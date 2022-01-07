using System.ComponentModel.DataAnnotations;
using TrashManagementApi_Data;

namespace EnesCanUyar_Odev2_TrashManagement.Dto
{
    public class VehicleDto
    {
        public long Id { get; set; }

        [Required]
        public string VehicleName { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(7)]
        public string VehiclePlate { get; set; }
    }
}
