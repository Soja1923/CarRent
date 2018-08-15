using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace CarRent.Infrastructure
{
    public class ImgConverter
    {
        //Zamiana obrazu na tablice byte
        public static byte[] ImgToByte(string path)
        {
            byte[] byteData = System.IO.File.ReadAllBytes(path);
            return byteData;
        }

        public static string ByteToImg(byte[] byteImg)
        {
            string imageBase64Data = Convert.ToBase64String(byteImg);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            return imageDataURL;
        }
    }
}
