using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_11.Models;
using System.Data.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace WebApplication_11.Controllers
{
    public class AdminController : Controller
    {
        public BazaContext db = new BazaContext();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kabinet()
        {
            string login = User.Identity.Name;
            var user=db.Userlar.Include(i=>i.Roles).Where(l=>l.Login==login).FirstOrDefault().Roles.Nomi;
            switch (user)
            {
                case "Admin":
                    {

                    }break;
                case "User":
                    {
                        return RedirectToAction("Klient", "Admin", new { Id = db.Foydalanuvchi.Where(u => u.Userlar.Login == login).FirstOrDefault().Id });
                    }break;
 
            }
            return View();
        }
        public ActionResult Klient(int?Id)
        {
            return View();
        }
        public ActionResult Zakas()
        {
            ViewBag.h = "ff";
            Sahifa s = new Sahifa();
            s.Kalonka = db.Kalonka.Include(k=>k.Kompaniya).ToList();
            s.Klaviatura = db.Klaviatura.Include(k => k.Kompaniya).ToList();
            s.Manitor = db.Manitor.Include(k => k.Kompaniya).ToList();
            s.OpSistema = db.OpSistema.ToList();           
            s.Protsessor = db.Protsessor.ToList();
            s.Xotira = db.Xotira.Include(k=>k.Kompaniya).ToList();
            s.Blokpitaniya = db.Blokpitaniya.Include(k => k.Kompaniya).ToList();
            s.Qattiqdisk = db.Qattiqdisk.Include(k => k.Kompaniya).ToList();
            s.Onaplata = db.Onaplata.Include(k => k.Kompaniya).ToList();
            s.Korpus = db.Korpus.Include(k => k.Kompaniya).ToList();
            s.Sichqoncha = db.Sichqoncha.Include(k => k.Kompaniya).ToList();

            ViewBag.login = User.Identity.Name;
            return View(s);
        }
        [HttpPost]
        public ActionResult Zakas(int? BlokpitaniyaId, int? QattiqdiskId, int? OnaplataId, int? ProtsessorId, int? KorpusId, int? OpSistemaId, int? KalonkaId, int? KlaviaturaId, int? ManitorId,int? SichqonchaId,string Login)
        {
            //ProtsessorId, QattiqdiskId, OpSistemaId
            ViewBag.h = ProtsessorId.ToString() + "." + QattiqdiskId.ToString() + "." + OpSistemaId.ToString() + ".";

           // Yigish yig = new Yigish();
           // yig.OpSistemaId = OpSistemaId;
           // yig.QattiqdiskId = QattiqdiskId;
           // yig.KalonkaId = KalonkaId;
           // yig.ProtsessorId = ProtsessorId;
           // yig.KlaviaturaId = KlaviaturaId;
           // yig.ManitorId = ManitorId;
           //int sum = 0;
           // OpSistema op = null;
           // op = db.OpSistema.Where(u => u.Id == OpSistemaId).FirstOrDefault();
           // if(op!=null)
           // {
           //     sum += Convert.ToInt32(op.Narxi);
           // } 
           // Qattiqdisk x = null;
           // x = db.Qattiqdisk.Where(xq => xq.Id == QattiqdiskId).FirstOrDefault();
           // if (x != null)
           // {
           //     sum += Convert.ToInt32(x.Narxi);
           // }
           // Kalonka k = null;
           // k = db.Kalonka.Where(xq => xq.Id == KalonkaId).FirstOrDefault();
           // if (k != null)
           // {
           //     sum += Convert.ToInt32(k.Narxi);
           // }
           // Protsessor pt = null;
           // pt = db.Protsessor.Where(xq => xq.Id == ProtsessorId).FirstOrDefault();
           // if (pt != null)
           // {
           //     sum += Convert.ToInt32(pt.Narxi);
           // }
           // Klaviatura kv = null;
           // kv = db.Klaviatura.Where(xq => xq.Id == KlaviaturaId).FirstOrDefault();
           // if (kv != null)
           // {
           //     sum += Convert.ToInt32(kv.Narxi);
           // }
           // Manitor mn = null;
           // mn = db.Manitor.Where(xq => xq.Id == ManitorId).FirstOrDefault();
           // if (mn != null)
           // {
           //     sum += Convert.ToInt32(mn.Narxi);
           // } 

           // yig.Summa = sum;
           // db.Yigish.Add(yig);
           // db.SaveChanges();
           // int idd = db.Yigish.Max(m => m.Id);
           // Buyurtma by = new Buyurtma();
           // by.FoydalanuvchiId = db.Foydalanuvchi.Where(f => f.Userlar.Login == Login).FirstOrDefault().Id;
           // by.Holati = "0";
           // by.YigishId = idd;
           // db.Buyurtma.Add(by);
           // db.SaveChanges();
           // return RedirectToAction("Index", "Home");
            Sahifa s = new Sahifa();
            s.Kalonka = db.Kalonka.Include(k => k.Kompaniya).ToList();
            s.Klaviatura = db.Klaviatura.Include(k => k.Kompaniya).ToList();
            s.Manitor = db.Manitor.Include(k => k.Kompaniya).ToList();
            s.OpSistema = db.OpSistema.ToList();
            s.Protsessor = db.Protsessor.ToList();
            s.Xotira = db.Xotira.Include(k => k.Kompaniya).ToList();
            s.Blokpitaniya = db.Blokpitaniya.Include(k => k.Kompaniya).ToList();
            s.Qattiqdisk = db.Qattiqdisk.Include(k => k.Kompaniya).ToList();
            s.Onaplata = db.Onaplata.Include(k => k.Kompaniya).ToList();
            s.Korpus = db.Korpus.Include(k => k.Kompaniya).ToList();
            s.Sichqoncha = db.Sichqoncha.Include(k => k.Kompaniya).ToList();
           // ViewBag.h = ProtsessorId.ToString() + "." + QattiqdiskId.ToString() + "." + OpSistemaId.ToString() + ".";
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            Chunk chunk = new Chunk("                 Yig'ish natijasi          ", FontFactory.GetFont("Arial", 30, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Yig'gan talaba: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            var userid = db.Userlar.Where(us => us.Login == Login).FirstOrDefault().Id;
            var fish = db.Foydalanuvchi.Where(foy => foy.UserlarId == userid).FirstOrDefault().FISH;
            chunk = new Chunk("         "+fish, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Blok pitaniya: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if(BlokpitaniyaId!=null)
            {
                var blp = db.Blokpitaniya.Where(bl => bl.Id == BlokpitaniyaId).FirstOrDefault().Nomi;
                chunk = new Chunk("             "+blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Qattiq disk: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (QattiqdiskId != null)
            {
                var blp = db.Qattiqdisk.Where(bl => bl.Id == QattiqdiskId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Ona plata: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (OnaplataId != null)
            {
                var blp = db.Onaplata.Where(bl => bl.Id == OnaplataId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }

            chunk = new Chunk("Protsessor: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (ProtsessorId != null)
            {
                var blp = db.Protsessor.Where(bl => bl.Id == ProtsessorId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }

            chunk = new Chunk("Korpus: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (KorpusId != null)
            {
                var blp = db.Korpus.Where(bl => bl.Id == KorpusId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Operatsion sistema: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (OpSistemaId != null)
            {
                var blp = db.OpSistema.Where(bl => bl.Id == OpSistemaId).FirstOrDefault().Raziryad;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Kalonka: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (KalonkaId != null)
            {
                var blp = db.Kalonka.Where(bl => bl.Id == KalonkaId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Klaviatura: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (KlaviaturaId != null)
            {
                var blp = db.Klaviatura.Where(bl => bl.Id == KlaviaturaId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Manitor: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (ManitorId != null)
            {
                var blp = db.Manitor.Where(bl => bl.Id == ManitorId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            chunk = new Chunk("Sichqoncha: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            if (SichqonchaId != null)
            {
                var blp = db.Sichqoncha.Where(bl => bl.Id == SichqonchaId).FirstOrDefault().Nomi;
                chunk = new Chunk("             " + blp, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }
            else
            {
                chunk = new Chunk("             Tanlanmagan: ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                pdfDoc.Add(new Paragraph(chunk));
            }

            ViewBag.login = User.Identity.Name;
            if (ProtsessorId != null && QattiqdiskId != null)
            {
                if ((ProtsessorId == 2 ) && QattiqdiskId == 2)
                {
                    ViewBag.h = "alo";
                    chunk = new Chunk("Sizga qo'yilgan baxo: a'lo ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    var pros = db.Protsessor.Where(p => p.Id == ProtsessorId).FirstOrDefault().Nomi;
                    var disk = db.Qattiqdisk.Where(p => p.Id == QattiqdiskId).FirstOrDefault().Nomi;
                    chunk = new Chunk("         Siz tanlagan "+pros+" turdagi protssesor va "+disk+" turdagi qattiq disk bir biriga mos tushadi", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));

                }
                else if ((ProtsessorId == 5 ) && QattiqdiskId == 1)
                {
                    ViewBag.h = "alo";
                    chunk = new Chunk("Sizga qo'yilgan baxo: a'lo ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    var pros = db.Protsessor.Where(p => p.Id == ProtsessorId).FirstOrDefault().Nomi;
                    var disk = db.Qattiqdisk.Where(p => p.Id == QattiqdiskId).FirstOrDefault().Nomi;
                    chunk = new Chunk("         Siz tanlagan " + pros + " turdagi protssesor va " + disk + " turdagi qattiq disk bir biriga mos tushadi", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                }
                else if ((ProtsessorId ==5) && QattiqdiskId == 2)
                {
                    ViewBag.h = "qoniqarli";
                    chunk = new Chunk("Sizga qo'yilgan baxo: qoniqarli ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    var pros = db.Protsessor.Where(p => p.Id == ProtsessorId).FirstOrDefault().Nomi;
                    var disk = db.Qattiqdisk.Where(p => p.Id == QattiqdiskId).FirstOrDefault().Nomi;
                    chunk = new Chunk("Siz tanlagan " + pros + " turdagi protssesor va " + disk + " turdagi qattiq disk bir biriga mos tushmaydi", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                }
                else if ((ProtsessorId == 2) && QattiqdiskId == 1)
                {
                    ViewBag.h = "qoniqarli";
                    chunk = new Chunk("Sizga qo'yilgan baxo: qoniqarli ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    var pros = db.Protsessor.Where(p => p.Id == ProtsessorId).FirstOrDefault().Nomi;
                    var disk = db.Qattiqdisk.Where(p => p.Id == QattiqdiskId).FirstOrDefault().Nomi;
                    chunk = new Chunk("         Siz tanlagan " + pros + " turdagi protssesor va " + disk + " turdagi qattiq disk bir biriga mos tushmaydi", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));

                }
                else if ((ProtsessorId == 3 || ProtsessorId == 4) && (QattiqdiskId == 1||QattiqdiskId==2))
                {
                    ViewBag.h = "yaxshi";
                    chunk = new Chunk("Sizga qo'yilgan baxo: yaxshi ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    var pros = db.Protsessor.Where(p => p.Id == ProtsessorId).FirstOrDefault().Nomi;
                    var disk = db.Qattiqdisk.Where(p => p.Id == QattiqdiskId).FirstOrDefault().Nomi;
                    chunk = new Chunk("       Siz tanlagan " + pros + " turdagi protssesor va " + disk + " turdagi qattiq disk bir biriga mos ehtimoli kam", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                }
            }
            else
            {
                if(QattiqdiskId==null&&ProtsessorId==null)
                {
                    chunk = new Chunk("Sizga qo'yilgan baxo: qoniqarli ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    chunk = new Chunk("       Siz protsessor va qattiq disk tanlamagansiz", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                }
               else if(QattiqdiskId==null)
                {
                    chunk = new Chunk("Sizga qo'yilgan baxo: qoniqarli ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    chunk = new Chunk("        Siz  qattiq disk tanlamagansiz", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                }
                else if (ProtsessorId == null)
                {
                    chunk = new Chunk("Sizga qo'yilgan baxo: qoniqarli ", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                    chunk = new Chunk("        Siz protsessor tanlamagansiz", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
                    pdfDoc.Add(new Paragraph(chunk));
                }
            }

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + fish+DateTime.Now.Year.ToString()+ DateTime.Now.Minute.ToString() + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
            return View(s);
        }
        public JsonResult getOp(int id)
        {
            return Json(db.OpSistema.Where(y => y.Id == id));
        }
        public JsonResult getXotira(int id)
        {
            return Json(db.Xotira.Where(y => y.Id == id));
        }
        public JsonResult getKol(int id)
        {
            return Json(db.Kalonka.Where(y => y.Id == id));
        }
        public JsonResult getPro(int id)
        {
            return Json(db.Protsessor.Where(y => y.Id == id));
        }
        public JsonResult getKlv(int id)
        {
            return Json(db.Klaviatura.Where(y => y.Id == id));
        }
        public JsonResult getMan(int id)
        {
            return Json(db.Manitor.Where(y => y.Id == id));
        }
        public JsonResult getSich(int id)
        {
            return Json(db.Sichqoncha.Where(y => y.Id == id));
        }
        public JsonResult getKor(int id)
        {
            return Json(db.Korpus.Where(y => y.Id == id));
        }
        public JsonResult getOna(int id)
        {
            return Json(db.Onaplata.Where(y => y.Id == id));
        }
        public JsonResult getQat(int id)
        {
            return Json(db.Qattiqdisk.Where(y => y.Id == id));
        }
        public JsonResult getBl(int id)
        {
            return Json(db.Blokpitaniya.Where(y => y.Id == id));
        }
    }
}