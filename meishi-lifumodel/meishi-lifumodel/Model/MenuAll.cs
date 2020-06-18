using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meishi_lifumodel.Model
{
    public class MenuAll
    {

    /// <summary>
    /// 用于单个菜谱详细页面
    /// 获取关于菜谱的所有信息
    /// 菜谱的基本信息
    /// 菜谱的教学
    /// 用户的信息
    /// </summary>
    public String MenuNumber { get; set; }
    public String MenuName   { get; set; }
   
    public String Introduces { get; set; }
    public String Type       { get; set; }
    public String TimeMade   {get; set; }    
    public String Collection { get; set; }
    public String CoverImg   { get; set; }
    public String KeyWord   {get; set; }
   // public String Relevant   {get; set; }    
    public String Status     { get; set; }
    public String Positives   { get; set; }
    public String Negatives { get; set; }
   
    public String  MenuND{ get; set; }    
  //public String UserName { get; set; }
    public String ProducerNumber { get; set; }
    
  
    public String MenuMainIngredient { get; set; }
    public String MenuFuliao {get; set; }    
    public String MenuGY { get; set; }
    public String MenuKW { get; set; }
        
    public String   MenuFL{ get; set; }    
    public String PreparationTime { get; set; }
    public String CookingTime{ get; set; }
    public String MenuSteps{get; set; }
    public String MenuTips { get; set; }    
                      
    }
}