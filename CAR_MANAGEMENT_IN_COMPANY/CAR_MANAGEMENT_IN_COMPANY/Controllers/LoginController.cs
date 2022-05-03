using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CAR_MANAGEMENT_IN_COMPANY.Controllers
{
    public class LoginController : CommonController
        //: ApiController

    {
        [System.Web.Mvc.HttpPost]
        public JsonResult GetList()
        {
            // 가짜 리스트 조회
            List<string> list = new List<string>();
            string[] tempData = new string[2]{ "Apple", "FineApple" };
            foreach (var temp in tempData)
            {
                list.Add(temp);
            }
            return JsonPost200(list);
        }

        public JsonResult GetDbList()
        {
            // DB 접속
            IsConnSql();
            // 쿼리
            

            var list = new List<string>();

            return JsonGet200(list);
        }
    }
}