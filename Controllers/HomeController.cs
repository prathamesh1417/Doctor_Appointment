using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Patient_DBContext d1;
        
       public IWebHostEnvironment env;

        public HomeController(ILogger<HomeController> logger, Patient_DBContext d1,IWebHostEnvironment env)
        {
            _logger = logger;
            this.d1 = d1;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LoginCredDum lr)
        {

            String folder = Path.Combine(env.WebRootPath, "images");

            String fname = lr.Image.FileName;

            String filepath = Path.Combine(folder, fname);

            lr.Image.CopyTo(new FileStream(filepath, FileMode.OpenOrCreate));

            LoginCredential l1 = new LoginCredential();
            l1.LoginId = lr.LoginId;
            l1.Username = lr.Username;
            l1.Email = lr.Email;
            l1.Password = lr.Password;
            l1.CPassword = lr.CPassword;
            l1.Image = fname;

            d1.LoginCredential.Add(l1);
            d1.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(LoginCredential lt)
        {
            
            var t = d1.LoginCredential.Where(h => h.Equals(lt.Username) && h.Equals(lt.Password));
            var t1 = d1.LoginCredential.FirstOrDefault(u => u.Username == lt.Username);
            if (t1 != null)
            {
                HttpContext.Session.SetString("utemp", t1.Username);
                return RedirectToAction("UserDash");
            }
            else
            {
                return RedirectToAction("Index");
            }
         
        }
        public IActionResult UserDash()
        {
            ViewData["o"] = HttpContext.Session.GetString("utemp");
            return View();
        }

        public IActionResult Display()
        {
            var b = d1.LoginCredential.ToList();
            return View(b);
        }
        public IActionResult Details(int id)
        {
            var e = d1.Book.Find(id);
            return View(e);
        }

        public IActionResult BookApp()
        {
            var doctorList = d1.Doct.Select(d => new { d.did, d.dname }).ToList();
            ViewBag.Doctors = doctorList;
            return View();
        }


        [HttpPost]
        public IActionResult BookApp(Booki h1)
        {
          
            var selectedDoctor = d1.Doct.FirstOrDefault(d => d.did == h1.did);

            if (selectedDoctor == null)
            {
                
                return BadRequest("Selected doctor does not exist.");
            }

          
            h1.doc = selectedDoctor;
            h1.did = selectedDoctor.did; 
            h1.DoctorName = selectedDoctor.dname; 

            d1.Book.Add(h1);
            d1.SaveChanges();

            return RedirectToAction("Index");
        }



      
        public IActionResult DispUser()
        {
            var y = d1.Book.ToList();
            return View(y);
        }

        public IActionResult DoctorReg()
        {
            return View();
        }
        [HttpPost]

        public IActionResult DoctorReg(doct g2)
        {
            if (g2.Cert == null || g2.Cert.Length == 0)
            {
                ModelState.AddModelError("Cert", "Certificate file is required.");
                return View(g2);
            }

            string folder = Path.Combine(env.WebRootPath, "Doct_Certificate");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string fileName = Path.GetFileName(g2.Cert.FileName);
            string filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                g2.Cert.CopyTo(stream); 
            }

     
            g2.Certi = fileName;

            d1.Doct.Add(g2);
            d1.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult Doctorlog(doct f7)
        {

            var t = d1.Doct.Where(h => h.Equals(f7.dname) && h.Equals(f7.dpass));
            var t1 = d1.Doct.FirstOrDefault(u => u.dname == f7.dname);
            if (t1 != null)
            {
                HttpContext.Session.SetString("temp", t1.dname);
                return RedirectToAction("AdminDash");
            }
            else
            {
                return RedirectToAction("DoctorReg");
            }
        }
        public IActionResult AdminDash()
        {

            ViewData["i"] = HttpContext.Session.GetString("temp");

            return View();
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();


            HttpContext.SignOutAsync();


            Response.Cookies.Delete(".AspNetCore.Identity.Application");

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
