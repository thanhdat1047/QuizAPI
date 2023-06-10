using Microsoft.AspNetCore.Mvc;
using Quiz.DAL;
using Quiz.DTO;
using Quiz.Model;

namespace Quiz.Controllers
{
    public class DetailUserSessionController
    {
        private readonly QuizContext _context;
        public DetailUserSessionController(QuizContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("/create_detail_user_session")]
        public bool PostUserSessionController(DetailUserSessionModel model)
        {
            var answer = _context.Answer.SingleOrDefault(a => a.Id == model.UserAnswerId && a.QuestionId == model.QuestionId);

            if (answer == null)
            {
                return false;     
            }
            var correctAnswer = _context.Answer.SingleOrDefault(a => a.QuestionId == model.QuestionId && a.isCorrect == true);



            var detailUserSession = new DetailUserSession
            {
                
                UserAnswerId  = model.UserAnswerId,
                QuestionId = model.QuestionId,
                UserSessionId = model.UserSessionId,
                IsCorrect = answer.Id == correctAnswer.Id
                
            };
            _context.DetailUserSession.Add(detailUserSession);
            _context.SaveChanges();

            return true;

        }

        [HttpGet]
        [Route("/get_list_Detail")]
        public IEnumerable<DetailUserSessionModel> Get()
        {
            var rs = _context.DetailUserSession.Select(x => new DetailUserSessionModel
            {
                Id = x.Id,
                UserAnswerId = x.UserSessionId,
                QuestionId = x.QuestionId,
                IsCorrect   =x.IsCorrect,
                UserSessionId=x.UserSessionId,
            }).ToArray();
            return rs;
        }
       
    }
}
