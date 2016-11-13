using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCStudents.Models
{
    public class Subject
    {
        /// <summary>
        /// Id
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Не менее 3 и не более 64 символов")]
        [Display(Name = "Название:")]
        public string Name { get; set; }
        /// <summary>
        /// Перподаватель
        /// </summary>
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Не менее 3 и не более 64 символов")]
        [Display(Name = "Преподаватель:")]
        public string Teacher { get; set; }
        /// <summary>
        /// Список студентов
        /// </summary>
        public virtual ICollection<Student> Students { get; set; }

        public Subject()
        {
            Students = new List<Student>();
        }
    }
}