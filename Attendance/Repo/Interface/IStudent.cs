using Attendance.Models;
namespace Attendance.Repo.Interface
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public Student GetId(int id);
        public void Add(Student student);   
        public void Update(Student student);
        public void Delete(Student student);
    }
}
