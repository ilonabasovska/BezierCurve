using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalPointOperation
{
    public partial class MainForm : Form
    {
        int x1;
        int y1;
        private PointF[] histo = new PointF[256];
        private List<PointF> point = new List<PointF>();
        private List<PointF> pointBezier = new List<PointF>();
        private PointF[] pointsForBezierCurves = new PointF[7];
        private Point[] histoBezier = new Point[256];
        public MainForm()
        {
            InitializeComponent();
            MakeHisto();
            point.Add(new PointF() { X = 0, Y = 0 });
            point.Add(new PointF() { X = 255, Y = 255 });
            openImagePictureBox.Image = new Bitmap("C:\\Users\\family\\Desktop\\lena-256x256.bmp");
        }

        private void MakeHisto()
        {
            for (int i = 0; i < 256; ++i)
            {
                histo[i] = new PointF(i, i);
            }
        }
        private void ChangeImage(int x, float y)
        {
            point.Add(new PointF() { X = x1, Y = y1 });
            point = point.OrderBy(p => p.X).ToList();

            for (int c = 0; c < point.Count - 1; ++c)
            {
                for (int i = (int)point[c].X; i <= point[c + 1].X; ++i)
                {
                    histo[i] = new PointF(i, ((((i - point[c + 1].X) / (point[c].X - point[c + 1].X)) * (point[c].Y - point[c + 1].Y)) + point[c + 1].Y));
                }
            }
        }

        private void MakeNewImage()
        {
            Bitmap bitmap = new Bitmap(openImagePictureBox.Image);
            Bitmap bitmapNewImage = new Bitmap(bitmap.Width, bitmap.Height);
            int[,] histogram = new int[bitmap.Width, bitmap.Height];
            int[,] histoNewImage = new int[bitmap.Width, bitmap.Height];
            Color pixelColor = new Color();
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    pixelColor = bitmap.GetPixel(x, y);
                    histogram[x, y] = ((pixelColor.R * 229 + pixelColor.G * 589 + pixelColor.B * 114) / 1000);
                }
            }
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    for (int c = 0; c < histo.Length; ++c)
                    {
                        if (histogram[x, y] == histo[c].X)
                        {
                            histoNewImage[x, y] = (int)histo[c].Y;
                        }
                    }
                }
            }
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    bitmapNewImage.SetPixel(x, y, Color.FromArgb(histoNewImage[x, y], histoNewImage[x, y], histoNewImage[x, y]));
                }
            }
            linesPictureBox.Image = bitmapNewImage;
        }


        private void MakePointsForBezierCurves()
        {
            float sum = 0;
            for (int c = 0; c < point.Count - 1; ++c)
            {
                pointBezier.Add(new PointF(point[c].X, point[c].Y));
                pointBezier.Add(new PointF(((point[c + 1].X - point[c].X) / 4) + sum, point[c].Y + 50));
                pointBezier.Add(new PointF((3 * (point[c + 1].X - point[c].X) / 4) + sum, point[c + 1].Y - 50));
                sum += point[c + 1].X - point[c].X;
            }
            pointBezier.Add(new PointF(point[point.Count - 1].X, point[point.Count - 1].Y));
            pointBezier = pointBezier.OrderBy(p => p.X).ToList();
            pointsForBezierCurves = pointBezier.ToArray();
        }

        private void ChangeImageBezier()
        {


            for (int i = 0; i < pointBezier[3].X; i++)
            {
                //for (int c = 0; c < pointBezier.Count - 1; c = +3)
                //{
                float t = (float)i / (pointBezier[3].X);

                float x = i;
                //float x = (1 - t) * (1 - t) * (1 - t) * pointBezier[0].X +
                //           3 * t * (1 - t) * (1 - t) * pointBezier[1].X +
                //           3 * t * t * (1 - t) * pointBezier[2].X +
                //           t * t * t * pointBezier[3].X;

                float y = (1 - t) * (1 - t) * (1 - t) * pointBezier[0].Y +
                           3 * t * (1 - t) * (1 - t) * pointBezier[1].Y +
                           3 * t * t * (1 - t) * pointBezier[2].Y +
                           t * t * t * pointBezier[3].Y;

                histoBezier[i] = new Point((int)x, (int)(y));
                //}
            }
            int a = 0;
            for (int i = (int)pointBezier[3].X; i <= pointBezier[6].X; i++)
            {
                float t = (float)a / (pointBezier[6].X - pointBezier[3].X);

                float x = i;
                //float x = (1 - t) * (1 - t) * (1 - t) * pointBezier[3].X +
                //           3 * t * (1 - t) * (1 - t) * pointBezier[4].X +
                //           3 * t * t * (1 - t) * pointBezier[5].X +
                //           t * t * t * pointBezier[6].X;

                float y = (1 - t) * (1 - t) * (1 - t) * pointBezier[3].Y +
                           3 * t * (1 - t) * (1 - t) * pointBezier[4].Y +
                           3 * t * t * (1 - t) * pointBezier[5].Y +
                           t * t * t * pointBezier[6].Y;

                histoBezier[i] = new Point((int)x, (int)(y));
                a++;
            }
        }
        private void MakeNewImageBezier()
        {
            Bitmap bitmap = new Bitmap(openImagePictureBox.Image);
            Bitmap bitmapNewImage = new Bitmap(bitmap.Width, bitmap.Height);
            int[,] histogram = new int[bitmap.Width, bitmap.Height];
            int[,] histoNewImage = new int[bitmap.Width, bitmap.Height];
            Color pixelColor = new Color();
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    pixelColor = bitmap.GetPixel(x, y);
                    histogram[x, y] = ((pixelColor.R * 229 + pixelColor.G * 589 + pixelColor.B * 114) / 1000);
                }
            }
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    for (int c = 0; c < histoBezier.Length; ++c)
                    {
                        if (histogram[x, y] == histoBezier[c].X)
                        {
                            histoNewImage[x, y] = (int)histoBezier[c].Y;
                        }
                    }
                }
            }
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    bitmapNewImage.SetPixel(x, y, Color.FromArgb(histoNewImage[x, y], histoNewImage[x, y], histoNewImage[x, y]));
                }
            }
            bezierPictureBox.Image = bitmapNewImage;
        }
        private void histpgramPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            ChangeImage(x1, y1);
            MakeNewImage();
            MakePointsForBezierCurves();
            ChangeImageBezier();
            MakeNewImageBezier();
            histpgramPictureBox.Invalidate();
        }

        private void histpgramPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, 255, 255);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), rectangle);

            e.Graphics.DrawLines(new Pen(Color.Magenta, 2), histo);

            e.Graphics.DrawBeziers(new Pen(Color.Blue, 2), pointsForBezierCurves);

        }
    }
}
