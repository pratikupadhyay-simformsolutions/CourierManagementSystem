using Microsoft.AspNetCore.Mvc;
using CourierManagement.Entities;
using CourierManagement.Entities.Models;
using CourierManagement.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Web.Controllers
{
    public class CourierController : Controller
    {
        private readonly ICourierService _courierService;

        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        /// <summary>
        ///  Using this method Add or Edit Courier
        /// </summary>
        /// <param name="id">if id is not null then Edit page open otherwise blank page open</param>
        public async Task<IActionResult> Create(int? id)
        {
            try
            {
                if (id != null)
                {
                    return View(await _courierService.GetCourierById(id.GetValueOrDefault()));
                }
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  This is post method which is used for store data into database.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(ResponseModel<CourierModel> courierRequestModel)
        {
            try
            {
                _ = await _courierService.CreateCourier(courierRequestModel.Result);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  This method is used for GridView of a courier list.
        /// </summary>
        public async Task<IActionResult> List()
        {
            try
            {
                return View(await _courierService.GetCourierList());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Using this method Delete any courier from list.
        /// </summary>
        /// <param name="id">using the id find the record from list and delete that record.</param>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _ = await _courierService.DeleteCourier(id);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
