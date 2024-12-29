using School_Final.Models.Entities;

namespace School_Final.Models.ViewModel
{
    public class AssignmentViewModel
    {
        public int AssID {  get; set; }
        public int TeacherIDD {  get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public int SubjectIDD {  get; set; }
        public IEnumerable<Subject>Subjects { get; set; }
        public DateTime datee {  get; set; }
    }
}
