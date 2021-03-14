using System.Drawing;
using System.IO;
using QRCoder;

namespace QRCode.Application.Services
{
    public static class CodeGenerator
    {
        public static byte[] GenerateByteArray(string url)
        {
            var image = GenerateCodeImage(url);
            return ImageToBytes(image);
        }
        private static byte[] ImageToBytes(Image image)
        {
            using var stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
            
        }
        public static Bitmap GenerateCodeImage(string url)
        {
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(10);
            return qrCodeImage;
        }
    }
}