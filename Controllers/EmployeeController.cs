using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCorewithAngular5.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCorewithAngular5.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Employees> GetAllEmployees()
        {
            return objemployee.GetAllEmployees();
        }

        // POST api/<controller>
        [HttpPost]

        [Route("api/Employee/Create")]
        public int Create([FromBody] Employees employee )
        {
            return objemployee.AddEmployee(employee);
           
        }
        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit(Employees emp)
        {
            return objemployee.UpdateEmployee(emp);
        }

        [HttpGet]
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employees Details(int id)
        {
            return objemployee.GetEmployeeDetail(id);
        }
                
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {           
            return objemployee.DeleteEmployee(id);
        }
    }
}
