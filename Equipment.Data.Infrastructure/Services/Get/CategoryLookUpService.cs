using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Equipment.Get.Core;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace Equipment.Data.Infrastructure.Services.Get
{
    public class CategoryLookUpService : ICategorylookupServices
    {
        private readonly string strConnectionString;
        public CategoryLookUpService()
        {
            // strConnectionString = "server=SQL5098.site4now.net;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=db_a83b98_emsadmin001_admin;Password=kingPin007@#;";
            strConnectionString = "server=COMP-038\\SQLSERVER2019;Initial Catalog=db_a83b98_emsadmin001;Integrated Security=false;User ID=sa;Password=123$abc;";
        }
        /// <summary>
        /// AddCategorylookup
        /// </summary>
        /// <param name="categoryLookup"></param>
        /// <returns></returns>
        public async Task<int> AddCategorylookup(CategoryLookup categoryLookup)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CategoryName", categoryLookup.CategoryName);
                parameters.Add("@IsActive", categoryLookup.IsActive);
                parameters.Add("@CreatedDate", categoryLookup.CreatedDate);
                parameters.Add("@UpdatedDate", categoryLookup.UpdatedDate);
                parameters.Add("@CreatedBy", categoryLookup.CreatedBy);
                parameters.Add("@UpdatedBy", categoryLookup.UpdatedBy);

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("sp_Insert_Category", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// DeleteCategoryLookup
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsPermanentDelete"></param>
        /// <returns></returns>

        public async Task<CategoryLookup> DeleteCategoryLookup(int CategoryID, bool IsActive, bool IsPermanentDelete)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", CategoryID);
            parameters.Add("@IsActive", IsActive);
            parameters.Add("@IsPermanentDelete", IsPermanentDelete);

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var isDelete = await con.QueryFirstOrDefaultAsync<CategoryLookup>("Sp_Delete_Category", parameters, commandType: CommandType.StoredProcedure);
                return isDelete;
            }
        }

        /// <summary>
        /// GetAllCategoryLookup
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryLookup>> GetAllCategoryLookup()
        {
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var category = await con.QueryAsync<CategoryLookup>("Sp_Get_All_CategoryLookup");
                return category;

            }
        }

        /// <summary>
        /// UpdateCategoryLookup
        /// </summary>
        /// <param name="categoryLookup"></param>
        /// <returns></returns>
        public async Task<int> UpdateCategoryLookup(CategoryLookup categoryLookup)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CategoryID", categoryLookup.CategoryID);
                parameters.Add("@CategoryName", categoryLookup.CategoryName);
                parameters.Add("@IsActive", categoryLookup.IsActive);
                parameters.Add("@CreatedDate", categoryLookup.CreatedDate);
                parameters.Add("@UpdatedDate", categoryLookup.UpdatedDate);
                parameters.Add("@CreatedBy", categoryLookup.CreatedBy);
                parameters.Add("@UpdatedBy", categoryLookup.UpdatedBy);


                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    var val = await con.QueryFirstOrDefaultAsync<int>("sp_Update_Category", parameters, commandType: CommandType.StoredProcedure);
                    return val;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
    }

