using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterVewPorject_02.Models
{
    public class M_Index : Databace
    {
        public string Query()
        {
            string strJson = string.Empty;
            DataTable dtResult = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnect()))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "Select CategoryID,CategoryName,Description from Categories ";
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtResult);
                    sda.Dispose();
                    strJson = JsonConvert.SerializeObject(dtResult, Formatting.Indented);
                }
            }

            return strJson;
        }

        public string Insert(Categories myCategories)
        {
            string strResult = string.Empty;
            int result = 0;
            using (SqlConnection conn = new SqlConnection(GetConnect()))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Insert Into Categories(CategoryName,Description,Picture) Values(@CategoryName,@Description,NULL) ";
                        cmd.Parameters.Add(new SqlParameter("@CategoryName", myCategories.CategoryName));
                        cmd.Parameters.Add(new SqlParameter("@Description", myCategories.Description));
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            strResult = "新增成功";
                        }
                        else
                        {
                            strResult = "新增失敗";
                        }
                    }
                    catch (SqlException)
                    {
                        strResult = "新增失敗";
                        throw;
                    }
                }
            }

            return strResult;
        }

        public string Update(Categories myCategories)
        {
            string strResult = string.Empty;
            int result = 0;
            using (SqlConnection conn = new SqlConnection(GetConnect()))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Update Categories Set CategoryName = @CategoryName,Description = @Description Where CategoryID = @CategoryID ";
                        cmd.Parameters.Add(new SqlParameter("@CategoryID", myCategories.CategoryID));
                        cmd.Parameters.Add(new SqlParameter("@CategoryName", myCategories.CategoryName));
                        cmd.Parameters.Add(new SqlParameter("@Description", myCategories.Description));
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            strResult = "編輯成功";
                        }
                        else
                        {
                            strResult = "編輯失敗";
                        }
                    }
                    catch (SqlException)
                    {
                        strResult = "編輯失敗";
                        throw;
                    }
                }
            }

            return strResult;
        }

        public string Delete(Categories myCategories)
        {
            string strResult = string.Empty;
            int result = 0;
            using (SqlConnection conn = new SqlConnection(GetConnect()))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Delete From Categories Where CategoryID = @CategoryID ";
                        cmd.Parameters.Add(new SqlParameter("@CategoryID", myCategories.CategoryID));
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            strResult = "刪除成功";
                        }
                        else
                        {
                            strResult = "刪除失敗";
                        }
                    }
                    catch (SqlException)
                    {
                        strResult = "刪除失敗";
                        throw;
                    }
                }
            }

            return strResult;
        }

    }
}