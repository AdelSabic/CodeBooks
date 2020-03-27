using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeBooks.EF;
using CodeBooks.Models;
using Microsoft.AspNetCore.Http;

namespace CodeBooks.Controllers
{
    public class CodebooksController : Controller
    {
        #region get
        // GET: Codebook
        private readonly MyContext db;
        public CodebooksController(MyContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            
            var Codebooks = db.Codebooks.ToList();
            return View(Codebooks);
        }
        // GET: Codebook/Details/5
        public ActionResult Details(int id)
        {
            var Codebooks = db.Codebooks.Where(x => x.Id == id).FirstOrDefault();
            //Models.Codebook Codebook = new Models.Codebook() {
            //    Id = Codebooks.
            //};


            return View(Codebooks);
        }
        // GET: Codebook/Create
        public ActionResult Create()
        {
            Models.CodebooksViewModel model = new Models.CodebooksViewModel()
            {
                codebooks = new List<Codebooks>()
            };
            model.codebooks = db.Codebooks.ToList();
            return View(model);
        }
        // GET: Codebook/Edit/5
        public ActionResult Edit(int id)
        {
            var cb = db.Codebooks.Where(x => x.Id == id).FirstOrDefault();
            Models.CodebooksViewModel Codebook = new CodebooksViewModel() {
                Code = cb.Code,
                Title = cb.Title,
                Description = cb.Description,
                Programmer = cb.Programmer,
                Cash = cb.Cash,
                CodebookId = cb.CodebooksId,
                CreatedOn = cb.CreatedOn
            };
            Codebook.codebooks = new List<Codebooks>(db.Codebooks.ToList());
            return View(Codebook);
        }
        // GET: Codebook/Delete/5
        public ActionResult Delete(int id)
        {
            
            var cb = db.Codebooks.Where(x => x.Id == id).FirstOrDefault();
            //Models.CodebooksViewModel Codebook = new CodebooksViewModel()
            //{
            //    Code = cb.Code,
            //    Title = cb.Title,
            //    Description = cb.Description,
            //    Programmer = cb.Programmer,
            //    Cash = cb.Cash,
            //    CreatedOn = cb.CreatedOn
            //};
            return View(cb);
        }
        #endregion

        #region post
        // POST: Codebook/Create
        [HttpPost]
        public ActionResult Create(CodebooksViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                Codebooks Codebook = new Codebooks()
                {
                    Code = model.Code,
                    Title = model.Title,
                    Description = model.Description,
                    Programmer = model.Programmer,
                    Cash = model.Cash,
                    CodebooksId = model.CodebookId,
                    CreatedOn = DateTime.Now
                };
                db.Add(Codebook);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Index", "Codebooks");
            }
            catch (Exception ex)
            {
                ViewBag.Ex = ex;
                return RedirectToAction("Index", "Home");
            }
        }
        // POST: Codebook/Edit/5
        [HttpPost]
        public ActionResult Edit(CodebooksViewModel model)
        {
            try
            {
                // TODO: Add update logic here
            
                var Codebook = db.Codebooks.Where(x => x.Id == model.Id).FirstOrDefault();
                Codebook.Code = model.Code;
                Codebook.Title = model.Title;
                Codebook.Description = model.Description;
                Codebook.Programmer = model.Programmer;
                Codebook.Cash = model.Cash;
                Codebook.CodebooksId = model.CodebookId;

                db.Update(Codebook);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Codebook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codes = await db.Codebooks.FindAsync(id);
            db.Codebooks.Remove(codes);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    } 
}
