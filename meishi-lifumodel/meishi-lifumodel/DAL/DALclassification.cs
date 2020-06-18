using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.DAL
{
    public class DALclassification
    {


        public IList<Classification> GetClassificationListBywhat(String bywhat)
        {
           
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menu_classification where  " + bywhat;
            return b.ExcuteQuery<Classification>(sql);

        }
        public IList<Classification> GetClassificationList(String type)
        {
           
            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menu_classification where Category_parent='" + type + "'";
            return b.ExcuteQuery<Classification>(sql);

        }

        public IList<SimpleMenu> GetSimpleMenuListnewlist(int index, int size)
        { 

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails order by Id desc limit " + index + "," + size;
            return b.ExcuteQuery<SimpleMenu>(sql);

        }
        public IList<SimpleMenu> GetSimpleMenuList(int index, int size)
        { 

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menualldetails order by id desc limit " + index + "," + size;
            return b.ExcuteQuery<SimpleMenu>(sql);

        }
        public IList<HealthNews> GetHealthNewsList(int index,int size)
        { 

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from healthnews limit "+index+","+size;
            return b.ExcuteQuery<HealthNews>(sql);

        }
        public IList<MenuCollocation> GetMenuCollocationList(String type,String scType)
        { 

            DBHelper.SqlHelper b = new DBHelper.SqlHelper();
         //   String sql = "select * from Users where Type='" + type + "' and PassWord='" + Size + "'";
            String sql = "select * from menucollocation where PPC='" + type + "' and ParentC='" + scType + "'  order by Type   asc";
            return b.ExcuteQuery<MenuCollocation>(sql);

        }
      
        
    }
}