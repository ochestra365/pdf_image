using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdf_image
{
   /// <summary>
   /// pdf 이미지 렌더링
   /// 아파치 라이센스2.0
   /// PdfiumViewer.Native.x86.v8-xfa
   /// PdfiumViewer 설치
   /// </summary>
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }
      static void ConvertPdfToImages(string pdfPath, string outputDirectory)
      {
         using (var document = PdfDocument.Load(pdfPath))
         {
            for (int pageIndex = 0; pageIndex < document.PageCount; pageIndex++)
            {
               using (var image = document.Render(pageIndex, 300, 300, true))
               {
                  string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex + 1}.png");
                  image.Save(outputPath, ImageFormat.Png);
               }
            }
         }
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         string pdfPath = "Image to PDF 20240130 14.13.26.pdf"; // PDF 파일 경로
         string outputDirectory = Application.StartupPath; // 이미지를 저장할 폴더 경로

         ConvertPdfToImages(pdfPath, outputDirectory);
      }
   }
}
