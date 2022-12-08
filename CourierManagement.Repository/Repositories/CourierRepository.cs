using CourierManagement.Database;
using CourierManagement.Database.Tables;
using CourierManagement.Repository.IRepositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Repository.Repositories
{
    public class CourierRepository : GenericRepository<Courier>, ICourierRepository
    {
        public CourierRepository(CourierManagmentContext context) : base(context)
        {
        }

        public async Task<int> SaveCourier(Courier courier)
        {
            try
            {
                await base.AddAsync(courier);
                return courier.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteCourier(int id)
        {
            try
            {
                var courier = base.GetById(id);
                base.Remove(courier);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IQueryable<Courier>> ListCouriers()
        {
            try
            {
                return await Task.Run(() => _context.Couriers);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Courier> GetCourierById(int id)
        {
            try
            {
                return await Task.Run(() => base.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
