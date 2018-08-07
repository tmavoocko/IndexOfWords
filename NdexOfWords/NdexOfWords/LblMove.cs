using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Xml.Linq;


namespace NdexOfWords
{
    public class LblMove:Button
    {
        public bool FncActive = false;
        public Color BClr;
        public Color FrClr;
        public BorderStyle Brdr = BorderStyle.FixedSingle;
        public Control Lnk;
        public bool Lnkadded=false;
        public PnTxt Naibor;
        public bool Naiboradded = false;
        private Point mdFrameLoc;
        private Point mouseDownLoc;
        private bool frameMoving;
        public  bool FrLocked = true;
        public Size OriginSize;
        public Point OriLoca;
        public LblMove(Point p,Size s, string xt,Color bclr ,Color fclr,Font fnt)
        {
            DoubleBuffered = true;
            Location = p; OriLoca = Location; Size = s;//new Size(s.Width * Cnst.Source.ZoomPerc / 100, s.Height * Cnst.Source.ZoomPerc / 100);
            OriginSize = new Size(s.Width, s.Height);
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor =BClr= bclr; ForeColor=FrClr = fclr; Font =fnt;
            
            Location = p; Size = s; Text = xt;

            if (FrLocked)
            {
                ToolTip hint = new ToolTip();
                hint.SetToolTip(this, "Locked");
                hint.BackColor = Color.Gray;
                hint.ForeColor = Color.OrangeRed;
            }
            else
            {
                ToolTip hint = new ToolTip();
                hint.SetToolTip(this, "Movable");
                hint.BackColor = Color.Gray;
                hint.ForeColor = Color.OrangeRed;
            }
            MouseDown += (sender, e) =>
            {
                if (FrLocked)
                {
                    Brdr = BorderStyle.Fixed3D;
                    BackColor = Color.FromArgb(255, Color.FromArgb(255,92, 45, 37));
                    FncSelect();
                    
                    mdFrameLoc = Location;
                    mouseDownLoc = e.Location;
                }
                else
                {
                    mouseDownLoc = e.Location;

                    if (e.Button == MouseButtons.Left) frameMoving = true;
                    BringToFront();
                }

            };
            MouseMove += (sender, e) =>
            {
                if (frameMoving)
                {
                    int left = Left + (e.X - mouseDownLoc.X);
                    int top = Top + (e.Y - mouseDownLoc.Y);
                    if (top < 0) top = 0;
                    if (left < 0) left = 0;
                    Top = top;
                    Left = left;
                    //OriLoca = new Point(left * 100 / Constants.Source.ZoomPerc, top * 100 / Constants.Source.ZoomPerc);
                }
            };
            MouseUp += (sender, e) =>
            {
                frameMoving = false;
                switch (e.Button)
                {
                    case MouseButtons.Left:

                        Brdr = BorderStyle.FixedSingle;
                        BackColor = BClr;
                        break;
                    case MouseButtons.Middle:
                        Brdr = BorderStyle.FixedSingle;
                        BackColor = BClr;
                        //Point parentLoc = new Point(parent.Left + Left + e.Location.X, parent.Top + Top + e.Location.Y);
                        if (Location == mdFrameLoc)
                        {
                            
                        }
                        
                        break;
                    case MouseButtons.Right:
                        Brdr = BorderStyle.FixedSingle;
                        BackColor = BClr;
                        //MessageBox.Show("A");
                        if (Location == mdFrameLoc)
                        {                       
                            //Point LcatOnParentControl = new Point(0, 0);
                            
                            try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                            try { Cnst.justOne.Dispose(); } catch (Exception) { }
                            
                            //Cnst.justOne = new CntxtMenu(LcatOnParentControl, this);
                            //Size = Cnst.justOne.Size;
                        }
                        break;
                    default:
                        break;
                }
            };
            //MouseHover += (sender, e) =>
            //{

            //    BackColor = FrClr;
            //    ForeColor = BClr;
            //};
            //MouseLeave+= (sender, e) =>
            //{
            //    BackColor = BClr;
            //    ForeColor = FrClr;

            //};
            //MFncInUse.

            BringToFront();
            //myParent.Controls.Add(this);
            
        }
        private int phase = 0;
        public int Phase
        {
            get { return phase; }
            set
            {
                phase = value;
                
                if (phase > 1) phase = 0;
                switch (phase)
                {

                    case 1:
                        //SwpColors();
                        //FncActive = true;
                        break;
                    case 0:
                        //OrgnColors();
                        //FncActive = false;
                        break;
                    default:
                        break;
                }
                
            }
        }
        public void FncSelect()
        {
            //set facing
            Phase++;
            // child facing
            
        }
        public void Rst()
        {
            Size = OriginSize;
            Location = OriLoca;
        }
        public void LinkMe(Control lnk) 
        {
            Lnk = lnk;
            Lnkadded = true;
        }
        public void NaiborMe(PnTxt nbr)
        {
            Naibor = nbr;
            Naiboradded = true;
        }
        public Color ClrHolder;
        public void SwpColors()
        {
            ClrHolder = BackColor;
            BackColor = ForeColor;
            ForeColor = ClrHolder;
        }
        public void OrgnColors()
        {
            
            ForeColor = FrClr;
            BackColor = BClr;
        }
        public void HdMSelf()
        {

            if (Cnst.Ticker.Enabled!=true)
            {
                Cnst.Ticker.Interval = 1000;
                Cnst.Ticker.Start();
                Cnst.Ticker.Tick += (Sender, f) =>
                {
                    Cnst.Ticker.Stop();
                    //afterTck
                    Hide();
                };
            }
        }
    }






}
