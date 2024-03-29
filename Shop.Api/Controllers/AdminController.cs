﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.DataModels.CustomModels;
using Shop.Logic.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService, IWebHostEnvironment _env)
        {
            this._adminService = adminService;
            this.env = _env;
        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(LoginModel loginModel)
        {
            var data = _adminService.AdminLogin(loginModel);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            var data = _adminService.GetProducts();
            return Ok(data);
        }


        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult SaveProduct(ProductModel newProduct)
        {
            int nextProductId = _adminService.GetNewProductId();
            newProduct.ImageUrl = @"Images/" + nextProductId + ".png";
            var path = $"{env.WebRootPath}\\Images\\{nextProductId + ".png"}";
            var fs = System.IO.File.Create(path);
            fs.Write(newProduct.FileContent, 0, newProduct.FileContent.Length);
            fs.Close();

            string uploadsFolder = Path.Combine(env.WebRootPath, "Images");

            var data = _adminService.SaveProduct(newProduct);
            return Ok(data);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(ProductModel productToDelete)
        {
            var data = _adminService.DeleteProduct(productToDelete);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProductStock")]
        public IActionResult GetProductStock()
        {
            var data = _adminService.GetProductStock();
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateProductStock")]
        public IActionResult UpdateProductStock(StockModel stock)
        {
            var data = _adminService.UpdateProductStock(stock);
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(ProductModel productToUpdate)
        {
            var data = _adminService.UpdateProduct(productToUpdate);
            return Ok(data);
        }

       

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var data = _adminService.GetCategories();
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveCategory")]
        public IActionResult SaveCategory(CategoryModel newCategory)
        {
            var data = _adminService.SaveCategory(newCategory);
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(CategoryModel categoryToUpdate)
        {
            var data = _adminService.UpdateCategory(categoryToUpdate);
            return Ok(data);
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(CategoryModel categoryToDelete)
        {
            var data = _adminService.DeleteCategory(categoryToDelete);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {
            var data = _adminService.GetOrders();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetOrderDetails")]
        public IActionResult GetOrderDetails(string order_number)
        {
            var data = _adminService.GetOrderDetails(order_number);
            return Ok(data);
        }

       

        [HttpGet]
        [Route("GetShippingStatus")]
        public IActionResult GetShippingStatus()
        {
            var data = _adminService.GetShippingStatus();
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveShippingStatus")]
        public IActionResult SaveShippingStatus(ShippingModel newShippingModel)
        {
            var data = _adminService.SaveShippingStatus(newShippingModel);
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateShippingStatus")]
        public IActionResult UpdateShippingStatus(ShippingModel shippingStatusToUpdate)
        {
            var data = _adminService.UpdateShippingStatus(shippingStatusToUpdate);
            return Ok(data);
        }

        [HttpPost]
        [Route("DeleteShippingStatus")]
        public IActionResult DeleteShippingStatus(ShippingModel shippingStatusToDelete)
        {
            var data = _adminService.DeleteShippingStatus(shippingStatusToDelete);
            return Ok(data);
        }

        [HttpGet]
        [Route("UpdateShippingStatusForOrder")]
        public IActionResult UpdateShippingStatusForOrder(string order_number, string shippingText)
        {
            var data = _adminService.UpdateShippingStatusForOrder(order_number, shippingText);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetShippingStatusForOrder")]
        public IActionResult GetShippingStatusForOrder(string order_number)
        {
            var data = _adminService.GetShippingStatusForOrder(order_number);
            return Ok(data);
        }
    }
}
