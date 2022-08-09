using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        [StringLength(10)]
        [Required(ErrorMessage ="Поле не повино бути пустим" )]
        public string Name { get; set; }

        [Display(Name = "Прізвище")]
        [StringLength(10)]
        [Required(ErrorMessage = "Поле не повино бути пустим")]
        public string Surname { get; set; }
        [Display(Name = "Адреса")]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле не повино бути пустим")]
        public string Adress { get; set; }
        [Display(Name = "Номер телефону")]
        [StringLength(14)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Поле не повино бути пустим")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле не повино бути пустим")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
