using Questionnaire.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Core.ResponseModels
{
    public class QuestionResponseModel
    {
        public IList<QuestionViewModel> Questions { get; set; }

    }
}
