using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyManagerApi.Models
{
    public class Survey
    {
        public Survey() {

            Questions = new List<Question>();
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public string OptionType { get; set; }  
        public ICollection<Question> Questions { get; set; }
    }
}
