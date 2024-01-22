﻿using Account.FE.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;


namespace Account.FE.Controllers
{
    public class CustomerController : Controller
    {
        //public IActionResult Index()
        //{
        //    var env = Environment.GetEnvironmentVariable("END_POINT_URL");
        //    Console.WriteLine(env);
        //    return View();
        //}

        public static async Task<List<Customer>> OnGetAsync()
        {
            var path = Environment.GetEnvironmentVariable("END_POINT_URL")+ "/customers";

            List<Customer> customers = new List<Customer>();

            using (var httpClient = new HttpClient())
            {
                using HttpResponseMessage response = 
                    await httpClient.GetAsync(path);

                string apiResponse = await response.Content.ReadAsStringAsync();

                customers = JsonNet.Deserialize<List<Customer>>(apiResponse);
            }
            return customers;//new JsonResult(customers);
        }
    }
}
