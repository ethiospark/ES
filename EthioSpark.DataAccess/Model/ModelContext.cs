using System.Data.Entity;
using EthioSpark.Entities;

namespace EthioSpark.DataAccess.Model
{
    public class ModelContext:Ethiosparkmodelcontainer
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            SetupForeignKeyAssociations(modelBuilder);
        }



        private void SetupForeignKeyAssociations(DbModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                        .HasRequired(u => u.HeightCodeValue)
                        .WithMany(c => c.HeightUsers)
                        .HasForeignKey(u => u.HeightCd)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.EthnicityCodeValue)
                        .WithMany(c => c.EthnicityUsers)
                        .HasForeignKey(u => u.EthnicityCd)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.ReligionCodeValue)
                        .WithMany(c => c.ReligionUsers)
                        .HasForeignKey(u => u.ReligionCd)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.DrinkingHabitCodeValue)
                        .WithMany(c => c.DrinkingHabitUsers)
                        .HasForeignKey(u => u.DrinkingHabitCd)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.SmokingHabitCodeValue)
                        .WithMany(c => c.SmokingHabitUsers)
                        .HasForeignKey(u => u.SmokingHabitCd)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.BodyTypeCodeValue)
                        .WithMany(c => c.BodyTypeUsers)
                        .HasForeignKey(u => u.BodyTypeCd)
                        .WillCascadeOnDelete(false);

            //Address
            modelBuilder.Entity<Address>()
                        .HasRequired(a => a.CityCodeValue)
                        .WithMany(c => c.CityAddresses)
                        .HasForeignKey(a => a.CityCd)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                        .HasRequired(a => a.CountryCodeValue)
                        .WithMany(c => c.CountryAddresses)
                        .HasForeignKey(a => a.CountryCd)
                        .WillCascadeOnDelete(false);

        }






    }
}
