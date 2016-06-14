using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hakuturu.Models;

namespace Hakuturu.Controllers
{
    public class PcInfoItemsController : Controller
    {
        private PcInfoDBContext db = new PcInfoDBContext();

        // GET: PcInfoItems
        public ActionResult Index(string PcNo)
        {
            //return View(db.PcInfoItems.ToList());

            //ジャンルフィルタ用ドロップダウンリスト設定
            //var GenreList = new List<string>();
            //var GenreQry = from d in db.Movies orderby d.Genre select d.Genre;
            //GenreList.AddRange(GenreQry.Distinct());
            //ViewBag.movieGenre = new SelectList(GenreList);

            //一覧表示
            var items = from m in db.PcInfoItems select m;
            if (!string.IsNullOrEmpty(PcNo))    //PC番号
            {
                items = items.Where(s => s.PcNo.Contains(PcNo));
            }
            //if (!string.IsNullOrEmpty(movieGenre))    //ジャンルフィルタ
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre);
            //}
            return View(items);
        }

        // GET: PcInfoItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcInfoItem pcInfoItem = db.PcInfoItems.Find(id);
            if (pcInfoItem == null)
            {
                return HttpNotFound();
            }
            return View(pcInfoItem);
        }

        // GET: PcInfoItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PcInfoItems/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PcNo,IpAddress,UseSegment,ModelName,ModelNo,UserName,PcName,Remarks")] PcInfoItem pcInfoItem)
        {
            if (ModelState.IsValid)
            {
                db.PcInfoItems.Add(pcInfoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pcInfoItem);
        }

        // GET: PcInfoItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcInfoItem pcInfoItem = db.PcInfoItems.Find(id);
            if (pcInfoItem == null)
            {
                return HttpNotFound();
            }
            return View(pcInfoItem);
        }

        // POST: PcInfoItems/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PcNo,IpAddress,UseSegment,ModelName,ModelNo,UserName,PcName,Remarks")] PcInfoItem pcInfoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pcInfoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pcInfoItem);
        }

        // GET: PcInfoItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcInfoItem pcInfoItem = db.PcInfoItems.Find(id);
            if (pcInfoItem == null)
            {
                return HttpNotFound();
            }
            return View(pcInfoItem);
        }

        // POST: PcInfoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PcInfoItem pcInfoItem = db.PcInfoItems.Find(id);
            db.PcInfoItems.Remove(pcInfoItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
