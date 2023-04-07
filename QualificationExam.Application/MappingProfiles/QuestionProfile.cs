namespace QualificationExam.Application.MappingProfiles
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question,CreateQuestionRequest>().ReverseMap();
            CreateMap<Question,UpdateQuestionRequest>().ReverseMap();
            CreateMap<Question, QuestionDetailResponse>().ReverseMap();
              
                
        }
    }
}
