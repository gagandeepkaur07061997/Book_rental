using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_rental.Models
//This class contains the information about Author means it tells about its ID, name, email.id, address and mobile number.//
{    
    public class Author
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email_Id { get; set; }
        public string Address { get; set; }
        [Required]
        public string Mobile_Number { get; set; }
    }
   
}
