namespace QualificationExam.Application.MappingProfiles
{
    public class QuizProfile:Profile
    {
        public QuizProfile()
        {
           CreateMap<Quiz,CreateQuizRequest>().ReverseMap();
           CreateMap<Quiz,QuizDetailResponse>().ReverseMap();
           CreateMap<Quiz,UpdateQuizRequest>().ReverseMap();    
        }
    }
}
