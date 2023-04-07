namespace QualificationExam.Application.MappingProfiles
{
    public class QuizProfile:Profile
    {
        public QuizProfile()
        {
           CreateMap<Quiz,CreateQuizRequest>().ReverseMap();
            CreateMap<Quiz, QuizDetailResponse>()
                .ForMember(dest => dest.questionDetails
                , act => act.MapFrom(src => src.Questions));
            CreateMap<Quiz, UpdateQuizRequest>().ReverseMap();
        }
    }
}
