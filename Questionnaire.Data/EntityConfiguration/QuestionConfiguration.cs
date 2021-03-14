using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Data.EntityConfiguration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasMany<QuestionOption>(o => o.Options)
                .WithOne(q => q.Question)
                .HasForeignKey(o => o.QuestionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            var Questions = new List<Question>()
            {
                new Question() { QuestionStatement = "Which is the national flower of Poland?", Id = 1},
                new Question() { QuestionStatement = "Which city is now the capital of Poland?", Id = 2 },
                new Question() { QuestionStatement = "Which countries border Poland?", Id = 3 }
            };
            builder.HasData(Questions);

           
        }
    }
}
