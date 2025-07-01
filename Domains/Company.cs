using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreMVCWithAuth.Domains
{
    public class Company
    {
        [Key]
        public long CompanyId { get; set; }
        [Display(Name ="Имя компании")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Информация о компании")]
        [Required]
        public string Information { get; set; }
        [Display(Name ="Дата основания")]
        [Required]
        public DateTime Founded { get; set; }
        [Display(Name ="Логотип")]
        [Required]
        public string Image { get; set; }
        [Display(Name ="Индустрия")]
        [Required]
        public Industry Industry { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
