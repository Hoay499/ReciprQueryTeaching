using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.BLL
{
    public class BLLmenu
    {

        
         #region //通过菜谱编号获取单个菜谱
        public IList<UserProductions > GetSingleUserMenu(String MenuId)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetSingleUserMenu(MenuId);
        }
        #endregion
        #region //通过菜谱编号获取单个菜谱
        public IList<MenuAll> GetSingleMenu(String MenuId)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetSingleMenu(MenuId);
        }
        #endregion
        #region //通过菜谱编号获取单个菜谱
        public IList<SimpleMenu> GetSimpleSingleMenu(String MenuId)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetSimpleSingleMenu(MenuId);
        }
        #endregion
         #region //获取当前菜谱不同工艺的做法
        public IList<MenuAll> GetMenuByOtherPractices(String MenuName, String MenuGY)
        {
            DAL.DALmenu menu = new DAL.DALmenu();


            String sql = "select * from  menualldetails where KeyWord ='" + MenuName + "' and MenuGY ='" + MenuGY + "'";


            return menu.GetMenuByIdenticalGY(sql);
        }
        #endregion
        #region //获取当前菜谱相同工艺的不同做法
        public IList<MenuAll> GetMenuByIdenticalGY(String MenuNumberList,String MenuName, String MenuGY)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            String[] MenuNList = MenuNumberList.Split('/');


            String notin = "  where menunumber not in(";
            foreach (string s in MenuNList)
            {
                notin = notin + "'" + s + "',";
            }
            String sql = "select * from  (select * from menualldetails where MenuGY='" + MenuGY + "' and MenuName like '%" + MenuName + "') as a" + notin + ")";


            return menu.GetMenuByIdenticalGY(sql);
        }
        #endregion
        #region //获取当前菜谱的其他做法工艺
        public IList<MenuPractices> GetCurrentMenuElseGY(String currentmenunumber, String menuname, String menuTechnology, String Attribute)
        {
            DAL.DALmenu menu = new DAL.DALmenu();

            String sql = "select distinct MenuGY from  menualldetails where MenuName like '%" + menuname + "%'  and " + Attribute + "<> '" + menuTechnology + "'";


            return menu.GetCurrentMenuElseGY(sql);
        }
        #endregion
        //#region //通过一个属性获取简单菜谱
        //public IList<SimpleMenu> GetSimpleMenuByOneAttribute(String val,String Attribute)
        //{
        //    DAL.DALmenu menu = new DAL.DALmenu();
        //    String sql="select * from  menualldetails where "+Attribute+"='"+val+"'";
        //   // return menu.GetSimpleMenuByOneAttribute(sql);
        //}
        //#endregion
     
        
        #region //通过关键字获取相似菜谱(同种菜的相似做法)
        public IList<MenuAll> GetSimilarMenu(String Keyword,String MenuNumber)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetSimilarMenu(Keyword, MenuNumber);
        }
        #endregion
        
        #region //获取食材搭配信息通过编号
        public IList<IngredientTaboo> GetIngredientTaboo(String IngredientNumber)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetIngredientTaboo(IngredientNumber);
        }
        #endregion

        
        
         #region //获取食材信息通过编号
        public IList<SimpleMenu> GetRelavantMenuA(String sql)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetRelavantMenuA(sql);
        }
        #endregion
        #region //获取食材信息通过编号
        public IList<recipeteachinginformation> GetRelavantMenu(String IngredientName)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetRelavantMenu(IngredientName);
        }
        #endregion
        #region //获取食材信息通过编号
        public IList<Ingredient> GetIngredientDetail(String by,String val)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetIngredientDetail(by,val);
        }
        #endregion
        //#region //通过主食材获取菜谱
        //public IList<MenuAll> GetIngredientDetail(String MenuId)
        //{
        //    DAL.DALmenu menu = new DAL.DALmenu();
        //    return menu.GetIngredientDetail(MenuId);
        //}
        //#endregion
        #region //通过菜谱编号获取菜谱评论
        public IList<UserComment> GetUserComment(String val)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetUserComment(val);
        }
        #endregion
        #region //通过评论编号获取用户评论的评论
        public IList<UserComment> GetUserComment2(String val)
        {
            DAL.DALmenu menu = new DAL.DALmenu();
            return menu.GetUserComment2(val);
        }
        #endregion

        #region //获取用户收藏的菜单
        public IList<UserCollections> GetMenuCollection(string sclx, String UserNumber, int size)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.GetMenuCollection(sclx, UserNumber, size);

        }
        #endregion
        #region //获取用户关注的用户
        public IList<UserCollections> GetUserpeopleCollection(string sclx, String UserNumber, int size)
        {

            DAL.DALuser user = new DAL.DALuser();

            return user.GetMenuCollection(sclx, UserNumber, size);

        }
        #endregion 

        #region create list data html
        //读多条数据
        public IList<MenuAll> GetMenuList(String type, String value, int Size, int index)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetMenuList(type, value, Size, index);

        }
        
        public IList<Ingredient> GetsimpleIngredientList(String type, String value, int Size, int index)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetsimpleIngredientList(type, value, Size, index);

        }
        public IList<SimpleMenu> GetsimpleMenuList(String type, String value, int Size, int index)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetsimpleMenuList(type, value, Size, index);

        }
       

        public IList<SimpleMenu> GetMenu(String type, int Size,int index)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetMenu(type, Size,index);

        }
        public int GetMenuCount(String type)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetMenuCount(type);

        }
        #endregion end of  create list data html

        
        //读取菜单
        public IList<SimpleMenu> GetMenudetail(String MenuId)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetMenudetail(MenuId);

        }
        public IList<User> GetUserinfo(String UserId,String Type)
        {

            DAL.DALmenu menu = new DAL.DALmenu();

            return menu.GetUserinfo(UserId,Type);

        }
        
    }
}