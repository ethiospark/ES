using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EthioSpark.Entities;
using EthioSpark.Entities.Profile;
using MySql.Data.Entity;

namespace EthioSpark.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EthioSparkContext>
    {
        public Configuration()
        {
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(EthioSparkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Test Codesets for Address city/country codes

            var countryCodeSet = new CodeSet
                                 {
                                     CodeSetId = 1,
                                     Description = "Country",
                                     DisplayName = "Country"
                                 };

            var cityCodeSet = new CodeSet
                              {
                                  CodeSetId = 2,
                                  Description = "City",
                                  DisplayName = "City"
                              };

            context.CodeSets.AddOrUpdate(c => c.CodeSetId, cityCodeSet, countryCodeSet);
            var kansasCodeValue = new CodeValue
                                  {
                                      CodeValueId = 1,
                                      CodeSetId = 1,
                                      DisplayName = "Kansas"
                                  };

            var overlandParkCodeValue = new CodeValue
                                        {
                                            CodeValueId = 2,
                                            CodeSetId = 2,
                                            DisplayName = "Overland Park"
                                        };


            context.CodeValues.AddOrUpdate(c => c.CodeValueId, kansasCodeValue, overlandParkCodeValue);

            #endregion

            ConfigureProfileCtxAndAttributeGroups(context);
            ConfigureProfileAttributes(context);
        }

        private void ConfigureProfileCtxAndAttributeGroups(EthioSparkContext context)
        {
            //Define profile groups
            var summary = new PrflAttrGrp
                          {
                              PrflAttrGrpId = 1,
                              Name = "Summary",
                              DisplayText = "Summary"
                          };
            var detail = new PrflAttrGrp
                         {
                             PrflAttrGrpId = 2,
                             Name = "Detail",
                             DisplayText = "Detail"
                         };
            context.PrflAttrGrps.AddOrUpdate(g => g.PrflAttrGrpId, detail, summary);

            //Define profile context(s)
            var editOwnProfileCtx = new PrflCtx
                                    {
                                        PrflCtxId = 1,
                                        Name = "Edit Own Profile"
                                    };
            var viewOwnProfileCtx = new PrflCtx
                                    {
                                        PrflCtxId = 2,
                                        Name = "View Own Profile"
                                    };
            context.PrflCtxs.AddOrUpdate(c => c.PrflCtxId, viewOwnProfileCtx, editOwnProfileCtx);

            context.SaveChanges();
            //Associate groups with contexts
            AssociateProfileGroupAndContext(context, new[,] {{1, 1}, {1, 2}, {2, 1}, {2, 2}});

            context.SaveChanges();
        }

        private void ConfigureProfileAttributes(EthioSparkContext context)
        {
            //Define profile attributes
            var intent = new PrflListAttr
                         {
                             PrflAttrId = 1,
                             Name = "Intent",
                             DisplayText = "Intent",
                             MultiValue = false,
                         };

            var height = new PrflListAttr
                         {
                             PrflAttrId = 2,
                             Name = "Height",
                             DisplayText = "Height",
                             MultiValue = false,
                         };

            var bodyType = new PrflListAttr
                           {
                               PrflAttrId = 3,
                               Name = "Body Type",
                               DisplayText = "Body Type",
                               MultiValue = false,
                           };

            var haveKids = new PrflListAttr
                           {
                               PrflAttrId = 4,
                               Name = "Have Kids",
                               DisplayText = "Have Kids",
                               MultiValue = false,
                           };

            var aboutMe = new PrflTxtAttr()
                          {
                              PrflAttrId = 5,
                              Name = "AboutMe",
                              DisplayText = "About Me",
                              MaxLength = 1000,
                              MultiLine = true
                          };

            var education = new PrflListAttr
                            {
                                PrflAttrId = 6,
                                Name = "Education",
                                DisplayText = "Education",
                                MultiValue = false,
                            };

            var occupation = new PrflListAttr
                             {
                                 PrflAttrId = 7,
                                 Name = "Occupation",
                                 DisplayText = "Occupation",
                                 MultiValue = false,
                             };

            var ethnicity = new PrflListAttr
                            {
                                PrflAttrId = 8,
                                Name = "Ethnicity",
                                DisplayText = "Ethnicity",
                                MultiValue = false,
                            };

            var religion = new PrflListAttr
                           {
                               PrflAttrId = 9,
                               Name = "Religion",
                               DisplayText = "Religion",
                               MultiValue = false,
                           };


            var smokes = new PrflListAttr
                         {
                             PrflAttrId = 10,
                             Name = "Smokes",
                             DisplayText = "Smokes",
                             MultiValue = false,
                         };

            var drinks = new PrflListAttr
                         {
                             PrflAttrId = 11,
                             Name = "Drinks",
                             DisplayText = "Drinks",
                             MultiValue = false,
                         };

            context.PrflAttrs.AddOrUpdate(a => a.PrflAttrId, intent, height, bodyType, haveKids, aboutMe, education, occupation, ethnicity, religion, smokes, drinks);
            context.SaveChanges();
            AssociateProfileAttibutesAndGroup(context, new[,]
                                                       {
                                                           //summary
                                                           {1, 1}, {1, 2}, {1, 3}, {1, 4}, {1, 5}, 
                                                           //detail
                                                           {2, 6}, {2, 7}, {2, 8}, {2, 9}, {2, 10}, {2, 11}
                                                       });
            context.SaveChanges();
            AssociateProfileAttributeAndContext(context, new[,]
                                                       {
                                                           //edit own profile context
                                                           {1, 1}, {1, 2}, {1, 3}, {1, 4}, {1, 5}, {1, 6}, {1, 7}, {1, 8}, {1, 9}, {1, 10}, {1, 11},
                                                           //view own profile context
                                                           {2, 1}, {2, 2}, {2, 3}, {2, 4}, {2, 5}, {2, 6}, {2, 7}, {2, 8}, {2, 9}, {2, 10}, {2, 11}
                                                       });
            context.SaveChanges();
        }

        private void AssociateProfileGroupAndContext(EthioSparkContext context, int[,] ctxGrpPair)
        {
            for (int idx0 = 0; idx0 < ctxGrpPair.GetLength(0); idx0++)
            {
                AssociateProfileGroupAndContext(context, ctxGrpPair[idx0, 0], ctxGrpPair[idx0, 1]);
            }
        }

        private void AssociateProfileGroupAndContext(EthioSparkContext context, int ctxId, int groupId)
        {
            PrflCtx ctx = context.PrflCtxs.Where(c => c.PrflCtxId == ctxId).Include("PrflAttrGrps").First();
            bool any = ctx.PrflAttrGrps.Any(c => c.PrflAttrGrpId == groupId);
            if (!any)
            {
                ctx.PrflAttrGrps.Add(context.PrflAttrGrps.Find(groupId));
            }
        }

        private void AssociateProfileAttibutesAndGroup(EthioSparkContext context, int[,] grpAttrPair)
        {
            for (int idx0 = 0; idx0 < grpAttrPair.GetLength(0); idx0++)
            {
                AssociateProfileAttibutesAndGroup(context, grpAttrPair[idx0, 0], grpAttrPair[idx0, 1]);
            }
        }

        private void AssociateProfileAttibutesAndGroup(EthioSparkContext context, int grpId, int attrId)
        {
            PrflAttrGrp grp = context.PrflAttrGrps.Where(c => c.PrflAttrGrpId == grpId).Include("PrflAttrs").First();
            bool any = grp.PrflAttrs.Any(c => c.PrflAttrId == attrId);
            if (!any)
            {
                grp.PrflAttrs.Add(context.PrflAttrs.Find(attrId));
            }
        }

        private void AssociateProfileAttributeAndContext(EthioSparkContext context, int[,] ctxAttrPair)
        {
            for (int idx0 = 0; idx0 < ctxAttrPair.GetLength(0); idx0++)
            {
                AssociateProfileAttributeAndContext(context, ctxAttrPair[idx0, 0], ctxAttrPair[idx0, 1]);
            }
        }

        private void AssociateProfileAttributeAndContext(EthioSparkContext context, int ctxId, int attrId)
        {
            PrflCtx ctx = context.PrflCtxs.Where(c => c.PrflCtxId == ctxId).Include("PrflAttrs").First();
            bool any = ctx.PrflAttrs.Any(c => c.PrflAttrId == attrId);
            if (!any)
            {
                ctx.PrflAttrs.Add(context.PrflAttrs.Find(attrId));
            }
        }
    }
}