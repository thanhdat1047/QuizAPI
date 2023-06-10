using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Quiz.DTO.Base;

namespace Quiz.DTO
{
    [Table("DetailUserSessions")]
    public class DetailUserSession : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int? UserAnswerId { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }  

       
        public int UserSessionId { get; set; }
        [ForeignKey("UserSessionId")]
        public virtual UserSession UserSession { get; set; }

        public Boolean IsCorrect { get; set; }

    }
}
