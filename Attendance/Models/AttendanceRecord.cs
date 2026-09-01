
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Attendance.Models
{
    public class AttendanceRecord
    {
        [Key]
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
