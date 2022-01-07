using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnesCanUyar_Odev2_TrashManagement.Dto
{
    public class ContainerDto
    {
        public long Id { get; set; }

        public string ContainerName { get; set; }

        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitude { get; set; }

        public long VehicleId { get; set; }
    }
}
