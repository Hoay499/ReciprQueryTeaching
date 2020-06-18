using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.DAL
{
    public class DALuser
    {
        #region 用户注册
        public int UserRegister(String username, String password, String Account, String actime)//用户注册
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "insert into user (UserName,Account,PassWord,JoinTime) values ('" + username + "','" + Account + "','" + password + "','" + actime + "')";
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region 用户登录
        public IList<User> Userlogin(String Account, String password)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from user where Account='" + Account + "' and PassWord='" + password + "'";
            return b.ExcuteQuery<User>(sql);
        }
        #endregion
        #region 获取用户信息byaccount
        public IList<User> getUser(String Account)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from user where Account='" + Account + "'";
            return b.ExcuteQuery<User>(sql);
        }
        #endregion
         #region 获取用户信息byaccount
        public IList<UserAttribute> getUserAttribute(String Account)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from userattribute where Account='" + Account + "'";
            return b.ExcuteQuery<UserAttribute>(sql);
        }
        #endregion
       
        #region 根据bywhat获取记录数
        public int GetDataCount(String bywhat,String tablename)
        {
            String sql = "";
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            if (bywhat == "") sql = "select count(*) from " + tablename;
            else  sql = "select count(*) from "+tablename+" where "+bywhat;
            //  sql = "select count(*) from user where UserName='" + username + "' and PassWord='" + password + "'";
            //String sql = "select count(*) from Users ";
            int r = int.Parse(b.GetSingle(sql).ToString());
            return r; 
        }
        #endregion
        #region 获取用户称号
        public IList<UserMedalsView> getUserMedals(String Account)
        {
            String sql = "";
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            sql = "select * from  usermedals where Account='" + Account+"'";
            //  sql = "select count(*) from user where UserName='" + username + "' and PassWord='" + password + "'";
            //String sql = "select count(*) from Users ";
            return b.ExcuteQuery<UserMedalsView>(sql);
            
        }
        #endregion
          
      
          #region 用户历史操作记录
        public IList<NewNotice> getHistoricalRecord2(String Account)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from userhistory where Account='" + Account +  "' order by Id desc";
           // "' and ctype='" + ctype +
             return b.ExcuteQuery<NewNotice>(sql);
        }
        #endregion
           #region 用户历史操作记录
        public IList<NewNotice> getHistoricalRecord(String Account, String ctype, int size, int index)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from userhistory where Account='" + Account +  "' limit " + index + "," + size;
           // "' and ctype='" + ctype +
             return b.ExcuteQuery<NewNotice>(sql);
        }
        #endregion
        #region 用户信息
        public IList<UserNotices> getRecord(String Account, String ctype, int size, int index)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
             String sql ="";
             //if (ctype == "userPnoticeunread")
             //{
             //    sql = "select * from usernotices where Account='" + Account + "' and ctype='' limit " + index + "," + size;

             //}
             //else if (ctype == "usernoticeunread")
             //{
                 sql = "select * from usernotices where Account='" + Account + "' and ctype='" + ctype + "' limit " + index + "," + size;
           
              

             return b.ExcuteQuery<UserNotices>(sql);
        }
        #endregion
          #region 获取用户的好友请求
        public IList<FriendApplication> getFriendApplication(String Account,int size,int index)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from friendapplicationview where Account='" + Account  + "' limit "+index+","+size;
            return b.ExcuteQuery<FriendApplication>(sql);
        }
        #endregion
        
        #region 用户查看制作的菜品
        public IList<UserProductions> GetUserProduction(String Account, int size,int index)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from userproduction where  Account='" + Account + "' limit "+index+","+size;

            return b.ExcuteQuery<UserProductions>(sql);

        }
        #endregion
         #region 获取称号
        public IList<UserMedalsView> getMedals(String Account, int size, int index)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from usermedalsview where  Account='" + Account + "' limit " + index + "," + size;


            return b.ExcuteQuery<UserMedalsView>(sql);



        }
        #endregion 
        
       #region 用户查看自己收藏的菜谱
        public IList<UserProductions> GetSingleUserMenu(String MenuNumber)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from userproduction where  MenuNumber='" + MenuNumber + "' ";
            return b.ExcuteQuery<UserProductions>(sql);  
        }
        #endregion 
        #region 用户查看自己收藏的菜谱
        public IList<UserCollections> GetUserMenuCollection(String Account, int size,int index)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from usercollectionview where  Account='" + Account + "' limit "+index+","+size;
            return b.ExcuteQuery<UserCollections>(sql);  
        }
        #endregion 
        #region 用户查看自己添加的好友
        public IList<UserFollows> getUserFriends(String Account, int size,int index)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from userfollowview where  Account='" + Account + "' and `CollectionType`='userfriend' limit "+index+"," + size;

            return b.ExcuteQuery<UserFollows>(sql);
        }
        #endregion


        #region //获取用户关注的用户
        public IList<User> GetEditorList(String orderby, string bywhat, int Size, String index)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from user " + orderby + "  limit " + index + "," + Size;

            return b.ExcuteQuery<User>(sql);
        }
        #endregion
        #region 用户查看自己关注的用户
        public IList<UserFollows> GetUserPersonFollow(String orderby,String Account, int size, int index)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from userfollowview where  Account='" + Account + "' and CollectionType='userfollow' " + orderby + "  limit " + index + "," + size;

            return b.ExcuteQuery<UserFollows>(sql);
        }
        #endregion

        #region //插入搜索
        public int searchfeverinsert(String keyword, string sid)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();


            string sql = "insert into searchfever (SearchContent,SearchType,Fever) values ('" + keyword + "','" + sid + "',0)";
            return b.ExecuteSql2(sql);
            
        }
        #endregion
        #region //跟新
        public int searchfeverupdate(String keyword, string ff)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "update searchfever set Fever='" + ff + "' where SearchContent='" + keyword + "'";
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region //评论
        public int usercomment(String Account, String Ctype, String Comment, String Obnumber, String picture, String CommentNumber)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "insert into Comments  (MenuNumber,UserAccount,Comment,Picture,CommentNumber,CommentType)values('" + Obnumber + "','" + Account + "','" + Comment + "','" + picture + "','" + CommentNumber + "','" + Ctype + "')";
               
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region //获取搜索
        public IList<SearchFever> GeSearchFeverList(String bywhat,int size,int index)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from searchfever where "+bywhat+" order by Fever desc limit "+index+","+size;
            return b.ExcuteQuery<SearchFever>(sql);
        }
        #endregion 
        #region //获取搜索
        public IList<SearchFever> GetSearchFever(String keyword)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from searchfever where SearchContent like '%" + keyword + "%'";
            return b.ExcuteQuery<SearchFever>(sql);
        }
        #endregion 

             #region 获取陌生人列表
        public IList<User> GetUserSearch(String orderby,string sval, string sby, int size, int index)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String bywhat = "";
            if (sby == "zh")
            {
                bywhat = " Account='" + sval + "'";
            }
            else if (sby == "yhm")
            {
                bywhat = " UserName like '%" + sval + "%'";
            }
            
            string sql = "select * from user where  " + bywhat +orderby+ " limit " + index + "," + size;

            return b.ExcuteQuery<User>(sql);
        }
        #endregion
        #region 获取陌生人列表
        public IList<User> getStrangerList(String orderby,String Account, int size,int index)//
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            String bywhat = " where Account not in (select ObjectNumber from usercollection  where Account='" + Account + "'";
            bywhat += "and  (CollectionType='userfriend' or CollectionType='userfollow'))  and Account <> '" + Account + "'";
            string sql = "select * from user " + bywhat + orderby+" limit " + index + "," + size;
            

            return b.ExcuteQuery<User>(sql);
        }
        #endregion
       
        #region 关注/收藏人数更新
        public int UpdateFollowNum(string ObjectNumber, string ObCollection,String tablename)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
             string sql="";
            if(tablename=="user")
                sql = "update user set FollowersNum='" + ObCollection + "' where Account='" + ObjectNumber + "'";
            if(tablename=="menu")
                sql = "update mainmenus set Collection='" + ObCollection + "' where MenuNumber='" + ObjectNumber + "'";
            if (tablename == "userfollow")
                sql = "update user set FollowersNum='" + ObCollection + "' where Account='" + ObjectNumber + "'";
            if (tablename == "useradd")
                sql = "update user set FriendNum='" + ObCollection + "' where Account='" + ObjectNumber + "'";
            
            return b.ExecuteSql(sql); ;

        }
        #endregion
       
         #region 修改单个属性值
        public int AlterSingleAttr(String table, String Attri, String val, String bywhat)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "update  " + table + " set " + Attri + "='" + val + "' " + bywhat;
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region 记录用户行为
        public int InsertUserAction(String Account, string actitle, string ctype, String actime, String content)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "insert into historyrecord (Account,actime,content,ctype,actitle) values ('" + Account + "','" + actime + "','" + content + "','" + ctype + "','" + actitle + "')";
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region 添加该用户为好友
        public int AddUser(String Account, string ObCollectionNumber)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "insert into usercollection (ObjectNumber,Account,CollectionType) values ('" + ObCollectionNumber + "','" + Account + "','adduser')";
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region 关注该用户
        public int FollowUser(String Account, string ObCollectionNumber)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "insert into usercollection (ObjectNumber,Account,CollectionType) values ('" + ObCollectionNumber + "','" + Account + "','userfollow')";
            return b.ExecuteSql2(sql);
        }
        #endregion
        
        #region 删除好友
        public int DeleteFriend(String Account, string ObCollectionNumber, string ObCollection)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "delete from usercollection  where Account='" + Account + "' and ObjectNumber='" + ObCollectionNumber + "' and ";
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region 取消关注该用户
        public int UnFollowUser(String Account, string ObCollectionNumber, string ObCollection)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "delete from usercollection  where Account='" + Account + "' and ObjectNumber='" + ObCollectionNumber + "'";
            return b.ExecuteSql2(sql);
        }
        #endregion

         #region 关注该用户
        public int LikeMenu(String Account, string ObCollectionNumber, string ObCollection)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "insert into usercollection (ObjectNumber,Account,CollectionType) values ('" + ObCollectionNumber + "','" + Account + "','菜单收藏')";
            return b.ExecuteSql2(sql);
        }
        #endregion
        #region 取消关注该用户
        public int DisLikeMenu(String Account, string ObCollectionNumber, string ObCollection)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "delete from usercollection  where Account='" + Account + "' and ObjectNumber='" + ObCollectionNumber + "'";
            return b.ExecuteSql2(sql);
        }
        #endregion

     
       
       
        public int MainMenusAdd(string menuname, string MenuNumber, string Introduces, string Type, string TimeMade, string Collection, string Relevant, string CoverImg, string TeachingNumber, string TeachingType, string ProducerNumber, string ingredients)//主菜单添加
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();                                               
            String sql = "insert into mainmenus (menuname, MenuNumber, Introduces, Type, TimeMade, Collection, Relevant, CoverImg, TeachingNumber, TeachingType, ProducerNumber, ingredients) values ('" + menuname + "','" + MenuNumber + "','" + Introduces + "','" + Type + "','" + TimeMade + "','" + Collection +"','" + Relevant + "','" + CoverImg + "','" + TeachingNumber + "','" + TeachingType +"','" + ProducerNumber + "','" + ingredients + "')";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql2(sql);
        }
        public int MainMenusEdit(string menuname, string MenuNumber, string Introduces, string Type, string TimeMade, string Collection, string Relevant, string CoverImg, string TeachingNumber, string TeachingType, string ProducerNumber, string ingredients)//主菜单修改
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            // UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'                                                                                                                                                                                                                                                                       
            String sql = "update  mainmenus set menuname ='" + menuname +  "', Introduces='" + Introduces + "', Type='" + Type + "', TimeMade='" + TimeMade + "', Collection='" + Collection + "', Relevant='" + Relevant + "', CoverImg='" + CoverImg + "', TeachingNumber='" + TeachingNumber + "', TeachingType='" + TeachingType + "', ProducerNumber='" + ProducerNumber + "', ingredients='" + ingredients + "' where MenuNumber='" + MenuNumber +"'";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql2(sql);
        }
        //public int MainMenusAdd(string UserName, string Account, string PassWord, string PhoneNumber, string UserImg, string UserNumber)//用户添加
        //{

        //    DBHelper.SqlHelper b = new DBHelper.SqlHelper();
        //    String sql = "insert into Users (UserName, Account, PassWord, PhoneNumber, UserImg, UserNumber) values ('" + UserName + "','" + Account + "','" + PassWord + "','" + PhoneNumber + "','" + UserImg + "','" + UserNumber + "')";
        //    //String sql = "select count(*) from Users ";
        //    return b.ExecuteSql2(sql);
        //}
        //public int MainMenusEdit(string UserName, string Account, string PassWord, string PhoneNumber, string UserImg, string UserNumber)//用户修改
        //{

        //    DBHelper.SqlHelper b = new DBHelper.SqlHelper();
        //    // UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'
        //    String sql = "update  Users set UserName ='" + UserName + "', Account='" + Account + "', PassWord='" + PassWord + "', PhoneNumber='" + PhoneNumber + "', UserImg='" + UserImg + "', UserNumber='" + UserNumber + "'";
        //    //String sql = "select count(*) from Users ";
        //    return b.ExecuteSql2(sql);
        //}
        public int UserAdd(string UserName, string Account, string PassWord, string PhoneNumber, string UserImg, string UserNumber)//用户添加
        {

           DBHelper.SqlHelper b = new DBHelper.SqlHelper();
           String sql = "insert into Users (UserName, Account, PassWord, PhoneNumber, UserImg, UserNumber) values ('" + UserName + "','" + Account + "','" + PassWord +"','"+PhoneNumber+"','"+UserImg+"','"+UserNumber+"')";
           //String sql = "select count(*) from Users ";
           return b.ExecuteSql2(sql);
        }
        public int UserEdit(string UserName, string Account, string PassWord, string PhoneNumber, string UserImg, string UserNumber)//用户修改
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
           // UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'
            String sql = "update  Users set UserName ='" + UserName +  "', PassWord='" + PassWord + "', PhoneNumber='" + PhoneNumber + "', UserImg='" + UserImg + "', UserNumber='" + UserNumber + "'  where  Account='" + Account +"'";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql2(sql);
        }

        public int MenuAdd(string menunumber, string menuname, string menutype, string menuimg, string Account, string TimeMade)//菜品制作
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string TeachingVideoAddress = "none";
            String TeachingMenuNumber = "none";
            String Positives= "none";
            String Negatives = "none";
            String KeyWord = "none";
           // MenuName,MenuNumber,Introduces,Type,TimeMade,Collection,CoverImg,TeachingVideoAddress,TeachingMenuNumber,ProducerNumber,Status,Positives,Negatives,KeyWord
            String sql = "insert into mainmenus ( MenuName,MenuNumber,Type,TimeMade,Collection,CoverImg,TeachingVideoAddress,TeachingMenuNumber,ProducerNumber,Status,Positives,Negatives,KeyWord) ";
            sql += "values ('" + menuname + "','" + menunumber + "','"  + menutype + "','" + TimeMade + "','" + "0" + "','" + menuimg + "','" + TeachingVideoAddress + "','" + TeachingMenuNumber + "','" + Account + "','" + "none" + "','" + Positives + "','" + Negatives + "','" + KeyWord + "')";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int MenuAdd2(string menunumber, String mainsc, String fl, String gy, String kw,  string Tips)//菜品制作
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String MenuND = "0";
            String MenuFL = "none";
            String PreparationTime = "none";
            String CookingTime = "none"; 
            // MenuNumber,MenuMainIngredient,MenuFuliao,MenuGY,MenuKW,MenuND,MenuFL,PreparationTime,CookingTime,MenuSteps,MenuTips
            String sql = "insert into recipeteachinginformation (MenuNumber,MenuMainIngredient,MenuFuliao,MenuGY,MenuKW,MenuND,MenuFL,PreparationTime,CookingTime,MenuTips) ";
            sql += "values ('" + menunumber + "','" + mainsc + "','" + fl + "','" + gy + "','" + kw + "','" + MenuND + "','" + MenuFL + "','" + PreparationTime + "','" + CookingTime + "','"  + Tips + "')";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int MenuUpdate(string menunumber, string menuname, string menutype, string menuimg,  string Account)//菜品修改
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
             
            // String  TimeMade="none";
             String  TeachingVideoAddress="none";
            String  TeachingMenuNumber="none";
            String Positives = "none";
            String Negatives = "none";
            String KeyWord = "none"; 
            // Collection
          //Status
          //Positives
         //   Negatives
         //   KeyWord 

            String sql = "update  mainmenus set ";
            //sql +=" MenuNumber='"+menunumber+"',";
            sql += "MenuName='" + menuname + "',";
            sql += "Type='" + menutype + "',";
           
            sql += "CoverImg='" + menuimg + "',";
            sql += "TeachingVideoAddress='" + TeachingVideoAddress + "',";
            sql += "TeachingMenuNumber='" + TeachingMenuNumber + "',";
            sql += "ProducerNumber='" + Account + "',";
            sql += "Positives='" + Positives + "',";
            sql += "KeyWord='" + KeyWord + "',";
            sql += "Negatives='" + Negatives + "' ";
            sql += " where MenuNumber='" + menunumber + "'";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int MenuUpdate2(string menunumber, String mainsc, String fl, String gy, String kw, string Tips)//菜品修改
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper(); 

            String  nd="0";
             String  fenlaing="none";
            String  PreparationTime="none";
            String CookingTime = "none"; 

            String sql = "update  recipeteachinginformation set ";
            //sql +=" MenuNumber='"+menunumber+"',";
          //sql += "MenuNumber='" + menunumber + "',";
            sql += "MenuMainIngredient='" + mainsc + "',";
            sql += "MenuFuliao='" + fl + "',";
            sql += "MenuGY='" + gy + "',";
            sql += "MenuKW='" + kw + "',";
            sql += "MenuND='" + nd + "',";
            sql += "MenuFL='" + fenlaing + "',";
            sql += "PreparationTime='" + PreparationTime + "',";
            sql += "CookingTime='" + CookingTime + "', ";
           
             sql += "MenuTips='" + Tips + "'";
            sql += " where MenuNumber='" + menunumber + "'";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int FoodProductionUpdate(string menunumber, string menuname, string menutype, string menuimg, string introduce, string Tips, string Account, String kw, String gy, String mainsc, String fl, String bzall)//菜品制作
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "update  userproduction set ";
             //sql +=" MenuNumber='"+menunumber+"',";
            sql +="MenuName='"+menuname+"',";
            sql +="Type='"+menutype+"',";
            sql +="Introduce='"+introduce+"',";
            sql +="Tips='"+Tips+"',";
            sql +="MenuKW='"+kw+"',";
            sql +="MenuGY='"+gy+"',";
            sql += "MenuMainIngredient='" + mainsc + "',";
            sql += "MenuFuliao='" + fl + "',";
            sql += "MenuSteps='" + bzall + "' "; 
            sql += " where MenuNumber='" + menunumber + "'";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int FoodProduction(string menunumber, string menuname, string menutype, string menuimg, string introduce, string Tips, string Account, String kw, String gy, String mainsc, String fl, String bzall, string TimeMade)//菜品制作
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "insert into userproduction (MenuNumber, MenuName,Type,CoverImg, Introduce,Tips,Account, Collection,MenuKW,MenuGY,MenuMainIngredient,MenuFuliao,MenuSteps,TimeMade) ";
            sql += "values ('" + menunumber + "','" + menuname + "','" + menutype + "','" + menuimg + "','" + introduce + "','" + Tips + "','" + Account + "','" + "0" + "','" + kw + "','" + gy + "','" + mainsc + "','" + fl + "','" + bzall + "','" + TimeMade + "')";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int FoodProductionedit(string foodintroduce, string foodmaterials, string foodname, string foodtype, string usernumber, string foodnumber,string foodimg)//用户修改菜品
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "update  lf_userproduction set FoodName='" + foodname + "', FoodType='" + foodtype + "', FoodMatrials='" + foodmaterials + "',FoodIntroduce='" + foodintroduce + "',FoodImg='" + foodimg +  "'  where UserNumber='" + usernumber + "' and UserFoodNumber='" + foodnumber + "'";
            //String sql = "select count(*) from Users ";
            return b.ExecuteSql(sql);
        }
        public int GetUserFoodProductionCount(string usernumber)//用户制作菜品
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select count(*) from lf_userproduction where UserNumber='" + usernumber + "'";

            int r = int.Parse(b.GetSingle(sql).ToString());
            return r;
        
           
        }







        public int AdminClassDel(string classid)//用户菜品删除
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "delete from menu_classification where number='" + classid + "'"; 

            return b.ExecuteSql(sql);
        }
        public int AdminClassAdd(string classid, string classchild, string classparent)//用户菜品删除
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
           //  String number  ="none";
            // String Category_parent = "none";
            // String Classification_contents  ="none";
             String Navigation  ="none";

             String sql = "insert into menu_classification  (number,Category_parent,Classification_contents,Navigation)";
            sql += "values('" + classid + "','" + classchild + "','" + classparent + "','" + Navigation + "')";


            return b.ExecuteSql(sql);
        }
        public int AdminClassAlter(string classid, string classchild, string classparent)//用户菜品删除
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //  String number  ="none";
            // String Category_parent = "none";
            // String Classification_contents  ="none";
            String Navigation = "none";

            String sql = "update  menu_classification set ";
            // sql +=" IngredientNumber='"+menunumber+"',";
           // sql += "number='" + IngredientName + "',";

            sql += "Category_parent='" + classparent + "',";
            sql += "Classification_contents='" + classchild + "',";
            sql += "Navigation='" + Navigation + "'";

            sql += " where number='" + classid + "'";
            return b.ExecuteSql(sql);
        }
         

        public int AdminIngredientDel(string IngredientNumber)//用户菜品删除
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "delete from ingredient where IngredientNumber='" + IngredientNumber + "'"; 
            return b.ExecuteSql(sql);
        }
        public int AdminIngredientAdd(string IngredientNumber, string IngredientName, string IngredientIntroduction, string NutritiveValue, string Negatives, string CookingTips, string EdibleEffect, string CoverImg)//用户菜品删除
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String Taboo = "none";
            String FoodTaboo = "none";
            String Choose = "none";
            String Storage = "none";
            String Positives = "none";

            String sql = "insert into ingredient  (IngredientNumber,IngredientName,CoverImg,IngredientIntroduction,Positives,Negatives,Taboo,NutritiveValue,EdibleEffect,FoodTaboo,Choose,Storage,CookingTips)";
            sql += "values('" + IngredientNumber + "','" + IngredientName + "','" + CoverImg + "','" + IngredientIntroduction + "','" + Positives + "','" + Negatives + "','" + Taboo + "','" + NutritiveValue + "','" + EdibleEffect + "','" + FoodTaboo + "','" + Choose + "','" + Storage + "','" + CookingTips + "')";
               
           
            return b.ExecuteSql(sql);
        }
        public int AdminIngredientAlter(string IngredientNumber, string IngredientName, string IngredientIntroduction, string NutritiveValue, string Negatives, string CookingTips, string EdibleEffect)//用户菜品删除
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
              String Taboo = "none";
            String FoodTaboo = "none";
            String Choose = "none";
            String Storage = "none";
            String Positives = "none";

            String sql = "update  ingredient set ";
           // sql +=" IngredientNumber='"+menunumber+"',";
            sql += "IngredientName='" + IngredientName + "',";
          
          //  sql += "CoverImg='" + CoverImg + "',";
            sql += "IngredientIntroduction='" + IngredientIntroduction + "',";
            sql += "Positives='" + Positives + "',";
            sql += "Negatives='" + Negatives + "',";
            sql += "Taboo='" + Taboo + "',";
            sql += "NutritiveValue='" + NutritiveValue + "',";
            sql += "EdibleEffect='" + EdibleEffect + "', ";
            sql += "Choose='" + Choose + "', ";
            sql += "Storage='" + Storage + "', ";
            sql += "FoodTaboo='" + FoodTaboo + "',";
            sql += "CookingTips='" + CookingTips + "'";
            sql += " where IngredientNumber='" + IngredientNumber + "'";
            return b.ExecuteSql(sql);
        }


        public int AdminStepDel(string foodnumber)//用户删除菜品
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();


            String sql = "delete from recipeteachinginformation where MenuNumber=" + foodnumber;
            //String sql = "select count(*) from Users ";
            
            return b.ExecuteSql(sql);
        }
        public int AdminProductionDel(string foodnumber)//用户删除菜品
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();


            String sql = "delete from mainmenus where MenuNumber=" + foodnumber;
            //String sql = "select count(*) from Users ";
            
            return b.ExecuteSql(sql);
        }

        public int UserProductionDel(string foodnumber)//用户删除菜品
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();


            String sql = "delete from userproduction where MenuNumber=" + foodnumber;
            //String sql = "select count(*) from Users ";
            
            return b.ExecuteSql(sql);
        }

        public IList<UserProductions> GetUserSingleProduction(String UserNumber, string menunumber)//用户菜品编辑信息获取
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
            //String sql = "select count(*) from Users ";
            //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
            string sql = "select * from lf_userproduction where  UserNumber='" + UserNumber + "' and UserFoodNumber='" + menunumber + "'";


            return b.ExcuteQuery<UserProductions>(sql);


        }
      
        
        public int Collect(string sclx, String UserNumber, string CollectionNumber,string Collection)
        {

           DBHelper.SqlHelper b = new DBHelper.SqlHelper();
           //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
           //String sql = "select count(*) from Users ";
             //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
           string sql = "insert into lf_usercollection (UserNumber,CollectionNumber,CollectionType) values ('"+UserNumber+"','"+CollectionNumber+"','"+sclx+"')";
           //update mainmenus set  Collection='2' where MenuNumber='1'
           string sql2 = "update mainmenus set Collection='" + Collection + "' where MenuNumber='" + CollectionNumber + "'";
           b.ExecuteSql(sql2);
          return b.ExecuteSql2(sql);
         
            
    
        }
        public int CollectDel(String UserNumber, string CollectionNumber, string Collection)
        {

           DBHelper.SqlHelper b = new DBHelper.SqlHelper();
           //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
           //String sql = "select count(*) from Users ";
           //delete from lf_usercollection where UserNumber="001" and CollectionNumber="1"
           string sql = "delete from lf_usercollection  where UserNumber='" + UserNumber + "' and CollectionNumber='" + CollectionNumber + "'";
           //update mainmenus set  Collection='2' where MenuNumber='1'
           string sql2 = "update mainmenus set Collection='" + Collection + "' where MenuNumber='" + CollectionNumber + "'";
           b.ExecuteSql(sql2);
          return b.ExecuteSql2(sql);
         
            
    
        }
        public IList<UserCollections>  GetMenuCollection(string sclx, String UserNumber, int size)
        {

           DBHelper.SqlHelper b = new DBHelper.SqlHelper();
           //String sql = "select count(*) from Users where UserName='"+ username +"' and PassWord='"+ password+"'";
           //String sql = "select count(*) from Users ";
             //INSERT INTO table_name (列1, 列2,...) VALUES (值1, 值2,....)
           string sql = "select * from lf_usercollection where CollectionType='"+sclx+"' and UserNumber='"+UserNumber+"'";


           return b.ExcuteQuery<UserCollections>(sql);
         
           
    
        }

        public int Followcount(String UserNumber, String ObUserNumber)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select count(*) from userfollowview where Account='" + UserNumber + "' and ObjectNumber='" + ObUserNumber + "'";
            //String sql = "select count(*) from Users ";
            int r = int.Parse(b.GetSingle(sql).ToString());
            return r;

        }
        public int Collectcount(String UserNumber, String MenuNumber)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select count(*) from usercollection where Account='" + UserNumber + "' and ObjectNumber='" + MenuNumber + "'";
            //String sql = "select count(*) from Users ";
            int r = int.Parse(b.GetSingle(sql).ToString());
            return r;

        }

        #region 后台数据管理
        public IList<User> GetUserlist(String orderby, int size, int dataindex)//用户管理
        { 
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "select * from user order by  " + orderby + " limit " + dataindex + "," + size; 
            return b.ExcuteQuery<User>(sql); 
        }
         
        public IList<Ingredient> GetIngredientList(String orderby, int size, int dataindex)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "select * from ingredient  order by  " + orderby+" limit " + dataindex + "," + size ; 
            return b.ExcuteQuery<Ingredient>(sql); 
        }
        public IList<Classification> GetClassificationList(String orderby, int size, int dataindex)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "select * from menu_classification   order by  " + orderby + " limit " + dataindex + "," + size; 
            return b.ExcuteQuery<Classification>(sql); 
        }
        public IList<MenuAll> GetMenuAllList(String orderby, int size, int dataindex)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            string sql = "select * from menualldetails   order by  " + orderby + " limit " + dataindex + "," + size; 
            
            return b.ExcuteQuery<MenuAll>(sql); 
        }
        #endregion
        
    }
}