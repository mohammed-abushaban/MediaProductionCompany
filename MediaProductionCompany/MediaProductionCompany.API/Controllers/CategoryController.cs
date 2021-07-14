using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class CategoryController : BaseController
    {

        private ICategoryService _categoryService;

        public CategoryController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var categoreis = await _categoryService.Index();
            return Ok(GetResponse(categoreis, "done"));
        }
        [HttpGet]
        // GET: CategoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.Details(id);
            return Ok(GetResponse(category, "done"));
        }

        // POST: CategoryController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategoryDto dto)
        {
            var category = await _categoryService.Create(string userId, dto);
            return Ok(GetResponse(category, "done"));
        }



        // PUT: CategoryController/Edit
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]UpdateCategoryDto dto)
        {
            var category = await _categoryService.Edit(string userId, dto);
            return Ok(GetResponse(category, "done"));

        }

        // Delete: CategoryController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string userId, int id)
        {
            await _categoryService.Delete(id);
            return Ok(GetResponse());
        }
    }
}
