using meishi_lifumodel.DBHelper;
using meishi_lifumodel.Model;
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
    public class DataHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             BLL.BLLuser bll = new BLL.BLLuser();
             CreateHtml HtmlCreate = new CreateHtml();
             String strret = "";
             int datacount = 0;
            
             String Account = (context.Session["useraccount"]).ToString();
             String datatype = Convert.ToString(context.Request.QueryString["datatype"]);


             String presentindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
             String pages = Convert.ToString(context.Request.QueryString["pages"]);
             //String PresentPageindex = (context.Session["persentpageindex"]).ToString();
             int Size = 10;
             String tablename = "";
             //ORDER BY Id DESC
             int Oldpages = Int32.Parse(pages);
            
               datacount = bll.GetDataCount(Account, "Account", tablename);
             double x = datacount / Size;
             int PresentPages = Int32.Parse(Math.Ceiling(x).ToString());
             if (PresentPages == Oldpages)
             {
                 context.Response.Write(strret);
                 return;
             }
             // 获取数据下方
             // strret = HtmlCreate.getDataBottomimage(datatype,presentindex + 1,pages);
             if (PresentPageindex != "") presentindex = Int32.Parse(PresentPageindex);

             String tablename = "";
              
             double x = datacount / Size;
             int Pages = Int32.Parse(Math.Ceiling(x).ToString());
             int index = Size * (presentindex+1);
            
           
             String bywhat = "";  
             
            if (datatype== "preUserfollow")
            {
                tablename="userfollowview";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat,tablename);
                IList<UserFollows> Lists = bll.GetUserPersonFollow(Account, Size, index);
                if (Lists.Count() != 0)
                {
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists);
                }
            }else if (datatype == "nextUserfollow")
            {
                tablename = "userfollowview";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<UserFollows> Lists = bll.GetUserPersonFollow(Account, Size, index);
                if (Lists.Count() != 0)
                {
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists);
                }
            }else if (datatype == "preUserCollect")
            {
                tablename = "usercollectionview";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<UserFollows> Lists = bll.GetUserPersonFollow(Account, Size, index);
            }else if (datatype == "nextUserCollect")
            {
                tablename = "usercollectionview";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<UserFollows> Lists = bll.GetUserPersonFollow(Account, Size, index);
            }else if (datatype == "preStranger")
            {
                tablename = "user";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<User> Lists = bll.getStrangerList(Account, Size, index);


                strret = HtmlCreate.getStrangerListimage(Lists);
            }else if (datatype == "nextStranger")
            {
                tablename = "user";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<User> Lists = bll.getStrangerList(Account, Size, index);


                strret = HtmlCreate.getStrangerListimage(Lists);
            }else if (datatype == "preHistoryLL")
            {
                tablename = "userhistory";
                bywhat = "Account";
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<UserFollows> Lists = bll.GetUserPersonFollow(Account, Size, index);
            }else if (datatype == "nextHistoryLL")
            {
                tablename = "userhistory";
                bywhat = "Account";
                
                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<NewNotice> Lists = bll.getRecord(Account, "historyrecord", Size, index);
                strret = HtmlCreate.getHistoricalRecordimage(Lists);
            } else if (datatype == "nextUserFriends")
            {
                tablename = "friendapplicationview";
                bywhat = "Account";

                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<FriendApplication> Lists = bll.getFriendApplication(Account, Size, index);
                strret = HtmlCreate.getFriendApplicationimage(Lists);
            }
            else if (datatype == "preUserFriends")
            {
                tablename = "friendapplicationview";
                bywhat = "Account";

                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<FriendApplication> Lists = bll.getFriendApplication(Account, Size, index);
                strret = HtmlCreate.getFriendApplicationimage(Lists);
            }
                 
            else if (datatype == "nextUserFriends")
            {
                tablename = "userfollowview";
                bywhat = "Account";

                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<UserFollows> Lists = bll.getUserFriends(Account, Size, index);
                strret = HtmlCreate.CreateUserPersonFollowImage(Lists);
            }
            else if (datatype == "preUserFriends")
            {
                tablename = "userfollowview";
                bywhat = "Account";

                datacount = bll.GetDataCount(Account, bywhat, tablename);
                IList<UserFollows> Lists = bll.getUserFriends(Account, Size, index);
                strret = HtmlCreate.CreateUserPersonFollowImage(Lists);
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