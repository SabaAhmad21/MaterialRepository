using System.ComponentModel.DataAnnotations;

namespace Materials_Info.ViewModels
{
    public class RawMaterialVM
    {

        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Material Name is required!")]
        public string MaterialName { get; set; } = null!;

        [Required(ErrorMessage = "Unit is required!")]
        public string Unit { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required!")]
        public decimal Quantity { get; set; }

       
        public DateTime CreatedDate { get; set; }
    }
}
