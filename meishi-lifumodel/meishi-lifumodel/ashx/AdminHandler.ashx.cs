using meishi_lifumodel.BLL;
using meishi_lifumodel.DBHelper;
using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace meishi_lifumodel.Frontdesk.ashx
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class AdminHandler : IHttpHandler,IRequiresSessionState
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
                    
                   result +="<img  src="+userimg+" /> ";
                   if (datacount == 0)
                   {
                       result += " <p id='wdxxjls'>" + username + "</p>";
                       result += " <p id='wdxxjls2' onclick='logout()'>退出登录</p>";
                   }
                   else {
                       result += " <p id='wdxxjls'>共有" + datacount + "条信息未读</p>";
                   }
                      
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


               // int r = blluser.UserRegister(username, Pword, Account, actime);
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

            
            #region 获取数据table
            if (Convert.ToString(context.Request.QueryString["type"]) == "getMenuList")
            {
                String strret = "";
                //String Account = (context.Session["useraccount"]).ToString();
                String pageindex = Convert.ToString(context.Request.QueryString["pageindex"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]); 
                String datatype = Convert.ToString(context.Request.QueryString["datatype"]);
               
                
                //String bywhat = " Account='" + Account + "'";
                double Size = 6.0;
               
                String tablename = "";
                String bywhat = "";

                if (datatype == "user") {
                    tablename = "user";

                } else if (datatype=="sc") {
                    tablename = "ingredient";
                }  else if (datatype == "cp")  {
                    tablename = "menualldetails";
                }  else if (datatype == "class") {
                    tablename = "menu_classification";
                } 
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int ind = Int32.Parse(pageindex);
                int dataindex = (Int32)Size * (ind - 1);


                //复制ashx后断点进入原来的ashx文件：文件右键修改标记
                string head = "";
                if (datatype == "user")
                { 
                    var properties = typeof(User).GetProperties();
                    foreach (System.Reflection.PropertyInfo info in properties)
                    {
                        head =head+info.Name+",";
                    }
                    head = head.Substring(0, head.Length - 1);
                    head += "|";
                    IList<User> Lists = bll.GetUserList(orderby, (Int32)Size, dataindex);
                    foreach(User i in Lists){
                           foreach (PropertyInfo pro in properties)
                          {  
                             string h=  (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                             strret = strret+h+",";
                          }
                           strret = strret.Substring(0, strret.Length - 1);
                           strret += "$";

                    }
                    strret = strret.Substring(0, strret.Length - 1);
                    strret = head + strret;
                }
                else if (datatype == "sc")
                {
                    //tablename = "ingredient";
                    var properties = typeof(Ingredient).GetProperties();
                    foreach (System.Reflection.PropertyInfo info in properties)
                    {
                        head = head + info.Name + ",";
                    }
                    head = head.Substring(0, head.Length - 1);
                    head += "|";
                    IList<Ingredient> Lists = bll.GetIngredientList(orderby, (Int32)Size, dataindex);
                    foreach (Ingredient i in Lists)
                    {
                        foreach (PropertyInfo pro in properties)
                        {
                            string h = (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                            strret = strret + h + ",";
                            
                        }
                        strret = strret.Substring(0, strret.Length - 1);
                        strret += "$";
                    }
                    strret = strret.Substring(0, strret.Length - 1);
                    strret = head + strret;
                }
                else if (datatype == "cp")
                {
                    //tablename = "menualldetials";
                    var properties = typeof(MenuAll).GetProperties();
                    foreach (System.Reflection.PropertyInfo info in properties)
                    {
                        head = head + info.Name + ",";
                    }
                    head = head.Substring(0, head.Length - 1);
                    head += "|";
                    IList<MenuAll> Lists = bll.GetMenuAllList(orderby, (Int32)Size, dataindex);
                    foreach (MenuAll i in Lists)
                    {
                        foreach (PropertyInfo pro in properties)
                        {
                            string h ="";
                            if(pro.Name=="MenuFuliao"){
                                strret = strret + "MenuFuliao" + ",";
                            }else if(pro.Name=="MenuMainIngredient"){
                                strret = strret + "MenuMainIngredient" + ",";
                            }else if(pro.Name=="MenuMainIngredient"){
                                strret = strret + "MenuMainIngredient" + ",";
                            }else if(pro.Name=="MenuSteps"){
                                strret = strret + "MenuSteps" + ",";
                            }else if(pro.Name=="Positives"){
                             strret = strret +"Positives" + ",";
                            }else if (pro.Name == "CoverImg")
                            {
                                strret = strret + "CoverImg" + ",";
                            } else {
                                h = (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                                strret = strret + h + ",";
                            } 
                        }
                        strret = strret.Substring(0, strret.Length - 1);
                        strret += "$";
                    }
                    strret = strret.Substring(0, strret.Length - 1);
                    strret = head + strret;
                }
                else if (datatype == "class")
                {
                   // tablename = "menu_classification";
                    var properties = typeof(Classification).GetProperties();
                    foreach (System.Reflection.PropertyInfo info in properties)
                    {
                        head = head + info.Name + ",";
                    }
                    head = head.Substring(0, head.Length - 1);
                    head += "|";
                    IList<Classification> Lists = bll.GetClassificationList(orderby, (Int32)Size, dataindex);
                    foreach (Classification i in Lists)
                    {
                        foreach (PropertyInfo pro in properties)
                        {
                            string h = (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                            strret = strret + h + ",";
                        }
                        strret = strret.Substring(0, strret.Length - 1);
                        strret += "$";
                    }
                    strret = strret.Substring(0, strret.Length - 1);
                    strret = head + strret;
                } 
               // Lists = bll.getHistoricalRecord(tablename, (Int32)Size, dataindex);
                //如果数据页数改变

                strret = strret + "|" + datacount;


                context.Response.Write(strret);
                return;
            }
            #endregion
            #region //用户编辑已有菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductionUpdate")
            {
                String Account = (context.Session["useraccount"]).ToString();
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);



                string menuimg = Convert.ToString(context.Request.QueryString["menuimg"]);
                string menuname = Convert.ToString(context.Request.QueryString["menuname"]); 
                string menutype = Convert.ToString(context.Request.QueryString["menutype"]);
                string introduce = Convert.ToString(context.Request.QueryString["introduce"]);
                string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04


                string Tips = Convert.ToString(context.Request.QueryString["Tips"]);
                string kw = Convert.ToString(context.Request.QueryString["kw"]);
                string gy = Convert.ToString(context.Request.QueryString["gy"]);
                string mainsc = Convert.ToString(context.Request.QueryString["mainsc"]);
                string fl = Convert.ToString(context.Request.QueryString["fl"]);
                string bzall = Convert.ToString(context.Request.QueryString["bzall"]);
               
                String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                String content = "你修改了" + menuname;
                String actitle = "修改  " + menuname;
                String ctype = "alterMenu";
                int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                BLLuser blluser = new BLLuser();
                
                int k2 = blluser.MenuUpdate(menunumber, menuname, menutype, menuimg, Account);

                int k = blluser.MenuUpdate2(menunumber, mainsc, fl, gy, kw, Tips);


                context.Response.Write("success");
                return;
            }
            #endregion  
            #region 加载用户单个菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "getSingleUserMenu")
            {
                String strret = "";

                String MenuNumber = Convert.ToString(context.Request.QueryString["MenuNumber"]);


                String MenuName = "";
                String Type = "";
                String Introduce = "";
                String CoverImg = "";
                String Collection = "";
                String Account = "";

                String Tips = "";
                String MenuMainIngredient = "";
                String MenuFuliao = "";
                String MenuGY = "";
                String MenuKW = "";
                String MenuSteps = "";
                String TimeMade = "";
                String status = "";
                String MenuND = "";

               // IList<UserProductions> Lists;
              //  Lists = bll.GetSingleUserMenu(MenuNumber);
                BLL.BLLmenu bll2 = new BLL.BLLmenu();
                IList<MenuAll> Lists = bll2.GetSingleMenu(MenuNumber);
                foreach (MenuAll l in Lists)
                {
                    MenuName = l.MenuName;
                    Type = l.Type;
                    Introduce = l.Introduces;
                    CoverImg = l.CoverImg;
                    Collection = l.Collection;
                    Account = l.ProducerNumber;

                    Tips = l.MenuTips;
                    MenuMainIngredient = l.MenuMainIngredient;
                    MenuFuliao = l.MenuFuliao;
                    MenuGY = l.MenuGY;
                    MenuKW = l.MenuKW;
                    MenuSteps = l.MenuSteps;
                    TimeMade = l.TimeMade;
                    status = l.Status;
                    MenuND = l.MenuND;



                }
                strret = "MenuName:" + MenuName + "，Type:" + Type + "，Introduce:" + Introduce + "，CoverImg:" + CoverImg + "，Tips:" + Tips + "，MenuMainIngredient:" + MenuMainIngredient;
                strret += "，MenuFuliao:" + MenuFuliao + "，MenuGY:" + MenuGY + "，MenuKW:" + MenuKW + "，MenuSteps:" + MenuSteps;
                //  strret=" { 'Menu' :[ {  'MenuName' :"+MenuName+",  'Type' :"+Type+",  'Introduce' :"+Introduce+",  'CoverImg' :"+CoverImg+",  'Tips' :"+Tips+",  'MenuMainIngredient' :"+MenuMainIngredient+", 'MenuSteps' :"+MenuSteps+"} ]";



                context.Response.Write(strret);
                return;
            }
            #endregion  
             #region 加载用户单个菜谱
            if (Convert.ToString(context.Request.QueryString["type"]) == "EditSingleMenu")
            {
                String MenuNumber = Convert.ToString(context.Request.QueryString["MenuNumber"]);
                String mainsc = "";
                String fl = "";
                String strret = "";
                String steps = "";
                BLL.BLLmenu bll2 = new BLL.BLLmenu();
                IList<MenuAll> siglemenu = bll2.GetSingleMenu(MenuNumber);

                foreach (MenuAll menu in siglemenu)
                {
                    steps = menu.MenuSteps;
                    fl = menu.MenuFuliao;
                    mainsc = menu.MenuMainIngredient;
                }
                //String strret = HtmlCreate.GetSingleMenuEditImage(siglemenu);
               // String mt = HtmlCreate.creatematerialsEdit(mainsc, fl);

               // String st = HtmlCreate.createstepsEdit(steps);
                //String m = ex.GetMenuMaterialsImage(siglemenu);
                //String s = ex.GetMenuStepsImage(siglemenu);
               // strret = strret + "$" + mt + "$" + st;
  
             
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


            #region 搜索加载
            if (Convert.ToString(context.Request.QueryString["type"]) == "SearchcolmnNavLoad")
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                string strret = "";
                
                DBHelper.SqlHelper b = new DBHelper.SqlHelper();
                string sql = "select column_name as Obname,column_comment as Obcomment from information_schema.columns where table_name='" + val + "' and table_schema = 'dzyall'";  

                //
                IList<SearchL> list = b.ExcuteQuery<SearchL>(sql);
                //  IList<SearchL> list = bllclassfication.GetSearchLoadList("table");
                foreach (SearchL l in list)
                {
                    if (l.Obcomment != "")
                    {
                        strret += l.Obname + ",";
                        strret += l.Obcomment + "";
                        strret += "|";
                    }
                   
                }
                if (strret.Length != 0) {
                    strret = strret.Substring(0, strret.Length - 1);

                }
               
                context.Response.Write(strret);
                return;
            }
            #endregion                         
             #region 搜索加载
            if (Convert.ToString(context.Request.QueryString["type"]) == "SearchNavLoad")
            {
             
                string strret = "";
                BLLclassification bllclassfication = new BLLclassification();
                DBHelper.SqlHelper b = new DBHelper.SqlHelper();
                string sql = " select table_name  as Obname ,table_comment as Obcomment from information_schema.tables where table_schema='dzyall' and table_type='base table'";
                // SearchcolmnNavLoad
                //select column_name,column_comment,data_type from information_schema.columns where table_name=''
                IList<SearchL> list = b.ExcuteQuery<SearchL>(sql);
              //  IList<SearchL> list = bllclassfication.GetSearchLoadList("table");
                foreach (SearchL l in list)
                    {
                        if(l.Obcomment!=""){
                           strret += l.Obname+",";
                           strret += l.Obcomment + "";
                           strret += "|";
                        }
                       
                    }
                if (strret.Length != 0)
                {
                    strret = strret.Substring(0, strret.Length - 1);
                }

                context.Response.Write(strret);
                return;
            }
            #endregion  
             #region 搜索
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminSearch")
            {
                 //GetSearchLoadList
                 String val = Convert.ToString(context.Request.QueryString["val"]);
                 String table = Convert.ToString(context.Request.QueryString["table"]);
                 String column = Convert.ToString(context.Request.QueryString["column"]);
                 BLLclassification bllclassfication = new BLLclassification();

                double Size = 6.0;
               
               
                String bywhat = " "+column+" like '%"+val+"%'";
                 int datacount = bll.GetDataCount(bywhat, table);

                if(datacount==0){
                   context.Response.Write("0");
                    return;
                }

                 string sql= "select * from "+table+" where "+column+" like '%"+val+"%'";
                 String strret = "";
                String head = "";
                 DBHelper.SqlHelper b = new DBHelper.SqlHelper();
               //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
                
              if(table=="user"){
                 #region 用户搜索
                 IList<User> list = b.ExcuteQuery<User>(sql);
                 if(list.Count==0){
                   strret="0"; 
                 }else{

                      var properties = typeof(User).GetProperties();
                    foreach (System.Reflection.PropertyInfo info in properties)
                    {
                        head =head+info.Name+",";
                    }
                    head = head.Substring(0, head.Length - 1);
                    head += "|";
                   // IList<User> Lists =b.ExcuteQuery<User>(sql);
                    foreach(User i in list){
                           foreach (PropertyInfo pro in properties)
                          {  
                             string h=  (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                             strret = strret+h+",";
                          }
                           strret = strret.Substring(0, strret.Length - 1);
                           strret += "$";

                    }
                    strret = strret.Substring(0, strret.Length - 1);
                    strret = head + strret;

                 }
                  #endregion
              }else  if(table=="ingredient")
              {
                  #region 食材搜索
                  IList<Ingredient> list = b.ExcuteQuery<Ingredient>(sql);
                  if (list.Count == 0)
                  {
                      strret = "0";
                  }
                  else {
                      var properties = typeof(Ingredient).GetProperties();
                      foreach (System.Reflection.PropertyInfo info in properties)
                      {
                          head = head + info.Name + ",";
                      }
                      head = head.Substring(0, head.Length - 1);
                      head += "|";
                      // IList<User> Lists =b.ExcuteQuery<User>(sql);
                      foreach (Ingredient i in list)
                      {
                          foreach (PropertyInfo pro in properties)
                          {
                              string h = (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                              strret = strret + h + ",";
                          }
                          strret = strret.Substring(0, strret.Length - 1);
                          strret += "$";

                      }
                      strret = strret.Substring(0, strret.Length - 1);
                      strret = head + strret;

                  }
                  #endregion
              }
              else  if(table=="mainmenus"){
                  #region 菜谱搜索
                  IList<MenuAll> list = b.ExcuteQuery<MenuAll>(sql);
                  if (list.Count == 0)
                  {
                      strret = "0";
                  }
                  else
                  {
                      var properties = typeof(Ingredient).GetProperties();
                      foreach (System.Reflection.PropertyInfo info in properties)
                      {
                          head = head + info.Name + ",";
                      }
                      head = head.Substring(0, head.Length - 1);
                      head += "|";
                      // IList<User> Lists =b.ExcuteQuery<User>(sql);
                      foreach (MenuAll i in list)
                      {
                          foreach (PropertyInfo pro in properties)
                          {
                              string h = (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                              strret = strret + h + ",";
                          }
                          strret = strret.Substring(0, strret.Length - 1);
                          strret += "$";

                      }
                      strret = strret.Substring(0, strret.Length - 1);
                      strret = head + strret;

                  }
                  #endregion
              }else  if(table=="menu_classification"){
                  #region 分类搜索
                  IList<Classification> list = b.ExcuteQuery<Classification>(sql);
                  if (list.Count == 0)
                  {
                      strret = "0";
                  }
                  else
                  {
                      var properties = typeof(Ingredient).GetProperties();
                      foreach (System.Reflection.PropertyInfo info in properties)
                      {
                          head = head + info.Name + ",";
                      }
                      head = head.Substring(0, head.Length - 1);
                      head += "|";
                      // IList<User> Lists =b.ExcuteQuery<User>(sql);
                      foreach (Classification i in list)
                      {
                          foreach (PropertyInfo pro in properties)
                          {
                              string h = (string)i.GetType().GetProperty(pro.Name).GetValue(i, null);
                              strret = strret + h + ",";
                          }
                          strret = strret.Substring(0, strret.Length - 1);
                          strret += "$";

                      }
                      strret = strret.Substring(0, strret.Length - 1);
                      strret = head + strret;

                  }
                  #endregion
              }else {
               strret="notok"; 
              }
                  
                
                
               if(strret=="notok"){
                context.Response.Write(strret);
               }else{
                strret = strret + "|" + datacount;
                context.Response.Write(strret);
               }
               
                return;
            }
            #endregion  
            #region 修改分类
            if (Convert.ToString(context.Request.QueryString["type"]) == "loadclass")
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                BLLclassification bllclassfication = new BLLclassification();
                string bywhat = "";
                string strret = "";
                if (val == "all") {
                    bywhat = " Category_parent='总分类'";
                    IList<Classification> list = bllclassfication.GetClassificationListBywhat(bywhat);

                   // foreach (Classification l in list)
                   /// {
                    //    strret += l.Classification_contents+",";
                    
                  //  }
                }
                
               
               
                context.Response.Write("ok");
                return;
            }
            #endregion  
            #region 修改分类
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminClassAlter")
            {
                String classid = Convert.ToString(context.Request.QueryString["classid"]);
               String classchild = Convert.ToString(context.Request.QueryString["classchild"]);
                String classparent = Convert.ToString(context.Request.QueryString["classparent"]);
                BLLuser blluser = new BLLuser();
                int r = blluser.AdminClassAlter(classid, classchild, classparent);
                context.Response.Write("ok");
                return;
            }
            #endregion  
                 
            //if (context.Request.Files["type"]!=null)
            //{
            //    string wwwwwww = (context.Request.Files["type"]).ToString();
            //}
            //foreach (string upload in context.Request.Files.AllKeys)
            //{
            //    HttpPostedFile file = context.Request.Files[upload];   //file可能为null
            //}
            //HttpFileCollection headsss = context.Request.Files;
            //string sss1 = headsss.AllKeys[0];
            //string sss2 = headsss.AllKeys[1];
            //string sss3 = headsss.AllKeys[2];
           
          //  string headsss = context.Request.Form["type"];
          //  string headsss2 = context.Request.Form["ingnumber"];
          //  string headsss3 = context.Request.Form["imginput"];
          //  HttpFileCollection _file = HttpContext.Current.Request.Files;
            //string namesssss = _file[0].FileName;
          //  HttpPostedFile filessss = context.Request.Files["imginput"];  
          //  HttpPostedFile upLoad2 = context.Request.Files["type"];
          #region 添加食材图片
            if (Convert.ToString(context.Request.Form["type"]) == "sctpup")
            {

                  string ingnumber = context.Request.Form["ingnumber"];
                  string temp = context.Request.Form["imginput"];
                  temp = temp.Split(',')[1];
                  temp = temp.Replace(" ", "+");
                  int mod4 = temp.Length % 4;
                  if (mod4 > 0)
                  {
                      temp += new string('=', 4 - mod4);
                  }

                  var btsdata = Convert.FromBase64String(temp);
                  string uploadDir = context.Request.MapPath("/images/Ingredient/" + ingnumber + ".jpg");
                //  System.IO.Directory.CreateDirectory(context.Request.MapPath("~") + "UploadAvatar");
                  using (Image img = Image.FromStream(new MemoryStream(btsdata)))
                  {
                      img.Save(uploadDir, ImageFormat.Jpeg);
                  }
                  // HttpFileCollection head = context.Request.Files;  Guid.NewGuid().ToString("D")
               // String img = Convert.ToString(context.Request.QueryString["imginput"]);
              //  String scnumber = Convert.ToString(context.Request.QueryString["scnumber"]);

             //   HttpPostedFile file = context.Request.Files["imginput"];   //file可能为null

             //   string name = file.FileName;
               // string naaaa=file.

              // string pa = "~/images/Ingredient/";
              // string ff = context.Request.MapPath(pa);
                //if (File.Exists(ff))  {  
                //    // 是文件 " + scnumber + "/"

                //}
              //  if (!File.Exists(ff))
              //  {
                    // 是文件夹

                  //  context.Request.Files["imginput"].SaveAs(ff);
               // }
               // else
               // {
                   // File.Delete(ff, true);
              //  }
                context.Response.Write("ok");
                return;
            }
            #endregion 

            #region 修改食材图片
            if (Convert.ToString(context.Request.Form["type"]) == "altersctp")
            { 
                string ingnumber = context.Request.Form["ingnumber"];
                string temp = context.Request.Form["imginput"];
                temp = temp.Split(',')[1];
                temp = temp.Replace(" ", "+");
                int mod4 = temp.Length % 4;
                if (mod4 > 0)
                {
                    temp += new string('=', 4 - mod4);
                }

                var btsdata = Convert.FromBase64String(temp);
                string uploadDir = context.Request.MapPath("/images/Ingredient/" + ingnumber + ".jpg");
                
                if (File.Exists(uploadDir)) {
                    File.Delete(uploadDir);
                }
                using (Image img = Image.FromStream(new MemoryStream(btsdata)))
                {
                    img.Save(uploadDir, ImageFormat.Jpeg);
                }
 
                context.Response.Write("ok");
                return;
            }
            #endregion 

             #region 添加分类
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminClassAdd")
            {
                String classid = Convert.ToString(context.Request.QueryString["classid"]);
                String classchild = Convert.ToString(context.Request.QueryString["classchild"]);
                String classparent = Convert.ToString(context.Request.QueryString["classparent"]);
                BLLuser blluser = new BLLuser();

                string s = "";
                int k = blluser.GetDataCount(" Classification_contents='" + classparent+"'", "menu_classification");
                if (k == 0)
                {
                    int r = blluser.AdminClassAdd(classid, classchild, classparent);
                    s = "ok";
                }
                else {
                    s = "当前分类已存在";
                }
                //int k2 = blluser.GetDataCount(" Classification_contents=" + classparent, "menu_classification");
               
                context.Response.Write(s);
                return;
            }
            #endregion 
          
            #region 删除分类
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminClassDel")
            {
                String classid = Convert.ToString(context.Request.QueryString["classid"]);
                BLLuser blluser = new BLLuser();
                int r = blluser.AdminClassDel(classid);
                context.Response.Write("ok");
                return;
            }
            #endregion 

           #region 删除食材
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminIngredientDel")
            {
                String IngredientNumber = Convert.ToString(context.Request.QueryString["IngNumber"]);
                BLLuser blluser = new BLLuser();
                int r = blluser.AdminIngredientDel(IngredientNumber);
                context.Response.Write("ok");
                return;
            }
            #endregion 
           
           #region 修改食材
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminIngredientAlter")
            {
                  
        
       // String Positives
        // String Negatives
        // String Taboo
      
       
        //String FoodTaboo
     //public String Choose{ get; set; }
     //   public String Storage{ get; set; }
        
                 String IngredientNumber = Convert.ToString(context.Request.QueryString["IngNumber"]);
                 String IngredientName = Convert.ToString(context.Request.QueryString["IngName"]);
                 String IngredientIntroduction= Convert.ToString(context.Request.QueryString["IngSCJS"]);
                 String NutritiveValue = Convert.ToString(context.Request.QueryString["IngYY"]);
                 String Negatives = Convert.ToString(context.Request.QueryString["IngJJ"]);
                 String CookingTips = Convert.ToString(context.Request.QueryString["IngXMZ"]);
                 String EdibleEffect = Convert.ToString(context.Request.QueryString["IngSYJZ"]);
                 //String Positives = Convert.ToString(context.Request.QueryString["IngSCJS"]);
                 //String CoverImg = Convert.ToString(context.Request.QueryString["IngImg"]);


                 BLLuser blluser = new BLLuser();
                 int r = blluser.AdminIngredientAlter(IngredientNumber, IngredientName,IngredientIntroduction, NutritiveValue, Negatives, CookingTips, EdibleEffect);

                context.Response.Write("ok");
                return;
            }
            #endregion 
             #region 添加食材
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminIngredientAdd")
            {
                String IngredientNumber = Convert.ToString(context.Request.QueryString["IngNumber"]);
                String IngredientName = Convert.ToString(context.Request.QueryString["IngName"]);
                String IngredientIntroduction = Convert.ToString(context.Request.QueryString["IngSCJS"]);
                String NutritiveValue = Convert.ToString(context.Request.QueryString["IngYY"]);
                String Negatives = Convert.ToString(context.Request.QueryString["IngJJ"]);
                String CookingTips = Convert.ToString(context.Request.QueryString["IngXMZ"]);
                String EdibleEffect = Convert.ToString(context.Request.QueryString["IngSYJZ"]);
                //String Positives = Convert.ToString(context.Request.QueryString["IngSCJS"]);
                String CoverImg = Convert.ToString(context.Request.QueryString["IngImg"]);
               
                BLLuser blluser = new BLLuser();
                int r = blluser.AdminIngredientAdd(IngredientNumber, IngredientName, IngredientIntroduction, NutritiveValue, Negatives, CookingTips, EdibleEffect, CoverImg);

                context.Response.Write("ok");
                return;
            }
            #endregion 

            #region 获取食材信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetIngredientDetail")
            {
                String IngredientNumber = Convert.ToString(context.Request.QueryString["val"]);
                String by = Convert.ToString(context.Request.QueryString["by"]);
                //String type = "IngredientName";
                //String type = "IngredientNumber";
                String strret = "";
                CreateHtml ex2 = new CreateHtml();
                BLL.BLLmenu bll2 = new BLL.BLLmenu();
                IList<Ingredient> sigleingredient = bll2.GetIngredientDetail(by, IngredientNumber);//获取食材基本信息


                strret = ex2.GetIngredientDetailAdmin(sigleingredient);

                context.Response.Write(strret);
                return;
            }
            #endregion 
             #region//用户修改菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductionSingleUpdate")
            {
                String Account = (context.Session["useraccount"]).ToString(); 
                string Attr = Convert.ToString(context.Request.QueryString["Attr"]);
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                 if (Attr == "Steps")
                {
                    string bzall = Convert.ToString(context.Request.QueryString["bzall"]);
                    int r = bll.AlterSingleAttr("recipeteachinginformation", "MenuSteps", bzall, " where MenuNumber='" + menunumber + "'");
                 
                }else if (Attr == "Else")
                {
                    
                   
                    String Username = (context.Session["username"]).ToString();
                    string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                    string kw = Convert.ToString(context.Request.QueryString["kw"]);
                    string gy = Convert.ToString(context.Request.QueryString["gy"]);
                    string menutype = Convert.ToString(context.Request.QueryString["menutype"]);
                    string mainsc = Convert.ToString(context.Request.QueryString["mainsc"]);
                    string fl = Convert.ToString(context.Request.QueryString["fl"]);
                    
                    string Tips = Convert.ToString(context.Request.QueryString["Tips"]);
                     
                    string menuimg = Convert.ToString(context.Request.QueryString["menuimg"]);
                   
                    string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                    String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                    String content = "你修改了" + menuname;
                    String actitle = "修改  " + menuname;
                    String ctype = "alterMenu";
                    int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                    //修改表中单个属性值
                    int allproductionnum = Int32.Parse((context.Session["allproductionnum"]).ToString());
                    allproductionnum++;
                    String val = allproductionnum.ToString();

                    int r = bll.AlterSingleAttr("User", "AllProductionNum", val, " where Account='" + Account + "'");


                    int experience = Int32.Parse((context.Session["experience"]).ToString());
                    experience = experience + 100;
                    val = (experience).ToString();

                    int r2 = bll.AlterSingleAttr("User", "Experience", val, " where Account='" + Account + "'");
                    BLLuser blluser = new BLLuser();

                    int k2 = blluser.MenuUpdate(menunumber, menuname, menutype, menuimg, Account);
                    int k = 0;
                    int dacount = bll.GetDataCount(" MenuNumber=" + menunumber, "recipeteachinginformation");
                    if (k2 == 0) {
                         k = blluser.MenuUpdate2(menunumber, mainsc, fl, gy, kw, Tips);
                    } else {
                        k = blluser.MenuAdd2(menunumber, mainsc, fl, gy, kw, Tips);
                    }
                    
                }
                 else if (Attr == "Introduce")
                {
                    string introduce = Convert.ToString(context.Request.QueryString["introduce"]);
                    int r = bll.AlterSingleAttr("mainmenus", "Introduces", introduce, " where MenuNumber='" + menunumber + "'");
                }     
               
               // int k = blluser.FoodProduction(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall, TimeMade); 
                context.Response.Write("success");
                return;
            }
            #endregion
               #region//制作菜品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductionSingleAdd")
            {
                 
                string Attr = Convert.ToString(context.Request.QueryString["Attr"]);
                string menunumber = Convert.ToString(context.Request.QueryString["menunumber"]);
                 if (Attr == "Steps")
                {
                    string bzall = Convert.ToString(context.Request.QueryString["bzall"]);
                    int r = bll.AlterSingleAttr("recipeteachinginformation", "MenuSteps", bzall, " where MenuNumber='" + menunumber + "'");
                 
                }else if (Attr == "Else")
                {
                    String Account = (context.Session["useraccount"]).ToString();
                    String Username = (context.Session["username"]).ToString();
                    string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                    string kw = Convert.ToString(context.Request.QueryString["kw"]);
                    string gy = Convert.ToString(context.Request.QueryString["gy"]);
                    string menutype = Convert.ToString(context.Request.QueryString["menutype"]);
                    string mainsc = Convert.ToString(context.Request.QueryString["mainsc"]);
                    string fl = Convert.ToString(context.Request.QueryString["fl"]);
                    
                    string Tips = Convert.ToString(context.Request.QueryString["Tips"]);
                     
                    string menuimg = Convert.ToString(context.Request.QueryString["menuimg"]);
                   
                    string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                    String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                    String content = "你制作了" + menuname;
                    String actitle = "制作  " + menuname;
                    String ctype = "madeMenu";
                    int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                    //修改表中单个属性值
                    int allproductionnum = Int32.Parse((context.Session["allproductionnum"]).ToString());
                    allproductionnum++;
                    String val = allproductionnum.ToString();

                    int r = bll.AlterSingleAttr("User", "AllProductionNum", val, " where Account='" + Account + "'");


                    int experience = Int32.Parse((context.Session["experience"]).ToString());
                    experience = experience + 100;
                    val = (experience).ToString();

                    int r2 = bll.AlterSingleAttr("User", "Experience", val, " where Account='" + Account + "'");
                    BLLuser blluser = new BLLuser();

                    int k2 = blluser.MenuAdd(menunumber, menuname, menutype, menuimg, Account, TimeMade);

                    int k = blluser.MenuAdd2(menunumber, mainsc, fl, gy, kw, Tips);
                }
                 else if (Attr == "Introduce")
                {
                    string introduce = Convert.ToString(context.Request.QueryString["introduce"]);
                    int r = bll.AlterSingleAttr("mainmenus", "Introduces", introduce, " where MenuNumber='" + menunumber + "'");
                }     
               
               // int k = blluser.FoodProduction(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall, TimeMade); 
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
                //修改表中单个属性值
                 int allproductionnum = Int32.Parse((context.Session["allproductionnum"]).ToString());
                 allproductionnum++;
                 String val= allproductionnum.ToString();
                        
                int r = bll.AlterSingleAttr("User","AllProductionNum",val," where Account='"+Account+"'");


                int experience = Int32.Parse((context.Session["experience"]).ToString());
                experience = experience + 100;
                  val = (experience).ToString();

                  int r2 = bll.AlterSingleAttr("User", "Experience", val, " where Account='" + Account + "'");
               

                BLLuser blluser = new BLLuser();

               // int k2 = blluser.MenuAdd(menunumber, menuname, menutype, menuimg, introduce, Account, TimeMade);

               // int k = blluser.MenuAdd2(menunumber, mainsc, fl, gy, kw, bzall, Tips);

               // int k = blluser.FoodProduction(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall, TimeMade); 
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
          // AdminProductiondel&userfoodnumber='+menunumber

            #region//删除作品
            if (Convert.ToString(context.Request.QueryString["type"]) == "AdminProductiondel")
            {
                string userfoodnumber = Convert.ToString(context.Request.QueryString["userfoodnumber"]);
                //string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                String Account = (context.Session["useraccount"]).ToString();

                BLLuser blluser = new BLLuser();
              ///  int r = blluser.UserProductionDel(userfoodnumber);
                int r = blluser.AdminProductionDel(userfoodnumber);
                if (r == 0)
                {
                }
                else
                {

                   // string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                   // String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                   // String content = "你删除了" + menuname;
                  //  String actitle = "删除  " + menuname;
                   // String ctype = "deleteMenu";
                   // int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                    string pa = "~/images/MenuAll/" + userfoodnumber +"/";
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


            #region//删除作品
            if (Convert.ToString(context.Request.QueryString["type"]) == "UserProductiondel")
            {
                string userfoodnumber = Convert.ToString(context.Request.QueryString["userfoodnumber"]);
                //string menuname = Convert.ToString(context.Request.QueryString["menuname"]);
                String Account = (context.Session["useraccount"]).ToString();

                BLLuser blluser = new BLLuser();
                int r = blluser.UserProductionDel(userfoodnumber);
                if (r == 0)
                {
                }
                else
                {

                   // string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                   // String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                   // String content = "你删除了" + menuname;
                  //  String actitle = "删除  " + menuname;
                   // String ctype = "deleteMenu";
                   // int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                    string pa = "~/images/MenuAll/" + userfoodnumber +"/";
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