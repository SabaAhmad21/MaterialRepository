using Materials_Dis.DbModels;
using Materials_Dis.Infrastructure.Interface;
using Materials_Dis.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Materials_Dis.Infrastructure.Implementation
{
    public class MaterialRepository : IMaterialRepository

    {
        private readonly RawMaterialDbContext _context;
     

        public MaterialRepository(RawMaterialDbContext context) 
        { 
            _context = context; 
        }

        public  bool CreateMaterial(MaterialVM material)
        {
            Material Entity = new Material();
            Entity.Quantity = material.Quantity;
            Entity.Unit = material.Unit;
            Entity.MaterialName = material.MaterialName;
            Entity.CreatedDate = DateTime.Now;

            _context.Materials.Add(Entity);
           _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteMaterial(Guid id)
        {
           var material = _context.Materials.Where(p=>p.Id==id).FirstOrDefault();
            _context.Materials.Remove(material);
            _context.SaveChanges();
            return true;
        }
       
        public IEnumerable<MaterialVM> GetAllMaterial()
        {
            var material = _context.Materials.ToList();
            List<MaterialVM> ListMaterial = new List<MaterialVM>();
            foreach (var item in material)
            {
                MaterialVM VM = new MaterialVM();
                VM.Quantity = item.Quantity;
                VM.Unit = item.Unit;
                VM.MaterialName = item.MaterialName;
                VM.CreatedDate = DateTime.Now;

                ListMaterial.Add(VM);   
            }
            return ListMaterial;

        }

        public bool UpdateMaterial(MaterialVM model)
        {
            var material =_context.Materials.Where(p=>p.Id==model.Id).FirstOrDefault();
            if (material != null)
            {
                material.Quantity = model.Quantity; 
                material.Unit = model.Unit;
                material.MaterialName = model.MaterialName;
                material.CreatedDate = DateTime.Now;

                _context.Update(material);
                _context.SaveChanges();
                

            }
            return true;
        }

        public MaterialVM GetMaterialById(Guid id)
        {
            var material = _context.Materials.Where(p=> p.Id==id).FirstOrDefault();
            if (material != null)
            {
                return new MaterialVM()
                {
                    Quantity = material.Quantity,
                    Unit = material.Unit,
                    MaterialName = material.MaterialName,
                    CreatedDate = DateTime.Now

                };
            }
            else
            {
                return null;
            }
        }


    }
}
