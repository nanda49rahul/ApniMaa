﻿using ApniMaa.BLL.Interfaces;
using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Managers
{
    public class ErrorLogManager : BaseManager, IErrorLogManager
    {
        string IErrorLogManager.LogExceptionToDatabase(Exception exc)
        {
            ErrorLog errorObj = new ErrorLog();
            errorObj.Message = exc.Message;
            errorObj.StackTrace = exc.StackTrace;
            errorObj.InnerException = exc.InnerException == null ? "" : exc.InnerException.Message;
            errorObj.LoggedInDetails = "";
            errorObj.LoggedAt = DateTime.UtcNow;
            Context.ErrorLogs.Add(errorObj);
            // To do
            // Context.SaveChanges();
            return errorObj.ErrorLogID.ToString();
        }
    }
}
