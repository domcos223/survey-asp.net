using SurveyManagerApi.Models;

namespace SurveyManagerApi.DTOs
{
    public class QuestionDTO
    {
        public string Id { get; set; }
        public string SurveyId { get; set; }
        public string Text { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
