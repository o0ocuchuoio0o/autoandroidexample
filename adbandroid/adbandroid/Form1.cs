using AForge.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adbandroid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            TOP_UP_BMP = (Bitmap)Bitmap.FromFile("data//TopUp.png");
            manhinh = (Bitmap)Bitmap.FromFile("a.png");
        }
        bool isStop = false;
        #region data
        Bitmap TOP_UP_BMP;
        Bitmap manhinh;
        #endregion

        public static Bitmap ConvertToFormat(System.Drawing.Image image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap sourceImage = ConvertToFormat(manhinh, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Bitmap template = ConvertToFormat(TOP_UP_BMP, System.Drawing.Imaging.PixelFormat.Format24bppRgb); ;
            var a = Find(sourceImage, template);
            a.Save("test.png");
        }

        public static Bitmap Find(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.4)
        {
            Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
            Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
            Image<Bgr, byte> image3 = image.Copy();
            using (Image<Gray, float> image4 = image.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] numArray;
                double[] numArray2;
                Point[] pointArray;
                Point[] pointArray2;
                image4.MinMax(out numArray, out numArray2, out pointArray, out pointArray2);
                if (numArray2[0] > percent)
                {
                    Rectangle rect = new Rectangle(pointArray2[0], template.Size);
                    image3.Draw(rect, new Bgr(System.Drawing.Color.Red), 2, LineType.EightConnected, 0);
                }
                else
                {
                    image3 = null;
                }
            }
            return ((image3 == null) ? null : image3.ToBitmap());
        }
    }
}
