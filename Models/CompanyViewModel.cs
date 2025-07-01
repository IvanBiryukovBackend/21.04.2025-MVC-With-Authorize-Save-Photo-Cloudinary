using ASPNETCoreMVCWithAuth.Domains;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCWithAuth.Models
{
    public class CompanyViewModel
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public DateTime Founded { get; set; }
        public IFormFile Image { get; set; }
        public Industry Industry { get; set; }
    }
}
