using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.BLL
{
    public class BLLuser
    {

        #region //用户注册
        public int UserRegister(String username, String password, String Account, String actime)//用户注册
        {
            DAL.DALuser user = new DAL.DALuser();

            return user.UserRegister(username, password, Account, actime);
        }
        #endregion
        #region //用户登录
        public IList<User> Userlogin(String username, String password)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.Userlogin(username, password);

        }
        #endregion
        #region //获取用户信息byAccount
        public IList<User> getUser(String Account)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getUser(Account);

        }
        #endregion
         #region //获取用户属性byAccount
        public IList<UserAttribute> getUserAttribute(String Account)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getUserAttribute(Account);

        }
        #endregion

       
         #region //获取用户好友申请
        public IList<FriendApplication> getFriendApplication(String Account,int size,int index)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getFriendApplication(Account,size,index);

        }
        #endregion
        
       #region //获取用户历史操作记录
        public IList<NewNotice> getHistoricalRecord2(String Account)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getHistoricalRecord2(Account);

        }
        #endregion
        #region //获取用户历史操作记录
        public IList<NewNotice> getHistoricalRecord(String Account,String ctype, int size, int index)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getHistoricalRecord(Account, ctype,size,index);

        }
        #endregion
        #region //获取用户新信息
        public IList<UserNotices> getRecord(String Account, String ctype, int size, int index)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getRecord(Account, ctype,size,index);

        }
        #endregion
        #region //获取用户制作的菜谱
        public IList<UserProductions> GetUserProduction(string usernumber, int Size,int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetUserProduction(usernumber, Size,index);
        }
        #endregion

       

         #region //获取用户关注的用户
        public IList<User> GetEditorList(String orderby,string bywhat, int Size,String index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetEditorList(orderby,bywhat, Size, index);
        }
        #endregion

        #region //获取用户关注的用户
        public IList<UserFollows> GetUserPersonFollow(String orderby,string usernumber, int Size,int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetUserPersonFollow(orderby,usernumber, Size, index);
        }
        #endregion
         #region //获取用户添加的好友
        public IList<UserFollows> getUserFriends(string usernumber, int Size,int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.getUserFriends(usernumber, Size,index);
        }
        #endregion
          
         #region //插入搜索
        public int searchfeverinsert(String keyword,string sid)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.searchfeverinsert(keyword, sid);
        }
        #endregion 
          #region //跟新
        public int searchfeverupdate(String keyword,string ff)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.searchfeverupdate(keyword, ff);
        }
        #endregion 
        
        #region //获取搜索
        public IList<SearchFever> GeSearchFeverList(String bywhat,int size, int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GeSearchFeverList(bywhat,size, index);
        }
        #endregion 
        #region //获取搜索
        public IList<SearchFever> GetSearchFever(String keyword)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetSearchFever(keyword);
        }
        #endregion 

        #region //获取用户搜索
        public IList<User> GetUserSearch(String ordery,string sval, string sby, int size, int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetUserSearch(ordery,sval, sby, size, index);
        }
        #endregion 
       
        #region //获取陌生人列表
        public int usercomment(String Account,String Ctype,String Comment,String Obnumber,String picture,String CommentNumber)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.usercomment(Account, Ctype, Comment, Obnumber, picture, CommentNumber);
        }
        #endregion 
        #region //获取陌生人列表
        public IList<User> getStrangerList(String orderby,string Account, int size,int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.getStrangerList(orderby,Account, size, index);
        }
        #endregion 
        
        
       #region //修改单个属性值
        public int AlterSingleAttr(String table, String Attri, String val, String bywhat)
        {
           
            DAL.DALuser user = new DAL.DALuser();

            return user.AlterSingleAttr(table, Attri, val, bywhat);

        }
        #endregion
        #region //记录用户行为
        public int InsertUserAction(String Account, string actitle, string ctype, String actime, String content)
        {
           
            DAL.DALuser user = new DAL.DALuser();

            return user.InsertUserAction(Account, actitle, ctype, actime, content);

        }
        #endregion
        #region //关注该用户
        public int AddUser(String Account, string ObCollectionNumber, string ObCollection)
        {

            DAL.DALuser user = new DAL.DALuser();
            user.UpdateFollowNum(ObCollectionNumber, ObCollection, "useradd");
            return user.AddUser(Account, ObCollectionNumber);

        }
        #endregion
        #region //关注该用户
        public int FollowUser(String Account, string ObCollectionNumber, string ObCollection)
        {

            DAL.DALuser user = new DAL.DALuser();
            user.UpdateFollowNum(ObCollectionNumber,  ObCollection,"userfollow");
            return user.FollowUser(Account, ObCollectionNumber);

        }
        #endregion
        
        #region //删除该用户
        public int DeleteFriend(String Account, string ObCollectionNumber, string ObCollection) 
        {

            DAL.DALuser user = new DAL.DALuser();
            user.UpdateFollowNum(ObCollectionNumber, ObCollection, "useradd");
            return user.DeleteFriend(Account, ObCollectionNumber, ObCollection);

        }
        #endregion
        #region //取消关注该用户
        public int UnFollowUser(String Account, string ObCollectionNumber, string ObCollection) 
        {

            DAL.DALuser user = new DAL.DALuser();
            user.UpdateFollowNum(ObCollectionNumber, ObCollection, "user");
            return user.UnFollowUser(Account, ObCollectionNumber, ObCollection);

        }
        #endregion
        
        #region //获取称号
        public IList<UserMedalsView> getMedals(string Account, int Size, int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.getMedals(Account, Size, index);
        }
        #endregion

        
             #region //获取用户收藏的菜谱
        public IList<UserProductions> GetSingleUserMenu(string menunumber)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetSingleUserMenu(menunumber);
        }
        #endregion
        #region //获取用户收藏的菜谱
        public IList<UserCollections> GetUserMenuCollection(string usernumber, int Size,int index)
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetUserMenuCollection(usernumber, Size, index);
        }
        #endregion
        #region //收藏该菜谱
        public int LikeMenu(String Account, string ObCollectionNumber, string ObCollection)
        {

            DAL.DALuser user = new DAL.DALuser();
            user.UpdateFollowNum(ObCollectionNumber, ObCollection, "menu");
            return user.LikeMenu(Account, ObCollectionNumber, ObCollection);

        }
        #endregion
        #region //取消收藏该菜谱
        public int DisLikeMenu(String Account, string ObCollectionNumber, string ObCollection)
        {

            DAL.DALuser user = new DAL.DALuser();
            user.UpdateFollowNum(ObCollectionNumber, ObCollection, "menu");
            return user.DisLikeMenu(Account, ObCollectionNumber, ObCollection);

        }
        #endregion

        #region 获取数据条数
        public int GetDataCount(String bywhat,String tablename)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.GetDataCount(bywhat,tablename);

        }
        #endregion
        #region 获取用户称号
        public IList<UserMedalsView> getUserMedals(String Account)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.getUserMedals(Account);

        }
        #endregion
       

        public int UserAdd(string UserName,string Account,string PassWord,string PhoneNumber,string UserImg,string UserNumber)//用户添加
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.UserAdd(UserName, Account, PassWord, PhoneNumber, UserImg, UserNumber);

        }
        public int UserEdit(string UserName, string Account, string PassWord, string PhoneNumber, string UserImg, string UserNumber)//用户修改
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.UserEdit(UserName, Account, PassWord, PhoneNumber, UserImg, UserNumber);

        }
        public int MainMenusAdd(string menuname,string MenuNumber,string  Introduces,string Type,string TimeMade,string Collection,string Relevant,string CoverImg,string TeachingNumber,string TeachingType,string ProducerNumber,string ingredients)//主菜单添加
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.MainMenusAdd(menuname, MenuNumber, Introduces, Type, TimeMade, Collection, Relevant, CoverImg, TeachingNumber, TeachingType, ProducerNumber, ingredients);

        }
        public int MainMenusEdit(string menuname, string MenuNumber, string Introduces, string Type, string TimeMade, string Collection, string Relevant, string CoverImg, string TeachingNumber, string TeachingType, string ProducerNumber, string ingredients)//主菜单修改
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.MainMenusEdit(menuname, MenuNumber, Introduces, Type, TimeMade, Collection, Relevant, CoverImg, TeachingNumber, TeachingType, ProducerNumber, ingredients);

        }

        public int FoodProductionUpdate(string menunumber, string menuname, string menutype, string menuimg, string introduce, string Tips, string Account, String kw, String gy, String mainsc, String fl, String bzall)//菜品修改
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.FoodProductionUpdate(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall);
        }
        public int FoodProduction(string menunumber, string menuname, string menutype, string menuimg, string introduce, string Tips, string Account, String kw, String gy, String mainsc, String fl, String bzall, string TimeMade)//菜品制作
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.FoodProduction(menunumber, menuname, menutype, menuimg, introduce, Tips, Account, kw, gy, mainsc, fl, bzall, TimeMade);
        }
        public int FoodProductionedit(string foodintroduce, string foodmaterials, string foodname, string foodtype, string usernumber, string foodnumber, string foodimg)//用户修改菜品
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.FoodProductionedit( foodintroduce, foodmaterials,  foodname, foodtype, usernumber, foodnumber, foodimg);
        
        }
        public int GetUserFoodProductionCount( string usernumber)//菜品制作
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetUserFoodProductionCount(usernumber);
        }

 



        public int AdminClassDel(string classid)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.AdminClassDel(classid);
        }
        public int AdminClassAdd(string classid, string classchild, string classparent)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.AdminClassAdd(classid, classchild, classparent);
        }
        public int AdminClassAlter( string classid, string classchild, string classparent)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.AdminClassAlter(classid, classchild, classparent);
        }

        public int AdminIngredientDel(string IngredientNumber)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.AdminIngredientDel(IngredientNumber);
        }
        public int AdminIngredientAdd(string IngredientNumber, string IngredientName, string IngredientIntroduction,string NutritiveValue,string Negatives,string CookingTips,string EdibleEffect,string CoverImg)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.AdminIngredientAdd(IngredientNumber, IngredientName, IngredientIntroduction, NutritiveValue, Negatives, CookingTips, EdibleEffect, CoverImg);
        }
        public int AdminIngredientAlter(string IngredientNumber, string IngredientName, string IngredientIntroduction,string NutritiveValue,string Negatives,string CookingTips,string EdibleEffect)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.AdminIngredientAlter(IngredientNumber, IngredientName, IngredientIntroduction, NutritiveValue, Negatives, CookingTips, EdibleEffect);
        }

        public int AdminProductionDel(string foodnumber)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            user.AdminStepDel(foodnumber);
            return user.AdminProductionDel(foodnumber);
        }
        public int UserProductionDel(string foodnumber)//用户菜品删除
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.UserProductionDel( foodnumber);
        }
        public IList<UserProductions> GetUserSingleProduction(string usernumber, string menunumber)//用户菜品编辑信息获取
        {
            DAL.DALuser user = new DAL.DALuser();
            return user.GetUserSingleProduction(usernumber, menunumber);
        }





        public int Followcount(String UserNumber, String ObUserNumber)
        {

            DAL.DALuser collection = new DAL.DALuser();

            return collection.Followcount(UserNumber, ObUserNumber);//判断是否已关注

        }
        public int Collectcount(String UserNumber, String MenuNumber)
        {

            DAL.DALuser collection = new DAL.DALuser();

            return collection.Collectcount(UserNumber, MenuNumber);//判断是否已收藏

        }
              #region 后台数据管理
        public IList<User> GetUserList(String orderby,int size,int dataindex)
        {
            
            DAL.DALuser user = new DAL.DALuser();

            return user.GetUserlist(orderby,size,dataindex);

        }

         public IList<Ingredient> GetIngredientList(String orderby,int size,int dataindex)
        {
            
            DAL.DALuser user = new DAL.DALuser();

            return user.GetIngredientList(orderby, size, dataindex);

        }
         public IList<Classification> GetClassificationList(String orderby, int size, int dataindex)
        {
            
            DAL.DALuser user = new DAL.DALuser();

            return user.GetClassificationList(orderby, size, dataindex);

        }
         public IList<MenuAll> GetMenuAllList(String orderby, int size, int dataindex)
        {
            
            DAL.DALuser user = new DAL.DALuser();

            return user.GetMenuAllList(orderby, size, dataindex);

        }
 
         public int MenuUpdate(string menunumber, string menuname, string menutype, string menuimg,  string Account)//菜品修改
         {
             DAL.DALuser user = new DAL.DALuser();
             return user.MenuUpdate(menunumber, menuname, menutype, menuimg, Account);
         }
         public int MenuUpdate2(string menunumber, String mainsc, String fl, String gy,  String kw,  string Tips)//菜品修改
         {
             DAL.DALuser user = new DAL.DALuser();
             
             return user.MenuUpdate2(menunumber, mainsc, fl, gy, kw,Tips);
         }
         public int MenuAdd(string menunumber, string menuname, string menutype, string menuimg,  string Account,String TimeMade)//菜品修改
         {
             DAL.DALuser user = new DAL.DALuser();
             return user.MenuAdd(menunumber, menuname, menutype, menuimg,Account,TimeMade);
         }
         public int MenuAdd2(string menunumber, String mainsc, String fl, String gy, String kw, string Tips)//菜品修改
         {
             DAL.DALuser user = new DAL.DALuser();

             return user.MenuAdd2(menunumber, mainsc, fl, gy, kw, Tips);
         }
         

             #endregion
       
       
       
    }
}