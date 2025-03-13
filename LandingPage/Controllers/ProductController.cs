using LandingPage.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LandingPage.Controllers
{
    public class ProductController : Controller
    {
        Context Context = new Context();
        //private readonly IWebHostEnvironment _env;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult ShowALL()
        {
            List<Product> Products = Context.products.ToList();
            return View(Products);
        }
        public IActionResult add(Product product)
        {
            return View();
        }
        public IActionResult Save_Add(Product pro, IFormFile file)
        {

            if (pro.ARName != null)
            {

                string RootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(RootPath, @"");
                    var ext = Path.GetExtension(file.FileName);
                    using (var filestream = new FileStream(Path.Combine(upload, fileName + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    pro.img = @"" + fileName + ext;
                }

                Context.products.Add(pro);
                Context.SaveChanges();

                return RedirectToAction("ShowALL");
            }
            return View("add", pro);

        }
        public IActionResult Details(int id)
        {
            Product Pro = Context.products.FirstOrDefault(d=>d.Id == id);
            return View("pro_details", Pro);

        }
        public IActionResult Edit(int id)
        {
            Product oldPro = Context.products.FirstOrDefault(d => d.Id == id);
            Product newPro = new Product();
            newPro.Id = oldPro.Id;
            newPro.ARName = oldPro.ARName;
            newPro.ENName = oldPro.ENName;
            newPro.img = oldPro.img;
            newPro.ARDescription = oldPro.ARDescription;
            newPro.ENDescription = oldPro.ENDescription;
            return View("edit", newPro);
        }
        public IActionResult Save_edit(Product pro, int id, IFormFile file)
        {
            if (pro.ARName != null)
            {
                string RootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(RootPath, @"");
                    var ext = Path.GetExtension(file.FileName);
                    using (var filestream = new FileStream(Path.Combine(upload, fileName + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    pro.img = @"" + fileName + ext;
                }
                Product newPro = Context.products.FirstOrDefault(d => d.Id == id);
                
                newPro.ARName = pro.ARName;
                newPro.ENName = pro.ENName;
                
                newPro.ARDescription = pro.ARDescription;
                newPro.ENDescription = pro.ENDescription;
                Context.SaveChanges();
                return RedirectToAction("ShowALL");

            }
            return View("edit",pro);
        }
        public ActionResult Delete(int id)
        {
            Product pro = Context.products.FirstOrDefault(p=>p.Id == id);
            Context.products.Remove(pro);
            Context.SaveChanges();
            List<Product> Products = Context.products.ToList();
            return View("ShowALL", Products);
        }

    }
}
