using Microsoft.EntityFrameworkCore;
using SurveyManagerApi.Models;

namespace SurveyManagerApi.Data
{
    public interface ISurveyManagerContext
    {
        public abstract DbSet<Survey> Surveys { get; set; }
        public abstract DbSet<Question> Questions { get; set; }
        public abstract DbSet<Option> Options { get; set; }



    }
}