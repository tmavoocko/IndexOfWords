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

namespace NdexOfWords
{
    public class DsgnInsVrtc:Panel
    {
        
        public AxixsPnl AxxY = new AxixsPnl("Y");
        public AxixsPnl AxxCrss3D = new AxixsPnl("Crss3D");
        //public AxixsPnl AxxCrss2D = new AxixsPnl("Crss2D");
        public DsgInsHrz DsgHrz = new DsgInsHrz();
        
        public Point SpwLc = new Point();
        public static Panel Space = new Panel();
        //public Form1 MyParent;
        private Point mouseDownLoc;
        public Color ClrInver;
        public Color ClrdBck = Color.FromArgb(32, 178, 170);
        public Color DsgnFrColor;
        public Font myFont = new Font("Cambria", 14, FontStyle.Bold);
        public DsgnInsVrtc()//Form1 parent
        {
            BackColor = ClrdBck;
            Location = new Point(0, ClientSize.Height - Height);
            BorderStyle = BorderStyle.None;
            BringToFront();
            DsgnInsVrtcDsgn();
            //ClientSizeChanged += (sender, e) => { relocatePanel(); };

        }
        public void relocatePanel()
        {//pozicovani kreslici plochy
         //Size = new Size(parent.ClientRectangle.Width, parent.ClientRectangle.Height * 90 / 100);
         //Location = new Point(0, parent.ClientRectangle.Height - Height);

            //MessageBox.Show(ClientSize.ToString());
            //Size = ClientSize;
            //Location = new Point(50, ClientSize.Height - Cnst.LftOverSize.Height);
            //Refresh();
        }
        public void DsgnInsVrtcDsgn()
        {
            BringToFront();
            BackColor = Color.FromArgb(45, ClrdBck);
            BorderStyle = BorderStyle.None;
            DoubleBuffered = true;
            MyClrInvrt(ClrdBck);
            {//Y,X,Corner panels
                AxxCrss3D.Size = new Size(Width / 2, Height / 2);
                AxxCrss3D.Location = new Point(0, 0); AxxCrss3D.BringToFront();
                AxxCrss3D.Axe = "";
                //AxxCrss3D.Paint += (sender, e) => { AxxCrss3D.Crss3DDraw(e.Graphics); };
                AxxCrss3D.Enabled = false;
                Controls.Add(AxxCrss3D);
                AxxCrss3D.BringToFront();

                DsgnFrColor = Color.FromArgb(32, 78, 70);
                AxxY.Size = new Size(88, 88);
                AxxY.Location = new Point(AxxCrss3D.Left, AxxCrss3D.Bottom); AxxY.BringToFront();
                AxxY.Axe = "";
                //AxxY.Paint += (sender, e) => { AxxY.YDraw(e.Graphics); };
                AxxY.Enabled = false;
                Controls.Add(AxxY);
                

                
                //MyParent.DsgVrt.AxxCrss3D.BringToFront();
                //MyParent.DsgVrt.AxxCrss2D.SendToBack();
                //MyParent.DsgVrt.Invalidate();

                DsgHrz.Size = new Size(AxxY.Height+AxxCrss3D.Height, Width-AxxCrss3D.Width);
                DsgHrz.BackColor = Color.Red;
                DsgHrz.Location = new Point(AxxCrss3D.Left, AxxCrss3D.Top);
                DsgHrz.BringToFront();
                //DsgHrz.Paint += (sender, e) => { DrwSpc.SpcDraw(e.Graphics); };
                
                Controls.Add(DsgHrz);
                DsgHrz.CntrlsCount = DsgHrz.Controls.Count;
            } //Y,X,Corner panels
            MouseDown += (sender, e) =>
            {
                //MessageBox.Show(e.Location.ToString());
                mouseDownLoc = e.Location;

            };

            MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    Point parentLoc = new Point(e.Location.X, e.Location.Y);
                    //justOne = new Fr1ContextMenu(e.Location, this);
                    //justOne.Location = new Point(e.Location.X - 72, e.Location.Y - 22);
                    //justOne.BringToFront();
                    try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                    try { Cnst.justOne.Dispose(); } catch (Exception) { }
                    //Point myP = Cursor.Position;
                    //CntxtMenu myCP = new CntxtMenu(myP, this);
                    Cnst.justOne = new CntxtMenu(parentLoc, this);
                    Cnst.justOne.BringToFront();
                }
                
            };
            MouseWheel += (sender, e) =>
            {
                //int oldZoom = 100;
                //int newZoom = e.Delta * SystemInformation.MouseWheelScrollLines / 30 + ZoomPerc;
                //ZoomPerc += e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                //if (newZoom < minZoom) newZoom = minZoom;
                //if (newZoom > maxZoom) newZoom = maxZoom;
                //foreach (Control p in Controls)
                //{
                //    p.Location = new Point(p.Location.X * newZoom / oldZoom, p.Location.Y * newZoom / oldZoom);
                //    p.Size = new Size(p.Size.Width * newZoom / oldZoom, p.Size.Height * newZoom / oldZoom);
                //    //MessageBox.Show(p.Location.ToString() +Environment.NewLine + p.Size.ToString());
                //}
            };

            KeyUp += (sender, e) =>
            {
                if (e.KeyData == Keys.Enter)
                {
                    //No mdFrameLoc - because it is on Form1                        
                    Point parentLoc = new Point(0, 0);
                    try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                    try { Cnst.justOne.Dispose(); } catch (Exception) { }
                    //Cnst.justOne = new CntxtMenu(parentLoc, this);
                    //Cnst.justOne.BringToFront();
                }
            };
            Paint += (sender, e) =>
            {
                //Draw(e.Graphics);
            };
            
            
        }
        
        public void MyClrInvrt(Color cl)
        {
            ClrInver = Color.FromArgb(cl.ToArgb() ^ 0xffffff);
            ForeColor = ClrInver;
        }
        







    }
}
