namespace WebApplication1.Data;

public class QuizSession
{
    public required string Continent { get; set; }
    public required List<QuizQuestionSession> Questions { get; set; }
}

public class QuizQuestionSession
{
    public int CorrectCountryId { get; set; }
    public required List<int> OptionCountryIds { get; set; }
}
