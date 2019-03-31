using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Managers
{
    public abstract class BaseManager : DbContext
    {
        public BaseManager()
            : base()
        {

        }
        /// <summary>
        /// protected, it only visible for inherited class
        /// </summary>
        protected void SaveChanges()
        {
            Context.SaveChanges();
        }


        public ActionOutput ErrorResponse(string message)
        {
            return new ActionOutput
            {
                Status = ActionStatus.Error,
                Message = message
            };
        }

        public ActionOutput<T> ErrorResponse<T>(string message)
        {
            return new ActionOutput<T>
            {
                Status = ActionStatus.Error,
                Message = message
            };
        }

        public ActionOutput SuccessResponse(string message)
        {
            return new ActionOutput
            {
                Status = ActionStatus.Successfull,
                Message = message
            };
        }

        public ActionOutput<T> SuccessResponse<T>(string message, T model)
        {
            return new ActionOutput<T>
            {
                Status = ActionStatus.Successfull,
                Message = message,
                Object = model
            };
        }

        public PagingResult<T> PagingResultResponse<T>(List<T> list, string message, int count)
        {
            var result = new PagingResult<T>();

            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = message;
            result.TotalCount = count;

            return result;
        }

        public ApiPagingResult<T> PagingResultResponse<T>(List<T> list, int count, object model = null)
        {
            var result = new ApiPagingResult<T>();

            result.List = list;
            result.TotalCount = count;
            result.Object = model;
            return result;
        }
    }


}
