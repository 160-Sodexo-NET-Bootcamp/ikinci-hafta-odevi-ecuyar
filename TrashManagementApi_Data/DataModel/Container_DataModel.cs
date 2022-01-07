using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashManagementApi_Data
{
    public class Container_DataModel
    {
        [Key]
        public long Id { get; set; }

        public string ContainerName { get; set; }

        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitude { get; set; }
        public long VehicleId { get; set; }

        //deleted because of object cycle
        //[ForeignKey("VehicleId")]
        //public Vehicle_DataModel Vehicle { get; set; }
    }
}
