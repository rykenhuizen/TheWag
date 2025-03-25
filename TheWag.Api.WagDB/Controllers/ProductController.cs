
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

        [HttpGet]
        public IList<ProductDTO> Index()
        {
            var result = _mapper.ProjectTo<ProductDTO>(_context.Products).ToList();

            return result;

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

        // POST: ProductController/Create
        [HttpPost]
        public IActionResult Create([FromBody]ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = _mapper.Map<Product>(product);
            var r = _context.Products.Add(_mapper.Map<Product>(p));
            _context.SaveChanges();
            //return CreatedAtAction("GetProduct", new { Id = product.Id }, product); 
            return Ok();

        }

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
