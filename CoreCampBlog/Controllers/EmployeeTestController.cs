using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreCampBlog.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44365/api/Default");  //hayali adres
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44365/api/Default", content);  // Hayali Adres
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(class1);
        }
    }
    public class Class1       //BlogApiDemo daki modellerin karşılığı
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
