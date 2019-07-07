using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellersServices;
        private readonly DepartamentService _departamentService;

        public SellersController(SellerServices sellersServices, DepartamentService departamentService)
        {
            _sellersServices = sellersServices;
            _departamentService = departamentService;
        }
        public IActionResult Index()
        {
            var list = _sellersServices.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departamentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}