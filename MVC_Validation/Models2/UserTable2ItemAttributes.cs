using MVC_Validation.Models;
using MVC_Validation.Models2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// 每個欄位上方的 [ ]符號，就得搭配這個命名空間
using System.Linq;
using System.Web;

namespace MVC_Validation.Models2
{
    public class UserTable2ItemAttributes
    {
        [Key]    // 主索引鍵（P.K.）
        [Display(Name = "ID名稱(UserName，必填)")]
        public int UserId { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}，至少要有 {2} 個字(最長允許 {1} 個字)")]
        [Display(Name = "名稱(UserName，必填)")]
        [Required(ErrorMessage = "*** 自訂訊息 *** 必填欄位 ***")]     // 必填欄位
        public string UserName { get; set; }


        [StringLength(1)]
        [Display(Name = "性別(UserSex)")]
        public string UserSex { get; set; }


        //====================================================================
        [Display(Name = "生日(UserBirthDay)")]
        [DataType(DataType.Date)]    // 只有日期 - 「年月日」。如果是 DateTime就是「日期與時間」
        // 加了DataType，請使用 Chrome瀏覽器來觀賞。會出現簡單的「日曆」欄位。

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]   // 設定日期為 yyyy/MM/dd 格式

        // *** 因為 jQuery改版，後續變成有問題 ***  
        // 設定日期區間（月/日/年）的驗證
        //[Range(typeof(DateTime), "1/1/1950", "1/1/2025" ,ErrorMessage = "日期區間，只能在1950年以後~2025年之前")]   
        // 原廠範例 https://msdn.microsoft.com/zh-tw/library/system.componentmodel.dataannotations.rangeattribute(v=vs.110).aspx
        // 「日期區間」的驗證，無效。 解法如下 https://stackoverflow.com/questions/27182606/asp-mvc-5-client-validation-for-range-of-datetimes

        // *** 自訂驗證 Custom Validation 屬性 ***   
        // 所以用 My 開頭命名。 詳見 /Models1Validation目錄下的 MyValidateDateRangeAttribute.cs檔案
        [MyValidateDateRange2(MyStartDate = "1/1/1950", MyEndDate = "1/1/2025", ErrorMessage = "日期區間，只能在1950年以後~2025年之前")]
        public DateTime UserBirthDay { get; set; }
        //====================================================================


        [StringLength(15, ErrorMessage = "*** 自訂訊息 *** 手機號碼不得超過15個數字 ***")]
        [Display(Name = "手機號碼(UserMobilePhone，必填)")]
        [RegularExpression(@"^(09)([0-9]{8})$")]   // 前兩個數字必須是09，後面跟著八個數字（必須是0~9的數字）。
        // 正規運算、正規表達（regular expression）。  ^符號 代表開始，$符號 代表結束。
        [Required]     // 必填欄位
        public string UserMobilePhone { get; set; }


        //=== 補充說明 =======================================(start)
        //public string Passwd { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("類別名稱.Passwd", ErrorMessage = "錯誤訊息")]   
        ////// 兩個屬性的值互相比較，例如，輸入密碼後，再次確認

        //[System.ComponentModel.DataAnnotations.Compare("Passwd")]
        ////因為另一個 System.Web.Mvc命名空間 也有「Compare」關鍵字，為了避免困擾，所以要寫清楚。
        //public string PasswdConfirm { get; set; }
        //=== 補充說明 =======================================(end)
    }
}