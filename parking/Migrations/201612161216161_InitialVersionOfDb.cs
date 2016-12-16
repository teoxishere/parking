namespace parking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialVersionOfDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingLots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MaxSpaces = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Token = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkingLotStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParkingLotId = c.Int(nullable: false),
                        FreeSpaces = c.Int(nullable: false),
                        ReporingDateTime = c.DateTime(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParkingLots", t => t.ParkingLotId, cascadeDelete: true)
                .Index(t => t.ParkingLotId);
            
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Set1 = c.String(maxLength: 200),
                        Set2 = c.String(maxLength: 200),
                        Set3 = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkingLotStatus", "ParkingLotId", "dbo.ParkingLots");
            DropIndex("dbo.ParkingLotStatus", new[] { "ParkingLotId" });
            DropTable("dbo.UserPreferences");
            DropTable("dbo.ParkingLotStatus");
            DropTable("dbo.ParkingLots");
        }
    }
}
