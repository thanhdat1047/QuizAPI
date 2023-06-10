using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quiz.DTO.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("InsertDate")]
        public DateTime? InsertDate { get; set; }  
        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }
    }
}
