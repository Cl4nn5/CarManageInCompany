using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CAR_MANAGEMENT_IN_COMPANY.Controllers
{
    public class CommonController : Controller
    //: ApiController
    {
        public JsonResult Json200<T>(T data)
        {
            JsonResult jsonRes = Json(new
            {
                result = "OK",
                message = "성공",
                data = data
            }, JsonRequestBehavior.AllowGet);
            jsonRes.MaxJsonLength = int.MaxValue;

            return jsonRes;
        }
        public JsonResult Json200<T>(string msg, T data)
        {
            var jsonRes = Json(new
            {
                result = "OK",
                message = msg,
                data = data
            }, JsonRequestBehavior.AllowGet);
            jsonRes.MaxJsonLength = int.MaxValue;

            return jsonRes;
        }
        public JsonResult Json404<T>(string msg)
        {
            return Json(new
            {
                result = "ERR",
                message = msg
            });
        }
    }
}