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
    [Route("api/employees")]
    [ApiController]
    public class employeesController : ControllerBase
    {
        private readonly MysqlContext _context;

        public employeesController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public ActionResult<List<employees>> GetAll()
        {
            var employees = _context.employees;
            List<employees> list_employees = new List<employees>();

            if (employees == null)
            {
                return NotFound();
            }
            foreach (var employee in employees)
            {


                list_employees.Add(employee);

            }

            return list_employees;
        }

    }
}