using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrashManagementApi_Data.Context;
using TrashManagementApi_Data.Repositories.GenericRepository;

namespace TrashManagementApi_Data.Repositories.ContainerRepository
{
    public class ContainerRepo : GenericRepository<Container_DataModel>, IContainerRepo
    {
        public ContainerRepo(TrashManagementDbContext context) : base(context)
        {
        }

        //public async Task<IEnumerable<Container_DataModel>> GetContainersWithVehicle()
        //{
        //    return await context.Set<Container_DataModel>().Include(x => x.Vehicle).ToListAsync();
        //}
    }
}
