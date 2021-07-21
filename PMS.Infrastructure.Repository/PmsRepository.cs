using Microsoft.Extensions.Configuration;
using PMS.Core.Entities;
using PMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PMS.Infrastructure.Repository
{
    public class PmsRepository : IPmsRepository
    {
        private string connectionstring;
        public PmsRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

      public ProjectsDetail GetProjectsList(int page,int pageSize)
        {
            var entity = new ProjectsDetail();
            var projectlst = new List<Project>();
            var emplst = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(SqlConstants.usp_GetProjectsList, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@page",page);
                command.Parameters.AddWithValue("@pagesize", pageSize);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    projectlst.Add(new Project
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ProjectName = reader["Name"].ToString(),
                        ProjectStartDate = Convert.ToDateTime(reader["StartDate"]).ToString(),
                        ProjectEndDate = Convert.ToDateTime(reader["EndDate"]).ToString(),
                        ProjectManagerName = reader["ManagerName"].ToString(),
                        ProjectManagerEmail= reader["ManagerEmail"].ToString()
                    }) ;
                    entity.Page = Convert.ToInt32(reader["Page"]);
                    entity.PageSize = Convert.ToInt32(reader["PageSize"]);
                    entity.TotalItems = Convert.ToInt32(reader["Total"]);
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        emplst.Add(new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            DOJ = Convert.ToDateTime(reader["DOJ"]).ToString(),
                            DepartmentName = reader["DepartmentName"].ToString(),
                            ProjectId = Convert.ToInt32(reader["ProjectId"])
                        });
                    }
                }
                foreach(var projects in projectlst)
                {
                    projects.employees = emplst.Where(x => x.ProjectId == projects.Id).ToList();
                }    
                entity.data = projectlst;
            }

            return entity;
        
        }

        public int UserLogin(string email, string password)
        {
            int result=0;
           using(SqlConnection con= new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(SqlConstants.usp_UserLogin,con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                con.Open();
               SqlDataReader reader= command.ExecuteReader();
                while(reader.Read())
                {
                    result = Convert.ToInt32(reader["Id"]);
                }
              
            }
            return result;
        }
    }
}
