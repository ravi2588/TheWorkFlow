﻿using Microsoft.AspNetCore.Mvc;

namespace TheWorkFlow.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();

        }
        public IActionResult Delete()
        {
            return View();

        }
        public IActionResult Update()
        {
            return View();

        }
    }
}