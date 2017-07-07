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
    public class SRDataConfiguration : WEntityConfiguration<SRDataEntity>
    {
        public SRDataConfiguration()
            : base("w_srdata")
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
               .HasColumnName("s_id");

            this.Property(assigment => assigment.DeviceId)
                .HasColumnName("s_deviceId");

            this.Property(assigment => assigment.Frequency)
                .HasColumnName("s_freguency");

            this.Property(assigment => assigment.SendData)
                .HasColumnName("s_send_data");

            this.Property(assigment => assigment.Status)
                .HasColumnName("s_status");

            this.Property(assigment => assigment.ErrorText)
                .HasColumnName("s_error_text");

            #endregion
        }
    }
}
