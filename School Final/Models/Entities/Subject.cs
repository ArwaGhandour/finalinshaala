using System.ComponentModel.DataAnnotations.Schema;

namespace School_Final.Models.Entities
{
    public class Subject
    {
        public int SubjectID {  get; set; }
        public string Name {  get; set; }
        public int Grade {  get; set; }
        public int Duration {  get; set; }
        
        public IEnumerable<Assignment> Assignments { get; set; }
    }
}
