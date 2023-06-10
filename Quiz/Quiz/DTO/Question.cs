using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Quiz.DTO.Base;

namespace Quiz.DTO
{
    
    [Table("Questions")]
    public class Question : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public String Content { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }    


    }
}
