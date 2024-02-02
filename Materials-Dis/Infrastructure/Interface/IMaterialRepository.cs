using Materials_Dis.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Materials_Dis.Infrastructure.Interface
{
    public interface IMaterialRepository
    {
        bool CreateMaterial(MaterialVM material);
        IEnumerable<MaterialVM> GetAllMaterial();
        bool UpdateMaterial(MaterialVM model);

        MaterialVM GetMaterialById(Guid id);
        bool DeleteMaterial(Guid id);
    }
}
