using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using NET_QR.Data;
using NET_QR.Models;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using NET_QR.Models.Interface;

namespace NET_QR.Controllers
{
    public class UsersController : Controller
    {
        private readonly NET_QRContext _context;
        private readonly InterfaceUser userrepo;

        public UsersController(NET_QRContext context, InterfaceUser userrepot)
        {
            _context = context;
            userrepo = userrepot;
        }


        ////////// LOGIN GET
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        ////////// SIGNUP GET
        [HttpGet]
        public ActionResult signup()
        {
            return View();
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.ToListAsync()) :
                          Problem("Entity set 'NET_QRContext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,username,email,pass,confpass")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,username,email,pass,confpass")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'NET_QRContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult login(User user)
        {
            string key = "user";
            string value = "I am";

            //if (ModelState.IsValid)
            //{
                bool isUserVerified = userrepo.Ifuserexist(user);

                Console.WriteLine(isUserVerified);
                if (isUserVerified)
                {
                
                


                    CookieOptions ck = new CookieOptions();
                    //////ck.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append(key, value, ck);

                    return RedirectToAction("Null", "Home");
                }
            //}
            //else
            //{
            //    ViewBag.Message = "Sorry! You entered wrong credentials";

            //}

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> signup(User user)
        {
            if (ModelState.IsValid)
            {
                bool isUserVerified = userrepo.UserExistByEmail(user.email);
                if (isUserVerified)
                {
                    ViewBag.Message = "Sorry! This email is already registered";
                    return View("signup");
                }
                
                userrepo.createuser(user);

                return RedirectToAction("login", "users");
            }
            return View();
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
