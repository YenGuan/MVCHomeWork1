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
    [ShowActionTime]
    public class 客戶聯絡人Controller : BaseController
    {
        //private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            var data = repo聯絡人.All();
          
            return View(data);
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo聯絡人.Add(客戶聯絡人);
             
                repo聯絡人.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                var l_客戶聯絡人 = (客戶資料Entities)repo聯絡人.UnitOfWork.Context;
                l_客戶聯絡人.Entry(客戶聯絡人).State = EntityState.Modified;
                //db.Entry(客戶聯絡人).State = EntityState.Modified;
                repo聯絡人.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repo聯絡人.Find(id);
            客戶聯絡人.已刪除 = true;
            repo聯絡人.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }
        //回復刪除
        [HttpPost, ActionName("Recover")]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repo聯絡人.Find(id);
            //db.客戶資料.Remove(客戶資料);
            客戶聯絡人.已刪除 = false;

            repo聯絡人.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult index()
        {
            string keyword = Request["queryKeyword"];
            var 客戶聯絡人 = repo聯絡人;
            if (!string.IsNullOrEmpty(keyword))
            {

                return View(客戶聯絡人.Where(p => p.姓名 == keyword));
            }
            else
            {
                return View(客戶聯絡人);
            }

        }
        public FileResult ExportExcel()
        {

            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();

            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            IQueryable<客戶聯絡人> 客戶聯絡人 = repo聯絡人.All();

            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("職稱");
            row1.CreateCell(1).SetCellValue("姓名");
            row1.CreateCell(2).SetCellValue("Email");
            row1.CreateCell(3).SetCellValue("手機");
            row1.CreateCell(4).SetCellValue("電話");
            row1.CreateCell(5).SetCellValue("客戶資料_客戶名稱");
            int RowNum = 1;
            foreach (var convo in 客戶聯絡人)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(RowNum);
                rowtemp.CreateCell(0).SetCellValue(convo.職稱.ToString());
                rowtemp.CreateCell(1).SetCellValue(convo.姓名.ToString());
                rowtemp.CreateCell(2).SetCellValue(convo.Email.ToString());
                rowtemp.CreateCell(3).SetCellValue(convo.手機.ToString());
                rowtemp.CreateCell(4).SetCellValue(convo.電話.ToString());
                rowtemp.CreateCell(5).SetCellValue(convo.客戶資料.客戶名稱.ToString());
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
                repo聯絡人.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
