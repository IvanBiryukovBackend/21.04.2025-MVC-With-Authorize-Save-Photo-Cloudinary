using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCWithAuth.Domains
{
    public enum Industry
    {
        [Display(Name = "Интернет")]
        Internet,
        [Display(Name = "Электронная торговля")]
        Ecommerce,
        [Display(Name = "Аэрокосмическая промышленность")]
        Aerospace,
        [Display(Name = "Финансовые услуги")]
        FinancialServices,
        [Display(Name = "Программное обеспечение")]
        Software,
        [Display(Name = "Видео игры")]
        Videogames
    }
}
