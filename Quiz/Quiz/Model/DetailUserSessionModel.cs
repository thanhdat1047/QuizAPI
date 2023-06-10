using Microsoft.AspNetCore.Mvc;
using Quiz.DAL;
using Quiz.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Model
{
   
    public class DetailUserSessionModel 
    {
        public int Id { get; set; }
        public int? UserAnswerId { get; set; }
        public int QuestionId { get; set; }
        public int UserSessionId { get; set; }
        public Boolean IsCorrect { get; set; }
    }

}
