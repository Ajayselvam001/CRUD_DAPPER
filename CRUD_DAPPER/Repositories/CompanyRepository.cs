using CRUD_DAPPER.DBContext;
using CRUD_DAPPER.Models;
using Dapper;
using System.Data;

namespace CRUD_DAPPER.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext context;

        public CompanyRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";

            using (var connection = context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async Task<Company> GetCompany(int? id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @Id";

            using (var connection = context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
                return company;
            }
        }

        public async Task CreateCompany(Company company)
        {
            var query = "INSERT INTO Companies (CompanyName, CompanyAddress, Country,GlassdoorRating) VALUES (@CompanyName, @CompanyAddress, @Country, @GlassdoorRating)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", company.CompanyName, DbType.String);
            parameters.Add("Address", company.CompanyAddress, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);
            parameters.Add("Country", company.GlassdoorRating, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateCompany(int id, Company company)
        {
            var query = "INSERT INTO Companies (CompanyName, CompanyAddress, Country,GlassdoorRating) VALUES (@CompanyName, @CompanyAddress, @Country, @GlassdoorRating WHERE Id = @Id)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", company.CompanyName, DbType.String);
            parameters.Add("Address", company.CompanyAddress, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);
            parameters.Add("Country", company.GlassdoorRating, DbType.Int32);
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteCompany(int id)
        {

            var query = "DELETE FROM Companies WHERE Id = @Id";
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}

