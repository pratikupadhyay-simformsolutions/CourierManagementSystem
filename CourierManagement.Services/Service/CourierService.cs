using AutoMapper;
using CourierManagement.Database.Tables;
using CourierManagement.Entities;
using CourierManagement.Entities.Models;
using CourierManagement.Repository.IRepositories;
using CourierManagement.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Services.Service
{
    public class CourierService : ICourierService
    {
        private readonly IMapper _mapper;
        private readonly ICourierRepository _courierRepository;

        public CourierService(ICourierRepository courierRepository, IMapper mapper)
        {
            _courierRepository = courierRepository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<int>> CreateCourier(CourierModel courierRequestModel)
        {
            ResponseModel<int> responseModel = new ResponseModel<int>();
            try
            {
                var courier = _mapper.Map<Courier>(courierRequestModel);
                responseModel.Result = await _courierRepository.SaveCourier(courier);
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
        }

        public async Task<ResponseModel<int>> DeleteCourier(int id)
        {
            ResponseModel<int> responseModel = new ResponseModel<int>();
            try
            {
                responseModel.Result = await _courierRepository.DeleteCourier(id);
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
        }

        public async Task<ResponseModel<CourierModel>> GetCourierById(int id)
        {
            ResponseModel<CourierModel> responseModel = new ResponseModel<CourierModel>();
            try
            {
                var projectResponseModel = await _courierRepository.GetCourierById(id);
                responseModel.Result = _mapper.Map<CourierModel>(projectResponseModel); 
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<CourierModel>>> GetCourierList()
        {
            ResponseModel<List<CourierModel>> responseModel = new ResponseModel<List<CourierModel>>();
            try
            {
                var projectResponseModelList = await _courierRepository.ListCouriers();
                responseModel.Result = _mapper.Map<List<CourierModel>>(projectResponseModelList.ToList());
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
                return responseModel;
            }
            catch(Exception ex)
            {
                responseModel.HasError = true;
                responseModel.Message = ex.Message;
                responseModel.StatusCode = HttpStatusCode.InternalServerError;
                return responseModel;
            }
            
        }
    }
}
