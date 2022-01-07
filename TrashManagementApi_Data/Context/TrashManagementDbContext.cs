using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashManagementApi_Data.Context
{
    public class TrashManagementDbContext : DbContext, ITrashManagementDbContext
    {
        public TrashManagementDbContext(DbContextOptions<TrashManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Container_DataModel> Container { get; set; }
        public DbSet<Vehicle_DataModel> Vehicle { get; set; }

    }
}
