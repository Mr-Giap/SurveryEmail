using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.BLL;
using System.Collections;


namespace ServeyEmail.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult ChartView(DateTime date)
        {                     
            return View();
        }        
      
        [HttpGet]
        public JsonResult GetJsondata()
        {
            DateTime date;//truyen tham số ngày vào để hiển thị biểu đồ.
            var list = new List<ChartData>();
            HistoryBLL hs = new HistoryBLL();           
            var list1 = hs.Checkdate(date);
            foreach (var item in list1)
            {                
                ChartData cd = new ChartData();
                cd.amount = item.Amount;               
                StatusBLL st = new StatusBLL();
                cd.name=(st.Getname(item.IdStatus));
                list.Add(cd);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}