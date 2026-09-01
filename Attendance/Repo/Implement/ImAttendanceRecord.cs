using Attendance.Models;
using Attendance.Repo.Interface;
using Microsoft.EntityFrameworkCore;
namespace Attendance.Repo.Implement
{
    public class ImAttendanceRecord:IAttendanceRecord
    {
    
        private readonly AppContexts context;
        public ImAttendanceRecord(AppContexts context)
        {
            this.context = context;
        }
        public List<AttendanceRecord> GetAll()
        {
            return context.AttendanceRecords.Include(n=>n.Student).Include(n => n.Subject).ToList();
        }
        public AttendanceRecord GetId(int id)
        {
            return context.AttendanceRecords.Include(n => n.Student).Include(n => n.Subject).FirstOrDefault(s=>s.AttendanceId==id);
        }
        public void Add(AttendanceRecord student)
        {
            context.AttendanceRecords.Add(student);
            context.SaveChanges();
        }
        public void Update(AttendanceRecord student)
        {
            context.AttendanceRecords.Update(student);
            context.SaveChanges();

        }
        public void Delete(AttendanceRecord student)
        {
            context.AttendanceRecords.Remove(student);
            context.SaveChanges();

        }
    }
}
