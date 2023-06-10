using Quiz.DTO;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Model
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public virtual ICollection<AnswerModel> Answers { get; set; }
    }
}
