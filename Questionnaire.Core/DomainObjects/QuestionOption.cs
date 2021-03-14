using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Questionnaire.Core.DomainObjects
{
    public class QuestionOption : Entity
    {
        public int QuestionId { get; set; }
        [Required, MaxLength(50)]
        public string OptionStatement { get; set; }
        public bool isCorrect { get; set; }
        public virtual Question Question { get; set; }
    }
}
