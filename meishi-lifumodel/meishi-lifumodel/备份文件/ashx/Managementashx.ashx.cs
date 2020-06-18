using meishi_lifumodel.BLL;
using meishi_lifumodel.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.ashx
{
    /// <summary>
    /// Managementashx 的摘要说明
    /// </summary>
    public class Managementashx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          //  context.Response.Write("Hello World");
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserManagement")//用户管理
            {
                // int Size = Int32.Parse(Convert.ToString(context.Request.QueryString["size"]));
                // string UserNumber = Convert.ToString(context.Request.QueryString["usernumber"]);
                //string CollectionNumber=

                int Size = 10;
                string sclx = "菜单收藏";//收藏类型

                myoperateClass ex = new myoperateClass();
                String strret = ex.UserManagement(sclx, Size);
                context.Response.Write(strret);
                return;


            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "editorload")//后台编辑器加载
            {
                // int Size = Int32.Parse(Convert.ToString(context.Request.QueryString["size"]));
                string tableflag = Convert.ToString(context.Request.QueryString["tableflag"]);
                string number = Convert.ToString(context.Request.QueryString["number"]);
                //string CollectionNumber=

                

                myoperateClass ex = new myoperateClass();
                String strret = ex.EditorLoad(tableflag, number);
                context.Response.Write(strret);
                return;


            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "User")//用户编辑
            {

                string czlx        = Convert.ToString(context.Request.QueryString["czlx"]);
                string UserName    = Convert.ToString(context.Request.QueryString["UserName"]);
                string Account     = Convert.ToString(context.Request.QueryString["Account"]);
                string PassWord    = Convert.ToString(context.Request.QueryString["PassWord"]);
                string PhoneNumber = Convert.ToString(context.Request.QueryString["PhoneNumber"]);
                string UserImg     = Convert.ToString(context.Request.QueryString["UserImg"]);
                string UserNumber  = Convert.ToString(context.Request.QueryString["UserNumber"]);

                BLLuser blluser = new BLLuser();
                string strret = "";
                if (czlx == "edit") {
                    int r = blluser.UserEdit(UserName, Account, PassWord, PhoneNumber, UserImg, UserNumber);
                    if (r == 0)
                    {
                        strret = "修改成功！";

                    }
                    else
                    {

                        strret = "修改失败！";


                    }

                    context.Response.Write(strret);
                    return;
                
                }
                else if (czlx == "add")
                {
                    int r = blluser.UserAdd(UserName, Account, PassWord, PhoneNumber, UserImg, UserNumber);
                    if (r == 0)
                    {
                        strret = "添加成功！";

                    }
                    else
                    {

                        strret = "添加失败！";


                    }

                    context.Response.Write(strret);
                    return;

                }


            }
            if (Convert.ToString(context.Request.QueryString["type"]) == "MainMenus")//主菜单编辑
            {
                string czlx             = Convert.ToString(context.Request.QueryString["czlx"]);
                string menuname         = Convert.ToString(context.Request.QueryString["menuname"]);
                string MenuNumber       = Convert.ToString(context.Request.QueryString["MenuNumber"]);
                string Introduces       = Convert.ToString(context.Request.QueryString["Introduces"]);
                string Type             = Convert.ToString(context.Request.QueryString["Type"]);
                string TimeMade         = Convert.ToString(context.Request.QueryString["TimeMade"]);
                string Collection       = Convert.ToString(context.Request.QueryString["Collection"]);
                string Relevant         = Convert.ToString(context.Request.QueryString["Relevant"]);
                string CoverImg         = Convert.ToString(context.Request.QueryString["CoverImg"]);
                string TeachingNumber   = Convert.ToString(context.Request.QueryString["TeachingNumber"]);
                string TeachingType     = Convert.ToString(context.Request.QueryString["TeachingType"]);
                string ProducerNumber   = Convert.ToString(context.Request.QueryString["ProducerNumber"]);
                string ingredients      = Convert.ToString(context.Request.QueryString["ingredients"]);
          
                BLLuser blluser = new BLLuser();
                string strret = "";

                
                if (czlx == "edit")
                {
                    int r = blluser.MainMenusEdit(menuname, MenuNumber, Introduces, Type, TimeMade, Collection, Relevant, CoverImg, TeachingNumber, TeachingType, ProducerNumber, ingredients);
                    if (r == 0)
                    {
                        strret = "修改成功！";

                    }
                    else
                    {

                        strret = "修改失败！";


                    }

                    context.Response.Write(strret);
                    return;

                }
                else if (czlx == "add")
                {
                    int r = blluser.MainMenusAdd(menuname, MenuNumber, Introduces, Type, TimeMade, Collection, Relevant, CoverImg, TeachingNumber, TeachingType, ProducerNumber, ingredients);
                    if (r == 0)
                    {
                        strret = "添加成功！";

                    }
                    else
                    {

                        strret = "添加失败！";


                    }

                    context.Response.Write(strret);
                    return;

                }

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