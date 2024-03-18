using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Population.Data;
using Population.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Population.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;
        

        public PeopleController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.peoples.Include(c => c.BloodGroups).Include(c => c.SSCBoards).Include(c => c.HSCBoards).ToList());
        }

        //Get Create method
        public IActionResult Create()
        {
            ViewData["BloodGroupId"] = new SelectList(_db.BloodGroups.ToList(), "Id", "BloodGroup");
            ViewData["SSCBoardId"] = new SelectList(_db.SSCBoards.ToList(), "Id", "SSCBoard");
            ViewData["HSCBoardId"] = new SelectList(_db.HSCBoards.ToList(), "Id", "HSCBoard");
            //ViewData["BoardId"] = new SelectList(_db.Boards.ToList(), "Id", "Board");
            return View();
        }


        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(People people, IFormFile image)
        {
            if (ModelState.IsValid)
            {


                if (image != null)
                {
                    var name = System.IO.Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                   people.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    people.Image = "Images/noimage.PNG";
                }
                _db.peoples.Add(people);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(people);
        }


        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            ViewData["BloodGroupId"] = new SelectList(_db.BloodGroups.ToList(), "Id", "BloodGroup");
            ViewData["SSCBoardId"] = new SelectList(_db.SSCBoards.ToList(), "Id", "SSCBoard");
            ViewData["HSCBoardId"] = new SelectList(_db.HSCBoards.ToList(), "Id", "HSCBoard");
            //ViewData["HSCBoardId"] = new SelectList(_db.HSCBoards.ToList(), "Id", "HSCBoard");

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.peoples.Include(c => c.BloodGroups).Include(c => c.SSCBoards).Include(c => c.HSCBoards)
                .FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        //POST Edit Action Method
        [HttpPost]
        public async Task<IActionResult> Edit(People people, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    people.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    people.Image = "Images/noimage.PNG";
                }
                _db.peoples.Update(people);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(people);
        }

        //GET Details Action Method
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var People = _db.peoples.Include(c => c.BloodGroups).Include(c => c.SSCBoards).Include(c => c.HSCBoards).FirstOrDefault(c => c.Id == id);
            if (People == null)
            {
                return NotFound();
            }
            return View(People);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = _db.peoples.Include(c => c.BloodGroups).Include(c => c.SSCBoards).Include(c => c.HSCBoards).FirstOrDefault(c => c.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var People = _db.peoples.Include(c => c.BloodGroups).Include(c => c.SSCBoards).Include(c => c.HSCBoards).FirstOrDefault(c => c.Id == id);
            if (People == null)
            {
                return NotFound();
            }

            _db.peoples.Remove(People);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        
    }
}
