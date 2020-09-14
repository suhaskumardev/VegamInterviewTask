using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegamInterviewTask.Models;
using VegamInterviewTask.BOL;
using System.Data;

namespace VegamInterviewTask.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        public List<ProductDropdownModel> GetProductDropdownModel()
        {
            try
            {
                return new BOLMaterial().BOL_GetProductDropdownModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MaterialModel GetMaterailInformation(string MaterialNo)
        {
            try
            {
                return new BOLMaterial().BOL_GetMaterailInformation(MaterialNo);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public string InsertMaterialInformation(MaterialModel materialModel)
        {
            try
            {
                BOLMaterial bOLMaterial = new BOLMaterial();
                var checkItem = GetMaterailInformation(materialModel.MaterialNo);
                if (checkItem != null)
                {
                    return "Material No. already exists";
                }
                else
                {
                    var status = bOLMaterial.BOL_InsertMaterialInformation(materialModel);
                    if (status == "Saved")
                    {
                        return "Information saved..";
                    }
                    else
                    {
                        return "Failed to save information ";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDetails> GetSelectedOrder(string OrderNum)
        {
            try
            {
                return new BOLMaterial().BOL_GetSelectedOrder(OrderNum);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}