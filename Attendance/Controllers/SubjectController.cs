using Attendance.Models;
using Attendance.Repo;
using Attendance.Repo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    public class SubjectController:Controller
    {
   
        private readonly ISubject subject;
        private readonly AppContexts contexts;
        public SubjectController(ISubject subject, AppContexts contexts)
        {
            this.subject = subject;
            this.contexts = contexts;
        }

        public IActionResult Index()
        {
            var s = subject.GetAll();
            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject s)
        {
            subject.Add(s);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewList(int id)
        {
            var students = subject.GetAll();
            return View(students);


        }

        public IActionResult Search(string name)
        {
            var s=contexts.Subjects.Where(x=>x.Name.Contains(name)).ToList();   
            return View(s);
        }

        }
    
}
