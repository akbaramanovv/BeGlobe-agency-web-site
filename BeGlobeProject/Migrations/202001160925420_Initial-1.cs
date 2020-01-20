namespace BeGlobeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Advertisings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Photo = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Adress = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        EmployeeName = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Positionns", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Positionns",
                c => new
                    {
                        PositionnID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PositionnID);
            
            CreateTable(
                "dbo.Logoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Phone = c.String(),
                        EmailAdress = c.String(),
                        MessageText = c.String(),
                        Readed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        FileName = c.Binary(),
                        WorkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Works", t => t.WorkID, cascadeDelete: true)
                .Index(t => t.WorkID);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WorkPhoto = c.Binary(),
                        WorkFullImage = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "WorkID", "dbo.Works");
            DropForeignKey("dbo.Employees", "PositionID", "dbo.Positionns");
            DropIndex("dbo.Photos", new[] { "WorkID" });
            DropIndex("dbo.Employees", new[] { "PositionID" });
            DropTable("dbo.Services");
            DropTable("dbo.Works");
            DropTable("dbo.Photos");
            DropTable("dbo.Messages");
            DropTable("dbo.Logoes");
            DropTable("dbo.Positionns");
            DropTable("dbo.Employees");
            DropTable("dbo.Contacts");
            DropTable("dbo.Advertisings");
            DropTable("dbo.Admins");
        }
    }
}
