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

namespace NdexOfWords
{
    public class BtnMy : Button
    {
        public Panel ShadeOwer = new Panel();
        public BorderStyle BrdrStyle = new BorderStyle();
        public Control Lnk;
        public Control LnkKvdr;
        public bool Lnkadded = false;
        private Point mdFrameLoc;
        private Point mouseDownLoc;
        private bool frameMoving;
        public bool FrLocked = true;
        public Size OriginSize;
        public Point OriLoca;
        public BtnMy(Point p, Size s, string xt, Color bclr, Color fclr, Font fnt)
        {
            DoubleBuffered = true;
            Location = OriLoca = p;  //new Size(s.Width * Cnst.Source.ZoomPerc / 100, s.Height * Cnst.Source.ZoomPerc / 100);
            Size = OriginSize = s;
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = bclr; ForeColor = fclr; Font = fnt;
            BrdrStyle = BorderStyle.None;
            Location = p; ShadeOwer.Size = Size = s; Text = xt;
            ShadeOwer.Location = new Point(0, 0);
            ShadeOwer.BackColor = Color.Transparent;
            ShadeOwer.SendToBack();
            Controls.Add(ShadeOwer);
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

                        break;
                    case MouseButtons.Middle:
                        //Point parentLoc = new Point(parent.Left + Left + e.Location.X, parent.Top + Top + e.Location.Y);
                        if (Location == mdFrameLoc)
                        {

                        }

                        break;
                    case MouseButtons.Right:
                        //MessageBox.Show("A");
                        if (Location == mdFrameLoc)
                        {
                            
                        }
                        break;
                    default:
                        break;
                }
            };


            BringToFront();
            //myParent.Controls.Add(this);

        }
        public void Rst()
        {
            Size = OriginSize;
            Location = OriLoca;
        }
        public void LinkPrsm(Control lnk)
        {
            Lnk = lnk;
            
            Lnkadded = true;
        }
        public void LinkKvdr(Control lnk)//Prism lnk)
        {
            //Lnk = lnk;
            LnkKvdr = lnk;
            Lnkadded = true;
        }
    }
}
