using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET_QR.Data;
using NET_QR.Models;
using NET_QR.Models.Interface;

namespace NET_QR.Models.Repositry
{
    public class UserRepositry : InterfaceUser
    {
        NET_QRContext _context  ;

        public UserRepositry(NET_QRContext contxt)
        {
            _context = contxt;

        }

        public async Task<bool> createuser(User user)
        {
            try
            {
                await (_context.User.AddAsync(user));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Ifuserexist(User user)
        {

            bool exist= (_context.User?.Any(e => e.email == user.email && e.pass == user.pass)).GetValueOrDefault();
            return exist;

        }

        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    

        public bool UserExistByEmail(string s)
        {
            return (_context.User?.Any(e => e.email == s)).GetValueOrDefault();
        }
    }
}
