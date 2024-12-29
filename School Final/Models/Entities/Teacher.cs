namespace School_Final.Models.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get;    set; }
        public string Email { get; set; }
        public string Specialization {  get; set; }
       
        public IEnumerable<Assignment>Assignments {  get; set; }
    }
}
