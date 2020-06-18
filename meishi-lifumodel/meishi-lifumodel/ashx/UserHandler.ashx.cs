using meishi_lifumodel.BLL;
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
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
             context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
             context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

             BLL.BLLuser bll = new BLL.BLLuser();
             myoperateClass ex = new myoperateClass();
             CreateHtml HtmlCreate = new CreateHtml();
           
            #region    退出登录
            if (Convert.ToString(context.Request.QueryString["type"]) == "logout")//退出登录
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                context.Session.RemoveAll();

               
                return;
            }
            #endregion
            

             #region 判断等级
            if (Convert.ToString(context.Request.QueryString["type"]) == "checkgrade")
            {
               
                String result = "disupgrade";
                String dj = "";

                String userjy = (context.Session["experience"]).ToString();
                String userlevel = (context.Session["userlevel"]).ToString();
                String UserTag = (context.Session["usertag"]).ToString()  ;
                String Account = (context.Session["useraccount"]).ToString();

                int t = Int32.Parse(userjy);
                if (t < 100) {
                    dj = "初级一";
                }else if(t>=100&&t<200){
                    dj = "初级二";
                } else if (t >= 200 && t < 400) {
                    dj = "初级三";
                }  else if (t >= 400 && t < 800)  {
                    dj = "初级四";
                }  else if (t >= 800 && t < 1600)  {
                    dj = "初级五";
                }
                
                if(dj!=UserTag){
                    context.Session["usertag"] = dj;
                    int r2 = bll.AlterSingleAttr("User", "UserTag", dj, " where Account='" + Account + "'");

                }
             //  context.Session["experience"] = userinfo.Experience.ToString();
               
                 

                 
                context.Response.Write(result);
                return;
            }
            #endregion
            #region 判断是否登录获得账号
            if (Convert.ToString(context.Request.QueryString["type"]) == "getaccount")
            {
               
                String result = "";

                if (context.Session["username"] != null)
                {
                    result = (context.Session["useraccount"]).ToString();

                    
                }

                 
                context.Response.Write(result);
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
                
                if (context.Session["username"] != null)
                {
                   username = (context.Session["username"]).ToString();
                   String  usertag = (context.Session["usertag"]).ToString();
                   String userimg = (context.Session["userimg"]).ToString();
                   String useraccount = (context.Session["useraccount"]).ToString();


                   String tablename = "usernotices";
                   String bywhat = " Account='" + useraccount + "'";
                   //计算当前页面数
                   int datacount = bll.GetDataCount(bywhat, tablename);

                   //result += "<img  src=" + userimg + "   onclick='popUserInfoBox()' /> ";
                   //if (datacount == 0)
                   //{
                   //    result += " <p id='wdxxjls'>" + username + "</p>";
                   //}
                   //else {
                   //    result += " <p id='wdxxjls'>共有" + datacount + "条信息未读</p>";
                   //}
                   result += "    <li><a href='#' onclick='popUserInfoBox()'>个人信息</a></li>";
					result += "				  <li><a href='#' onclick='logout()'>退出登录</a></li>";
                   //result +="   <div class='userheadpro' onclick='popUserInfoBox()'>";
                   //result +=" <img  src='"+userimg+"' />";
                   //result +=" </div>";
                   //result +="  <div class='usermiddlejs'>";
                   //result +="  <div class='wdusername'>"+username+"</div>";
                   //result +="   <div class='wdlabel'>"+usertag+"</div>";
                   //result +="  <div class='wdjyan'>经验</div>";
                   //result +="  </div>";
          
                   //result +="  <div class=‘userrightjs'>";
                   //result +="   <ul class='userrightul'>";
                   //result +="  <li >wwwww</li>";
                   //result +="  <li >wwwww</li>";
                   //result +="  <li >wwwww</li>"; 
                   //result +="  </ul>"; 
                   //result +=" </div>";

                    
                }

                if (username == "")
                {
                    result = "unlogin";
                }
               
                context.Response.Write(result);
                return;
            }
            #endregion

            #region  判断用户是否已存在
             if (context.Request.QueryString["type"] == "checkusername")
             {
                 string username = context.Request.QueryString["username"];
                 String tablename = "user";
                // String bywhat = "UserName";
                 String bywhat = " UserName='" + username+"'";
                 int r1 = bll.GetDataCount(bywhat, tablename);
                 if (r1 == 0)  
                 {
                     context.Response.Write("fail");
                 }
                 else
                 {
                     context.Response.Write("success"); 
                 }
             }
             #endregion

            #region  判断账号
             if (context.Request.QueryString["type"] == "checkAccount")
             {
                 string account = context.Request.QueryString["account"];

                 String bywhat = " Account='" + account+"'";
                 string tablename = "user";
                 int r1 = bll.GetDataCount(bywhat, tablename);
                 if (r1 == 0)  
                 {
                     context.Response.Write("fail");
                 }
                 else
                 {
                     context.Response.Write("success"); 
                 }
             }
             #endregion

            #region  用户登录
             if (context.Request.QueryString["type"] == "login")
             {
                 string username = context.Request.QueryString["username"];
                 string password = context.Request.QueryString["password"];
                 string uselevel = "";
                 
                 IList<User> user = bll.Userlogin(username, password);
                 if(user.Count()==0){
                     context.Response.Write("fail");
                 }
                 else{
                      foreach (User userinfo in user)
                     {
                        context.Session["username"] = userinfo.UserName.ToString();
                        context.Session["useraccount"] = userinfo.Account.ToString();
                        context.Session["userimg"] =userinfo.UserImg.ToString();
                        context.Session["usertag"] = userinfo.UserTag.ToString();
                        context.Session["followersnum"] = userinfo.FollowersNum.ToString();
                          context.Session["follownum"] = userinfo.FollowNum.ToString();
                          context.Session["collectionnum"] = userinfo.CollectionNum.ToString();
                          context.Session["jointime"] = userinfo.JoinTime.ToString();
                          context.Session["experience"] = userinfo.Experience.ToString();
                          context.Session["userlevel"] = userinfo.UserLevel.ToString();
                          uselevel = userinfo.UserLevel.ToString();
                          context.Session["integral"] = userinfo.Integral.ToString();
                          context.Session["releaseproductionnum"] = userinfo.ReleaseProductionNum.ToString();
                          context.Session["allproductionnum"] = userinfo.AllProductionNum.ToString();
                          String hh = (context.Session["allproductionnum"]).ToString();
                          context.Session["menudidnum"] = userinfo.MenuDidNum.ToString(); 
                           
                       // context.Session["userimg"] =userinfo.UserImg.ToString();
                       // HttpContext.Current.Session["username"] = a;
                     }
                      if (uselevel == "administrator")
                      {
                          context.Response.Write("adminsuccess");
                      }
                      else {
                          context.Response.Write("usersuccess");
                      }
                     
                 }      
             }
                 #endregion  

            #region 用户注册
            if (Convert.ToString(context.Request.QueryString["type"]) == "register")
            {
                string username = Convert.ToString(context.Request.QueryString["username"]);
                string Pword = Convert.ToString(context.Request.QueryString["password"]);
                BLLuser blluser = new BLLuser();
                String Account="";
                int i =0;
                String p = "";
                string[] s1 = { "a","_","-", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };//字符列表
                Random rand = new Random();//实例化rand
                for (int k = 0; k <3; k++) {
                    i = rand.Next(0, 28);
                    Account += s1[i];
                    p += i.ToString();   
                }
                Account +=p;
                String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "";


                int r = blluser.UserRegister(username, Pword, Account, actime);
                if (r == 0)
                {
                    context.Response.Write("fail");
                    return;
                }
                else{
                    context.Response.Write(Account);
                     return;
                } 
            }
            #endregion


             #region 获取用户所有信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "getUserAllxinxi")
            {
                 
                String Account = (context.Session["useraccount"]).ToString();
                IList<User> user = bll.getUser(Account);
                IList<UserAttribute> userattribute = bll.getUserAttribute(Account);


                String strret = "";

                strret = HtmlCreate.getUesrDetailimage(user, userattribute);
                
               
                context.Response.Write(strret);
                 return;
              
            }
            #endregion


            //#region 收藏菜谱
            //if (Convert.ToString(context.Request.QueryString["type"]) == "Collect")
            //{
            //    String flag ="notok";
            //   // string MenuNumber = Convert.ToString(context.Request.QueryString["menunumber"]);
            //    String useraccount= (context.Session["useraccount"]).ToString();
            //    String menunumber = (context.Session["MenuNumber"]).ToString();
            //    //string Collection = Convert.ToString(context.Request.QueryString["Collection"]);

            //    string Collection = (context.Session["CollectionNumber"]).ToString();
            //    int collection = int.Parse(Collection);
            //    string strret = "";
            //    string sclx = "菜单收藏";//收藏类型
            //    collection++;
            //    Collection = collection.ToString();

            //    BLLuser blluser = new BLLuser();
            //    int r = blluser.Collect(sclx, useraccount, menunumber, Collection);//收藏菜单

            //    if (r > 0)
            //    {
            //        flag = "ok";
                   
            //    }

            //    context.Response.Write(flag);
            //    return;
            
            
            //}

            //#endregion

            //#region 取消收藏菜谱
            //#endregion

            
             
         
              #region 获取用户历史足迹2
            if (Convert.ToString(context.Request.QueryString["type"]) == "getUserNewHistoricalRecord")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
               
                 
                 IList<NewNotice> Lists;
                double Size = 8.0;
               //  String tablename = "userhistory";
               ///  //String bywhat = " Account='" + Account+"'";
                //计算当前页面数
               //  int datacount = bll.GetDataCount(bywhat, tablename);
              //  double x = datacount / Size;
               // int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                 
              //  int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getHistoricalRecord2(Account);
                //如果数据页数改变

                strret = HtmlCreate.getHistoricalRecord2image(Lists);
              
               
               
                  
             
                
                context.Response.Write(strret);
                return;
            }
            #endregion
            #region 获取用户历史足迹
            if (Convert.ToString(context.Request.QueryString["type"]) == "getHistoricalRecord")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                if (actype == "pre" && OldPageindex == "0")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k < 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                 IList<NewNotice> Lists;
                double Size = 8.0;
                 String tablename = "userhistory";
                 String bywhat = " Account='" + Account+"'";
                //计算当前页面数
                 int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getHistoricalRecord(Account, "historyrecord", (Int32)Size, dataindex);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 ||Int32.Parse(OldPages)!= NewPages)
                    strret = HtmlCreate.getHistoricalRecordimage(Lists, pageindex, NewPages, actype);
                else
                    strret = HtmlCreate.getHistoricalRecordimage(Lists, pageindex, Int32.Parse(OldPages), actype);
               
               
                  
             
                
                context.Response.Write(strret);
                return;
            }
            #endregion
            #region 获取用户新的信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "getNewNotice")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String noticetype = Convert.ToString(context.Request.QueryString["noticetype"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                if (actype == "pre" && OldPageindex == "0")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k < 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<UserNotices> Lists;
                double Size = 8.0;
                String tablename = "usernotices";
                String bywhat = " Account='" + Account + "' and ctype='" + noticetype + "'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getRecord(Account, noticetype, (Int32)Size, dataindex);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    strret = HtmlCreate.getUserNoticesimage(noticetype, Lists, pageindex, NewPages, actype);
                else
                    strret = HtmlCreate.getUserNoticesimage(noticetype, Lists, pageindex, Int32.Parse(OldPages), actype);

                int allunreadcount = bll.GetDataCount("", tablename);


                strret = strret + "|" + allunreadcount.ToString();


                //strret = ex.getNewNoticeimage(Lists);
                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 获取用户的好友
            if (Convert.ToString(context.Request.QueryString["type"]) == "getUserFriends")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);

                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                if (actype == "pre" && OldPageindex == "0")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k<0)
                {
                    context.Response.Write(strret);
                    return;
                }

                IList<UserFollows> Lists;
                double Size = 8.0;
                String tablename = "userfollowview";
                String bywhat = " Account='" + Account + "' and CollectionType='userfriend'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getUserFriends(Account, (Int32)Size, dataindex);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, NewPages, "friend", actype);

                else
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, Int32.Parse(OldPages), "friend", actype);

                context.Response.Write(strret);
                return;
            }
            #endregion
            #region 接受好友申请
            if (Convert.ToString(context.Request.QueryString["type"]) == "acceptUserhysq")
            {
                string ObAccount = context.Request.QueryString["ObAccount"];
                string ObCollection = context.Request.QueryString["ObCollection"];
                string ObName = context.Request.QueryString["ObName"];
                String Account = (context.Session["useraccount"]).ToString();
                double size = 8.0;
                String strret = "";

                String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你觉得对方很有品位，毫不犹豫的接受了" + ObName + "发来的好友请求";
                String actitle = "添加好友  " + ObName;
                String ctype = "addfriend";

                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                int r = bll.AddUser(Account, ObAccount, ObCollection);

                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户的好友申请
            if (Convert.ToString(context.Request.QueryString["type"]) == "getUserhysq")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);

                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                if (actype == "pre" && OldPageindex == "0")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k < 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                 IList<FriendApplication> Lists;
                double Size = 8.0;
                 String tablename = "friendapplicationview";
                //计算当前页面数
                String bywhat = " Account='" + Account+"'";
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getFriendApplication(Account, (Int32)Size, dataindex);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 ||Int32.Parse(OldPages)!= NewPages)
                    strret = HtmlCreate.getFriendApplicationimage(Lists, pageindex, NewPages,actype);
                else
                    strret = HtmlCreate.getFriendApplicationimage(Lists, pageindex, Int32.Parse(OldPages),actype); 

              
                
                
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 删除好友
            if (Convert.ToString(context.Request.QueryString["type"]) == "DeleteFriend")
            {
                string ObAccount = context.Request.QueryString["ObAccount"];
                string ObCollection = context.Request.QueryString["ObCollection"];
                string ObName = context.Request.QueryString["ObName"];
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();

                String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你觉得不行，毫不犹豫的删除了" + ObName;
                String actitle = "删除  " + ObName;
                String ctype = "DeleteFriend";

                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                int r = bll.DeleteFriend(Account, ObAccount, ObCollection);
               //int r = bll.UnFollowUser(Account, ObAccount, ObCollection);
                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 关注该用户
            if (Convert.ToString(context.Request.QueryString["type"]) == "FollowUser")
            {
                string ObAccount = context.Request.QueryString["ObAccount"];
                string ObCollection = context.Request.QueryString["ObCollection"];
                string ObName = context.Request.QueryString["ObName"];
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();

                String tablename = "usercollection";
                String bywhat = " Account='" + Account + "' and ObjectNumber='" + ObAccount + "' and CollectionType='userfollow'";
                //bywhat += "and  (CollectionType='userfriend' or CollectionType='userfollow'))  and Account <> '" + Account + "'";
                //" Account='" + Account+"'";
                int datacount = bll.GetDataCount(bywhat, tablename);

                if (datacount == 0)
                {

                    String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                    String content = "你终于找到了，毫不犹豫的关注了" + ObName;
                    String actitle = "关注  " + ObName;
                    String ctype = "follow";

                    int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                    int follownum = Int32.Parse((context.Session["follownum"]).ToString());
                    follownum++;
                    
                    String val = follownum.ToString();
                    context.Session["follownum"] = val;

                    int r2 = bll.AlterSingleAttr("User", "FollowNum", val, " where Account='" + Account + "'");
                   
                    int r = bll.FollowUser(Account, ObAccount, ObCollection);
                    strret="ok";
                }
                else {

                    strret = "followed";
                }
                
                context.Response.Write(strret);
                return;
            }
            #endregion   

            #region 取消关注该用户
            if (Convert.ToString(context.Request.QueryString["type"]) == "UnFollowUser")
            {
                string ObAccount = context.Request.QueryString["ObAccount"];
                string ObCollection = context.Request.QueryString["ObCollection"];
                string ObName = context.Request.QueryString["ObName"];
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();

                String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你觉得不行，毫不犹豫的取关了" + ObName;
                String actitle = "取关  " + ObName;
                String ctype = "unfollow";

                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                int follownum = Int32.Parse((context.Session["follownum"]).ToString());
                follownum--;
                String val = follownum.ToString();
                context.Session["follownum"] = val;
                int r2 = bll.AlterSingleAttr("User", "FollowNum", val, " where Account='" + Account + "'");
                   
                int r = bll.UnFollowUser(Account, ObAccount, ObCollection);
                context.Response.Write(strret);
                return;
            }
            #endregion  

            #region 收藏该菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "LikeMenu")
            {
                string ObMenuNumber = context.Request.QueryString["ObMenuNumber"];
                string ObCollection = context.Request.QueryString["ObCollection"];
                string ObName = context.Request.QueryString["ObName"];
                String strret = "ok";
                 String Account="";
                 if (context.Session["useraccount"] != null)
                     Account = (context.Session["useraccount"]).ToString();
                 else {
                     strret = "unlogin";
                     context.Response.Write(strret);
                     return;
                 }
                     
                String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你终于找到了，毫不犹豫的收藏了" + ObName;
                String actitle = "收藏  " + ObName;
                String ctype = "collect";

                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                int collectionnum = Int32.Parse((context.Session["collectionnum"]).ToString());
                collectionnum++;
                String val = collectionnum.ToString();
                context.Session["collectionnum"] = val;
                int r2 = bll.AlterSingleAttr("User", "CollectionNum", val, " where Account='" + Account + "'");
                   
                int r = bll.LikeMenu(Account, ObMenuNumber, ObCollection);
                context.Response.Write(strret);
                return;
            }
            #endregion

            #region 取消收藏该菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "DisLikeMenu")
            {
                string ObMenuNumber = context.Request.QueryString["ObMenuNumber"];
                string ObCollection = context.Request.QueryString["ObCollection"];
                string ObName = context.Request.QueryString["ObName"];
                String strret = "ok";
                String Account = (context.Session["useraccount"]).ToString();

                String actime = DateTime.Now.ToLongDateString().ToString() + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你终于找到了，毫不犹豫的取消了对" + ObName+"的收藏";
                String actitle = "取消收藏  " + ObName;
                String ctype = "uncollect";

                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                int collectionnum = Int32.Parse((context.Session["collectionnum"]).ToString());
                collectionnum--;
                String val = collectionnum.ToString();
                context.Session["collectionnum"] = val;
                int r2 = bll.AlterSingleAttr("User", "CollectionNum", val, " where Account='" + Account + "'");
                   
                int r = bll.DisLikeMenu(Account, ObMenuNumber, ObCollection);
                context.Response.Write(strret);
                return;
            }
            #endregion  

            #region 获取称号
            if (Convert.ToString(context.Request.QueryString["type"]) == "getMedals")
            {
                String strret = "";
                String MedalType = "称号";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);

                if (actype == "pre" && (OldPageindex == "0" || OldPageindex == "-1"))
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k == -1)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<UserMedalsView> Lists;
                double Size = 10.0;
                String tablename = "medals";
                String bywhat = " MedalType='" + MedalType + "'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                bywhat = " status='0' and Account='"+Account+"'";
                tablename = "usermedalsview";
                int datacount2 = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);

                Lists = bll.getMedals(Account, (Int32)Size, dataindex);

                String datac = datacount2.ToString() + "/" + datacount.ToString();
                String strhead = HtmlCreate.CreateHeadImage("Medals", datac, Account);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    //strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, NewPages, "follow", actype);
                    strret = HtmlCreate.CreateMedalsImage(Lists, pageindex, NewPages, actype);

                else
                    strret = HtmlCreate.CreateMedalsImage(Lists, pageindex, Int32.Parse(OldPages), actype);

                strret = strhead + strret;
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户的称号
            if (Convert.ToString(context.Request.QueryString["type"]) == "getUserMedals")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();

                IList<UserMedalsView> Lists =bll.getUserMedals(Account);

                
                foreach (UserMedalsView list in Lists) {
                    strret +="|"+ list.MedalNumber+","+list.finished; 
                }

                context.Response.Write(strret);
                return;
            }
            #endregion  

            
             #region 加载用户单个菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "getSingleUserMenu")
            {
                String strret = "";

                String MenuNumber = Convert.ToString(context.Request.QueryString["MenuNumber"]);

              
                String  MenuName="";
                String  Type="";
                String  Introduce="";
                String  CoverImg="";
                String  Collection="";
                String  Account="";
               
                String  Tips="";
                String  MenuMainIngredient="";
                String  MenuFuliao="";
                String  MenuGY="";
                String  MenuKW="";
                String  MenuSteps="";
                String  TimeMade="";
                String  status="";
                String  MenuND = "";

                IList<UserProductions> Lists;
                Lists = bll.GetSingleUserMenu(MenuNumber);

                foreach (UserProductions l in Lists) {
                    MenuName = l.MenuName;
                    Type = l.Type;
                    Introduce = l.Introduce;
                    CoverImg = l.CoverImg;
                    Collection = l.Collection;
                    Account = l.Account;

                    Tips = l.Tips;
                    MenuMainIngredient = l.MenuMainIngredient;
                    MenuFuliao = l.MenuFuliao;
                    MenuGY = l.MenuGY;
                    MenuKW = l.MenuKW;
                    MenuSteps = l.MenuSteps;
                    TimeMade = l.TimeMade;
                    status = l.status;
                    MenuND = l.MenuND;



                }
                strret = "MenuName:" + MenuName + "，Type:" + Type + "，Introduce:" + Introduce + "，CoverImg:" + CoverImg + "，Tips:" + Tips + "，MenuMainIngredient:" + MenuMainIngredient;
                strret += "，MenuFuliao:" + MenuFuliao + "，MenuGY:" + MenuGY + "，MenuKW:" + MenuKW + "，MenuSteps:" + MenuSteps;
              //  strret=" { 'Menu' :[ {  'MenuName' :"+MenuName+",  'Type' :"+Type+",  'Introduce' :"+Introduce+",  'CoverImg' :"+CoverImg+",  'Tips' :"+Tips+",  'MenuMainIngredient' :"+MenuMainIngredient+", 'MenuSteps' :"+MenuSteps+"} ]";

  
             
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户收藏的菜谱 
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserMenuCollection")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);

                if (actype == "pre" && (OldPageindex == "0" || OldPageindex == "-1"))
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k == -1)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<UserCollections> Lists;
                double Size = 4.0;
                String tablename = "usercollectionview";
                String bywhat = "Account='" + Account + "'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);

                Lists = bll.GetUserMenuCollection(Account, (Int32)Size, dataindex);

                String strhead = HtmlCreate.CreateHeadImage("UserCollection", datacount.ToString(), Account);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    //strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, NewPages, "follow", actype);
                    strret = HtmlCreate.CreateUserMenuCollectionImage(Lists, pageindex, NewPages, actype, "yhcp");

                else
                    strret = HtmlCreate.CreateUserMenuCollectionImage(Lists, pageindex, Int32.Parse(OldPages), actype, "yhcp");



                strret = strhead + strret;

                

              
                 
               
             
                context.Response.Write(strret);
                return;
            }
            #endregion  

             
             #region 获取作者列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "getEditorListB")
            {
                String strret = "";
                String Account = "";
                String pages = Convert.ToString(context.Request.QueryString["indpages"]);
                String size2 = Convert.ToString(context.Request.QueryString["size"]); 
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);

                if(context.Session["useraccount"]!=null){
                    Account = (context.Session["useraccount"]).ToString();
                }
                 
                IList<User> Lists;
                double Size = 4.0;

                if (size2 == "4") {
                    Size = 4.0;
                }else if (size2 == "8") {
                    Size = 8.0;
                }
                String tablename = "user";
                String bywhat = "";
                if (size2 == "4")
                {
                    orderby = "Order by ObjectFNum desc";
                    Lists = bll.GetEditorList(orderby, bywhat, (Int32)Size, "0");
                }
                else {

                    if (orderby == "id")
                    {
                        orderby = "Order by Id asc";
                    }
                    else if (orderby == "orderbygzd")
                    {
                        orderby = "Order by ObjectFNum desc";
                    }
                    else
                    {
                        orderby = "Order by ObjectNumber desc";
                    }
                    int dataindex = Int32.Parse(((Int32.Parse(pages)-1)*Size).ToString());
                    Lists = bll.GetEditorList(orderby, bywhat, (Int32)Size, dataindex.ToString());
                
                }
                
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());


                strret = HtmlCreate.CreateEditorImage(Lists, Account);


                strret = strret + "|" + NewPages;
                 
                     
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取作者列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "getEditorList")
            {
                String strret = "";
                String Account = "";
                String pages = Convert.ToString(context.Request.QueryString["pages"]);
                String size2 = Convert.ToString(context.Request.QueryString["size"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);
                if(context.Session["useraccount"]!=null){
                    Account = (context.Session["useraccount"]).ToString();
                }
                 
                IList<User> Lists;
                double Size = 4.0;

                if (size2 == "4") {
                    Size = 4.0;
                }else if (size2 == "8") {
                    Size = 8.0;
                }
                String tablename = "user";
                String bywhat = "";
                if (size2 == "4")
                {
                    orderby = "Order by FollowersNum desc";
                    Lists = bll.GetEditorList(orderby, bywhat, (Int32)Size, "0");
                }
                else {

                    if (orderby == "orderbydj")
                    {
                        orderby = "Order by FollowersNum asc";
                    }
                    else if (orderby == "orderbygzd")
                    {
                        orderby = "Order by FollowersNum desc";
                    }
                    else
                    {
                        orderby = "Order by FollowersNum desc";
                    }
                    int dataindex = 0;
                    Lists = bll.GetEditorList(orderby, bywhat, (Int32)Size, dataindex.ToString());
                
                }
                
                
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());


                strret = HtmlCreate.CreateEditorImage(Lists, Account);
                     
                
                
                 
                     
                context.Response.Write(strret);
                return;
            }
            #endregion  

         
            #region 获取陌生用户列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "getStrangerListB")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String Pageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);

                String size = Convert.ToString(context.Request.QueryString["size"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);


                IList<User> Lists;
                double Size = 8.0;
              
                String tablename = "user";
                //计算当前页面数
                // select  * from user where Account not in (select ObjectNumber from usercollection  where Account='jrx111925' 
                //and  (CollectionType='userfriend' or CollectionType='userfollow'))  and Account <> 'jrx111925'
                String bywhat = " Account not in (select ObjectNumber from usercollection  where Account='" + Account + "'";
                bywhat += "and  (CollectionType='userfriend' or CollectionType='userfollow'))  and Account <> '" + Account + "'";
                //" Account='" + Account+"'";
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());
                if (orderby == "orderbyid")
                {
                    orderby = "Order by Id asc";
                }
                else if (orderby == "orderbygzd")
                {
                    orderby = "Order by FollowersNum desc";
                }
                else
                {
                    orderby = "Order by Account desc";
                }
                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(Pageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getStrangerList(orderby, Account, (Int32)Size, dataindex);
                //如果数据页数改变

                strret = HtmlCreate.CreateEditorImage3(Lists);
                strret = strret + "|" + NewPages;
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户关注的用户
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserPersonFollowB")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String Pageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
               
                String size = Convert.ToString(context.Request.QueryString["size"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);


                IList<UserFollows> Lists;
                double Size = 8.0;
                String tablename = "userfollowview";
                String bywhat = " Account='"+Account+"' and CollectionType='userfollow'";
                String bywhat2 = "where Account='" + Account + "' and CollectionType='userfollow'";
                
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(Pageindex);
                int dataindex = (Int32)Size * (pageindex - 1);

                if (orderby == "orderbyid")
                {
                    orderby = "Order by ObjectLevel asc";
                }
                else if (orderby == "orderbygzd")
                {
                    orderby = "Order by ObjectFNum desc";
                }
                else {
                    orderby = "Order by ObjectNumber desc";
                }
                Lists = bll.GetUserPersonFollow(orderby, Account, (Int32)Size, dataindex);

                strret = HtmlCreate.CreateEditorImage2(Lists);

                strret = strret + "|" + NewPages;
                context.Response.Write(strret);
                return;
            }
            #endregion  


            #region 获取用户关注的用户
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserPersonFollow")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);

                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);

                if (actype == "pre" && (OldPageindex == "0" || OldPageindex == "-1"))
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k == -1)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<UserFollows> Lists;
                double Size = 8.0;
                String tablename = "userfollowview";
                String bywhat = "Account='"+Account+"' and CollectionType='userfollow'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);

                if (orderby == "orderbydj")
                {
                    orderby = "Order by ObjectLevel asc";
                }
                else if (orderby == "orderbygzd")
                {
                    orderby = "Order by ObjectFNum desc";
                }
                else {
                    orderby = "Order by ObjectNumber desc";
                }
                Lists = bll.GetUserPersonFollow(orderby,Account, (Int32)Size, dataindex);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, NewPages, "follow", actype);
                     
                else
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, Int32.Parse(OldPages), "follow", actype);
                     
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户制作的菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserProduction")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);

                if (actype == "pre" && (OldPageindex == "0" || OldPageindex == "-1"))
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k == -1)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<UserProductions> Lists;
                double Size = 4.0;
                String tablename = "userproduction";
                String bywhat = "Account='" + Account + "'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                if (datacount == 0)
                {
                    String  nstrhead = HtmlCreate.UserDetailDataNone("UserProduction", Account);
                   String  retstrbottom =HtmlCreate.getDataBottomimage("getUserProduction", 1, 1, "0");
                    strret += " <div class='usernonedata'> </div>";

                    strret = nstrhead + strret + retstrbottom;
                    context.Response.Write(strret);
                    return;
                }
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);

                Lists = bll.GetUserProduction(Account, (Int32)Size, dataindex);

                String strhead = HtmlCreate.CreateHeadImage("UserProduction", datacount.ToString(), Account);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    //strret = HtmlCreate.CreateUserPersonFollowImage(Lists, pageindex, NewPages, "follow", actype);
                     strret = HtmlCreate.CreateUserProductionImage(Lists, pageindex, NewPages, actype);

                else
                    strret = HtmlCreate.CreateUserProductionImage(Lists, pageindex, Int32.Parse(OldPages), actype);



                strret = strhead + strret;
                 
                
                
              
                context.Response.Write(strret);
                return;
            }
            #endregion  
             #region 获取陌生用户列表 
            if (Convert.ToString(context.Request.QueryString["type"]) == "getStrangerList")
            {
                String strret = "";
                
                String Account = (context.Session["useraccount"]).ToString();
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);
                if (actype == "pre" && OldPageindex == "0")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k<0)
                {
                    context.Response.Write(strret);
                    return;
                }
                 IList<User> Lists;
                double Size = 8.0;
                 String tablename = "user";
                //计算当前页面数
                // select  * from user where Account not in (select ObjectNumber from usercollection  where Account='jrx111925' 
               //and  (CollectionType='userfriend' or CollectionType='userfollow'))  and Account <> 'jrx111925'
                 String bywhat = " Account not in (select ObjectNumber from usercollection  where Account='"+Account+"'";
                 bywhat += "and  (CollectionType='userfriend' or CollectionType='userfollow'))  and Account <> '"+Account+"'";
                    //" Account='" + Account+"'";
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());
                if (orderby == "orderbydj")
                {
                    orderby = "Order by UserLevel asc";
                }
                else if (orderby == "orderbygzd")
                {
                    orderby = "Order by FollowersNum desc";
                }
                else
                {
                    orderby = "Order by Account desc";
                }
                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.getStrangerList(orderby,Account, (Int32)Size, dataindex);
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 ||Int32.Parse(OldPages)!= NewPages)
                    strret = HtmlCreate.getStrangerListimage(Lists, pageindex, NewPages,actype);
                else
                    strret = HtmlCreate.getStrangerListimage(Lists, pageindex, Int32.Parse(OldPages),actype); 
                context.Response.Write(strret);
                return;
            }
            #endregion  
              #region 用户评论 
            if (Convert.ToString(context.Request.QueryString["type"]) == "Comment")
            {
                String strret = "";
               
                String Account = (context.Session["useraccount"]).ToString();
                String Ctype = Convert.ToString(context.Request.QueryString["Ctype"]);
                String Comment = Convert.ToString(context.Request.QueryString["Comment"]);
                String Obnumber = Convert.ToString(context.Request.QueryString["Obnumber"]);
                String picture ="none"; 
                String commentcount = Convert.ToString(context.Request.QueryString["commentcount"]);
                String   CommentNumber="";
                if(Ctype=="回复"){
                     CommentNumber=(Int32.Parse(Obnumber+"00100")+commentcount).ToString();
                }else{
                      CommentNumber=(Int32.Parse(Obnumber+"0")+commentcount).ToString();
                }

                int r = bll.usercomment(Account,Ctype,Comment,Obnumber,picture,CommentNumber);
                context.Response.Write(strret);
                return;
            }
            #endregion  
       

              #region//获取基本菜谱信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "getbasic")
            {
                String kw = "";
                String gy = "";
               // String sc = "";
                String type = "";
               // String sql = "";
             //  sql = "select * from menu_classification where Category_parent='口味'";
                BLLclassification bllc=new BLLclassification();
                IList<Classification> l = bllc.GetClassificationList("口味");
                kw += "<div class='claitem'><p class='clatitle'>口味</p>";
                foreach(Classification q in l){
                    kw += "<p class='cla' onclick='setval(&quot;kw&quot;,&quot;" + q.Classification_contents + "&quot;)'>" + q.Classification_contents + "</p>";
                }
                kw += "</div>";

                 l = bllc.GetClassificationList("制作工艺");
                 gy += "<div class='claitem'><p class='clatitle'>制作工艺</p>";
                 foreach (Classification q in l)
                 {
                     gy += "<p class='cla' onclick='setval(&quot;gy&quot;,&quot;" + q.Classification_contents + "&quot;)'>" + q.Classification_contents + "</p>";
                 }
                 gy += "</div>";
                
                 //type = "<div class='clat' >";
                 //type = "<div class='clatnav'><p>菜系</p><p>家常菜谱</p><p>各地小吃</p></div>";
                 l = bllc.GetClassificationListBywhat(" Category_parent like '%菜系%'");
                 type += "<div class='claitem'><p class='clatitle'>菜系</p>";
                 foreach (Classification q in l)
                 {
                     type += "<p class='cla' onclick='setval(&quot;type&quot;,&quot;" + q.Classification_contents + "&quot;)'>" + q.Classification_contents + "</p>";
                 }
                 type += "</div>";
                //家常菜谱，各地小吃
                 l = bllc.GetClassificationList("家常菜谱");
                 type += "<div class='claitem'><p class='clatitle'>家常菜谱</p>";
                 foreach (Classification q in l)
                 {
                     type += "<p class='cla' onclick='setval(&quot;type&quot;,&quot;" + q.Classification_contents + "&quot;)'>" + q.Classification_contents + "</p>";
                 }
                 type += "</div>";
                 //家常菜谱，各地小吃
                 l = bllc.GetClassificationList("各地小吃");
                 type += "<div class='claitem'><p class='clatitle'>各地小吃</p>";
                 foreach (Classification q in l)
                 {
                     type += "<p class='cla' onclick='setval(&quot;type&quot;,&quot;" + q.Classification_contents + "&quot;)'>" + q.Classification_contents + "</p>";
                 }
                 type += "</div>";
                //String twp="";
                //l = bllc.GetClassificationList("调味品");
                // twp += "<div class='claitem'><p class='clatitle'>调味品</p>";
                // foreach (Classification q in l)
                // {
                    
                     
                //         twp += "<p class='cla'>" +q.Classification_contents + "</p>";
                     
                  
                // }
                //   twp += "</div>";
                

                String mainsc="";
                l = bllc.GetClassificationList("食材大全");
                foreach (Classification q in l)
                 {
                     mainsc += "<div class='claitem'><p class='clatitle'>" + q.Classification_contents + "</p>";
                     IList<Classification> l2 = bllc.GetClassificationList(q.Classification_contents);
                     foreach (Classification w in l2)
                     {
                         mainsc += "<p class='cla' onclick='setval(&quot;mainsc&quot;,&quot;" + w.Classification_contents + "&quot;)'>" + w.Classification_contents + "</p>";
                     }
                     mainsc += "</div>";
                 }
                String fl = "";
                l = bllc.GetClassificationList("食材大全");
                foreach (Classification q in l)
                {
                    fl += "<div class='claitem'><p class='clatitle'>" + q.Classification_contents + "</p>";
                    IList<Classification> l2 = bllc.GetClassificationList(q.Classification_contents);
                    foreach (Classification w in l2)
                    {
                        fl += "<p class='cla' onclick='setval(&quot;fl&quot;,&quot;" + w.Classification_contents + "&quot;)'>" + w.Classification_contents + "</p>";
                    }
                    fl += "</div>";
                }
                 //l=bllc.GetClassificationListBywhat("number not in (10341,10357)");

               // String fl="";
                // l=bllc.GetClassificationListBywhat("number in (10341,10357)");
                // l = bllc.GetClassificationList("食材大全");



                String ss = kw + "$" + gy + "$" + mainsc + "$" + type + "$" + fl;//
                //string foodpicture = Convert.ToString(context.Request.QueryString["foodmaterials"]);
                 context.Response.Write(ss);
                 return;       
            }            
           #endregion


              #region//用户制作菜品步骤
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductionSteps")
            {
                String Account = (context.Session["useraccount"]).ToString();
                String Username = (context.Session["username"]).ToString();
               
                
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
               
                string bzall = Convert.ToString(context.Request.QueryString["bzall"]);


              //  int i = bll.UpdateUserProductionSteps(menunumber, bzall);

               context.Response.Write("success");
                return;
            }
            #endregion
          
            #region//用户制作菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProduction")
            {
                String Account = (context.Session["useraccount"]).ToString();
                String Username = (context.Session["username"]).ToString();
                string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                string kw = Convert.ToString(context.Request.QueryString["kw"]);
                string gy = Convert.ToString(context.Request.QueryString["gy"]);
                string menutype = Convert.ToString(context.Request.QueryString["menutype"]);
                string mainsc = Convert.ToString(context.Request.QueryString["mainsc"]);
                string fl = Convert.ToString(context.Request.QueryString["fl"]);
                string introduce = Convert.ToString(context.Request.QueryString["introduce"]);
                string Tips = Convert.ToString(context.Request.QueryString["Tips"]);
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                string menuimg = Convert.ToString(context.Request.QueryString["menuimg"]);
                string bzall = Convert.ToString(context.Request.QueryString["bzall"]);
                string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04

                String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你制作了" + menuname;
                String actitle = "制作  " + menuname;
                String ctype = "madeMenu";
                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                //修改表中单个属性值]\
                String hh = (context.Session["allproductionnum"]).ToString();
                 int allproductionnum = Int32.Parse((context.Session["allproductionnum"]).ToString());
                allproductionnum++;
                 String val= allproductionnum.ToString();
                        
                int r = bll.AlterSingleAttr("User","AllProductionNum",val," where Account='"+Account+"'");


                int experience = Int32.Parse((context.Session["experience"]).ToString());
                experience = experience + 100;
                  val = (experience).ToString();

                  int r2 = bll.AlterSingleAttr("User", "Experience", val, " where Account='" + Account + "'");
               

                BLLuser blluser = new BLLuser();
                int k = blluser.FoodProduction(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall, TimeMade); 
                context.Response.Write("success");
                return;
            }
            #endregion

            #region //用户编辑已有菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductionUpdate")
            {
                String Account = (context.Session["useraccount"]).ToString();
                string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                string kw = Convert.ToString(context.Request.QueryString["kw"]);
                string gy = Convert.ToString(context.Request.QueryString["gy"]);
                string menutype = Convert.ToString(context.Request.QueryString["menutype"]);
                string mainsc = Convert.ToString(context.Request.QueryString["mainsc"]);
                string fl = Convert.ToString(context.Request.QueryString["fl"]);
                string introduce = Convert.ToString(context.Request.QueryString["introduce"]);
                string Tips = Convert.ToString(context.Request.QueryString["Tips"]);
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                string menuimg = Convert.ToString(context.Request.QueryString["menuimg"]);
                string bzall = Convert.ToString(context.Request.QueryString["bzall"]);
                string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你修改了" + menuname;
                String actitle = "修改  " + menuname;
                String ctype = "alterMenu";
                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                BLLuser blluser = new BLLuser();
                int k = blluser.FoodProductionUpdate(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall); 
                context.Response.Write("success");
                return;
            }
            #endregion  
           
            #region//修改用户名
            if (Convert.ToString(context.Request.QueryString["type"]) == "altername")
            {
              //  string altertable = "";
                //string alterAttri = "";
               // string  val = "";
              //  string bywhatAttri = "";
              //  string bywhatval = "";
                string username = Convert.ToString(context.Request.QueryString["username"]);
                context.Session["username"] = username;
                String Account = (context.Session["useraccount"]).ToString();

                BLLuser blluser = new BLLuser();
                

                    string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                    String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                    String content = "你修改了自己的用户名";
                    String actitle = "修改用户名" ;
                    String ctype = "altername";
                    int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                 
                     int r2 = bll.AlterSingleAttr("User", "UserName", username, " where Account='" + Account + "'");
                    context.Response.Write("yes");
                    return;
                
            }
            #endregion 
           
            #region//删除作品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductiondel")
            {
                string userfoodnumber = Convert.ToString(context.Request.QueryString["userfoodnumber"]);
                string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                String Account = (context.Session["useraccount"]).ToString();

                BLLuser blluser = new BLLuser();
                int r = blluser.UserProductionDel(userfoodnumber);
                if (r == 0)
                {
                }
                else
                {

                    string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                    String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                    String content = "你删除了" + menuname;
                    String actitle = "删除  " + menuname;
                    String ctype = "deleteMenu";
                    int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                    string pa = "~/images/userproduction/" + Account + "/" + userfoodnumber +"/";
                    string ff = context.Request.MapPath(pa);
                     //if (File.Exists(ff))  {  
                     //    // 是文件 

                     //}
                     if (Directory.Exists(ff)) { 
                         // 是文件夹
                         Directory.Delete(ff,true);
                     }
                     else  {   
                         // 都不是 
                     }
                     int allproductionnum = Int32.Parse((context.Session["allproductionnum"]).ToString());
                    allproductionnum--;
                     String val = allproductionnum.ToString();
                     context.Session["allproductionnum"] = val;
                     int r2 = bll.AlterSingleAttr("User", "AllProductionNum", val, " where Account='" + Account + "'");
                    context.Response.Write("yes");
                    return;
                }
            }
            #endregion 


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