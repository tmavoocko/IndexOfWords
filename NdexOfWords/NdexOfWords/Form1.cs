using System;
//using System.CollectionCnst.S.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.WindowCnst.S.Forms;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace NdexOfWords
{
    
    public partial class Form1 : Form
    {
        //public Hdr Header;
        public Color ClrdBck = Color.FromArgb(32, 178, 170);
        public Color DsgnFrColor = Color.FromArgb(32, 78, 70);

        //public DrwFrmCntrls DrCntForm = new DrwFrmCntrls();
        public DsgnInsVrtc DsgVrt = new DsgnInsVrtc();
        //public MCnvs AxxX = new MCnvs();
        //public MCnvs AxxY = new MCnvs();
        //public MCnvs AxxCrrs = new MCnvs();
        //public AxixsPnl AxxX = new AxixsPnl("X");

        private Graphics g;
        public Rectangle RgnMouseClic;
        public Region OnlMouseClic;
        public Point SpwLc = new Point();
        public int ZoomPerc = 100;
        public int FntSize = 10;
        public Font myFont = new Font("Cambria", 15, FontStyle.Bold);
        public Timer Ticker = new Timer();
        public static RichTextBox GthData = new RichTextBox();
        public static Label LblX1 = new Label(); public static Label LblX2 = new Label();
        public static Label LblY1 = new Label(); public static Label LblY2 = new Label();
        public static TextBox Input = new TextBox();
        public static Label Solve = new Label();
        public static Panel myScrollPan = new Panel();
        public string Mss = "";

        public static bool DrwRec = false;
        public static bool FrmMoving = false;
        public bool ClckdBefore = false;
        //public PcBResizable[] myPcbRs = new PcBResizable[0];
        private Point mouseDownLoc;
        private static int maxZoom = 600; private static int minZoom = 40;
        public int[] Inpt;
        public Panel scIntrBackground = new Panel();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Frequencies Table - D.Konicek - zadani treti";
            g = CreateGraphics();
            Cnst.RegInstance(this);
            InitMensFillIt();
            //hints stratup controls

            //hints stratup controls
        }
        private void InitMensFillIt()
        {

            //events
            MouseDown += (sender, e) =>
            {
                mouseDownLoc = e.Location;

            };

            MouseUp += (sender, e) =>
            {

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
                    Cnst.justOne = new CntxtMenu(parentLoc, this);
                    Cnst.justOne.BringToFront();
                }
            };
            //events
            //Functions called:
            //ScSize();
            //IntrScr();//Functions called:
        }

    }
    //Classes other

    public class MenuesContext : Panel
    {
        public int FntSize = 15;
        public Font myFont = new Font("Cambria", 15, FontStyle.Bold);

        public int W = 150;
        public int H = 30;



    }//---This class is for inheriting inside setings
     //This class is for inheriting inside setings
}
