using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Models
{
    public class Dpartment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set; }
        [Required(ErrorMessage ="Name is Requierd!")]
        public string Name { get; set; }
        [DisplayName("Date of Creation")]
        public DateTime DateOfCreation { get; set; }
    }
}
