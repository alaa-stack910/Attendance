using Attendance.Models;

namespace Attendance.Repo.Interface
{
    public interface IAttendanceRecord
    {
   
        public List<AttendanceRecord> GetAll();
        public AttendanceRecord GetId(int id);
        public void Add(AttendanceRecord student);
        public void Update(AttendanceRecord student);
        public void Delete(AttendanceRecord student);
    }
}
