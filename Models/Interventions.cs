using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("interventions")]
    public class interventions
    {
        public long id { get; set; }
        public String author_id { get; set; }
        public long? customer_id { get; set; }
        public long? building_id { get; set; }
        public long? battery_id { get; set; }
        public long? column_id { get; set; }
        public long? elevator_id { get; set; }
        public long? employee_id { get; set; }
        public DateTime? interventionStartTime { get; set; }
        public DateTime? interventionEndTime { get; set; }
        public String result { get; set; }
        public String report { get; set; }
        public String status { get; set; }
    }


}