using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("employees")]
    public class employees
    {
        public long id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String title { get; set; }
        public String email { get; set; }
        public String encrypted_password { get; set; }
        public String reset_password_token { get; set; }
        public DateTime? reset_password_sent_at { get; set; }
        public DateTime? remember_created_at { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }



    }
}
