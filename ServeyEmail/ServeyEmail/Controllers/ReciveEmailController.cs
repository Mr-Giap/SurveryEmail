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
            string ngayht = Encrypt.sha1("" + DateTime.Now.Date);
            if (ngayht != date)
            {
                ViewBag.message = "Đã quá hạn để xác nhận. Xin cảm ơn!";
            }
            else
            {
                OUsers user = new OUsers();
                UserBLL userbll = new UserBLL();
                // lấy tất cả các user chưa gửi khảo sát
                var dsus = userbll.GetallBycheck(0);
                if (dsus == null) // kiểm tra nếu danh sách rỗng thì gửi message
                {
                    ViewBag.message = "Bạn đã làm khảo sát ngày hôm nay. Xin cảm ơn ";
                }
                else // nếu không thì kiểm tra tiếp
                {
                    foreach (var item in dsus) //kiểm tra có id nào trùng với id đã gửi về k. nếu có thì gán vào biến user
                    {
                        string ma = Encrypt.sha1("" + item.IdUser);
                        if (ma == code)
                        {
                            user = item;
                        }
                    }
                }
                // kiểm tra biến user có giá trị k
                if (user.IdUser != Guid.Empty) //nếu có
                {
                    HistoryBLL hisbll = new HistoryBLL();
                    //kiểm tra xem đã có bản ghi ngày hôm nay chưa
                    var kttontai = from table in hisbll.Getall()
                                   where table.CreationDate == DateTime.Now.Date
                                   select table;
                    if (kttontai == null) //nếu không có thì thêm mới.
                    {
                        OHistories history = new OHistories();
                        history.IdHis = Guid.NewGuid();
                        history.CreationDate = DateTime.Now.Date;
                        history.IdStatus = number;
                        history.IdGroup = user.IdGroup;
                        hisbll.Insert(history);
                    }
                    else // nếu đã có bản ghi ngày hôm nay
                    {
                        bool kq = false;
                        foreach (var item in kttontai)
                        {
                            if (item.IdStatus == number) // kiểm tra xem có bản ghi của loại trạng thái đã truyền về không
                            {
                                hisbll.Update(item); //nếu có. update bản ghi 
                                kq = true;
                            }
                        }
                        if (kq == false) // nếu không có thì tạo bản ghi mới với trạng thái đấy
                        {
                            OHistories history = new OHistories();
                            history.IdHis = Guid.NewGuid();
                            history.CreationDate = DateTime.Now.Date;
                            history.IdStatus = number;
                            history.IdGroup = user.IdGroup;
                            hisbll.Insert(history);
                        }
                    }
                    // sửa user thành đã làm khảo sát
                    user.Checkmail = true;
                    userbll.Updatecheckmail(user, 1);
                    ViewBag.message = "Cảm ơn bạn đã khảo sát. Xin cảm ơn !";
                }
                else
                {
                    ViewBag.message = "Bạn đã làm khảo sát ngày hôm nay. Xin cảm ơn ";
                }
            }
            return View();
        }
    }
}