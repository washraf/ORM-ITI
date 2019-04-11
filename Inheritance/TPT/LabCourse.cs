using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPT
{

    public class LabCourse 
    {
        [Key]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; } // PK and FK pointing to CourseTable
        public Course Course { get; set; }
        public string Location { get; set; }
    }
}