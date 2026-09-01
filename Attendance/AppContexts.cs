
using Attendance.Models;
using Microsoft.EntityFrameworkCore;
namespace Attendance
{
    public class AppContexts:DbContext
    {
        public AppContexts (DbContextOptions<AppContexts> options):base(options) { }
        public DbSet<Student> Students { get; set; }    
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
