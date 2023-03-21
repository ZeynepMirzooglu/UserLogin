using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using UserLogin.Models;
using Microsoft.EntityFrameworkCore;
using UserLogin.ViewModels;

namespace UserLogin.Controllers
{
    public class LoginController : Controller
    {
       
        private readonly LoginDbContext _context;

        public LoginController(LoginDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidTCKimlikNo(model.TcNo))
                {
                    var result= _context.UserLogins.Any(x => x.TcNo == model.TcNo && x.Password==model.Password);
                    if (result)
                    {
                        TempData["result"] = "Giriş Başarılı!";
                        return RedirectToAction("Success");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Hatalı şifre girdiniz.");
                        return View();
                    }
                    
                }
                else
                {
                    // TC Kimlik yanlış, hata mesajı gösterin.
                    ModelState.AddModelError("TcNo", "TC Kimlik Numarası Geçersiz");
                    return View();
                }
            }
            return View();

        }

        public IActionResult Success()
        {
            return View();
        }
       
        private bool IsValidTCKimlikNo(string tcKimlikNo)
        {
            if (tcKimlikNo.Length != 11)
            {
                return false;
            }

            long tcKimlikNoNumeric = 0;
            if (!long.TryParse(tcKimlikNo, out tcKimlikNoNumeric))
            {
                return false;
            }

            int[] tcKimlikNoDigits = tcKimlikNoNumeric.ToString().Select(x => int.Parse(x.ToString())).ToArray();

            if (tcKimlikNoDigits[0] == 0)
            {
                return false;
            }

            int totalOddDigits = tcKimlikNoDigits[0] + tcKimlikNoDigits[2] + tcKimlikNoDigits[4] + tcKimlikNoDigits[6] + tcKimlikNoDigits[8];
            int totalEvenDigits = tcKimlikNoDigits[1] + tcKimlikNoDigits[3] + tcKimlikNoDigits[5] + tcKimlikNoDigits[7];

            int digit10 = ((totalOddDigits * 7) - totalEvenDigits) % 10;
            int digit11 = (totalOddDigits + totalEvenDigits + tcKimlikNoDigits[9]) % 10;

            return tcKimlikNoDigits[9] == digit10 && tcKimlikNoDigits[10] == digit11;
        }
        private bool IsValidUser(string tcNo, string password)
        {
            var result = _context.UserLogins.Any(x => x.TcNo == tcNo && x.Password == password);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}



