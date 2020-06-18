using meishi_lifumodel.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.Frontdesk.ashx
{
    /// <summary>
    /// readmenu 的摘要说明
    /// </summary>
    public class readmenu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetSingleMainMenu")//得到新秀菜谱信息
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                string usernumber = Convert.ToString(context.Request.QueryString["usernumber"]);
                string tableflag = "Main";
                myoperateClass ex = new myoperateClass();
                String strret = ex.createPageImage(menunumber, usernumber, tableflag);
                context.Response.Write(strret);
                return;
            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetSingleUserMenu")//得到用户菜谱信息
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                string usernumber = Convert.ToString(context.Request.QueryString["usernumber"]);
                string tableflag = "User";
                myoperateClass ex = new myoperateClass();
                String strret = ex.createPageImage(menunumber, usernumber, tableflag);
                context.Response.Write(strret);
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}