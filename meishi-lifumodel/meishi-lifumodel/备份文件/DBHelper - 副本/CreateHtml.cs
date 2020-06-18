using meishi_lifumodel.BLL;
using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace meishi_lifumodel.DBHelper
{
    public class CreateHtml
    {



       
        /// <summary>
        /// 传入要生成的表，内容包括：文件地址，菜品名称，Id
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// 

        #region 主页菜单列表
        public String createMainMenuList(String type,String value, int Size,int index)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            IList<Menu> menus = bll.GetMenuList(type, value, Size, index);
            string retstr = "";

            foreach (Menu menu in menus)
            {
                 retstr += "<div class='item'>";
                 retstr += "     <div class='product-thumb'>";
                 retstr += "       <div class='image2 product-imageblock'> <a href='#'>";
                 retstr += "     <img data-name='product_image' src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'>";
                 retstr += "  <img src='" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
                 retstr += "        <div class='caption product-detail text-left'>";
                 retstr += "          <h6 data-name='product_name' class='product-name mt_20'><a href='#' title='Casual Shirt With Ruffle Hem'>" + menu.Introduces + "</a></h6>";
                 retstr += "          <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x notcenter'></i></span> <span class='fa fa-stack'><i class='fa fa-star fa-stack-x'></i></span> </div>";
                 retstr += "           <span class='price'><span class='amount'><span class='currencySymbol'></span>" + menu.menuname + "</span>";
                 retstr += "           </span>";
                 retstr += "           <div class='button-group text-center'>";
                 retstr += "             <div class='wishlist'><a href='#'><span>wishlist</span></a></div>";
                 retstr += "             <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                 retstr += "             <div class='compare'><a href='#'><span>Compare</span></a></div>";
                 retstr += "             <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
                 retstr += "           </div>";
                 retstr += "        </div>";
                 retstr += "       </div>";
                 retstr += "    </div>";




            }
 
            return  retstr;
        }
        #endregion  

        //这个页面需要刷新两次
        #region 单个菜单详细页面
        public String GetSingleMenu(IList<Menu> siglemenu, String useraccount)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            BLLuser blluser = new BLLuser();
            String keyword = "";
            String menunumber = "";
            string retstr = "";
            //IList<Menu> siglemenu = bll.GetSingleMenu(val);
            


            foreach (Menu menu in siglemenu)
            {

                  keyword = menu.KeyWord;
                  menunumber = menu.MenuNumber;
                  int r1 = blluser.Collectcount(useraccount, menunumber);//判断是否已收藏
                 retstr += "  <div class='item product-layout product-list'>";
                 retstr += "  <div class='product-thumb'>";
                  retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                 retstr += "  <img src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
                  retstr += "   <div class='caption product-detail text-left'>";
                  retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>"+menu.menuname+"</a></h6>";
                   retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>"; 
                    retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                   retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                   retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                    retstr += "  <span class='price' id='scl'><span class='amount'><span class='currencySymbol'>已有</span>" + menu.Collection + " 人收藏</span>  </span>";
                    
                     retstr += "  <p class='product-desc mt_20'>"+menu.Introduces+"</p>";
                     retstr += "  <div class='wdcc'>";

                     retstr += "  <div class='wdc1'>";
                     retstr += " <div class='wdc2'> 2</div>";
                     retstr += " <div class='wdc3'>3</div>";
                     retstr += "  <div class='wdc3'>4</div>";

                     retstr += " <div class='wdc2'> 2</div>";
                     retstr += " <div class='wdc3'>3</div>";
                     retstr += "  <div class='wdc3'>4</div>";
                     //onclick='Ingredient('" + +"')'
                     retstr += "  <div > <a href='ingredients.html?val=" + menu.MainIngredient + " '>" + menu.MainIngredient + "的更多做法</a></div>";
                     retstr += "  	  </div>";
                      //retstr += "   <div class='days'></div>";
                      // retstr += "  <div class='hours'></div>";
                      // retstr += "  <div class='minutes'></div>";
                      // retstr += "  <div class='seconds'></div>";
                     retstr += "  </div>";
                     retstr += "  <div class='button-group text-center wdbb'>";
                     retstr += "  <div  id='sc'>";
                     if (r1 == 0) {    retstr += "   <div class='wishlist '><a href='#' onclick='shoucang(" + menu.Collection + ")'><span>wishlist</span></a></div>"; }
                     else { retstr += "   <div class='dislike' ><a href='#' onclick='shoucangdel(" + menu.Collection + ")'><span>wishlist</span></a></div>"; }
                     retstr += "  </div>";
                     
                       retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                       retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
                       retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
                    retstr += "   </div>";
                   retstr += "  </div>";
                 retstr += "  </div>";
               retstr += "  </div>";


            }

            IList<Menu> menus = bll.GetSimilarMenu(keyword, menunumber);
            foreach (Menu menu in menus)
            {

                retstr += "  <div class='item product-layout product-list'>";
                retstr += "  <div class='product-thumb'>";
                retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                retstr += "  <img src='" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
                retstr += "   <div class='caption product-detail text-left'>";
                retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>" + menu.menuname + "</a></h6>";
                retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>";
                retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                retstr += "  <span class='price'><span class='amount'><span class='currencySymbol'>$</span>70.00</span>";
                retstr += "  </span>";
                retstr += "  <p class='product-desc mt_20'> " + menu.Introduces + "</p>";
                retstr += "  <div class='wdcc'>";
                
                 retstr += "  <div class='wdc1'>";
        retstr += " <div class='wdc2'> 2</div>";
	   retstr += " <div class='wdc3'>3</div>";
	   retstr += "  <div class='wdc3'>4</div>";

	   retstr += " <div class='wdc2'> 2</div>";
	   retstr += " <div class='wdc3'>3</div>";
	   retstr += "  <div class='wdc3'>4</div>";
	   
	   retstr += "  	  </div>";
	 
	 
	 
 
                //retstr += "   <div class='days'></div>";
                //retstr += "  <div class='hours'></div>";
                //retstr += "  <div class='minutes'></div>";
                //retstr += "  <div class='seconds'></div>";
                retstr += "  </div>";
                retstr += "  <div class='button-group text-center wdbb'>";
                retstr += "   <div class='wishlist'><a href='#'><span>wishlist</span></a></div>";
                retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
                retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
                retstr += "   </div>";
                retstr += "  </div>";
                retstr += "  </div>";
                retstr += "  </div>";

            }
           
            return retstr;
           
        }
        #endregion
        



        #region  根据主食材获取其不同做法
        public String GetIngredientDetail(String val)
        {

            BLL.BLLmenu bll = new BLL.BLLmenu();
           
            string retstr = "";
            IList<Menu> siglemenu = bll.GetIngredientDetail(val);
            


            foreach (Menu menu in siglemenu)
            {
                  
                 retstr += "  <div class='item product-layout product-list'>";
                 retstr += "  <div class='product-thumb'>";
                  retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                 retstr += "  <img src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
                  retstr += "   <div class='caption product-detail text-left'>";
                  retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>"+menu.menuname+"</a></h6>";
                   retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>"; 
                    retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                   retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                   retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                     retstr += "  <span class='price'><span class='amount'><span class='currencySymbol'>$</span>70.00</span>";
                     retstr += "  </span>";
                     retstr += "  <p class='product-desc mt_20'>"+menu.Introduces+"</p>";
                     retstr += "  <div class='wdcc'>";

                     retstr += "  <div class='wdc1'>";
                     retstr += " <div class='wdc2'> 2</div>";
                     retstr += " <div class='wdc3'>3</div>";
                     retstr += "  <div class='wdc3'>4</div>";

                     retstr += " <div class='wdc2'> 2</div>";
                     retstr += " <div class='wdc3'>3</div>";
                     retstr += "  <div class='wdc3'>4</div>";
                     //onclick='Ingredient('" + +"')'
                     retstr += "  <div > <a href='ingredients.html?val=" + menu.MainIngredient + " '>" + menu.MainIngredient + "的更多做法</a></div>";
                     retstr += "  	  </div>";
                      //retstr += "   <div class='days'></div>";
                      // retstr += "  <div class='hours'></div>";
                      // retstr += "  <div class='minutes'></div>";
                      // retstr += "  <div class='seconds'></div>";
                     retstr += "  </div>";
                     retstr += "  <div class='button-group text-center wdbb'>";
                      retstr += "   <div class='wishlist'><a href='#'><span>wishlist</span></a></div>";
                       retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                       retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
                       retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
                    retstr += "   </div>";
                   retstr += "  </div>";
                 retstr += "  </div>";
               retstr += "  </div>";


            }

            return retstr;
           
        }

        #endregion
       
        
          #region  通过菜谱编号获取菜谱评论
        public String GetUserComment(String val)
        {

            BLL.BLLmenu bll = new BLL.BLLmenu();
           
            string retstr = "";
            IList<UserComment> comments = bll.GetUserComment(val);
            //UserComment commentlist = new UserComment();

            
            foreach (UserComment list in comments)
            {
              
             retstr +="    <div class='item'>";
	    	 retstr +=" <a  href='#'><img class='example-image' src='"+list.Picture+"' alt=''/></a>";
			 retstr +=" 	<div class='content-item'>";
			 retstr +=" 		<span class=time'><a class='btn btn-1'>More</a> SEPTEMBER 30TH</span>";
			 retstr +=" 		<h3 class='title-item'><a href='#'>Agfa</a></h3>";
           
            
	      
             //retstr += "  <p class='info' onclick='edit(this)'>" + list.Comment + "</p> ";
             IList<UserComment> comment = bll.GetUserComment2(list.CommentNumber);
             int i=comment.Count();
             if (i == 0)
             {
                 retstr += "      <div style='e2'>";
                 retstr += "  <p class='info' onclick='edit(this)'>" + list.Comment + "</p> ";
                 retstr += "  </div>";
             }
             else {
                 retstr += "      <div class='singlepllist'>";
                 retstr += "  <div style='position:absolute;right:0;top:40px' onclick='list(this)'>" + i + "回复</div>";
                 retstr += "  <p class='info' onclick='edit(this)'>" + list.Comment + "</p> ";
                 foreach (UserComment list2 in comment)
                 {
                   
                     retstr += "  <p class='info' onclick='edit(this)'>"+list2.UserName+"::"+list2.Comment + "</p> ";
                    
                 }
                 retstr += "  </div>";
             }
             
            
             //retstr +=" 		<ul class='list-inline'>";
             // retstr +=" 			<li><a href='#'><i class='fa fa-eye'></i> 260</a></li>";
             //    retstr +=" 		<li><a href='#'><i class='fa fa-comment'></i> 260</a></li>";
             //    retstr +=" 		<li><a href='#'><i class='fa fa-heart'></i> 260</a></li>";
             //    retstr +=" 		<li><a href='#'><i class='fa fa-share'></i> 260</a></li>";
             //    retstr +=" 	</ul>";
				 retstr +=" </div>";
				 retstr +=" <div class='bottom-item'>";
				 retstr +=" 	<a href='#' class='btn btn-share share'><i class='fa fa-share-alt'></i> Share</a>";
				 retstr +=" 	<span class='user f-right'>Posted by <a href='#'>"+list.UserName+"</a><img src='"+list.UserImg+"' class='img-circle'></span>";
			 retstr +=" 	</div>";
			 retstr +=" </div>";
                  
               


            }

            return retstr;
           
        }

        #endregion


        
            
        #region //用户关注的用户列表
        public String CreateUserPersonFollowImage(IList<UserCollections> Lists)
        {
            
            string retstr = "";


            foreach (UserCollections menu in Lists)
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
         #endregion
        #region //用户菜谱收藏列表
        public String CreateUserMenuCollectionImage( IList<UserCollections> Lists)
        {
            
            string retstr = "";
           

            foreach (UserCollections menu in Lists)
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
         #endregion

         #region //用户制作的菜谱列表
        public String  CreateUserProductionImage( IList<UserProductions> Lists)
        {
            
            string retstr = "";


            foreach (UserProductions menu in Lists)
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
         #endregion



         

        #region  获取主分类列表
        public String mainClassListImage()
        {
            BLL.BLLclassification bll = new BLL.BLLclassification();
            IList<Classification> menus = bll.GetClassificationList("全部分类");
           
            string retstr = "";


            foreach (Classification menu in menus)
            {
                retstr += "  <li><a href='#' title='" + menu.Classification_contents + "' target='_blank'>" + menu.Classification_contents + "</a></li>";
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
        public String createCollectionImage(string sclx,string UserNumber,int Size)//用户收藏列表
        {
             BLLuser blluser = new BLLuser();
             BLLmenu bllmenu = new BLLmenu();
            IList<UserCollections> menus = blluser.GetMenuCollection(sclx, UserNumber, Size);

            string retstr = "";
            if (menus.Count() == 0)
                return retstr;

            foreach (UserCollections menu in menus)
            {

                IList<Menu> Menu = bllmenu.GetMenudetail(menu.CollectionNumber);

                retstr += "                                <div style='float: left;padding: 10px;margin-left: 10px;'>";
                retstr += "                                       <img src='"+Menu[0].CoverImg+"' style='min-width: 150px;' /><br />";
                retstr += "                                   	<span style='color: #686868;'>"+Menu[0].menuname+"</span><br/>";
                retstr += "                                       <span style='color: #686868;margin-top: 23px;display:block;'>";
                if (Menu[0].status == "已删除")
                {
                    retstr += "  <img src='img/tennis-ball.png' style='margin-bottom: -2px; height:12px;width:12px;margin-left:30px ;' />";
                    retstr += "<font style='font-size: 12px;color: #505050;font-weight: bold; margin-left: 5px;'>宝贝失效了</font>";
                }
                else {
                    retstr += "                                     <div class='del' onclick='del(" + menu.CollectionNumber + "," + Menu[0].Collection + ")'>取消收藏</div>";
               
                }
               retstr += "                                </span> </div>";
                

            }
            
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
                   // else if(pro.Name=="UserNumber")   
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

 
     