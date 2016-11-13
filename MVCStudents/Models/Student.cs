using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCStudents.Models
{
    public class Student
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required(ErrorMessage = "required")]
        public int StudentId { get; set; }
        /// <summary>
        /// Фамилия, имя, отччество
        /// </summary>
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [StringLength(64, MinimumLength =3, ErrorMessage="Не менее 3 и не более 64 символов")]
        [Display(Name ="ФИО")]
        public string FIO { get; set; }
        /// <summary>
        /// Контактные данные
        /// </summary>
        [Required(ErrorMessage ="Поле не может быть пустым")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Не менее 3 и не более 64 символов")]
        [Display(Name = "Контакты:")]
        public string Contacts { get; set; }
        /// <summary>
        /// Курс
        /// </summary>
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Range(1,6, ErrorMessage ="Неверный курс")]
        [Display(Name = "Курс:")]
        public int Course { get; set; }
        /// <summary>
        /// Список предметов
        /// </summary>
        public virtual ICollection<Subject> Subjects { get; set; }

        public Student()
        {
            Subjects = new List<Subject>();
        }
    }
}