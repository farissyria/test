using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.IRepository;
using test.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace test.Controllers
{
    public class ItemsController : Controller
    {
        private   readonly Repository<Item> _repository;
        private readonly IHostingEnvironment _host;

        public ItemsController(Repository<Item> repository, IHostingEnvironment hosta)
        {
            _repository = repository;
            _host = hosta;
           
        }


        public IActionResult find(Item item,int id)
        {
            _repository.edito(item, id);
            return RedirectToAction("Index", "Items");
        }

        public IActionResult Index()
        {
           IEnumerable<Item>listitem=_repository.listo().ToList();
            return View(listitem);
        }
        //new 
        [Authorize]
        public IActionResult New() 
        {

            return View();
        }

        [HttpPost]
        public IActionResult New(Item item)
        {
            
            string filename = string.Empty;
            if(item.ClientFile !=null  )
            {
                string mypath = Path.Combine(_host.WebRootPath, "images");
                filename = item.ClientFile.FileName;
                string fullpath = Path.Combine(mypath, filename);
                item.ClientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                item.ImagePath = filename;

            }
           _repository.addo(item);
            return RedirectToAction("Index");
        }
        //update
        public IActionResult Update(int id)
        {
           var r= _repository.findo(id);

            return View(r);
        }
        public IActionResult Details(int id)
        {
            var r = _repository.findo(id);

            return View(r);
        }
    


        [HttpPost]
        public IActionResult Update(Item item,int id)
        {
            string filename = string.Empty;
            if (item.ClientFile != null)
            {
                string mypath = Path.Combine(_host.WebRootPath, "images");
                filename = item.ClientFile.FileName;
                string fullpath = Path.Combine(mypath, filename);
                item.ClientFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                item.ImagePath = filename;

            }

            _repository.edito(item,id);
            //_repository.edito(id);
            return RedirectToAction("Index","Items");
        }

        public IActionResult Delete( int id)
        {
            var r = _repository.findo(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult Delete(Item item,int id)
        {
            _repository.removeo(item, id);

            return RedirectToAction("Index", "Items");
        }
    }
}
