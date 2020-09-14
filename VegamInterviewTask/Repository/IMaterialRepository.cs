using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegamInterviewTask.Models;

namespace VegamInterviewTask.Repository
{
    public interface IMaterialRepository
    {
        MaterialModel GetMaterailInformation(string MaterialNo);
        string InsertMaterialInformation(MaterialModel materialModel);
        List<ProductDropdownModel> GetProductDropdownModel();
        List<OrderDetails> GetSelectedOrder(string OrderNum);
    }
}