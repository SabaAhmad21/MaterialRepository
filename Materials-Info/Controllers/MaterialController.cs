using Materials_Info.DbModels;
using Materials_Info.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Materials_Info.Controllers
{
    public class MaterialController : Controller
    {
        private readonly MaterialDbContext _context;

        public MaterialController(MaterialDbContext context) 
        { 
         _context = context;
        }

        public async Task<IActionResult> Materials()
        {
            return View(await _context.RawMaterials.ToListAsync());

        }

        [HttpGet]
        public async Task<IActionResult> MaterialCreate()
        {
            return View();
                
        }

        [HttpPost]
        public async Task<IActionResult> MaterialCreate(RawMaterialVM material)
        {
            if (ModelState.IsValid)
            {
                var Entity = new RawMaterial()
                {
                CreatedDate = DateTime.Now,
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
                Unit=material.Unit,
                Quantity = material.Quantity, 
                };

                _context.RawMaterials.Add(Entity);
                await _context.SaveChangesAsync();
            }
            ModelState.AddModelError("", "Material Created");
            return RedirectToAction("Materials" ,material);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
