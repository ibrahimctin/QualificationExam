﻿namespace QualificationExam.Domain.Enitities
{
    public class QuestionOption
    {
      
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public string questionId { get; set; }
        public Question Question { get; set; }
    }
}