using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.BLL;
using System.Collections;
using System.Web.Helpers;

namespace ServeyEmail.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chart
       
      
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
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            string date;
            date = (Convert.ToDateTime(TempData["date"])).ToString("yyyy-MM-dd");

            
            HistoryBLL hs = new HistoryBLL();
            var list1 = hs.Checkdate(date);
            foreach (var item in list1)
            {
                xValue.Add(item.Amount);
                StatusBLL st = new StatusBLL();
                string str = (st.Getname(item.IdStatus));
                xValue.Add(str);
            }
            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("mmmm")
                .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
                .Write("bmp");

                return null;
        }


      
    }
}