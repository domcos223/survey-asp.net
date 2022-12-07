using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyManagerApi.Data;
using SurveyManagerApi.Models;

namespace SurveyManagerApi.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyManagerContext _context;

        public SurveyService(SurveyManagerContext context)
        {
            _context = context;
        }

        public async void Add(Survey survey)
        {
            foreach (var q in survey.Questions)
            {
                q.Survey = survey;
                foreach (var o in q.Options)
                {
                    o.Question = q;
                }
            }
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
        }

        public async void Delete(string id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Survey>>> GetAll()
        {
            return await _context.Surveys.Include(i => i.Questions).ThenInclude(t => t.Options).ToListAsync();
        }

        public async Task<ActionResult<Survey>> GetById(string id)
        {

            var survey = await _context.Surveys.Include(i => i.Questions).ThenInclude(t => t.Options).Where(s => s.Id == id).SingleOrDefaultAsync();

            return survey;
        }

        public async Task<Survey> Submit(string id, Survey filledSurvey)
        {

            var survey = await _context.Surveys.AsNoTracking().Include(i => i.Questions).ThenInclude(t => t.Options).Where(s => s.Id == id).SingleOrDefaultAsync();

            foreach (var q in filledSurvey.Questions)
            {
                foreach (var o in q.Options)
                {
                    _context.Update(o);
                }
                await _context.SaveChangesAsync();
            }
            _context.Entry(filledSurvey).State = EntityState.Modified;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            var pickedOptions = _context.Options.Where(o => o.IsPicked == true);
            foreach (var option in pickedOptions)
            {
                option.Answered++;
                option.IsPicked = false; //reset 
            }

            var questions = _context.Questions.Where(q => q.SurveyId == id).ToList();
            foreach (var q in questions)
            {
                var previous = q.MostAnsweredOp;
                var mostAnsweredOp = q.Options.MaxBy(o => o.Answered).Text;
                q.MostAnsweredOp = mostAnsweredOp;
            }
            _context.SaveChanges();

            return survey;
        }
    }
}
