using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SurveyManagerApi.Models
{
    public class Option
    {
        [Key]
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsPicked { get; set; } = false;
        public int Answered { get; set; } = 0;
        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
