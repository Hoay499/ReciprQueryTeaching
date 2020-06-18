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
             if (context.Request.QueryString["type"] == "login")//登录
             {
               
                 string username = context.Request.QueryString["username"];
                 string password = context.Request.QueryString["password"];
                
                 #region  login ....


                 BLL.BLLuser bll = new BLL.BLLuser();
                   
                 int count = bll.GetUserCount(username, password);
                 if (count == 0)
                 {
                     //"用户名或密码错误";
                     context.Response.Write("error");

                    //  context.Response.Redirect("login.html?username=" + username);
                }
                 else
                 {
                     IList<User> user = bll.Userlogin(username, password);
                    
                     foreach (User userinfo in user) {
                         //context.Session["username"] = userinfo.UserName.ToString();
                       //  context.Session["password"] = userinfo.PassWord.ToString();
                         String a = userinfo.UserName.ToString();
                         String b = userinfo.PassWord.ToString();

                         HttpContext.Current.Session["username"] = a;
                         //HttpContext.Current.Session["username"] = a;
                         
                     }

                     context.Response.Redirect("../index/index.html?username="+username);
                    // context.Response.Redirect("../html/index.html?username=" + username + "&time=" + DateTime.Now.ToUniversalTime());

                 }



                 #endregion login....

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