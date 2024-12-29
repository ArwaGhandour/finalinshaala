using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Final.Models;
using School_Final.Models.Entities;

namespace School_Final.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDBContext _appdb;
        public TeacherController(AppDBContext appdb) { 
         _appdb=appdb;
        }
        public async Task<IActionResult> GetAllTeachers()
        {
            var teach = await _appdb.teachers.ToListAsync();
            return View(teach);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (teacher == null)
            {
                return View(teacher);
            }
            await _appdb.teachers.AddAsync(teacher);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllTeachers");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id) {
            var upd = await _appdb.teachers.FirstOrDefaultAsync(x => x.TeacherID == id);
            return View(upd);
        }
        [HttpPost]
        public async Task <IActionResult>Update(Teacher teacher)
        {
            _appdb.teachers.Update(teacher);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllTeachers");
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var upd = await _appdb.teachers.FirstOrDefaultAsync(x => x.TeacherID == id);
            return View(upd);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Delete(Teacher teacher)
        {
            _appdb.teachers.Remove(teacher); await _appdb.SaveChangesAsync(); return RedirectToAction("GetAllTeachers");
        }
        public async Task<IActionResult>Details(int id)
        {
            var de = await _appdb.teachers.FirstOrDefaultAsync(x => x.TeacherID == id);
            return View(de);
        }
    }
}
