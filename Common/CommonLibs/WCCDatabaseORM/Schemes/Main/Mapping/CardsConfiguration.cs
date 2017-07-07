using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.AbstractionLayer;
using WCCDatabaseORM.Schemes.Main.Entities;

namespace WCCDatabaseORM.Schemes.Main.Mapping
{
    public class CardsConfiguration : WEntityConfiguration<CardsEntity>
    {
        public CardsConfiguration()
            : base("w_cards")
        {

        }

        public override void BuildConfiguration()
        {
            #region Primary key
            this.HasKey(assigment => assigment.Id);
            #endregion

            #region Relations

            #endregion

            #region Properties
            this.Property(assigment => assigment.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
               .HasColumnName("c_id");

            this.Property(assigment => assigment.CardId)
                .HasColumnName("c_cardId");

            this.Property(assigment => assigment.IsDeleted)
                .HasColumnName("c_deleted");

            this.Property(assigment => assigment.Password)
                .HasColumnName("c_password");

            this.Property(assigment => assigment.YmdEnd)
                .HasColumnName("c_end");

            this.Property(assigment => assigment.YmdStart)
                .HasColumnName("c_start");

            #endregion
        }
    }
}
