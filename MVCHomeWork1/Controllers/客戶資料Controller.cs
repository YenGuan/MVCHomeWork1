using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWork1.Models;

namespace MVCHomeWork1.Controllers
{
    public class 客戶資料Controller : BaseController
    {
        //private 客戶資料Entities db = new 客戶資料Entities();
        [ShowActionTime]
        // GET: 客戶資料
        public ActionResult Index(string p_cate)
        {
           
            if (p_cate != null)
            {
                var data = repo客戶資料.Where(p=>p.分類==p_cate);
                ViewBag.category = getCategory(data);
                return View(data);
            }

          
            var data1 = repo客戶資料.All();
            ViewBag.category = getCategory(data1);
            return View(data1);
        }

        private IQueryable<SelectListItem> getCategory(IQueryable<客戶資料> data)
        {

            return data
                .AsQueryable()
                .Select(s => new SelectListItem()
                        {
                            Value = s.分類,
                            Text = s.分類
                        })
                     ;

        }





      
     
        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,分類")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo客戶資料.Add(客戶資料);
                //db.SaveChanges();
                repo客戶資料.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,分類")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var l_客戶資料 = (客戶資料Entities)repo客戶資料.UnitOfWork.Context;
                l_客戶資料.Entry(客戶資料).State = EntityState.Modified;
                repo客戶資料.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 l_客戶資料 = repo客戶資料.Find(id);
            l_客戶資料.已刪除 = true;
            l_客戶資料.客戶銀行資訊.AsQueryable().ToList().ForEach(a => a.已刪除 = true);
            l_客戶資料.客戶聯絡人.AsQueryable().ToList().ForEach(a => a.已刪除 = true);
            //repo客戶資料.Remove(客戶資料);



            repo客戶資料.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }
        //回復刪除
        [HttpPost, ActionName("Recover")]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverConfirmed(int id)
        {
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            //repo客戶資料.Remove(客戶資料);
            客戶資料.已刪除 = false;

            repo客戶資料.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult index()
        {
            string keyword = Request["queryKeyword"];
            var 客戶資料 = repo客戶資料;
            if (!string.IsNullOrEmpty(keyword))
            {

                return View(客戶資料.Where(p => p.客戶名稱 == keyword));
            }
            else
            {
                return View(客戶資料);
            }

        }
        public FileResult ExportExcel()
        {



            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();

            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            IQueryable<客戶資料> 客戶資料 = repo客戶資料.All();

            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("客戶名稱");
            row1.CreateCell(1).SetCellValue("統一編號");
            row1.CreateCell(2).SetCellValue("電話");
            row1.CreateCell(3).SetCellValue("傳真");
            row1.CreateCell(4).SetCellValue("地址");
            row1.CreateCell(5).SetCellValue("Email");
            int RowNum = 1;
            foreach (var cust in 客戶資料)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(RowNum);
                rowtemp.CreateCell(0).SetCellValue(cust.客戶名稱.ToString());
                rowtemp.CreateCell(1).SetCellValue(cust.統一編號.ToString());
                rowtemp.CreateCell(2).SetCellValue(cust.電話.ToString());
                rowtemp.CreateCell(3).SetCellValue(cust.傳真.ToString());
                rowtemp.CreateCell(4).SetCellValue(cust.地址.ToString());
                rowtemp.CreateCell(5).SetCellValue(cust.Email.ToString());
                RowNum++;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);

            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyyyMMddHHmm");
            string fileName = "客戶資料" + dateTime + ".xls";
            return File(ms.ToArray(), "application/vnd.ms-excel", fileName);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo客戶資料.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
