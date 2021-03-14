using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questionnaire.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Data.EntityConfiguration
{
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder
                .HasOne<Question>(q => q.Question)
                .WithMany(o => o.Options)
                .HasForeignKey(x => x.QuestionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            var questionsOptions = new List<QuestionOption>()
            {
                //first question options
                new QuestionOption() { OptionStatement = "Lily", QuestionId = 1, Id = 1 },
                new QuestionOption() { OptionStatement = "Corn Poppy", QuestionId = 1, Id = 2, isCorrect = true },
                new QuestionOption() { OptionStatement = "Lavender", QuestionId = 1, Id = 3 },
                new QuestionOption() { OptionStatement = "Flor De Maga", QuestionId = 1, Id = 4 },

                //second question options
                new QuestionOption() { OptionStatement = "Astana", QuestionId = 2, Id = 5 },
                new QuestionOption() { OptionStatement = "Warsaw", QuestionId = 2, Id = 6, isCorrect = true },
                new QuestionOption() { OptionStatement = "Krakow", QuestionId = 2, Id = 7 },
                new QuestionOption() { OptionStatement = "Bucharest", QuestionId = 2, Id = 8 },

                //third question options
                new QuestionOption() { OptionStatement = "Germany", QuestionId = 3, Id = 9, isCorrect = true},
                new QuestionOption() { OptionStatement = "Ukraine", QuestionId = 3, Id = 10, isCorrect = true },
                new QuestionOption() { OptionStatement = "Romania", QuestionId = 3, Id = 11},
                new QuestionOption() { OptionStatement = "Italy ", QuestionId = 3, Id = 12}
            };
            builder.HasData(questionsOptions);

        }
    }
}
