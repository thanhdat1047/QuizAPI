using Quiz.DTO.Base;
using Quiz.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.DTO
{
    [Table("UserSession")]
    public class UserSession : BaseEntity
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string UserSessionId { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int NumCorrectAnswer { get; set; }

        public Boolean result { get; set; }

        public virtual ICollection<DetailUserSession> DetailUserSessions { get; set; }


    }
}
