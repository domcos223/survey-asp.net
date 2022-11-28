using Microsoft.EntityFrameworkCore;
using SurveyManagerApi.Models;

namespace SurveyManagerApi.Data
{
    public class SurveyManagerContext : DbContext, ISurveyManagerContext
    {
        public SurveyManagerContext(DbContextOptions<SurveyManagerContext> options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
