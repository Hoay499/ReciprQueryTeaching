using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace meishi_lifumodel.ashx
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest( HttpContext context)
        {
            //HttpContextBase
            //HttpContextBase fi =context.Request.Files[""]; 
          //  String i = fi.Request.Form["tpty"];
          // String bzcount = fi.Request.Form["bzcount"];
           // context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
                    //String Account = (context.Session["useraccount"]).ToString();
                    //string username = context.Request.QueryString["username"];
                    //String h=context.Request.QueryString["img1"];
                  //  HttpPostedFile f = HttpContext.Current.Request.Files;
                  //  String tpty = context.Request.QueryString["tpty"];
                //    String file1 = context.Request.Form["tpty"];   //file可能为null
            // pa = "~/images/userproduction/" + usernumber + "/" + menunumber + "/cp.jpg";
           //pa = "~/images/userproduction/" + usernumber + "/" + menunumber + "/steps/" + i + ".jpg";
           // ff = context.Request.MapPath(pa);
            // if (File.Exists(ff))  {  // 是文件   }
            // else if (Directory.Exists(ff)) {   // 是文件夹 }
            //else  {   // 都不是  }
                   String usernumber = (context.Session["useraccount"]).ToString();
                   String useractype = context.Request.Form["submittype"];
                  // String username = (context.Session["username"]).ToString();
                   if (useractype == "edit")
                   {
                       String alterlist = context.Request.Form["alterlist"];
                       String menunumber = context.Request.Form["menunumber2"];
                       String[] a = alterlist.Split(',');
                       String pa = " ";
                       String ff = " ";
                       foreach (string i in a)
                       {

                           if (i == "0")
                           {
                               #region //修改成品图片
                               string pa2 = "~/images/userproduction/" + usernumber + "/" + menunumber + "/cp.jpg";
                               ff = context.Request.MapPath(pa2);
                               if (File.Exists(ff))
                               {
                                   File.Delete(ff);
                                   context.Request.Files["file1"].SaveAs(ff);
                               }
                               #endregion
                           }
                           else
                           {
                               #region //修改步骤图片
                               pa = "~/images/userproduction/" + usernumber + "/" + menunumber + "/steps/" + i + ".jpg";
                               ff = context.Request.MapPath(pa);
                               if (File.Exists(ff))
                               {
                                   File.Delete(ff);
                               }
                                   // context.Request.Files["file1"].SaveAs(pa);
                                   if (i == "1")
                                       context.Request.Files["bztpuploadfile1"].SaveAs(ff);
                                   else if (i == "2")
                                       context.Request.Files["bztpuploadfile2"].SaveAs(ff);
                                   else if (i == "3")
                                       context.Request.Files["bztpuploadfile3"].SaveAs(ff);
                                   else if (i == "4")
                                       context.Request.Files["bztpuploadfile4"].SaveAs(ff);
                                   else if (i == "5")
                                       context.Request.Files["bztpuploadfile5"].SaveAs(ff);
                                   else if (i == "6")
                                       context.Request.Files["bztpuploadfile6"].SaveAs(ff);
                                   else if (i == "7")
                                       context.Request.Files["bztpuploadfile7"].SaveAs(ff);
                                   else if (i == "8")
                                       context.Request.Files["bztpuploadfile8"].SaveAs(ff);
                                   else if (i == "9")
                                       context.Request.Files["bztpuploadfile9"].SaveAs(ff);
                                   else if (i == "10")
                                       context.Request.Files["bztpuploadfile10"].SaveAs(ff);
                                   else if (i == "11")
                                       context.Request.Files["bztpuploadfile11"].SaveAs(pa);
                              
                               #endregion
                           }
                       }

                   }





                 if (useractype == "add")
                 { 

                    String bzcount = context.Request.Form["bzcount"];
                   // String usernumber = context.Request.Form["usernumber2"];
                    String menunumber = context.Request.Form["menunumber2"];
                    String bztppath = context.Request.Form["bztppath"];
                    int bzc = Int32.Parse(bzcount);
                       string pa="";
                       String ff="";
                       string name="";

                       #region //保存成品图片

                       String file = context.Request.Files["file1"].FileName;
                        String cptppath = context.Request.Form["cptppath"];
                         name = "cp.jpg";
                         pa = "~/images/userproduction/" + usernumber+"/";
                        //System.IO.Directory.CreateDirectory(@"C:\Users\Administrator\Desktop\upppp");//不存在就创建目录 
                       
                        ff = context.Request.MapPath(pa); 
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


                        context.Request.Files["file1"].SaveAs(ff + name);
                        //int bzcount = 1;
                        #endregion
                        #region  //保存步骤图片
                        pa = "~/images/userproduction/" + usernumber + "/";
                    //System.IO.Directory.CreateDirectory(@"C:\Users\Administrator\Desktop\upppp");//不存在就创建目录 
                      ff = context.Request.MapPath(pa);

                    if (!Directory.Exists(pa))
                    {
                        //创建文件夹 
                        Directory.CreateDirectory(@ff);
                    }
                    pa = pa + menunumber + "/steps/";
                    ff = context.Request.MapPath(pa);
                    if (!Directory.Exists(pa))
                    {
                        //创建文件夹 
                        Directory.CreateDirectory(@ff);
                    }
                    
                    for (int i = 1; i <= bzc; i++)
                    {
                        String d = "bztpuploadfile1" + i.ToString();
                          name = i + ".jpg";
                        if (i == 1) 
                            context.Request.Files["bztpuploadfile1"].SaveAs(ff + name);
                        else if (i == 2)
                            context.Request.Files["bztpuploadfile2"].SaveAs(ff + name);
                        else if (i == 3)
                            context.Request.Files["bztpuploadfile3"].SaveAs(ff + name);
                        else if (i == 4)
                            context.Request.Files["bztpuploadfile4"].SaveAs(ff + name);
                        else if (i == 5)
                            context.Request.Files["bztpuploadfile5"].SaveAs(ff + name);
                        else if (i == 6)
                            context.Request.Files["bztpuploadfile6"].SaveAs(ff + name);
                        else if (i == 7)
                            context.Request.Files["bztpuploadfile7"].SaveAs(ff + name);
                        else if (i == 8)
                            context.Request.Files["bztpuploadfile8"].SaveAs(ff + name);
                        else if (i == 9)
                            context.Request.Files["bztpuploadfile9"].SaveAs(ff + name);
                        else if (i == 10)
                            context.Request.Files["bztpuploadfile10"].SaveAs(ff + name);
                        else if (i == 11)
                            context.Request.Files["bztpuploadfile11"].SaveAs(ff + name);

                    }

                     #endregion

                 }



                  context.Response.Redirect("../Frontdesk/MadeMenu/MadeMenu.html?menunumber=dnon&usernumber=" + usernumber);
                  return;
           

   
          
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
// DirectoryInfo dir = new DirectoryInfo(ff);
//if (dir is DirectoryInfo)            //判断是否文件夹
// {
//   DirectoryInfo subdir = new DirectoryInfo(ff);
//   subdir.Delete(true);          //删除子目录和文件
//  }
// else
//  {
//如果 使用了 streamreader 在删除前 必须先关闭流 ，否则无法删除 sr.close();
//    File.Delete(ff);      //删除指定文件
//  }
// FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
// foreach (FileSystemInfo k in fileinfo)
//{

// }          