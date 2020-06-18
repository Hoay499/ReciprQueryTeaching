using meishi_lifumodel.DBHelper;
using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace meishi_lifumodel.Frontdesk.ashx
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    /// 

    public class UploadImg: IHttpHandler 
    {

       
        public void ProcessRequest(HttpContext context)
        {


            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            //String Account = (context.Session["useraccount"]).ToString();
            // string username = context.Request.QueryString["username"];
            //String h=context.Request.QueryString["img1"];
            //String tpty = context.Request.QueryString["tpty"]; false
            String tpty = context.Request.Form["tpty"];
            String usernumber = context.Request.Form["usernumber"];
            String menunumber = context.Request.Form["menunumber"];

            //String tpty3 = context.Request["tpty"]; true
            String bzcount = context.Request.QueryString["bzcount"];
            if (tpty == "cp")
            {
                String file = context.Request.Files["file1"].FileName;
                String cptppath = context.Request.Form["cptppath"];
                string name = "cp.jpg";
                string pa = "~/images/userproduction/" + usernumber + "/";
                //System.IO.Directory.CreateDirectory(@"C:\Users\Administrator\Desktop\upppp");//不存在就创建目录 
                String ff = context.Request.MapPath(pa);
                if (!Directory.Exists(pa))
                {
                    //创建文件夹 
                    Directory.CreateDirectory(@ff);
                }
                pa = pa + menunumber + "/";
                ff = context.Request.MapPath(pa);
                if (!Directory.Exists(pa))
                {
                    //创建文件夹 
                    Directory.CreateDirectory(@ff);
                }
                // FileStream dir = new FileStream(); 

                context.Request.Files["file1"].SaveAs(ff + name);
                // context.Response.Write("true");
                 
            }
            else if (tpty == "bztp")
            {
                String bztppath = context.Request.Form["bztppath"];
                int bzc = Int32.Parse(bzcount);
                //int bzcount = 1;
                string fileName2 = "";
                for (int i = 1; i <= bzc; i++)
                {
                    String d = "File" + i.ToString();
                    fileName2 = context.Request.Files[d].FileName; //文件名


                }

                string fileName = context.Request.Files["File"].FileName; //文件名
                string fileType = context.Request.Files["File"].ContentType;//文件类型
                string fileExt = System.IO.Path.GetExtension(fileName); //文件扩展后缀名
                String ff = context.Request.MapPath("~/File/");
                //context.Response.Write("true");
                
            }
            context.Response.Redirect("../Frontdesk/MadeMenu/MadeMenu.html");
             //context.Response.Write("true");
             return;
            //#region 根据菜单分类读取菜单
            //if (Convert.ToString(context.Request.QueryString["type"]) == "getMenuListsByType")
            //{
            //    CreateHtml HtmlCreate = new CreateHtml();
            //    BLL.BLLmenu bll = new BLL.BLLmenu();
            //     BLL.BLLuser bll2 = new BLL.BLLuser();
            //    String strret = "";
            //    String val = Convert.ToString(context.Request.QueryString["val"]);//根据传入的值匹配
            //    String valtype = Convert.ToString(context.Request.QueryString["valtype"]);//根据传入的值匹配
            //    String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
            //    String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
            //    String actype = Convert.ToString(context.Request.QueryString["actype"]);
            //    int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
            //    if (actype == "pre" && OldPageindex == "1")
            //    {
            //        context.Response.Write(strret);
            //        return;
            //    }
            //    else if (actype == "next" && k == 0)
            //    {
            //        context.Response.Write(strret);
            //        return;
            //    }
            //    IList<MenuAll> Lists;
            //    double Size = 12.0;
            //    String tablename = "mainmenus";
            //    String bywhat = " Type='" + val + "'";
            //    //计算当前页面数
            //    int datacount =  bll2.GetDataCount(bywhat, tablename);
            //    double x = datacount / Size;
            //    int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

            //    //int presentindex = Int32.Parse(OldPageindex);
            //    int pageindex = Int32.Parse(OldPageindex);
            //    int dataindex = (Int32)Size * (pageindex - 1);
            //    Lists = bll.GetMenuList("Type",val, (Int32)Size, dataindex);
            //    //如果数据页数改变
            //    if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
            //        strret = HtmlCreate.createMainMenuListimage(Lists,valtype, pageindex, NewPages);
            //    else
            //        strret = HtmlCreate.createMainMenuListimage(Lists,valtype, pageindex, Int32.Parse(OldPages));


 
            //    context.Response.Write(strret);
            //    return;
            //}
            //#endregion 
             
         
            
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