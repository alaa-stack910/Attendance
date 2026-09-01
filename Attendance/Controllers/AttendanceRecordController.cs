using Attendance.Models;
using Attendance.Repo.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Attendance.Controllers
{
    public class AttendanceRecordController:Controller
    {
 
        private readonly IStudent student;
        private readonly ISubject subject;
        private readonly IAttendanceRecord attendance;

        private readonly AppContexts contexts;
        public AttendanceRecordController(IStudent student, ISubject subject, IAttendanceRecord attendance, AppContexts contexts)
        {
            this.student = student;
            this.subject = subject;
            this.contexts = contexts;
            this.attendance = attendance;
        }

        public IActionResult Index()
        {
            var s = attendance.GetAll();
            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var a = new AttendanceVm
            {
                Student = student.GetAll(),
                Subject = subject.GetAll()
            };
            return View(a);
        }

        [HttpPost]
        public IActionResult Create(AttendanceVm s)
        {
            var a = new AttendanceRecord
            {
                Date = s.Date,
                AttendanceId=s.AttendanceId,
                StudentId=s.StudentId,
                SubjectId=s.SubjectId,
                Status = s.Status
            };
            attendance.Add(a);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var s = attendance.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            var a = new AttendanceVm
            {
                Date = s.Date,
                AttendanceId = s.AttendanceId,
                StudentId = s.StudentId,
                SubjectId = s.SubjectId,
                Status = s.Status,
                Student =student.GetAll(),
                Subject = subject.GetAll()

            };

            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(AttendanceVm s)
        {
            var v = attendance.GetId(s.AttendanceId);
            if (v == null)
            {
                return NotFound();
            }
            v.AttendanceId=s.AttendanceId;
            v.StudentId=s.StudentId;
            v.Date= s.Date;
            v.SubjectId=s.SubjectId;
            v.Status=s.Status;
            attendance.Update(v);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var s = attendance.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            attendance.Delete(s);

            return RedirectToAction(nameof(Index));

        }
        public IActionResult ViewList(int id)
        {
            var students = attendance.GetAll();
            return View(students);


        }
        public IActionResult Filter(int? StudentId, int? SubjectId)
        {
            var a=contexts.AttendanceRecords.Include(n => n.Student).Include(n => n.Subject).AsQueryable();

            if (StudentId != null)
            {
                a=a.Where(x=>x.StudentId== StudentId);
            }
            if (SubjectId != null)
            {
                a = a.Where(x => x.SubjectId == SubjectId);
            }

            var vm= new AttendanceVm
            {
                StudentId= StudentId ?? 0,
                SubjectId = SubjectId ?? 0,

                Student = student.GetAll(),
                Subject = subject.GetAll(),
                attendanceRecords=a.ToList()
            };

            return View(vm);


        }



    }
}


////ليههههههههههههههههههههه