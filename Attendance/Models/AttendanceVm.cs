namespace Attendance.Models
{
    public class AttendanceVm
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; }

        public List<AttendanceRecord> attendanceRecords { get; set; }

        public List<Student> Student { get; set; }
        public List<Subject> Subject { get; set; }
    }
}
