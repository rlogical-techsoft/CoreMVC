using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCoreWebApp.Models;

namespace NetCoreWebApp.Models
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            string conn = _configuration.GetConnectionString("DefaultConnection").ToString();
            EmployeeModel context = new EmployeeModel();           
            return View(context.GetAllAlbums(conn));
        }       
    }
}
