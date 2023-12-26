using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBookMVCApp.Models
{
    public class People
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string perName { get; set; }
        [Required(ErrorMessage = "Please enter Surname")]
        public string perSurname { get; set; }
        [Required(ErrorMessage = "Please enter E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DisplayName("Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Required(ErrorMessage = "All Contact Fields Are")]
        public string perPhone { get; set; }                //SOR !!!!!!!!!2
        [Required(ErrorMessage = "Please enter Age")]
        public int age { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.DateTime)]
        public DateTime birthday { get; set; }
    }
}