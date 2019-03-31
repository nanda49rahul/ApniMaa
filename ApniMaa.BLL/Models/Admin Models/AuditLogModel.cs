using ApniMaa.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniMaa.DAL;

namespace ApniMaa.BLL.Models
{
    //public class AuditLogDetails
    //{
    //    public string PropertyName { get; set; }
    //    public string OldValue { get; set; }
    //    public string NewValue { get; set; }
    //}
    //public class AuditLogModel
    //{
    //    public string MasterEntityName { get; set; }
    //    public string EntityName { get; set; }
    //    public int State { get; set; }
    //    public string ModifiedBy { get; set; }
    //    public DateTime ModifiedDate { get; set; }
    //    public string ProfileImage { get; set; }
    //    public string FirmName { get; set; }
    //    public List<AuditLogDetails> AuditLogs { get; set; }
    //    public AuditLogModel() { }
    //    public AuditLogModel(Audit obj,int? firmId)
    //    {
    //        if (obj.Entity.Contains('_'))
    //        {
    //            var entity = obj.Entity.Substring(0, obj.Entity.IndexOf("_"));
    //            this.MasterEntityName = entity;
    //        }
    //        else
    //        {
    //            this.MasterEntityName = obj.Entity;
    //        }
    //        if (obj.FirmID != null && obj.FirmID > 0)
    //        {
    //            this.FirmName = obj.Fleet.FleetName;
    //        }
    //        this.EntityName = obj.EntityName;
    //        this.ProfileImage = "";
    //        this.State =obj.Operation;
    //        this.ModifiedBy = obj.UserName;
    //        this.ModifiedDate = obj.Timestamp;
    //        var auditLog = obj.AuditLogs.AsEnumerable();
    //        if (auditLog != null && auditLog.Any())
    //        {
    //            var logs = new List<AuditLogDetails>();
    //            foreach (var item in auditLog)
    //            {
    //                if (firmId > 0)
    //                {
    //                    if (!item.PropertyName.ToLower().Contains("internalnotes"))
    //                    {
    //                        logs.Add(new AuditLogDetails
    //                        {
    //                            PropertyName = item.PropertyName,
    //                            OldValue = item.OldValue,
    //                            NewValue = item.NewValue
    //                        });
    //                    }
                       
    //                }
    //                else
    //                {
    //                    logs.Add(new AuditLogDetails
    //                    {
    //                        PropertyName = item.PropertyName,
    //                        OldValue = item.OldValue,
    //                        NewValue = item.NewValue
    //                    });
    //                }
    //            }
    //            this.AuditLogs = logs;
    //        }
    //    }
    //}
}
