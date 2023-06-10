using Quiz.DTO;

namespace Quiz.Model
{
    public class UserSessionMode
    {
        public int Id { get; set; }

        public string UserSessionId { get; set; }


        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int NumCorrectAnswer { get; set; }

        public Boolean result { get; set; } 

        public virtual ICollection<DetailUserSessionModel> DetailUserSessionModels { get; set; }
    }
}
