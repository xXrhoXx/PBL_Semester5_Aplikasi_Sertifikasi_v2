using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class Register : AccountBase
    {
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string? email { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        [Required]
        public string confirmPassword { get; set; }
    }
}
