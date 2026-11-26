namespace WebApplication1.Models;

public class QuizViewModel
{
    public required string Continent { get; set; }
    public required List<QuizQuestionViewModel> Questions { get; set; }
}

public class QuizQuestionViewModel
{
    public int Number { get; set; }
    public required string FlagUrl { get; set; }
    public required List<Country> Options { get; set; }
}

public class QuizSubmissionViewModel
{
    public List<int?> Answers { get; set; } = [];
}

public class QuizResultsViewModel
{
    public required string Continent { get; set; }
    public required List<QuizResultItemViewModel> Questions { get; set; }
    public int CorrectCount { get; set; }
    public int TotalCount => Questions.Count;
    public int SuccessRate => TotalCount == 0 ? 0 : (int)Math.Round(CorrectCount * 100.0 / TotalCount);
}

public class QuizResultItemViewModel
{
    public int Number { get; set; }
    public required string FlagUrl { get; set; }
    public required string CorrectAnswer { get; set; }
    public required string CorrectAnswerCode { get; set; }
    public string? SelectedAnswer { get; set; }
    public string? SelectedAnswerCode { get; set; }
    public bool IsCorrect { get; set; }
}
