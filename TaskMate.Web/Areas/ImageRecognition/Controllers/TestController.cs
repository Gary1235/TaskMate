using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;
using Tesseract;

namespace TaskMate.Web.Areas.ImageRecognition.Controllers
{
    [Area("ImageRecognition")]
    public class TestController : Controller
    {
        public IActionResult TESTRecognition()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Recognize([FromBody] ImageRequest request)
        {
            if (string.IsNullOrEmpty(request.Image))
                return BadRequest("No image provided");

            // 解析 Base64 成影像
            byte[] imageBytes = Convert.FromBase64String(request.Image.Replace("data:image/png;base64,", ""));
            using var ms = new MemoryStream(imageBytes);
            using var bitmap = new Bitmap(ms);

            // 使用 Tesseract 進行 OCR 辨識
            string result;
            using (var ocrEngine = new TesseractEngine("D:\\Side Projects\\TaskMate\\TaskMate.Web\\RecognitionData", "eng", EngineMode.Default))
            {
                using var img = ConvertBitmapToPix(bitmap);
                using var page = ocrEngine.Process(img);
                result = page.GetText().Trim();
            }

            return Json(new { result });
        }

        public Pix ConvertBitmapToPix(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // 儲存為 PNG 格式
                ms.Seek(0, SeekOrigin.Begin);
                return Pix.LoadFromMemory(ms.ToArray()); // 使用 Pix.LoadFromMemory 讀取
            }
        }

        public class ImageRequest
        {
            public string Image { get; set; }
        }
    }
}
