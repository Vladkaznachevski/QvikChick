using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Order
    {
        
        public int id { get; set; }



        [Display(Name = "Введите ваше Имя")]
        [StringLength(30)]
        [Required(ErrorMessage = "длина имени не может")]
        public string name { get; set; }

        [Display(Name = "Введите вашу Фамилию")]
        public string surname { get; set; }

        [Display(Name = "Введите ваше Адрес")]
        public string address { get; set; }

        [Display(Name = "Введите ваш Телефон")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "это не телефон")]
        public string phone { get; set; }

        [Display(Name = "Введите вашу электронную почту")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "это не почта")]
        public string email { get; set; }

        public DateTime orderTime { get; set; }

 


    }
}
