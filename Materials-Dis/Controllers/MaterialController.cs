using Materials_Dis.Infrastructure.Interface;
using Materials_Dis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Materials_Dis.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialController(IMaterialRepository materialRepository) 
        {
          
            _materialRepository=materialRepository;
        
        }

        public IActionResult Materials()
        {
            return View(_materialRepository.GetAllMaterial());
        }

        [HttpGet]
        public IActionResult CreateMaterial() 
        { 
          
            return View();
        
        }

        [HttpPost]

        public IActionResult CreateMaterial(MaterialVM material)
        {
            if(ModelState.IsValid)
            {
                if(_materialRepository.CreateMaterial(material))
                {
                    ModelState.AddModelError("", "Material Created Successfully!");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong.");
                }
                return View();
            }
            return View();
        }


        public IActionResult UpdateMaterial(Guid id)
        {

            return View(_materialRepository.GetMaterialById(id));

        }

        public ActionResult UpdateMaterial(MaterialVM material)
        {
            if(ModelState.IsValid)
            {
                _materialRepository.UpdateMaterial(material);
            }
            return RedirectToAction("Materials", new {Controller  = "Material"});
        }



        public IActionResult DeleteMaterial(Guid id)
        {
            _materialRepository.DeleteMaterial(id);
            return RedirectToAction("Materials");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
