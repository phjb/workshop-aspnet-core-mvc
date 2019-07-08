﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

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
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellersServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellersServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellersServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Department> departments = _departamentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Seller seller)
        {
            if (id !=seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellersServices.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {

                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
          
        }
    }
}