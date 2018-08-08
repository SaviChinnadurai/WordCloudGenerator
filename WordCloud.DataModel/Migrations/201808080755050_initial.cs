namespace WordCloud.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WordDMs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        WordText = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WordDMs");
        }
    }
}
