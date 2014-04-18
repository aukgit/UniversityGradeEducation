namespace UGE.Models.DbContext {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UGEContext : DbContext {
        public UGEContext()
            : base("name=UGEContext") {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleMistake> ArticleMistakes { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<LinksToDisplay> LinksToDisplays { get; set; }
        public virtual DbSet<MCQ> MCQs { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<ReplyAgainstMistake> ReplyAgainstMistakes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WatchedReference> WatchedReferences { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Article>()
                .Property(e => e.ArticleName)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.VideoLink)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Article1)
                .WithOptional(e => e.Article2)
                .HasForeignKey(e => e.PreviousArticleID);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Article11)
                .WithOptional(e => e.Article3)
                .HasForeignKey(e => e.NextArticleID);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Bookmarks)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.LinksToDisplays)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.MCQs)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.WatchedReferences)
                .WithRequired(e => e.Article)
                .HasForeignKey(e => e.WhichFromArticleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.WatchedReferences1)
                .WithRequired(e => e.Article1)
                .HasForeignKey(e => e.WhichToArticleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.WishLists)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArticleMistake>()
                .HasMany(e => e.ReplyAgainstMistakes)
                .WithRequired(e => e.ArticleMistake)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Chapters)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chapter>()
                .Property(e => e.TopicName)
                .IsUnicode(false);

            modelBuilder.Entity<Chapter>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Chapter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chapter>()
                .HasMany(e => e.LinksToDisplays)
                .WithRequired(e => e.Chapter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Choice>()
                .Property(e => e.ChoiceDisplay)
                .IsUnicode(false);

            modelBuilder.Entity<Choice>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Choice)
                .HasForeignKey(e => e.AnswerChoiceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MCQ>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<MCQ>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.MCQ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Hint)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.QuestionDisplay)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Choices)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuestionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReplyAgainstMistake>()
                .Property(e => e.Reply)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyAgainstMistake>()
                .HasMany(e => e.ReplyAgainstMistake1)
                .WithRequired(e => e.ReplyAgainstMistake2)
                .HasForeignKey(e => e.LinkedReplyMistakeID);

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bookmarks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.WishLists)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
