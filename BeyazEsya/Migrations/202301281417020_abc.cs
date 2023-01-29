namespace BeyazEsya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeyazEsyas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Renk = c.String(),
                        Boyutlar_En = c.Int(nullable: false),
                        Boyutlar_Boy = c.Int(nullable: false),
                        Boyutlar_Derinlik = c.Int(nullable: false),
                        KategorıId = c.Int(nullable: false),
                        Kg = c.Int(),
                        ProgramSayisi = c.Int(),
                        SogutucuTıp = c.Int(),
                        Hacım = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategorı", t => t.KategorıId, cascadeDelete: true)
                .Index(t => t.KategorıId);
            
            CreateTable(
                "dbo.Kategorı",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategorıAdi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BeyazEsyas", "KategorıId", "dbo.Kategorı");
            DropIndex("dbo.BeyazEsyas", new[] { "KategorıId" });
            DropTable("dbo.Kategorı");
            DropTable("dbo.BeyazEsyas");
        }
    }
}
