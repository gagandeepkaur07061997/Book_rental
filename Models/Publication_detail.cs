using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_rental.Models
    //This class is about publication details where it tells about publication id, books copies and has a foreign key that is linked with Publisher_detailsClass tabel with its publisher id//
{
    public class Publication_detail
    {
        
        public int Id { get; set; }
        [Required]
        public string Books_Copies { get; set; }

        public int Publisher_detailId { get; set; }
        public Publisher_detail Publisher_detail { get; set; }

        public int Books_detailId { get; set; }
        public Books_detail Books_detail { get; set; }


        
    }
}
