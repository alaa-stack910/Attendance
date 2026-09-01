using Attendance.Models;

namespace Attendance.Repo.Interface
{
    public interface ISubject
    {
  
        public List<Subject> GetAll();
        public Subject GetId(int id);
        public void Add(Subject student);
    }
}
