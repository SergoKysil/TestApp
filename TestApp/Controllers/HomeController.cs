using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.App.DTO;
using TestApp.App.Services.Interfaces;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ICSVService _csvService;

        public HomeController(ICSVService csvService, IWebHostEnvironment webHost)
        {
            this._csvService = csvService;
            this._appEnvironment = webHost;
        }


        public IActionResult Index(string sortOrder)


        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["MarriedSortParm"] = sortOrder == "Married" ? "married_desc" : "Married";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["SalarySortParm"] = sortOrder == "Salary" ? "salary_desc" : "Salary";


            var list = _csvService.GetAllCSVs();
            IEnumerable<CSVViewModel> csv = list.Result.Select(s => new CSVViewModel
            {
                Id = s.Id,
                Name = s.Name,
                DateofBirth = s.DateofBirth,
                IsMarried = s.IsMarried,
                Salary = s.Salary,
                Phone = s.Phone
            });

            switch (sortOrder)
            {
                case "name_desc":
                    csv = csv.OrderByDescending(x => x.Name);
                    break;

                case "Date":
                    csv = csv.OrderBy(x => x.DateofBirth);
                    break;

                case "date_desc":
                    csv = csv.OrderByDescending(x => x.DateofBirth);
                    break;

                case "Married":
                    csv = csv.OrderBy(x => x.IsMarried);
                    break;

                case "married_desc":
                    csv = csv.OrderByDescending(x => x.IsMarried);
                    break;

                case "Phone":
                    csv = csv.OrderBy(x => x.Phone);
                    break;

                case "phone_desc":
                    csv = csv.OrderByDescending(x => x.Phone);
                    break;

                case "Salary":
                    csv = csv.OrderBy(x => x.Salary);
                    break;

                case "salary_desc":
                    csv = csv.OrderByDescending(x => x.Salary);
                    break;

                default:
                    csv = csv.OrderBy(x => x.Name);
                    break;
            }

            return View(csv);
        }


        [HttpPost]
        public async Task<IActionResult> AddRange(IFormFile formFile)
        {
            string path = "/files/" + formFile.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
            var pathToWrite = _appEnvironment.WebRootPath + path;
            await _csvService.AddRange(pathToWrite);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _csvService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            CSVViewModel csv = new CSVViewModel
            {
                Id = result.Id,
                Name = result.Name,
                DateofBirth = result.DateofBirth,
                IsMarried = result.IsMarried,
                Phone = result.Phone,
                Salary = result.Salary
            };  
            return View(csv);
        }



        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, CSVViewModel model)
        {
            if (id == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var csv = new CSVDto
                {
                    Id = id,
                    Name = model.Name,
                    DateofBirth = model.DateofBirth,
                    IsMarried = model.IsMarried,
                    Phone = model.Phone,
                    Salary = model.Salary
                };
                await _csvService.Update(csv);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
                return NotFound();
            
            
            var result = await _csvService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            CSVViewModel csv = new CSVViewModel
            {
                Id = result.Id,
                Name = result.Name,
                DateofBirth = result.DateofBirth,
                IsMarried = result.IsMarried,
                Phone = result.Phone,
                Salary = result.Salary
            };
            return View(csv);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var result = await _csvService.GetById(id);
            if (result == null)
                return RedirectToAction("Index", "Home");

            await _csvService.Remove(id);
            return RedirectToAction("Index", "Home");
        }

    }
}
