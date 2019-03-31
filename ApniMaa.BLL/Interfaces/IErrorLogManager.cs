using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Interfaces
{

    public interface IErrorLogManager
    {
        /// <summary>
        /// Log Exception to database
        /// </summary>
        /// <param name="exc"></param>
        /// <returns></returns>
        string LogExceptionToDatabase(Exception exc);
    }
}
