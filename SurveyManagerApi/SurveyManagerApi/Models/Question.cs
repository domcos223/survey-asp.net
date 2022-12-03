using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SurveyManagerApi.Models
{
    public class Question
    {   
        [Key]
        public string Id { get; set; }
        public string SurveyId { get; set; }
        public string Text { get; set; }
        public ICollection<Option> Options { get; set; }

        public string MostAnsweredOp { get; set; }

        [JsonIgnore]
        public virtual Survey? Survey { get; set;}


    }
}
