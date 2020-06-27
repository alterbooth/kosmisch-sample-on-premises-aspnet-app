using Kosmisch.Sample.OnPremisesAspnetApp.Data;
using Kosmisch.Sample.OnPremisesAspnetApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Controllers
{
    public class UsersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,ProfileImageName")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.Id = Guid.NewGuid();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,ProfileImageName")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendEmailSample()
        {
            // 各種設定値はサンプルのため、実際には動作しません
            var client = new SmtpClient("smtp.kosmischsample.net");
            var from = new MailAddress("from@kosmischsample.net", "Kosmisch", Encoding.UTF8);
            var to = new MailAddress("to@kosmischsample.net");
            var message = new MailMessage(from, to);
            message.Body = "Test message";
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = "Kosmisch Sample";
            message.SubjectEncoding = Encoding.UTF8;
            client.Send(message);
            message.Dispose();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> SendHttpRequestSampleAsync()
        {
            // 各種設定値はサンプルのため、実際には動作しません
            var client = new HttpClient();
            var response = await client.GetAsync("http://kosmischsample.net/");
            var responseBody = await response.Content.ReadAsStringAsync();

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
