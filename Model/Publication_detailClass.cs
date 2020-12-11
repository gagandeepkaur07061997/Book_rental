using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_rental.Model
    //This class is about publication details where it tells about publication id, books copies and has a foreign key that is linked with Publisher_detailsClass tabel with its publisher id//
{
    public class Publication_detailClass
    {
        
        public int ID { get; set; }
        [Required]
        public string Books_copies { get; set; }

        public int Publisher_ID { get; set; }
        public Publisher_detailClass objPublisher_detailClass { get; set; }

        public int Book_ID { get; set; }
        public Books_detail_Class objBooks_detail_Class { get; set; }


        
    }
}
