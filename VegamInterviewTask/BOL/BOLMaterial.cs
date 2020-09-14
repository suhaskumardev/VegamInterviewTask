using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VegamInterviewTask.Models;

namespace VegamInterviewTask.BOL
{
    public class BOLMaterial
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString1"].ConnectionString);
        DataTable Dt1;
        SqlDataAdapter Ad1;
        string ReturnResponse = string.Empty;
        SqlCommand _SQLCmd1;


        public MaterialModel BOL_GetMaterailInformation(string MaterialNo)
        {
            try
            {
                _SQLCmd1 = new SqlCommand("SELECT * FROM TBL_MATERIALINFORMATION WHERE MaterialNo=@MaterialNo", conn);
                _SQLCmd1.CommandType = CommandType.Text;
                _SQLCmd1.Parameters.AddWithValue("@MaterialNo", MaterialNo);
                Ad1 = new SqlDataAdapter(_SQLCmd1);
                Dt1 = new DataTable();
                Ad1.Fill(Dt1);
                if(Dt1!=null && Dt1.Rows.Count>0)
                {
                    return new MaterialModel { 
                        Duration=Convert.ToString(Dt1.Rows[0]["Duration"]),
                        MaterialDesc= Convert.ToString(Dt1.Rows[0]["MaterialDesc"]),
                        MaterialNo= Convert.ToString(Dt1.Rows[0]["MaterialNo"]),
                        ShelfLife= !string.IsNullOrEmpty(Convert.ToString(Dt1.Rows[0]["ShelfLife"])) ? Convert.ToInt32(Convert.ToString(Dt1.Rows[0]["ShelfLife"])): (int?)null,
                        Type= Convert.ToString(Dt1.Rows[0]["Type"])
                    };

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BOL_InsertMaterialInformation(MaterialModel materialModel)
        {
            ReturnResponse = string.Empty;

            try
            {
                conn.Open();
                string query = "INSERT INTO TBL_MATERIALINFORMATION(MaterialNo,MaterialDesc,ShelfLife,Duration,Type) Values(@MaterialNo,@MaterialDesc,@ShelfLife,@Duration,@Type)";
                _SQLCmd1 = new SqlCommand(query, conn);
                _SQLCmd1.CommandType = CommandType.Text;
                _SQLCmd1.Parameters.AddWithValue("@MaterialNo", materialModel.MaterialNo);
                if (string.IsNullOrEmpty(materialModel.MaterialDesc))
                    _SQLCmd1.Parameters.AddWithValue("@MaterialDesc", DBNull.Value);
                else
                    _SQLCmd1.Parameters.AddWithValue("@MaterialDesc", materialModel.MaterialDesc);
                _SQLCmd1.Parameters.AddWithValue("@ShelfLife", materialModel.ShelfLife);
                if (string.IsNullOrEmpty(materialModel.Duration))
                    _SQLCmd1.Parameters.AddWithValue("@Duration", DBNull.Value);
                else
                    _SQLCmd1.Parameters.AddWithValue("@Duration", materialModel.Duration);
                _SQLCmd1.Parameters.AddWithValue("@Type", materialModel.Type);
                int cnt = _SQLCmd1.ExecuteNonQuery();
                ReturnResponse = cnt > 0 ? "Saved" : "Failed";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return ReturnResponse;
        }

        public List<ProductDropdownModel> BOL_GetProductDropdownModel()
        {
            try
            {
                _SQLCmd1 = new SqlCommand("SELECT P.OrderNum,P.MaterialNo,MaterialDesc FROM TBL_PRODUCT_DTL P LEFT JOIN TBL_MATERIALINFORMATION M ON P.MaterialNo=M.MaterialNo", conn);
                _SQLCmd1.CommandType = CommandType.Text;
                Ad1 = new SqlDataAdapter(_SQLCmd1);
                Dt1 = new DataTable();
                Ad1.Fill(Dt1);
                if (Dt1 != null && Dt1.Rows.Count > 0)
                {
                    List<ProductDropdownModel> lstitmes = new List<ProductDropdownModel>();
                    foreach (DataRow row in Dt1.Rows)
                    {
                        lstitmes.Add(new ProductDropdownModel
                        {
                            OrderNum = Convert.ToString(row["OrderNum"]),
                            MaterialDesc = Convert.ToString(row["MaterialDesc"]),
                            MaterialNo = Convert.ToString(row["MaterialNo"]),
                        });
                    }
                    return lstitmes;

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDetails> BOL_GetSelectedOrder(string OrderNum)
        {
            try
            {
                _SQLCmd1 = new SqlCommand("SELECT P.MaterialNo,MaterialDesc,P.Batch,(convert(varchar(10),P.Qty) +' '+ UOM) QTY,ExpiryDate,ShelfLife,(Select OrderDate from TBL_PRODUCT_HDR WHERE OrderNum=P.OrderNum) OrderDate FROM TBL_PRODUCT_DTL P INNER JOIN TBL_MATERIALINFORMATION M ON P.MaterialNo=M.MaterialNo AND P.OrderNum=@OrderNum", conn);
                _SQLCmd1.CommandType = CommandType.Text;
                _SQLCmd1.Parameters.AddWithValue("@OrderNum", OrderNum);
                Ad1 = new SqlDataAdapter(_SQLCmd1);
                Dt1 = new DataTable();
                Ad1.Fill(Dt1);
                if (Dt1 != null && Dt1.Rows.Count > 0)
                {
                    List<OrderDetails> lstitmes = new List<OrderDetails>();
                    foreach (DataRow row in Dt1.Rows)
                    {
                        lstitmes.Add(new OrderDetails
                        {
                            Batch = Convert.ToString(row["Batch"]),
                            MaterialDesc = Convert.ToString(row["MaterialDesc"]),
                            MaterialNo = Convert.ToString(row["MaterialNo"]),
                            Qty= Convert.ToString(row["Qty"]),
                            ExpiryDate= Convert.ToString(row["ExpiryDate"]),
                            OrderDate = Convert.ToString(row["OrderDate"]),
                            ShelfLife = !string.IsNullOrEmpty(Convert.ToString(row["ShelfLife"])) ? Convert.ToInt32(Convert.ToString(row["ShelfLife"])) : 0,
                        });
                    }
                    return lstitmes;

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}