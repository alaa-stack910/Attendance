namespace Attendance.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }

    }
}
