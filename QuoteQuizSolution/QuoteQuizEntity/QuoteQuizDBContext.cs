using Microsoft.EntityFrameworkCore;
using QuoteQuizEntity.Entities;

namespace QuoteQuizEntity.Entities
{
    public class QuoteQuizDBContext : DbContext
    {
        public QuoteQuizDBContext()
        {
        }


        public QuoteQuizDBContext(DbContextOptions<QuoteQuizDBContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteType> QuoteTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Answer>(entity =>
        //    //{
        //    //    entity.HasIndex(x => x.statementName);
        //    //});
        //    //modelBuilder.Entity<Statement>(entity =>
        //    //{
        //    //    entity.HasIndex(x => x.statementName);
        //    //});
        //}
    }
}