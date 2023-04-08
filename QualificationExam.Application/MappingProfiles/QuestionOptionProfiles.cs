namespace QualificationExam.Application.MappingProfiles
{
    public class QuestionOptionProfiles:Profile
    {
        public QuestionOptionProfiles()
        {
            CreateMap<QuestionOption, CreateQuestionOptionRequest>().ReverseMap();
            CreateMap<QuestionOption,UpdateQuestionOptionRequest>();
            CreateMap<QuestionOption, QuestionDetailResponse>();
        }
    }
}
