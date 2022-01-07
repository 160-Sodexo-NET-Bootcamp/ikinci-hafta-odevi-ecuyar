using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashManagementApi_Data
{
    public class Vehicle_DataModel
    {
        [Key]
        public long Id { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }

        //deleted because of object cycle
        //public List<Container_DataModel> Container { get; set; }

    }
}
