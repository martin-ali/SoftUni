namespace CatShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CatShop.Models;
    using System.Linq;

    public class CatController : Controller
    {
        private readonly CatDbContext context;

        public CatController(CatDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var cats = this.context.Cats.ToList();

            return View(cats);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Cat cat)
        {
            if (ModelState.IsValid == false)
            {
                return View(cat);
            }

            this.context.Cats.Add(cat);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var cat = this.context.Cats.Find(id);

            if (cat == null) return NotFound();

            return View(cat);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Cat catModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(catModel);
            }

            var cat = this.context.Cats.Find(id);
            cat.Name = catModel.Name;
            cat.Nickname = catModel.Nickname;
            cat.Price = catModel.Price;

            this.context.Update(cat);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var cat = this.context.Cats.Find(id);

            if (cat == null) return NotFound();

            return View(cat);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cat catModel)
        {
            var cat = this.context.Cats.Find(id);

            if (cat == null) return NotFound();

            this.context.Cats.Remove(cat);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
