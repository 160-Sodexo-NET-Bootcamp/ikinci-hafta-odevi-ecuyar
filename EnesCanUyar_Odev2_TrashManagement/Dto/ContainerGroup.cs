using System.Collections.Generic;

namespace EnesCanUyar_Odev2_TrashManagement.Dto
{
    public class ContainerGroup
    {
        public int ContainerGroupId { get; set; }
        public long VehicleId { get; set; }
        public List<ContainerDto> Containers { get; set; }

        public ContainerGroup()
        {
            Containers = new List<ContainerDto>();
        }
    }
}
