
using Microsoft.AspNetCore.Mvc;
using TheWag.Models;
using TheWag.Api.WagDB.EF;

using AutoMapper;


namespace TheWag.Api.WagDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly WagDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(WagDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetProducts")]
        public IList<ProductDTO> Index()
        {
            var products = _context.Products.ToArray();

            var result = _mapper.ProjectTo<ProductDTO>(_context.Products).ToList();

            return result;

            //return _context.GetProducts();
            //return new Product[]
            //{
            //    new Product
            //    {
            //        Id = 1,
            //        URL = "https://www.google.com",
            //        Description = "Description 1",
            //        Price = 10.00m,
            //        Stock = 10
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        URL = "Product 2",
            //        Description = "Description 2",
            //        Price = 20.00m,
            //        Stock = 20
            //    }
            //};

        }

        //// GET: ProductController/Details/5
        //public IEnumerable<Product> Details(int id)
        //{
        //    return null;
        //}

        // GET: ProductController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ProductController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ProductController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ProductController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ProductController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
