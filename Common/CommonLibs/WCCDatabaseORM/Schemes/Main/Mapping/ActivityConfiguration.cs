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
    public class ActivityConfiguration : WEntityConfiguration<ActivityEntity>
    {
        public ActivityConfiguration()
            : base("w_activity")
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
               .HasColumnName("w_id");

            this.Property(assigment => assigment.UserName)
                .HasColumnName("w_username");

            this.Property(assigment => assigment.Time)
                .HasColumnName("w_time");

            this.Property(assigment => assigment.ActivityText)
                .HasColumnName("w_activitytext");

            this.Property(assigment => assigment.IsVip)
                .HasColumnName("w_isvip");

            #endregion
        }
    }
}
