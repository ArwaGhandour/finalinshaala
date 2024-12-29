using Microsoft.AspNetCore.Mvc;
using School_Final.Models.Entities;
using School_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace School_Final.Controllers
{
    public class SubjectController : Controller
    {
        private readonly AppDBContext _appdb;
        public SubjectController(AppDBContext appdb)
        {
            _appdb = appdb;
        }
        public async Task<IActionResult> GetAllSubjects()
        {
            var teach = await _appdb.Subjects.ToListAsync();
            return View(teach);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subject subject)
        {
            if (subject == null)
            {
                return View(subject);
            }
            await _appdb.Subjects.AddAsync(subject);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllSubjects");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var upd = await _appdb.Subjects.FirstOrDefaultAsync(x => x.SubjectID == id);
            return View(upd);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Subject subject)
        {
            _appdb.Subjects.Update(subject);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllSubjects");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var upd = await _appdb.Subjects.FirstOrDefaultAsync(x => x.SubjectID == id);
            return View(upd);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Subject subject)
        {
            _appdb.Subjects.Remove(subject); await _appdb.SaveChangesAsync(); return RedirectToAction("GetAllSubjects");
        }
    }
}
