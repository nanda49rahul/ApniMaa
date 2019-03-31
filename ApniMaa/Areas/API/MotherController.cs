using ApniMaa.Attributes;
using ApniMaa.BLL.Common;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using ApniMaa.Framework.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Web.Mvc;

namespace ApniMaa.Areas.API
{
    public class MotherController : BaseAPIController
    {
        IMotherManager _motherManager;
        //IPushNotificationManager _pushNotificationManager;
        
        //IAdminManager _adminManager;
        public MotherController(IMotherManager motherManager)
        {
            _motherManager = motherManager;
            //  _pushNotificationManager = pushNotificationManager;
          
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetMotherQuestions()
        {
           
            var result = _motherManager.GetMotherQuestions();
            if (result.Status == ActionStatus.Successfull)
            {
                
                return new JsonContent(result.Message, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        //[System.Web.Http.HttpPost]
        //public HttpResponseMessage SaveMotherAnswers(List<MotherAnswer> model)
        //{

        //    var result = _motherManager.SaveMotherAnswers(model);
        //    if (result.Status == ActionStatus.Successfull)
        //    {

        //        return new JsonContent(result.Message, Status.Success).ConvertToHttpResponseOK();
        //    }
        //    else
        //    {
        //        return new JsonContent(result.Message, Status.Failed).ConvertToHttpResponseOK();
        //    }
        //}

        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateMotherProfile(MotherModel model)
        {

            var result = _motherManager.UpdateMotherProfile(model);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetMotherDailySchedule(int Id)
        {

            var result = _motherManager.GetMotherDailySchedule(Id);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateMotherDailySchedule(MotherScheduleModel model)
        {

            var result = _motherManager.UpdateMotherDailySchedule(model);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetMotherDishDailySchedule(int Id)
        {

            var result = _motherManager.GetMotherDishDailySchedule(Id);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateMotherDishDailySchedule(List<MotherDishScheduleModel> model)
        {

            var result = _motherManager.UpdateMotherDishDailySchedule(model);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }
    }
}