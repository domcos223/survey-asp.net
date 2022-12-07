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
using SurveyManagerApi.Services;

namespace SurveyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _service;

        public SurveysController(ISurveyService service)
        {
            _service = service;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survey>>> GetSurveys()
        {
            return await _service.GetAll();
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(string id)
        {
            var survey =  await _service.GetById(id);
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
            var surveyFromDb = _service.Submit(id, filledSurvey);
            if (surveyFromDb == null)
            {
                return NotFound();
            }
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
             _service.Add(survey);
            
            return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(string id)
        {   
            var survey = await _service.GetById(id);
            if (survey == null)
            {
                return NotFound();
            }
            _service.Delete(id);

            return NoContent();
        }

    }
}
