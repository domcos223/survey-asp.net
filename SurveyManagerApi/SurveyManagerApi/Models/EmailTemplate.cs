using Microsoft.Build.Framework;

namespace SurveyManagerApi.Models
{
    public class EmailTemplate
    {
        [Required]
        public IEnumerable<string> Emails { get; set; }

        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
