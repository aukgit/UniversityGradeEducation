namespace UGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleMistake",
                c => new
                    {
                        ArticleMistakeID = c.Long(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ArticleID = c.Long(nullable: false),
                        SubmitedDated = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.ArticleMistakeID);
            
            CreateTable(
                "dbo.ReplyAgainstMistake",
                c => new
                    {
                        ReplyAgainstMistakeID = c.Long(nullable: false, identity: true),
                        ArticleMistakeID = c.Long(nullable: false),
                        RepliedByWhomID = c.Int(nullable: false),
                        Reply = c.String(nullable: false, maxLength: 800, unicode: false),
                        LinkedReplyMistakeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyAgainstMistakeID)
                .ForeignKey("dbo.ReplyAgainstMistake", t => t.LinkedReplyMistakeID)
                .ForeignKey("dbo.ArticleMistake", t => t.ArticleMistakeID)
                .Index(t => t.ArticleMistakeID)
                .Index(t => t.LinkedReplyMistakeID);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleID = c.Long(nullable: false, identity: true),
                        ArticleName = c.String(nullable: false, maxLength: 150, unicode: false),
                        Description = c.String(nullable: false, maxLength: 800, unicode: false),
                        PreviousArticleID = c.Long(),
                        NextArticleID = c.Long(),
                        ChapterID = c.Int(nullable: false),
                        VideoLink = c.String(nullable: false, maxLength: 800, unicode: false),
                        Height = c.Short(nullable: false),
                        Width = c.Short(nullable: false),
                        AvgRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.Article", t => t.PreviousArticleID)
                .ForeignKey("dbo.Article", t => t.NextArticleID)
                .ForeignKey("dbo.Chapter", t => t.ChapterID)
                .Index(t => t.PreviousArticleID)
                .Index(t => t.NextArticleID)
                .Index(t => t.ChapterID);
            
            CreateTable(
                "dbo.Bookmark",
                c => new
                    {
                        BookmarkID = c.Long(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ArticleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BookmarkID)
                .ForeignKey("dbo.User", t => t.UserID)
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .Index(t => t.UserID)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 40, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        AccountID = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(nullable: false, maxLength: 101, unicode: false),
                        UserRole_UserRoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRole", t => t.UserRole_UserRoleID)
                .Index(t => t.UserRole_UserRoleID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingID = c.Long(nullable: false, identity: true),
                        ArticleID = c.Long(nullable: false),
                        UserID = c.Int(nullable: false),
                        VideoQualtiy = c.Byte(nullable: false),
                        TechingTechnique = c.Byte(nullable: false),
                        Materials = c.Byte(nullable: false),
                        AvgRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.User", t => t.UserID)
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .Index(t => t.ArticleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.WishList",
                c => new
                    {
                        WishListID = c.Long(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ArticleID = c.Long(nullable: false),
                        Dated = c.DateTime(nullable: false, storeType: "date"),
                        LastNotified = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.WishListID)
                .ForeignKey("dbo.User", t => t.UserID)
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .Index(t => t.UserID)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.Chapter",
                c => new
                    {
                        ChapterID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        TopicName = c.String(nullable: false, maxLength: 150, unicode: false),
                        TotalArticles = c.Int(nullable: false),
                        MasterArticleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ChapterID)
                .ForeignKey("dbo.Book", t => t.BookID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Byte(nullable: false),
                        BookName = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Byte(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.LinksToDisplay",
                c => new
                    {
                        LinksToDisplayID = c.Long(nullable: false, identity: true),
                        ArticleID = c.Long(nullable: false),
                        ChapterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LinksToDisplayID)
                .ForeignKey("dbo.Chapter", t => t.ChapterID)
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .Index(t => t.ArticleID)
                .Index(t => t.ChapterID);
            
            CreateTable(
                "dbo.MCQ",
                c => new
                    {
                        MCQID = c.Int(nullable: false, identity: true),
                        Duration = c.Short(nullable: false),
                        ArticleID = c.Long(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150, unicode: false),
                        DisplayQuestion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MCQID)
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Long(nullable: false, identity: true),
                        Hint = c.String(maxLength: 200, unicode: false),
                        AnswerChoiceID = c.Long(nullable: false),
                        QuestionDisplay = c.String(nullable: false, maxLength: 800, unicode: false),
                        MCQID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Choice", t => t.AnswerChoiceID)
                .ForeignKey("dbo.MCQ", t => t.MCQID)
                .Index(t => t.AnswerChoiceID)
                .Index(t => t.MCQID);
            
            CreateTable(
                "dbo.Choice",
                c => new
                    {
                        ChoiceID = c.Long(nullable: false, identity: true),
                        QuestionID = c.Long(nullable: false),
                        ChoiceDisplay = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.ChoiceID)
                .ForeignKey("dbo.Question", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.WatchedReference",
                c => new
                    {
                        WatchedReferenceID = c.Long(nullable: false, identity: true),
                        WhichFromArticleID = c.Long(nullable: false),
                        WhichToArticleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.WatchedReferenceID)
                .ForeignKey("dbo.Article", t => t.WhichFromArticleID)
                .ForeignKey("dbo.Article", t => t.WhichToArticleID)
                .Index(t => t.WhichFromArticleID)
                .Index(t => t.WhichToArticleID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 30, unicode: false),
                        RolePriority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRole_UserRoleID", "dbo.UserRole");
            DropForeignKey("dbo.WishList", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.WatchedReference", "WhichToArticleID", "dbo.Article");
            DropForeignKey("dbo.WatchedReference", "WhichFromArticleID", "dbo.Article");
            DropForeignKey("dbo.Rating", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.MCQ", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.Question", "MCQID", "dbo.MCQ");
            DropForeignKey("dbo.Choice", "QuestionID", "dbo.Question");
            DropForeignKey("dbo.Question", "AnswerChoiceID", "dbo.Choice");
            DropForeignKey("dbo.LinksToDisplay", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.LinksToDisplay", "ChapterID", "dbo.Chapter");
            DropForeignKey("dbo.Book", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Chapter", "BookID", "dbo.Book");
            DropForeignKey("dbo.Article", "ChapterID", "dbo.Chapter");
            DropForeignKey("dbo.Bookmark", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.WishList", "UserID", "dbo.User");
            DropForeignKey("dbo.Rating", "UserID", "dbo.User");
            DropForeignKey("dbo.Bookmark", "UserID", "dbo.User");
            DropForeignKey("dbo.Article", "NextArticleID", "dbo.Article");
            DropForeignKey("dbo.Article", "PreviousArticleID", "dbo.Article");
            DropForeignKey("dbo.ReplyAgainstMistake", "ArticleMistakeID", "dbo.ArticleMistake");
            DropForeignKey("dbo.ReplyAgainstMistake", "LinkedReplyMistakeID", "dbo.ReplyAgainstMistake");
            DropIndex("dbo.WatchedReference", new[] { "WhichToArticleID" });
            DropIndex("dbo.WatchedReference", new[] { "WhichFromArticleID" });
            DropIndex("dbo.Choice", new[] { "QuestionID" });
            DropIndex("dbo.Question", new[] { "MCQID" });
            DropIndex("dbo.Question", new[] { "AnswerChoiceID" });
            DropIndex("dbo.MCQ", new[] { "ArticleID" });
            DropIndex("dbo.LinksToDisplay", new[] { "ChapterID" });
            DropIndex("dbo.LinksToDisplay", new[] { "ArticleID" });
            DropIndex("dbo.Book", new[] { "SubjectID" });
            DropIndex("dbo.Chapter", new[] { "BookID" });
            DropIndex("dbo.WishList", new[] { "ArticleID" });
            DropIndex("dbo.WishList", new[] { "UserID" });
            DropIndex("dbo.Rating", new[] { "UserID" });
            DropIndex("dbo.Rating", new[] { "ArticleID" });
            DropIndex("dbo.User", new[] { "UserRole_UserRoleID" });
            DropIndex("dbo.Bookmark", new[] { "ArticleID" });
            DropIndex("dbo.Bookmark", new[] { "UserID" });
            DropIndex("dbo.Article", new[] { "ChapterID" });
            DropIndex("dbo.Article", new[] { "NextArticleID" });
            DropIndex("dbo.Article", new[] { "PreviousArticleID" });
            DropIndex("dbo.ReplyAgainstMistake", new[] { "LinkedReplyMistakeID" });
            DropIndex("dbo.ReplyAgainstMistake", new[] { "ArticleMistakeID" });
            DropTable("dbo.UserRole");
            DropTable("dbo.WatchedReference");
            DropTable("dbo.Choice");
            DropTable("dbo.Question");
            DropTable("dbo.MCQ");
            DropTable("dbo.LinksToDisplay");
            DropTable("dbo.Subject");
            DropTable("dbo.Book");
            DropTable("dbo.Chapter");
            DropTable("dbo.WishList");
            DropTable("dbo.Rating");
            DropTable("dbo.User");
            DropTable("dbo.Bookmark");
            DropTable("dbo.Article");
            DropTable("dbo.ReplyAgainstMistake");
            DropTable("dbo.ArticleMistake");
        }
    }
}
