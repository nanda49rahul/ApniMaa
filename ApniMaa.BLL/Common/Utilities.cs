using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using ApniMaa.BLL.Models;
using ApniMaa.DAL;
using System.Security.Cryptography;
using System.Configuration;

namespace ApniMaa.BLL.Common
{
    public class UtilitiesHelp
    {
        public static List<SelectListItem> EnumToList(Type en, bool isDesc = true)
        {
            var itemValues = en.GetEnumValues();
            var list = new List<SelectListItem>();

            foreach (var value in itemValues)
            {
                var name = en.GetEnumName(value);
                var member = en.GetMember(name).Single();

                if (isDesc)
                {
                    var desc = ((DescriptionAttribute)member.GetCustomAttributes(typeof(DescriptionAttribute), false).Single()).Description;
                    list.Add(new SelectListItem { Text = desc, Value = ((int)value).ToString() });
                }
                else
                {
                    list.Add(new SelectListItem { Text = value.ToString(), Value = ((int)value).ToString() });
                }
            }
            return list;
        }


        public static string GetFileBasePath(string fileName)
        {
            var path = HostingEnvironment.MapPath(fileName);
            return path;
        }

        public static string GetFilePath(string folderName, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var path = ("/ApplicationImages/" + folderName + "/" + fileName);
            return path;
        }

        public static string SaveMovePostedFile(string folderName, HttpPostedFileBase fileData, int id)
        {
            var UploadPath = HostingEnvironment.MapPath("~/Content/temp");
            bool exists = System.IO.Directory.Exists(UploadPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }

            HttpPostedFileBase file = fileData;
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/temp/");
            file.SaveAs(path + file.FileName);

            path = path + file.FileName;
            path = MovePolicyFile(folderName, path, id);

            return path;
        }

        public static string SavePostedFile(string FolderName, HttpPostedFileBase fileData)
        {
            var FileDataContent = fileData;
            var UploadPath = HostingEnvironment.MapPath("~/ApplicationImages/" + FolderName + "/");
            bool exists = System.IO.Directory.Exists(UploadPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }
            var FilePath = Path.Combine(UploadPath, FileDataContent.FileName);
            var extension = Path.GetExtension(FilePath);
            Guid FileId = Guid.NewGuid();
            var FileCreated = FileId + extension;
            var NewFile = UploadPath + FileCreated;
            FileDataContent.SaveAs(NewFile);
            return FileCreated;
        }

        public static string GenerateOTP()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }

        public static double HaversineDistance(LatLng pos1, LatLng pos2)
        {
            double R =  6371;
            var lat = (pos2.Latitude - pos1.Latitude).ToRadians();
            var lng = (pos2.Longitude - pos1.Longitude).ToRadians();
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                          Math.Cos(pos1.Latitude.ToRadians()) * Math.Cos(pos2.Latitude.ToRadians()) *
                          Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            return R * h2;
        }

        public static string MovePolicyFile(string FolderName, string srcFilePath, int FirmID)
        {

            var UploadPath = HostingEnvironment.MapPath("~/Documents/" + FolderName + "/" + FirmID + "/");
            bool exists = System.IO.Directory.Exists(UploadPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }


            Guid FileId = Guid.NewGuid();
            var FileCreated = FileId + ".pdf";
            var NewFile = UploadPath + FileCreated;
            File.Move(srcFilePath, NewFile);
            return FileCreated;
        }
        public static string MoveImportFile(string FolderName, string srcFilePath)
        {

            var UploadPath = HostingEnvironment.MapPath("~/Documents/" + FolderName + "/");
            bool exists = System.IO.Directory.Exists(UploadPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }


            Guid FileId = Guid.NewGuid();
            var FileCreated = FileId + ".xlsx";
            var NewFile = UploadPath + FileCreated;
            File.Move(srcFilePath, NewFile);
            return FileCreated;
        }
        public static void DeletePostedFile(string FileName, string FolderName, int firmID)
        {
            string Path = HostingEnvironment.MapPath("~/Documents/" + FolderName + "/" + firmID + "/") + FileName;
            FileInfo file = new FileInfo(Path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        public static string GenerateApplicationNo()
        {
            using (ApniMaaDBEntities Context = new ApniMaaDBEntities())
            {
                var appno = "0001";
                var prev = Context.MotherTbls.Max(p => p.ApplicationNo);
                if(prev!=null)
                {
                    appno = (Convert.ToInt32(prev) + 1).ToString("0000");
                }
                return appno;
            }
        }

        public static String EnumToDecription(Type en, int id)
        {
            var itemValues = en.GetEnumValues();
            var list = new List<SelectListItem>();
            var selectedEnum = itemValues.GetValue(id - 1);
            var name = en.GetEnumName(selectedEnum);
            var member = en.GetMember(name).Single();
            string desc = ((DescriptionAttribute)member.GetCustomAttributes(typeof(DescriptionAttribute), false).Single()).Description;
            return desc;
        }

        public static string TruncateAtWord(string input, int length)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string s = input;
                string output = string.Empty;
                Regex regex = new Regex("\\<[^\\>]*\\>");
                output = regex.Replace(s, String.Empty);
                if (output == null || output.Length < length)
                    return output;
                int iNextSpace = output.LastIndexOf(" ", length, StringComparison.Ordinal);
                return string.Format("{0}...", output.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
            }
            return input;
        }

        public static bool IsImage(string path)
        {
            try
            {
                var file = HttpContext.Current.Server.MapPath(path);
                System.Drawing.Image imgObj = System.Drawing.Image.FromFile(file);
                if (imgObj.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                    imgObj.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                    imgObj.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid ||
                    imgObj.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid ||
                    imgObj.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                { return true; }
                else
                { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GenerateLiscRefID(string Firm, int id)
        {
            var prefix = "ApniMaa";
            var random = GeneratePassword(6);
            string str = "";
            foreach (string s in Firm.Split(' '))
            {
                if (!string.IsNullOrEmpty(s))
                {
                    str += s.Substring(0, 1);
                }
            }
            var count = Convert.ToString(id).Length;
            string last = "";
            if (count < 2)
            {
                last = id.ToString("00");
            }
            else
            {
                last = id.ToString();
            }
            var result = prefix + random + str + last;
            return result;
        }


        #region Password Encryption and Decryption
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra security</param>
        /// <returns></returns>
        public static string EncryptPassword(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            string key = "Syed Moshiur Murshed";
            //(string)settingsReader.GetValue("SecurityKey",
            //                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string DecryptPassword(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            //  string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            string key = "Syed Moshiur Murshed";
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion



        public static string ReadFileText(string file, HttpServerUtility context = null)
        {
            HostingEnvironment.MapPath(file);
            if (HttpContext.Current != null)
            {
                return File.ReadAllText(HttpContext.Current.Server.MapPath(file));
            }
            else
            {
                return File.ReadAllText(HostingEnvironment.MapPath(file));
            }
        }

        private static Random random = new Random();
        public static string GeneratePassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateRandomNo(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static List<SelectListItem> YearsOfCall(int flag)
        {
            var list = new List<SelectListItem>();
            var maxOffset = 100;
            var thisYear = DateTime.Now.Year; ;

            if (flag > 0)
            {
                for (var i = 0; i <= 100; i++)
                {
                    var year = thisYear - 68 + i;
                    list.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString() });
                }
            }
            else
            {
                for (var i = 0; i <= maxOffset; i++)
                {
                    var year = thisYear - 68 + i;
                    list.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString() });
                }
            }
            return list;
        }

        public static void WriteInFile(string filePath, string msg)
        {
            StreamWriter str = new StreamWriter(filePath, true);
            str.WriteLine("" + DateTime.Now.ToString());
            str.WriteLine(msg);
            str.WriteLine("");
            str.Close();
        }

        public static void Log(object msg)
        {
            var logsFolder = HttpContext.Current.Server.MapPath("~/Logs");
            if (!Directory.Exists(logsFolder)) Directory.CreateDirectory(logsFolder);
            var currentDate = DateTime.Now.ToString("MM-dd-yyyy");
            var filePath = string.Format("{0}/{1}.txt", logsFolder, currentDate);
            if (!File.Exists(filePath)) File.Create(filePath).Close();
            UtilitiesHelp.WriteInFile(filePath, JsonConvert.SerializeObject(msg, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        public static string GetHtmlCertificateViewName(int certificateType, string name)
        {
            //if (isGenericCertificate)
            //{
            //    return "/Views/Shared/Certificates/_generic.cshtml";
            //}
            //else
            //{


            //return "/Views/Shared/Certificates/_vaughn.cshtml";

            var viewName = EnumToDecription(typeof(CertificatesViewTypes), certificateType);

            return "/Views/Shared/Certificates/" + viewName;
            //return "/Views/Shared/Certificates/_brampton.cshtml";


            //}
        }

        public static bool SaveBytesData(string fileName, byte[] Data)
        {
            BinaryWriter Writer = null;
            string name = fileName;

            try
            {
                var path = HostingEnvironment.MapPath(fileName);
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(path));

                // Writer raw data                
                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
            }
            catch (Exception ex)
            {
                //...
                return false;
            }

            return true;
        }

        public static string CreateEmptyFile(string folderName, string fileName, int id)
        {
            var UploadPath = HostingEnvironment.MapPath("~/Documents/" + folderName + "/" + id + "/");
            bool exists = System.IO.Directory.Exists(UploadPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }


            if (string.IsNullOrEmpty(fileName))
                return null;

            var path = ("/Documents/" + folderName + "/" + id + "/" + fileName);

            if (!File.Exists(path))
            {
                System.IO.StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(HostingEnvironment.MapPath(path), true);
                    sw.WriteLine("");
                }
                catch { }
                finally { sw.Close(); }
            }

            return path;
        }

        public static List<SelectListItem> GetMonthsList()
        {
            return DateTimeFormatInfo
                   .InvariantInfo
                   .MonthNames
                   .Select((monthName, index) => new SelectListItem
                   {
                       Value = (index + 1).ToString(),
                       Text = monthName
                   }).ToList();

        }


        public static List<SelectListItem> GetYearsList()
        {
            return Enumerable.Range(1996, (DateTime.Now.Year - 1995)).Reverse().Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();

        }

        public static string ToMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }

    }
    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LatLng()
        {
        }

        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }
    public static class NumericExtensions
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }



}
