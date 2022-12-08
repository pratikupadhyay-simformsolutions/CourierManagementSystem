using CourierManagement.Entities;
using CourierManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Services.IService
{
    public interface ICourierService
    {
        Task<ResponseModel<int>> CreateCourier(CourierModel courierRequestModel);

        Task<ResponseModel<CourierModel>> GetCourierById(int id);

        Task<ResponseModel<List<CourierModel>>> GetCourierList();

        Task<ResponseModel<int>> DeleteCourier(int id);
    }
}
