using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServicesManager _services;

        public CategoriesController(IServicesManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllcategories()
        {
            return Ok(await _services.CategoryService.GetAllCategoriesAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllcategories([FromRoute]int id)
        {
            return Ok(await _services.CategoryService.GetOneCategoryAsync(id,false));
        }
    }
}
