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
    public class 客戶銀行資訊Controller : BaseController
    {
        //private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            var data = repo銀行資訊.All();
            return View(data);
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = repo銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo客戶資料.Where(p => p.已刪除 == false), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                repo銀行資訊.Add(客戶銀行資訊);
                repo銀行資訊.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = repo銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(客戶銀行資訊).State = EntityState.Modified;
                var l_客戶銀行資訊 = (客戶資料Entities)repo銀行資訊.UnitOfWork.Context;
                l_客戶銀行資訊.Entry(客戶銀行資訊).State = EntityState.Modified;
                //db.SaveChanges();
                repo銀行資訊.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = repo銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = repo銀行資訊.Find(id);
            客戶銀行資訊.已刪除 = true;
            //db.SaveChanges();
            repo銀行資訊.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = repo銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }
        //回復刪除
        [HttpPost, ActionName("Recover")]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = repo銀行資訊.Find(id);
            //repo客戶資料.Remove(客戶資料);
            客戶銀行資訊.已刪除 = false;

            //db.SaveChanges();
            repo銀行資訊.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult index()
        {
            string keyword = Request["queryKeyword"];
            var 客戶銀行資訊 = repo銀行資訊;
            if (!string.IsNullOrEmpty(keyword))
            {

                return View(客戶銀行資訊.Where(p => p.銀行名稱 == keyword));
            }
            else
            {
                return View(客戶銀行資訊);
            }

        }
        public FileResult ExportExcel()
        {

            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();

            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            IQueryable<客戶銀行資訊> 客戶銀行資訊 = repo銀行資訊.All();

            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("銀行名稱");
            row1.CreateCell(1).SetCellValue("銀行代碼");
            row1.CreateCell(2).SetCellValue("分行代碼");
            row1.CreateCell(3).SetCellValue("帳戶名稱");
            row1.CreateCell(4).SetCellValue("帳戶號碼");
            row1.CreateCell(5).SetCellValue("客戶資料_客戶名稱");
            int RowNum = 1;
            foreach (var info in 客戶銀行資訊)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(RowNum);
                rowtemp.CreateCell(0).SetCellValue(info.銀行名稱.ToString());
                rowtemp.CreateCell(1).SetCellValue(info.銀行代碼.ToString());
                rowtemp.CreateCell(2).SetCellValue(info.分行代碼.ToString());
                rowtemp.CreateCell(3).SetCellValue(info.帳戶名稱.ToString());
                rowtemp.CreateCell(4).SetCellValue(info.帳戶號碼.ToString());
                rowtemp.CreateCell(5).SetCellValue(info.客戶資料.客戶名稱.ToString());
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
                repo銀行資訊.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
