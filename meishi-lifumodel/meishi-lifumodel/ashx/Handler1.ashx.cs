using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace meishi_lifumodel.ashx
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            String val = Convert.ToString(context.Request.QueryString["val"]);
            String zl = Convert.ToString(context.Request.QueryString["zl"]);
            String sh = "";
            string[] Array1 = new string[10000];

            val = val.Trim();
            //string[] sArray = Regex.Split(val, "|", RegexOptions.Singleline);
            string[] sArray = val.Split(new char[] { '|' }); 
            FileStream stream = new FileStream(@"C:\Users\Administrator\Desktop\aa.txt", FileMode.Append);//fileMode指定是读取还是写入
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("====================");
             foreach (string i in sArray) {
                 sh = "insert  into  menu_classification (number,Category_parent,Classification_contents)values('1128','"+zl+"','" + i.ToString() + "');";
                 writer.WriteLine(sh + "\r\n");
            
             };
          
            writer.WriteLine("====================");
            writer.Close();//释放内存
            stream.Close();//释放内存
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