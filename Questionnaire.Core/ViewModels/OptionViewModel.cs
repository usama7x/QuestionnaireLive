using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Core.ViewModels
{
    public class OptionViewModel
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string OptionStatement { get; set; }
        public bool isCorrect { get; set; }
    }
}
