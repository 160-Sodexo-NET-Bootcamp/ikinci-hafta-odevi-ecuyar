using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashManagementApi_Data.Context
{
    public interface ITrashManagementDbContext
    {
        DbSet<Container_DataModel> Container { get; set; }
        DbSet<Vehicle_DataModel> Vehicle { get; set; }

    }
}
