using meishi_lifumodel;
using meishi_lifumodel.DBHelper;
using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace meishi_lifumodel.Frontdesk.login
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler,IRequiresSessionState
    {
        
        public void ProcessRequest(HttpContext context)
        {
          // context.Session.RemoveAll();
             context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            #region  用户登录
             if (context.Request.QueryString["type"] == "login")
             {
                 string username = context.Request.QueryString["username"];
                 string password = context.Request.QueryString["password"];

                 BLL.BLLuser bll = new BLL.BLLuser();
                 int count = bll.GetUserCount(username, password);
                 if (count == 0) //"用户名或密码错误";
                 {
                     context.Response.Write("error");
                 }
                 else
                 {
                     IList<User> user = bll.Userlogin(username, password);
                     foreach (User userinfo in user) {
                         String a = userinfo.UserName.ToString();
                         String b = userinfo.PassWord.ToString();
                         context.Session["username1"] = a;
                         context.Session["useraccount"] = userinfo.Account.ToString();
                         HttpContext.Current.Session["username"] = a; 
                     }
                     context.Response.Redirect("../index/index.html?username="+username);
                    // context.Response.Redirect("../html/index.html?username=" + username + "&time=" + DateTime.Now.ToUniversalTime());

                 }
                 #endregion  

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