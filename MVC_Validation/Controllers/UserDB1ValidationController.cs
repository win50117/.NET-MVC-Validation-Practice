using MVC_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Validation.Controllers
{
    public class UserDB1ValidationController : Controller
    {
        //*************************************   連結 MVC_UserDB 資料庫  ********************************* (start)
        private UserDBContext _db = new UserDBContext();

        // 資料庫一旦開啟連線，用完就得要關閉連線與釋放資源。
        protected override void Dispose(bool disposing)
        {   
            if (disposing)
            {
                _db.Dispose();  //***這裡需要自己修改，例如 _db字樣
            }
            base.Dispose(disposing);
        }

        // 如果找不到動作（Action）或是輸入錯誤的動作名稱，一律跳回首頁
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("http://首頁(網址)/");
            base.HandleUnknownAction(actionName);
        }
        //*************************************   連結 MVC_UserDB 資料庫  ********************************* (end)

        //===================================
        //== 新增 (1)  == 只修改了檢視頁面的 @Html.ValidationSummary( false, .....
        //===================================
        //*** 加入檢視畫面時，勾選「參考指令碼程式庫」，才能產生表單驗證
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]//避免XSS、CSRF攻擊
        public ActionResult Create(UserTable _userTable)
        {
            //if ((_userTable != null) && (ModelState.IsValid))   // ModelState.IsValid，通過表單驗證（Server-side validation）需搭配 Model底下類別檔的 [驗證]
            //{
            //    // 第一種方法
            //    _db.UserTables.Add(_userTable);
            //    _db.SaveChanges();

            //    //return Content(" 新增一筆記錄，成功！");    // 新增成功後，出現訊息（字串）。
            //    return RedirectToAction("List");
            //}
            //else
            //{   // 搭配 ModelState.IsValid，如果驗證沒過，就出現錯誤訊息。

            // 檢視畫面上的 @Html.ValidationSummary，請設定為 false。
            ModelState.AddModelError("Value0", " *** 進入 Controller的第二個Create動作*** 自訂錯誤訊息(0) ");
            ModelState.AddModelError("Value1", " 自訂錯誤訊息(1) ");  // 第一個輸入值是 key，第二個是錯誤訊息（字串）
            ModelState.AddModelError("Value2", " 自訂錯誤訊息(2) ");

            return View(); // 將錯誤訊息，返回並呈現在「新增」的檢視畫面上
                           //return View(_userTable); // 寫成這樣也行。執行結果無差別。將錯誤訊息，返回並呈現在「新增」的檢視畫面上
                           //}
        }
        // GET: UserDB1Validation
        public ActionResult Index()
        {
            return View();
        }
    }
}