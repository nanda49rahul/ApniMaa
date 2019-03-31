using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using ApniMaa.BLL.Managers.Scheduler;
using ApniMaa.DAL;
using ApniMaa.BLL.Interfaces;
using ApniMaa.Services.Scheduler;

namespace ApniMaa.Services.SchedulerJobs
{
    public class NotificationJob : IJob
    {
        public List<int> Cases { get; set; }
        public int FirmID { get; set; }
        public int CaseID { get; set; }
        public void Execute(IJobExecutionContext context)
        {
            NotificationSchedularTasks obj = new NotificationSchedularTasks();
            if (Cases != null && Cases.Count() > 0)
            {
              //  obj.NotifyUserCases(Cases);
            }
            if (FirmID > 0)
            {
                //obj.NotifyUnderwriters(FirmID);
            }
            if (CaseID > 0)
            {
                //obj.NotifyManagers(CaseID);
            }
        }
    }
}