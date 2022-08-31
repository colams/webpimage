using Imazen.WebP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Imagelib
{
    public class WebpConvertUtil
    {
        #region 将图片转换为Webp格式
        /// <summary>
        /// 将图片转换为Webp格式
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="outFilePath"></param>
        public void ConvertToWebp(string fileName = "", string outFilePath = "")
        {
            Imazen.WebP.Extern.LoadLibrary.LoadWebPOrFail();

            var encoder = new SimpleEncoder();
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "2.png";
            }
            string outFileName = outFilePath + string.Format("\\testimageout{0}.webp", DateTime.Now.ToString("yyyyMMddHHmmss"));
            File.Delete(outFileName);

            Bitmap mBitmap;
            FileStream outStream = new FileStream(outFileName, FileMode.Create);
            using (Stream BitmapStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image img = Image.FromStream(BitmapStream);

                mBitmap = new Bitmap(img);

                encoder.Encode(mBitmap, outStream, 100);
            }

            FileInfo finfo = new FileInfo(outFileName);
        } 
        #endregion
    }
}
