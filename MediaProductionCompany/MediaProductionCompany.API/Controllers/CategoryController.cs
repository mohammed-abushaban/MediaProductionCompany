using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoryController : BaseController
    {

        private ICategoryService _categoryService;

        public CategoryController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var categoreis = await _categoryService.Index();
            return Ok(GetResponse(categoreis, "done"));
        }
        //[Authorize]
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
            var category = await _categoryService.Create(UserId, dto);
            return Ok(GetResponse(category, "done"));
        }



        // PUT: CategoryController/Edit
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]UpdateCategoryDto dto)
        {
            var category = await _categoryService.Edit(UserId, dto);
            return Ok(GetResponse(category, "done"));

        }

        // Delete: CategoryController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(UserId ,id);
            return Ok(GetResponse());
        }
    }
}
