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

































        #region create list data html

        /// <summary>
        /// 传入要生成的表，内容包括：文件地址，菜品名称，Id
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public String createListImage2(String type,int Size, String urlstr,int index)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            IList<Menu> menus = bll.GetMenu(type,Size,index);

            string retstr = "";
            //string scriptstr = "";
           

            //retstr += "                           <div class='data'>";
            foreach (Menu menu in menus)
            {
                String img = menu.CoverImg;
                //retstr += "                                <li >";
                retstr += "                                     <div class='data'>";
                //retstr += "                                        <img src='" + urlstr + dt.Rows[i]["文件地址"].ToString() + "' />";
                retstr += "                                          <img class='dataimg' src='"+ menu.CoverImg + "' />";
               
                retstr += "                                      <div class='datadetails'>";
                retstr += "                                        <h5 class='datatitle'>" + menu.menuname + "</h5>";
                retstr += "                                        <div class='datacontent'><a href='/zhu_caipinxinxiB.html?id=" + menu.MenuNumber  + "' class='works-btn'>查看 &gt;</a></div>";
                retstr += "                                      </div>";
                retstr += "                                     </div>";
               //retstr += "                               </li>";
                //scriptstr += "                                      <script>                       ";
                //scriptstr += "                                            var el, li;";
                //scriptstr += "                                         el = document.getElementById('thelist');";
                
                //scriptstr += "                                         li = document.createElement('li');";
                //scriptstr += "                                          li.innerHTML ='"+retstr+"';";
                //scriptstr += "                                   //alert('被执行l');";
                //scriptstr += "                                         el.appendChild(li, el.childNodes[0]);";

                //scriptstr += "                                            </script>";


                //all = retstr + scriptstr;
                
           
            }
           // retstr += "                          </div>";
            return retstr;
        }


        #region  获取主页主分类列表
        public String mainClassListImage()
        {
            BLL.BLLclassification bll = new BLL.BLLclassification();
            IList<Classification> menus = bll.GetClassificationList("主页分类");
           
            string retstr = "";


            foreach (Classification menu in menus)
            {
                retstr += "  <li><a href='#' title='" + menu.Classification_contents + "' target='_blank'>" + menu.Classification_contents + "</a></li>";
            }
 
            return retstr;
        }
        #endregion 获取分类列表  
        #region  获取历史足迹 
        public String getHistoricalRecordimage(IList<usernotices> Lists)
        {
             
            string retstr = "";


            foreach (usernotices menu in Lists)
            {
                retstr += "<div class='xfitem'>";

                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>号</div>";
                retstr += "<div class='zmml2'>像</div>";
                retstr += "<div class='zmml3'>用户名</div>";
                retstr += " <div class='zmml4'>级</div>";
                retstr += " <div class='zmml5'>注</div>";
                retstr += "</div>";


                retstr += "   </div>";
            }
 
            return retstr;
        }
        #endregion 获取分类列表  
        
        #region  获取新提示
        public String getNewNoticeimage(IList<usernotices> Lists)
        {
            BLL.BLLuser bll = new BLL.BLLuser();
          

            string retstr = "";


            foreach (usernotices menu in Lists)
            {
                retstr+="<div class='xfitem'>";

                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>号</div>";
                retstr += "<div class='zmml2'>像</div>";
                retstr += "<div class='zmml3'>用户名</div>";
                retstr += " <div class='zmml4'>级</div>";
                retstr += " <div class='zmml5'>注</div>";
                retstr += "</div>";
                    
                    
                 retstr+="   </div>";
            }

            return retstr;
        }
        #endregion 获取分类列表 
 
        #region  获取陌生用户列表
        public String getStrangerListimage(IList<usernotices> Lists)
        {
           

            string retstr = "";


            foreach (usernotices list in Lists)
            {
                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>号</div>";
                retstr += "<div class='zmml2'>像</div>";
                retstr += "<div class='zmml3'>用户名</div>";
                retstr += " <div class='zmml4'>级</div>";
                retstr += " <div class='zmml5'>注</div>";
                retstr += "</div>";
            }

            return retstr;
        }
        #endregion 获取分类列表 

        #region  获取分类列表 
        public String ClassificationListImage(String type)
        {
            BLL.BLLclassification bll = new BLL.BLLclassification();
            IList<Classification> menus = bll.GetClassificationList(type);
            String bt="";
            int i = 0;
            string retstr = "";
            

            foreach (Classification menu in menus)
            {
                retstr += "                          <li> ";
                retstr += "  <p class='sxf1'>" + menu.Classification_contents + "</p>";
                IList<Classification> menu2 = bll.GetClassificationList(menu.Classification_contents);
                foreach (Classification menu3 in menu2)
                {
                    retstr += "   <a href='wdzj.html?type=" + menu3.Classification_contents + "' title='' target='_blank'>" + menu3.Classification_contents + "</a>";
                }
                retstr += "                          </li> ";
              //  if (bt != menu.Category_parent)
              //  {
              //      if (i != 0) {

              //          retstr += "                          </li> ";
              //          i = 1;
              //      }
                   
              //      retstr += "                          <li> ";
              //      retstr += "  <p class='sxf1'>" + menu.Category_parent + "</p>";
              //  }
               
              //retstr += "   <a href='#' title='' target='_blank'>" + menu .Classification_contents+ "</a>";
 
            }
            
           
            return retstr;
        }
    #endregion 获取分类列表

         #region 主页菜谱列表
        public String indexMenuListImage(String type, int Size, String urlstr, int index)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            IList<Menu> menus = bll.GetMenu(type,Size,index);
            string retstr = "";
            int i=0;
            foreach (Menu menu in menus)
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


        public String createListImage(String type, int Size, String urlstr,int index)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            IList<Menu> menus = bll.GetMenu(type,Size,index);
        
            string retstr = "";



            //retstr += "                           <div class='data'>";
            foreach (Menu menu in menus)
            {
                String img = menu.CoverImg;
                retstr += "<li> ";
                retstr += "  <a href='#'  title='８元汉堡 全天爆单' target='_blank' class='gbco1ig'>";
                retstr += " <img src='picture/201901281531223754335.jpg' alt=''></a>";
                retstr += "  <div class='gbco1dv gbco1dv1'>";
                retstr += "  <label class='gbco1lb'>汉堡</label>";
                retstr += "  <a href='#'  title='' target='_blank'>麦塔基汉堡</a>";
                retstr += "  <p>额度：3-5万</p>";
                retstr += "  <p>８元汉堡 全天爆单</p>";
                retstr += "   <a href='#'  title='８元汉堡 全天爆单' target='_blank' class='gbco1ck'>立即查看</a> </div>";
                retstr += "  </li>";






                //以前的
               // retstr += "                                <li>";
               // //retstr+="                              <a href='introduce
               // retstr += "                                    <div class='data' onclick='tz("+menu.MenuNumber+")'>";
               // // retstr += "                                        <img src='" + urlstr + dt.Rows[i]["文件地址"].ToString() + "' />";
               // retstr += "                                          <img class='dataimg' src='" + menu.CoverImg + "' />";

               // retstr += "                                      <div class='datadetails'>";
               // retstr += "                                        <h5 class='datatitle'>" + menu.menuname + "</h5>";
               // retstr += "                                        <div class='datacontent'><a href='introduces.html?id=" + menu.MenuNumber + "' class='works-btn'>查看 &gt;</a></div>";
               // retstr += "                                      </div>";
               // retstr += "                                     </div>";
               //retstr += "                               </li>";
            }
            // retstr += "                          </div>";
            return retstr;
        }

        #endregion end of  create list data html


        public String createPageImage(string menunumber,string usernumber,string tableflag)
        {
            BLLuser blluser = new BLLuser();
            string retstr = "";
            if (tableflag == "User")
            {
                IList<UserProductions> menu = blluser.GetUserSingleProduction(usernumber, menunumber);

                retstr += "                               <div class='menuImg'>";
                retstr += "                                       <img src='" + menu[0].FoodImg + "'  />";
                retstr += "                               </div>";
                retstr += "                               <div class='jibenjs'>";
                retstr += "                               </div>";
                retstr += "                                <div class='jieshao'>";
                retstr += "                                       <h1>菜品介绍</h1>";
                retstr += "                                       <div class='menujieshao'>" + menu[0].FoodIntroduce + "</div>";
                retstr += "                                        <h1>需要材料</h1>";
                retstr += "                                        <ul class='shicai'>";
                String cl = menu[0].FoodMatrials;
                String[] ingredient = cl.Split('/');
                for (int i = 0; i < ingredient.Length; i++)
                {
                    retstr += "                                            <li>" + ingredient[i].ToString() + "</li>";
                }
                retstr += "                                          </ul>";


                retstr += "                                  </div>";



            }
            else {
                BLL.BLLmenu bll = new BLL.BLLmenu();
                IList<Menu> menus = bll.GetMenudetail(menunumber);


                int r1 = blluser.Collectcount(usernumber, menunumber);//判断是否已收藏

               



                //retstr += "                           <div class='data'>";
                foreach (Menu menu in menus)
                {
                    IList<User> user = bll.GetUserinfo(menu.ProducerNumber, "NotAll");

                    //String img = menu.CoverImg;
                    retstr += "                               <div class='menuImg'>";
                    retstr += "                                       <img src='" + menu.CoverImg + "'  />";
                    retstr += "                               </div>";
                    retstr += "                               <div class='jibenjs'>";

                    retstr += "                                     <div class='line1'> <h3 >" + menu.menuname + "</h3><div id='scl'> <p class='scl'> 收藏量：" + menu.Collection + "</p></div></div>";
                    retstr += "                                     <div class='line2'><p class='zzname'> 作者:" + user[0].UserName + "</p>";
                    retstr += "                                                        <div class='zzimg'>";
                    retstr += "                                                               <img src='" + user[0].UserImg + "' />";
                    retstr += "                                                        </div>";
                    retstr += "                                     </div>";
                    if (r1 == 0) { retstr += "                                 <div id='sc'>    <div class='line3' onclick='shoucang(" + menu.Collection + ")'>点击收藏</div> </div>"; }
                    else { retstr += "                                         <div id='sc'>    <div class='line3' onclick='shoucangdel(" + menu.Collection + ")'>取消收藏</div> </div> "; }
                    retstr += "                               </div>";
                    retstr += "                                <div class='jiesha'>";
                    retstr += "                                       <h1>菜品介绍</h1>";
                    retstr += "                                       <div class='menujieshao'>" + menu.Introduces + "</div>";
                    retstr += "                                        <h1>需要材料</h1>";
                    retstr += "                                        <ul class='shicai'>";
                    String cl = menu.ingredients;
                    String[] ingredient = cl.Split('/');
                    for (int i = 0; i < ingredient.Length; i++)
                    {
                        retstr += "                                            <li>" + ingredient[i].ToString() + "</li>";
                    }
                    retstr += "                                          </ul>";


                    retstr += "                                  </div>";

                }
                // retstr += "                          </div>";
            
            }
            
            return retstr;
        }
        //

        public String createUserProductionImage(string UserNumber, int Size)//查看用户作品
        {
             BLLuser blluser = new BLLuser();
           
            IList<UserProductions> menus = blluser.GetUserProduction(UserNumber, Size);

            string retstr = "";
            if (menus.Count() == 0)
                return retstr;
                   



            //retstr += "                           <div class='data'>";
            foreach (UserProductions menu in menus)
            {

                
				retstr += " 	   <div style='border:1px solid #ccc;height: 150px;margin-top: 20px;'>";
				retstr += " 	   <input name='店铺' type='checkbox' value='' style='margin-top: 20px;margin-left: 20px;' />";
				retstr += " 		<div>";
                retstr += " 	    	<img src='" + menu.FoodImg + "' style='margin-left:40px; float: left;height:110px;width:100px' onclick=showdetail('" + menu.UserFoodNumber + "')/>";
				retstr += " 	    </div>	";
				retstr += " 	    <div>";
                retstr += " 	    	<span style='margin-left:15px;float: left;'><font style='font-size: 12px;color: #1f1f1f; '>" + menu.FoodName + "</font>";
				retstr += " 	    		<font style='font-size: 12px;color: #949494;margin-left: 230px;TEXT-DECORATION: line-through; '>22.8</font>";
                retstr += " 	    		<br/> <font style='font-size: 12px;color: #1f1f1f; '>" + menu.FoodIntroduce + "</font>";
				retstr += " 	    		<font style='font-size: 12px;color: #1f1f1f;margin-left: 340px;font-weight: bold;  '>15.90</font>";
				retstr += " 	    		<br/>";
				retstr += " 	    	<img src='img/购物车/矢量智能对象.png' style='margin-left:0px; float: left;' />";
				retstr += " 	    	<button style='color:F88600;background-color: #FCE6D1;border: 1px #F88600 solid;width:80px ;margin-left: 430px;'>卖家促销</button>";
				retstr += " 	    	</span>";
				retstr += " 			<span style=''margin-left:35px;float: left; '>";
				retstr += " 				<input type='button' value='-' style=' color:#333333;height:30px;width:20px;border-style:solid;margin-left:30px;'></input><input type='text' value='1' style=' color:#333333;height:30px;width:30px;text-align:center;'></input><input type='button' value='+' style=' color:#333333;height:30px;width:20px;border-style:solid;'></input>";
				retstr += " 			</span>";
				retstr += " 			<span style='margin-left:10px;float: left;'>";
                retstr += "           <font style='font-size: 14px;color: #FD3C0D;margin-left: 85px;font-weight: bold;  '>15.90</font>";
				retstr += " 			</span >";
                retstr += " 			<span style='margin-left:85px; float: left;'><font style='font-size: 14px;color: #1E1E1E; ' onclick='edit(" + menu.UserFoodNumber + ")'>修改作品</font>";
                retstr += "           <br/> <font style='font-size: 14px;color: #1E1E1E; '  onclick='del(" + menu.UserFoodNumber + ")'>删除</font>";
				retstr += " 			</span>";
				retstr += " 	    </div>";

                retstr += " 	  </div>";



                //retstr += "                               <div class='MenuCollection' id='"+menu.UserFoodNumber+"'>";
                //retstr += "                                       <img src='"+menu.FoodImg+"' class='MCImg' onclick=showdetail('"+menu.UserFoodNumber+"') />";
                //retstr += "                                   <div class='introduce'>     <h1>"+menu.FoodName+"</h1>";
                //retstr += "                                       <h2>"+menu.FoodIntroduce+"</h2> </div>";
                //retstr += "                                     <div class='del' onclick='del("+menu.UserFoodNumber+")'>删除作品</div>";
                //retstr += "                                     <div class='del' onclick='edit(" + menu.UserFoodNumber + ")'>修改作品</div>";
                //retstr += "                                </div>";
                

            }
            // retstr += "                          </div>";
            return retstr;
           
        }
       
        //end

        #region 后台数据读取
        public String UserManagement(string sclx, int Size)
        {
            BLLuser blluser = new BLLuser();
            IList<User> users = blluser.GetUserlist(Size);
            string retstr = "";
                   retstr += "                      <div class='card'>";
                   retstr+="                                 <div class='header'>";
                   retstr+="                                         <h4 class='title'>User Table</h4>";
                   retstr+="                                        <p class='category'>Here is a subtitle for this table</p>";
                   retstr+="                                  </div> "; 
                   retstr+="                                  <div class='content table-responsive table-full-width'>";
                   retstr+="                                   <table class='table table-striped' >";
                   retstr+="                                                        <thead>";
            PropertyInfo[] pros = typeof(User).GetProperties();
             foreach (PropertyInfo pro in pros)
                {
                    string a=pro.Name;
                   retstr+="                     <th>"+pro.Name+"</th>";
                }
             retstr += "  </thead>";
             retstr += "                              <tbody>";
            foreach (User menu in users)
            {
               
               
                retstr += "                                      <tr id='"+menu.Account+"' onclick='selected("+menu.Account+")'>";
                retstr += "                                   <td>"+menu.UserName+"</td>";
               // retstr += "                                   <td>"+menu.UserNumber+"</td>";
                retstr += "                                   <td>"+menu.Account+"</td>";

                retstr += "                                   <td>"+menu.PassWord+"</td>";
                retstr += "                                   <td>"+menu.PhoneNumber+"</td>";
                retstr += "                                   <td>"+menu.UserImg+"</td>";
                
                   

            }    
                retstr+=" </tbody>";
                retstr += " </table>";
                retstr += " </div>";
                retstr += " </div>";
            return retstr;
        }
        public String EditorLoad(string tableflag, string number) {
            string retstr="";
            if (tableflag == "User"&&number!="") {
                
                BLL.BLLmenu bll = new BLL.BLLmenu();
                IList<User> user = bll.GetUserinfo(number, "NotAll");
                
                PropertyInfo[] pros = typeof(User).GetProperties();
           
                retstr += "<h1>用户信息编辑</h1>";
                
        
                foreach (PropertyInfo pro in pros)
                {
                    
                    
                    retstr+="<div class='line'>";
                    retstr+="<label class='bq' >"+pro.Name+"</label>";
                    retstr+=" <input id='"+pro.Name+"' value='";
                    if(pro.Name=="UserName")
                        retstr+=user[0].UserName+"' /> ";
                  //  else if(pro.Name=="UserNumber")   
                      //  retstr+=user[0].UserNumber+"' /> ";
                    else if (pro.Name == "Account")
                        retstr += user[0].Account + "' /> ";
                    else if (pro.Name == "PassWord")
                        retstr += user[0].PassWord + "' /> ";
                    else if (pro.Name == "PhoneNumber")
                        retstr += user[0].PhoneNumber + "' /> ";
                    else if (pro.Name == "UserImg")
                        retstr += user[0].UserImg + "' /> ";
                    
                    retstr+="</div>";
                    
                   
                }
                    retstr+="<div class='Editorfoot'>";
                    retstr += "<div class='editorsubmit'onclick='submit('edit')'>提交</div>";
                    retstr+="</div>";


            
            }
            else if (tableflag == "User" && number == "")
            {
                retstr += "<h1>添加用户</h1>";
                PropertyInfo[] pros = typeof(User).GetProperties();


                foreach (PropertyInfo pro in pros)
                {


                    retstr += "<div class='line'>";
                    retstr += "<label class='bq' >" + pro.Name + "</label>";
                    retstr += " <input id='" + pro.Name + "' />";

                       

                    retstr += "</div>";


                }
                retstr += "<div class='Editorfoot'>";
                retstr += "<div class='editorsubmit'onclick='submit('add')'>提交</div>";
                retstr += "</div>";

            }
            return retstr;

           
        
        
        
        
        } 
        
        #endregion
    }
}

 //<li>
                
 //               <div class="hh" style="height:100px;width:100px;background:red" onclick="tz(1)"></div>
 //           </li>


     