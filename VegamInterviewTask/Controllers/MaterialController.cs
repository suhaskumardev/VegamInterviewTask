using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VegamInterviewTask.Models;

namespace VegamInterviewTask.Controllers
{
    public class MaterialController : ApiController
    {
        [HttpGet]
        public List<ProductDropdownModel> GetProductDropdownModel()
        {
            try
            {
                Repository.IMaterialRepository materialRepository = new Repository.MaterialRepository();
                return materialRepository.GetProductDropdownModel();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public List<OrderDetails> GetSelectedOrder(string OrderNum)
        {
            try
            {
                Repository.IMaterialRepository materialRepository = new Repository.MaterialRepository();
                return materialRepository.GetSelectedOrder(OrderNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
