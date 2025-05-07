namespace PetBnB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetOwnerIDNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactUsSubmissionModels", "PetOwnerID", "dbo.PetOwnerModels");
            DropIndex("dbo.ContactUsSubmissionModels", new[] { "PetOwnerID" });
            AlterColumn("dbo.ContactUsSubmissionModels", "PetOwnerID", c => c.Guid());
            CreateIndex("dbo.ContactUsSubmissionModels", "PetOwnerID");
            AddForeignKey("dbo.ContactUsSubmissionModels", "PetOwnerID", "dbo.PetOwnerModels", "PetOwnerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactUsSubmissionModels", "PetOwnerID", "dbo.PetOwnerModels");
            DropIndex("dbo.ContactUsSubmissionModels", new[] { "PetOwnerID" });
            AlterColumn("dbo.ContactUsSubmissionModels", "PetOwnerID", c => c.Guid(nullable: false));
            CreateIndex("dbo.ContactUsSubmissionModels", "PetOwnerID");
            AddForeignKey("dbo.ContactUsSubmissionModels", "PetOwnerID", "dbo.PetOwnerModels", "PetOwnerID", cascadeDelete: true);
        }
    }
}
