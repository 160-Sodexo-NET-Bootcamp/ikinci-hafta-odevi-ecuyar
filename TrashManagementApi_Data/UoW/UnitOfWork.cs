using TrashManagementApi_Data.Context;
using TrashManagementApi_Data.Repositories.ContainerRepository;
using TrashManagementApi_Data.Repositories.VehicleRepository;

namespace TrashManagementApi_Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TrashManagementDbContext _context;

        public IContainerRepo Container { get; private set; }
        public IVehicleRepo Vehicle { get; private set; }

        public UnitOfWork(TrashManagementDbContext context)
        {
            _context = context;

            Container = new ContainerRepo(_context);
            Vehicle = new VehicleRepo(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
