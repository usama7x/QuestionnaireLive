using Questionnaire.Core.DomainObjects;
using Questionnaire.Core.RequestModels;
using Questionnaire.Core.ResponseModels;
using Questionnaire.Core.ViewModels;
using Questionnaire.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questionnaire.Services
{
   public interface IQuestionService
    {
        IList<QuestionViewModel> GetAll();

       bool Save(UserAnswers answers);
    }
    public class QuestionService : IQuestionService
    {
        private readonly QuestionnaireContext _questionnaireContext;
        public QuestionService(QuestionnaireContext questionnaireContext)
        {
            _questionnaireContext = questionnaireContext;
        }

        public IList<QuestionViewModel> GetAll()
        {
            var response = _questionnaireContext.Questions.Select(q => new QuestionViewModel
            {
                QuestionId = q.Id,
                Question = q.QuestionStatement,
                Options = q.Options.Select(o => new OptionViewModel
                {
                    OptionStatement = o.OptionStatement,
                    isCorrect = o.isCorrect,
                    OptionId = o.Id,
                    QuestionId = o.QuestionId
                   
                }).ToList()
            }).ToList();
            return response;
        }
        public bool Save(UserAnswers userAnswers)
        {
            foreach(KeyValuePair<string, int[]> entry in userAnswers.Answers)
            {
                foreach(int optionId in entry.Value)
                {
                    _questionnaireContext.Answers
                        .Add(
                            new Answer()
                            {
                                QuestionId = int.Parse(entry.Key),
                                OptionId = optionId,
                                UserName = userAnswers.User,
                                Stamp = DateTime.Now,
                                IsCorrect = _questionnaireContext.QuestionsOptions
                                            .Where(o => o.QuestionId == int.Parse(entry.Key))
                                            .Any(o => o.isCorrect && o.Id == optionId)
                               
                            });
                    _questionnaireContext.SaveChanges();
                }
            }
            return true;
        }
    }
}
