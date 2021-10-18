namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        BookName = c.String(nullable: false),
                        BookDescription = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}
