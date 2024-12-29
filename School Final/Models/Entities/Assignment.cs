using System.ComponentModel.DataAnnotations.Schema;

namespace School_Final.Models.Entities
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public DateTime Assigneddate { get; set; }
        public int TeacherIDd {  get; set; }
        [ForeignKey("TeacherIDd")]
        public Teacher teacher { get; set; }
        public int SubjectIDd {  get; set; }
        [ForeignKey("SubjectIDd")]
        public Subject subject {  get; set; }
    }
}
