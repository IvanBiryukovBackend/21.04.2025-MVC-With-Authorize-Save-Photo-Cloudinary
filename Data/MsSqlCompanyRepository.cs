using ASPNETCoreMVCWithAuth.Abstract;
using ASPNETCoreMVCWithAuth.Domains;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace ASPNETCoreMVCWithAuth.Data
{
    public class MsSqlCompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public MsSqlCompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void DeleteCompany(Company company)
        {
            _context.Remove(company);
            _context.SaveChanges();
        }

        public async Task<Company> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCompany(Company company)
        {
            _context.Update(company);
            return Save();
        }
    }
}
