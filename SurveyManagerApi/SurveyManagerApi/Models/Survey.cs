namespace SurveyManagerApi.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Details { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
