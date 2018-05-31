namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetGames",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        BetId = c.Int(nullable: false),
                        ResultPrediction_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.GameId, t.BetId })
                .ForeignKey("dbo.Bets", t => t.BetId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.ResultPredictions", t => t.ResultPrediction_Id)
                .Index(t => t.GameId)
                .Index(t => t.BetId)
                .Index(t => t.ResultPrediction_Id);
            
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BetMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfBet = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        DateTimeOfGame = c.DateTime(nullable: false),
                        HomeTeamWinBetRate = c.Double(nullable: false),
                        AwayTeamWinBetRate = c.Double(nullable: false),
                        DrawBetRate = c.Double(nullable: false),
                        AwayTeam_Id = c.Int(),
                        Competition_Id = c.Int(),
                        HomeTeam_Id = c.Int(),
                        Round_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .ForeignKey("dbo.Rounds", t => t.Round_Id)
                .Index(t => t.AwayTeam_Id)
                .Index(t => t.Competition_Id)
                .Index(t => t.HomeTeam_Id)
                .Index(t => t.Round_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Logo = c.Binary(nullable: false),
                        ThreeLetterInitials = c.String(nullable: false, maxLength: 3),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrimaryKitColor_Id = c.Int(nullable: false),
                        SecondaryKitColor_Id = c.Int(nullable: false),
                        Town_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.PrimaryKitColor_Id, cascadeDelete: false)
                .ForeignKey("dbo.Colors", t => t.SecondaryKitColor_Id, cascadeDelete: false)
                .ForeignKey("dbo.Towns", t => t.Town_Id)
                .Index(t => t.PrimaryKitColor_Id)
                .Index(t => t.SecondaryKitColor_Id)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SquadNumber = c.Int(nullable: false),
                        IsCurrentlyInjured = c.Boolean(nullable: false),
                        Position_Id = c.String(maxLength: 2),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.PlayerStatistics",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        ScoredGoals = c.Int(nullable: false),
                        PlayerAssists = c.Int(nullable: false),
                        PlayedMinutesDuringGame = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.PlayerId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 2),
                        PositionDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Country_Id = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompetitionTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResultPredictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prediction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CountryContinents",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 3),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CountryId, t.ContinentId })
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.ContinentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BetGames", "ResultPrediction_Id", "dbo.ResultPredictions");
            DropForeignKey("dbo.BetGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "Round_Id", "dbo.Rounds");
            DropForeignKey("dbo.Games", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Competitions", "Type_Id", "dbo.CompetitionTypes");
            DropForeignKey("dbo.Games", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.Games", "AwayTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.CountryContinents", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.CountryContinents", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Teams", "SecondaryKitColor_Id", "dbo.Colors");
            DropForeignKey("dbo.Teams", "PrimaryKitColor_Id", "dbo.Colors");
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.PlayerStatistics", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerStatistics", "GameId", "dbo.Games");
            DropForeignKey("dbo.BetGames", "BetId", "dbo.Bets");
            DropForeignKey("dbo.Bets", "User_Id", "dbo.Users");
            DropIndex("dbo.CountryContinents", new[] { "ContinentId" });
            DropIndex("dbo.CountryContinents", new[] { "CountryId" });
            DropIndex("dbo.Competitions", new[] { "Type_Id" });
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            DropIndex("dbo.PlayerStatistics", new[] { "PlayerId" });
            DropIndex("dbo.PlayerStatistics", new[] { "GameId" });
            DropIndex("dbo.Players", new[] { "Team_Id" });
            DropIndex("dbo.Players", new[] { "Position_Id" });
            DropIndex("dbo.Teams", new[] { "Town_Id" });
            DropIndex("dbo.Teams", new[] { "SecondaryKitColor_Id" });
            DropIndex("dbo.Teams", new[] { "PrimaryKitColor_Id" });
            DropIndex("dbo.Games", new[] { "Round_Id" });
            DropIndex("dbo.Games", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Games", new[] { "Competition_Id" });
            DropIndex("dbo.Games", new[] { "AwayTeam_Id" });
            DropIndex("dbo.Bets", new[] { "User_Id" });
            DropIndex("dbo.BetGames", new[] { "ResultPrediction_Id" });
            DropIndex("dbo.BetGames", new[] { "BetId" });
            DropIndex("dbo.BetGames", new[] { "GameId" });
            DropTable("dbo.CountryContinents");
            DropTable("dbo.ResultPredictions");
            DropTable("dbo.Rounds");
            DropTable("dbo.CompetitionTypes");
            DropTable("dbo.Competitions");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.Towns");
            DropTable("dbo.Colors");
            DropTable("dbo.Positions");
            DropTable("dbo.PlayerStatistics");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
            DropTable("dbo.Users");
            DropTable("dbo.Bets");
            DropTable("dbo.BetGames");
        }
    }
}
