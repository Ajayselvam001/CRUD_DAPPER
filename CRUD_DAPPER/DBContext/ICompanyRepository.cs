
using CRUD_DAPPER.Models;

namespace CRUD_DAPPER.DBContext
{
    //    public class ICompanyRepository
    //    {
    //    }
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int? id);
        Task CreateCompany(Company company);
        Task UpdateCompany(int id, Company company);
        Task DeleteCompany(int id);
    }
}
