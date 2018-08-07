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
    public class DsgInsHrz : Panel
    {
        public int CntrlsCount = 0;
        public VScrollBar vScrollBar = new VScrollBar();
        public HScrollBar hScrollBar = new HScrollBar();
        //public DsgnCnvHldr DsgCore = new DsgnCnvHldr("Clnt");
        public VScrollBar MVScroll = new VScrollBar();
        public AxixsPnl AxxX = new AxixsPnl("X");
        public Point SpwLc = new Point();
        private Point mouseDownLoc;
        public Color ClrInver;
        public Color ClrdBck = Color.FromArgb(32, 178, 170);
        public Color DsgnFrColor;
        public Font myFont = new Font("Cambria", 14, FontStyle.Bold);
        public DsgInsHrz()//Form1 parent
        {
            BackColor = ClrdBck;
            AutoScroll = false;
            Location = new Point(0, ClientSize.Height - Height);
            BorderStyle = BorderStyle.None;
            BringToFront();
            DsgInsHrzDsgn();
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
        public void DsgInsHrzDsgn()
        {
            BringToFront();
            
            BorderStyle = BorderStyle.None;
            DoubleBuffered = true;
            MyClrInvrt(ClrdBck);
            {//Y,X,Corner panels
                DsgnFrColor = Color.FromArgb(32, 78, 70);
                AxxX.Size = new Size(Width, 63);
                AxxX.Location = new Point(0, Height-AxxX.Height);
                AxxX.BringToFront();
                AxxX.Paint += (sender, e) => { AxxX.XDraw(e.Graphics); };
                AxxX.Dock = DockStyle.Top;
                AxxX.Enabled = false;
                Controls.Add(AxxX);
                ////UserPanel DsgCore = new UserPanel(this);
                //DsgCore.Location = new Point(0, AxxX.Bottom);
                ////DsgCore.VerticalScroll.Value = 100;
                //DsgCore.Size = new Size(Width-20, Height-20 - AxxX.Height);
                ////DsgCore.Dock = DockStyle.Fill;
                //DsgCore.BringToFront();
                

                //Controls.Add(DsgCore);
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
                    //Cnst.justOne = new CntxtMenu(parentLoc, this);
                    //Cnst.justOne.BringToFront();
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
                //MyCnvsDrw.Refresh();
            };
            

        }
        
        public void MyClrInvrt(Color cl)
        {
            ClrInver = Color.FromArgb(cl.ToArgb() ^ 0xffffff);
            ForeColor = ClrInver;
        }
       







    }
}
