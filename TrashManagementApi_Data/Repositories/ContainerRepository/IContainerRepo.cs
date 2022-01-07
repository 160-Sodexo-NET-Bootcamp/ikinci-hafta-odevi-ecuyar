using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashManagementApi_Data.Repositories.GenericRepository;

namespace TrashManagementApi_Data.Repositories.ContainerRepository
{
    public interface IContainerRepo : IGenericRepository<Container_DataModel>
    {


        //Task<IEnumerable<Container_DataModel>> GetContainersWithVehicle();
        


    }

    
}
