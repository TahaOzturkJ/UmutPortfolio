using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Concrete;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using Project.UI.Models;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());

        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(Portfolio portfolio,PortfolioViewModel pvm)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);

            if (results.IsValid)
            {
                if (pvm.Image1 != null && Path.GetExtension(pvm.Image1.FileName) != ".svg")
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(pvm.Image1.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resource + "/wwwroot/PortfolioImage/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await pvm.Image1.CopyToAsync(stream);
                    portfolio.ImageUrl = "/PortfolioImage/" + imagename;
                }

                if (portfolio.Condition != 100)
                {
                    portfolio.Status = false;
                }
                else
                {
                    portfolio.Status = true;
                }

                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            PortfolioViewModel model = new PortfolioViewModel();
            model.PortfolioID = values.PortfolioID;
            model.Name = values.Name;
            model.Description = values.Description;
            model.ProjectUrl = values.ProjectUrl;
            model.Condition = (int)values.Condition;
            model.Price = values.Price;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPortfolio(Portfolio portfolio,PortfolioViewModel pvm)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            if (results.IsValid)
            {
                if (pvm.Image1 != null && Path.GetExtension(pvm.Image1.FileName) != ".svg")
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(pvm.Image1.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resource + "/wwwroot/PortfolioImage/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await pvm.Image1.CopyToAsync(stream);
                    portfolio.ImageUrl = "/PortfolioImage/" + imagename;
                }
                else
                {
                    portfolio.ImageUrl = portfolioManager.TGetByID(pvm.PortfolioID).ImageUrl;
                }

                if (portfolio.Condition != 100)
                {
                    portfolio.Status = false;
                }
                else
                {
                    portfolio.Status = true;
                }

                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
