namespace PetBnB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactUsSubmission : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactSubmissionModels", newName: "ContactUsSubmissionModels");
            DropForeignKey("dbo.BookingModels", "Employee_EmployeeID", "dbo.EmployeeModels");
            DropIndex("dbo.BookingModels", new[] { "Employee_EmployeeID" });
            AddColumn("dbo.BookingModels", "CreatedDateTime", c => c.DateTime());
            AlterColumn("dbo.BookingModels", "Employee_EmployeeID", c => c.Guid());
            CreateIndex("dbo.BookingModels", "Employee_EmployeeID");
            AddForeignKey("dbo.BookingModels", "Employee_EmployeeID", "dbo.EmployeeModels", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "Employee_EmployeeID", "dbo.EmployeeModels");
            DropIndex("dbo.BookingModels", new[] { "Employee_EmployeeID" });
            AlterColumn("dbo.BookingModels", "Employee_EmployeeID", c => c.Guid(nullable: false));
            DropColumn("dbo.BookingModels", "CreatedDateTime");
            CreateIndex("dbo.BookingModels", "Employee_EmployeeID");
            AddForeignKey("dbo.BookingModels", "Employee_EmployeeID", "dbo.EmployeeModels", "EmployeeID", cascadeDelete: true);
            RenameTable(name: "dbo.ContactUsSubmissionModels", newName: "ContactSubmissionModels");
        }
    }
}
