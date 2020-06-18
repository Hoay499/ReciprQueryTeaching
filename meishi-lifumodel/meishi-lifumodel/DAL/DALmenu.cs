using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.DAL
{
    public class DALmenu
    {

        #region //通过菜谱编号获取单个菜谱
        public IList<SimpleMenu> GetSimpleSingleMenu(String MenuId)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails where MenuNumber='" + MenuId + "'";
            return b.ExcuteQuery<SimpleMenu>(sql);

        }
        #endregion
         #region //通过菜谱编号获取单个菜谱
        public IList<UserProductions> GetSingleUserMenu(String MenuId)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from userproduction where MenuNumber='" + MenuId + "'";
            return b.ExcuteQuery<UserProductions>(sql);

        }
        #endregion
        
        #region //通过菜谱编号获取单个菜谱
        public IList<MenuAll> GetSingleMenu(String MenuId)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails where MenuNumber='" + MenuId + "'";
            return b.ExcuteQuery<MenuAll>(sql);

        }
        #endregion
        #region //通过一个属性获取简单菜谱
        public IList<SimpleMenu> GetSimpleMenuByOneAttribute(String sql)
        { 
            DBHelper.SqlHelper b = new DBHelper.SqlHelper(); 
            return b.ExcuteQuery<SimpleMenu>(sql); 
        }
        #endregion
        
       #region //获取当前菜谱相同工艺的不同做法
        public IList<MenuPractices> GetCurrentMenuElseGY(String sql)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            return b.ExcuteQuery<MenuPractices>(sql);
        }
        #endregion
        #region //获取当前菜谱相同工艺的不同做法
        public IList<MenuAll> GetMenuByIdenticalGY(String sql)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            return b.ExcuteQuery<MenuAll>(sql);
        }
        #endregion
        #region //通过关键字获取相似菜谱(同种菜的相似做法)
        public IList<MenuAll> GetSimilarMenu(String MenuName, String MenuNumber)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "select * from menualldetails where KeyWord like '%" + MenuName + "%' and MenuNumber <> '" + MenuNumber + "'";
            return b.ExcuteQuery<MenuAll>(sql);

        }
        #endregion
        #region //获取食材搭配信息通过编号
        public IList<IngredientTaboo> GetIngredientTaboo(String IngredientNumber)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "select * from foodtabooview where  FoodNumber='" + IngredientNumber + "'";
            return b.ExcuteQuery<IngredientTaboo>(sql);

        }
        #endregion
        //#region //通过编号获取食材信息
        //public IList<Ingredient> GetIngredientDetail(String IngredientNumber)
        //{

        //    DBHelper.SqlHelper b = new DBHelper.SqlHelper();

        //    String sql = "select * from ingredient where IngredientNumber='" + IngredientNumber + "'";
        //    return b.ExcuteQuery<Ingredient>(sql);

        //}
        //#endregion
        
        #region //通过编号获取食材搭配
        public IList<SimpleMenu> GetRelavantMenuA(String sql)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            //String sql = " select * from recipeteachinginformation where MenuMainIngredient like '%" + IngredientName + "%' limit 0,10";
            return b.ExcuteQuery<SimpleMenu>(sql);

        }
        #endregion
         #region //通过编号获取食材搭配
        public IList<recipeteachinginformation> GetRelavantMenu(String IngredientName)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = " select * from recipeteachinginformation where MenuMainIngredient like '%" + IngredientName + "%' limit 0,10";
            return b.ExcuteQuery<recipeteachinginformation>(sql);

        }
        #endregion
        
        #region //通过编号获取食材搭配
        public IList<Ingredient> GetIngredientDetail(String type, String val)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();

            String sql = "select * from ingredient where " + type + "='" + val + "'";
            return b.ExcuteQuery<Ingredient>(sql);

        }
        #endregion
        //#region //通过主食材菜谱 
        //public IList<MenuAll> GetIngredientDetail(String MenuName)
        //{

        //    DBHelper.SqlHelper b = new DBHelper.SqlHelper();

        //    String sql = "select * from menualldetails where MainIngredient='" + MenuName + "'";
        //    return b.ExcuteQuery<MenuAll>(sql);

        //}
        //#endregion
        #region //通过菜谱编号获取菜谱评论
        public IList<UserComment> GetUserComment(String MenuNumber)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();


            String sql = "select * from usercomment where MenuNumber='" + MenuNumber + "'";
            return b.ExcuteQuery<UserComment>(sql);

        }
        #endregion
        #region //通过评论编号获取用户评论的评论
        public IList<UserComment> GetUserComment2(String MenuNumber)
        {
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select * from usercomment where MenuNumber='" + MenuNumber + "'";
            return b.ExcuteQuery<UserComment>(sql);

        }
        #endregion
       
        public IList<Ingredient> GetsimpleIngredientList(String type, String value, int Size, int index)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from ingredient where " + type + "='" + value + "' limit " + index + "," + Size;
            return b.ExcuteQuery<Ingredient>(sql);

        }
        public IList<SimpleMenu> GetsimpleMenuList(String type, String value, int Size, int index)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails where " + type + " like '%" + value + "%' limit " + index + "," + Size;
            return b.ExcuteQuery<SimpleMenu>(sql);

        }
        public IList<MenuAll> GetMenuList(String type, String value, int Size, int index)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails where " + type + "='" + value + "' limit " + index + "," + Size;
            return b.ExcuteQuery<MenuAll>(sql);

        }

        public IList<SimpleMenu> GetMenu(String type, int Size,int index)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails where Type='" + type + "' limit " + index + "," + Size;
            return b.ExcuteQuery<SimpleMenu>(sql);

        }
        public int GetMenuCount(String type)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
            String sql = "select count(*) from mainmenus where Type='" + type + "'";
            //String sql = "select count(*) from Users ";
            int r = int.Parse(b.GetSingle(sql).ToString());
            return r;

        }
        public IList<SimpleMenu> GetMenudetail(String MenuId)
        {

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from mainmenus where MenuNumber='" + MenuId + "'";
            return b.ExcuteQuery<SimpleMenu>(sql);

        }

        public IList<User> GetUserinfo(String UserId, String Type)
        {
            String sql="";
            //if (Type == "NotAll")
            //    sql = "select UserName,UserImg from users where UserNumber='" + UserId + "'";
            
                sql = "select * from users where UserNumber='" + UserId + "'";


            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
             
            return b.ExcuteQuery<User>(sql);

        }

        
        
    }
}