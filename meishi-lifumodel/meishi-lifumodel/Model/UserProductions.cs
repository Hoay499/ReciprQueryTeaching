using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.Model
{
    public class UserProductions
    {





         public int Id { get; set; }
        public String MenuName { get; set; }
        public String Type { get; set; }
          public String Introduce { get; set; }
        public String CoverImg { get; set; }
        public String Collection { get; set; }
          public String Tips { get; set; }
          public String MenuNumber { get; set; }
          public String Account { get; set; }
     
           
        public String MenuMainIngredient { get; set; }
        public String MenuFuliao { get; set; }
          public String MenuGY { get; set; }
        public String MenuKW { get; set; }
        public String MenuSteps { get; set; }
          public String TimeMade { get; set; }
          public String status { get; set; }
          public String MenuND { get; set; } 
      


        //menuFL,CookingTime,PreparationTime 
        public String menuFL { get; set; }
        public String CookingTime { get; set; }
        public String PreparationTime { get; set; }
    }
}