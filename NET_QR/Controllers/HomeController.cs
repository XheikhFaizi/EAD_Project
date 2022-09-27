using Microsoft.AspNetCore.Mvc;
using NET_QR.Models;
using System.Diagnostics;
using IronBarCode;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using NET_QR.Models.Repositry;
using NET_QR.Models.Interface;
using NET_QR.Data;
using System.Net.Http.Headers;

namespace NET_QR.Controllers
{
    public class HomeController : Controller
    {
        private readonly NET_QRContext _context;
        private IWebHostEnvironment Environment;
        //private readonly InterfaceUser userrepo;
        private readonly InterfaceUserQrRelation userqrrepo;

        public HomeController(InterfaceUserQrRelation userop ,IWebHostEnvironment _environment, NET_QRContext context)
        {
            userqrrepo = userop;
            _context = context;
            Environment = _environment;
        
        }
    
        List<User> userslist = new List<User>();


        //////////////*********************************************************************

       
        public ActionResult factorycreateurlqr(IFormFile file , string URL ,string Color)
        {
            string wwwPath = this.Environment.WebRootPath;

            var userid = this.HttpContext.Session.GetString("User");

            int hh = int.Parse(userid);

            string mail = _context.User.Where(x => x.ID == hh).Select(x => x.email).FirstOrDefault();


            string userpath1 = Path.Combine(this.Environment.WebRootPath, "Users");
            string userpath2 = Path.Combine(userpath1, mail);

            GeneratedBarcode barcode = null;

            if (file != null)
            {
                var filesourceName = file.FileName.Trim('"');

                string userpath3 = Path.Combine(userpath2, "Logos");

                if (!Directory.Exists(userpath3))
                {
                    Directory.CreateDirectory(userpath3);
                }
                var pathWithFileName = Path.Combine(userpath3, filesourceName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);

                    stream.Close();

                }



                string filePath = pathWithFileName.ToString();
               barcode = QRCodeWriter.CreateQrCodeWithLogo(URL, filePath, 350);

      


            }
            else
            {
                barcode = QRCodeWriter.CreateQrCode(URL, 350);
            }


            barcode.SetMargins(10);

            //////////ADDING COLOR
            string hex = Color;
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            barcode.ChangeBarCodeColor(_color);

            string mypath3 = Path.Combine(userpath2, "Qrs");
            string name = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".png";
            string filePaths = Path.Combine(mypath3, name);
            barcode.SaveAsPng(filePaths);
            string fileName = Path.GetFileName(filePaths);


            UserQrRelation qrRelation = new UserQrRelation();
            qrRelation.userid = hh;
            qrRelation.name = "Url Qr";
            string imagepath = "~/Users/" + mail + "/Qrs/" + fileName;

            Console.WriteLine(imagepath);

            qrRelation.imagepath=imagepath;

            userqrrepo.addrelation(qrRelation);

            ViewBag.Qr = "/Users/" + mail + "/Qrs/" + name;

            return ViewComponent("Qrshow");

        }

        public ActionResult factorycreatetextqr(IFormFile file, string TEXT, string Color)
        {
            string wwwPath = this.Environment.WebRootPath;

            var userid = this.HttpContext.Session.GetString("User");

            int hh = int.Parse(userid);

            string mail = _context.User.Where(x => x.ID == hh).Select(x => x.email).FirstOrDefault();


            string userpath1 = Path.Combine(this.Environment.WebRootPath, "Users");
            string userpath2 = Path.Combine(userpath1, mail);

            GeneratedBarcode barcode = null;

            if (file != null)
            {
                var filesourceName = file.FileName.Trim('"');

                string userpath3 = Path.Combine(userpath2, "Logos");

                if (!Directory.Exists(userpath3))
                {
                    Directory.CreateDirectory(userpath3);
                }
                var pathWithFileName = Path.Combine(userpath3, filesourceName);


                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();

                }


                string filePath = pathWithFileName.ToString();
                barcode = QRCodeWriter.CreateQrCodeWithLogo(TEXT, filePath, 350);




            }
            else
            {
                barcode = QRCodeWriter.CreateQrCode(TEXT, 350);
            }


            barcode.SetMargins(10);

            //////////ADDING COLOR
            string hex = Color;
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            barcode.ChangeBarCodeColor(_color);

            string mypath3 = Path.Combine(userpath2, "Qrs");
            string name = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".png";
            string filePaths = Path.Combine(mypath3, name);
            barcode.SaveAsPng(filePaths);
            string fileName = Path.GetFileName(filePaths);


            UserQrRelation qrRelation = new UserQrRelation();
            qrRelation.userid = hh;
            qrRelation.name = "TEXT Qr";
            string imagepath = "~/Users/" + mail + "/Qrs/" + fileName;

            Console.WriteLine(imagepath);

            qrRelation.imagepath = imagepath;

            userqrrepo.addrelation(qrRelation);

            ViewBag.Qr = "/Users/" + mail + "/Qrs/" + name;

            return ViewComponent("Qrshow");

        }


        public ActionResult factorycreatewifiqr(IFormFile file, string network, string Color,string password,string type)
        {
            string wwwPath = this.Environment.WebRootPath;

            var userid = this.HttpContext.Session.GetString("User");


            string line = "WIFI:S:" + network + ";T:" + type + ";P:" + password + ";H:false;;";

            int hh = int.Parse(userid);

            string mail = _context.User.Where(x => x.ID == hh).Select(x => x.email).FirstOrDefault();


            string userpath1 = Path.Combine(this.Environment.WebRootPath, "Users");
            string userpath2 = Path.Combine(userpath1, mail);

            GeneratedBarcode barcode = null;

            if (file != null)
            {
                var filesourceName = file.FileName.Trim('"');

                string userpath3 = Path.Combine(userpath2, "Logos");

                if (!Directory.Exists(userpath3))
                {
                    Directory.CreateDirectory(userpath3);
                }
                var pathWithFileName = Path.Combine(userpath3, filesourceName);


                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();

                }


                string filePath = pathWithFileName.ToString();
                barcode = QRCodeWriter.CreateQrCodeWithLogo(line, filePath, 350);




            }
            else
            {
                barcode = QRCodeWriter.CreateQrCode(line , 350);
            }


            barcode.SetMargins(10);

            //////////ADDING COLOR
            string hex = Color;
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            barcode.ChangeBarCodeColor(_color);

            string mypath3 = Path.Combine(userpath2, "Qrs");
            string name = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".png";
            string filePaths = Path.Combine(mypath3, name);
            barcode.SaveAsPng(filePaths);
            string fileName = Path.GetFileName(filePaths);


            UserQrRelation qrRelation = new UserQrRelation();
            qrRelation.userid = hh;
            qrRelation.name = "Wifi Qr";
            string imagepath = "~/Users/" + mail + "/Qrs/" + fileName;

            Console.WriteLine(imagepath);

            qrRelation.imagepath = imagepath;

            userqrrepo.addrelation(qrRelation);

            ViewBag.Qr = "/Users/" + mail + "/Qrs/" + name;

            return ViewComponent("Qrshow");

        }


        public ActionResult factorycreatebitcoinqr(IFormFile file, string coin, string Color, string account, string amount)
        {
            string wwwPath = this.Environment.WebRootPath;

            var userid = this.HttpContext.Session.GetString("User");


            string line = coin + ":" + account + "?amount=" + amount;

            int hh = int.Parse(userid);

            string mail = _context.User.Where(x => x.ID == hh).Select(x => x.email).FirstOrDefault();


            string userpath1 = Path.Combine(this.Environment.WebRootPath, "Users");
            string userpath2 = Path.Combine(userpath1, mail);

            GeneratedBarcode barcode = null;

            if (file != null)
            {
                var filesourceName = file.FileName.Trim('"');

                string userpath3 = Path.Combine(userpath2, "Logos");

                if (!Directory.Exists(userpath3))
                {
                    Directory.CreateDirectory(userpath3);
                }
                var pathWithFileName = Path.Combine(userpath3, filesourceName);


                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();

                }


                string filePath = pathWithFileName.ToString();
                barcode = QRCodeWriter.CreateQrCodeWithLogo(line, filePath, 350);




            }
            else
            {
                barcode = QRCodeWriter.CreateQrCode(line, 350);
            }


            barcode.SetMargins(10);

            //////////ADDING COLOR
            string hex = Color;
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            barcode.ChangeBarCodeColor(_color);

            string mypath3 = Path.Combine(userpath2, "Qrs");
            string name = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".png";
            string filePaths = Path.Combine(mypath3, name);
            barcode.SaveAsPng(filePaths);
            string fileName = Path.GetFileName(filePaths);


            UserQrRelation qrRelation = new UserQrRelation();
            qrRelation.userid = hh;
            qrRelation.name = "Crypto Qr";
            string imagepath = "~/Users/" + mail + "/Qrs/" + fileName;

            Console.WriteLine(imagepath);

            qrRelation.imagepath = imagepath;

            userqrrepo.addrelation(qrRelation);

            ViewBag.Qr = "/Users/" + mail + "/Qrs/" + name;

            return ViewComponent("Qrshow");

        }



        public ActionResult factorycreatesmsqr(IFormFile file, string num, string Color, string sms)
        {
            string wwwPath = this.Environment.WebRootPath;

            var userid = this.HttpContext.Session.GetString("User");


            string line = "SMSTO:" + num + ":" + sms;

            int hh = int.Parse(userid);

            string mail = _context.User.Where(x => x.ID == hh).Select(x => x.email).FirstOrDefault();


            string userpath1 = Path.Combine(this.Environment.WebRootPath, "Users");
            string userpath2 = Path.Combine(userpath1, mail);

            GeneratedBarcode barcode = null;

            if (file != null)
            {
                var filesourceName = file.FileName.Trim('"');

                string userpath3 = Path.Combine(userpath2, "Logos");

                if (!Directory.Exists(userpath3))
                {
                    Directory.CreateDirectory(userpath3);
                }
                var pathWithFileName = Path.Combine(userpath3, filesourceName);


                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();

                }


                string filePath = pathWithFileName.ToString();
                barcode = QRCodeWriter.CreateQrCodeWithLogo(line, filePath, 350);


            }
            else
            {
                barcode = QRCodeWriter.CreateQrCode(line, 350);
            }


            barcode.SetMargins(10);

            //////////ADDING COLOR
            string hex = Color;
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            barcode.ChangeBarCodeColor(_color);

            string mypath3 = Path.Combine(userpath2, "Qrs");
            string name = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".png";
            string filePaths = Path.Combine(mypath3, name);
            barcode.SaveAsPng(filePaths);
            string fileName = Path.GetFileName(filePaths);


            UserQrRelation qrRelation = new UserQrRelation();
            qrRelation.userid = hh;
            qrRelation.name = "Sms Qr";
            string imagepath = "~/Users/" + mail + "/Qrs/" + fileName;

            Console.WriteLine(imagepath);

            qrRelation.imagepath = imagepath;

            userqrrepo.addrelation(qrRelation);

            ViewBag.Qr = "/Users/" + mail + "/Qrs/" + name;

            return ViewComponent("Qrshow");

        }


        public ActionResult factorycreateemailqr(IFormFile file, string email, string Color, string subject,string body)
        {
            string wwwPath = this.Environment.WebRootPath;

            var userid = this.HttpContext.Session.GetString("User");


            string line = "MATMSG:TO:" + email + ";SUB:" + subject + ";BODY:" + body + ";;";

            int hh = int.Parse(userid);

            string mail = _context.User.Where(x => x.ID == hh).Select(x => x.email).FirstOrDefault();


            string userpath1 = Path.Combine(this.Environment.WebRootPath, "Users");
            string userpath2 = Path.Combine(userpath1, mail);

            GeneratedBarcode barcode = null;

            if (file != null)
            {
                var filesourceName = file.FileName.Trim('"');

                string userpath3 = Path.Combine(userpath2, "Logos");

                if (!Directory.Exists(userpath3))
                {
                    Directory.CreateDirectory(userpath3);
                }
                var pathWithFileName = Path.Combine(userpath3, filesourceName);


                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();

                }


                string filePath = pathWithFileName.ToString();
                barcode = QRCodeWriter.CreateQrCodeWithLogo(line, filePath, 350);




            }
            else
            {
                barcode = QRCodeWriter.CreateQrCode(line, 350);
            }


            barcode.SetMargins(10);

            //////////ADDING COLOR
            string hex = Color;
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            barcode.ChangeBarCodeColor(_color);

            string mypath3 = Path.Combine(userpath2, "Qrs");
            string name = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".png";
            string filePaths = Path.Combine(mypath3, name);
            barcode.SaveAsPng(filePaths);
            string fileName = Path.GetFileName(filePaths);


            UserQrRelation qrRelation = new UserQrRelation();
            qrRelation.userid = hh;
            qrRelation.name = "Email Qr";
            string imagepath = "~/Users/" + mail + "/Qrs/" + fileName;

            Console.WriteLine(imagepath);

            qrRelation.imagepath = imagepath;

            userqrrepo.addrelation(qrRelation);

            ViewBag.Qr = "/Users/" + mail + "/Qrs/" + name;

            return ViewComponent("Qrshow");

        }













        //////////////*********************************************************************
        public IActionResult AjaxUpload(List<IFormFile> files)
        { 
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                    ViewBag.FileName = fileName;
                }
            }
            return Json(true);
        }

        public ActionResult createbitcoinqr(GenerateQr data)
        {
            string wwwPath = this.Environment.WebRootPath;



            string line = data.coin + ":" + data.account + "?amount=" + data.amount;

            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(line, 300);


            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);

            string path = Path.Combine(this.Environment.WebRootPath, "GeneratedQrs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "CryptoQrCode.png");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);

            //string imageUrl = $ "{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            //ViewBag.QrCodeUri = imageUrl;

            ViewBag.Qr = "/GeneratedQrs/CryptoQrCode.png";

            return ViewComponent("Qrshow");

        }







        public ActionResult createemailqr(GenerateQr data)
        {
            string wwwPath = this.Environment.WebRootPath;



            string line = "MATMSG:TO:" + data.mail + ";SUB:" + data.subject + ";BODY:" + data.body + ";;";
          
            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(line, 300);


            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);

            string path = Path.Combine(this.Environment.WebRootPath, "GeneratedQrs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "EmailQrCode.png");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);

            //string imageUrl = $ "{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            //ViewBag.QrCodeUri = imageUrl;

            ViewBag.Qr = "/GeneratedQrs/EmailQrCode.png";

            return ViewComponent("Qrshow");

        }











        public ActionResult createsmsqr(GenerateQr data)
        {
            string wwwPath = this.Environment.WebRootPath;

            Int64 numb = Int64.Parse(data.num);

            string line ="SMSTO:" + numb + ":" + data.sms;
            Console.WriteLine(line);

            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(line, 300);


            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);

            string path = Path.Combine(this.Environment.WebRootPath, "GeneratedQrs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "SmsQrCode.png");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);

            //string imageUrl = $ "{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            //ViewBag.QrCodeUri = imageUrl;

            ViewBag.Qr = "/GeneratedQrs/SmsQrCode.png";

            return ViewComponent("Qrshow");

        }





        public ActionResult createwifiqr(GenerateQr data)
        {
            string wwwPath = this.Environment.WebRootPath;

            string line = "WIFI:S:" + data.network + ";T:" + data.type + ";P:" + data.password + ";H:false;;";
            Console.WriteLine(line);

            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(line,300);

            
            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);

            string path = Path.Combine(this.Environment.WebRootPath, "GeneratedQrs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "WifiQrCode.png");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);

            //string imageUrl = $ "{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            //ViewBag.QrCodeUri = imageUrl;

            ViewBag.Qr = "/GeneratedQrs/WifiQrCode.png";

            return ViewComponent("Qrshow");

        }


        public ActionResult createtextqr(GenerateQr data)
        {
            string wwwPath = this.Environment.WebRootPath;

            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(data.TEXT, 300);

            //barcode.AddBarcodeValueTextBelowBarcode();
            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);

            string path = Path.Combine(this.Environment.WebRootPath, "GeneratedQrs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "TextQrCode.png");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);

            //string imageUrl = $ "{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            //ViewBag.QrCodeUri = imageUrl;

            ViewBag.Qr = "/GeneratedQrs/TextQrCode.png";

            return ViewComponent("Qrshow");

        }

        public ActionResult createurlqr(GenerateQr data)
        {
            string wwwPath = this.Environment.WebRootPath;

            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(data.URL, 300);

            //barcode.AddBarcodeValueTextBelowBarcode();
            // Styling a QR code and adding annotation text
            barcode.SetMargins(10);
            //string hex = "#FF3FF3";
            //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            //barcode.ChangeBarCodeColor(_color);

            //Console.WriteLine(_color);

            string path = Path.Combine(this.Environment.WebRootPath, "GeneratedQrs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "UrlQrCode.png");
            barcode.SaveAsPng(filePath);
            string fileName = Path.GetFileName(filePath);

            //string imageUrl = $ "{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
            //ViewBag.QrCodeUri = imageUrl;

            ViewBag.Qr = "/GeneratedQrs/UrlQrCode.png";

            return ViewComponent("Qrshow");

        }

        //////////////*********************************************************************




        //[HttpPost]
        //public async Task<ActionResult> ImageUploading(IFormFile file)
        //{
        //    try
        //    {
        //        if (await userrepo.UploadFile(file))
        //        {
        //            ViewBag.Message = "File Upload Successful";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "File Upload Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log ex
        //        ViewBag.Message = "File Upload Failed";
        //    }
        //    return View();
        //}

        [HttpPost]
        public ViewResult factory(User gg)
        {
            return View();

        }

        public ViewResult Null()
        {
            return View();

        }
        public ViewResult About()
        {
            return View();

        }

        public ViewResult Services()
        {
            return View();

        }

        public ViewResult Contact ()
        {
            return View();

        }

        public ViewResult factory()
        {
            return View();

        }

        public ViewResult customizeqr()
        {

            var userid = this.HttpContext.Session.GetString("User");
            int hh = 0;
            if (userid !=null)
            {

                hh= int.Parse(userid);
            }
            return View(userqrrepo.getuserrelation(hh));

        }


    }
}