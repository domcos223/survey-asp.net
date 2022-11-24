using SurveyManagerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SurveyManagerApi.DTOs
{
    public class OptionDTO
    {

        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
      
    }
}
