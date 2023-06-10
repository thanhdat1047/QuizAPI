using Microsoft.AspNetCore.Mvc;
using Quiz.DAL;
using Quiz.DTO;
using Quiz.Model;

namespace Quiz.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuizContext _context;
        public QuestionController(QuizContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/get_list_question")]
        public IEnumerable<QuestionModel> Get()
        {
            var rs = _context.Question.Select(x => new QuestionModel
            {
                Id = x.Id,
                Content = x.Content,
                Answers = x.Answers.Select(y => new AnswerModel
                { 
                    Id = y.Id, Content = y.Content, isCorrect = y.isCorrect
                }).ToList()
            }).ToArray();
            return rs;
        }

        [HttpGet]
        [Route("/get_list_question_by_id/{id}")]

        public IEnumerable<QuestionModel> Get(int id)
        {
            var rs = _context.Question.Where(x => x.Id == id).Select(x => new QuestionModel
            {
                Id = x.Id,
                Content = x.Content,
                Answers = x.Answers.Select(y => new AnswerModel
                {
                    Id = y.Id,
                    Content = y.Content,
                    isCorrect = y.isCorrect
                }).ToList()
            }).ToArray();
            return rs;
        }


    }


}
