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

    public class Index : IHttpHandler, IRequiresSessionState
    {

        int count=0;
        public void ProcessRequest(HttpContext context)
        { 

          	 #region 根据菜单分类读取菜单
            if (Convert.ToString(context.Request.QueryString["type"]) == "getMenuLists")
            {
                CreateHtml HtmlCreate = new CreateHtml();
                BLL.BLLmenu bll = new BLL.BLLmenu();
                 BLL.BLLuser bll2 = new BLL.BLLuser();
                String strret = "";
                String val = Convert.ToString(context.Request.QueryString["val"]);//根据传入的值匹配
                String valtype = Convert.ToString(context.Request.QueryString["valtype"]);//根据传入的值匹配
                String bywhat2 = Convert.ToString(context.Request.QueryString["bywhat"]);//根据传入的值匹配
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
               // String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
              //  String actype = Convert.ToString(context.Request.QueryString["actype"]);
              //  int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
               val = val.Replace("'", ""); 
 
                valtype = valtype.Replace("'", "");
                valtype = valtype.Replace("\"", "");//双引
                 bywhat2= bywhat2.Replace("'", "");//单引
                bywhat2=bywhat2.Replace("\"", "");//双引
                //if (actype == "pre" && OldPageindex == "0")
                //{
                //    context.Response.Write(strret);
                //    return;
                //}
                //else if (actype == "next" && k <0)
                //{
                //    context.Response.Write(strret);
                //    return;
                //}
                IList<MenuAll> Lists;
                double Size = 12.0;
                String tablename = "menualldetails";
                String bywhat = " " + bywhat2 + "='" + val+"'";
                //计算当前页面数
                int datacount =  bll2.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.GetMenuList(bywhat2, val, (Int32)Size, dataindex);
                //如果数据页数改变
               // if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                   strret = HtmlCreate.createMainMenuListimage(Lists, valtype, pageindex, NewPages);
               // else
                //    strret = HtmlCreate.createMainMenuListimage(Lists, valtype, pageindex, Int32.Parse(OldPages));
                   val = val.Replace("'", "");
                   val = val.Replace("\"", "");//双引
                 String ww="<li><a class='social wdc' onclick='displayli()' title='更多数据' >共"+datacount+"记录</a></li>";
                for (int q=1;q<=NewPages;q++){
                    int p=(q-1)*12+1;
                    if (q != NewPages)
                        ww += "  <li id='k1'class='k1'><a class='social wdc' href='#' onclick='getmenulist(&quot;" + valtype + "&quot;,&quot;" + val + "&quot;,&quot;" + bywhat2 + "&quot;," + q + ")' >" + p + "-" + q * 12 + "</a></li>";
                    else
                        ww += "  <li  id='k2' class='k1'><a class='social wdc' href='#'  onclick='getmenulist(&quot;" + valtype + "&quot;,&quot;" + val + "&quot;,&quot;" + bywhat2 + "&quot;," + q + ")' >" + p + "-" + datacount + "</a></li>";
                } 



                strret = strret + "$" + ww;
 
                context.Response.Write(strret);
                return;
            }
            #endregion           
            #region 根据菜单分类读取菜单
            if (Convert.ToString(context.Request.QueryString["type"]) == "getMenuListsByType2")
            {
                CreateHtml HtmlCreate = new CreateHtml();
                BLL.BLLmenu bll = new BLL.BLLmenu();
                 BLL.BLLuser bll2 = new BLL.BLLuser();
                String strret = "";
                String val = Convert.ToString(context.Request.QueryString["val"]);//根据传入的值匹配
                String valtype = Convert.ToString(context.Request.QueryString["valtype"]);//根据传入的值匹配
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                if (actype == "pre" && OldPageindex == "1")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<MenuAll> Lists;
                double Size = 12.0;
                String tablename = "mainmenus";
                String bywhat = " Type='" + val + "'";
                //计算当前页面数
                int datacount =  bll2.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.GetMenuList("Type",val, (Int32)Size, dataindex);
                //如果数据页数改变
                
                    if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                        strret = HtmlCreate.createMainMenuListimage(Lists, valtype, pageindex, NewPages);
                    else
                        strret = HtmlCreate.createMainMenuListimage(Lists, valtype, pageindex, Int32.Parse(OldPages));
               
               


 
                context.Response.Write(strret);
                return;
            }
            #endregion 
            if (Convert.ToString(context.Request.Form["tpty"]) == "cp")
            {
                String bzcount = context.Request.Form["bzcount"];
                String usernumber = context.Request.Form["usernumber"];
                String menunumber = context.Request.Form["menunumber"];
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


                context.Request.Files["file1"].SaveAs(ff + name);
                context.Response.Write("true");
                return;
            }

             
             #region IndexNewList
            if (Convert.ToString(context.Request.QueryString["type"]) == "getindexnewlist")
            {
                CreateHtml HtmlCreate = new CreateHtml();
                BLL.BLLclassification bll = new BLL.BLLclassification();
                String strret = "";
                
               // String val = Convert.ToString(context.Request.QueryString["val"]);//根据传入的值匹配
               


               
                    int index = 0;
                    int size = 3;
                    String type="latest";
                    //String type2="hotest";
                    //IList<SimpleMenu> List2s = bll.GetSimpleMenuList(index, size);
                    IList<SimpleMenu> Lists = bll.GetSimpleMenuListnewlist(index, size);
                    strret = HtmlCreate.createindexmenuimage(Lists);
 
               
                 

                //strret = HtmlCreate.createIndexMiddleimage(Lists);
                


 
                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region IndexMiddle
            if (Convert.ToString(context.Request.QueryString["type"]) == "IndexMiddle")
            {
                CreateHtml HtmlCreate = new CreateHtml();
                BLL.BLLclassification bll = new BLL.BLLclassification();
                String strret = "";
                String scType = "人气";
                String val = Convert.ToString(context.Request.QueryString["val"]);//根据传入的值匹配
                String useraccount = "";
                if (context.Session["useraccount"] != null) {
                    useraccount = (context.Session["useraccount"]).ToString();
                }
               // if((context.Session["useraccount"]).ToString())


                if (val == "mrsc" )
                {
                    IList<MenuCollocation> Lists = bll.GetMenuCollocationList(val, scType); 

                    strret = HtmlCreate.createThreeMealsimage(Lists,useraccount);
                }else if (val == "djsc") { 
                   
                   
                }else if (val == "jkxw") {
                    int index = 0;
                    int size = 4;
                    IList<HealthNews> Lists = bll.GetHealthNewsList(index,size);

                    strret = HtmlCreate.createHealthNewsimage(Lists);
                }
                else if (val == "msgc")
                {
                    int index = 0;
                    int size = 4;
                    String type="latest";
                    //String type2="hotest";
                    IList<SimpleMenu> Lists = bll.GetSimpleMenuList(index, size);

                    strret = HtmlCreate.createSimpleMenuimage(Lists);

                }
               
                 

                //strret = HtmlCreate.createIndexMiddleimage(Lists);
                


 
                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 获取当前菜谱不同工艺的做法
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetMenuByOtherPractices")
            {
                // String useraccount = "1001";
                String useraccount = "";
                if (context.Session["username"] != null)
                {
                    useraccount = (context.Session["useraccount"]).ToString();
                } 
                String MenuName = Convert.ToString(context.Request.QueryString["MenuName"]);
                String MenuGY = Convert.ToString(context.Request.QueryString["MenuGY"]);
               // String MenuGYListImg = Convert.ToString(context.Request.QueryString["MenuGYListImg"]);
                String MenuNumber = Convert.ToString(context.Request.QueryString["MenuNumber"]); 
                String strret = "";
                CreateHtml ex = new CreateHtml();
               //  val = val.Replace("'", "");
               // val = val.Replace("\"", "");
                BLL.BLLmenu bll = new BLL.BLLmenu();

                IList<MenuAll> siglemenu = bll.GetMenuByOtherPractices(MenuName, MenuGY);

                String menuTechnology ="";
                String  currentmenunumber = "";
                String  menuname = "";
                //IList<MenuAll> siglemenu = bll.GetSingleMenu(val);
                foreach (MenuAll menu in siglemenu)
                {
                    menuTechnology = menu.MenuGY;
                    currentmenunumber = menu.MenuNumber;
                    menuname = menu.KeyWord;
                }
             
                //IList<SimpleMenu> OtherPractices = bll.GetCurrentMenuElseGY(persentMenuNumber, MenuName, MenuGY, "MenuGY");//获取当前菜单的其他做法
               // strret = ex.GetMenuByOtherPracticesImage(siglemenu, useraccount, MenuGYListImg);
                IList<MenuPractices> OtherPractices = bll.GetCurrentMenuElseGY(currentmenunumber, menuname, menuTechnology, "MenuGY");//获取当前菜单的其他做法

                strret = ex.GetSingleMenuImage(siglemenu, useraccount, OtherPractices);
                String m = ex.GetMenuMaterialsImage(siglemenu);
                String s = ex.GetMenuStepsImage(siglemenu);
                strret = strret + "$" + m + "$" + s;
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 获取当前菜谱相同工艺的不同做法
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetMenuByIdenticalGY")
            {
                // String useraccount = "1001";
                String useraccount = "";
                if (context.Session["username"] != null)
                {
                    useraccount = (context.Session["useraccount"]).ToString();
                }
                String MenuName = Convert.ToString(context.Request.QueryString["MenuName"]);
                String MenuGY = Convert.ToString(context.Request.QueryString["MenuGY"]);
                String MenuNumberList = Convert.ToString(context.Request.QueryString["MenuNumberList"]);
                String MenuGYListImg = Convert.ToString(context.Request.QueryString["MenuGYListImg"]); 
                String strret = "";
                CreateHtml ex = new CreateHtml();
               //  val = val.Replace("'", "");
               // val = val.Replace("\"", "");
                BLL.BLLmenu bll = new BLL.BLLmenu();

                IList<MenuAll> siglemenu = bll.GetMenuByIdenticalGY(MenuNumberList,MenuName, MenuGY);
               
                String[] MenuNList = MenuNumberList.Split('/');
                String persentMenuNumber = MenuNList[MenuNList.Length-1];
                //IList<SimpleMenu> OtherPractices = bll.GetCurrentMenuElseGY(persentMenuNumber, MenuName, MenuGY, "MenuGY");//获取当前菜单的其他做法
                strret = ex.GetIdenticalGYMenuImage(siglemenu, useraccount, MenuNumberList, MenuGYListImg);
                
                context.Response.Write(strret);
                return;
            }
            #endregion  

               #region 获取热门搜索列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "SearchFever")
            {
                // String useraccount = "1001";
              // SearchFever&searchtype=sccp
                String searchtype = Convert.ToString(context.Request.QueryString["searchtype"]);
                String strret = "";
                String bywhat="";
                CreateHtml ex = new CreateHtml();
                int size = 5;
                int index = 0;
               //  val = val.Replace("'", "");
               // val = val.Replace("\"", "");
                BLL.BLLuser bll = new BLL.BLLuser();
                if (searchtype == "sccp") {
                    bywhat = " SearchType='cm' or  SearchType='sc'";

                }
                else if (searchtype == "yhmzh")
                {
                    bywhat = " SearchType='yhm' or SearchType='zh'  ";
                }
                IList<SearchFever> siglemenu = bll.GeSearchFeverList(bywhat, size, index);


                strret = ex.GeSearchFeverListImage(siglemenu);
                
                context.Response.Write(strret);
                return;
            }
            #endregion
             
            #region 获取菜谱用料---未完成
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetMenuMaterials") 
            {
               // String useraccount = "1001";
                 String useraccount = "";
                if (context.Session["username"] != null) { 
                  useraccount = (context.Session["useraccount"]).ToString();
                }
               
                String MenuNumber = Convert.ToString(context.Request.QueryString["MenuNumber"]);
                String strret = "";
                String menuTechnology = "";
                String menuname = "";
                String currentmenunumber = "";
                 
                CreateHtml ex = new CreateHtml();
                MenuNumber = MenuNumber.Replace("'", "");
                MenuNumber = MenuNumber.Replace("\"", ""); 
                BLL.BLLmenu bll = new BLL.BLLmenu();

                IList<MenuAll> siglemenu = bll.GetSingleMenu(MenuNumber);
                foreach(MenuAll menu in siglemenu){
                    menuTechnology = menu.MenuGY;
                    currentmenunumber = menu.MenuNumber;
                    menuname = menu.MenuName;
                }

                IList<MenuPractices> OtherPractices = bll.GetCurrentMenuElseGY(currentmenunumber, menuname, menuTechnology, "MenuGY");//获取当前菜单的其他做法
                strret = ex.GetSingleMenuImage(siglemenu, useraccount, OtherPractices);
                
                context.Response.Write(strret);
                return;
            }
            #endregion  
             #region 获取菜谱步骤---未完成
            if (Convert.ToString(context.Request.QueryString["type"]) == " GetMenuSteps") 
            {
               // String useraccount = "1001";
                 String useraccount = "";
                if (context.Session["username"] != null) { 
                  useraccount = (context.Session["useraccount"]).ToString();
                }
               
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                String menuTechnology = "";
                String menuname = "";
                String currentmenunumber = "";
                 
                CreateHtml ex = new CreateHtml();
                val=val.Replace("'", "");
                val=val.Replace("\"", ""); 
                BLL.BLLmenu bll = new BLL.BLLmenu();

                IList<MenuAll> siglemenu = bll.GetSingleMenu(val);
                foreach(MenuAll menu in siglemenu){
                    menuTechnology = menu.MenuGY;
                    currentmenunumber = menu.MenuNumber;
                    menuname = menu.MenuName;
                }

                IList<MenuPractices> OtherPractices = bll.GetCurrentMenuElseGY(currentmenunumber, menuname, menuTechnology, "MenuGY");//获取当前菜单的其他做法
                strret = ex.GetSingleMenuImage(siglemenu, useraccount, OtherPractices);
                
                context.Response.Write(strret);
                return;
            }
            #endregion  
            #region 根据菜谱编号读取菜谱 
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetSingleMenu") 
            {
               // String useraccount = "1001";
                 String useraccount = "";
                if (context.Session["username"] != null) { 
                  useraccount = (context.Session["useraccount"]).ToString();
                }
               
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String tt = Convert.ToString(context.Request.QueryString["tt"]);
                String strret = "";
                String menuTechnology = "";
                String menuname = "";
                String currentmenunumber = "";
                String ty = "";
                CreateHtml ex = new CreateHtml();
                val=val.Replace("'", "");
                val=val.Replace("\"", "");
                tt = tt.Replace("'", "");
                BLL.BLLmenu bll = new BLL.BLLmenu();

                if (tt == "notuserproduction")
                {
                    ty = "userpgp";
                    IList<MenuAll> siglemenu = bll.GetSingleMenu(val);
                    foreach (MenuAll menu in siglemenu)
                    {
                        menuTechnology = menu.MenuGY;
                        currentmenunumber = menu.MenuNumber;
                        menuname = menu.MenuName;
                    }

                    IList<MenuPractices> OtherPractices = bll.GetCurrentMenuElseGY(currentmenunumber, menuname, menuTechnology, "MenuGY");//获取当前菜单的其他做法
                    strret = ex.GetSingleMenuImage(siglemenu, useraccount, OtherPractices);
                    String m = ex.GetMenuMaterialsImage(siglemenu);
                    String s = ex.GetMenuStepsImage(siglemenu);
                    strret = strret + "$" + m + "$" + s;
                }
                else {
                    ty = "userp";
                    String mainsc ="";
                    String  fl ="";
                    String  steps ="";
                    IList<UserProductions> siglemenu = bll.GetSingleUserMenu(val);
                    foreach (UserProductions menu in siglemenu)
                    {
                        steps = menu.MenuSteps;
                        fl = menu.MenuFuliao;
                        mainsc = menu.MenuMainIngredient;
                    }
                    strret = ex.GetSingleUserMenuImage(siglemenu);
                    String mt = ex.creatematerials( mainsc, fl);
                     
                    String st = ex.createsteps(steps,ty);
                    //String m = ex.GetMenuMaterialsImage(siglemenu);
                    //String s = ex.GetMenuStepsImage(siglemenu);
                   strret = strret + "$" + mt + "$" + st;
                }
               
                context.Response.Write(strret);
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
                CreateHtml ex = new CreateHtml();
                BLL.BLLmenu bll = new BLL.BLLmenu();
                IList<Ingredient> sigleingredient = bll.GetIngredientDetail(by,IngredientNumber);//获取食材基本信息
              
                
                strret = ex.GetIngredientDetail(sigleingredient);
               
                context.Response.Write(strret);
                return;
            }
            #endregion 
            

            #region 获取食材搭配
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetRelavantMenu")
            {
                String IngredientName = Convert.ToString(context.Request.QueryString["val"]);

                //String type = "IngredientName";
               //String by = "IngredientNumber";

                BLL.BLLuser bll2 = new BLL.BLLuser();
                BLL.BLLmenu bll = new BLL.BLLmenu();
                String strret = "";
                myoperateClass ex = new myoperateClass();
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
                IList<SimpleMenu> Lists;
                double Size = 10.0;
                String tablename = "recipeteachinginformation";
                String bywhat = " MenuMainIngredient  like '%" + IngredientName + "%'";
                //计算当前页面数
                int datacount = bll2.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);


                IList<recipeteachinginformation> relavantmenu = bll.GetRelavantMenu(IngredientName);//

                String bb = "(";
                foreach (recipeteachinginformation l in relavantmenu)
                {
                    bb += l.MenuNumber+",";
                }
                bb += "0)";

                bb = "select * from menualldetails where MenuNumber in " + bb;

                Lists = bll.GetRelavantMenuA(bb);


                if (datacount != 0)
                {
                    strret = ex.SearchListImage(Lists, pageindex, NewPages, actype, datacount, "getrelavantmenu");
                    int prepageindex = pageindex-1;
                    int nextpageindex = pageindex+1;
              String  retstr = " <div class='userDaTabottom'> ";
              retstr += "   <div class='DataBottom'>";
              retstr += "<div class='DataBottominner'>";
              retstr += "<span class='presentindex'>" + pageindex + "</span><span class='pages'>/" + NewPages + "</span></div>";
              retstr += "<div class='zcbq' onclick='getrelavantmenu(&quot;" + IngredientName + "&quot;,0," + NewPages + "," + prepageindex + ",&quot;pre&quot;)'></div>";
              retstr += "<div class='zcbh' onclick='getrelavantmenu(&quot;" + IngredientName + "&quot;,0," + NewPages + "," + nextpageindex + ",&quot;next&quot;)'></div>";
             retstr += "</div> ";
             retstr += "</div> ";
            
            // getrelavantmenu(menuname, pages, persentpageindex, actype)
             strret += retstr;
                }
                else
                {

                    strret += " <div class='searchlist'>";
                    strret += "  <div class='searchlisttitle'>";
                    strret += " <p class='searchlisttit'>暂无数据</p>";

                    strret += " </div>";
                    strret += "  <div class='alertcancle' onclick='alertcancle()'> 取消</div>";

                    strret += " </div>";


                }
               
               


              
                //strret = ex.SearchListImage(relavantmenu, pageindex, NewPages, actype, datacount);

                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 获取食材搭配
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetIngredientChoose")
            {
                String IngredientNumber = Convert.ToString(context.Request.QueryString["val"]);

                //String type = "IngredientName";
                String by = "IngredientNumber";
                String strret = "";
                CreateHtml ex = new CreateHtml();
                BLL.BLLmenu bll = new BLL.BLLmenu();


                IList<Ingredient> sigleingredient = bll.GetIngredientDetail(by,IngredientNumber);//获取食材基本信息

                 strret = ex.GetIngredientChoose(sigleingredient);

                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 获取食材搭配
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetIngredientTaboo") 
            {
                String IngredientNumber = Convert.ToString(context.Request.QueryString["val"]);
                //String type = "IngredientName";
                String by = "IngredientNumber";
                String strret = "";
                CreateHtml ex = new CreateHtml();
                BLL.BLLmenu bll = new BLL.BLLmenu();

              
                IList<Ingredient> sigleingredient = bll.GetIngredientDetail(by,IngredientNumber);//获取食材基本信息
                String iname = "";
                String img = "";
                foreach (Ingredient l in sigleingredient)
                {
                    iname = l.IngredientName;
                    img = l.CoverImg;
                }
                IList<IngredientTaboo> foodtaboo = bll.GetIngredientTaboo(IngredientNumber);
                strret = ex.GetIngredientTabooImage(img, iname,foodtaboo);
                
                context.Response.Write(strret);
                return;
            }
            #endregion 
              #region 获取菜谱评论模板
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserCommentmb") 
            {
                String strret = "unlogin";
                if (context.Session["username"] == null) {
                    context.Response.Write(strret);
                    return;
                }
                

                String username = (context.Session["username"]).ToString();
                String userimg = (context.Session["userimg"]).ToString();
                
                CreateHtml ex = new CreateHtml();
                
                strret = ex. GetUserCommentmb( userimg, username);
                
                context.Response.Write(strret);
                return;
            }
            #endregion 
            #region 获取菜谱评论信息
            if (Convert.ToString(context.Request.QueryString["type"]) == "GetUserComment") 
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                CreateHtml ex = new CreateHtml();
                val = val.Replace("'", "");
                val = val.Replace("\"", ""); 
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
            if (Convert.ToString(context.Request.QueryString["type"]) == "getindexclassification")
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                myoperateClass ex = new myoperateClass();

                BLL.BLLclassification bll = new BLL.BLLclassification();

                IList<Classification> Lists = bll.GetClassificationList(val);

             
                    strret = ex.ClassificationListImage2(Lists,val);
               
                context.Response.Write(strret);
                return;
            }
            #endregion 获取分类列表

            
            #region 获取分类列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "classification")
            {
                String val = Convert.ToString(context.Request.QueryString["val"]);
                String strret = "";
                myoperateClass ex = new myoperateClass();

                BLL.BLLclassification bll = new BLL.BLLclassification();

                IList<Classification> Lists = bll.GetClassificationList(val);

                 
                if (val == "HeadNavigation") 
                {
                    strret = ex.createHeadNavigationImage(Lists);
                }
                else if (val == "MainMenu")
                {
                    foreach(Classification list in Lists){
                     strret +=list.Classification_contents+"|";
                    }
                   
                }
                else
                {
                    strret = ex.ClassificationListImage(Lists,val);
                }

                context.Response.Write(strret);
                return;
            }
            #endregion 获取分类列表

            #region 用户搜索列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "usersearch2")
            {
                String sid = Convert.ToString(context.Request.QueryString["sid"]);
                BLL.BLLuser bll = new BLL.BLLuser();
                BLL.BLLmenu bll2 = new BLL.BLLmenu();
                String keyword = Convert.ToString(context.Request.QueryString["keyword"]);
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);

                String Account = "";
                if (context.Session["useraccount"] != null) {
                    Account = (context.Session["useraccount"]).ToString();
                    string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                    String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";

                    String content = "你搜索了作者: " + keyword;
                    String actitle = "搜索" + keyword;
                    String ctype = "search";
                    int i2 = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                }
               

               

                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                //String useraccount = (context.Session["useraccount"]).ToString();
                String strret = "";
                CreateHtml HtmlCreate = new CreateHtml();
                //if (actype == "pre" && OldPageindex == "1")
                //{
                //    context.Response.Write(strret);
                //    return;
                //}
                //else if (actype == "next" && k == 0)
                //{
                //    context.Response.Write(strret);
                //    return;
                //}
                IList<User> Lists;
                double Size = 8.0;
                String tablename = "user";
                //计算当前页面数
                String bywhat = " ";
                if (sid == "zh")
                {
                    bywhat = " Account='" + keyword + "'";
                }
                else if (sid == "yhm")
                {
                    bywhat = " UserName like '%" + keyword + "%'";
                }
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
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());


                bywhat = " SearchContent='" + keyword + "'";
                int datacount2 = bll.GetDataCount(bywhat, "searchfever");
                if (datacount2 == 0)
                {
                    int rr = bll.searchfeverinsert(keyword, sid);

                }
                else
                {
                    String fever = "";
                    IList<SearchFever> List2 = bll.GetSearchFever(keyword);
                    foreach (SearchFever i in List2)
                    {
                        fever = i.Fever;
                    }
                    int ff = Int32.Parse(fever);
                    ff++;
                    int rr = bll.searchfeverupdate(keyword, ff.ToString());
                }


                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.GetUserSearch(orderby, keyword, sid, (Int32)Size, dataindex);

                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    strret = HtmlCreate.getUserSearchListimage2(Lists, pageindex, NewPages, actype, Account);
                else
                    strret = HtmlCreate.getUserSearchListimage2(Lists, pageindex, Int32.Parse(OldPages), actype, Account);


                strret = strret + "；" + NewPages;
                context.Response.Write(strret);
                return;
            }
            #endregion 
            
             #region 用户搜索列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "usersearch")
            {
                String sid = Convert.ToString(context.Request.QueryString["sid"]);
                BLL.BLLuser bll = new BLL.BLLuser();
                BLL.BLLmenu bll2 = new BLL.BLLmenu();
                String keyword = Convert.ToString(context.Request.QueryString["keyword"]);
                String OldPageindex = Convert.ToString(context.Request.QueryString["persentpageindex"]);
                String OldPages = Convert.ToString(context.Request.QueryString["pages"]);
                String actype = Convert.ToString(context.Request.QueryString["actype"]);
                String orderby = Convert.ToString(context.Request.QueryString["orderby"]);


                String Account = (context.Session["useraccount"]).ToString();

                string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                  
                String content = "你搜索了作者: " + keyword;
                String actitle = "搜索" + keyword;
                String ctype = "search";
                int i2 = bll.InsertUserAction(Account, actitle, ctype, actime, content);

                int k = Int32.Parse(OldPages) - Int32.Parse(OldPageindex);
                String useraccount = (context.Session["useraccount"]).ToString();
                String strret = "";
                CreateHtml HtmlCreate = new CreateHtml();
                if (actype == "pre" && OldPageindex == "1")
                {
                    context.Response.Write(strret);
                    return;
                }
                else if (actype == "next" && k == 0)
                {
                    context.Response.Write(strret);
                    return;
                }
                IList<User> Lists;
                double Size = 8.0;
                String tablename = "user";
                //计算当前页面数
                String bywhat = " ";
                if (sid == "zh") {
                    bywhat = " Account='" + keyword + "'";
                }
                else if (sid == "yhm") {
                    bywhat = " UserName like '%" + keyword + "%'";
                }
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
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());


                bywhat=" SearchContent='"+keyword+"'";
                 int datacount2 = bll.GetDataCount(bywhat, "searchfever");
                 if (datacount2 == 0) { 
                      int rr = bll.searchfeverinsert(keyword,sid);
    
                 }else{
                  String fever = "";
                  IList<SearchFever> List2 = bll.GetSearchFever(keyword);
                  foreach (SearchFever i in List2) {
                       fever = i.Fever;
                  }
                  int ff = Int32.Parse(fever);
                  ff++;
                  int rr = bll.searchfeverupdate(keyword,ff.ToString());
                 } 
               
               
                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                Lists = bll.GetUserSearch(orderby,keyword, sid, (Int32)Size, dataindex);
               
                //如果数据页数改变
                if (Int32.Parse(OldPages) == 0 || Int32.Parse(OldPages) != NewPages)
                    strret = HtmlCreate.getUserSearchListimage(Lists, pageindex, NewPages, actype,useraccount);
                else
                    strret = HtmlCreate.getUserSearchListimage(Lists, pageindex, Int32.Parse(OldPages), actype,useraccount);
                context.Response.Write(strret);
                return;
            }
            #endregion 
            
           
            #region 获取搜索列表
            if (Convert.ToString(context.Request.QueryString["type"]) == "search")
            {
                String sid = Convert.ToString(context.Request.QueryString["sid"]);
                BLL.BLLuser bll = new BLL.BLLuser();
                BLL.BLLmenu bll2 = new BLL.BLLmenu();
                String keyword = Convert.ToString(context.Request.QueryString["keyword"]);
            
                String strret = "";
                myoperateClass ex = new myoperateClass();
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
                IList<SimpleMenu> Lists;
                double Size = 10.0;
                if(context.Session["useraccount"] != null){
                 String Account = (context.Session["useraccount"]).ToString();

                 string TimeMade = DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
                 String actime = TimeMade + "   " + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分";
                 String ht="";
                 if (sid == "sc") ht = "食材";
                 else if (sid == "zz") ht = "作者";
                 else if (sid == "cm") ht = "菜谱";
                 String content = "你搜索了"+ht+":" + keyword;
                 String actitle = "搜索" + keyword;
                 String ctype = "search";
                 int i = bll.InsertUserAction(Account, actitle, ctype, actime, content);
                 //int follownum = Int32.Parse((context.Session["follownum"]).ToString());
                 //String val = (follownum--).ToString();
                 //int r2 = bll.AlterSingleAttr("User", "FollowNum", val, " where Account='" + Account + "'");
                }
               

                String  bywhat = " SearchContent='" + keyword + "'";
                int datacount2 = bll.GetDataCount(bywhat, "searchfever");
                if (datacount2 == 0)
                {
                    int rr = bll.searchfeverinsert(keyword, sid);

                }
                else
                {
                    String fever = "";
                    IList<SearchFever> List2 = bll.GetSearchFever(keyword);
                    foreach (SearchFever i in List2)
                    {
                        fever = i.Fever;
                    }
                    int ff = Int32.Parse(fever);
                    ff++;
                    int rr = bll.searchfeverupdate(keyword, ff.ToString());
                } 
                 
                String att = "";
                String tablename = "mainmenus";
                if(sid=="sc"){
                    att = "IngredientName";
                    tablename = "ingredient";
                } else if (sid == "zz") {
                    att = " UserName";
                } else if (sid == "cm") {
                    att = " menuname";
                }
                bywhat = att + " like '%" + keyword + "%'";
                //计算当前页面数
                int datacount = bll.GetDataCount(bywhat, tablename);
                double x = datacount / Size;
                int NewPages = Int32.Parse(Math.Ceiling(x).ToString());

                //int presentindex = Int32.Parse(OldPageindex);
                int pageindex = Int32.Parse(OldPageindex);
                int dataindex = (Int32)Size * (pageindex - 1);
                
                
                if (datacount != 0)
                {
                    if (sid == "sc")
                    {

                        IList<Ingredient> IngredientLists = bll2.GetsimpleIngredientList(att, keyword, (Int32)Size, dataindex);
                        strret = ex.SearchListImage2(IngredientLists, pageindex, NewPages, actype, datacount, "submitsearch");
                    }
                    else if (sid == "cm")
                    {
                        Lists = bll2.GetsimpleMenuList(att, keyword, (Int32)Size, dataindex);
                        strret = ex.SearchListImage(Lists, pageindex, NewPages, actype, datacount, "submitsearch");
                    }
                }
                else
                {

                    strret += " <div class='searchlist'>";
                    strret += "  <div class='searchlisttitle'>";
                    strret += " <p class='searchlisttit'>暂无数据</p>";

                    strret += " </div>";
                    strret += "  <div class='alertcancle' onclick='alertcancle()'> 取消</div>";

                    strret += " </div>";


                } 
            
               
               
              

                context.Response.Write(strret);
                return;
            }
            #endregion 
            
 
            //if (Convert.ToString(context.Request.QueryString["type"]) == "getmenulist")//菜谱列表
            //{
            //    String val = Convert.ToString(context.Request.QueryString["val"]);
            //    myoperateClass ex = new myoperateClass();
            //      int Size=0;
            //      String urlstr = "";
            //    int index = 0;
            //    String strret = ex.indexMenuListImage(val,Size,urlstr,index);
            //    context.Response.Write(strret);
            //    return;
            //}
            
            
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