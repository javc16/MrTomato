using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrTomato.Helpers;
using MrTomato.Models;
using MrTomato.Models.DTO;
using MrTomato.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Category item)
        {
            return Ok(await _categoryService.PostCategory(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(CategoryDTO item)
        {
            return Ok(await _categoryService.PutCategory(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(CategoryDTO item)
        {
            return Ok(await _categoryService.DeleteCategory(item));
        }
    }
}
