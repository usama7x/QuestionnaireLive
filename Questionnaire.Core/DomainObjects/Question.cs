using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Core.DomainObjects
{
    public class Question : Entity
    {
        public Question(): base() { }
        public string QuestionStatement { get; set; }

        public bool isActive { get; set; } = true;

        public virtual ICollection<QuestionOption> Options { get; set; }
    }
}
