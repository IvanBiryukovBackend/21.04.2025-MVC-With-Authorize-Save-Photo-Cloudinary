using ASPNETCoreMVCWithAuth.Abstract;
using ASPNETCoreMVCWithAuth.Domains;
using ASPNETCoreMVCWithAuth.Helper;
using ASPNETCoreMVCWithAuth.Models;
using ASPNETCoreMVCWithAuthAndPhotoCloud.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using static System.Net.Mime.MediaTypeNames;

namespace ASPNETCoreMVCWithAuth.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IPhotoService _photoService;

        public CompaniesController(
            ICompanyRepository companyRepository,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            IPhotoService photoService
            )
        {
            _companyRepository = companyRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _photoService = photoService;
        }

        public async Task<IActionResult> CompanyList()
        {
            IEnumerable<Company> companies =
                await _companyRepository.GetCompanies();

            return View(companies);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            return View(companyViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel companyViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(companyViewModel.Image);
                Company company = new Company
                {
                    Name = companyViewModel.Name,
                    Information = companyViewModel.Information,
                    Founded = companyViewModel.Founded,
                    Image = result.Url.ToString(),
                    Industry = companyViewModel.Industry,
                    UserId = _userManager.GetUserId(User)
                };
                _companyRepository.CreateCompany(company);
                return RedirectToAction("CompanyList");
            }
            else
            {
                ModelState.AddModelError("error","Company Upload Failed");
            }

            return View(companyViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyRepository.GetByIdAsyncNoTracking(id);

            if (company == null)
            {
                return View("Error");
            }

            EditCompanyViewModel companyViewModel = new EditCompanyViewModel
            {
                Name = company.Name,
                Information = company.Information,
                Founded = company.Founded,
                ImageForm = company.Image,
                Industry = company.Industry
            };

            return View(companyViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCompanyViewModel companyViewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("Failed","Failed to edit company");
                return View("Edit", companyViewModel);
            }

            var result = await _photoService.AddPhotoAsync(companyViewModel.Image);
            var userCompany = await _companyRepository.GetByIdAsyncNoTracking(id);
            if (companyViewModel.Image == null)
            {
                return Ok();
            }
            else
            {
                var resulta = await _photoService.DeletePhotoAsync(id.ToString());
            }

            if (userCompany != null)
            {
                Company company = new Company()
                {
                    CompanyId = id,
                    Name = companyViewModel.Name,
                    Information = companyViewModel.Information,
                    Founded = companyViewModel.Founded,
                    Image = result.Url.ToString(),
                    Industry = companyViewModel.Industry,
                    UserId = _userManager.GetUserId(User)
                };

                _companyRepository.UpdateCompany(company);
                return RedirectToAction("CompanyList", "Companies");
            }
            else
            {
                return View(companyViewModel);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var companyDetails = await _companyRepository.GetByIdAsyncNoTracking(id);

            if(companyDetails == null)
            {
                return View("Error");
            }

            return View(companyDetails);
        }

        [Authorize]
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var companyDetails = await _companyRepository.GetByIdAsyncNoTracking(id);
            if (companyDetails == null)
            {
                return View("Error");
            }

            _companyRepository.DeleteCompany(companyDetails);
            return RedirectToAction("CompanyList");
        }
    }
}
