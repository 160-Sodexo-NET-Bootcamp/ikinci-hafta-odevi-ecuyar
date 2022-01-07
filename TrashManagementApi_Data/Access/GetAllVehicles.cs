using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrashManagementApi_Data.Access
{
    public class GetAllVehicles
    {
        private readonly DbSet<Vehicle_DataModel> dbset;

        public async Task<IEnumerable<Vehicle_DataModel>> All()
        {
            return await dbset.ToListAsync();
        }
    }
}
