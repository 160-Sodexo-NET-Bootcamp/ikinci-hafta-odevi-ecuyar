using TrashManagementApi_Data.Context;
using TrashManagementApi_Data.Repositories.GenericRepository;
using System.Linq;

namespace TrashManagementApi_Data.Repositories.VehicleRepository
{
    public class VehicleRepo : GenericRepository<Vehicle_DataModel>, IVehicleRepo
    {
        public VehicleRepo(TrashManagementDbContext context) : base(context)
        {
        }

        public bool DeleteWithContainerInfo(long id)
        {
            //I assume that if a vehicle is deleted, I will go to containers and delete vehicleId info of container
            // just make vehicleid -1

            var model = context.Set<Vehicle_DataModel>().Find(id);
            dbSet.Remove(model);

            var updateContainers = context.Set<Container_DataModel>().Where(x => x.VehicleId == id);

            foreach (var item in updateContainers)
            {
                item.VehicleId = -1L;
                context.Set<Container_DataModel>().Update(item);
            }

            return true;
        }
    }
}
