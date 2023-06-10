using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.DAL;
using Quiz.DTO;
using Quiz.Model;
using System;

namespace Quiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSessionController :ControllerBase
    {
        private readonly QuizContext _context;
        public UserSessionController(QuizContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/get_result")]
        public IEnumerable<UserSessionMode> Get()
        {
            var rs = _context.UserSession.Select(x => new UserSessionMode
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                UserSessionId = x.UserSessionId,
                NumCorrectAnswer = x.NumCorrectAnswer,
                result = x.result,
                DetailUserSessionModels = _context.DetailUserSession
                .Where(y => y.UserSessionId == x.Id)
                .Select(y => new DetailUserSessionModel
                {
                    Id = y.Id,
                    UserSessionId = y.UserSessionId,
                    IsCorrect = y.IsCorrect,
                    UserAnswerId = y.UserAnswerId,
                    QuestionId = y.QuestionId,
                }).ToList()
            }).ToArray();
            return rs;

        }
        [HttpGet]
        [Route("/get_result_by_id_session/{id}")]
        public IEnumerable<UserSessionMode> Get(int Id)
        {
            var rs = _context.UserSession.Where(x=>x.Id==Id).Select(x => new UserSessionMode
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                UserSessionId = x.UserSessionId,
                NumCorrectAnswer = x.NumCorrectAnswer,
                result = x.result,
                DetailUserSessionModels = _context.DetailUserSession
                .Where(y => y.UserSessionId == x.Id)
                .Select(y => new DetailUserSessionModel
                {
                    Id = y.Id,
                    UserSessionId = y.UserSessionId,
                    IsCorrect = y.IsCorrect,
                    UserAnswerId = y.UserAnswerId,
                    QuestionId = y.QuestionId,
                }).ToList()
            }).ToArray();
            return rs;

        }

        [HttpPost]
        [Route("/create_user_session")]
        public bool PostUserSessionController(UserSessionMode model)
        {
            var userSession = new UserSession
            {

                UserSessionId = model.UserSessionId,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                InsertDate = DateTime.Now
            };
            _context.UserSession.Add(userSession);
            _context.SaveChanges();

            return true;

        }
        [HttpPost]
        [Route("/update_numCorrect_UserSession")]
        public bool PostUpdateUserSession(int IdSession)
        {
            int numCorrect = _context.UserSession.Where(x => x.Id == IdSession)
                .SelectMany(x => x.DetailUserSessions)
                .Count(d => d.IsCorrect);
            var session = _context.UserSession.Find(IdSession);
            session.NumCorrectAnswer = numCorrect;

            if (numCorrect >= 6)
                session.result = true;
            else
                session.result = false;

            _context.SaveChanges();
            return true;
        } 



       
    }
}
