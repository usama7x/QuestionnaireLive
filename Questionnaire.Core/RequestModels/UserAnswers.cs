using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Core.RequestModels
{
    public class UserAnswers
    {
        public string User { get; set; }
        public Dictionary<string,int[]> Answers { get; set; }
    }
}
