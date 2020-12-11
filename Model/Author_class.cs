using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_rental.Model
    //This class contains the information about Author means it tells about its ID, name, email.id, address and mobile number.//
{
    public class Author_class
    {
        
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email_id { get; set; }
        public string Address { get; set; }
        [Required]
        public string Mobile_number { get; set; }
    }
}
