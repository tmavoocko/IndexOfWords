using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace NdexOfWords
{
    public class AxixsPnl : Panel
    {
        public Point SpwLc = new Point();
        public static Panel Space = new Panel();
        //public Form1 MyParent;
        private Point mouseDownLoc;
        public Color ClrInver;
        public Color ClrdBck = Color.FromArgb(32, 178, 170);
        public Color DsgnFrColor1;
        public Color DsgnFrColor11 = Color.FromArgb(32, 78, 70);//)	"{Name=ff204e46, ARGB=(255, 32, 78, 70)}"	System.Drawing.Color

        public Font myFont = new Font("Cambria", 14, FontStyle.Bold);
        public string Axe = "";
        
        public AxixsPnl(string a)//Form1 parent
        {
            Axe = a;
            BackColor = ClrdBck;
            //MyParent = parent;
            AxixsPnlDsgn();
            //MyParent.Controls.Add(this);
            //MyParent.ClientSizeChanged += (sender, e) => { RposCntrols(); };

        }
        
        private void AxixsPnlDsgn()
        {
            Size = new Size(63, 63);
            Location = new Point(0, 0);
            //Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            //Anchor = (AnchorStyles.Left);
            //AutoSize = true;
            BringToFront();
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //Dock = DockStyle.Left;
            BorderStyle = BorderStyle.FixedSingle;
            //BackColor = Color.Transparent;
            //BackColor = Color.FromArgb(45, ClrdBck);
            MyClrInvrt(ClrdBck);
            DsgnFrColor1 = ForeColor;
            //Point spwnLoc = new Point(Width / 50, Height / 50);
            Size szz = new Size(63, 63); int fnt = 18;
            Font myFont = new Font("Cambria", fnt, FontStyle.Bold);
            Enabled = false;
            Paint += (sender, e) =>
            {
                //MessageBox.Show("MCnvs Paint += (sender, e) =>  =Active ");
                if (Axe=="Y")
                {
                    YDraw(e.Graphics);
                }
                if (Axe == "X")
                {
                    XDraw(e.Graphics);
                }
                if (Axe == "Crss2D")
                {
                    Crss2DDraw(e.Graphics);
                }
                if (Axe == "Crss3D")
                {
                    Crss3DDraw(e.Graphics);
                }

                if (Axe == "Spc")
                {
                    SpcDraw(e.Graphics);
                }
            };
            MouseHover += (sender, e) =>
            {
                ToolTip hint = new ToolTip();
                hint.SetToolTip(this, this.ToString());

            };
            //MyParent.Controls.Add(this);
        }
        public void MyClrInvrt(Color cl)
        {
            ClrInver = Color.FromArgb(cl.ToArgb() ^ 0xffffff);
            ForeColor = ClrInver;
        }
        
        //protected override void OnPaint(PaintEventArgs e)
        //{

        //    //MessageBox.Show("MCnvs OnPaint(PaintEventArgs e)=Active ");
        //    //YDraw(e.Graphics);
        //    //XDraw(e.Graphics);
        //}
        public void Crss2DDraw(Graphics G)
        {

            {//GraphicsContainer ArrCross
                GraphicsContainer ArrCross = G.BeginContainer();//Arrow cross Container
                int z = 20; int w = 20; int h = 20;
                Random random = new Random();
                Color orntCross = Color.FromArgb(random.Next(50, 255), random.Next(0, 255), random.Next(25, 255));//rnd Color

                Pen pncl = new Pen(Color.FromArgb(32, 78, 70), 3f);
                Point SpwLc = new Point(15, 15);
                G.ScaleTransform(1.0f, -1.0f);
                G.TranslateTransform(0, -Height);
                {
                    GraphicsContainer x = G.BeginContainer();////X Arrow  ContainerX
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X + w, SpwLc.Y);
                    G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y + (z / 2 / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y - (z / 2 / Cnst.FltZ));
                    GraphicsContainer xRotate = G.BeginContainer();
                    G.ScaleTransform(1.0f, -1.0f);
                    G.TranslateTransform(0, -Height);
                    SizeF txtSz = G.MeasureString("X", myFont);
                    G.DrawString("X", myFont, new SolidBrush(Color.FromArgb(32, 78, 70)), SpwLc.X + w, SpwLc.Y + (txtSz.Height)/2);
                    G.EndContainer(xRotate);
                    G.EndContainer(x);//X Arrow X ContainerEnd
                }////X Arrow  ContainerX
                {
                    GraphicsContainer yArrw = G.BeginContainer();//Y Arrow  ContainerY
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X, SpwLc.Y + h);
                    GraphicsContainer y = G.BeginContainer();//ContainerY Rotate
                    G.TranslateTransform(SpwLc.X, SpwLc.Y + h);
                    G.RotateTransform(180);//ROTATE STRING!!
                    SizeF textSize = G.MeasureString("Y", myFont);
                    G.ScaleTransform(-1.0f, 1.0f);//MIRRORED VIEW to mirrored STRING = go back to originall!!
                    G.DrawString("Y", myFont, new SolidBrush(Color.FromArgb(32, 78, 70)), -(textSize.Width / 2), -(textSize.Height));
                    G.EndContainer(y);// Y Rotate ContainerEnd
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y + h, SpwLc.X + (z / 2 / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y + h, SpwLc.X - (z / 2 / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.EndContainer(yArrw);//Y Arrow  ContainerY  End
                }//Y Arrow  ContainerY
                G.EndContainer(ArrCross);//ContainerEnd////Arrow cross Container


            }//ArrCross GraphicsContainer 

           


        }
        public void Crss3DDraw(Graphics G)
        {
            {//Arrow cross
                int screw = 20;
                int z = 33; int w = 43; int h = 43;
                
                Pen pncl = new Pen(Color.FromArgb(32, 78, 70), 3f);
                SpwLc = new Point(ClientSize.Width / 6, ClientSize.Height - 12);
                //X Arrow
                G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X + w, SpwLc.Y);
                G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y + (z / 2 / Cnst.FltZ));
                G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y - (z / 2 / Cnst.FltZ));
                //X Arrow

                //Y Arrow
                G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X, SpwLc.Y - h);
                G.DrawLine(pncl, SpwLc.X, SpwLc.Y - h, SpwLc.X + (z / 2 / Cnst.FltZ), SpwLc.Y - h - h / 4 + (z / Cnst.FltZ));
                G.DrawLine(pncl, SpwLc.X, SpwLc.Y - h, SpwLc.X - (z / 2 / Cnst.FltZ), SpwLc.Y - h - h / 4 + (z / Cnst.FltZ));
                //Y Arrow

                //Z Arrow
                G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X + (z / Cnst.FltZ), SpwLc.Y - (z / Cnst.FltZ));
                G.DrawLine(pncl, SpwLc.X + (z / Cnst.FltZ), SpwLc.Y - (z / Cnst.FltZ), SpwLc.X + (z / Cnst.FltZ), SpwLc.Y + h / 3 / 2 - (z / Cnst.FltZ));
                G.DrawLine(pncl, SpwLc.X + (z / Cnst.FltZ), SpwLc.Y - (z / Cnst.FltZ), SpwLc.X + (z / Cnst.FltZ) - w / 3 / 2, SpwLc.Y - (z / Cnst.FltZ));
                //Z Arrow
            }//Arrow cross
        }
        public void Crss3DDrawTst(Graphics G)
        {

            {//GraphicsContainer ArrCross
                GraphicsContainer ArrCross = G.BeginContainer();//Arrow cross Container
                int z = 10; int w = 20; int h = 20;
                Random random = new Random();
                Color orntCross = Color.FromArgb(random.Next(50, 255), random.Next(0, 255), random.Next(25, 255));//rnd Color

                Pen pncl = new Pen(Color.FromArgb(32, 78, 70), 3f);
                Point SpwLc = new Point(15, 15);
                G.ScaleTransform(1.0f, -1.0f);
                G.TranslateTransform(0, -Height);
                {
                    GraphicsContainer x = G.BeginContainer();////X Arrow  ContainerX
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X + w, SpwLc.Y);
                    G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y + (z / 2 / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y - (z / 2 / Cnst.FltZ));
                    GraphicsContainer xRotate = G.BeginContainer();
                    G.ScaleTransform(1.0f, -1.0f);
                    G.TranslateTransform(0, -Height);
                    SizeF txtSz = G.MeasureString("X", myFont);
                    G.DrawString("X", myFont, new SolidBrush(Color.FromArgb(32, 78, 70)), SpwLc.X + w, SpwLc.Y + (txtSz.Height) / 2);
                    G.EndContainer(xRotate);
                    G.EndContainer(x);//X Arrow X ContainerEnd
                }////X Arrow  ContainerX
                {
                    GraphicsContainer yArrw = G.BeginContainer();//Y Arrow  ContainerY
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X, SpwLc.Y + h);
                    GraphicsContainer y = G.BeginContainer();//ContainerY Rotate
                    G.TranslateTransform(SpwLc.X, SpwLc.Y + h);
                    G.RotateTransform(180);//ROTATE STRING!!
                    SizeF textSize = G.MeasureString("Y", myFont);
                    G.ScaleTransform(-1.0f, 1.0f);//MIRRORED VIEW to mirrored STRING = go back to originall!!
                    G.DrawString("Y", myFont, new SolidBrush(Color.FromArgb(32, 78, 70)), -(textSize.Width / 2), -(textSize.Height));
                    G.EndContainer(y);// Y Rotate ContainerEnd
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y + h, SpwLc.X + (z / 2 / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y + h, SpwLc.X - (z / 2 / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.EndContainer(yArrw);//Y Arrow  ContainerY  End
                }//Y Arrow  ContainerY


                {////Z Arrow  ContainerZ
                    GraphicsContainer Z = G.BeginContainer();////X Arrow  ContainerX
                    
                    //Z Arrow
                    //G.ScaleTransform(1.0f, -1.0f);
                    //G.TranslateTransform(0, -Height);
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X + (z / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X + (z / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ), SpwLc.X + (z / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ)-9);
                    G.DrawLine(pncl, SpwLc.X + (z / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ), SpwLc.X + (z / Cnst.FltZ) -9, SpwLc.Y + (z / Cnst.FltZ));
                    
                    //Z Arrow
                    GraphicsContainer zRotate = G.BeginContainer();
                    
                    G.TranslateTransform(SpwLc.X + (z / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.RotateTransform(180);//ROTATE STRING!!
                    SizeF txtSz = G.MeasureString("Z", myFont);
                    G.DrawString("Z", myFont, new SolidBrush(Color.FromArgb(32, 78, 70)), SpwLc.X + (z / Cnst.FltZ), SpwLc.Y +(z / Cnst.FltZ) + (txtSz.Height) / 2 + (z / Cnst.FltZ));
                    G.EndContainer(zRotate);
                    G.EndContainer(Z);//Z Arrow Z ContainerEnd
                }////Z Arrow  ContainerZ
                

                G.EndContainer(ArrCross);//ContainerEnd////Arrow cross Container


            }//ArrCross GraphicsContainer 




        }
        public void YDraw(Graphics G)
        {
            {//BaseLines Container
                GraphicsContainer BsLns = G.BeginContainer();//BaseLines Container
                int w = Width, h = Cnst.ScreeLftOver.Height-30 ;
                Random random = new Random();
                Color orntCross = Color.FromArgb(random.Next(50, 255), random.Next(0, 255), random.Next(25, 255));//rnd Color
                //MessageBox.Show(h.ToString()); MessageBox.Show(ClientSize.ToString());
                Pen pncl = new Pen(Color.FromArgb(32, 78, 70), 3f);
                SpwLc = new Point(30, 0);
                G.ScaleTransform(1.0f, -1.0f);
                G.TranslateTransform(30, 0 - Height);
                
                {//Y Line Working
                    GraphicsContainer yLine = G.BeginContainer();//Y yLine  ContainerY
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y - 10, SpwLc.X, SpwLc.Y + h+30);
                    GraphicsContainer y = G.BeginContainer();//ContainerY Rotate
                    G.TranslateTransform(SpwLc.X, SpwLc.Y + h - 90);
                    G.RotateTransform(180);//ROTATE STRING!!
                    SizeF textSize = G.MeasureString("Y", myFont);
                    G.ScaleTransform(-1.0f, 1.0f);//MIRRORED VIEW to mirrored STRING = go back to originall!!
                    //MessageBox.Show((SpwLc.Y + h -(h-30)- (textSize.Height )).ToString());
                    G.DrawString("Y", myFont, new SolidBrush(Color.FromArgb(32, 78, 70)), SpwLc.X - (textSize.Width * 4), SpwLc.Y - 30 - (textSize.Height * 3));
                    G.EndContainer(y);// Y Rotate ContainerEnd

                    for (int i = 10; i <= h + 30 + 10; i++)
                    {
                        G.DrawLine(pncl, SpwLc.X - 5, SpwLc.Y - 10 - 100 + i * 10, SpwLc.X, SpwLc.Y - 10 - 100 + i * 10);

                    }


                    G.EndContainer(yLine);//Y ContainerY  End
                }//Y Line ContainerY - working
                G.EndContainer(BsLns);//ContainerEnd////BaseLines Container


            }//BaseLinesContainer
            
        }
        public void XDraw(Graphics G)
        {

            {//BaseLines Container
                GraphicsContainer BsLns = G.BeginContainer();//BaseLines Container
                int w = Width, h = Cnst.ScreeLftOver.Height - 60;
                Random random = new Random();
                Color orntCross = Color.FromArgb(random.Next(50, 255), random.Next(0, 255), random.Next(25, 255));//rnd Color
                //MessageBox.Show(h.ToString()); MessageBox.Show(ClientSize.ToString());
                Pen pncl = new Pen(Color.FromArgb(32, 78, 70), 3f);
                SpwLc = new Point(0, 0);
                G.ScaleTransform(1.0f, -1.0f);
                G.TranslateTransform(0, 3 - Height);
                {//X Line
                    GraphicsContainer xLine = G.BeginContainer();////X Line  ContainerX
                    G.DrawLine(pncl, SpwLc.X , SpwLc.Y, SpwLc.X + w, SpwLc.Y);
                    SizeF textSize = G.MeasureString("X", myFont);
                    G.DrawString("X", new Font("Verdana", 14), new SolidBrush(Color.FromArgb(32, 78, 70)), SpwLc.X + w - 90 - (textSize.Width), SpwLc.Y + (textSize.Height) -15);
                    for (int i = 10; i <= (w + 10 + 30); i++)
                    {
                        G.DrawLine(pncl, SpwLc.X - 100  + i * 10, SpwLc.Y , SpwLc.X - 100 + i * 10, SpwLc.Y+5);

                    }
                    



                    G.EndContainer(xLine);//X Line ContainerEnd
                }////X Line  ContainerX
                
                G.EndContainer(BsLns);//ContainerEnd////BaseLines Container


            }//BaseLinesContainer

           

        }
        public void SpcDraw(Graphics G)
        {

            {//BaseLines Container
                GraphicsContainer BsLns = G.BeginContainer();//BaseLines Container
                int w = Width, h = Cnst.ScreeLftOver.Height ;
                Pen pncl = new Pen(ForeColor, 5f);
                SpwLc = new Point(0, 0);
                G.ScaleTransform(1.0f, -1.0f);
                G.TranslateTransform(0, 0 - Height);
                {//Border
                    GraphicsContainer Border = G.BeginContainer();////X Line  ContainerX
                    //Cnst.ScreeLftOver.Location = SpwLc;
                    //Cnst.ScreeLftOver.Width = w-4;
                    //G.DrawRectangle(pncl, Cnst.ScreeLftOver);
                    
                    G.EndContainer(Border);//Border ContainerEnd
                }////Border  Container


                G.EndContainer(BsLns);//ContainerEnd////BaseLines Container


            }//BaseLinesContainer



        }
        public void ClntDraw(Graphics G)
        {

            {//GraphicsContainer ArrCross
                GraphicsContainer ArrCross = G.BeginContainer();//Arrow cross Container
                int z = 55; int w = 55; int h = 55;
                Random random = new Random();
                Color orntCross = Color.FromArgb(random.Next(50, 255), random.Next(0, 255), random.Next(25, 255));//rnd Color

                Pen pncl = new Pen(orntCross, 2f);
                Point SpwLc = new Point(30, 30);
                G.ScaleTransform(1.0f, -1.0f);
                G.TranslateTransform(0, -Height);
                {
                    GraphicsContainer x = G.BeginContainer();////X Arrow  ContainerX
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X + w, SpwLc.Y);
                    G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y + (z / 2 / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X + w, SpwLc.Y, SpwLc.X + w + w / 2 - (z * 2 / Cnst.FltZ), SpwLc.Y - (z / 2 / Cnst.FltZ));
                    G.DrawString("X", new Font("Verdana", 14), new SolidBrush(orntCross), SpwLc.X + w, SpwLc.Y);
                    G.EndContainer(x);//X Arrow X ContainerEnd
                }////X Arrow  ContainerX
                {
                    GraphicsContainer yArrw = G.BeginContainer();//Y Arrow  ContainerY
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y, SpwLc.X, SpwLc.Y + h);
                    GraphicsContainer y = G.BeginContainer();//ContainerY Rotate
                    G.TranslateTransform(SpwLc.X, SpwLc.Y + h);
                    G.RotateTransform(180);//ROTATE STRING!!
                    SizeF textSize = G.MeasureString("Y", myFont);
                    G.DrawString("Y", myFont, new SolidBrush(orntCross), -(textSize.Width / 2), -(textSize.Height));
                    G.EndContainer(y);// Y Rotate ContainerEnd
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y + h, SpwLc.X + (z / 2 / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.DrawLine(pncl, SpwLc.X, SpwLc.Y + h, SpwLc.X - (z / 2 / Cnst.FltZ), SpwLc.Y + (z / Cnst.FltZ));
                    G.EndContainer(yArrw);//Y Arrow  ContainerY  End
                }//Y Arrow  ContainerY
                G.EndContainer(ArrCross);//ContainerEnd////Arrow cross Container


            }//ArrCross GraphicsContainer 




        }


        
    }
}
