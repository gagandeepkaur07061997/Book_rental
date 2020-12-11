using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_rental.Model
    //The class is about Publisher details it tells about the publisher id, name, mobile number and email_id//
{
    public class Publisher_detailClass
    {
       
        public int ID { get; set; }
        [Required]
        public string Publisher_Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Email_Id { get; set; }
    }
}
