using CourierManagement.Database.Tables;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Repository.IRepositories
{
    public interface ICourierRepository
    {
        public Task<int> SaveCourier(Courier courier);
        public Task<int> DeleteCourier(int id);
        public Task<IQueryable<Courier>> ListCouriers();
        public Task<Courier> GetCourierById(int id);
    }
}
