using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Newtonsoft.Json.Linq;
namespace TodoApi.Controllers {
    [Route ("api/leads")]
    [ApiController]
    public class leadsController : ControllerBase {
        private readonly MysqlContext _context;
        public leadsController (MysqlContext context) {
            _context = context;
        }

        // GET api/leads
        [HttpGet]
        public ActionResult<List<leads>> GetAll () {
          
             var listl = _context.leads;
            var listc = _context.customers;


            if (listl == null) {
                return NotFound ("Not Found");
            }
          
            List<leads> list_lead = new List<leads> ();
            List<customers> list_customer = new List<customers>();


            foreach (var customer in listc) {
                 list_customer.Add (customer);
                   

                 }
            
            Int32 lengthc = list_customer.Count;  
            DateTime currentDate = DateTime.Now.AddDays (-30);
            foreach (var lead in listl) {
                var verification = true;
                 for (var i=0;i <lengthc;i++) 
                  {
                    if(lead.Email == list_customer[i].contact_email){
                        verification = false;

                     }

                 }
                      if (lead.Created_at >= currentDate && verification == true) 
                      {
                   
                   

                           list_lead.Add (lead);
                           

                       }


                
                }
            return list_lead;
            
        }

    }
}