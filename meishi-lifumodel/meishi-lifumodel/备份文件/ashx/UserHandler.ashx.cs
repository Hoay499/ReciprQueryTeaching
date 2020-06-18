using meishi_lifumodel.BLL;
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

            #region  判断用户是否已存在
             if (context.Request.QueryString["type"] == "checkusername")
             {
                 string username = context.Request.QueryString["username"];
                  
                 BLL.BLLuser bll = new BLL.BLLuser();
                 int r1 = bll.GetUserCount(username, "UserName");
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
                  
                 BLL.BLLuser bll = new BLL.BLLuser();
                 int r1 = bll.GetUserCount(account,"Account");
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

                 BLL.BLLuser bll = new BLL.BLLuser();
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
                       // context.Session["userimg"] =userinfo.UserImg.ToString();
                       // HttpContext.Current.Session["username"] = a;
                     }
                      context.Response.Write("success");
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
                

                int r = blluser.UserRegister(username, Pword,Account);
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

            #region 收藏菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "Collect")
            {
                String flag ="notok";
               // string MenuNumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                String useraccount= (context.Session["useraccount"]).ToString();
                String menunumber = (context.Session["MenuNumber"]).ToString();
                //string Collection = Convert.ToString(context.Request.QueryString["Collection"]);

                string Collection = (context.Session["CollectionNumber"]).ToString();
                int collection = int.Parse(Collection);
                string strret = "";
                string sclx = "菜单收藏";//收藏类型
                collection++;
                Collection = collection.ToString();

                BLLuser blluser = new BLLuser();
                int r = blluser.Collect(sclx, useraccount, menunumber, Collection);//收藏菜单

                if (r > 0)
                {
                    flag = "ok";
                   
                }

                context.Response.Write(flag);
                return;
            
            
            }

            #endregion

            #region 取消收藏菜谱
            #endregion

            #region 获取用户历史足迹
            if (Convert.ToString(context.Request.QueryString["type"]) == "getHistoricalRecord")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();

                IList<usernotices> Lists = bll.getHistoricalRecord(Account);
                strret = ex.getHistoricalRecordimage(Lists);
                context.Response.Write(strret);
                return;
            }
            #endregion  
            
            #region 获取用户新的提示
            if (Convert.ToString(context.Request.QueryString["type"]) == "getNewNotice")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();

                IList<usernotices> Lists = bll.getNewNotice(Account);
                strret = ex.getNewNoticeimage(Lists);
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户收藏的菜谱 
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserMenuCollection")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                int Size =10;
                string sclx = "菜单收藏";//收藏类型
                // BLLmenu bllmenu = new BLLmenu();
                 IList<UserCollections> Lists = bll.GetUserMenuCollection( Account, Size);
                if (Lists.Count() != 0)
                {
                    strret = HtmlCreate.CreateUserMenuCollectionImage(Lists);
                }
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户关注的用户
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserPersonFollow")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                int Size = 10;
                string sclx = "菜单收藏";//收藏类型
                
                IList<UserCollections> Lists = bll.GetUserPersonFollow( Account, Size);
                if (Lists.Count() != 0)
                {
                    strret = HtmlCreate.CreateUserPersonFollowImage(Lists);
                }
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取用户制作的菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserProduction")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                int Size = 10;
                IList<UserProductions> Lists = bll.GetUserProduction(Account, Size);
                strret = HtmlCreate.CreateUserProductionImage(Lists);
                context.Response.Write(strret);
                return;
            }
            #endregion  
             #region 获取陌生用户列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "getStrangerList")
            {
                String strret = "";
                String Account = (context.Session["useraccount"]).ToString();
                IList<usernotices> Lists = bll.getNewNotice(Account);


                strret = ex.getStrangerListimage(Lists);
                context.Response.Write(strret);
                return;
            }
            #endregion  
           
            #region 旧的收藏
            if (Convert.ToString(context.Request.QueryString["type"]) == "Collect")//得到新秀菜谱列表
            {
                //string strret = mycommonClassobj.createListImage("http://" + context.Request.Url.Authority.ToString());
                //context.Response.Write(strret);
                string MenuNumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                string UserNumber = Convert.ToString(context.Request.QueryString["usernumber"]);
                string Collection = Convert.ToString(context.Request.QueryString["Collection"]);
                int collection=int.Parse(Collection);
                string strret = "";
               
                //string CollectionNumber=
                
                BLLuser blluser = new BLLuser();
                string sclx = "菜单收藏";//收藏类型
                int r1 = blluser.Collectcount(UserNumber, MenuNumber);//判断是否已收藏
                if (r1 == 0)
                {
                    collection++;
                    Collection=collection.ToString();
                    
                    int r = blluser.Collect(sclx, UserNumber, MenuNumber,Collection);//收藏菜单

                    if (r > 0)
                    {
                        strret = "<p class='scl'> 收藏量：" + Collection + "</p>";
                        context.Response.Write(strret);
                        return;
                    }
                    
                    
                }
                else
                {
                    collection--;
                    Collection = collection.ToString();
                    int r = blluser.CollectDel(UserNumber, MenuNumber, Collection);//取消收藏菜单

                    if (r > 0)
                    {
                        strret = "<p class='scl'> 收藏量：" + Collection + "</p>";
                    }
                    context.Response.Write(strret);
                    return;
                }
                    
               
            }
           #endregion

        

            #region//用户制作菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "FoodProduction")
            { 
                string foodname = Convert.ToString(context.Request.QueryString["foodname"]);
                string UserNumber = Convert.ToString(context.Request.QueryString["usernumber"]);
                string foodmaterials =Convert.ToString(context.Request.QueryString["foodmaterials"]);
                string foodtype = Convert.ToString(context.Request.QueryString["foodtype"]);
                string foodintroduce = Convert.ToString(context.Request.QueryString["foodintroduce"]);
                
                BLLuser blluser = new BLLuser();
                int number = blluser.GetUserFoodProductionCount(UserNumber);

                string foodnumber = "1"+UserNumber+number.ToString();
                int r = blluser.FoodProduction(foodintroduce,foodmaterials,foodname,foodtype,UserNumber,foodnumber);
                if (r == 0)
                {
                    context.Response.Write("fail");
                    return;
                }
                else
                {
                    context.Response.Write("success");
                    return;
                }
                //string foodpicture = Convert.ToString(context.Request.QueryString["foodmaterials"]);
            
            }
           #endregion

            #region //查看用户制作菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "getUserMenu")
            {
                int Size = Convert.ToInt32(Convert.ToString(context.Request.QueryString["Size"]));
                string MenuNumber = Convert.ToString(context.Request.QueryString["MenuNumber"]);
                //string UserNumber = Convert.ToString(context.Request.QueryString["UserNumber"]);
                //string UserAccout = (context.Session["useraccount"]).ToString();
                string UserNumber = "1001";
                if (MenuNumber == "")
                {
                    myoperateClass ex = new myoperateClass();
                    String strret = ex.createUserProductionImage(UserNumber, Size);
                    context.Response.Write(strret);
                    return;
                }
                else {
                    BLLuser blluser = new BLLuser();

                    IList<UserProductions> menus = blluser.GetUserSingleProduction(UserNumber,MenuNumber);

                    string retstr = "<script>";
                    retstr+=" var foodname = document.getElementById('name');";
                    retstr += " var foodmaterials = document.getElementById('sc');";
                    retstr += " var foodintroduce = document.getElementById('introduce');";
                    retstr += " var foodtype = document.getElementById('type');";
                   // retstr += " var foodname = document.getElementById('foodnumber')";
                     //  var foodpicture = result;
                    retstr +="foodname.value = '"+menus[0].FoodName+"';";
                    retstr +="foodmaterials.value = '"+menus[0].FoodMatrials+"';";
                    retstr +="foodtype.value = '"+menus[0].FoodType+"';";
                    retstr +="foodintroduce.value = '"+menus[0].FoodIntroduce+"';";
                   // retstr += "foodnumber.value = '" + menus[0].UserFoodNumber+ "'";
                    retstr+="</script>";
                    context.Response.Write(retstr);
                    return;
                }
              
                //string foodpicture = Convert.ToString(context.Request.QueryString["foodmaterials"]);

            }
            #endregion 

            #region //用户编辑已有菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == " UserProductionedit")
            {
                string foodname = Convert.ToString(context.Request.QueryString["foodname"]);
                string UserNumber = Convert.ToString(context.Request.QueryString["usernumber"]);
                string foodmaterials = Convert.ToString(context.Request.QueryString["foodmaterials"]);
                string foodtype = Convert.ToString(context.Request.QueryString["foodtype"]);
                string foodintroduce = Convert.ToString(context.Request.QueryString["foodintroduce"]);
                string foodnumber = Convert.ToString(context.Request.QueryString["foodnumber"]);
              //  string foodimg = Convert.ToString(context.Request.QueryString["usernumber"]);
                string foodimg = "";
                BLLuser blluser = new BLLuser();
                int r = blluser.FoodProductionedit(foodintroduce, foodmaterials, foodname, foodtype, UserNumber, foodnumber,foodimg);
                String strret ="";
                context.Response.Write(strret);
                return;
                //string foodpicture = Convert.ToString(context.Request.QueryString["foodmaterials"]);

            }
            #endregion  

            #region//删除作品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductiondel")
            {
                string userfoodnumber = Convert.ToString(context.Request.QueryString["userfoodnumber"]);
                BLLuser blluser = new BLLuser();
                int r = blluser.UserProductionDel(userfoodnumber);
                if (r == 0)
                {
                }
                else {
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