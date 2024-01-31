using Materials_Info.DbModels;
using Materials_Info.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Materials_Info.Controllers
{
    public class MaterialController : Controller
    {
        private readonly MaterialDbContext _context;

        public MaterialController(MaterialDbContext context) 
        { 
         _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> MaterialCreate(RawMaterialVM model)
        {
            if (ModelState.IsValid)
            {
                var Entity = new RawMaterial()
                {
                CreatedDate = DateTime.Now,
                MaterialId = model.MaterialId,
                MaterialName = model.MaterialName,
                Unit=model.Unit,
                Quantity = model.Quantity, 
                };

                _context.RawMaterials.Add(Entity);
                await _context.SaveChangesAsync();
            }
            ModelState.AddModelError("", "Material Created");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MaterialUpdate(int id)
        {
            var model = new RawMaterialVM();
            var RawMaterial = await _context.RawMaterials.Where(p=>p.MaterialId == id).FirstOrDefaultAsync();
            if(RawMaterial != null)
            {
               
                model.MaterialName = RawMaterial.MaterialName;
                model.Unit = RawMaterial.Unit;
                model.Quantity = RawMaterial.Quantity;
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MaterialUpdate(RawMaterialVM model)
        {
            if (ModelState.IsValid)
            {
                    var RawMaterial =await _context.RawMaterials.Where(p=>p.MaterialId==model.MaterialId).FirstOrDefaultAsync();
                if (RawMaterial != null)
                {
                    model.MaterialName = RawMaterial.MaterialName; 
                    model.Unit = RawMaterial.Unit;
                    model.Quantity = RawMaterial.Quantity;


                    _context.Update(RawMaterial);
                    await _context.SaveChangesAsync();
                }
                    //RawMaterial.MaterialName = model.MaterialName;
                    //RawMaterial.Unit = model.Unit;
                    //RawMaterial.Quantity = model.Quantity;
                  

                }

            ModelState.AddModelError("", "Material Updated!");
            return View(model);
        }
            






        public async Task<IActionResult> MaterialDelete(int id)
        {
            var Material = await _context.RawMaterials.Where(p=>p.MaterialId==id).FirstOrDefaultAsync();
            
            if (Material != null)
            {
               
            }
            _context.RawMaterials.Remove(Material);
            await _context.SaveChangesAsync();
            return RedirectToAction("Materials" , "Material");

        }


       
    }
}
