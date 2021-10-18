namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraryy",
                c => new
                    {
                        LibraryID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LibraryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Libraryy");
        }
    }
}
