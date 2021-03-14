using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Core.DomainObjects
{
    public class Entity
    {
        public Entity()
        {
            Stamp = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime Stamp { get; set; }
    }
}
