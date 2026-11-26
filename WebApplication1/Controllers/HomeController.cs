using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private const string QuizSessionKey = "active-quiz";
        private readonly QuizDbContext _database;

        public HomeController(QuizDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Hello()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Quiz(string continent)
        {
            var allCountries = await _database.Countries.ToListAsync();
            var questionCountries = continent.Equals("Random", StringComparison.OrdinalIgnoreCase)
                ? allCountries
                : allCountries.Where(country => country.Continent == continent).ToList();

            if (questionCountries.Count < 4)
            {
                return RedirectToAction(nameof(Hello));
            }

            var questions = questionCountries
                .OrderBy(_ => Random.Shared.Next())
                .Take(3)
                .Select(correctCountry =>
                {
                    var wrongOptions = allCountries
                        .Where(country => country.Continent == correctCountry.Continent)
                        .Where(country => country.Id != correctCountry.Id)
                        .GroupBy(country => country.Code, StringComparer.OrdinalIgnoreCase)
                        .Select(group => group.First())
                        .OrderBy(_ => Random.Shared.Next())
                        .Take(3)
                        .ToList();
                    wrongOptions.Add(correctCountry);

                    return new QuizQuestionSession
                    {
                        CorrectCountryId = correctCountry.Id,
                        OptionCountryIds = wrongOptions
                            .OrderBy(_ => Random.Shared.Next())
                            .Select(country => country.Id)
                            .ToList()
                    };
                })
                .ToList();

            HttpContext.Session.SetString(QuizSessionKey, JsonSerializer.Serialize(new QuizSession
            {
                Continent = continent,
                Questions = questions
            }));

            return View(new QuizViewModel
            {
                Continent = continent,
                Questions = questions.Select((question, index) => new QuizQuestionViewModel
                {
                    Number = index + 1,
                    FlagUrl = GetFlagUrl(allCountries.Single(country => country.Id == question.CorrectCountryId).Code),
                    Options = question.OptionCountryIds
                        .Select(id => allCountries.Single(country => country.Id == id))
                        .OrderBy(_ => Random.Shared.Next())
                        .ToList()
                }).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Quiz(QuizSubmissionViewModel submission)
        {
            var sessionJson = HttpContext.Session.GetString(QuizSessionKey);
            if (sessionJson is null)
            {
                return RedirectToAction(nameof(Hello));
            }

            var quiz = JsonSerializer.Deserialize<QuizSession>(sessionJson);
            if (quiz is null)
            {
                return RedirectToAction(nameof(Hello));
            }

            var countryIds = quiz.Questions
                .SelectMany(question => question.OptionCountryIds)
                .Distinct()
                .ToList();
            var countries = await _database.Countries
                .Where(country => countryIds.Contains(country.Id))
                .ToDictionaryAsync(country => country.Id);

            var results = quiz.Questions.Select((question, index) =>
            {
                var correctCountry = countries[question.CorrectCountryId];
                var selectedId = index < submission.Answers.Count ? submission.Answers[index] : null;
                var selectedAnswer = selectedId.HasValue && countries.TryGetValue(selectedId.Value, out var selectedCountry)
                    ? selectedCountry.Name
                    : null;

                return new QuizResultItemViewModel
                {
                    Number = index + 1,
                    FlagUrl = GetFlagUrl(correctCountry.Code),
                    CorrectAnswer = correctCountry.Name,
                    CorrectAnswerCode = correctCountry.Code,
                    SelectedAnswer = selectedAnswer,
                    SelectedAnswerCode = selectedId.HasValue && countries.TryGetValue(selectedId.Value, out var answerCountry)
                        ? answerCountry.Code
                        : null,
                    IsCorrect = selectedId == question.CorrectCountryId
                };
            }).ToList();

            HttpContext.Session.Remove(QuizSessionKey);

            return View("Results", new QuizResultsViewModel
            {
                Continent = quiz.Continent,
                Questions = results,
                CorrectCount = results.Count(result => result.IsCorrect)
            });
        }

        private static string GetFlagUrl(string countryCode) =>
            $"https://flagcdn.com/w320/{countryCode}.png";

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
