namespace TourismMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTourismTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgencyProfiles",
                c => new
                    {
                        AgencyId = c.Int(nullable: false, identity: true),
                        AgencyName = c.String(nullable: false, maxLength: 120),
                        ServicesOffered = c.String(maxLength: 500),
                        Description = c.String(maxLength: 800),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AgencyId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TravelPackages",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false, maxLength: 1200),
                        Destination = c.String(nullable: false, maxLength: 120),
                        ImagePath = c.String(maxLength: 300),
                        AgencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackageId)
                .ForeignKey("dbo.AgencyProfiles", t => t.AgencyId, cascadeDelete: true)
                .Index(t => t.AgencyId);
            
            CreateTable(
                "dbo.TourSchedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        AvailableDate = c.DateTime(nullable: false),
                        DurationDays = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupSizeLimit = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.TravelPackages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        TouristId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        ParticipantsCount = c.Int(nullable: false),
                        BookingStatus = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.TouristProfiles", t => t.TouristId, cascadeDelete: true)
                .ForeignKey("dbo.TourSchedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.TouristId)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(maxLength: 1000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.TouristProfiles",
                c => new
                    {
                        TouristId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 120),
                        ContactNumber = c.String(maxLength: 30),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TouristId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AgencyProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TourSchedules", "PackageId", "dbo.TravelPackages");
            DropForeignKey("dbo.Bookings", "ScheduleId", "dbo.TourSchedules");
            DropForeignKey("dbo.TouristProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "TouristId", "dbo.TouristProfiles");
            DropForeignKey("dbo.Feedbacks", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.TravelPackages", "AgencyId", "dbo.AgencyProfiles");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TouristProfiles", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "ScheduleId" });
            DropIndex("dbo.Bookings", new[] { "TouristId" });
            DropIndex("dbo.TourSchedules", new[] { "PackageId" });
            DropIndex("dbo.TravelPackages", new[] { "AgencyId" });
            DropIndex("dbo.AgencyProfiles", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TouristProfiles");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Bookings");
            DropTable("dbo.TourSchedules");
            DropTable("dbo.TravelPackages");
            DropTable("dbo.AgencyProfiles");
        }
    }
}
