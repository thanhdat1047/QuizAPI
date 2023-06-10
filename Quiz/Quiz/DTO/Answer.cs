using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Quiz.DTO.Base;

namespace Quiz.DTO
{
    [Table("Answers")]
    public class Answer :BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public int QuestionId { get; set; } 

        [MaxLength(500)]
        public string Content { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public Boolean isCorrect { get; set; }


    }
}
