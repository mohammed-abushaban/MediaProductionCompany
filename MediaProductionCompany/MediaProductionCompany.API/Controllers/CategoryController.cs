using MediaProductionCompany.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public Task<IActionResult> Index()
        {

        }

        // GET: CategoryController/Details/5
        public Task<IActionResult> Details(int id)
        {
        }

        // POST: CategoryController/Create
        [HttpPost]
        public Task<IActionResult> Create(CreateCategoryDto dto)
        {

        }



        // PUT: CategoryController/Edit
        [HttpPut]
        public Task<IActionResult> Edit(UpdateCategoryDto dto)
        {

        }

        // Delete: CategoryController/Delete/5
        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {

        }
    }
}
