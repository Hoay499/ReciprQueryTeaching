using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.Model
{
    /// <summary>
    /// 简单菜谱信息用于菜谱列表展示界面
    /// </summary>
    public class SimpleMenu
    {
        public String MenuName { get; set; }
        public String Introduces { get; set; }
        public String MenuNumber { get; set; }
        public String CookingTime { get; set; }  
        public String Type { get; set; }
        public String TimeMade { get; set; }
        public String Collection { get; set; }
        public String CoverImg { get; set; }
        public String status { get; set; }
        public String MenuND { get; set; } 
        public String ProducerNumber { get; set; }
        public String MenuMainIngredient { get; set; }
        public String MenuGY { get; set; }
        public String MenuKW { get; set; }
        public String MenuFL { get; set; }
        public String PreparationTime { get; set; }
        public String UserImg { get; set; }  
        public String UserName { get; set; }  
        public String MenuScore { get; set; }  
         
    }
}