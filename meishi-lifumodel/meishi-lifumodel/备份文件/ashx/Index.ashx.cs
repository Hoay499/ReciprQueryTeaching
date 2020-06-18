using meishi_lifumodel.DBHelper;
using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace meishi_lifumodel.Frontdesk.ashx
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    /// 

    public class Index : IHttpHandler, IRequiresSessionState
    {

        int count=0;
        public void ProcessRequest(HttpContext context)
        {
            //if (context.Session["username"] != null)
            //{
            //    context.Response.Write("<script>alert('username is null');</script>");
            //    return;

            //}


            #region 根据菜单分类读取菜单
            if (Convert.ToString(context.Request.QueryString["type"]) == "getMenuByType")
            {
                //String useraccount = (context.Session["useraccount"]).ToString();
                String useraccount = "1001";
                String val = Convert.ToString(context.Request.QueryString["val"]);//根据传入的值匹配
                String strret = "";
                CreateMenuList ex = new CreateMenuList();
                //创建主页菜单
                int Size = 10;
                int index = 0;
                strret = ex.createMainMenuList("Type", val, Size, index);


                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 根据id读取菜谱（并根据名字查询其他几种不同做法)
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetSingleMenu") 
            {
                String useraccount = "1001";
               // String useraccount = (context.Session["useraccount"]).ToString();
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                CreateMenuList ex = new CreateMenuList();

                BLL.BLLmenu bll = new BLL.BLLmenu();

                IList<Menu> siglemenu = bll.GetSingleMenu(val);
                foreach (Menu menu in siglemenu)
                {
                    context.Session["MenuNumber"] = menu.MenuNumber;
                    context.Session["CollectionNumber"] = menu.Collection;
                }
                
                strret = ex.GetSingleMenu(siglemenu, useraccount);
                
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取食材信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetIngredientDetail") 
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                CreateMenuList ex = new CreateMenuList();

                strret = ex.GetIngredientDetail(val);
                
                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 获取菜谱评论信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserComment") 
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                CreateMenuList ex = new CreateMenuList();

                strret = ex.GetUserComment(val);
                
                context.Response.Write(strret);
                return;
            }
            #endregion 
          


            #region    退出登录
            if (Convert.ToString(context.Request.QueryString["type"]) == "logout")//退出登录
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                context.Session.RemoveAll();

               
                return;
            }
            #endregion
            #region 判断是否登录
            if (Convert.ToString(context.Request.QueryString["type"]) == "islogin")//判断是否登录
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                String username = "";
                String result = "";
                if (HttpContext.Current.Session["username"] != null)
                {

                }
                if (context.Session["username1"] != null)
                {
                    username = (context.Session["username"]).ToString();
                    result = username;
                }


                if (username == "")
                {

                    result = "未登录";
                }

                context.Response.Write(result);
                return;
            }
            #endregion
            #region 获取分类列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "classification")
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                myoperateClass ex = new myoperateClass();
                if (val == "mainclasslist")//主页主分类
                {
                    strret = ex.mainClassListImage();
                }
                else
                {
                    strret = ex.ClassificationListImage(val);
                }

                context.Response.Write(strret);
                return;
            }
            #endregion 获取分类列表


            if (Convert.ToString(context.Request.QueryString["type"]) == "mainclasslist")//获得主分类列表
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                myoperateClass ex = new myoperateClass();
                String strret = ex.ClassificationListImage(val);
                context.Response.Write(strret);
                return;
            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "getmenulist")//菜谱列表
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                myoperateClass ex = new myoperateClass();
                  int Size=0;
                  String urlstr = "";
                int index = 0;
                String strret = ex.indexMenuListImage(val,Size,urlstr,index);
                context.Response.Write(strret);
                return;
            }
            
            if (Convert.ToString(context.Request.QueryString["type"]) == "1")//得到新秀菜谱列表
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                int Size = 10;
                String urlstr="";
                 
                 
                
                String type = "1";
                myoperateClass ex = new myoperateClass();
                String strret = ex.createListImage(type,Size,urlstr,0);
                context.Response.Write(strret);
                return;
            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "11")//得到新秀菜谱列表
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                int Size = 10;
                int index=Convert.ToInt32(context.Request.QueryString["index"]);
                String urlstr = "";
                String type = "最近流行";
                BLL.BLLmenu a = new BLL.BLLmenu();

                if(count == 0)
                   count = a.GetMenuCount("1");
                context.Response.Write("index:"+index);
                if (count - index * Size <= 0) {
                    context.Response.Write("没有更多数据了");
                }
                else {
                    myoperateClass ex = new myoperateClass();
                    String strret = ex.createListImage2(type, Size, urlstr, index);
                    context.Response.Write(strret);
                    
                }
               
               
                return;
            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "2")//得到新秀菜谱列表
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                int Size = 10;
                String urlstr = "";
                String type = "最近流行";
                myoperateClass ex = new myoperateClass();
                String strret = ex.createListImage(type, Size, urlstr,0);
                context.Response.Write(strret);
                return;
            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "3")//得到新秀菜谱列表
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                int Size = 10;
                String urlstr = "";
                String type = "时令食材";
                myoperateClass ex = new myoperateClass();
                String strret = ex.createListImage(type, Size, urlstr,0);
                context.Response.Write(strret);
                return;
            }
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
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