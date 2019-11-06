using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//****************************************************
using System.ComponentModel.DataAnnotations;   // *** 請自己修改！***  ValidationAttribute得搭配這個命名空間
//****************************************************


namespace MVC_Validation.Models
{
    /// <summary>
    /// ***** 自訂驗證 （Custom Validation）屬性 *****
    /// 
    ///  (1) 建議類別名稱的最後使用「Attribute」 
    ///  (2) 「日期區間」的驗證
    ///  
    ///  [MyValidateDateRange(MyStartDate = "1/1/1950", MyEndDate = "1/1/2025", ErrorMessage = "日期區間，只能在1950年以後~2025年之前")]   
    ///  
    /// 範例來源  https://stackoverflow.com/questions/27182606/asp-mvc-5-client-validation-for-range-of-datetimes
    /// </summary>

    //                                                                // *** 重點！！********* 請自己修改！
    public class MyValidateDateRange2Attribute : ValidationAttribute       // 搭配 System.ComponentModel.DataAnnotations命名空間
    {   //                                                           // *** 重點！！********* 請自己修改！

        // ****** 請自己修改 **************************************** (start)
        // 日期區間，允許修改、輸入「起迄日」
        public string MyStartDate { get; set; }    // string 改成 DateTime會出錯
        public string MyEndDate { get; set; }
        // ****** 請自己修改 **************************************** (end)


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   //        ********** 覆寫，請自己實作

            // https://msdn.microsoft.com/zh-tw/library/dd730022(v=vs.110).aspx
            // 參數 (1) value : System.Object  要驗證的值。 (2) validationContext : 驗證作業的相關內容資訊。
            // 傳回值 :  ValidationResult 類別的執行個體。

            // ****** 請自己修改 **************************************** (start)
            DateTime dt = (DateTime)value;
            // 日期區間（起迄日）
            if (value != null && dt >= Convert.ToDateTime(MyStartDate) && dt <= Convert.ToDateTime(MyEndDate))
            {
                return ValidationResult.Success;   // 驗證成功
            }
            else
            {   // 第一種作法，驗證失敗會出現這一句錯誤訊息。
                //return new ValidationResult("[自訂驗證 的 錯誤訊息] 抱歉～日期區間，不符合或超出範圍");

                //第二種作法，這裡使用空字串（""）。驗證失敗就會使用 UserTable.cs裡面的 [ ErrorMessage=""] 錯誤訊息
                return new ValidationResult("");
            }
            // ****** 請自己修改 **************************************** (end)            
        }

        // 補充範例：
        // http://ezzylearning.com/tutorial/creating-custom-validation-attribute-in-asp-net-mvc
        // 微軟中文說明 https://msdn.microsoft.com/zh-tw/library/cc668224(v=vs.100).aspx
    }
}
