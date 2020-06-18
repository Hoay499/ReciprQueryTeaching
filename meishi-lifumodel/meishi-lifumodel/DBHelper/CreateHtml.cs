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
        public String createMainMenuListimage(IList<MenuAll> Lists, String valtype, int presentindex, int pages)
        {
            BLL.BLLclassification bll = new BLL.BLLclassification();
            IList<Classification> classList = bll.GetClassificationList(valtype);
            int i = 0;
            int k = 0;
            string retstr = ""; 
            string retstrbottom = "";
            // retstr += "<div class='col-lg-12'>";
            foreach (MenuAll list in Lists)
            {
                    if (i ==0 &&k==0)
                    {
                        k = 1;
                        retstr += " <div class='item active'>";
                    }
                    else if(i==4) {
                        retstr += " </div>";
                        retstr += " <div class='item'>";
                        i = 0;
                    }
                    retstr += "<article  class='box-shadow'>";
                    retstr += "		<div class='no-gutter'>";
                    if(i==0||i==2){
                        retstr += "			<div class='col-sm-6 fix-right'>";
                     }else{
                           retstr += "			<div class='col-sm-6'>";
                     }
                   
                    retstr += "				<div class='box-image'>";
                    retstr += "					<img src='../../images/MenuAll/"+list.CoverImg+"'>";
                    retstr += "				</div>";
                    retstr += "			</div>";
                    retstr += "			<div class='col-sm-6'>";
                    retstr += "				<div class='art-content text-center'>";
                    retstr += "					<div class='heading'>";
                    retstr += "						<h2>"+list.MenuName+"</h2>";
                    retstr += "						<hr class='line'>";
                    retstr += "					</div>";
                    retstr += "					<p class='wdjs1'>" + list.Introduces + "</p>";
                    retstr += "					<a class='btn btn-theme' onclick='getmenudetails(&quot;notuserproduction&quot;,&quot;" + list.MenuNumber + "&quot;)'>Continue learning...</a>";
                    retstr += "				</div>";
                    retstr += "			</div>";
                    retstr += "		</div>";
                    retstr += "	</article>";
                    i++;    
                  
            }
            if (i !=4)
            {
                retstr += " </div><div class='item'><img src='images/zwsj.png' style='heigt:100%;width:100%'/></div>";
            }
            else {
                retstr += "</div>";
            }

            if(Lists.Count()==0){

                retstr = " <div><img src='images/zwsj.png' style='heigt:100%;width:100%'/></div>";
                
            }
           // retstr += "</div>";
            String classlist = "";
            
            foreach (Classification list in classList)
            {
                classlist += "  <li>";
                classlist += "	<a href='#'  onclick='getmenulist(&quot;" + valtype + "&quot;,&quot;" + list.Classification_contents + "&quot;, &quot;Type&quot;,1)'>";
                classlist += "		<i class='fa fa-tags'></i>";
                classlist += "		<span>" + list.Classification_contents + "</span>";
                classlist += "	</a>";
                classlist += "</li>";
				 
            }

            
                retstr = retstr + "$" + classlist;
            
            //retstrbottom = getDataBottomimage("gethysq", presentindex, pages, actype);
            
          

            return retstr;
        }
        #endregion  

        //#region 主页菜单列表old
        //public String createMainMenuList(String type,String value, int Size,int index)
        //{
        //    BLL.BLLmenu bll = new BLL.BLLmenu();
        //    IList<MenuAll> menus = bll.GetMenuList(type, value, Size, index);
        //    string retstr = "";

        //    foreach (MenuAll menu in menus)
        //    {
        //         retstr += "<div class='item'>";
        //         retstr += "     <div class='product-thumb'>";
        //         retstr += "       <div class='image2 product-imageblock'> <a href='#'>";
        //         retstr += "     <img data-name='product_image' src='"+menu.CoverImg+"' alt='iPod Classic' title='iPod Classic' class='img-responsive'>";
        //         retstr += "  <img src='" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
        //         retstr += "        <div class='caption product-detail text-left'>";
        //        // retstr += "          <h6 data-name='product_name' class='product-name mt_20'><a href='#' title='Casual Shirt With Ruffle Hem'>" + menu.Introduces + "</a></h6>";
        //         retstr += "          <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x notcenter'></i></span> <span class='fa fa-stack'><i class='fa fa-star fa-stack-x'></i></span> </div>";
        //         retstr += "           <span class='price'><span class='amount'><span class='currencySymbol'></span>" + menu.MenuName + "</span>";
        //         retstr += "           </span>";
        //         retstr += "           <div class='button-group text-center'>";
        //         retstr += "             <div class='wishlist'><a href='#'><span>wishlist</span></a></div>";
        //         retstr += "             <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
        //         retstr += "             <div class='compare'><a href='#'><span>Compare</span></a></div>";
        //         retstr += "             <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
        //         retstr += "           </div>";
        //         retstr += "        </div>";
        //         retstr += "       </div>";
        //         retstr += "    </div>";




        //    }
 
        //    return  retstr;
        //}
        //#endregion  
        #region 获取当前菜谱的不同工艺做法
        public String GetMenuByOtherPracticesImage(IList<MenuAll> siglemenu, String useraccount, String MenuGYListImg)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            BLLuser blluser = new BLLuser();

            String menunumber = "";
            string retstr = "";
            //IList<Menu> siglemenu = bll.GetSingleMenu(val);
            int r1 = 0;


            foreach (MenuAll menu in siglemenu)
            {


                if (useraccount != "")
                {
                    menunumber = menu.MenuNumber;
                    r1 = blluser.Collectcount(useraccount, menunumber);//判断是否已收藏
                }
              
                retstr += "  <div class='item product-layout product-list' id='" + menu.MenuNumber + "'>";

                retstr += "  <div class='product-thumb'>";
                retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='../../images/MenuAll/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                retstr += "  <img src='../../images/MenuAll/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
                retstr += "   <div class='caption product-detail text-left'>";
                retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>" + menu.MenuName + "</a></h6>";
                retstr += "  <div class='button-group text-center wdbb'>";
                retstr += "  <div  id='sc'>";
                if (r1 == 0) { retstr += "   <div class='wishlist '><a href='#' onclick='shoucang(" + menu.Collection + ")'><span>wishlist</span></a></div>"; }
                else { retstr += "   <div class='dislike' ><a href='#' onclick='shoucangdel(" + menu.Collection + ")'><span>wishlist</span></a></div>"; }
                retstr += "  </div>";
                retstr += "   </div>";
                retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>";
                retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                retstr += "  <span class='price' id='scl'><span class='amount'><span class='currencySymbol'>已有</span>" + menu.Collection + " 人收藏</span>  </span>";

                retstr += "  <p class='product-desc mt_20'>" + menu.Introduces + "</p>";
                retstr += "  <div class='wdcc'>";

                retstr += "  <div class='wdc1'>";
                retstr += " <div class='wdc2'>分量：" + menu.MenuFL + "人份</div>";
                retstr += " <div class='wdc3'>工艺: " + menu.MenuGY + "</div>";
                retstr += "  <div class='wdc3'>口味： " + menu.MenuKW + "</div>";

                retstr += " <div class='wdc2'>难度: " + menu.MenuND + "</div>";
                retstr += " <div class='wdc3'>烹饪用时: " + menu.CookingTime + "分钟</div>";
                retstr += "  <div class='wdc3'>准备时间: " + menu.PreparationTime + "</div>";
                //onclick='Ingredient('" + +"')'
                retstr += "  <div > <a href='ingredients.html?val=" + menu.MenuMainIngredient + " '>" + menu.MenuMainIngredient + "的更多做法</a></div>";

                BLLuser bll2 = new BLLuser();
                IList<User> user = bll2.getUser(menu.ProducerNumber);

                foreach (User u in user)
                {
                    retstr += " <div class='wdc2'> 账号：" + u.Account + "</div>";
                    retstr += " <div class='wdc2'>收藏：" + u.CollectionNum + "</div>";
                    retstr += " <div class='wdc2'>关注度：" + u.FollowersNum + "</div>";
                    retstr += " <div class='wdc2'>作品：" + u.AllProductionNum + "</div>";
                    retstr += " <div class='wdc2'>头像：" + u.UserImg + "</div>";
                    retstr += " <div class='wdc2'>用户名：" + u.UserName + "</div>";
                    retstr += " <div class='wdc2'>等级：" + u.UserLevel + "</div>";


                }
                retstr += "  	  </div>";
                //retstr += "   <div class='days'></div>";
                // retstr += "  <div class='hours'></div>";
                // retstr += "  <div class='minutes'></div>";
                // retstr += "  <div class='seconds'></div>";
                retstr += MenuGYListImg;

                retstr += "  </div>";
                retstr += "  </div>";

                //retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                // retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
                // retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
               // retstr += "              <div class='owl-nav'>";
               // retstr += "  <div class='owl-prev disabled'>prev</div>";
 
               //retstr += "  <div class='owl-next' onclick='GetMenuByIdenticalGY(&quot;" + menu.MenuNumber + "&quot;,&quot;" + menu.MenuName + "&quot;,&quot;" + menu.MenuGY + "&quot;)'>next</div>";
                 
               // retstr += "  </div>";

                retstr += "  </div>";
                retstr += "  <div class='item product-layout product-list'></div>";

            }



            return retstr;

        }
        #endregion
        #region 单个菜单详细页面
        public String GetIdenticalGYMenuImage(IList<MenuAll> siglemenu, String useraccount, String MenuNumberList, String MenuGYListImg)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            BLLuser blluser = new BLLuser();
           
            String menunumber = "";
            string retstr = "";
            //IList<Menu> siglemenu = bll.GetSingleMenu(val);
            int r1 = 0;
            
            
            foreach (MenuAll menu in siglemenu)
            {
               
                
                  if (useraccount != "") {
                      menunumber = menu.MenuNumber;
                      r1 = blluser.Collectcount(useraccount, menunumber);//判断是否已收藏
                  }
                    if (MenuNumberList!="")
                        MenuNumberList = MenuNumberList + "/" + menu.MenuNumber;
                    retstr += "  <div class='item product-layout product-list' id='" + menu.MenuNumber + "'>";
                  
                    retstr += "  <div class='product-thumb'>";
                    retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='../../images/MenuAll/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                    retstr += "  <img src='../../images/MenuAll/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> </div>";
                    retstr += "   <div class='caption product-detail text-left'>";
                    retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>"+menu.MenuName+"</a></h6>";
                    retstr += "  <div class='button-group text-center wdbb'>";
                    retstr += "  <div  id='sc'>";
                    if (r1 == 0) { retstr += "   <div class='wishlist '><a href='#' onclick='shoucang(" + menu.Collection + ")'><span>wishlist</span></a></div>"; }
                    else { retstr += "   <div class='dislike' ><a href='#' onclick='shoucangdel(" + menu.Collection + ")'><span>wishlist</span></a></div>"; }
                    retstr += "  </div>";
                    retstr += "   </div>";
                    retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>"; 
                    retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                    retstr += "  <span class='price' id='scl'><span class='amount'><span class='currencySymbol'>已有</span>" + menu.Collection + " 人收藏</span>  </span>";
                    
                     retstr += "  <p class='product-desc mt_20'>"+menu.Introduces+"</p>";
                     retstr += "  <div class='wdcc'>";

                     retstr += "  <div class='wdc1'>";
                     retstr += " <div class='wdc2'>分量："+menu.MenuFL+"人份</div>";
                     retstr += " <div class='wdc3'>工艺: "+menu.MenuGY+"</div>";
                     retstr += "  <div class='wdc3'>口味： "+menu.MenuKW+"</div>";

                     retstr += " <div class='wdc2'>难度: "+menu.MenuND+"</div>";
                     retstr += " <div class='wdc3'>烹饪用时: "+menu.CookingTime+"分钟</div>";
                     retstr += "  <div class='wdc3'>准备时间: " + menu.PreparationTime + "</div>";
                     //onclick='Ingredient('" + +"')'
                     retstr += "  <div > <a href='ingredients.html?val=" + menu.MenuMainIngredient + " '>" + menu.MenuMainIngredient + "的更多做法</a></div>";

                     BLLuser bll2 = new BLLuser();
                     IList<User> user = bll2.getUser(menu.ProducerNumber);

                     foreach (User u in user)
                     {
                         retstr += " <div class='wdc2'> 账号：" + u.Account + "</div>";
                         retstr += " <div class='wdc2'>收藏：" + u.CollectionNum + "</div>";
                         retstr += " <div class='wdc2'>关注度：" + u.FollowersNum + "</div>";
                         retstr += " <div class='wdc2'>作品：" + u.AllProductionNum + "</div>";
                         retstr += " <div class='wdc2'>头像：" + u.UserImg + "</div>";
                         retstr += " <div class='wdc2'>用户名：" + u.UserName + "</div>";
                         retstr += " <div class='wdc2'>等级：" + u.UserLevel + "</div>";
                         
                             
                     }
                     retstr += "  	  </div>";
                      //retstr += "   <div class='days'></div>";
                      // retstr += "  <div class='hours'></div>";
                      // retstr += "  <div class='minutes'></div>";
                      // retstr += "  <div class='seconds'></div>";
                     retstr += MenuGYListImg;

                   retstr += "  </div>";
                 retstr += "  </div>";

                 //retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                 // retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
                 // retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
                    //retstr += "              <div class='owl-nav'>";
                    //retstr += "  <div class='owl-prev disabled'>prev</div>";
                    
                    // if(MenuNumberList=="")
                    //    retstr += "  <div class='owl-next' onclick='GetMenuByIdenticalGY(&quot;" + menu.MenuNumber + "&quot;,&quot;" + menu.MenuName + "&quot;,&quot;" + menu.MenuGY + "&quot;)'>next</div>";
                    // else
                    //     retstr += "  <div class='owl-next' onclick='GetMenuByIdenticalGY(&quot;" + MenuNumberList + "&quot;,&quot;" + menu.MenuName + "&quot;,&quot;" + menu.MenuGY + "&quot;)'>next</div>";
                    
                    //retstr += "  </div>";
                                                 
                 retstr += "  </div>";
                 retstr += "  <div class='item product-layout product-list'></div>";
                  
            }

            
           
            return retstr;
           
        }
        #endregion
       
        public String creatematerials(String mainsc,String fl){
            String menuMaterials = "";
           

                menuMaterials += "<div class='materailbox'>";

                menuMaterials += "  <div class='mainmaterail'>";
                menuMaterials += " <p class='mtit'>主料</p>";
                String[] ZList = mainsc.Split(',');//主料list
                foreach (String s in ZList)
                {
                    String[] h = s.Split('|');
                    menuMaterials += " <p class='mcont'>";
                    for (int i = 0; i < h.Length; i++)
                    {
                        if (i == 0) menuMaterials += "<a href='ingredients.html?val=" + h[0] + "&&itype=IngredientName'>" + h[0] + ">></a>";
                        else menuMaterials += h[i] + "     ";
                    }
                    menuMaterials += "       </p>";
                }
                menuMaterials += "</div>";
                menuMaterials += " <div class='fumaterial'><p class='mtit'>辅料</p>";
                ZList = fl.Split(',');//辅料list
                foreach (String s in ZList)
                {
                    String[] h = s.Split('|');//
                    menuMaterials += " <p class='mcont'>";
                    foreach (String s2 in h)
                    {
                        menuMaterials += s2 + "     ";
                    }
                    menuMaterials += "       </p>";
                }
                menuMaterials += "</div></div>";




            return menuMaterials;
        }

        public String createsteps(String steps,String t)
        {
            String menuSteps = "";
            


                String[] StepsList = steps.Split('$');//步骤list
                int k = 400 * StepsList.Length;
                menuSteps += "<div class='StepsListbox'><div class='steptitle'>共<span id='bzsl'>" + StepsList.Length + "</span>步</div>";
                menuSteps += "    <div class='StepsList' id='StepsList' style='width:" + k.ToString() + "px ! important'> ";
                int stepi = 1;
                foreach (String s in StepsList)
                {
                    String[] h = s.Split('#');//
                    menuSteps += " <div class='stepcont'><p class='stepind'>" + stepi + ".</p>";
                    for (int i = 0; i < h.Length; i++)
                    {
                        if (i == 0) menuSteps += "<p class='steptit'>" + h[0] + "</p>";
                        else {
                            if (t == "userp")
                            {
                                menuSteps += " <img src='/images/" + h[i] + "'/> ";
                            }
                            else {
                                menuSteps += " <img src='/images/MenuAll/" + h[i] + "'/> ";
                            }
                           
                        }
                    }
                    menuSteps += "       </div>";
                    stepi++;
                }





                menuSteps += "   </div></div>";




         
            return menuSteps;
        }
         


         

        //  #region 单个用户菜单详细页面
        //public String GetSingleMenuEditImage(IList<MenuAll> siglemenu)
        //{
             
        //    string retstr = "";
        //    //IList<Menu> siglemenu = bll.GetSingleMenu(val);


        //    foreach (MenuAll menu in siglemenu)
        //    {



                   
        //            retstr += "  <div class='item product-layout product-list' id='"+menu.MenuNumber+"'>";
        //            retstr += "             <input  id='MenuNumber' style='display:none;' value='" + menu.MenuNumber + "'/>";
        //            retstr += "             <input  id='MenuName2' style='display:none;' value='" + menu.MenuName + "'/>";
        //            retstr += "  <div class='product-thumb'>";
        //            retstr += "   <div class='image product-imageblock'> <div style='background-image:url(&quot;../../images/" + menu.CoverImg + "&quot;)' class='myp1'> <form action=''><input  id='menuimg'  type='file' /></form></div>  ";
        //            //retstr += "  <img src='../../images/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> ";
        //            retstr += "    <p class='menuylzf' onclick='getmenuMaterials()'> 用料</p><p class='menuylzf' onclick='getmenuSteps()'> 做法</p>";
        //            retstr += "      </div>"; 
        //            retstr += "   <div class='caption product-detail text-left'>";
        //            retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'><input  id='MenuName'  value='" + menu.MenuName + "'/></a></h6>";
        //            retstr += "  <div class='button-group text-center wdbb'>"; 
                   
        //            retstr += "   </div>";
        //            retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>"; 
        //            retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
        //            retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
        //            retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
        //            retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
        //            retstr += "  <span class='price' id='scl'><span class='amount'><span class='currencySymbol'>已有</span>" + menu.Collection + " 人收藏</span>  </span>";

        //            retstr += "  <p class='product-desc mt_20'><textarea  id='Introduces'  value='" + menu.Introduces + "'></textarea></p>";
                    
                    
                    
        //             retstr += "  </div>";

                   

        //           retstr += "  </div>";
        //         retstr += "  </div>";

             
                                                 
        //         retstr += "  </div>";
        //         retstr += "  <div class='item product-layout product-list'> <p class='submitone' onclick='submitone()'>上传菜谱信息</div>";
                 
                 
        //    }
            
            
           
        //    return retstr;
           
        //}
        //#endregion

            
        #region 单个用户菜单详细页面
        public String GetSingleUserMenuImage(IList<UserProductions> siglemenu)
        {
             
            string retstr = "";
            //IList<Menu> siglemenu = bll.GetSingleMenu(val);
            
            
            foreach (UserProductions menu in siglemenu)
            {
               
                
                 
                  
                    retstr += "  <div class='item product-layout product-list' id='"+menu.MenuNumber+"'>";
                    retstr += "             <input  id='MenuNumber' style='display:none;' value='" + menu.MenuNumber + "'/>";
                    retstr += "             <input  id='MenuName' style='display:none;' value='" + menu.MenuName + "'/>";
                    retstr += "  <div class='product-thumb'>";
                    retstr += "   <div class='image product-imageblock'> <div style='background-image:url(&quot;../../images/" + menu.CoverImg + "&quot;)' class='myp1'></div>  ";
                    //retstr += "  <img src='../../images/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> ";
                    retstr += "    <p class='menuylzf' onclick='getmenuMaterials()'> 用料</p><p class='menuylzf' onclick='getmenuSteps()'> 做法</p>";
                    retstr += "      </div>"; 
                    retstr += "   <div class='caption product-detail text-left'>";
                    retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>"+menu.MenuName+"</a></h6>";
                    retstr += "  <div class='button-group text-center wdbb'>"; 
                   
                    retstr += "   </div>";
                    retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>"; 
                    retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                    retstr += "  <span class='price' id='scl'><span class='amount'><span class='currencySymbol'>已有</span>" + menu.Collection + " 人收藏</span>  </span>";
                    
                     retstr += "  <p class='product-desc mt_20'>"+menu.Introduce+"</p>";
                    
                    



                    
                     retstr += "  </div>";







                   

                   retstr += "  </div>";
                   retstr += "  </div>";

             
                                                 
                 retstr += "  </div>";
                 retstr += "  <div class='item product-layout product-list'></div>";

                
                 retstr += "<div class='newposition'> <div class='wdcc'>";

                 retstr += "  <div class='wdc1'>";
                 retstr += " <div class='wdc2'>分量：" + menu.menuFL + "人份</div>";
                 retstr += " <div class='wdc3'>工艺: " + menu.MenuGY + "</div>";
                 retstr += "  <div class='wdc3'>口味： " + menu.MenuKW + "</div>";

                 retstr += " <div class='wdc2'>难度: " + menu.MenuND + "</div>";
                 retstr += " <div class='wdc3'>烹饪用时: " + menu.CookingTime + "分钟</div>";
                 retstr += "  <div class='wdc3'>准备时间: " + menu.PreparationTime + "</div>";
                 //onclick='Ingredient('" + +"')'
                 //retstr += "  <div > <a href='ingredients.html?val=" + menu.MenuMainIngredient + " '>" + menu.MenuMainIngredient + "的更多做法</a></div>";
                 BLLuser bll2 = new BLLuser();
                 IList<User> user = bll2.getUser(menu.Account);

                 foreach (User u in user)
                 {
                     retstr += " <div class='menuuser' onclick='userdetails(&quot;" + u.Account + "&quot;)'>";
                     retstr += " <div class='menuusertx'><img src='" + u.UserImg + "'/></div>";
                     retstr += " <div class='menuusername'>" + u.UserName + "</div>";
                     retstr += " <p >关注度：" + u.FollowersNum + " / </p>   ";
                     retstr += " <p>作品：" + u.AllProductionNum + " / </p>";
                     retstr += " <p >收藏：" + u.CollectionNum + "  </p>";

                     retstr += " <p >" + u.JoinTime + "   /</p>";
                     retstr += " <p >" + u.UserLevel + "</p>";
                     retstr += " </div>";

                 }

                 retstr += "  	  </div> </div>";

                  
                


                 
            }
            
            
           
            return retstr;
           
        }
        #endregion

        //这个页面需要刷新两次
        #region 单个菜单详细页面
        public String GetSingleMenuImage(IList<MenuAll> siglemenu, String useraccount, IList<MenuPractices> OtherPractices)
        {
            BLL.BLLmenu bll = new BLL.BLLmenu();
            BLLuser blluser = new BLLuser();
            String menuMaterials = "";
            String menuSteps = "";
            String menunumber = "";
            string retstr = "";
            //IList<Menu> siglemenu = bll.GetSingleMenu(val);
            int r1 = 0;
                
            String MenuGYListImg = "";
            foreach (MenuAll menu in siglemenu)
            {
               
                
                  if (useraccount != "") {
                      menunumber = menu.MenuNumber;
                      r1 = blluser.Collectcount(useraccount, menunumber);//判断是否已收藏
                  }
                  
                    retstr += "  <div class='item product-layout product-list' id='"+menu.MenuNumber+"'>";
                    retstr += "             <input  id='MenuNumber' style='display:none;' value='" + menu.MenuNumber + "'/>";
                    retstr += "             <input  id='MenuName' style='display:none;' value='" + menu.MenuName + "'/>";
                    retstr += "  <div class='product-thumb'>";
                    retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='/images/MenuAll/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                    retstr += "  <img src='/images/MenuAll/" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> ";
                    retstr += "    <p class='menuylzf' onclick='getmenuMaterials()'> 用料</p><p class='menuylzf' onclick='getmenuSteps()'> 做法</p>";
                    retstr += "      </div>"; 
                    retstr += "   <div class='caption product-detail text-left'>";
                    retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>"+menu.MenuName+"</a></h6>";
                    retstr += "  <div class='button-group text-center wdbb'>"; 
                    retstr += "  <div  id='sc'>";
                    if (r1 == 0) { retstr += "   <div class='wishlist ' onclick='shoucang(&quot;" + menu.MenuName + "&quot;,&quot;" + menu.MenuNumber + "&quot;," + menu.Collection + ")'><a href='#' ><span>wishlist</span></a></div>"; }
                    else { retstr += "   <div class='dislike' onclick='shoucangdel(&quot;" + menu.MenuName + "&quot;,&quot;" + menu.MenuNumber + "&quot;," + menu.Collection + ")'><a href='#' ><span>wishlist</span></a></div>"; }
                    retstr += "  </div>";
                    retstr += "   </div>";
                    retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>"; 
                    retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
                    retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
                    retstr += "  <span class='price' id='scl'><span class='amount'><span class='currencySymbol'>已有</span>" + menu.Collection + " 人收藏</span>  </span>";
                    
                     retstr += "  <p class='product-desc mt_20'>"+menu.Introduces+"</p>";
                     retstr += "  <div class='elsezuofa'>";
                    // MenuGYListImg += "&quot;<div class='elsezuofa'>";
                     foreach (MenuPractices op in OtherPractices)
                     {
                        // MenuGYListImg += " <p class='OtherPracticestit' >共有其他工艺的做法" + OtherPractices.Count() + "种</p>";
                       //  MenuGYListImg += "<p class='OtherPractices' onclick='GetSingleMenu(&quot;" + menu.MenuNumber + "&quot;)'>" + op.MenuGY + "</p></div>&quot;";
                         retstr += " <p class='OtherPracticestit' >共有其他工艺的做法" + OtherPractices.Count() + "种</p>";
                        // retstr += " <div style='display:none' id='MenuGYListImg' >" + MenuGYListImg + " </div>";
                         retstr += " <p class='OtherPractices' onclick='GetMenuByOtherPractices(&quot;" + menu.MenuNumber + "&quot;,&quot;"+menu.KeyWord+"&quot;,&quot;"+op.MenuGY+"&quot;)'>" + op.MenuGY + "</p>";
                     }
                                                           
                     retstr += "   </div>";
                     retstr += "  <div class='wdcc'>";

                     retstr += "  <div class='wdc1'>";
                     retstr += " <div class='wdc2'>分量："+menu.MenuFL+"人份</div>";
                     retstr += " <div class='wdc3'>工艺: "+menu.MenuGY+"</div>";
                     retstr += "  <div class='wdc3'>口味： "+menu.MenuKW+"</div>";

                     retstr += " <div class='wdc2'>难度: "+menu.MenuND+"</div>";
                     retstr += " <div class='wdc3'>烹饪用时: "+menu.CookingTime+"分钟</div>";
                     retstr += "  <div class='wdc3'>准备时间: " + menu.PreparationTime + "</div>";
                     //onclick='Ingredient('" + +"')'
                    //retstr += "  <div > <a href='ingredients.html?val=" + menu.MenuMainIngredient + " '>" + menu.MenuMainIngredient + "的更多做法</a></div>";
                     BLLuser bll2 = new BLLuser();
                     IList<User> user = bll2.getUser(menu.ProducerNumber);
                     
                     foreach (User u in user)
                     {
                         retstr += " <div class='menuuser' onclick='userdetails(&quot;" + u.Account + "&quot;)'>";
                         retstr += " <div class='menuusertx'><img src='" + u.UserImg + "'/></div>";
                          retstr += " <div class='menuusername'>" + u.UserName + "</div>";
                         retstr += " <p >关注度：" + u.FollowersNum + " / </p>   ";
                         retstr += " <p>作品：" + u.AllProductionNum + " / </p>";
                         retstr += " <p >收藏：" + u.CollectionNum + "  </p>";

                         retstr += " <p >" + u.JoinTime + "   /</p>";
                         retstr += " <p >" + u.UserLevel + "</p>";
                        retstr += " </div>";

                     }     
              
                retstr += "  	  </div>";
                      //retstr += "   <div class='days'></div>";
                      // retstr += "  <div class='hours'></div>";
                      // retstr += "  <div class='minutes'></div>";
                      // retstr += "  <div class='seconds'></div>";
                     retstr += "  </div>";

                   

                   retstr += "  </div>";
                 retstr += "  </div>";

                 //retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
                 // retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
                 // retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
                    //retstr += "              <div class='owl-nav'>";
                    //retstr += "  <div class='owl-prev disabled'>prev</div>";
                     
                    //    retstr += "  <div class='owl-next' onclick='GetMenuByIdenticalGY(&quot;" + menu.MenuNumber + "&quot;,&quot;" + menu.KeyWord + "&quot;,&quot;" + menu.MenuGY + "&quot;)'>next</div>";
                   
                    //retstr += "  </div>";
                                                 
                 retstr += "  </div>";
                 retstr += "  <div class='item product-layout product-list'></div>";



                  
                   menuMaterials += "<div class='wdcc'>";

                   menuMaterials += "  <div class='wdc1'>";
                   menuMaterials += " <div class='wdc2'><p class='mtit'>主料</p>";
                   String[] ZList = menu.MenuMainIngredient.Split(',');//主料list
                  foreach (String s in ZList){
                       String[] h=s.Split('|');
                      menuMaterials += " <p class='mcont'>";
                       for (int i=0;i<h.Length;i++){
                           if (i == 0) menuMaterials += "<a href='ingredients.html?val=&quot;" + h[0] + "&quot;&&itype=&quot;IngredientName&quot;'>" + h[0] + "  更多做法>></a>"; 
                            else menuMaterials += h[i]+"     ";
                       }
                      menuMaterials += "       </p>";
                  }
                  menuMaterials += "</div>";
                 menuMaterials += " <div class='wdc2'><p class='mtit'>辅料</p>";
                    ZList = menu.MenuFuliao.Split(',');//辅料list
                  foreach (String s in ZList){
                       String[] h=s.Split('|');//
                      menuMaterials += " <p class='mcont'>";
                       foreach (String s2 in h){
                            menuMaterials += s2+"     ";
                       }
                      menuMaterials += "       </p>";
                  }
                  menuMaterials += "</div></div>";

                 String[] StepsList = menu.MenuMainIngredient.Split('$');//步骤list
                  menuSteps += "<div class='StepsList'> <p class='steptitle'>共"+StepsList.Length+"步</p>";
                   int stepi=1;
                     foreach (String s in StepsList){
                            String[] h=s.Split('#');//
                            menuSteps += " <div class='stepcont'>" + stepi;
                           for(int i=0;i<h.Length;i++){
                               if (i == 0) menuSteps += "<p class='steptit'>" + h[0] + "</p>";
                               else menuSteps += " <img src='/images/MenuAll/" + h[i] + "'/> ";
                             }
                             menuMaterials += "       </div>";
                             stepi++;
                     } 
                
                    
                      
                    
                      
                  menuSteps +="   </div>";



                 
            }
            
            
           
            return retstr;
           
        }
        #endregion

        
        #region 菜谱用料
        public String GetMenuMaterialsImage(IList<MenuAll> siglemenu)
        {

            String menuMaterials = "";
            foreach (MenuAll menu in siglemenu)
            {

              
                menuMaterials += "<div class='materailbox'>";

                menuMaterials += "  <div class='mainmaterail'>";
                menuMaterials += " <p class='mtit'>主料</p>";
                String[] ZList = menu.MenuMainIngredient.Split(',');//主料list
                foreach (String s in ZList)
                {
                    String[] h = s.Split('|');
                    menuMaterials += " <p class='mcont'>";
                    for (int i = 0; i < h.Length; i++)
                    {
                        if (i == 0) menuMaterials += "<a href='ingredients.html?val=" + h[0] + "&&itype=IngredientName'>" + h[0] + ">></a>";
                        else menuMaterials += h[i] + "     ";
                    }
                    menuMaterials += "       </p>";
                }
                menuMaterials += "</div>";
                menuMaterials += " <div class='fumaterial'><p class='mtit'>辅料</p>";
                ZList = menu.MenuFuliao.Split(',');//辅料list
                foreach (String s in ZList)
                {
                    String[] h = s.Split('|');//
                    menuMaterials += " <p class='mcont'>";
                    foreach (String s2 in h)
                    {
                        menuMaterials += s2 + "     ";
                    }
                    menuMaterials += "       </p>";
                }
                menuMaterials += "</div></div>"; 



            }



            return menuMaterials;

        }
        #endregion
        //这个页面需要刷新两次
        #region 菜谱步骤
        public String GetMenuStepsImage(IList<MenuAll> siglemenu)
        {

            String menuSteps = "";
            foreach (MenuAll menu in siglemenu)
            {



 
                
                String[] StepsList = menu.MenuSteps.Split('$');//步骤list
                int k = 400 * StepsList.Length;
                menuSteps += "<div class='StepsListbox'><div class='steptitle'>共<span id='bzsl'>" + StepsList.Length + "</span>步</div>";
                menuSteps += "    <div class='StepsList' id='StepsList' style='width:" + k.ToString() + "px ! important'> ";
                int stepi = 1;
                foreach (String s in StepsList)
                {
                    String[] h = s.Split('#');//
                    menuSteps += " <div class='stepcont'><p class='stepind'>" + stepi + ".</p>";
                    for (int i = 0; i < h.Length; i++)
                    {
                        if (i == 0) menuSteps += "<p class='steptit'>" + h[0] + "</p>";
                        else menuSteps += " <img src='/images/menuall/" + h[i] + "'/> ";
                    }
                    menuSteps += "       </div>";
                    stepi++;
                }





                menuSteps += "   </div></div>";




            }



            return menuSteps;

        }
        #endregion
       
         #region 菜谱搭配
        public String GetIngredientTabooImage(string img, string iname, IList<IngredientTaboo> foodtaboo)
        {

            String menuMaterials = "";
            foreach (IngredientTaboo l in foodtaboo)
            {

              
              

                menuMaterials += "  <div class='mainmaterail'>";
                menuMaterials += " <p class='mtit'><img src='../../images/" + img + "'/> " + iname + "</p>";

                menuMaterials += " <p class='mtitadd'> + </p>";
                menuMaterials += " <p class='mtit'> <img src='../../images/" + l.TabooImg + "'/> ";
                menuMaterials += "<a href='ingredients.html?val=" + l.TabooNumber + "&&itype=IngredientNumber'>" + l.TabooNamer + ">></a>";
                     
                    menuMaterials += "       </p>";
                    menuMaterials += " <p class='mtit' ><a href='index.html?MenuNumber=" + l.MenuNumber + "&tt=notuserproduction'>查看菜谱>></a></p>";
                    menuMaterials += " <p class='mtiteff'> " + l.Effect + "</p>";
                   
                menuMaterials += "</div>";
              



            }


            return menuMaterials;

        }
        #endregion
        
        #region 菜谱选购
        public String GetIngredientChoose(IList<Ingredient> sigleingredient)
        {

            String menuMaterials = "";
            foreach (Ingredient l in sigleingredient)
            {

              
                menuMaterials += "<div class='materailbox'>";

                menuMaterials += "  <div class='mainmaterail'>";
                menuMaterials += " <p class='mtit'>食材选购</p>";
               
                    menuMaterials += " <p class='mcont'>"+l.Choose+" </p>";
                      menuMaterials += "</div>";
                  menuMaterials += "</div>";
                }
               
               


         


            return menuMaterials;

        }
        #endregion


        

        #region  根据编号获取食材信息
        public String GetIngredientDetailAdmin(IList<Ingredient> sigleingredient)
        {

            
           
            string retstr = "";
            



            foreach (Ingredient l in sigleingredient)
            {

                retstr += "  <div class='sccocn'> ";
                retstr += "                   <input type='text' id='MenuName' name='MenuName'  value='"+l.IngredientName+"' style='display:none' />  ";
                
               retstr += "         <div class='scimgconleft'> ";  
                retstr += "             <form id='sctp' action='/ashx/Adminhandler.ashx' method='post' enctype='multipart/form-data'> ";
                retstr += "                   <input type='text' id='type' name='type'  value='sctpup' style='display:none' runat= 'server' />  ";
                retstr += "                  <input type='file' name='imginput' id='imginput' accept='image/*'  runat= 'server' />  ";
                retstr += "                  <img src='../../images/"+l.CoverImg+"' class='sssss' id='scimg'>  ";
                                
                      
                       
                retstr += "                   <input type='text' id='ingnumber' name='ingnumber'  value='"+l.IngredientNumber+"' style='display:none' runat= 'server' />";
                         
               retstr += "              </form>";

               retstr += "         </div>";
                retstr += "       <div class='simpline'> ";
             retstr += "    <div class='pline1'>";
              retstr += "                 <span data-name='product_name' class='product-name'>食材名称</span>";
              retstr += "      <input type='text' id='scname' placehodler='食材名称' value='" + l.IngredientName + "'></div></div>  ";
                    
                    
                retstr += "       <div class='scimgconright'>  <div class='pline'>";
                 retstr += "          <span data-name='product_name' class='product-name'>食材介绍</span>";
                 retstr += "          <textarea id='scjsinput' placehodler='食材介绍' >" + l.IngredientIntroduction + "</textarea></div>";
                   retstr += "          <div class='pline'> ";
                     retstr += "            <span data-name='product_name' class='product-name'>食用价值</span>";
                     retstr += "             <textarea id='syjzinput' placehodler='食用价值'  >" + l.EdibleEffect + "</textarea></div> ";
                   retstr += "         <div class='pline'>";
                     retstr += "           <span data-name='product_name' class='product-name'>营养价值</span>";
                     retstr += "             <textarea id='yyjzinput' placehodler='营养价值' >" + l.NutritiveValue + " </textarea></div> ";
                         
                    retstr += "        <div class='pline'>";
                     retstr += "           <span data-name='product_name' class='product-name'>禁忌</span>";
                     retstr += "           <textarea id='jjinput' placehodler='禁忌'  > " + l.Negatives + "</textarea></div>  ";
                    retstr += "       <div class='pline'><span data-name='product_name' class='product-name'>小妙招</span>";
                    retstr += "            <textarea id='xmzinput' placehodler='小妙招'  >" + l.CookingTips + "</textarea></div>  	  </div> ";
                   retstr += "    <div class='submit' onclick='submit(&quot;alter&quot;,&quot;"+l.IngredientNumber+"&quot;)'>上传</div> ";
                   retstr += "    <div class='submit2' onclick='back()'>返回</div> ";
                   retstr += "    <div class='submit3' onclick='submit(&quot;del&quot;,&quot;"+l.IngredientNumber+"&quot;)'>删除</div> ";
                retstr += "   </div>";


            }

            return retstr;
           
        }

        #endregion
        #region  根据编号获取食材信息
        public String GetIngredientDetail(IList<Ingredient> sigleingredient)
        {

            
           
            string retstr = "";
            



            foreach (Ingredient l in sigleingredient)
            {
                  
                 retstr += "  <div class='item product-layout product-list'>";
                 retstr += "  <div class='product-thumb'>";
                 retstr += "             <input  id='MenuName' style='display:none;' value='" + l.IngredientName + "'/>";
                 retstr += "   <div class='hhhymg'> <div class='hhdic' onclick='getrelavantmenu(&quot;" + l.IngredientName + "&quot;,0,0,1,1)'> <img  src='../../images/" + l.CoverImg + "' alt='点击查看相关菜谱' title='点击查看相关菜谱' > </div>";
                 retstr += "   ";
                
               //  retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='../../images/Ingredient/" + l.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
                // retstr += "  <img src='../../images/" + l.CoverImg + "' alt='点击查看相关菜谱' title='点击查看相关菜谱' class='img-responsive' onclick='getrelavantmenu(&quot;" + l.IngredientName + "&quot;,0,0,1,1)'> </a> ";
                  //retstr += "    <p class='menuylzf'> </p><p class='menuylzf'></p>";
                  retstr += "    <p class='menuylzf' onclick='gettaboo(&quot;" + l.IngredientNumber + "&quot;)'> 搭配</p><p class='menuylzf' onclick='getchoose(&quot;" + l.IngredientNumber + "&quot;)'> 选购</p>";
                                     
                   retstr += "    </div>";
                  retstr += "   <div class='caption product-detail text-left'>";
                  // retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>"+l.IngredientName+"</a></h6>";


                   retstr += "     <h6 data-name='product_name' class='product-name'>食材介绍</h6>";
                     retstr += "  <p class='product-desc mt_20'>"+l.IngredientIntroduction+"</p>";


                    
                     retstr += "     <h6 data-name='product_name' class='product-name'>食用价值</h6>";
                     retstr += "  <p class='product-desc mt_20'>" + l.EdibleEffect + "</p>";

                    
                     retstr += "     <h6 data-name='product_name' class='product-name'>营养价值</h6>";
                     retstr += "  <p class='product-desc mt_20'>" + l.NutritiveValue + "</p>";
                     
                     retstr += "     <h6 data-name='product_name' class='product-name'>禁忌</h6>";
                     retstr += "  <p class='product-desc mt_20'>" + l.Negatives + "</p>";
                 
                     retstr += "     <h6 data-name='product_name' class='product-name'>小技巧</h6>";
                     retstr += "  <p class='product-desc mt_20'>" + l.CookingTips + "</p>";
                     
                   
                    
                  
                retstr += "  	  </div>";
                      //retstr += "   <div class='days'></div>";
                      // retstr += "  <div class='hours'></div>";
                      // retstr += "  <div class='minutes'></div>";
                      // retstr += "  <div class='seconds'></div>";
                     retstr += "  </div>";
                    
                   retstr += "  </div>";
                 


            }

            return retstr;
           
        }

        #endregion

        //#region  根据食材信息
        //public String GetIngredientDetail(String val)
        //{

        //    BLL.BLLmenu bll = new BLL.BLLmenu();

        //    string retstr = "";
        //    IList<Ingredient> sigleingredient = bll.GetIngredientDetail(val);



        //    foreach (Ingredient menu in sigleingredient)
        //    {

        //        retstr += "  <div class='item product-layout product-list'>";
        //        retstr += "  <div class='product-thumb'>";
        //        retstr += "   <div class='image product-imageblock'> <a href='#'> <img data-name='product_image' src='" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> ";
        //        retstr += "  <img src='" + menu.CoverImg + "' alt='iPod Classic' title='iPod Classic' class='img-responsive'> </a> ";
        //        retstr += "    <p class='menuylzf'> 用料</p><p class='menuylzf'> 做法</p>";

        //        retstr += "    </div>";
        //        retstr += "   <div class='caption product-detail text-left'>";
        //        retstr += "     <h6 data-name='product_name' class='product-name'><a href='#' title='Casual Shirt With Ruffle Hem'>" + menu.MenuName + "</a></h6>";
        //        retstr += "    <div class='rating'> <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span>";
        //        retstr += "  <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
        //        retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
        //        retstr += "     <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-1x'></i></span> ";
        //        retstr += "   <span class='fa fa-stack'><i class='fa fa-star-o fa-stack-1x'></i><i class='fa fa-star fa-stack-x'></i></span> </div>";
        //        retstr += "  <span class='price'><span class='amount'><span class='currencySymbol'>$</span>70.00</span>";
        //        retstr += "  </span>";
        //        retstr += "  <p class='product-desc mt_20'>" + menu.Introduces + "</p>";
        //        retstr += "  <div class='wdcc'>";

        //        retstr += "  <div class='wdc1'>";
        //        retstr += " <div class='wdc2'> 2</div>";
        //        retstr += " <div class='wdc3'>3</div>";
        //        retstr += "  <div class='wdc3'>4</div>";

        //        retstr += " <div class='wdc2'> 2</div>";
        //        retstr += " <div class='wdc3'>3</div>";
        //        retstr += "  <div class='wdc3'>4</div>";
        //        //onclick='Ingredient('" + +"')'
        //        retstr += "  <div > <a href='ingredients.html?val=" + menu.MenuMainIngredient + " '>" + menu.MenuMainIngredient + "的更多做法</a></div>";
        //        BLLuser bll2 = new BLLuser();
        //        IList<User> user = bll2.getUser(menu.ProducerNumber);

        //        foreach (User u in user)
        //        {
        //            retstr += " <div class='wdc2'> 账号：" + u.Account + "</div>";
        //            retstr += " <div class='wdc2'>收藏：" + u.CollectionNum + "</div>";
        //            retstr += " <div class='wdc2'>关注度：" + u.FollowersNum + "</div>";
        //            retstr += " <div class='wdc2'>作品：" + u.ProductionNum + "</div>";
        //            retstr += " <div class='wdc2'>头像：" + u.UserImg + "</div>";
        //            retstr += " <div class='wdc2'>用户名：" + u.UserName + "</div>";
        //            retstr += " <div class='wdc2'>等级：" + u.UserLevel + "</div>";


        //        }
        //        retstr += "  	  </div>";
        //        //retstr += "   <div class='days'></div>";
        //        // retstr += "  <div class='hours'></div>";
        //        // retstr += "  <div class='minutes'></div>";
        //        // retstr += "  <div class='seconds'></div>";
        //        retstr += "  </div>";
        //        retstr += "  <div class='button-group text-center wdbb'>";
        //        retstr += "   <div class='wishlist'><a href='#'><span>wishlist</span></a></div>";
        //        retstr += "  <div class='quickview'><a href='#'><span>Quick View</span></a></div>";
        //        retstr += "  <div class='compare'><a href='#'><span>Compare</span></a></div>";
        //        retstr += "   <div class='add-to-cart'><a href='#'><span>Add to cart</span></a></div>";
        //        retstr += "   </div>";
        //        retstr += "  </div>";
        //        retstr += "  </div>";
        //        retstr += "  </div>";


        //    }

        //    return retstr;

        //}

        //#endregion
        #region  获得评论模板
        public String GetUserCommentmb(String img,String UserName)
        {

            

          String h="  <div class='item' style='top: 0px; left: 692px;'> ";
          h+="<a href='#'>";
          h+="   <img class='example-image' src='../../images/usercomment/01.jpg' alt=''/></a> 	<div class='content-item'> 	";
          h += "       <span class='time' id='pltc' onclick='ppp(&quot;tc&quot;)'><a class='btn btn-1'>吐槽</a> </span>";
          h += "   <span class='time' id='pltw' onclick='ppp(&quot;tw&quot;)'><a class='btn btn-2'>提问</a></span>";
          h+="       <div class='title-item'> <input  id='usercommentinput' placehoder='请输入评论'/></div>  ";
          h += "       <div class='title-item'> <button onclick='plppp()'>提交</button></div>  <div class='bottom-item'> 	";
          h+="           <a href='#' class='btn btn-share share'><i class='fa fa-share-alt'></i> Share</a> 	";
          h+="           <span class='user f-right'>Posted by <a href='#'>"+UserName+"</a>";
          h += " <img src='" + img + "' class='img-circle'></span> 	</div> </div>";
             
            
             //retstr +=" 		<ul class='list-inline'>";
             // retstr +=" 			<li><a href='#'><i class='fa fa-eye'></i> 260</a></li>";
             //    retstr +=" 		<li><a href='#'><i class='fa fa-comment'></i> 260</a></li>";
             //    retstr +=" 		<li><a href='#'><i class='fa fa-heart'></i> 260</a></li>";
             //    retstr +=" 		<li><a href='#'><i class='fa fa-share'></i> 260</a></li>";
             //    retstr +=" 	</ul>";
				  
                  
               


           

            return h;
           
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
                IList<UserComment> comment = bll.GetUserComment2(list.CommentNumber);
                int i = comment.Count();
             retstr +="    <div class='item'>";
	    	 retstr +=" <a  href='#'><img class='example-image' src='"+list.Picture+"' alt=''/></a>";
			 retstr +=" 	<div class='content-item'>";
             retstr += " 		<span class=time' onclick='list(this)'><a class='btn btn-1'>" + i + "</a> 回复</span>";
			 retstr +=" 		<h3 class='title-item'><a href='#' onclick='edit("+i+","+list.MenuNumber+",this)'>"+list.CommetType+"</a></h3>";
           
            
	       
             //retstr += "  <p class='info' onclick='edit(this)'>" + list.Comment + "</p> ";
          
             if (i == 0)
             {
                 retstr += "      <div style='e2'>";
                 retstr += "  <p class='info' >" + list.Comment + "</p> ";
                 retstr += "  </div>";
             }
             else {
                 retstr += "      <div class='singlepllist'>";
                 //retstr += "  <div style='position:absolute;right:0;top:40px' onclick='list(this)'>" + i + "回复</div>";
                 retstr += "  <p class='info' >" + list.Comment + "</p> ";
                 
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




        #region  获取用户详细信息
        public String getUesrDetailimage(IList<User> ULists, IList<UserAttribute> ALists)
        {

            string retstr = "";
            
             
            foreach (User list in ULists)
            {
              // if(list.UserTag=="厨房小白")
                retstr += " <div class='userjmleft' style='background-image:url(&quot;../../images/usergradeimg/xb.jpg&quot;);'>";
               
                retstr += "<div class='username'> ";
               retstr += "   <input  id='userjmname' value='"+list.UserName+"'  disabled/>";
                 
               retstr += "   <img src='images/edit.jpg'  onclick='editusername()'/>";
               retstr += " </div>";

               retstr += " </div>";
               retstr += "  <div class='userjmright'>";
               
               retstr += "<div class='userjmrighthead'>";
               retstr += "<div class='userjmrighttit'>基本信息 </div>";
               retstr += " <div class='userjmrightc2'>"+list.JoinTime+"加入hh </div>";
               retstr += " <div class='userjmrightc2'>"+list.UserTag+"</div>";

               retstr += " <div class='userjmrightc2'>经验 : "+list.Experience+"</div>";
               retstr += "<div class='userjmrightc2'>积分 : "+list.Integral+" </div>";

               retstr += " <div class='userjmrightc3'>关注 : "+list.FollowNum+" </div>";
               retstr += " <div class='userjmrightc3'>粉丝 : "+list.FollowersNum+"</div>";
               retstr += " <div class='userjmrightc3'>我的菜谱 : "+list.AllProductionNum+"</div>";

               retstr += "<div class='userjmrightc3'>发布菜谱 ："+list.ReleaseProductionNum+" </div>";
               retstr += "<div class='userjmrightc3'>收藏菜谱 : "+list.CollectionNum+" </div>";
               retstr += "<div class='userjmrightc3'>做过  : "+list.MenuDidNum+"</div>";
               retstr += "</div>   ";
               retstr += "   <div class='userjmrightbottom'> <p  onclick='logout()'>退出登录</p> ";
              
            }
          //  String kw=" <div class='userjmrighttit'> 口味 </div> <div class='userjmrightbottomcot'>";
           // int kwc=0;
           // String sc = "  <div class='userjmrighttit'> 食材 </div>  <div class='userjmrightbottomcot'>";
          //  int scc=0;
          //  foreach (UserAttribute list in ALists)
          //  { 
           //    if(list.AttributeType=="口味")
            ///   {
             //     kwc++; 
             //     kw +=" <div class='userjmrightc2'>"; 
            //      kw +="    <p>"+list.AttributeName+"</p>";
             //     kw +="      <p class='usersc100'><p class='jyt' style='width:" + list.degree + "px;' ></p>";
             //     kw +="     </p> </div>";
             //  } else if(list.AttributeType=="食材"){
             //     scc++;
             //     sc+="";
             //     sc +=" <div class='userjmrightc2'>"; 
              //    sc +="    <p>"+list.AttributeName+"</p>";
             //     sc += "      <p class='usersc100'><p  class='jyt' style='width:" + list.degree + "px;' ></p>";
              //    sc +="     </p> </div>";
             //  }         
           // }
            //if(kwc!=0)
             // retstr = retstr+kw +"</div>   ";
           // if (scc != 0)
            //  retstr  = retstr + sc + "</div>   ";
           retstr += "</div>  ";
            return retstr;
        }
        #endregion 

        //#region  每日三餐
        //public String createThreeMealsimage(IList<MenuCollocation> Lists)
        //{
        //    String retstr = "";
        //    String tt = "";
        //    int kk = Lists.Count();
        //    BLL.BLLmenu bll = new BLL.BLLmenu();
        //    String widthall = (kk * 1400).ToString();
        //    retstr += "<div id='mmlist' style='width:" + widthall + "px;height:400px;'>";
        //    foreach (MenuCollocation l in Lists)
        //    {

        //        if (l.Type == "0")
        //        {
        //            tt = "早餐";
        //            retstr += " <div class='mmlist' id='mmlist1' >";
        //            retstr += "  <div class='gbcont1head'> <p class='gbheadpre' onclick='#' ></p>";
        //            retstr += "  <p class='gbcont1title'>" + l.Title + "</p>";
        //            retstr += "<p class='gbheadnext' onclick='gbheadnext()'>>>>></p></div>";
        //        }
        //        else if (l.Type == "1")
        //        {
        //            tt = "午餐";
        //            retstr += "<div class='mmlist'  >";
        //            retstr += "  <div class='gbcont1head'> <p class='gbheadpre' onclick='gbheadpre()' ><<<<</p>";
        //            retstr += "  <p class='gbcont1title'>" + l.Title + "</p>";
        //            retstr += "<p class='gbheadnext' onclick='gbheadnext()'>>>>></p></div>";
        //        }
        //        else if (l.Type == "2")
        //        {
        //            tt = "晚餐";
        //            retstr += "<div class='mmlist'  >";
        //            retstr += "  <div class='gbcont1head'> <p class='gbheadpre' onclick='gbheadpre()' ><<<<</p>";
        //            retstr += "  <p class='gbcont1title'>" + l.Title + "</p>";
        //            retstr += "<p class='gbheadnext' onclick='gbheadnext()'>>>>></p></div>";
        //            //retstr += "<div class='mmlist' style='display:none' >";
        //        }
        //        else if (l.Type == "3")
        //        {
        //            tt = "夜宵";
        //            retstr += "<div class='mmlist'  >";
        //            retstr += "  <div class='gbcont1head'> <p class='gbheadpre' onclick='gbheadpre()' ><<<<</p>";
        //            retstr += "  <p class='gbcont1title'>" + l.Title + "</p>";
        //            retstr += "<p class='gbheadnext' onclick='#'  ></p></div>";
        //            // retstr += "<div class='mmlist' style='display:none' >";
        //        }






        //        retstr += "<ul class='gbco11'  >";

        //        String[] h = l.MenuNumber.Split(',');
        //        foreach (string s in h)
        //        {
        //            IList<SimpleMenu> siglemenu = bll.GetSimpleSingleMenu(s);
        //            double i = h.Length;
        //            i = 1200 / i;
        //            int width = Int32.Parse(Math.Floor(i).ToString());
        //            // 
        //            foreach (SimpleMenu k in siglemenu)
        //            {
        //                retstr += "   <li style='width:" + width.ToString() + "px' onclick='getmenudp(&quot;" + k.MenuNumber + "&quot;)'> <p    class='gbco1ig'  > <img src='../../images/MenuAll/" + k.CoverImg + "' alt=''></p>";
        //                retstr += "<div class='gbco1dv gbco1dv1'>";

        //                retstr += "  <label class='gbco1lb'>" + l.ParentC + tt + "</label>";
        //                retstr += "    <a href='#'  title=''>" + k.MenuName + "</a>";
        //                retstr += " <p>难度：" + k.MenuND + "</p>";
        //                retstr += "<p>准备时间约" + k.PreparationTime + "分钟</p>";
        //                retstr += " <p    title='" + k.MenuName + "' class='gbco1ck'>立即查看</p> </div>";
        //                retstr += " </li>";

        //            }
        //        }
        //        retstr += "</ul>";
        //        retstr += "</div>";


        //    }
        //    retstr += "</div>";
        //    return retstr;
        //}
        //#endregion 


        public String createindexmenuimage(IList<SimpleMenu> Lists)
        {
            String retstr = ""; 
            foreach (SimpleMenu k in Lists)
            {

                 retstr += " <div class='entry col-xs-12 col-sm-4'>";
				 retstr += "	<div class='entry-media'>";
				 retstr += "		<img src='../../images/MenuAll/"+k.CoverImg+"' alt=''>";
				 retstr += "	</div>";
				 retstr += "	<h3 class='entry-title'><a href='#'>"+k.MenuName+"</a></h3>";
				 retstr += "	<p class='entry-meta'>";
				 retstr += "		<img src='"+k.UserImg+"' alt=''>";
				 retstr += "		Post by "+k.UserName+"";
				 retstr += "	</p>";
				 retstr += "	<p class='entry-text'>"+k.Introduces +".</p>";
				 retstr += "	<p><a class='ht-button view-more' href='#' onclick='getmenudp(&quot;"+k.MenuNumber+"&quot;)'>查看更多信息<i class='fa fa-long-arrow-right'></i></a></p>";
				 retstr += "</div>"; 
            }

            return retstr;
        }
        public String createThreeSinigleMealsimage(String val,String type,String useraccount)
        {
            String retstr = "";
            BLL.BLLmenu bll = new BLL.BLLmenu();
            IList<SimpleMenu> siglemenu = bll.GetSimpleSingleMenu(val);
            String menunumber = "";
            BLL.BLLuser blluser = new BLLuser();
            int r1 = 0;
            foreach (SimpleMenu k in siglemenu)
            {

                //if (type == "0")
                //{
                //    retstr += "<div class='entry col-xs-12 col-sm-12 filter-pudding'>";
                //}
                //else if (type == "1")
                //{
                //    retstr += "<div class='entry col-xs-12 col-sm-12 filter-food'>";
                //}
                //else if (type == "2")
                //{
                //    retstr += "<div class='entry col-xs-12 col-sm-12 filter-beverages'>";
                //}
                //else if (type == "3")
                //{
                //    retstr += "<div class='entry col-xs-12 col-sm-12 filter-dessert'>";
                //}
                retstr += "<div class='entry col-xs-12 col-sm-3 filter-dessert'>";
                retstr += " <div class='entry-inner'>";
                retstr += "		<div class='entry-media'>";
                retstr += "			<img src='../../images/MenuAll/" + k.CoverImg + "'  alt=''/>";
                retstr += "			<div class='entry-action'>";
                #region c1
                retstr += "				<div class='entry-action-inner'>";
                retstr += "				<span>";
                retstr += "					<a href='#' onclick='getmenudp(&quot;" + k.MenuNumber + "&quot;)'>查看菜谱</a>";
                retstr += "				</span>";
                retstr += "				<span id='sc'>";

                if (useraccount != "")
                {
                    menunumber = k.MenuNumber;
                    r1 = blluser.Collectcount(useraccount, menunumber);//判断是否已收藏
                    if (r1 == 0)
                    {
                        retstr += "<a href='#' onclick='shoucang(&quot;" + k.MenuName + "&quot;,&quot;" + k.MenuNumber + "&quot;," + k.Collection + ",this)' >收藏菜谱</a>";

                    }
                    else
                    {
                        retstr += "<a href='#'onclick='shoucangdel(&quot;" + k.MenuName + "&quot;,&quot;" + k.MenuNumber + "&quot;," + k.Collection + ",this)'>取消收藏</a>";

                    }

                }

                //  retstrzc += "					<a href='#' >收藏菜谱</a>";
                retstr += "				</span>";
                retstr += "			</div>";
                #endregion c1
                retstr += "		</div>";
                retstr += "	</div>";
                //	<!-- ./ entry-media -->
                retstr += "	<div class='content-wrapper'>";
                retstr += "		<h3 class='entry-name'><a href='#' >" + k.MenuName + "</a></h3>";
                retstr += "		<p class='entry-author'>By " + k.UserName + "</p>";
                retstr += "		<div class='entry-meta'>";
                #region c2
                retstr += "			<div class='foo-wrapper'>";
                if (Int32.Parse(k.MenuND) < 5)
                {
                    retstr += "				<span class='meta-difficulty easy' title=''>Easy</span>";
                }
                else if (Int32.Parse(k.MenuND) < 8 && Int32.Parse(k.MenuND) >= 5)
                {
                    retstr += "	 <span class='meta-difficulty master' title=''>Master</span>";
                }
                else if (Int32.Parse(k.MenuND) >= 8)
                {
                    retstr += "	<span class='meta-difficulty hard' title=''>Hard</span>";

                }
                // <span class="meta-difficulty hard" title="">Hard</span>

                // <span class="meta-difficulty master" title="">Master</span>
                retstr += "				<span class='meta-time'>约 " + k.PreparationTime + " minutes</span>";
                retstr += "		</div>";
                #endregion c2
                #region starbegin
                retstr += "		<div class='meta-rate' title='4 star'>";
                if (Int32.Parse(k.MenuScore) > 0 && Int32.Parse(k.MenuScore) <= 2)
                {//星级1
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                }
                else if (Int32.Parse(k.MenuScore) > 2 && Int32.Parse(k.MenuScore) <= 4)
                {//星级2
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                }
                else if (Int32.Parse(k.MenuScore) > 4 && Int32.Parse(k.MenuScore) <= 6)
                {//星级3
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                }
                else if (Int32.Parse(k.MenuScore) > 6 && Int32.Parse(k.MenuScore) <= 8)
                {//星级4
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star'></i>";
                }
                else if (Int32.Parse(k.MenuScore) > 8 && Int32.Parse(k.MenuScore) <= 10)
                {//星级5
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                    retstr += "			<i class='fa fa-star rated'></i>";
                }

                retstr += "		</div>";
                #endregion starend
                retstr += "	</div>";
                retstr += "</div>";



                retstr += "</div>";

                retstr += "</div>";
              


            }

            return retstr;
        }
        #region  获取用户搜索列表
        public String getUserSearchListimage2(IList<User> Lists, int presentindex, int pages, String actype, String useraccount)
        {


            string retstr = "";
            BLLuser blluser = new BLLuser();

            int r1 = 0;
            String menunumber = "";
            


            foreach (User list in Lists)
            {

                retstr += " <div class='entry col-xs-12 col-sm-3'>";
                retstr += " 	<div class='entry-media'>";
                retstr += " 		<div class='thumb'>";
                retstr += " 			<img src='" + list.UserImg + "' alt=''>";
                retstr += "	</div>";
                retstr += "	</div>";
                retstr += "	<h3 class='entry-name'>" + list.UserName + "</h3>";
                retstr += "<p class='entry-position'>" + list.UserLevel + "</p>";

                retstr += "	<div class='entry-social'>";
                retstr += " <div class='entry-social-inner'>";
                retstr += "      <a href='' class='fa'>" + list.FollowersNum + "</a>";
                if (useraccount != "")
                {
                    menunumber = list.Account;
                    r1 = blluser.Followcount(useraccount, menunumber);//判断是否已收藏
                    if (r1 == 0)
                    {
                        retstr += "     <a  class='fa'  onclick='followuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'>关注</a>";

                        //retstr += "<a href='#' class='fa' onclick='shoucang(&quot;" + k.MenuName + "&quot;,&quot;" + k.MenuNumber + "&quot;," + k.Collection + ")' >收藏菜谱</a>";

                    }
                    else
                    {
                        retstr += "     <a  class='fa'  onclick='unfollowuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'>取消关注</a>";

                        // retstr += "<a href='#' class='fa' onclick='shoucangdel(&quot;" + k.MenuName + "&quot;,&quot;" + k.MenuNumber + "&quot;," + k.Collection + ")'>取消收藏</a>";

                    }

                }



                retstr += " </div>";
                retstr += "	</div>";
                retstr += "</div>";
            }
            //  retstrbottom = getDataBottomimage("getStrangerList", presentindex, pages, actype);
            //retstrbottom = getDataBottomimage("submitsearch", presentindex, pages, actype);

           // String tilt = getDatatitleimage("submitsearch");
           // retstr = tilt + "|" + retstr + "|" + retstrbottom;
            return retstr;
        }
        #endregion   

        #region //作者列表
        public String CreateEditorImage(IList<User> Lists,String useraccount)
        {

            string retstr = "";
            string menunumber = "";
            int r1 = 0;
            BLLuser blluser = new BLLuser();
             
            foreach (User list in Lists)
            { 
                retstr += " <div class='entry col-xs-12 col-sm-3'>";
                retstr += " 	<div class='entry-media'>";
                retstr += " 		<div class='thumb'>";
                retstr += " 			<img src='" + list.UserImg + "' alt=''>";
                retstr += "	</div>";
                retstr += "	</div>";
                retstr += "	<h3 class='entry-name'>" + list.UserName + "</h3>";
                retstr += "<p class='entry-position'>"+list.UserLevel+"</p>";

                retstr += "	<div class='entry-social'>";
                retstr += " <div class='entry-social-inner'>";
                retstr += "      <a href='' class='fa'>" + list.FollowersNum + "</a>";
                if (useraccount != "")
                {
                    menunumber = list.Account;
                    r1 = blluser.Followcount(useraccount, menunumber);//判断是否已收藏
                    if (r1 == 0)
                    {
                        retstr += "     <a  class='fa'  onclick='followuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'>关注</a>";
                
                        //retstr += "<a href='#' class='fa' onclick='shoucang(&quot;" + k.MenuName + "&quot;,&quot;" + k.MenuNumber + "&quot;," + k.Collection + ")' >收藏菜谱</a>";
                        
                    }
                    else
                    {
                        retstr += "     <a  class='fa'  onclick='unfollowuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'>取消关注</a>";
                
                       // retstr += "<a href='#' class='fa' onclick='shoucangdel(&quot;" + k.MenuName + "&quot;,&quot;" + k.MenuNumber + "&quot;," + k.Collection + ")'>取消收藏</a>";

                    }

                }

              
               
                retstr += " </div>";
                retstr += "	</div>";
                retstr += "</div>";

            }
         
             
            return retstr;

        }
        #endregion

        #region //作者列表
        public String CreateEditorImage2(IList<UserFollows> Lists)
        {

            string retstr = "";

            foreach (UserFollows list in Lists)
            {

                //retstr += "  <div class='zmmrow'>";

                //retstr += "<div class='zmml2' onclick='getuserdetails(" + list.ObjectNumber + ")'><img src='" + list.ObjectImg + "' /></div>";
                //retstr += "<div class='zmml3'>" + list.ObjectName + "</div>";
                //retstr += " <div class='zmml4'>" + list.ObjectFNum + "</div>";
                //// retstr += " <div class='zmml4'></div>";
                //// retstr += " <div class='zmml5'><div  onclick='deletefriend(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'>删除好友</div></div>";
                //retstr += " <div class='zmml5'><div class='yllike' onclick='unfollowuser(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'><a href='#'> </a></div></div>";

                //retstr += "</div>"; 
                retstr += " <div class='entry col-xs-12 col-sm-3'>";
                retstr += " 	<div class='entry-media'>";
                retstr += " 		<div class='thumb'>";
                retstr += " 			<img src='" + list.ObjectImg + "' alt=''>";
                retstr += "	</div>";
                retstr += "	</div>";
                retstr += "	<h3 class='entry-name'>" + list.ObjectName + "</h3>";
                retstr += "<p class='entry-position'>" + list.ObjectLevel + "</p>";
                retstr += "	<div class='entry-social'>";
                retstr += " <div class='entry-social-inner' id='scsc'>";
                // retstr += "      <a href='' class='fa'></a>";

                retstr += "     <a  class='fa'  onclick='unfollowuser(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'>取消关注</a>";
                retstr += "     <a  class='fa' >" + list.ObjectFNum + "</a>";
              
                

                // retstr += "    <a href='' class='fa'></a>";
                retstr += " </div>";
                retstr += "	</div>";
                retstr += "</div>";

            }


            return retstr;

        }
        #endregion

        #region //作者列表
        public String CreateEditorImage3(IList<User> Lists)
        {

            string retstr = "";

            foreach (User list in Lists)
            {

                //retstr += "  <div class='zmmrow'>";

                //retstr += "<div class='zmml2' onclick='getuserdetails(" + list.ObjectNumber + ")'><img src='" + list.ObjectImg + "' /></div>";
                //retstr += "<div class='zmml3'>" + list.ObjectName + "</div>";
                //retstr += " <div class='zmml4'>" + list.ObjectFNum + "</div>";
                //// retstr += " <div class='zmml4'></div>";
                //// retstr += " <div class='zmml5'><div  onclick='deletefriend(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'>删除好友</div></div>";
                //retstr += " <div class='zmml5'><div class='yllike' onclick='unfollowuser(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'><a href='#'> </a></div></div>";

                //retstr += "</div>"; 
                retstr += " <div class='entry col-xs-12 col-sm-3'>";
                retstr += " 	<div class='entry-media'>";
                retstr += " 		<div class='thumb'>";
                retstr += " 			<img src='" + list.UserImg + "' alt=''>";
                retstr += "	</div>";
                retstr += "	</div>";
                retstr += "	<h3 class='entry-name'>" + list.UserName + "</h3>";
                retstr += "<p class='entry-position'>" + list.UserLevel + "</p>";
                retstr += "	<div class='entry-social'>";
                retstr += " <div class='entry-social-inner' id='scsc'>";
               // retstr += "      <a href='' class='fa'></a>";

                retstr += "     <a href='' class='fa'  onclick='followuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'>关注</a>";
                retstr += "     <a href='' class='fa'>"+list.FollowersNum+"</a>";
              
                
                // retstr += "    <a href='' class='fa'></a>";
                retstr += " </div>";
                retstr += "	</div>";
                retstr += "</div>";

            }


            return retstr;

        }
        #endregion

   
         #region  每日三餐
        public String createThreeMealsimage(IList<MenuCollocation> Lists,String useraccount)
        {
            String retstr = "";
        
         
            String menunumber = "";
         
          
            foreach (MenuCollocation l in Lists)
            {

                String[] h = l.MenuNumber.Split(',');
                retstr += "<div class='dmrscdata'>";
                
                foreach (string s in h)
                {
                   menunumber= createThreeSinigleMealsimage(s,l.Type, useraccount);
                   retstr += menunumber;
                } 
                retstr += "</div>";
            }
           

          
            
            return   retstr ;
        }
        #endregion 
    
          #region  获取最新菜谱
        public String createSimpleMenuimage(IList<SimpleMenu> Lists)
        {
            
            String retstr="";
            retstr += "<ul class='gbco11' style='margin-top:0px'>";
            retstr += "<div style='width:100%;height:40px;margin-top:-40px;text-align:center;'>最新菜谱</div>";
            foreach (SimpleMenu l in Lists)
            {
               retstr += "   <li> <a href='#'  title='#'  class='gbco1ig'><img src='../../images/MenuAll/"+l.CoverImg+"' alt=''></a>";
               retstr += "<div class='gbco1dv gbco1dv1'>";
               retstr += "  <label class='gbco1lb'>"+l.MenuKW+"</label>";
               retstr += "    <a href='#'  title=''>"+l.MenuName+"</a>";
              retstr += " <p>难度："+l.MenuND+"</p>";
               retstr += "<p>"+l.TimeMade+"</p>";
               retstr += " <a href='#'  title='８元汉堡 全天爆单' class='gbco1ck' onlick='getmenudetails(&quot;notuserproduction&quot;,&quot;" + l.MenuNumber + "&quot;)'>立即查看</a> </div>";
               retstr += " </li>";

             }

            retstr += "</ul>";
           
            return retstr;
        }
        #endregion

        #region  获取健康新闻
        public String createHealthNewsimage(IList<HealthNews> Lists)
        {
            
            String retstr="";
            retstr += "<ul class='gbco11' style='margin-top:0px'>";
            foreach (HealthNews l in Lists)
            {
               retstr += "   <li> <a href='#'  title=''  class='gbco1ig'>";
               retstr += "<div class='gbco1dv gbco1dv1'>";
               retstr += "  <label class='gbco1lb'>健康新闻</label>";
               retstr += "    <a href='#'  title=''>"+l.title+"</a>";
              // retstr += " <p>额度：3-5万</p>";
               retstr += "<p>"+l.content+"</p>";
              // retstr += " <a href='#'  title='８元汉堡 全天爆单' class='gbco1ck'>立即查看</a> </div>";
               retstr += " </li>";

             }
            retstr += "</ul>";
       
           
            return retstr;
        }
        #endregion
       

         

          #region  获取热门搜索
        public String GeSearchFeverListImage( IList<SearchFever> Lists)
        {
            
            String retstr="";
             foreach(SearchFever l in Lists){
                 retstr += " <a title='#' href='#'  onclick='rmsubmitsearch(&quot;" + l.SearchType + "&quot;,&quot;" + l.SearchContent + "&quot;)'>" + l.SearchContent + "</a>";

             }
       
       
           
            return retstr;
        }
        #endregion
        #region  获取用户好友申请
        public String getFriendApplicationimage(IList<FriendApplication> Lists, int presentindex, int pages, String actype)
        {

            string retstr = "";
            int i = 0;
            string retstrbottom = "";
            foreach (FriendApplication list in Lists)
            {
                i++;
                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>" + i + "</div>";
                retstr += "<div class='zmml2' onclick='getuserdetails(" + list.ObjectNumber + ")'><img src='" + list.ObjectImg + "' /></div>";
                retstr += "<div class='zmml3'>" + list.ObjectName + "</div>";
                retstr += " <div class='zmml4'>"+list.ObjectFrNum+"</div>";
                retstr += " <div class='zmml5'><a href='#' onclick='adduser('"+list.ObjectFrNum+"','"+list.ObjectNumber+"', this)'><div class='ww'>接受</div> </a></div>";
                retstr += " <div class='zmml5'><a href='#' onclick='ignoreuser(" + list.ObjectFrNum + ",&quot;" + list.ObjectName + "&quot;, &quot;" + list.ObjectNumber + "&quot;, this)'><div class='wwq'>忽略</div> </a></div>";
                retstr += "</div>";
            }
            retstrbottom = getDataBottomimage("gethysq", presentindex, pages,actype);
            return retstr;
        }
        #endregion 
        
          #region  获取数据title 
        public String getDatatitleimage(String function)
        {
            
               
	      //retstr += " <div class='zcmiddlet1 lm3'>  <a onclick=''>认证</a>  </div>";
            
            string retstr = "";
             
                retstr += "  <div class='zcmiddlet1'> <a onclick=' " + function + "(&quot;orderbydj&quot;,0,1,0)'> 等级</a>   </div> ";
                retstr += "<div class='zcmiddlet1 lm2'>  <a onclick=' " + function + "(&quot;orderbygzd&quot;,0,1,0)'> 关注度</a>  </div>";
              
           
           
            
              

            return retstr;
        }
        #endregion
         #region  获取数据下方分页
        public String getDataBottomimage(String function, int presentindex, int pages, String actype)
        {
            
               int prepresentindex = presentindex - 1;
            
             
               int nextpresentindex = presentindex + 1;
            
            
            string retstr = "";
            if (function == "getUserProduction2")
            {
                retstr += " <div class='userDaTabottom2'> ";
            }
            else {
                retstr += " <div class='userDaTabottom'> ";
            }
             
             retstr += "   <div class='DataBottom'>";
              retstr += "<div class='DataBottominner'>";
              retstr += "<span class='presentindex'>"+presentindex+"</span><span class='pages'>/"+pages+"</span></div>";
              if (function == "getUserNoticeP")
              {
                  retstr += "<div class='zcbq' onclick='" + function + "(&quot;userPnoticeunread&quot;" + pages + "," + prepresentindex + ",&quot;pre&quot;)'></div>";
                  retstr += "<div class='zcbh' onclick='" + function + "(&quot;userPnoticeunread&quot;" + pages + "," + nextpresentindex + ",&quot;next&quot;)'></div>";
   
              }
              else if (function == "getHistoricalRecord")
              {
                  retstr += "<div class='zcbq' onclick='" + function + "(" + pages + "," + prepresentindex + ",&quot;pre&quot;)'></div>";
                  retstr += "<div class='zcbh' onclick='" + function + "(" + pages + "," + nextpresentindex + ",&quot;next&quot;)'></div>";

              } 
              else if (function == "getUserNotice")
              {
                  retstr += "<div class='zcbq' onclick='" + function + "(&quot;usernoticeunread&quot;" +pages + "," + prepresentindex + ",&quot;pre&quot;)'></div>";
                  retstr += "<div class='zcbh' onclick='" + function + "(&quot;usernoticeunread&quot;" + pages + "," + nextpresentindex + ",&quot;next&quot;)'></div>";
   
              }
              else
              {
                  retstr += "<div class='zcbq' onclick='" + function + "(" + pages + "," + prepresentindex + ",&quot;pre&quot;)'></div>";
                  retstr += "<div class='zcbh' onclick='" + function + "(" + pages + "," + nextpresentindex + ",&quot;next&quot;)'></div>";

              }
            
               retstr += "</div> ";
               retstr += "</div> ";

            return retstr;
        }
        #endregion
        
        #region  获取未读信息
        public String getUserNoticesimage(String noticetype,IList<UserNotices> Lists, int presentindex, int pages, String actype)
        {

            string retstr = "";
            string retstrbottom = "";
            int i = 0;
            foreach (UserNotices list in Lists)
            {
                i++;
                retstr += "<div class='noticeit'> <p class='noticeindex'>" +i + ". </p>  <p class='noticecon'>" + list.content + " </p>";
                retstr += "<p class='noticetime'>" + list.actime + " </p></div>";  
                //retstr += "<p class='noticecon'>私信</p>";
            }
            if (noticetype=="usernoticeunread")
               retstrbottom = getDataBottomimage("getUserNotice2", presentindex, pages, actype);
            else if(noticetype=="userPnoticeunread") 
                retstrbottom = getDataBottomimage("getUserNoticeP2", presentindex, pages, actype);
            retstr += retstrbottom;

            return retstr;
        }
        #endregion

       


          #region  获取历史足迹
        public String getHistoricalRecord2image(IList<NewNotice> Lists)
        {

            string retstr = "";
            //string retstrfollow = "<li class='menu-item-has-children'> <a href='#'>关注记录</a> <ul>";
            //string retstrunfollow = "<li class='menu-item-has-children'> <a href='#'>取关记录</a> <ul>";

            //string retstrcollect = "<li class='menu-item-has-children'> <a href='#'>收藏记录</a> <ul>";
            //string retstruncollect = "<li class='menu-item-has-children'> <a href='#'>取消收藏记录</a> <ul>";


            //string retstralterMenu = "<li class='menu-item-has-children'> <a href='#'>修改记录</a> <ul>";
            //string retstrmadeMenu = "<li class='menu-item-has-children'> <a href='#'>制作记录</a> <ul>";
            //string retstrdeleteMenu = "<li class='menu-item-has-children'> <a href='#'>删除记录</a> <ul>";

            //string retstrsearch = "<li class='menu-item-has-children'> <a href='#'>搜索记录</a> <ul>";


            //string retstrelse = "<li class='menu-item-has-children'> <a href='#'>其他记录</a> <ul>";
            string retstrfollow = "";
            string retstrunfollow = "";

            string retstrcollect = "";
            string retstruncollect = "";


            string retstralterMenu = "";
            string retstrmadeMenu = "";
            string retstrdeleteMenu = "";

            string retstrsearch = "";


            string retstrelse = "";        
            
            foreach (NewNotice list in Lists)
            {
               //  retstr += "  <li class='menu-item-has-children'>";
                 if (list.ctype == "follow")
                 {
                     retstrfollow += " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
                 }  else if (list.ctype == "follow")
                 {
                     retstrunfollow+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 } else if (list.ctype == "collect")
                 {
                     retstrcollect+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 }else if (list.ctype == "uncollect")
                 {
                     retstruncollect+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 }else if (list.ctype == "alterMenu")
                 {
                     retstralterMenu+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 }else if (list.ctype == "madeMenu")
                 {
                     retstrmadeMenu+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 }else if (list.ctype == "deleteMenu")
                 {
                     retstrdeleteMenu+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 }else if (list.ctype == "search")
                 {
                     retstrsearch+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 }else  
                 {
                     retstrelse+= " 					<li><a href='#'> " + list.content + "|" + list.actime + "</a></li>";
              
                 } 
				
                 //retstr += " 						<ul>";
                 //retstr += " 							<li><a href='#'><i class='ht-foodie-055'></i> Recipe Single</a></li>";
                 //retstr += " 							<li><a href='#'><i class='ht-foodie-063'></i> Recipe Single With Video</a></li>";
                 //retstr += " 						</ul>";
                 //retstr += " 					</li>";


               //retstr += "  <div class='xfitem'>"; 
               //retstr += "<div class='xfitemrowimg' onclick='#'><img src='"+list.UserImg+"' /><p>"+list.UserName+"</p></div>";
               //retstr += "<div class='xfitemrowc'>";  
               //retstr += " <div class='xfitemrowtit'>"+list.actitle+"</div>";
               //retstr += " <div class='xfitemrowcont'>"+list.content+"</div> ";
               //retstr += "  <div class='xfitemrowti'>"+list.actime+"</div>";
               //retstr += " </div>";
               //retstr += "</div> ";

            }


            retstr = retstrfollow + "；" + retstrunfollow + "；" + retstrcollect + "；";

            retstr = retstr + retstruncollect + "；" + retstralterMenu + "；" + retstrmadeMenu + "；";

            retstr = retstr + retstrdeleteMenu + "；" + retstrsearch + "；" + retstrelse + "；";

           // retstr = retstr + retstruncollect + "</ul></li>|" + retstralterMenu + "</ul></li>|" + retstrmadeMenu + "</ul></li>|";
            #region begin
              //if (retstrfollow == "<li class='menu-item-has-children'> <a href='#'>关注记录</a> <ul>")  {
              //} else {
              //    retstr += retstrfollow + "</ul></li>";
              //}

              //if (retstrunfollow == "<li class='menu-item-has-children'> <a href='#'>取关记录</a> <ul>") {
              //}  else  {
              //    retstr += retstrunfollow + "</ul></li>";
              //}

              //if (retstrcollect == "<li class='menu-item-has-children'> <a href='#'>收藏记录</a> <ul>")  { 
              //} else {
              //    retstr += retstrcollect + "</ul></li>";
              //}

              //if (retstruncollect == "<li class='menu-item-has-children'> <a href='#'>取消收藏记录</a> <ul>")  {
              //}   else  {
              //    retstr += retstruncollect + "</ul></li>";
              //}

              //if (retstralterMenu == "<li class='menu-item-has-children'> <a href='#'>修改记录</a> <ul>")  {
              //}  else  {
              //    retstr += retstralterMenu + "</ul></li>";
              //}

              //if (retstrmadeMenu == "<li class='menu-item-has-children'> <a href='#'>制作记录</a> <ul>")  {
              //}   else  {
              //    retstr += retstrmadeMenu + "</ul></li>";
              //}

              //if (retstrdeleteMenu == "<li class='menu-item-has-children'> <a href='#'>删除记录</a> <ul>")  {
              //}  else  {
              //    retstr += retstrdeleteMenu + "</ul></li>";
              //}

              //if (retstrsearch == "<li class='menu-item-has-children'> <a href='#'>搜索记录</a> <ul>")  {
              //}  else  {
              //    retstr += retstrsearch + "</ul></li>";
              //}

              //if (retstrelse == "<li class='menu-item-has-children'> <a href='#'>其他记录</a> <ul>")  {
              //}   else  {
              //    retstr += retstrelse + "</ul></li>";
            //}
            #endregion


            return retstr;
        }
        #endregion
        #region  获取历史足迹
        public String getHistoricalRecordimage(IList<NewNotice> Lists,int presentindex,int pages,String actype)
        {

            string retstr = "";
            string retstrbottom = "";

            foreach (NewNotice list in Lists)
            {
               retstr += "  <div class='xfitem'>"; 
               retstr += "<div class='xfitemrowimg' onclick='#'><img src='"+list.UserImg+"' /><p>"+list.UserName+"</p></div>";
               retstr += "<div class='xfitemrowc'>";  
               retstr += " <div class='xfitemrowtit'>"+list.actitle+"</div>";
               retstr += " <div class='xfitemrowcont'>"+list.content+"</div> ";
               retstr += "  <div class='xfitemrowti'>"+list.actime+"</div>";
               retstr += " </div>";
               retstr += "</div> ";

            }
            retstrbottom = getDataBottomimage("getHistoricalRecord", presentindex, pages,actype);
            retstr = retstr + "|" + retstrbottom;
            return retstr;
        }
        #endregion
         
        
        #region  获取用户搜索列表
        public String getUserSearchListimage(IList<User> Lists, int presentindex, int pages, String actype,String useraccount)
        {


            string retstr = "";
            BLLuser blluser = new BLLuser();

            int i = 0;
            String menunumber = "";
            String retstrbottom = "";
            

            foreach (User list in Lists)
            {
                 
                  
                int  r1 = blluser.Collectcount(useraccount, list.Account);//判断是否已收藏
                //int r1 = blluser.userfollowcount(useraccount, list.Account,'userfollow');//用户已关注
                //int r1 = blluser.userfollowcount(useraccount, list.Account,'userfollow');//用户已关注
                i++;
                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>" + i + "</div>";
                retstr += "<div class='zmml2' onclick='getuserdetails(" + list.Account + ")'><img src='" + list.UserImg + "' /></div>";
                retstr += "<div class='zmml3'>" + list.UserName + "</div>";
                retstr += " <div class='zmml4'>" + list.FollowersNum + "</div>";
                if (r1 == 0)
                {
                    retstr += " <div class='zmml5'><div class='yldislike'  onclick='followuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'><a href='#'> </a></div></div>";
                
                }
                else {
                    retstr += " <div class='zmml5'><div class='yllike'  onclick='unfollowuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'><a href='#'> </a></div></div>";
                }
                retstr += "</div>";
            }
           //  retstrbottom = getDataBottomimage("getStrangerList", presentindex, pages, actype);
            retstrbottom = getDataBottomimage("submitsearch", presentindex, pages, actype);
             
            String tilt = getDatatitleimage("submitsearch");
            retstr = tilt + "|" + retstr + "|" + retstrbottom;
            return retstr;
        }
        #endregion   
        #region  获取陌生用户列表
        public String getStrangerListimage(IList<User> Lists, int presentindex, int pages,String actype)
        {


            string retstr = "";
            String retstrbottom = "";
            int i = 0;

            foreach (User list in Lists)
            {
                i++;
                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>"+i+"</div>";
                retstr += "<div class='zmml2' onclick='getuserdetails(" + list.Account + ")'><img src='" + list.UserImg + "' /></div>";
                retstr += "<div class='zmml3'>"+list.UserName+"</div>";
                retstr += " <div class='zmml4'>"+list.FollowersNum+"</div>";
               
                retstr += " <div class='zmml5'><div class='yldislike'  onclick='followuser(" + list.FollowersNum + ",&quot;" + list.UserName + "&quot;,&quot;" + list.Account + "&quot;,this)'><a href='#'> </a></div></div>";
                retstr += "</div>";
            }
            retstrbottom = getDataBottomimage("getStrangerList", presentindex, pages, actype);

            String tilt = getDatatitleimage("getStrangerList");
            retstr = tilt + "|" + retstr + "|" + retstrbottom;
            return retstr;
        }
        #endregion   
            
        #region //用户关注的用户列表
        public String CreateUserPersonFollowImage(IList<UserFollows> Lists,int presentindex,int pages,String f,String actype)
        {
            
            string retstr = "";
            int i = 0;
            string retstrbottom = "";
            foreach(UserFollows list in Lists)
            {
                i++; 
                retstr += "  <div class='zmmrow'>";
                retstr += "<div class='zmml1'>"+i+"</div>";
                retstr += "<div class='zmml2' onclick='getuserdetails(" + list.ObjectNumber + ")'><img src='" + list.ObjectImg + "' /></div>";
                retstr += "<div class='zmml3'>"+list.ObjectName+"</div>";
                retstr += " <div class='zmml4'>"+list.ObjectFNum+"</div>";
               // retstr += " <div class='zmml4'></div>";
               // retstr += " <div class='zmml5'><div  onclick='deletefriend(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'>删除好友</div></div>";
                retstr += " <div class='zmml5'><div class='yllike' onclick='unfollowuser(" + list.ObjectFNum + ",&quot;" + list.ObjectName + "&quot;,&quot;" + list.ObjectNumber + "&quot;,this)'><a href='#'> </a></div></div>";

                retstr += "</div>";
               
            }
            if (f == "friend") {
                retstrbottom = getDataBottomimage("getmyfriend", presentindex, pages,actype);
            }else if (f == "follow") {
                retstrbottom = getDataBottomimage("getUserPersonFollow", presentindex, pages,actype);
            }
            String tilt = getDatatitleimage("getUserPersonFollow");
            retstr =tilt+"|"+ retstr + "|" + retstrbottom;
            return retstr;
           
        }
         #endregion

        
        #region //用户称号
        public String CreateMedalsImage(IList<UserMedalsView> Lists, int presentindex, int pages, String actype)
        {
            
             string retstr = "";
            
            string retstrbottom = "";
            retstr += " <div class='usercplist'>";
            foreach (UserMedalsView list in Lists)
            {

              //  IList<UserMedals> List2s = bll.getUserMedals(Account);
                retstr += " <div class='usercp' style='background-image:url(&quot;" + list.MedalImg + "&quot;);'onmousemove='medalsmovein(&quot;" + list.MedalNumber + "&quot;)'  onmouseout='medalsmoveout(&quot;" + list.MedalNumber + "&quot;)'>";
                retstr += " <div class='chhh'  id='" + list.MedalNumber + "'>获得条件：" + list.MdalMission + "(" + list.finished + "/" + list.MissionQuantity + "）</div>";
              retstr += "</div>";  
            }
            retstr += "</div>"; 
            retstrbottom = getDataBottomimage("getUserProduction", presentindex, pages,actype);
           
            retstr = retstr + retstrbottom;
            return retstr;
           
        }
         #endregion
        #region //用户菜谱收藏列表
        public String CreateUserMenuCollectionImage( IList<UserCollections> Lists,int presentindex,int pages,String actype,String ty)
        {
            
             string retstr = "";
            //int i = 0;
            string retstrbottom = "";
            String cl = "";

            if (ty == "yhcp")
            {
                cl= "hj1";
            }
            else {
                cl= "hj2";
            }
            
            foreach(UserCollections list in Lists)
            { 
                
                retstr += " <div class='usercp' >";
                retstr += " <img src='../../images/MenuAll/" + list.CoverImg + "' onclick='getmenudetails(&quot;notuserproduction&quot;,&quot;" + list.ObjectNumber + "&quot;)' />";
                retstr += "  <p class='hj2' onclick='shoucangdel2(&quot;" + list.menuname + "&quot;,&quot;" + list.ObjectNumber + "&quot;,&quot;" + list.Collection + "&quot;,this)'>取消收藏</p>";
                retstr += "</div>";  
              
            }
            
            retstrbottom = getDataBottomimage("getUsermenuCollection2", presentindex, pages,actype);
           
            retstr = retstr + retstrbottom;
            return retstr;
           
        }
         #endregion
        


             #region //用户信息界面无数据
        public String UserDetailDataNone(String type,String useraccount)
        {
            
            string retstr = "";
            
             if(type=="UserProduction"){
                 retstr += "   <div class='usercptit'><p class='bt'>用户制作 </p> ";
                 retstr += "     <div class='finaljytcon100'><p class='finaljytinn' style='width: 0px;' ></p> <p class='jyst'>0/100 </p></div> <p ><a href='../MadeMenu/MadeMenu.html?menunumber=non&usernumber=" + useraccount + "'>前往制作</a></p> </div>";

             }  else if (type == "UserCollection")
             {
                 retstr += "   <div class='usercptit'><p class='bt'>用户收藏 </p> ";
                 retstr += "     <div class='finaljytcon100'><p class='finaljytinn' style='width:0px;' ></p> <p class='jyst'>0/100 </p></div> </div>";
             } else if (type == "Medals")
             {
                 retstr += "   <div class='usercptit'><p class='bt'>获得称号   0/100 </p> ";
                 //retstr += "     <p class='usersc100'><p style='width:" + datacount + "px;' ></p></p> </div>";
             } 
           
              
            return retstr;
           
        }
         #endregion


       #region //用户界面头部
        public String CreateHeadImage(String type, String datacount,String useraccount)
        {
            
            string retstr = "";
            
             if(type=="UserProduction"){
                 retstr += "   <div class='usercptit'><p class='bt'>用户制作 </p> ";
                 retstr += "     <div class='finaljytcon100'><p class='finaljytinn' style='width:" + datacount + "px;' ></p> <p class='jyst'>" + datacount + "/100 </p></div> <p ><a href='../MadeMenu/MadeMenu.html?menunumber=non&usernumber=" + useraccount + "'>前往制作</a></p> </div>";

             }  else if (type == "UserCollection")
             {
                 retstr += "   <div class='usercptit'><p class='bt'>用户收藏 </p> ";
                 retstr += "     <div class='finaljytcon100'><p class='finaljytinn' style='width:" + datacount + "px;' ></p> <p class='jyst'>" + datacount + "/100 </p></div> </div>";
             } else if (type == "Medals")
             {
                 retstr += "   <div class='usercptit'><p class='bt'>获得称号 " + datacount + "/" + datacount + " </p> ";
                 retstr += "     <p class='usersc100'><p style='width:" + datacount + "px;' ></p></p> </div>";
             } 
           
              
            return retstr;
           
        }
         #endregion
         #region //用户制作的菜谱列表
        public String  CreateUserProductionImage( IList<UserProductions> Lists,int presentindex,int pages,String actype)
        {
            
            string retstr = "";
            int i = 0;
            string retstrbottom = "";
            
            foreach(UserProductions list in Lists)
            {
                retstr += " <div class='usercp'>";
                retstr += " <img src='../../images/" + list.CoverImg + "' onclick='getmenudetails(&quot;userproduction&quot;,&quot;" + list.MenuNumber + "&quot;)' />";
                retstr += "  <p class='hj1' onclick='editmenu(&quot;" + list.MenuNumber + "&quot;)'>修改</p><p class='hj1' onclick='deletemenu(&quot;" + list.MenuNumber + "&quot;,&quot;" + list.MenuName  + "&quot;)'>删除</p>";
              retstr += "</div>";  
            }
            
            retstrbottom = getDataBottomimage("getUserProduction2", presentindex, pages,actype);
           
            retstr = retstr + retstrbottom;
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
         #endregion  


        
         
    }
}

 
     