using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using CAR_MANAGEMENT_IN_COMPANY.Models.Config;
using log4net;

namespace CAR_MANAGEMENT_IN_COMPANY.Controllers
{
    public class CommonController : Controller
    //: ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CommonController));
        static readonly DbConfig _conf = new DbConfig();

        readonly string _DbName = _conf.DataBaseName;
        readonly string _host = _conf.IP;
        readonly string _port = _conf.Port;
        readonly string _username = _conf.ID;
        readonly string _password = _conf.PWD;

        #region DbConnection
        public SqlConnection IsConnSql()
        {
            _log.Info($"{_host}:{_port}\tDB접속시도");

            // DB연결
            string connectionString = $"Data Source={_host},{_port};Database={_DbName};User Id={_username};Password={_password}";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                }
                else
                {
                };
                _log.Debug(conn.ToString());
                return conn;
            }
            catch (Exception e)
            {
                _log?.Error(e.ToString());

                throw new Exception($"DBConn ERR: " + e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public JsonResult DbLogin(string loginId, string loginPwd)
        {
            string id = String.Empty;
            string name = String.Empty;

            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "SELECT * FROM USER_TB WHERE IS_USE = 1 AND FAIL_CNT < 10 AND ID = @ID AND PWD = @PWD";
            adapter.SelectCommand = new SqlCommand(sql, IsConnSql());
            adapter.SelectCommand.Parameters.AddWithValue("@ID", loginId ?? "ADMIN");
            adapter.SelectCommand.Parameters.AddWithValue("@PWD", loginPwd ?? "1234");

            try
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRowCollection row = dt.Rows;

                if (row != null && row.Count > 0)
                {
                    id = row[0]["ID"].ToString();
                    name = row[0]["NAME"].ToString();
                }

                if (id != String.Empty && name != String.Empty)
                {
                    Session["UserId"] = id;
                    Session["UserName"] = name;
                }

                return JsonPost200(new { id, name });
            }
            catch (Exception e)
            {
                return Json404("DbLogin ERR: " + e.ToString());
            }

        }
        #endregion

        #region Return JsonResult
        public JsonResult JsonGet200<T>(T data)
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
        public JsonResult JsonGet200<T>(string msg, T data)
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
        public JsonResult JsonPost200<T>(T data)
        {
            JsonResult jsonRes = Json(new
            {
                result = "OK",
                message = "성공",
                data = data
            });
            jsonRes.MaxJsonLength = int.MaxValue;

            return jsonRes;
        }
        public JsonResult JsonPost200<T>(string msg, T data)
        {
            var jsonRes = Json(new
            {
                result = "OK",
                message = msg,
                data = data
            });
            jsonRes.MaxJsonLength = int.MaxValue;

            return jsonRes;
        }
        public JsonResult Json404(string msg)
        {
            return Json(new
            {
                result = "ERR",
                message = msg,
                data = ""
            });
        }
        #endregion
    }
}