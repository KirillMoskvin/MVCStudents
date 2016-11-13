using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStudents.Models;
using System.Data.Entity;

namespace MVCStudents.Controllers
{
    public class SubjectController : Controller
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        StudentsContext context = new StudentsContext();

        #region Index
        /// <summary>
        /// Список всех предметов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Subjects.ToList());
        }
        #endregion

        #region Edit
        /// <summary>
        /// Изменение предмета (при запросе пользователем)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditSubject(int id)
        {
            var obj = context.Subjects.Find(id);
            if (obj == null)
                return HttpNotFound();
            return View(obj);
        }

        /// <summary>
        /// Изменение предмета (при отправке формы)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditSubject(Subject s)
        {
            if(!ModelState.IsValid)
            {
                return View(s);
            }
            context.Entry(s).State = EntityState.Modified;
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
        public ActionResult AddSubject()
        {
            return View(new Subject());
        }
        /// <summary>
        /// Добавление (при отправке формы)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSubject(Subject subj)
        {
            if (!ModelState.IsValid)
            {
                return View(subj);
            }
            context.Subjects.Add(subj);
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
        public ActionResult DeleteSubject(int id)
        {
            Subject subj = context.Subjects.Find(id);
            if (subj != null)
            {
                context.Subjects.Remove(subj);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion Delete
    }
}
