using ApniMaa.Attributes;
using ApniMaa.BLL.Common;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using ApniMaa.Framework.Api.Helpers;
using ApniMaa.DAL;
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
    public class HomeController : BaseAPIController
    {
        IHomeManager _homeManager;
        //IPushNotificationManager _pushNotificationManager;
        
        //IAdminManager _adminManager;
        public HomeController(IHomeManager homeManager)
        {
            _homeManager = homeManager;
            //  _pushNotificationManager = pushNotificationManager;
        }

        [SkipAuthorization]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetCategoryList()
        {

            var result = _homeManager.GetCategoryList();
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, result.Object ).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [SkipAuthorization]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAmazingDishes(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyType)
        {

            var result = _homeManager.GetAmazingDishesList(Longitute,Latitute,ReqDate,CategoryId,AvailabiltyType);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, result.Object ).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }
        [SkipAuthorization]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetMothersList(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyType)
        {

            var result = _homeManager.GetMothersList(Longitute, Latitute, ReqDate, CategoryId, AvailabiltyType);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, result.Object ).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [SkipAuthorization]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetSignatureDishes(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyType)
        {

            var result = _homeManager.GetSignatureDishes(Longitute, Latitute, ReqDate, CategoryId, AvailabiltyType);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, result.Object ).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }
    }
}