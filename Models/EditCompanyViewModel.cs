using ASPNETCoreMVCWithAuth.Domains;

namespace ASPNETCoreMVCWithAuth.Models
{
    public class EditCompanyViewModel
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public DateTime Founded { get; set; }
        public IFormFile Image { get; set; }
        public string ImageForm { get; set; }
        public Industry Industry { get; set; }
    }
}
