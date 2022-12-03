using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SurveyManagerApi.Data;
using SurveyManagerApi.Models;

namespace SurveyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly SurveyManagerContext _context;

        public SurveysController(SurveyManagerContext context)
        {
            _context = context;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            return await _context.Surveys.Include(i => i.Questions).ThenInclude(t => t.Options).ToListAsync();
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(string id)
        {
            var survey = await _context.Surveys.Include(i => i.Questions).ThenInclude(t => t.Options).Where(s => s.Id == id).SingleOrDefaultAsync();

            if (survey == null)
            {
                return NotFound();
            }

            return survey;
        }
 

        // PUT: api/Surveys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SaveAnswerSurvey( [FromRoute] string id, [FromBody] Survey filledSurvey)
        {
            if (id != filledSurvey.Id)
            {
                return BadRequest();
            }
            if (id == null || filledSurvey == null)
            {
                return BadRequest();
            }
            var survey = await _context.Surveys.AsNoTracking().Include(i => i.Questions).ThenInclude(t => t.Options).Where(s => s.Id == id).SingleOrDefaultAsync();

            if (survey == null) { 
                return NotFound();
            }
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
                option.IsPicked = false; //reset pick
            }

            var questions = _context.Questions.Where(q => q.SurveyId == id).ToList();
            foreach (var q in questions)
            {
                var previous = q.MostAnsweredOp;
                var mostAnsweredOp = q.Options.MaxBy(o => o.Answered).Text;
                q.MostAnsweredOp = mostAnsweredOp;
            }

            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/Surveys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Survey>> PostSurvey([FromBody] Survey survey)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
      
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

            return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(string id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }

            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurveyExists(string id)
        {
            return _context.Surveys.Any(e => e.Id == id);
        }
    }
}
