using Microsoft.AspNetCore.Mvc;
using SurveyManagerApi.Models;

namespace SurveyManagerApi.Services
{
    public interface ISurveyService
    {
        Task<ActionResult<IEnumerable<Survey>>> GetAll();
        Task<ActionResult<Survey>> GetById(string id);
        void Add(Survey survey);
        Task<Survey> Submit(string id, Survey survey);
        void Delete(string id);



    }
}
