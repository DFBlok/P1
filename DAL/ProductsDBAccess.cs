using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductsDBAccess
    {
        public bool AddNewProduct(Products product)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@QuanityUnit", product.QuantityPerUnit)
            };
            return DBHelper.ExecuteNonQuery("sp_InsertProduct", CommandType.StoredProcedure, parameters);
        }
        public Products GetProductDetails(int productID)
        {
            Products product = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@productID", productID)
            };
            using (DataTable table = DBHelper.ExecuteParamerizedselectCommand("sp_ReturnProduct",
                CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    product = new Products();
                    product.ProductID = Convert.ToInt32(row["ProductID"]);
                    product.ProductName = row["ProductName"].ToString();
                    product.QuantityPerUnit = row["QuantityPerUnit"].ToString();
                }
            }
            return product;
        }
        
        public List<Products> GetProductList()
        {
            List<Products> productList = null;

            using (DataTable table = DBHelper.ExecuteSelectCommand("sp_ReturnAllProduct",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    productList = new List<Products>();
                    foreach (DataRow row in table.Rows)
                    {
                        Products product = new Products();
                        product.ProductID = Convert.ToInt32(row["ProductID"]);
                        product.ProductName = row["ProductName"].ToString();
                        product.QuantityPerUnit = row["QuantityPerUnit"].ToString();
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
        
    }
}
