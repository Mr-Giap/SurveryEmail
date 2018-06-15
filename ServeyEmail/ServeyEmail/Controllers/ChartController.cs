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
        [HttpGet]
        public ActionResult ChartView()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Getdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Getdate(DateTime date)
        {
           
            DateTime datev = new DateTime();
            //date = DateTime.Parse(Request.Form["date"]).Date;
            //if (DateTime.TryParse(Convert.ToString(Request.Form["date"]), out date))
            //{
            //    //read the Date here
            //    string strDate = date.ToString("yyyy-MM-dd");
                
            //}
            
            TempData["date"] = date;
            TempData.Keep();
            return RedirectToAction("ChartView");
        }
       
                     
        [HttpGet]
        public JsonResult GetJsondata()
        {
            DateTime date;
             date = Convert.ToDateTime((Convert.ToDateTime(TempData["date"])).ToString("yyyy-MM-dd"));
            
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