using System.Collections.Generic;
using System.Threading.Tasks;
using TrashManagementApi_Data.Repositories.GenericRepository;

namespace TrashManagementApi_Data.Repositories.VehicleRepository
{
    public interface IVehicleRepo : IGenericRepository<Vehicle_DataModel>
    {
        bool DeleteWithContainerInfo(long id);
    }
}
