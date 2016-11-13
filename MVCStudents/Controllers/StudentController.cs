using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCStudents.Models;

namespace MVCStudents.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        StudentsContext context = new StudentsContext();

        #region Index
        /// <summary>
        /// Список всех студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Students.ToList());
        }
        #endregion

        #region Edit
        /// <summary>
        /// Изменение студента (при запросе пользователем)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var obj = context.Students.Find(id);
            if (obj == null)
                return HttpNotFound();
            ViewBag.Subjects = context.Subjects.ToList();
            return View(obj);
        }

        /// <summary>
        /// Изменение студента (при отправке формы)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditStudent (Student s, int[] selectedSubjects)
        {
            Student stud = context.Students.Find(s.StudentId);
            stud.Contacts = s.Contacts;
            stud.Course = s.Course;
            stud.FIO = s.FIO;
            stud.Subjects.Clear();
            if (selectedSubjects != null)
                foreach (var subj in context.Subjects)
                    if (selectedSubjects.Contains(subj.SubjectId))
                        stud.Subjects.Add(subj);

            if (!ModelState.IsValid)
            {
               ViewBag.Subjects = context.Subjects.ToList();
               return View(stud);
            }
            context.Entry(stud).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        /// <summary>
        /// Добавление (при запросе)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.Subjects = context.Subjects.ToList();
            return View(new Student());
        }
        /// <summary>
        /// Добавление (при отправке формы)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddStudent(Student stud, int[] chosenSubjects)
        {
            if (chosenSubjects!=null)
                foreach (Subject subj in context.Subjects)
                    if (chosenSubjects.Contains(subj.SubjectId))
                        stud.Subjects.Add(subj);
            if (!ModelState.IsValid)
            {
                ViewBag.Subjects = context.Subjects.ToList();
                return View(stud);
            }
            context.Students.Add(stud);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteStudent(int id)
        {
            Student st = context.Students.Find(id);
            if (st!=null)
            {
                context.Students.Remove(st);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion Delete

        [HttpGet]
        public ActionResult More(int id)
        {
            Student stud = context.Students.Find(id);
            if (stud == null)
                return HttpNotFound();
            ViewBag.Subjects = context.Subjects.ToList();  
            return View(stud);
        }
    }
}