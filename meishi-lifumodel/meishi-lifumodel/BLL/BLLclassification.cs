using meishi_lifumodel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.BLL
{
    public class BLLclassification
    {

        public IList<Classification> GetClassificationListBywhat(String bywhat)
        {

            DAL.DALclassification menu = new DAL.DALclassification();


            return menu.GetClassificationListBywhat(bywhat);

        }
        public IList<Classification> GetClassificationList(String type)
        {

            DAL.DALclassification menu = new DAL.DALclassification();

            
            return menu.GetClassificationList(type);

        }
        public IList<MenuCollocation> GetMenuCollocationList(String type, String scType)
        {

            DAL.DALclassification menu = new DAL.DALclassification();


            return menu.GetMenuCollocationList(type, scType);

        }

        public IList<SimpleMenu> GetSimpleMenuListnewlist(int index, int size)
        {

            DAL.DALclassification menu = new DAL.DALclassification();


            return menu.GetSimpleMenuListnewlist(index, size);

        }
        public IList<SimpleMenu> GetSimpleMenuList(int index, int size)
        {

            DAL.DALclassification menu = new DAL.DALclassification();


            return menu.GetSimpleMenuList(index, size);

        }
        public IList<HealthNews> GetHealthNewsList(int index,int size)
        {

            DAL.DALclassification menu = new DAL.DALclassification();


            return menu.GetHealthNewsList(index, size);

        }
        
    }
}