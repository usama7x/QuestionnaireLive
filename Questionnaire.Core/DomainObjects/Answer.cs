using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Questionnaire.Core.DomainObjects
{
    public class Answer : Entity
    {
        public string UserName { get; set; }

        [Required]
        public int QuestionId { get; set; }
       
        [Required]
        public int OptionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}
