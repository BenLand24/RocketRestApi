using System;
using System.Collections.Generic;

namespace TodoApi.Models {
    public class batteries {
         public batteries () {
            columns = new HashSet<columns> ();
        }

        public long id { get; set; }
        public string status { get; set; }
        public string  battery_type { get; set; }
        public DateTime  date_commision { get; set; }
        public DateTime date_last_inspect { get; set; }
        public long? building_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

         public buildings building { get; set; }
        //  public employees employee { get; set; }
        public ICollection<columns> columns { get; set; }
    }
}