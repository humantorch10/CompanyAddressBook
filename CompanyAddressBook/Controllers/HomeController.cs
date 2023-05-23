using CompanyAddressBook.Data;
using CompanyAddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CompanyAddressBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // A method to load companies from a text file
        [HttpGet]
        public IActionResult LoadCompanies()
        {
            
            var fileContent = System.IO.File.ReadAllText("XPE-Task-SampleData.txt");

            var lines = fileContent.Split("\n");

            lines = lines.Skip(1).ToArray();

            foreach (var line in lines)
            {
                var fields = line.Split("\t\t");

                if (fields.Length == 3)
                {
                    var name = fields[0];
                    var numContacts = int.Parse(fields[1]);
                    var maxContactAge = int.Parse(fields[2]);

                    if (Regex.IsMatch(name, @"\d[§®™©ʬ@]"))
                    {
                        if (!_context.Companies.Any(c => c.Name == name))
                        {
                            var company = new Company
                        {
                            Name = name,
                            NumberOfContacts = numContacts,
                            MaxContactAge = maxContactAge,
                            Contacts = new List<Contact>()
                        };
                            _context.Companies.Add(company);
                        }
                    }
                }
            }

            _context.SaveChanges();
            return View();
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}