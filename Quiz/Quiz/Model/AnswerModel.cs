using Quiz.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Model
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Boolean isCorrect { get; set; }
    }
}
