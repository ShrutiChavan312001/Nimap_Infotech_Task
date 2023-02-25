using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Nimap_Infotech_Task.Models
{
    public class CommonDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        //crud CategoryMaster
        public List<CategoryMaster> GetCategory()
        {
            List<CategoryMaster> CategoryList = new List<CategoryMaster>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CategoryMaster cat = new CategoryMaster();
                cat.CategoryId = Convert.ToInt32(dr.GetValue(0).ToString());
                cat.CategoryName = dr.GetValue(1).ToString();
                CategoryList.Add(cat);

            }
            con.Close();

            return CategoryList;
        }

        public bool AddCategoryMaster(Category cat)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCategoryMaster(Category cat,int CategoryId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
            con.Open();
            int i = cmd.ExecuteNonQuery();//executenonQuery use when we work on dml query(insert,update,delete). returns integer value.
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteCategoryMaster(int CategoryId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            con.Open();
            int i = cmd.ExecuteNonQuery();//executenonQuery use when we work on dml query(insert,update,delete). returns integer value.
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //crud ProductMaster
        public List<ProductMaster> GetProducts()
        {
            List<ProductMaster> ProductList = new List<ProductMaster>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductMaster cat = new ProductMaster();
                cat.ProductId = Convert.ToInt32(dr.GetValue(0));
                cat.CategoryName = dr.GetValue(1).ToString();
                cat.ProductName = dr.GetValue(2).ToString();
                ProductList.Add(cat);

            }
            con.Close();

            return ProductList;
        }

        public bool AddProductMaster(ProductMaster cat)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", cat.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", cat.CategoryName);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProductMaster(ProductMaster cat)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", cat.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", cat.ProductName);
            con.Open();
            int i = cmd.ExecuteNonQuery();//executenonQuery use when we work on dml query(insert,update,delete). returns integer value.
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteProductMaster(int ProductId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            con.Open();
            int i = cmd.ExecuteNonQuery();//executenonQuery use when we work on dml query(insert,update,delete). returns integer value.
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Product Details
        public List<ProductDetails> GetProductDetails()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                productDetails.Add(
                        new ProductDetails
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = Convert.ToString(dr["ProductName"]),
                            CategoryId = Convert.ToInt32(dr["CategoryId"]),
                            CategoryName = Convert.ToString(dr["CategoryName"])
                            
                        });

            }
            con.Close();

            return productDetails;
        }

        public bool AddCategory(CategoryMaster cat)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
            cmd.Parameters.AddWithValue("@Product", cat.Product);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet GetCategoryMaster()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(cs);
            try
            {
                SqlCommand cmd = new SqlCommand("spGetCatMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }



    }
}