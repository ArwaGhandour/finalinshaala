using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Final.Models;
using School_Final.Models.Entities;
using School_Final.Models.ViewModel;

namespace School_Final.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly AppDBContext _appdb;
        public AssignmentController(AppDBContext appdb)
        {
            _appdb = appdb;
        }
        public async Task<IActionResult> GetAllAssignments()
        {
            var lis=await _appdb.assignment.Include(x=>x.teacher).Include(x=>x.subject).ToListAsync();
            return View(lis);
        }
        [HttpGet]
        public async Task<IActionResult> Create(Assignment aa)
        {
            var tea = await _appdb.teachers.ToListAsync();
            var sub = await _appdb.Subjects.ToListAsync();
            AssignmentViewModel v1 = new AssignmentViewModel()
            {
                AssID=aa.AssignmentId,
                datee=aa.Assigneddate,
                TeacherIDD=aa.TeacherIDd,
                SubjectIDD=aa.SubjectIDd,
                Teachers=tea,
                Subjects=sub,
            };
            return View(v1);
        }
        [HttpPost]
        public async Task <IActionResult>Create(AssignmentViewModel avm)
        {
            
            Assignment ass = new Assignment()
            {
                TeacherIDd=avm.TeacherIDD,
                SubjectIDd=avm.SubjectIDD,
                  AssignmentId=avm.AssID,
                  Assigneddate=avm.datee
            };
            await _appdb.assignment.AddAsync(ass);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllAssignments");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var upd = await _appdb.assignment.Include(x=>x.teacher).Include(x=>x.subject).FirstOrDefaultAsync(x => x.AssignmentId == id);
            var tea = await _appdb.teachers.ToListAsync();
            var sub = await _appdb.Subjects.ToListAsync();
            AssignmentViewModel v1 = new AssignmentViewModel()
            {
                SubjectIDD=upd.SubjectIDd,

                TeacherIDD=upd.TeacherIDd,
                datee=upd.Assigneddate,
                AssID=upd.AssignmentId,
                Teachers=tea,
                Subjects=sub,
            };
            return View(v1);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AssignmentViewModel avm)
        {

            var upd = await _appdb.assignment.Include(x => x.teacher).Include(x => x.subject).FirstOrDefaultAsync(x => x.AssignmentId ==avm.AssID);
            upd.TeacherIDd = avm.TeacherIDD;
            upd.AssignmentId = avm.AssID;
            upd.SubjectIDd = avm.SubjectIDD;
                upd.Assigneddate = avm.datee;
            _appdb.assignment.Update(upd);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllAssignments");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var upd = await _appdb.assignment.Include(x=>x.teacher).Include(s=>s.subject).FirstOrDefaultAsync(x => x.AssignmentId == id);
            return View(upd);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Assignment ass)
        {
            _appdb.assignment.Remove(ass); await _appdb.SaveChangesAsync(); return RedirectToAction("GetAllAssignments");
        }
        public async Task<IActionResult> Details(int id)
        {
            var upd = await _appdb.assignment.Include(x => x.teacher).Include(s => s.subject).FirstOrDefaultAsync(x => x.AssignmentId == id);
            return View(upd);
        }
    }
}
