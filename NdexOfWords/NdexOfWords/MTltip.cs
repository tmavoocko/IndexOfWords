using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Drawing.Graphics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NdexOfWords
{
    public class MTltip:Panel
    {
        public Timer Dlay = new Timer();
        public Font MFnt = new Font("Litograph", 9, FontStyle.Italic);
        public Point SpwLc;
        public String MTxt = "";
        //public Label MTxt = new Label();
        public Control MPrnt;
        public Control Lnk;
        public int OpacityMine = 100;
        public int FutureOpacityMine = 0;
        public Color ClrdFrnt = new Color();
        public Color ClrdBck = new Color();
        public MTltip(Control parent, Control lnk,string txt,int mopacity=100)
        {
            MPrnt = parent;
            Lnk = lnk;
            OpacityMine = mopacity;
            BackColor= ClrdBck = Color.FromArgb(OpacityMine, Lnk.ForeColor);
            ForeColor=ClrdFrnt = Color.FromArgb(OpacityMine, Lnk.BackColor);
            if (txt=="")
            {
                MTxt = Lnk.ToString();
            }
            else
            {
                MTxt = txt;
            }
            
            Paint += (sender, e) =>
             {
                 {////ClientResultsDraw
                     {//Rmck
                         GraphicsContainer Brdr = e.Graphics.BeginContainer();//BaseLines Container
                         int wRmck = Width-6, hRmck = Height-6;
                         Pen pnclRmck = new Pen(ClrdFrnt, 5f);
                         Pen pnclDashRmck = new Pen(ClrdBck, 3f);
                         pnclDashRmck.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                         SpwLc = new Point(3, 3);
                         e.Graphics.ScaleTransform(1.0f, -1.0f);
                         e.Graphics.TranslateTransform(0, 0 - Height);
                         Rectangle rmck = new Rectangle(SpwLc.X,SpwLc.Y,Width,Height);
                         rmck.Height = hRmck;
                         rmck.Width = wRmck;

                         //funguje
                         e.Graphics.DrawRectangle(pnclRmck, rmck);
                         e.Graphics.DrawRectangle(pnclDashRmck, rmck);

                         e.Graphics.EndContainer(Brdr);//ContainerEnd////BaseLines Container
                     }//Rmck

                     {//String
                         GraphicsContainer MTltpTxt = e.Graphics.BeginContainer();//BaseLines Container
                         int w = Width, h = Height;
                         Pen pncl = new Pen(Color.WhiteSmoke, 13f);
                         Pen pnclDash = new Pen(ForeColor, 8f);
                         pnclDash.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                         SpwLc = new Point(9, 9);
                         //SpwLc.X = Lnk.Location.X + Lnk.Width / 2;
                         //SpwLc.Y = Lnk.Location.Y + Lnk.Height / 2;
                         GraphicsContainer strngRotate = e.Graphics.BeginContainer();
                         e.Graphics.ScaleTransform(1.0f, 1.0f);
                         e.Graphics.TranslateTransform(0, 0 - Height);
                         SizeF txtSz = e.Graphics.MeasureString(MTxt, MFnt);
                         if ((int)txtSz.Width>Width-18)
                         {
                             Width = (int)txtSz.Width + 18;
                             Invalidate();
                         }
                         if ((int)txtSz.Height > Height - 8)
                         {
                             Height = (int)txtSz.Height + 18;
                             Invalidate();
                         }

                         //e.Graphics.FillPolygon(new SolidBrush(Color.White), pnts);
                         e.Graphics.DrawString(MTxt, MFnt, new SolidBrush(Lnk.BackColor), SpwLc.X + (0), SpwLc.Y + (txtSz.Height * 2) );//txtSz.Width /2

                         e.Graphics.EndContainer(strngRotate);


                         e.Graphics.EndContainer(MTltpTxt);//ContainerEnd////BaseLines Container


                     }//String
                 }//ClientResultsDraw
                 


             };
            Left = 0+ Lnk.Width / 2;
            Top = 0 + Lnk.Height / 2;
            //AutoSize = true;


            //Lbl here
            try//Mine Tolltip (Label)
            {
                //Label myTooltip = new Label();
                //myTooltip.Font = new Font("Cambria", 8); // working!!

                //myTooltip.Font = new Font(FontFamily.GenericSansSerif,12.0F, FontStyle.Bold); //working!!
                //myTooltip.Font = new System.Drawing.Font(this.Font.FontFamily, 8); //working!!
                Cnst.Ticker.Interval = 1000;
                Cnst.Ticker.Start();
                Cnst.Ticker.Tick += (Sender, f) =>
                {
                    Cnst.Ticker.Stop();
                    //afterTck
                    Label myDBgTooltip = new Label();
                    myDBgTooltip.Font = Lnk.Font; // working!!
                    myDBgTooltip.Location = new Point(0, 0);
                    myDBgTooltip.TextAlign = ContentAlignment.MiddleCenter;
                    //myDBgTooltip.Text = Lnk.ToString() + ", " + Environment.NewLine + MTxt + ", " + Environment.NewLine + Lnk.Location + ", " + Environment.NewLine + Lnk.Size + ".";
                    if (MTxt!="")
                    {
                        myDBgTooltip.Text = MTxt;
                    }
                    else
                    {
                        myDBgTooltip.Text = Lnk.ToString() + ", " + Environment.NewLine + "Zero Txt input given" + ", " + Environment.NewLine + Lnk.Location + ", " + Environment.NewLine + Lnk.Size + ".";

                    }
                    //myDBgTooltip.Size = new Size(200, 200);
                    myDBgTooltip.AutoSize = true;

                    myDBgTooltip.BackColor = Lnk.ForeColor;
                    myDBgTooltip.ForeColor = Lnk.BackColor;
                    //Controls.Add(myDBgTooltip);
                    myDBgTooltip.BringToFront();
                    Cnst.Ticker.Interval = 2000;
                    Cnst.Ticker.Start();
                    Cnst.Ticker.Tick += (Sender2, f2) =>
                    {
                        Dispose();
                        Cnst.Ticker.Stop();

                    };
                };


            }
            catch (Exception) { }//Mine Tolltip (Label)




            //Width = Lnk.Width / 2;
            //Height = Lnk.Height / 2;
            //Size = Lnk.Size;
            //Location.X = (Lnk.Location.X + Lnk.Width / 2);
            MPrnt.Controls.Add(this);
        }
        
        private int drwTickDuration = 50;
        public bool isDrwing = false;
        public void ReceiveDrw(DrwOverTime e, int drwDrtn = 50)
        {

            //S.Cnvs.KillLists3D();
            //String df=new String()

            
            drwTickDuration = drwDrtn;
            //S.Canvas.Pohyby.Add(this);
            Cnst.S.TPaint.Add(this);
            isDrwing = true;
            if (!Cnst.S.Ticker.Enabled) Cnst.S.Ticker.Start();
        }
        public void Ticker_Tick2()
        {
            if (drwTickDuration > 0)
            {

                int stepToOpacity = (FutureOpacityMine - OpacityMine) / drwTickDuration;//pksX1.X means in2D=X2.X=Input[0]

                OpacityMine += stepToOpacity;
                {//REDRAW
                    BackColor = Color.FromArgb(OpacityMine, Lnk.BackColor);
                    ForeColor = Color.FromArgb(OpacityMine, Lnk.ForeColor);
                    Refresh();
                }//REDRAW
                
                {//Functions Influence
                    

                    //if (S.Cnvs.FncDiffr == true) S.Cnvs.DffrPrsms();
                }//Functions Influence
                drwTickDuration--;
            }
            else
            {
                OpacityMine = FutureOpacityMine;
                {//REDRAW
                    BackColor = Color.FromArgb(OpacityMine, Lnk.BackColor);
                    ForeColor = Color.FromArgb(OpacityMine, Lnk.ForeColor);
                    Refresh();
                    if (OpacityMine==0)
                    {
                        Hide();
                    }
                }//REDRAW
                

                isDrwing = false;

            }
        }//FUNKCNI


        public struct DrwOverTime
        {

            private int pcty;
            public int MOpacity { get { return pcty; } }

            
            public DrwOverTime(int chngOpacity)
            {
                pcty = chngOpacity;
                
            }
        }
    }
}
