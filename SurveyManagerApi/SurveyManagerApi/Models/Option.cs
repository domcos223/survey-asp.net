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

        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
