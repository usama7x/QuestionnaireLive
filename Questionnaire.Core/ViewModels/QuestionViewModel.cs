using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Core.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public IList<OptionViewModel> Options { get; set; }
    }
}
