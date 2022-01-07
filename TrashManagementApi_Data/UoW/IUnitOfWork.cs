using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashManagementApi_Data.Repositories.ContainerRepository;
using TrashManagementApi_Data.Repositories.VehicleRepository;

namespace TrashManagementApi_Data.UoW
{
    public interface IUnitOfWork
    {
        IContainerRepo Container { get; }
        IVehicleRepo Vehicle { get; }

        int Complete();
    }
}
