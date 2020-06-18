using meishi_lifumodel.BLL;
using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace meishi_lifumodel.DBHelper
{
    public class myoperateClass
    {

         
        #region  获取头部导航
        public String createHeadNavigationImage(IList<Classification> Lists)
        {
           
         
            string retstr = "";

            
            foreach (Classification list in Lists)
            {
                //if (list.Category_parent == "HeadNavigation")
                
                    retstr += "  <li><a href='#' title='" + list.Classification_contents + "' onclick='getIndexMiddle(&quot;" + list.Navigation + "&quot;)'>" + list.Classification_contents + "</a></li>";
        
                
            }
 
            return retstr;
        }
        #endregion    

        #region  获取数据下方分页  
        public String getDataBottomimage(String function, int presentindex, int pages, String actype,String sid, String sval)
        {

            int prepresentindex = presentindex - 1;


            int nextpresentindex = presentindex + 1;


            string retstr = "";

            retstr += " <div class='userDaTabottom'> ";
            retstr += "   <div class='DataBottom'>";
            retstr += "<div class='DataBottominner'>";
            retstr += "<span class='presentindex'>" + presentindex + "</span><span class='pages'>/" + pages + "</span></div>";

            retstr += "<div class='zcbq' onclick='" + function + "(0," + pages + "," + prepresentindex + ",&quot;pre&quot;,&quot;" + sid + "&quot;,&quot;" + sval + "&quot;)'></div>";
            retstr += "<div class='zcbh' onclick='" + function + "(0," + pages + "," + nextpresentindex + ",&quot;next&quot;,&quot;" + sid + "&quot;,&quot;" + sval + "&quot;)'></div>";

              
           

            retstr += "</div> ";
            retstr += "</div> ";

            return retstr;
        }
        #endregion
        
        #region  获取用户信息
        public String getNewNoticeimage(IList<UserNotices> Lists)
        {
            BLL.BLLuser bll = new BLL.BLLuser();


            string retstr = "";

            
            foreach (UserNotices menu in Lists)
            {
                retstr += " <div class='userjminnercontent'>";

                retstr += "  <div class='usernoticestitle'>";
                retstr += " <p class='noticetit'>通知</p>";
                retstr += " <p class='noticetit'>私信</p>";
                retstr += " </div>";
               retstr += " <div class='usernoticeslist'>";
               retstr += " <p class='noticecon'> ";
               retstr += "  </p>";
               retstr += " <p class='noticecon'>私信</p>";
               retstr += "  </div>";
               retstr += " </div>";
            }

            return retstr;
        }
        #endregion  
 
         
         #region  获取搜索列表
        public String SearchListImage2( IList<Ingredient>  Lists,int presentindex,int pages,String actype,int datacount,string function)
        { 
            string retstr = "";
            String sval = "";
            retstr += " <div class='searchlist'>";
            retstr += "  <div class='searchlisttitle'>";
            retstr += " <p class='searchlisttit'>共为您找到"+datacount+"条记录</p>"; 
            retstr += " </div>";
            foreach (Ingredient l in Lists)
            { 
               retstr += " <div class='searchlistitem' onclick='getingredientdetails(&quot;IngredientNumber&quot;,&quot;" + l.IngredientNumber + "&quot;)'>";
               retstr += " <img src='/images/" + l.CoverImg + "' /> "; 
               retstr += " <p class='itemname'>"+l.IngredientName+"</p>";
               sval = l.IngredientName;
               retstr += "  </div>"; 
            }
            retstr += "  <div class='alertcancle' onclick='alertcancle()'> 取消</div>";  
            retstr += " </div>";
            
           String retstrbottom = getDataBottomimage("submitsearch", presentindex, pages, actype,"sc",sval);

            retstr = retstr + retstrbottom;
            return retstr;
        }
        #endregion   
        
       #region  获取搜索列表
        public String SearchListImage(IList<SimpleMenu> Lists,int presentindex,int pages,String actype,int datacount,string function)
        {
             
            
            string retstr = "";
            String sval = "";
            retstr += " <div class='searchlist'>";
            retstr += "  <div class='searchlisttitle'>";
            retstr += " <p class='searchlisttit'>共为您找到"+datacount+"条记录</p>";
           
            retstr += " </div>";
            foreach (SimpleMenu menu in Lists)
            {

                retstr += " <div class='searchlistitem' onclick='getmenudetails(&quot;notuserproduction&quot;,&quot;" + menu.MenuNumber + "&quot;)'>";
                retstr += " <img src='/images/MenuAll/" + menu.CoverImg + "' /> ";
               sval = menu.MenuName;
               retstr += " <p class='itemname'>"+menu.MenuName+"</p>";
               retstr += "  </div>";
             
            }
          retstr += "  <div class='alertcancle' onclick='alertcancle()'> 取消</div>"; 
          
            retstr += " </div>";

              String retstrbottom = getDataBottomimage("submitsearch", presentindex, pages, actype,"cm",sval);

            retstr = retstr + retstrbottom;
           
          //  String bottom = getDataBottomimage(function, presentindex, pages, actype);
            return retstr;
        }
        #endregion   
      
        
         #region  获取分类列表 
        public String ClassificationListImage2(IList<Classification> Lists, String type)
        {
            BLL.BLLclassification bll = new BLL.BLLclassification();
           // IList<Classification> menus = bll.GetClassificationList(type);
            BLL.BLLuser bll2 = new BLL.BLLuser();
           // String tablename = "menu_classification";
            IList<Classification> menu;
            string retstr = "";
            String hh = "";
            int k=0;
            foreach (Classification  list in Lists)
            {
                //String bywhat = " Category_parent='" + list.Classification_contents + "'";
                //int r1 = bll2.GetDataCount(bywhat, tablename);
                
               


                  retstr += "   	              <li class='menu-item-has-children'>";
                  retstr += "   						<a href='#'>" + list.Classification_contents + "</a>";
				   retstr += "   						<ul>";
                   menu = bll.GetClassificationList(list.Classification_contents);
                   foreach (Classification list2 in menu)
                   {
                        if (type == "饮食健康" || type == "菜谱大全") {
                           // hh += " <p class='sxf1' >" + list2.Classification_contents + "</p>";
                            retstr += "<li  onclick='getmenulistbytype(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;Type&quot;)'><a href='#'><i class='ht-foodie-046'></i> " + list2.Classification_contents + "</a></li>";
                   
                        } else if(type=="食材大全"){
                           // hh += " <p class='sxf1' onclick='getingredientbyname(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;IngredientName&quot;)'>" + list2.Classification_contents + "</p>";
                            retstr += "<li  onclick='getingredientbyname(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;IngredientName&quot;)'><a href='#' ><i class='ht-foodie-046'></i> " + list2.Classification_contents + "</a></li>";
                   
                        } else if (type == "菜谱属性") {
                           // hh += " <p class='sxf1' onclick='getmenulistbysx(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;MenuGY&quot;)'>" + list2.Classification_contents + "</p>";
                            retstr += "<li  onclick='getmenulistbysx(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;MenuGY&quot;)'><a href='#'><i class='ht-foodie-046'></i> " + list2.Classification_contents + "</a></li>";
                   
                        
                        }
                          
                   }

                     //retstr += "   						<li><a href='#'><i class='ht-foodie-046'></i> Home</a></li>";
                     //retstr += "   						<li><a href='#'><i class='ht-foodie-055'></i> Home 2</a></li>";
                     //retstr += "   						<li><a href='#'><i class='ht-foodie-063'></i> Home 3</a></li>";
						 retstr += "   				</ul>";
                         retstr += "   			</li>";  
            }
            
           
            return retstr;
        }
    #endregion  




        #region  获取分类列表 
        public String ClassificationListImage(IList<Classification> Lists,String type)
        {
            BLL.BLLclassification bll = new BLL.BLLclassification();
           // IList<Classification> menus = bll.GetClassificationList(type);
            BLL.BLLuser bll2 = new BLL.BLLuser();
            String tablename = "menu_classification";
            IList<Classification> menu;
            string retstr = "";
            String hh = "";
            int k=0;
            foreach (Classification  list in Lists)
            {
                String bywhat = " Category_parent='" + list.Classification_contents + "'";
                int r1 = bll2.GetDataCount(bywhat, tablename);
                
               
                if (r1 > 20) retstr += "                          <div class='classblock' style='width:1500px'> ";
                else{
                 retstr += "                          <div class='classblock' style='width:30%'> ";
                }
               
                retstr += "  <p class='sxf1tit'>" + list.Classification_contents + "</p>";
               
                // String bywhat = "UserName";
                
               
                if (r1 != 0)
                {
                    menu = bll.GetClassificationList(list.Classification_contents);
                    foreach (Classification list2 in menu)
                    {
                        if (type == "饮食健康" || type == "菜谱大全") {
                            hh += " <p class='sxf1' onclick='getmenulistbytype(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;Type&quot;)'>" + list2.Classification_contents + "</p>";
                   
                        } else if(type=="食材大全"){
                            hh += " <p class='sxf1' onclick='getingredientbyname(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;IngredientName&quot;)'>" + list2.Classification_contents + "</p>";
                        } else if (type == "菜谱属性") {
                            hh += " <p class='sxf1' onclick='getmenulistbysx(&quot;" + list2.Category_parent + "&quot;,&quot;" + list2.Classification_contents + "&quot;,&quot;MenuGY&quot;)'>" + list2.Classification_contents + "</p>";
                        
                        }
                    }
                   //hh =ClassificationListImage(menu);
                   retstr += hh;
                   hh = "";
                }
               
                retstr += "                          </div> ";
              
                 
                
 
            }
            
           
            return retstr;
        }
    #endregion  

         #region 主页菜谱列表
        public String indexMenuListImage(String type, int Size, String urlstr, int index)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            IList<SimpleMenu> menus = bll.GetMenu(type,Size,index);
            string retstr = "";
            int i=0;
            foreach (SimpleMenu menu in menus)
            {
                if(i==0){
                  retstr +=" <div style='padding:10px ;text-align: center;float: left;'>";
                }
                retstr += "<div style='float: left;margin-left: 20px;background-color: #fff;'> ";
                retstr += "<img src='img/kuzi.png' />";
                retstr += "<p style='width: 180px;'></p>  ";
                //retstr += "<span style='display: block;float: left;margin-left: 10px;color: #f78642;font-size: 12px;'>¥156</span> ";
				retstr += "<del style='margin-left: -100px;margin-top: 10px;color: #949494;'>¥189</del>";							
				retstr += "<dl style='text-align: left;margin-left: 10px;color: #686868;'>2016秋季新款季新款牛仔季新款牛</dl>";									
				retstr += "<dl>广东佛山</dl> ";		
				retstr += "<input type='button' value='找相似' style='color:#949494;background-color:#fff ;border:1px #ccc solid;padding: 2px;width: 70px;margin-top: 10px;margin-bottom: 20px;' />";
		        retstr += "</div> ";
                i++;
								
                if(i==5){
                  retstr +=" </div>";
                  i = 0;
                }
                
 
            }
             
            return retstr;
        }
         #endregion 获取分类列表

 
    }
}

 