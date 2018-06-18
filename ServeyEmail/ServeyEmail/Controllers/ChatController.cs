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
            GroupBLL grBLL = new GroupBLL();
            SelectList listGr = new SelectList(grBLL.Getall(), "IdGroup", "Name");
            ViewBag.ListGroup = listGr;
            return View();
        }
        [HttpPost]
        public ActionResult Getdate(DateTime date,Guid IdGroup)
        {
            TempData["IdG"] = IdGroup;
            TempData["date"] = date;
            TempData.Keep();
            return RedirectToAction("Dash");
        }
        //public ActionResult Index()
        //{
        //    ArrayList xValue = new ArrayList();
        //    ArrayList yValue = new ArrayList();
        //    DateTime date;
        //    date = Convert.ToDateTime((Convert.ToDateTime(TempData["date"])).ToString("yyyy-MM-dd"));

            
        //    HistoryBLL hs = new HistoryBLL();
        //    var list1 = hs.Checkdate(date);
        //    foreach (var item in list1)
        //    {
        //        xValue.Add(item.Amount);
        //        StatusBLL st = new StatusBLL();
        //        string str = (st.Getname(item.IdStatus));
        //        yValue.Add(str);
        //    }
        //    new Chart(width: 600, height: 400, theme: ChartTheme.Green)
        //        .AddTitle("Chart for Growth[Pie Chart]")
        //        .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
        //        .Write("bmp");

        //        return null;
        //}

        public ActionResult Dash()
        {
            DateTime date;
            date = Convert.ToDateTime((Convert.ToDateTime(TempData["date"])).ToString("yyyy-MM-dd"));
            Guid IdG = Guid.Parse(TempData["IdG"].ToString());
            var list = new List<ChartData>();
            HistoryBLL hs = new HistoryBLL();
            var list1 = hs.Checkdate(date,IdG);
            foreach (var item in list1)
            {
                ChartData cd = new ChartData();
                cd.amount = item.Amount;
                StatusBLL st = new StatusBLL();
                cd.name = (st.Getname(item.IdStatus));
                list.Add(cd);
            }
            List<int?> am = new List<int?>();
            List<string> nm = new List<string>();
            foreach(var item in list)
            {
                am.Add(item.amount);
                nm.Add(item.name);
            }
            var rep = am;
            ViewBag.AMOUNT = am;
            ViewBag.NAME = nm;

            return View();
        }

      
    }
}