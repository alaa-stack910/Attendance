using Attendance.Models;
using Attendance.Repo.Interface;

namespace Attendance.Repo.Implement
{
    public class ImSubject:ISubject
    {
 
        private readonly AppContexts context;
        public ImSubject(AppContexts context)
        {
            this.context = context;
        }
        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }
        public Subject GetId(int id)
        {
            return context.Subjects.Find(id);
        }
        public void Add(Subject student)
        {
            context.Subjects.Add(student);
            context.SaveChanges();

        }
        
    }
}
