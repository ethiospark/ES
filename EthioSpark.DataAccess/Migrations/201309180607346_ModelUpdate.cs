namespace EthioSpark.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CodeSet",
                c => new
                    {
                        CodeSetId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CodeSetId);
            
            CreateTable(
                "CodeValue",
                c => new
                    {
                        CodeValueId = c.Int(nullable: false, identity: true),
                        CodeSetId = c.Int(nullable: false),
                        DisplayName = c.String(unicode: false),
                        Meaning = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CodeValueId)
                .ForeignKey("CodeSet", t => t.CodeSetId, cascadeDelete: true)
                .Index(t => t.CodeSetId);
            
            CreateTable(
                "Picture",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Filename = c.String(unicode: false),
                        Description = c.Single(),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        MembershipUserId = c.Guid(nullable: false),
                        Gender = c.Byte(nullable: false),
                        SeekingGender = c.Byte(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("Address", t => t.Address_AddressId)
                .Index(t => t.Address_AddressId);
            
            CreateTable(
                "Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(unicode: false),
                        CityCd = c.Int(nullable: false),
                        CountryCd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("CodeValue", t => t.CityCd, cascadeDelete: true)
                .ForeignKey("CodeValue", t => t.CountryCd, cascadeDelete: true)
                .Index(t => t.CityCd)
                .Index(t => t.CountryCd);
            
            CreateTable(
                "PrflAttrValue",
                c => new
                    {
                        PrflAttrValueId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(unicode: false),
                        InternalMeaning = c.String(unicode: false),
                        PrflAttrId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrflAttrValueId)
                .ForeignKey("PrflAttr", t => t.PrflAttrId, cascadeDelete: true)
                .Index(t => t.PrflAttrId);
            
            CreateTable(
                "PrflAttrGrp",
                c => new
                    {
                        PrflAttrGrpId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayText = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PrflAttrGrpId);
            
            CreateTable(
                "PrflCtx",
                c => new
                    {
                        PrflCtxId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PrflCtxId);
            
            CreateTable(
                "PrflAttr",
                c => new
                    {
                        PrflAttrId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayText = c.String(unicode: false),
                        MultiLine = c.Boolean(),
                        MaxLength = c.Int(),
                        MultiValue = c.Boolean(),
                        AttrType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrflAttrId);
            
            CreateTable(
                "PrflAttrGrpPrflAttr",
                c => new
                    {
                        PrflAttrGrp_PrflAttrGrpId = c.Int(nullable: false),
                        PrflAttr_PrflAttrId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrflAttrGrp_PrflAttrGrpId, t.PrflAttr_PrflAttrId })
                .ForeignKey("PrflAttrGrp", t => t.PrflAttrGrp_PrflAttrGrpId, cascadeDelete: true)
                .ForeignKey("PrflAttr", t => t.PrflAttr_PrflAttrId, cascadeDelete: true)
                .Index(t => t.PrflAttrGrp_PrflAttrGrpId)
                .Index(t => t.PrflAttr_PrflAttrId);
            
            CreateTable(
                "PrflCtxPrflAttrGrp",
                c => new
                    {
                        PrflCtx_PrflCtxId = c.Int(nullable: false),
                        PrflAttrGrp_PrflAttrGrpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrflCtx_PrflCtxId, t.PrflAttrGrp_PrflAttrGrpId })
                .ForeignKey("PrflCtx", t => t.PrflCtx_PrflCtxId, cascadeDelete: true)
                .ForeignKey("PrflAttrGrp", t => t.PrflAttrGrp_PrflAttrGrpId, cascadeDelete: true)
                .Index(t => t.PrflCtx_PrflCtxId)
                .Index(t => t.PrflAttrGrp_PrflAttrGrpId);
            
            CreateTable(
                "PrflCtxPrflAttr",
                c => new
                    {
                        PrflCtx_PrflCtxId = c.Int(nullable: false),
                        PrflAttr_PrflAttrId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrflCtx_PrflCtxId, t.PrflAttr_PrflAttrId })
                .ForeignKey("PrflCtx", t => t.PrflCtx_PrflCtxId, cascadeDelete: true)
                .ForeignKey("PrflAttr", t => t.PrflAttr_PrflAttrId, cascadeDelete: true)
                .Index(t => t.PrflCtx_PrflCtxId)
                .Index(t => t.PrflAttr_PrflAttrId);
            
            CreateTable(
                "PrflAttrValueUser",
                c => new
                    {
                        PrflAttrValue_PrflAttrValueId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrflAttrValue_PrflAttrValueId, t.User_UserId })
                .ForeignKey("PrflAttrValue", t => t.PrflAttrValue_PrflAttrValueId, cascadeDelete: true)
                .ForeignKey("User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.PrflAttrValue_PrflAttrValueId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("PrflAttrValueUser", new[] { "User_UserId" });
            DropIndex("PrflAttrValueUser", new[] { "PrflAttrValue_PrflAttrValueId" });
            DropIndex("PrflCtxPrflAttr", new[] { "PrflAttr_PrflAttrId" });
            DropIndex("PrflCtxPrflAttr", new[] { "PrflCtx_PrflCtxId" });
            DropIndex("PrflCtxPrflAttrGrp", new[] { "PrflAttrGrp_PrflAttrGrpId" });
            DropIndex("PrflCtxPrflAttrGrp", new[] { "PrflCtx_PrflCtxId" });
            DropIndex("PrflAttrGrpPrflAttr", new[] { "PrflAttr_PrflAttrId" });
            DropIndex("PrflAttrGrpPrflAttr", new[] { "PrflAttrGrp_PrflAttrGrpId" });
            DropIndex("PrflAttrValue", new[] { "PrflAttrId" });
            DropIndex("Address", new[] { "CountryCd" });
            DropIndex("Address", new[] { "CityCd" });
            DropIndex("User", new[] { "Address_AddressId" });
            DropIndex("Picture", new[] { "UserId" });
            DropIndex("CodeValue", new[] { "CodeSetId" });
            DropForeignKey("PrflAttrValueUser", "User_UserId", "User");
            DropForeignKey("PrflAttrValueUser", "PrflAttrValue_PrflAttrValueId", "PrflAttrValue");
            DropForeignKey("PrflCtxPrflAttr", "PrflAttr_PrflAttrId", "PrflAttr");
            DropForeignKey("PrflCtxPrflAttr", "PrflCtx_PrflCtxId", "PrflCtx");
            DropForeignKey("PrflCtxPrflAttrGrp", "PrflAttrGrp_PrflAttrGrpId", "PrflAttrGrp");
            DropForeignKey("PrflCtxPrflAttrGrp", "PrflCtx_PrflCtxId", "PrflCtx");
            DropForeignKey("PrflAttrGrpPrflAttr", "PrflAttr_PrflAttrId", "PrflAttr");
            DropForeignKey("PrflAttrGrpPrflAttr", "PrflAttrGrp_PrflAttrGrpId", "PrflAttrGrp");
            DropForeignKey("PrflAttrValue", "PrflAttrId", "PrflAttr");
            DropForeignKey("Address", "CountryCd", "CodeValue");
            DropForeignKey("Address", "CityCd", "CodeValue");
            DropForeignKey("User", "Address_AddressId", "Address");
            DropForeignKey("Picture", "UserId", "User");
            DropForeignKey("CodeValue", "CodeSetId", "CodeSet");
            DropTable("PrflAttrValueUser");
            DropTable("PrflCtxPrflAttr");
            DropTable("PrflCtxPrflAttrGrp");
            DropTable("PrflAttrGrpPrflAttr");
            DropTable("PrflAttr");
            DropTable("PrflCtx");
            DropTable("PrflAttrGrp");
            DropTable("PrflAttrValue");
            DropTable("Address");
            DropTable("User");
            DropTable("Picture");
            DropTable("CodeValue");
            DropTable("CodeSet");
        }
    }
}
