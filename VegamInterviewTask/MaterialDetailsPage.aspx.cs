using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VegamInterviewTask
{
    public partial class MaterialDetailsPage : System.Web.UI.Page
    {
        Models.MaterialModel materialModel=null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                try
                {
                    materialModel = new Models.MaterialModel();
                    materialModel.Duration = txtDuration.Text;
                    materialModel.MaterialDesc = txtMaterialDesc.Text;
                    materialModel.MaterialNo = txtMaterialNo.Text;
                    materialModel.ShelfLife = !string.IsNullOrEmpty(txtShelfLife.Text) ? Convert.ToInt32(txtShelfLife.Text) : (int?)null;
                    materialModel.Type = ddlType.SelectedValue;
                    Repository.IMaterialRepository materialRepository = new Repository.MaterialRepository();
                    var response = materialRepository.InsertMaterialInformation(materialModel);
                    if(response.ToLower().Contains("save"))
                    {
                        txtDuration.Text = string.Empty;
                        txtMaterialDesc.Text = string.Empty;
                        txtMaterialNo.Text = string.Empty;
                        txtShelfLife.Text = string.Empty;
                    }
                    Response.Write("<script>alert('" + response + "');</script>");
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
              
            }
        }

      
    }
}