using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tp1.Models;

namespace tp1.Repositories
{
    public class UsersController : Controller
    {
        private readonly UnitOfWork unit = new UnitOfWork();

        // GET: Clients
        public ActionResult Index()
        {
            return View(unit.UsersRepository.Queryable().ToList());
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await unit.UsersRepository.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                unit.UsersRepository.Create(user);
                await unit.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await unit.UsersRepository.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Clients/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                unit.UsersRepository.Update(user);
                await unit.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await unit.UsersRepository.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await unit.UsersRepository.FindAsync(id);
            unit.UsersRepository.Delete(user);
            await unit.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}