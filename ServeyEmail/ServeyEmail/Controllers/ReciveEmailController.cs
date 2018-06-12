using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValueObjects;
using BusinessLogicLayer.BLL;
using BusinessLogicLayer;

namespace ServeyEmail.Controllers
{
    public class ReciveEmailController : Controller
    {
        // GET: ReciveEmail
        public ActionResult Index(string code, int number, string date)
        {
            string ngayht = MAHOA.sha1("" + DateTime.Now.Date);
            if(ngayht != date)
            {
                ViewBag.message = "Đã quá hạn để xác nhận. Xin cảm ơn!";
            }
            else
            {
                UserBLL usbll = new UserBLL();
                OUsers user = new OUsers();
                foreach (var item in usbll.GetallUsers())
                {
                    string ma = MAHOA.sha1("" + item.IdUser);
                    if (ma == code)
                    {
                        user = item;
                    }
                }
                if (user.IdUser != null)
                {
                    
                    HistoryBLL hisbll = new HistoryBLL();

                    var kttontai = (from table in hisbll.Getall()
                                    where table.CreationDate == DateTime.Now.Date
                                    select table).FirstOrDefault();
                    if (kttontai == null)
                    {
                        OHistories history = new OHistories();
                        history.IdHis = Guid.NewGuid();
                        history.CreationDate = DateTime.Now.Date;
                        history.IdStatus = number;
                        history.IdGroup = user.IdGroup;
                        history.listuser = new List<OUsers>();
                        history.listuser.Add(user);
                        hisbll.Insert(history);
                    }
                    else
                    {
                        if(kttontai.IdStatus == number)
                        {
                            hisbll.Update(kttontai);
                        }
                        else
                        {
                            OHistories history = new OHistories();
                            history.IdHis = Guid.NewGuid();
                            history.CreationDate = DateTime.Now.Date;
                            history.IdStatus = number;
                            history.IdGroup = user.IdGroup;
                            history.listuser = new List<OUsers>();
                            history.listuser.Add(user);
                            hisbll.Insert(history);
                        }
                    }
                    ViewBag.message = "Cảm ơn bạn đã khảo sát. XIn cảm ơn !";
                }
                else
                {
                    ViewBag.message = "Có lỗi xảy ra. Xin liên hệ với admin. XIn cảm ơn !";
                }
            }   
            return View();
        }
    }
}