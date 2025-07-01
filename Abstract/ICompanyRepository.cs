using ASPNETCoreMVCWithAuth.Domains;

namespace ASPNETCoreMVCWithAuth.Abstract
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        void CreateCompany(Company company);
        bool UpdateCompany(Company company);
        Task<Company> GetByIdAsyncNoTracking(int id);
        void DeleteCompany(Company company);
        bool Save();


    }
}
