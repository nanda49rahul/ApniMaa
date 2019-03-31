using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using ApniMaa.BLL.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace ApniMaa.BLL.Helpers
{
    public static class Extensions
    {
        /// <summary>
        /// Get Logged in user details from formauthentication
        /// </summary>
        /// <param name="isAdminSection"></param>
        /// <returns></returns>
        public static UserInfo GetCurrentUser(bool isAdminSection = true)
        {
            var user = new UserInfo();
            HttpCookie auth_cookie = HttpContext.Current.Request.Cookies[isAdminSection ? Cookies.AdminAuthorizationCookie : Cookies.AuthorizationCookie];
            if (auth_cookie != null)
            {
                var auth_ticket = FormsAuthentication.Decrypt(auth_cookie.Value);
                user = new JavaScriptSerializer().Deserialize<UserInfo>(auth_ticket.UserData);
            }
            return user;
        }


        public static byte[] GetPDF(string html, int document)
        {
            StringReader sr = new StringReader(html.ToString());
            Byte[] bytes;
            Document pdfDoc = new Document();
            pdfDoc.AddAuthor("ApniMaa");
            pdfDoc.AddCreationDate();
            pdfDoc.AddCreator("ApniMaa");



            if (document == (int)DocumentType.PolicyDeclaration)
            {
                pdfDoc = new Document(PageSize.LETTER, 20f, 20f, 15f, 15f);
            }
            else if (document == (int)DocumentType.AnnualReniew)
            {
                pdfDoc = new Document(PageSize.LETTER, 60f, 20f, 40f, 0f);

            }
            else if (document == (int)DocumentType.Policy)
            {
                pdfDoc = new Document(PageSize.LETTER, 55f, 55f, 30f, 10f);
            }
            else if (document == (int)DocumentType.Schedule)
            {
                pdfDoc = new Document(PageSize.LETTER, 50f, 50f, 35f, 10f);
            }
            else if (document == (int)DocumentType.Endorsement)
            {
                pdfDoc = new Document(PageSize.LETTER, 70f, 70f, 40f, 10f);
            }
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);


            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {


                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    

                    pdfDoc.Open();


                    if (document == (int)DocumentType.Policy)
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    else
                    {
                        htmlparser.Parse(sr);
                    }
                    pdfDoc.Close();

                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                catch (Exception ex)
                {
                    bytes = new Byte[0];
                }
            }
            return bytes;
        }

        //public static void createPolicy(string src, string des, VehicleDetailsModel model)
        //{
        //    String pathin = src;
        //    String pathout = des;
        //    //create a document object
        //    //var doc = new Document(PageSize.A4);
        //    //create PdfReader object to read from the existing document
        //    PdfReader reader = new PdfReader(pathin);
        //    //select two pages from the original document
        //    reader.SelectPages("1-" + reader.NumberOfPages);
        //    //create PdfStamper object to write to get the pages from reader 
        //    PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.Create));
        //    // PdfContentByte from stamper to add content to the pages over the original content
        //    PdfContentByte pbover = stamper.GetOverContent(1);
        //    //Font fontH1 = new Font(FontFactory.COURIER, 14, Font.NORMAL);


        //    Font font8pt = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);
        //    Font font14pt = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
        //   //1st Slip
        //    //add content to the page using ColumnText
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_MIDDLE, new Phrase(model.InsuranceCompany, font14pt), 40, 725, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseName, font8pt), 40, 700, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseAddress, font8pt), 40, 692, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseCity + ", " + model.LesseProvince + " " + model.LesseZipCode, font8pt), 40, 685, 0);


        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorName, font8pt), 200, 700, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorAddress, font8pt), 200, 692, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorCity + ", " + model.LessorProvince + " " + model.LessorZipCode, font8pt), 200, 685, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Model_Year, font8pt), 40, 660, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Make, font8pt), 70, 660, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.VIM, font8pt), 124, 660, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 250, 660, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.EffectiveDate.Value.ToString("MMM dd,yyyy"), font8pt), 40, 638, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 180, 638, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PolicyNo + "" + @model.TrebuchetRefrenceID, font8pt), 40, 615, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Trebuchet Insurance Brokers Limited", font8pt), 150, 618, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Claims:(902 908-5000)", font8pt), 150, 610, 0);  




        //    //2nd Slip

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_MIDDLE, new Phrase(model.InsuranceCompany, font14pt), 40, 544.9f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseName, font8pt), 40, 519.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseAddress, font8pt), 40, 511.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseCity + ", " + model.LesseProvince + " " + model.LesseZipCode, font8pt), 40, 504.9f, 0);


        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorName, font8pt), 200, 519.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorAddress, font8pt), 200, 511.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorCity + ", " + model.LessorProvince + " " + model.LessorZipCode, font8pt), 200, 504.9f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Model_Year, font8pt), 40, 479.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Make, font8pt), 70, 479.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.VIM, font8pt), 124, 479.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 250, 479.9f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.EffectiveDate.Value.ToString("MMM dd,yyyy"), font8pt), 40, 457.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 180, 457.9f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PolicyNo + "" + @model.TrebuchetRefrenceID, font8pt), 40, 434.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Trebuchet Insurance Brokers Limited", font8pt), 150, 437.9f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Claims:(902 908-5000)", font8pt), 150, 429.9f, 0);


        //    //3rd Slip

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_MIDDLE, new Phrase(model.InsuranceCompany, font14pt), 40, 364.8f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseName, font8pt), 40, 339.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseAddress, font8pt), 40, 331.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseCity + ", " + model.LesseProvince + " " + model.LesseZipCode, font8pt), 40, 324.8f, 0);


        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorName, font8pt), 200, 339.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorAddress, font8pt), 200, 331.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorCity + ", " + model.LessorProvince + " " + model.LessorZipCode, font8pt), 200, 324.8f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Model_Year, font8pt), 40, 299.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Make, font8pt), 70, 299.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.VIM, font8pt), 124, 299.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 250, 299.8f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.EffectiveDate.Value.ToString("MMM dd,yyyy"), font8pt), 40, 277.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 180, 277.8f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PolicyNo + "" + @model.TrebuchetRefrenceID, font8pt), 40, 254.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Trebuchet Insurance Brokers Limited", font8pt), 150, 257.8f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Claims:(902 908-5000)", font8pt), 150, 249.8f, 0);


        //    //4rd Slip

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_MIDDLE, new Phrase(model.InsuranceCompany, font14pt), 40, 184.7f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseName, font8pt), 40, 159.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseAddress, font8pt), 40, 151.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LesseCity + ", " + model.LesseProvince + " " + model.LesseZipCode, font8pt), 40, 144.7f, 0);


        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorName, font8pt), 200, 159.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorAddress, font8pt), 200, 151.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.LessorCity + ", " + model.LessorProvince + " " + model.LessorZipCode, font8pt), 200, 144.7f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Model_Year, font8pt), 40, 119.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.Make, font8pt), 70, 119.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.VIM, font8pt), 124, 119.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 250, 119.7f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.EffectiveDate.Value.ToString("MMM dd,yyyy"), font8pt), 40, 97.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PlateNumber, font8pt), 180, 97.7f, 0);

        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase(model.PolicyNo + "" + @model.TrebuchetRefrenceID, font8pt), 40, 74.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Trebuchet Insurance Brokers Limited", font8pt), 150, 77.7f, 0);
        //    ColumnText.ShowTextAligned(pbover, Element.ALIGN_LEFT, new Phrase("Claims:(902 908-5000)", font8pt), 150, 69.7f, 0);  
            
         

        //    //close the stamper
        //    stamper.Close();
        //}

        public static void CreateTemplate(string watermarkText, string targetFileName)
        {
            var document = new Document();
            var pdfWriter = PdfWriter.GetInstance(document, new FileStream(targetFileName, FileMode.Create));
            var font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 70, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY);
            document.Open();
            ColumnText.ShowTextAligned(pdfWriter.DirectContent, Element.ALIGN_CENTER, new Phrase(watermarkText, font), 300, 400, 45);
            document.Close();
        }
        public static void AddTextWatermark(string sourceFilePath, string watermarkTemplatePath, string targetFilePath)
        {
            var pdfReaderSource = new PdfReader(sourceFilePath);
            var pdfStamper = new PdfStamper(pdfReaderSource, new FileStream(targetFilePath, FileMode.Create));
            var pdfReaderTemplate = new PdfReader(watermarkTemplatePath);
            var page = pdfStamper.GetImportedPage(pdfReaderTemplate, 1);

            for (var i = 0; i < pdfReaderSource.NumberOfPages; i++)
            {
                var content = pdfStamper.GetUnderContent(i + 1);
                content.AddTemplate(page, 0, 0);
            }

            pdfStamper.Close();
            pdfReaderTemplate.Close();
        }

        //private byte[] AddWatermark(byte[] bytes, BaseFont bf)
        //{
        //    using (var ms = new MemoryStream(10 * 1024))
        //    {
        //        using (var reader = new PdfReader(bytes))
        //        using (var stamper = new PdfStamper(reader, ms))
        //        {
        //            int times = reader.NumberOfPages;
        //            for (int i = 1; i <= times; i++)
        //            {
        //                var dc = stamper.GetOverContent(i);
        //                PdfHelper.AddWaterMark(dc, AppName, bf, 48, 35, new BaseColor(70, 70, 255), reader.GetPageSizeWithRotation(i));
        //            }
        //            stamper.Close();
        //        }
        //        return ms.ToArray();
        //    }
        //}

        //public static void AddWaterMark(PdfContentByte dc, string text, BaseFont font, float fontSize, float angle, BaseColor color, Rectangle realPageSize, Rectangle rect = null)
        //{
        //    var gstate = new PdfGState { FillOpacity = 0.1f, StrokeOpacity = 0.3f };
        //    dc.SaveState();
        //    dc.SetGState(gstate);
        //    dc.SetColorFill(color);
        //    dc.BeginText();
        //    dc.SetFontAndSize(font, fontSize);
        //    var ps = rect ?? realPageSize; /*dc.PdfDocument.PageSize is not always correct*/
        //    var x = (ps.Right + ps.Left) / 2;
        //    var y = (ps.Bottom + ps.Top) / 2;
        //    dc.ShowTextAligned(Element.ALIGN_CENTER, text, x, y, angle);
        //    dc.EndText();
        //    dc.RestoreState();
        //}
    }
}
