using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Newtonsoft.Json.Linq;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace TodoApi.Controllers
{
    [Route("api/interventions")]
    [ApiController]
    public class interventionController : ControllerBase
    {
        private readonly MysqlContext _context;

        public interventionController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/interventions
        [HttpGet]
        public ActionResult<List<interventions>> GetAll()
        {
            var interventions = _context.interventions;
            List<interventions> list_intervention = new List<interventions>();

            if (interventions == null)
            {
                return NotFound();
            }
            foreach (var intervention in interventions)
            {
                if (intervention.status == "Pending" && intervention.interventionStartTime == null)
                {

                    list_intervention.Add(intervention);
                }
            }

            return list_intervention;
        }
        // GET: api/interventions/id?
        [HttpGet("{id}")]
        public async Task<ActionResult<interventions>> GetById(long id)
        {
            var interventionId = await _context.interventions.FindAsync(id);

            if (interventionId == null)
            {
                return NotFound();
            }

            return interventionId;
        }

        // PUT: api/interventions/InProgress/id?
        [HttpPut("InProgress/{id}")]
        public async Task<IActionResult> PutInProgress(long id)
        {
            var INTER = _context.interventions.Find(id);
            if (INTER == null)
            {
                return NotFound();
            }

            INTER.status = "InProgress";
            INTER.interventionStartTime = DateTime.Now;

            _context.interventions.Update(INTER);
            _context.SaveChanges();
            var json = new JObject();
            json["message"] = "The status of the intenvention ID: " + INTER.id + " has been changed satisfactorily to: " + INTER.status;
            return Content(json.ToString(), "application/json");
        }

        // PUT: api/interventions/Completed/id?

        [HttpPut("completed/{id}")]
        public async Task<IActionResult> PutCompleted(long id)
        {
            var INTER = _context.interventions.Find(id);
            if (INTER == null)
            {
                return NotFound();
            }

            INTER.status = "Completed";
            INTER.interventionEndTime = DateTime.Now;

            _context.interventions.Update(INTER);
            _context.SaveChanges();
            var json = new JObject();
            json["message"] = "The status of the intenvention ID: " + INTER.id + " has been changed satisfactorily to: " + INTER.status;
            return Content(json.ToString(), "application/json");
        }

    }
}
