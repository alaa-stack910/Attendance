
using Attendance.Models;
using Attendance.Repo.Interface;
using Microsoft.EntityFrameworkCore;
namespace Attendance.Repo
{
    public class ImStudent:IStudent
    {
        private readonly AppContexts context;
        public ImStudent(AppContexts context)
        {
            this.context = context;
        }
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public Student GetId(int id)
        {
            return context.Students.Find(id);
        }
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();

        }
        public void Delete(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();

        }
    }
}
