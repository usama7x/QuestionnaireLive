using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Data.DatabaseContext
{
   public class QuestionnaireContext: DbContext
    {
        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options) { }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionsOptions { get; set; }
        public DbSet<Answer> Answers{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(QuestionnaireContext).Assembly);
        }

    }
}
