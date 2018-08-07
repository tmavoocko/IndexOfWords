
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
using System.Collections;
using System.Text.RegularExpressions;
//using System.Windows.Shapes;

namespace NdexOfWords
{
    public class Hdr2 : Panel
    {
        public Dictionary<string, List<Tuple<int, int>>> validWords = new Dictionary<string, List<Tuple<int, int>>>();
        //public int FncsCtive = new int();
        public NumericUpDown UpDownMoveX = new NumericUpDown();
        public NumericUpDown UpDownMoveY = new NumericUpDown();
        public NumericUpDown UpDownMoveZ = new NumericUpDown();
        public PnTxt UsrMoveX; public PnTxt UsrMoveY; public PnTxt UsrMoveZ;
        public Control KvdrSlct = null;
        public Control PrsmSlct = null;
        //public DtString Cmpairer = new DtString();
        public List<List<DtString>> DctionaryA = new List<List<DtString>>();
        public List<DtString> ADctAllWrds = new List<DtString>();
        public List<DtString> ADctionaryWrds = new List<DtString>();
        public List<DtString> ADctionaryLine = new List<DtString>();
        public List<DtString> BDctionaryLine = new List<DtString>();
        public List<List<DtString>> DctionaryB = new List<List<DtString>>();
        public List<string> CntrLines = new List<string>();
        public Point SpwnLck = new Point();
        public Point X1; public Point X2; public Point Y1; public Point Y2;
        public Point X3; public Point X4; public Point Y3; public Point Y4;
        public PnTxt Pn0rgn; public PnTxt Pn1rgn; public PnTxt Pn2;
        public PnTxt Pn3; public PnTxt Pn4; public PnTxt Pn5;
        public Size Szz; public Panel Hldr = new Panel();
        public int BttPrRw = 0;
        public int[] Inpt;
        public System.Drawing.Rectangle DsgnRct = new System.Drawing.Rectangle();
        //public bool To2D = true;
        //public bool To3D = false;

        public Font MFnt = new Font("Litograph", 10, FontStyle.Bold);
        public Font LddTxtFnt = new Font("Litograph", 9, FontStyle.Italic| FontStyle.Bold| FontStyle.Underline);
        public Color ClrInver;
        //public Color ClrdBck = Color.FromArgb(32, 178, 170);
        //public Color ClrdFrnt = Color.FromArgb(32, 78, 70);
        public Color ClrdBck = Color.FromArgb(132, 45, 37);
        public Color ClrdFrnt = Color.FromArgb(232, 145, 137);
        //public Color ClrdFrnt = Color.Chocolate;
        public Control MyParent;
        public Hdr2(Control parent)
        {
            MyParent = parent;
            HdrDsgn();
            MyParent.Controls.Add(this);
            MyParent.ClientSizeChanged += (sender, e) => { RposCntrols(); };

        }
        public void RposCntrols()
        {//Position of added controls
            Invalidate();
            //MessageBox.Show(Cnst.Source.ClientRectangle.Size.ToString());

            foreach (Control c in Controls)
            {
                c.ForeColor = ClrdFrnt;
                c.Invalidate();
                if (c.Controls.Count > 0)
                {
                    foreach (Control Cc in Controls)
                    {
                        Cc.ForeColor = ClrdFrnt;
                        Cc.Invalidate();
                        if (Cc.Controls.Count > 0)
                        {
                            foreach (Control Ccc in Controls)
                            {
                                Ccc.ForeColor = ClrdFrnt;
                                Ccc.Invalidate();
                            }
                        }
                    }

                }
            }
            //Controls.Clear();
            //HdrDsgn();
        }
        public void HdrDsgn()
        {

            Size = new Size(MyParent.Width, MyParent.Height / 8);
            Invalidate();
            //AutoSize = true;
            BringToFront();
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Top;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.Transparent;
            BackColor = Color.FromArgb(45, ClrdBck);
            //MyClrInvrt(ClrdBck);

            SpwnLck = new Point(2, 2);
            BttPrRw = 2;
            Szz = new Size(Width / BttPrRw, (Height)); int fnt = 21;
            Font myFont = MFnt;
            //Font myFont = new Font("Cambria", fnt, FontStyle.Bold);
            if (Cnst.HdrToSet == true)
            {
                try//Design on StartUp 
                {
                    LblMove lstCntrl = null;
                    Control lstNtroll = null;


                    //Buttons
                    LblMove fl = lstCntrl = new LblMove(SpwnLck, Szz, "File", ClrdBck, ClrdFrnt, myFont);
                    lstCntrl.MouseDown += (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                            try { Cnst.justOne.Dispose(); } catch (Exception) { }

                            {//MenuStrip
                                MenuStrip tsdd = new MenuStrip();
                                
                                tsdd.BackColor =  ClrdFrnt;
                                tsdd.ForeColor = Color.FromArgb(197, ClrdBck);
                                tsdd.Text = "File Menu";
                                tsdd.Font = MFnt;
                                tsdd.MouseLeave += (sndr, dr) =>
                                {
                                    try
                                    {
                                        //tsdd.Dispose();
                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }

                                };


                                tsdd.Items.Add("Open");
                                tsdd.Items[0].Font = LddTxtFnt;
                                tsdd.Items[0].MouseDown += (senderb, b) => 
                                {
                                    {//OpenFile
                                        {//OpenFile
                                            if (Cnst.B.UsVl.Text=="")
                                            {
                                                Cnst.LddFileName = "";
                                                Cnst.LddFile = "";
                                                string autoPath = Application.StartupPath;
                                                autoPath += "\\User save";
                                                // OPEN FILE DIALOG - LOAD A PICTURE BY YOUR OWN CHOICE WHILE PROGRAM IS RUNNING ------------------------------------------------
                                                OpenFileDialog ofd = new OpenFileDialog();
                                                //Initial Directory
                                                ofd.InitialDirectory = autoPath;
                                                // image filters  
                                                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                                                if (ofd.ShowDialog() == DialogResult.OK)
                                                {
                                                    // display text in rchTxt box      
                                                    //Bitmap texIn = new Bitmap(ofd.FileName);
                                                    StreamReader sr = new StreamReader(ofd.FileName);

                                                    string pks = sr.ReadToEnd();
                                                    Cnst.LddFileName = ofd.SafeFileName;
                                                    //MessageBox.Show(Cnst.LddFileName);


                                                    if (pks.Contains(Environment.NewLine + "-------------------------------------------" + Environment.NewLine))
                                                    {
                                                        //List<string> prepFile = pks.Split('\n\r');
                                                        string[] stringSeparators = new string[] { "\r\n" };
                                                        List<string> prepFile = pks.Split(stringSeparators, StringSplitOptions.None).ToList();
                                                        try
                                                        {
                                                            Cnst.LddFile = prepFile[0];//1#kill
                                                        }
                                                        catch (Exception) { }//Cnst.LddFile
                                                        
                                                        
                                                        try
                                                        {
                                                            Cnst.A.UsVl.Text = prepFile[0];//1#kill
                                                        }
                                                        catch (Exception) { }//Cnst.A
                                                        try
                                                        {
                                                            Cnst.B.UsVl.Text = prepFile[0];//1#kill
                                                        }
                                                        catch (Exception) { }//Cnst.B
                                                        
                                                        Cnst.A.UsVl.SelectAll();
                                                        Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                                        Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                                        //Cnst.A.UsVl.Invalidate();
                                                        MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                        MyParent.Invalidate();
                                                        try
                                                        {
                                                            Cnst.C.UsVl.Text = prepFile[2];//3#last
                                                        }
                                                        catch (Exception) { }//Cnst.C
                                                        
                                                        //Cnst.C.UsVl.Invalidate();
                                                        try
                                                        {Cnst.D.UsVl.Text = prepFile[3];//4#does not exist
                                                        }
                                                        catch (Exception) { }
                                                        //Cnst.D.UsVl.Invalidate();

                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            Cnst.LddFile = pks;//1#kill
                                                        }
                                                        catch (Exception) { }//Cnst.LddFile
                                                        try
                                                        {
                                                            Cnst.A.UsVl.Text = pks;//1#kill
                                                        }
                                                        catch (Exception) { }//Cnst.A
                                                        try
                                                        {
                                                            Cnst.B.UsVl.Text = pks;//1#kill
                                                        }
                                                        catch (Exception) { }//Cnst.B
                                                        Cnst.A.UsVl.SelectAll();
                                                        Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                                        Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                                        Cnst.A.UsVl.Invalidate();
                                                        tsdd.Dispose();
                                                        MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                        MyParent.Invalidate();
                                                        MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                        MyParent.Invalidate();
                                                        
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                {//Dialog
                                                    DialogResult dialogResult = MessageBox.Show("Discard changes ?", "Discard changes", MessageBoxButtons.YesNo);
                                                    if (dialogResult == DialogResult.Yes)
                                                    {
                                                        Cnst.LddFileName = "";
                                                        Cnst.LddFile = "";
                                                        string autoPath = Application.StartupPath;
                                                        autoPath += "\\User save";
                                                        // OPEN FILE DIALOG - LOAD A PICTURE BY YOUR OWN CHOICE WHILE PROGRAM IS RUNNING ------------------------------------------------
                                                        OpenFileDialog ofd = new OpenFileDialog();
                                                        //Initial Directory
                                                        ofd.InitialDirectory = autoPath;
                                                        // image filters  
                                                        ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                                                        if (ofd.ShowDialog() == DialogResult.OK)
                                                        {
                                                            // display text in rchTxt box      
                                                            //Bitmap texIn = new Bitmap(ofd.FileName);
                                                            StreamReader sr = new StreamReader(ofd.FileName);

                                                            string pks = sr.ReadToEnd();
                                                            Cnst.LddFileName = ofd.SafeFileName;
                                                            //MessageBox.Show(Cnst.LddFileName);
                                                            if (pks.Contains(Environment.NewLine + "-------------------------------------------" + Environment.NewLine))
                                                            {
                                                                //List<string> prepFile = pks.Split('\n\r');
                                                                string[] stringSeparators = new string[] { "\r\n" };
                                                                List<string> prepFile = pks.Split(stringSeparators, StringSplitOptions.None).ToList();
                                                                try
                                                                {
                                                                    Cnst.LddFile = prepFile[0];//1#kill
                                                                }
                                                                catch (Exception) { }//Cnst.LddFile


                                                                try
                                                                {
                                                                    Cnst.A.UsVl.Text = prepFile[0];//1#kill
                                                                }
                                                                catch (Exception) { }//Cnst.A
                                                                try
                                                                {
                                                                    Cnst.B.UsVl.Text = prepFile[0];//1#kill
                                                                }
                                                                catch (Exception) { }//Cnst.B

                                                                Cnst.A.UsVl.SelectAll();
                                                                Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                                                Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                                                //Cnst.A.UsVl.Invalidate();
                                                                MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                                MyParent.Invalidate();
                                                                try
                                                                {
                                                                    Cnst.C.UsVl.Text = prepFile[2];//3#last
                                                                }
                                                                catch (Exception) { }//Cnst.C

                                                                //Cnst.C.UsVl.Invalidate();
                                                                try
                                                                {
                                                                    Cnst.D.UsVl.Text = prepFile[3];//4#does not exist
                                                                }
                                                                catch (Exception) { }
                                                                //Cnst.D.UsVl.Invalidate();

                                                            }
                                                            else
                                                            {
                                                                try
                                                                {
                                                                    Cnst.LddFile = pks;//1#kill
                                                                }
                                                                catch (Exception) { }//Cnst.LddFile
                                                                try
                                                                {
                                                                    Cnst.A.UsVl.Text = pks;//1#kill
                                                                }
                                                                catch (Exception) { }//Cnst.A
                                                                try
                                                                {
                                                                    Cnst.B.UsVl.Text = pks;//1#kill
                                                                }
                                                                catch (Exception) { }//Cnst.B
                                                                Cnst.A.UsVl.SelectAll();
                                                                Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                                                Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                                                Cnst.A.UsVl.Invalidate();
                                                                tsdd.Dispose();
                                                                MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                                MyParent.Invalidate();
                                                                MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                                MyParent.Invalidate();

                                                            }

                                                            //if (pks.Contains(Environment.NewLine + "-------------------------------------------" + Environment.NewLine))
                                                            //{
                                                            //    //List<string> prepFile = pks.Split('\n\r');
                                                            //    string[] stringSeparators = new string[] { "\r\n" };
                                                            //    List<string> prepFile = pks.Split(stringSeparators, StringSplitOptions.None).ToList();
                                                            //    Cnst.LddFile = prepFile[0];
                                                            //    Cnst.A.UsVl.Text = prepFile[0];//1#kill
                                                            //    Cnst.B.UsVl.Text = prepFile[0];
                                                            //    Cnst.A.UsVl.SelectAll();
                                                            //    Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                                            //    Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                                            //    Cnst.A.UsVl.DeselectAll();
                                                            //    //Cnst.A.UsVl.Invalidate();
                                                            //    MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                            //    MyParent.Invalidate();
                                                            //    Cnst.C.UsVl.Text = prepFile[2];//3#kill
                                                            //    Cnst.C.UsVl.Invalidate();
                                                            //    try
                                                            //    {
                                                            //        Cnst.D.UsVl.Text = prepFile[3];//4#does not exist
                                                            //    }
                                                            //    catch (Exception){}

                                                            //    Cnst.D.UsVl.Invalidate();

                                                            //}
                                                            //else
                                                            //{
                                                            //    Cnst.LddFile = pks;

                                                            //    Cnst.A.UsVl.Text = pks;
                                                            //    Cnst.B.UsVl.Text = pks;
                                                            //    Cnst.A.UsVl.SelectAll();
                                                            //    Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                                            //    Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                                            //    Cnst.A.UsVl.DeselectAll();
                                                            //    //Cnst.A.UsVl.Invalidate();
                                                            //    tsdd.Dispose();
                                                            //    MyParent.Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                                            //    MyParent.Invalidate();
                                                            //}
                                                        }
                                                    }
                                                    else if (dialogResult == DialogResult.No)
                                                    {
                                                        
                                                    }
                                                }//Dialog
                                                
                                            }
                                        }//OpenFile
                                    }//OpenFile
                                };//Open

                                tsdd.Items.Add("Save");
                                tsdd.Items[1].Font=LddTxtFnt;
                                tsdd.Items[1].MouseDown += (senderb, b) =>
                                {
                                    {//Save
                                        {//Save
                                            string autoPath = Application.StartupPath;
                                            
                                            autoPath += "\\User save";
                                            SaveFileDialog svFl = new SaveFileDialog();
                                            svFl.InitialDirectory = autoPath;

                                            {//Options for save
                                                {//filename
                                                    if (Cnst.LddFileName != "")
                                                    {
                                                        //string GetFileNameWithoutExtension(string pat)
                                                        svFl.FileName = Cnst.LddFileName;//.TrimEnd('\\');//default file name
                                                        //svFl.DefaultExt = ".txt"; //default file extension
                                                        svFl.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                                                    }//filename
                                                    else
                                                    {
                                                        svFl.FileName = "Untitled1"; //default file name
                                                        svFl.DefaultExt = ".txt"; //default file extension
                                                        svFl.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                                                    }//filename
                                                }//filename
                                                {//SwitchOutputString
                                                    if (Cnst.LddFileName != "")
                                                    {
                                                        svFl.FileName = Cnst.LddFileName;//default file name
                                                        svFl.DefaultExt = ".txt"; //default file extension
                                                        svFl.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                                                    }//filename
                                                    else
                                                    {
                                                        svFl.FileName = "Untitled1"; //default file name
                                                        svFl.DefaultExt = ".txt"; //default file extension
                                                        svFl.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                                                    }//filename
                                                }//SwitchOutputString

                                            }//Options for save
                                            if (svFl.ShowDialog() == DialogResult.OK)
                                            {
                                                if (Cnst.LddFileName != "")
                                                {
                                                    try
                                                    {
                                                        // Determine whether the directory existCnst.S.
                                                        if (File.Exists(svFl.FileName))
                                                        {
                                                            string output0 = Cnst.B.UsVl.Text + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + Cnst.C.UsVl.Text + "-------------------------------------------" + Environment.NewLine + Cnst.D.UsVl.Text;

                                                            File.WriteAllText(svFl.FileName, output0);
                                                        }

                                                    }
                                                    catch (Exception z)
                                                    {
                                                        MessageBox.Show("The process failed: {0}", z.ToString());
                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        // Determine whether the directory existCnst.S.
                                                        if (File.Exists(svFl.FileName))
                                                        {
                                                            MessageBox.Show("That path exists already.");
                                                            return;
                                                        }
                                                        string output0 = Cnst.B.UsVl.Text + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + Cnst.C.UsVl.Text + "-------------------------------------------" + Environment.NewLine + Cnst.D.UsVl.Text;

                                                        File.WriteAllText(svFl.FileName, output0);
                                                    }
                                                    catch (Exception z)
                                                    {
                                                        MessageBox.Show("The process failed: {0}", z.ToString());
                                                    }
                                                    finally { }
                                                }

                                                //autoPath += "//";
                                                //autoPath += xprt.FileName;
                                                //MessageBox.Show(xprt.FileName );
                                                



                                            }
                                        }//Save
                                    }//Save
                                };//Save
                                

                                tsdd.Items.Add("New");
                                tsdd.Items[2].Font = LddTxtFnt;
                                tsdd.Items[2].MouseDown += (senderb, b) =>
                                {
                                    {//New
                                        {//New

                                            Cnst.LddFileName = "New";
                                            Cnst.A.UsVl.Text = "";
                                            Cnst.A.UsVl.BackColor = Color.Chocolate;
                                            Cnst.A.WrtnTxt = true;
                                            Cnst.A.UsVl.SelectAll();
                                            Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Left;
                                            Cnst.A.UsVl.SelectionFont = Cnst.A.Font;
                                            Cnst.A.UsVl.Focus();
                                            Cnst.A.Invalidate();
                                            Cnst.A.UsVl.Invalidate();
                                            Cnst.B.UsVl.Text = "";
                                            Cnst.B.UsVl.Invalidate();
                                            MyParent.Text = "New";
                                            MyParent.Invalidate();
                                        }//New
                                    }//New
                                };//New
                                //tsdd.Location = lstCntrl.Location;
                                //Controls.Add(tsdd);
                                if (fl.Controls.Count<1)
                                {
                                    fl.Controls.Add(tsdd);
                                }
                                
                                
                            }//MenuStrip
                           

                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                            try { Cnst.justOne.Dispose(); } catch (Exception) { }
                            try
                            {
                                {//MenuStrip DISPOSE

                                    foreach (MenuStrip tsdd in fl.Controls)
                                    {
                                        tsdd.Dispose();
                                    }
                                    fl.Controls.Clear();


                                }//MenuStrip DISPOSE
                            }
                            catch (Exception){}
                            

                        }
                    };
                    Controls.Add(lstCntrl);

                    SpwnLck = new Point(lstCntrl.Right, lstCntrl.Top);
                    LblMove sttstcs = lstCntrl = new LblMove(SpwnLck, Szz, "Statistics", ClrdBck, ClrdFrnt, myFont);
                    lstCntrl.MouseDown += (sender, e) =>
                    {
                        try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                        try { Cnst.justOne.Dispose(); } catch (Exception) { }
                        if (e.Button == MouseButtons.Left)
                        {

                            string prsTxt = "";
                            {//Dctionary- First try

                                {//DctionaryA
                                    {//DtStringDctionary
                                        //Dictionary<string, DtString> vldWords = new Dictionary<string, DtString>();
                                        //bool inOp = false;

                                        //{//ParseTEXT AND Fill THE DICTIONARY
                                        //    if (!inOp)
                                        //    {
                                        //        inOp = true;
                                        //        vldWords.Clear();
                                        //        string[] Lines = Cnst.A.UsVl.Text.Split('\n');
                                        //        for (int i = 0; i < Lines.Length; i++)
                                        //        {
                                        //            string lineClear = Regex.Replace(Lines[i], @"\t|\n|\r", " ");
                                        //            while (lineClear.Contains("  ")) lineClear = lineClear.Replace("  ", " ");
                                        //            string[] splitLine = lineClear.Split(' ');
                                        //            for (int j = 0; j < splitLine.Length; j++)
                                        //            {
                                        //                string word = splitLine[j].Trim(S.Separators);
                                        //                if (word.Length > 3 && !word.Any(char.IsNumber) && word != word.ToUpper())
                                        //                {
                                        //                    if (vldWords.Keys.Contains(word))
                                        //                    {
                                        //                        //Tuple<int, int> t = new Tuple<int, int>(i, j);
                                        //                        vldWords[word].Lines.Add(i);
                                        //                        vldWords[word].Indexes.Add(j);

                                        //                    }
                                        //                    else
                                        //                    {
                                        //                        DtString dtSt = new DtString();
                                        //                        dtSt.Wrd = word;
                                        //                        dtSt.Lines.Add(i);
                                        //                        dtSt.Indexes.Add(j);
                                        //                        dtSt.Line = i;
                                        //                        dtSt.Index = j;
                                        //                        //List<Tuple<int, int>> list = new List<Tuple<int, int>>();
                                        //                        //Tuple<int, int> t = new Tuple<int, int>(i, j);
                                        //                        //list.Add(t);
                                        //                        vldWords.Add(word, dtSt);
                                        //                    }
                                        //                }
                                        //            }
                                        //        }
                                        //        inOp = false;
                                        //    }
                                        //}//ParseTEXT AND Fill THE DICTIONARY


                                        ////Cnst.C.UsVl.Text = "";
                                        //foreach (KeyValuePair<string, DtString> kvp in vldWords)
                                        //{
                                        //    if (prsTxt != "") prsTxt += "\r\n";
                                        //    prsTxt += kvp.Key + " --(";
                                        //    string output = "";
                                        //    //if (output != "") output += ", ";

                                        //    //output += (kvp.Value.Line+1).ToString() + "/" + (kvp.Value.Index+1).ToString();
                                        //    foreach (int t in kvp.Value.Indexes)
                                        //    {
                                        //        //if (output != "") output += ", ";
                                        //        ////output += t.Item1.ToString() + "/" + t.Item2.ToString();
                                        //        //output += (kvp.Value.Lines[t] ).ToString() + "/" + (t ).ToString();

                                        //    }
                                        //    //foreach (Tuple<int, int> t in kvp.Value)
                                        //    //{
                                        //    //    if (output != "") output += ", ";
                                        //    //    output += t.Item1.ToString() + "/" + t.Item2.ToString();
                                        //    //}
                                        //    prsTxt += output + ")";
                                        //}
                                    }//DtStringDctionary











                                    //string[] stringSeparators = new string[] { "\r\n" };
                                    //string[] lines = Cnst.A.UsVl.Text.Split('\n');
                                    //CntrLines = Cnst.A.UsVl.Text.Split('\n').ToList();

                                    //string[] words = Cnst.A.UsVl.Text.Split(' ');
                                    ////MessageBox.Show("Nr. Of items in list: " + lines.Length); // 2 lines
                                    //string mss = "";
                                    //int line = 0;
                                    ////string[] prepLine;
                                    //for (int i = 0; i < CntrLines.Count; i++)
                                    //{
                                    //    line++;
                                    //    string[] prepLine = CntrLines[i].Split(' ');
                                    //    for (int j = 0; j < prepLine.Length; j++)
                                    //    {

                                    //        DtString wrd = new DtString()
                                    //        {
                                    //            Line = i,
                                    //            Index = CntrLines[i].IndexOf(prepLine[j]),
                                    //            Wrd = prepLine[j].Trim(S.Separators)

                                    //        };
                                    //        wrd.Indexes.Add(CntrLines[i].IndexOf(prepLine[j]));
                                    //        wrd.Lines.Add(i);
                                    //        //ADctAllWrds.Add(wrd);
                                    //        if (wrd.Wrd.Length > 3 && !wrd.Wrd.Any(char.IsNumber) && wrd.Wrd != wrd.Wrd.ToUpper())
                                    //        {
                                    //            ADctAllWrds.Add(wrd);
                                    //            for (int k = 0; k < ADctAllWrds.Count; k++)
                                    //            {
                                    //                if (ADctAllWrds[k].Wrd == wrd.Wrd)
                                    //                {
                                    //                    ADctAllWrds[k].Indexes.Add(wrd.Index);
                                    //                    ADctAllWrds[k].Lines.Add(i);
                                    //                    int ADctionaryWrdsPoss = 0;
                                    //                    foreach (var wr in ADctionaryWrds)
                                    //                    {
                                    //                        if (wr.Wrd == wrd.Wrd)
                                    //                        {
                                    //                            wr.Indexes.Add(wrd.Index);
                                    //                            wr.Lines.Add(i);
                                    //                        }
                                    //                        else
                                    //                        {
                                    //                            if (!ADctionaryWrds.Contains(wrd))
                                    //                            {
                                    //                                ADctionaryWrds.Add(wrd);
                                    //                            }

                                    //                        }
                                    //                    }
                                    //                    //ADctionaryWrds.ElementAt(ADctAllWrds[k])
                                    //                    wrd.Indexes = ADctAllWrds[k].Indexes;
                                    //                    wrd.Lines = ADctAllWrds[k].Lines;
                                    //                }
                                    //                else
                                    //                {
                                    //                    if (ADctAllWrds[k].Wrd != wrd.Wrd)
                                    //                    {

                                    //                        ADctionaryWrds.Add(wrd);


                                    //                    }
                                    //                }

                                    //            }
                                    //        }

                                    //        ADctionaryLine.Add(wrd);
                                    //    }
                                    //    DctionaryA.Add(ADctionaryLine);
                                    //    ADctionaryLine.Clear();
                                    //}
                                    //string msg = "ADctionaryWrds: ";
                                    //foreach (var wrd in ADctionaryWrds)
                                    //{
                                    //    msg += wrd.Wrd + Environment.NewLine;
                                    //}
                                    //foreach (var wrd in ADctAllWrds)
                                    //{
                                    //    mss += wrd.Wrd + Environment.NewLine;
                                    //}
                                    //MessageBox.Show(msg);//msg = "";
                                    //MessageBox.Show(mss); //msg = "";
                                    //MessageBox.Show("Nr. Of Lines in ABlock: " + CntrLines.Count().ToString()); // 2 lines

                                    //MessageBox.Show(" Lines in ABlock: " + CntrLines.Count().ToString()); // 2 lines
                                    //for (int i = 0; i < words.Length; i++)
                                    //{
                                    //    DtString dtstr = new DtString();
                                    //    //dtstr.Cnt = 1;
                                    //    dtstr.Index = Cnst.A.UsVl.Text.IndexOf(words[i]);
                                    //}
                                }//DctionaryA


                            }//Dctionary- First try

                            {////Statistics - First try
                                try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                                try { Cnst.justOne.Dispose(); } catch (Exception) { }

                                Cnst.B.UsVl.SelectAll();
                                Cnst.B.UsVl.SelectionBackColor = Cnst.B.UsVl.BackColor;
                                Cnst.B.UsVl.DeselectAll();
                                string output = "Provedené úpravy ve slovech:" + Environment.NewLine;
                                string mTputCnstD = "";
                                string mTputCnstC = "";
                                mTputCnstC += "Dictionary: " + Environment.NewLine + prsTxt+Environment.NewLine+"-------------";

                                {//Show statistics//changes to text from original file
                                    if (Cnst.A.UsVl.Text != "" && Cnst.B.UsVl.Text != "")//&& Cnst.A.UsVl.Text != Cnst.B.UsVl.Text)
                                    {
                                        List<int> pks = new List<int>();
                                        List<int> ChRgnsA = new List<int>();
                                        List<int> ChChngdB = new List<int>();
                                        List<int> IndexesOfChng = new List<int>();

                                        List<char> cmprdCh = new List<char>();
                                        //List<List<char>> cmprdChArrays = new List<List<char>>();
                                        string cmprdTxt = "";// to create -output?
                                        string cmprdIndex = "";// to create - exact map of changes?
                                        List<string> cmprdWrds = new List<string>();
                                        List<string> cmprdWrdsInverted = new List<string>();
                                        DtString Cmpairer = new DtString();
                                        List<DtString> MCmpairers = new List<DtString>();
                                        List<DtString> WrCMCmprrs = new List<DtString>();
                                        List<DtString[]> clctnMCmpairers = new List<DtString[]>();

                                        List<char> rgnsCh = new List<char>();
                                        List<string> rgnsWrds = new List<string>();
                                        List<DtString> rgnRpttn = new List<DtString>();
                                        string rgnsTxt = "";
                                        int crrctionRgn = 0;

                                        int crrctionChn = 0;
                                        string chngdTxt = "";
                                        List<char> chngdCh = new List<char>();
                                        List<string> chngdWrds = new List<string>();
                                        List<DtString> chngRpttn = new List<DtString>();
                                        List<string> ChngsStringsOneByOne = new List<string>();
                                        List<char> wrd = new List<char>();
                                        List<List<char>> wrdsChrArrays = new List<List<char>>();
                                        {//Fill
                                            if (Cnst.LddFile != "" && Cnst.LddFile == Cnst.A.UsVl.Text)
                                            {//FillList with ORIGINAL strings
                                             //MessageBox.Show("NEW CHANGES:"+ "LddFile.CompareTo(Cnst.B.UsVl.Text  -:" + Cnst.LddFile.CompareTo(Cnst.B.UsVl.Text).ToString());
                                                foreach (char ch in Cnst.LddFile.ToArray())
                                                {
                                                    rgnsCh.Add(ch);
                                                    //dbg += ch;
                                                }
                                                rgnsTxt = Cnst.LddFile;
                                                if (rgnsTxt!="")
                                                {
                                                    rgnsWrds = rgnsTxt.Split(' ').ToList();
                                                }
                                                
                                                //MessageBox.Show(dbg+"loaded OK");

                                            }
                                            else
                                            {
                                                
                                                foreach (char ch in Cnst.A.UsVl.Text.ToArray())
                                                {
                                                    rgnsCh.Add(ch);
                                                    //dbg += ch;
                                                }
                                                rgnsTxt = Cnst.A.UsVl.Text;
                                                if (rgnsTxt != "")
                                                {
                                                    rgnsWrds = rgnsTxt.Split(' ').ToList();
                                                }
                                                //MessageBox.Show(dbg + " //loaded OK");
                                            }//FillList with ORIGINAL strings
                                            foreach (char ch in Cnst.B.UsVl.Text.ToArray())
                                            {
                                                
                                                chngdCh.Add(ch);

                                                //dbg += ch;
                                            }
                                            chngdTxt = Cnst.B.UsVl.Text;
                                            if (chngdTxt != "")
                                            {
                                                chngdWrds = chngdTxt.Split(' ').ToList();
                                            }
                                        }//Fill
                                        {//Lengt correction
                                            if (Cnst.B.UsVl.Text.Length > Cnst.A.UsVl.Text.Length)
                                            {
                                                crrctionRgn = Cnst.B.UsVl.Text.Length - Cnst.A.UsVl.Text.Length;

                                            }
                                            if (Cnst.B.UsVl.Text.Length < Cnst.A.UsVl.Text.Length)
                                            {
                                                crrctionChn = Cnst.A.UsVl.Text.Length - Cnst.B.UsVl.Text.Length;

                                            }
                                            for (int i = 0; i < crrctionRgn; i++)
                                            {
                                                rgnsTxt += " ";
                                            }
                                            rgnsCh = rgnsTxt.ToCharArray().ToList();
                                            for (int i = 0; i < crrctionChn; i++)
                                            {
                                                chngdTxt += " ";
                                            }
                                            chngdCh = chngdTxt.ToCharArray().ToList();

                                        }// Lengt correction

                                        {//Fill compair
                                            
                                            {//Universal for  both!

                                                cmprdWrds = chngdWrds.Except(rgnsWrds).ToList();


                                                {//Find out repetition- Functional - beware if last char is {':',';','!','.','<','?','{','}','[',']','(',')','/','\'}

                                                    {//A
                                                        //string fndOutEqualWrds = "Equal words : '";
                                                        
                                                        //foreach (var wrdd in rgnsWrds)
                                                        //{//Find out all repetition

                                                        //    DtString AStrng = new DtString();
                                                        //    AStrng.Wrd = wrdd;
                                                        //    //AStrng.Cnt++;
                                                        //    MCmpairers.Add(AStrng);
                                                        //    WrCMCmprrs.Add(AStrng);


                                                        //    for (int i = 0; i < MCmpairers.Count; i++)
                                                        //    {
                                                        //        if (wrdd == MCmpairers[i].Wrd)
                                                        //        {
                                                        //            //MCmpairers[i].Cnt++;
                                                        //        }

                                                        //    }
                                                            


                                                            

                                                        //}//Find out all repetition A

                                                        //foreach (var dtStr in MCmpairers)
                                                        //{//Filter out all repetition
                                                        //    int cntActual = 0;
                                                        //    int mxCnt = 0;
                                                        //    mxCnt=MCmpairers.Max(mx => mx.Cnt);
                                                        //    cntActual = mxCnt;
                                                        //    if (dtStr.Cnt == mxCnt)
                                                        //    {
                                                        //        //cntActual = mxCnt;
                                                        //        rgnRpttn.Add(dtStr);

                                                        //        //if (cntActual-- != 1)
                                                        //        {
                                                        //            cntActual--;
                                                        //        }
                                                                
                                                        //        WrCMCmprrs.Remove(dtStr);
                                                        //        fndOutEqualWrds +=  dtStr.Wrd + "' x " + (dtStr.Cnt ).ToString() + Environment.NewLine;// + "dtStr.Cnt: " + (dtStr.Cnt).ToString() + "." + Environment.NewLine;
                                                        //    }
                                                        //    while (dtStr.Cnt == cntActual)
                                                        //    {
                                                        //        for (int i = 0; i < rgnRpttn.Count; i++)
                                                        //        {
                                                        //            if (dtStr.Wrd==rgnRpttn[i].Wrd)
                                                        //            {
                                                        //                WrCMCmprrs.Remove(dtStr);
                                                        //                cntActual--;
                                                        //            }
                                                        //            if (dtStr.Wrd != rgnRpttn[i].Wrd)
                                                        //            {
                                                        //                rgnRpttn.Add(dtStr);
                                                        //                WrCMCmprrs.Remove(dtStr);
                                                        //                cntActual--;
                                                        //                fndOutEqualWrds += "'" + dtStr.Wrd + "' x " + (dtStr.Cnt).ToString() + Environment.NewLine;// + "dtStr.Cnt: " + (dtStr.Cnt).ToString() + "." + Environment.NewLine;
                                                        //            }

                                                        //        }
                                                                
                                                                
                                                                
                                                        //    }
                                                            
                                                        //}//Filter out all repetitionA
                                                        ////Cnst.C.UsVl.Text=fndOutEqualWrds+Environment.NewLine;
                                                        ////mTputCnstD += fndOutEqualWrds + Environment.NewLine;
                                                        //mTputCnstC += fndOutEqualWrds + Environment.NewLine;
                                                        //MCmpairers.Clear();
                                                        //WrCMCmprrs.Clear();
                                                        ////MessageBox.Show(fndOutEqualWrds);

                                                    }//A
                                                    {//B
                                                        //string fndOutEqualWrds = "Equal words : '";

                                                        //foreach (var wrdd in chngdWrds)
                                                        //{//Find out all repetition

                                                        //    DtString AStrng = new DtString();
                                                        //    AStrng.Wrd = wrdd;
                                                        //    //AStrng.Cnt++;
                                                        //    MCmpairers.Add(AStrng);
                                                        //    WrCMCmprrs.Add(AStrng);


                                                        //    for (int i = 0; i < MCmpairers.Count; i++)
                                                        //    {
                                                        //        if (wrdd == MCmpairers[i].Wrd)
                                                        //        {
                                                        //            //MCmpairers[i].Cnt++;
                                                        //        }

                                                        //    }





                                                        //}//Find out all repetition B

                                                        //foreach (var dtStr in MCmpairers)
                                                        //{//Filter out all repetition B
                                                        //    int cntActual = 0;
                                                        //    int mxCnt = 0;
                                                        //    mxCnt = MCmpairers.Max(mx => mx.Cnt);
                                                        //    cntActual = mxCnt;
                                                        //    if (dtStr.Cnt == mxCnt)
                                                        //    {
                                                        //        //cntActual = mxCnt;
                                                        //        chngRpttn.Add(dtStr);

                                                        //        //if (cntActual-- != 1)
                                                        //        {
                                                        //            cntActual--;
                                                        //        }

                                                        //        WrCMCmprrs.Remove(dtStr);
                                                        //        fndOutEqualWrds += dtStr.Wrd + "' x " + (dtStr.Cnt).ToString() + Environment.NewLine;// + "dtStr.Cnt: " + (dtStr.Cnt).ToString() + "." + Environment.NewLine;
                                                        //    }
                                                        //    while (dtStr.Cnt == cntActual)
                                                        //    {
                                                        //        for (int i = 0; i < rgnRpttn.Count; i++)
                                                        //        {
                                                        //            if (dtStr.Wrd == rgnRpttn[i].Wrd)
                                                        //            {
                                                        //                WrCMCmprrs.Remove(dtStr);
                                                        //                cntActual--;
                                                        //            }
                                                        //            if (dtStr.Wrd != rgnRpttn[i].Wrd)
                                                        //            {
                                                        //                rgnRpttn.Add(dtStr);
                                                        //                WrCMCmprrs.Remove(dtStr);
                                                        //                cntActual--;
                                                        //                fndOutEqualWrds += "'" + dtStr.Wrd + "' x " + (dtStr.Cnt).ToString() + Environment.NewLine;// + "dtStr.Cnt: " + (dtStr.Cnt).ToString() + "." + Environment.NewLine;
                                                        //            }

                                                        //        }



                                                        //    }

                                                        //}//Filter out all repetitionB
                                                        ////Cnst.C.UsVl.Text=fndOutEqualWrds+Environment.NewLine;
                                                        //mTputCnstD += fndOutEqualWrds + Environment.NewLine;
                                                        ////mTputCnstC += fndOutEqualWrds + Environment.NewLine;
                                                        //MCmpairers.Clear();
                                                        //WrCMCmprrs.Clear();
                                                        ////MessageBox.Show(fndOutEqualWrds);

                                                    }//B
                                                }//Find out repetition- Functional- beware if last char is {':',';','!','.','<','?','{','}','[',']','(',')','/','\',''}

                                                mTputCnstD += "New changes: '";
                                                foreach (var cmpWrd in cmprdWrds)
                                                {
                                                    mTputCnstD +=  cmpWrd ;
                                                }
                                                mTputCnstD +=  "' -(changed or added)" + Environment.NewLine;

                                                cmprdWrdsInverted = rgnsWrds.Except(chngdWrds).ToList();
                                                foreach (var cmpWrdInversion in cmprdWrdsInverted)
                                                {
                                                    mTputCnstD += "'" + cmpWrdInversion + "'"  + Environment.NewLine;
                                                }
                                                mTputCnstD +=  " -(changed or deleted)" + Environment.NewLine;

                                                if (chngdTxt.Length==rgnsTxt.Length)
                                                {
                                                    //search for difrences
                                                    {//chrCount + chrChange+ chngdTxt+Coloring Words!! (ALL WORKING)!!



                                                        int chrCount = 0, ndex = 0;
                                                        while (ndex < chngdTxt.Length)
                                                        {//AllchrCount Count algoritm
                                                            ndex++;

                                                            chrCount++;

                                                            // skip whitespace until next word
                                                            //while (ndex < rgnsTxt.Length && char.IsWhiteSpace(rgnsTxt[ndex]))
                                                            //    ndex++;
                                                        }//AllchrCount algoritm -----Working!
                                                        mTputCnstD += Environment.NewLine+ "Edited txt has: " + chrCount.ToString() + " character/s "+Environment.NewLine;

                                                        int chrChange = 0;
                                                        for (int i = 0; i < rgnsCh.Count; i++)//Find out changes
                                                        {
                                                            if (rgnsCh[i] != chngdCh[i])
                                                            {
                                                                int indexOfCharChange = i;
                                                                IndexesOfChng.Add(i);
                                                                chrChange++;
                                                                cmprdCh.Add(chngdCh[i]);
                                                                
                                                            }
                                                        }//Find out changes
                                                        
                                                        foreach (var c in cmprdCh)
                                                        {
                                                            
                                                            {//Prepair cmprdTxt
                                                                cmprdTxt += Environment.NewLine + "'" + c + "'";
                                                            }//Prepair cmprdTxt
                                                        }//Prepair cmprdTxt
                                                        foreach (var i in IndexesOfChng)
                                                        {//Prepair cmprdTxt
                                                            cmprdIndex += Environment.NewLine + "'" + (i+1).ToString() + "'";
                                                        }//Prepair Inedexes To show them to User
                                                        
                                                        
                                                        foreach (var w in chngdWrds)
                                                        {

                                                            if (cmprdWrds.Contains(w))
                                                            {

                                                                {//Two-Colored WORKING!!
                                                                    string cction2 = "";
                                                                    {//Two-Colored WORKING!!
                                                                        String sentence1 = Cnst.B.UsVl.Text;
                                                                        String sentence2 = w;
                                                                        cction2 = sentence1 + sentence2;
                                                                        int start1 = cction2.IndexOf(sentence1);//correction of IndexOf()  -for every newLine neded!
                                                                        int start2 = cction2.IndexOf(sentence2);
                                                                        
                                                                        String subString1 = cction2.Substring(start1, sentence1.Length);
                                                                        String subString2 = cction2.Substring(start2, sentence2.Length);

                                                                        bool match1 = (sentence1 == subString1); // true
                                                                        bool match2 = (sentence2 == subString2); // true

                                                                        //Cnst.A.UsVl.SelectionStart = start1;
                                                                        //Cnst.A.UsVl.SelectionLength = sentence1.Length;
                                                                        //Cnst.A.UsVl.SelectionColor = Color.Red;

                                                                        Cnst.B.UsVl.SelectionStart = start2;
                                                                        Cnst.B.UsVl.SelectionLength = sentence2.Length;
                                                                        Cnst.B.UsVl.SelectionColor = Color.YellowGreen;
                                                                    }//Two-Colored WORKING!!
                                                                }//Two-Colored WORKING!!
                                                                
                                                                
                                                            }
                                                            
                                                        }//Coloring changed Words: goes change by change
                                                        foreach (var w in rgnsWrds)
                                                        {

                                                            if (chngdWrds.Contains(w))
                                                            {

                                                                {//Two-Colored WORKING!!
                                                                    string cction2 = "";
                                                                    {//Two-Colored WORKING!!
                                                                        String sentence1 = Cnst.A.UsVl.Text;
                                                                        String sentence2 = w;
                                                                        cction2 = sentence1 + sentence2;
                                                                        int start1 = cction2.IndexOf(sentence1);//correction of IndexOf()  -for every newLine neded!
                                                                        int start2 = cction2.IndexOf(sentence2);

                                                                        String subString1 = cction2.Substring(start1, sentence1.Length);
                                                                        String subString2 = cction2.Substring(start2, sentence2.Length);

                                                                        bool match1 = (sentence1 == subString1); // true
                                                                        bool match2 = (sentence2 == subString2); // true

                                                                        //Cnst.A.UsVl.SelectionStart = start1;
                                                                        //Cnst.A.UsVl.SelectionLength = sentence1.Length;
                                                                        //Cnst.A.UsVl.SelectionColor = Color.Red;

                                                                        Cnst.A.UsVl.SelectionStart = start2;
                                                                        Cnst.A.UsVl.SelectionLength = sentence2.Length;
                                                                        Cnst.A.UsVl.SelectionColor = Color.Lavender;
                                                                    }//Two-Colored WORKING!!
                                                                }//Two-Colored WORKING!!


                                                            }

                                                        }//Coloring changed Words: goes change by change
                                                        if (Cnst.B.UsVl.Text.Length< Cnst.A.UsVl.Text.Length)
                                                        {
                                                            mTputCnstD += Environment.NewLine + "Edited txt has: " + (Cnst.A.UsVl.Text.Length - Cnst.B.UsVl.Text.Length) + " character/s deleted. "+Environment.NewLine;
                                                            //MessageBox.Show("Edited txt has: " + (Cnst.A.UsVl.Text.Length- Cnst.B.UsVl.Text.Length) + " character/s deleted. ");
                                                            mTputCnstD += Environment.NewLine + "Edited txt has: " + chrChange.ToString() + " character/s changed: " + Environment.NewLine;
                                                            //MessageBox.Show("Edited txt has: " + chrChange.ToString() + " character/s changed: ");
                                                            mTputCnstD+= Environment.NewLine + "Comparisions:" + cmprdTxt + Environment.NewLine + "changes to character/s." + Environment.NewLine;
                                                            //MessageBox.Show("Comparisions:" + cmprdTxt + Environment.NewLine + "changes to character/s.");
                                                            mTputCnstD += Environment.NewLine + "Indexes of changes that have been made: " + cmprdIndex + Environment.NewLine;
                                                            //MessageBox.Show("Indexes of changes that have been made: " + cmprdIndex);
                                                            mTputCnstD += Environment.NewLine + "Edited txt has changed:" + cmprdWrds.Count.ToString() + " word/s.";// + Environment.NewLine;
                                                            //MessageBox.Show("Edited txt has changed:" + cmprdWrds.Count.ToString() + " word/s.");


                                                        }
                                                        if (Cnst.B.UsVl.Text.Length > Cnst.A.UsVl.Text.Length)
                                                        {
                                                            //mTputCnstD+=Environment.NewLine+(
                                                            mTputCnstD+=Environment.NewLine + Environment.NewLine + ("Edited txt has: " + (Cnst.B.UsVl.Text.Length - Cnst.A.UsVl.Text.Length) + " character/s added. ");
                                                            mTputCnstD+=Environment.NewLine +Environment.NewLine+("Edited txt has: " + chrChange.ToString() + " character/s changed: ");
                                                            mTputCnstD+=Environment.NewLine +Environment.NewLine+("Comparisions:" + cmprdTxt + Environment.NewLine + "changes to character/s.");
                                                            mTputCnstD+=Environment.NewLine +Environment.NewLine+("Indexes of changes that have been made: " + cmprdIndex);
                                                            mTputCnstD+= Environment.NewLine + Environment.NewLine + ("Edited txt has changed:" + cmprdWrds.Count.ToString() + " word/s.");


                                                        }
                                                        if (Cnst.B.UsVl.Text.Length == Cnst.A.UsVl.Text.Length)
                                                        {
                                                            
                                                            mTputCnstD+=Environment.NewLine +Environment.NewLine+("Edited txt has: " + chrChange.ToString() + " character/s changed: ");
                                                            mTputCnstD+=Environment.NewLine +Environment.NewLine+("Comparisions:" + cmprdTxt + Environment.NewLine + "changes to character/s.");
                                                            mTputCnstD+=Environment.NewLine +Environment.NewLine+("Indexes of changes that have been made: " + cmprdIndex);
                                                            mTputCnstD+= Environment.NewLine + Environment.NewLine + ("Edited txt has changed:" + cmprdWrds.Count.ToString() + " word/s.");


                                                        }


                                                    }//chrCount + chrChange+ chngdTxt+ColoringWords!! (ALL WORKING)!!
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Error in correction Phase");
                                                }
                                                
                                            }//Universal! for  both!
                                            
                                        }//Fill compair
                                        string otpt = Environment.NewLine + "List of Letters used:" + Environment.NewLine;
                                        {//Letters used
                                         // 1.
                                         // Int to store frequency of Changes.

                                            int[] c = new int[(int)char.MaxValue];


                                            // 2.
                                            // Read entire strings.
                                            string rgn = "";
                                            if (Cnst.LddFile != "" && Cnst.LddFile == Cnst.A.UsVl.Text)
                                            {//FillList with ORIGINAL strings
                                             //MessageBox.Show("NEW CHANGES:"+ "LddFile.CompareTo(Cnst.B.UsVl.Text  -:" + Cnst.LddFile.CompareTo(Cnst.B.UsVl.Text).ToString());
                                                rgn = Cnst.LddFile;

                                            }
                                            else
                                            {
                                                rgn = Cnst.A.UsVl.Text;

                                            }//FillList with ORIGINAL strings

                                            string chng = Cnst.B.UsVl.Text;
                                            //string s = UsVl.Text;

                                            // 3.
                                            // Iterate over each character.
                                            if (Cnst.B.UsVl.Text != rgn)
                                            {
                                                char[] rgnsChars = rgn.ToArray();
                                                char[] chngdChars = chng.ToArray();
                                                char[] dltdChars= rgnsChars.Except(chngdChars).ToArray();

                                                char[] adddChars = chngdChars.Except(rgnsChars).ToArray();
                                                foreach (char ddd in adddChars)
                                                {
                                                    otpt += "added =) " + ddd + Environment.NewLine;
                                                    //cchngCharCount++;
                                                }
                                                foreach (char dlt in dltdChars)
                                                {
                                                    otpt += "deleted =) " + dlt + Environment.NewLine;

                                                }
                                                
                                            }
                                            //MessageBox.Show( otpt);



                                        }//Letters used
                                        Cnst.C.UsVl.Text += Environment.NewLine + mTputCnstC;
                                        Cnst.D.UsVl.Text += Environment.NewLine+ mTputCnstD + otpt;// + Environment.NewLine + "--- Bylo provedeno " + cchngCharCount2.ToString() + " změn. ---" + Environment.NewLine + "Výpis písmen použitých k úpravě: " + Environment.NewLine + otpt;
                                        Cnst.D.UsVl.Invalidate();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Nemám co bych mohl porovnávat.");
                                    }
                                }//Show statistics
                            }//Statistics - First try









                        }

                    };
                    //lstCntrl.Visible = false;
                    Controls.Add(lstCntrl);

                    SpwnLck = new Point(lstCntrl.Right, lstCntrl.Top);
                    LblMove swp = lstCntrl = new LblMove(SpwnLck, Szz, "Writen text", ClrdBck, ClrdFrnt, myFont);
                    lstCntrl.MouseDown += (sender, e) =>
                    {
                        try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                        try { Cnst.justOne.Dispose(); } catch (Exception) { }
                        if (e.Button == MouseButtons.Left)
                        {


                            if (Cnst.A.WrtnTxt != true)
                            {


                                //Cnst.A.UsVl.SelectionProtected = false;

                                Cnst.A.UsVl.BackColor = Color.Chocolate;
                                Cnst.A.WrtnTxt = true;
                                Cnst.A.UsVl.SelectAll();
                                Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Left;
                                Cnst.A.UsVl.SelectionColor = Color.Black;
                                Cnst.A.UsVl.SelectionBackColor = Cnst.A.UsVl.BackColor;
                                Cnst.A.UsVl.SelectionFont = Cnst.A.Font;
                                Cnst.A.UsVl.DeselectAll();
                                Cnst.A.UsVl.Focus();
                                Cnst.A.UsVl.SelectionStart = Cnst.A.UsVl.Text.Length;
                            }
                            else
                            {
                                Cnst.A.UsVl.SelectAll();
                                Cnst.A.UsVl.SelectionBackColor = Cnst.A.UsVl.BackColor;
                                Cnst.A.UsVl.BackColor = Cnst.A.BackColor;
                                Cnst.A.WrtnTxt = false;
                                Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                                
                                Cnst.A.UsVl.SelectionColor = Color.Black;
                                
                                Cnst.A.UsVl.SelectionFont = LddTxtFnt;
                                Cnst.A.UsVl.DeselectAll();
                                Cnst.B.UsVl.Focus();
                                Cnst.B.UsVl.SelectionStart = Cnst.B.UsVl.Text.Length;

                            }

                            Cnst.D.UsVl.Text = "";

                            int wordCount = 0, index = 0;
                            {//Words Count algoritm
                                var text = Cnst.B.UsVl.Text.Trim();


                                while (index < text.Length)
                                {
                                    // check if current char is part of a word
                                    while (index < text.Length && !char.IsWhiteSpace(text[index]))
                                        index++;

                                    wordCount++;

                                    // skip whitespace until next word
                                    while (index < text.Length && char.IsWhiteSpace(text[index]))
                                        index++;
                                }

                            }//Words Count algoritm


                            string output = "";
                            {//Letters frequency
                             // 1.
                             // Array to store frequencies.
                                int[] c = new int[(int)char.MaxValue];

                                // 2.
                                // Read entire text file.
                                string s = Cnst.B.UsVl.Text;

                                // 3.
                                // Iterate over each character.
                                foreach (char t in s)
                                {
                                    // Increment table.
                                    c[(int)t]++;
                                }

                                // 4.
                                // Write all letters found.
                                for (int i = 0; i < (int)char.MaxValue; i++)
                                {
                                    if (c[i] > 0 &&
                                        char.IsLetterOrDigit((char)i))
                                    {
                                        output += ("Písmeno: " + (char)i + "=) " + c[i] + " x" + Environment.NewLine);
                                        //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                        //    (char)i,
                                        //    c[i]);
                                    }
                                }

                            }//Letters frequency

                            //MessageBox.Show(output);
                            Cnst.C.UsVl.Text = "Váš text obsahuje:" + Environment.NewLine + (wordCount).ToString() + " slov." + Environment.NewLine + output;
                            Cnst.C.UsVl.Invalidate();
                        }

                    };
                    
                    Controls.Add(lstCntrl);

                    SpwnLck = new Point(lstCntrl.Right, lstCntrl.Top);
                    LblMove cmmtChanges = lstCntrl = new LblMove(SpwnLck, Szz, "Commit Changes", ClrdBck, ClrdFrnt, myFont);
                    lstCntrl.MouseDown += (sender, e) =>
                    {
                        try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                        try { Cnst.justOne.Dispose(); } catch (Exception) { }
                        if (e.Button == MouseButtons.Left)
                        {
                            DialogResult dialogResult = MessageBox.Show("Sure to commit? In a case Txt File is loaded,"+Environment.NewLine+" this commit will not change the base file", "Commit", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //do something
                                Cnst.LddFile = Cnst.A.UsVl.Text = Cnst.B.UsVl.Text;
                                MessageBox.Show("Change/s accepted", "Commit succesfull", MessageBoxButtons.OK);
                                
                                //Cnst.A.WrtnTxt = false;
                                if (Cnst.A.UsVl.Text == Cnst.B.UsVl.Text && Cnst.LddFile != "" && Cnst.LddFile == Cnst.B.UsVl.Text)//&& Cnst.A.WrtnTxt == false)
                                {

                                    //get index=position of cursor in string==UsVl.SelectionStart
                                    //UsVl.Text.Remove(UsVl.SelectionStart - 1);
                                    if (Cnst.A.WrtnTxt==false)
                                    {
                                        Cnst.A.dsgFnt();
                                    }
                                    
                                    //Cnst.A2.UsVl.SelectionProtected = true;
                                    Cnst.A.UsVl.Text = Cnst.LddFile;
                                    Cnst.A.UsVl.Invalidate();
                                    //Cnst.A.UsVl.SelectAll();
                                    //Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Left;
                                    //Cnst.A.UsVl.SelectionFont = Cnst.A.Font;
                                    //Cnst.A.UsVl.Font = Cnst.A.UsVl.SelectionFont;
                                    //Cnst.A2.UsVl.SelectionProtected = true;
                                    //Cnst.A.Hide();
                                    //Cnst.A2.Show();
                                }


                                //Cnst.A.UsVl.Invalidate();
                                
                                

                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //do something else
                            }
                            
                            
                        }

                    };
                    //lstCntrl.Visible = false;
                    Controls.Add(lstCntrl);//Buttons functions
                    SizeChanged += (sendere, z) =>
                    {
                        //RposCntrols();
                        Invalidate();
                        Szz = new Size(ClientSize.Width / Controls.Count, ClientSize.Height);

                        //Szz = new Size(Cnst.WnOrigArea.Width / Controls.Count, Cnst.WnOrigArea.Height/8 );
                        //Szz = new Size(Width / Controls.Count, Height);

                        for (int i = 0; i < Controls.Count; i++)
                        {
                            Controls[0].Location = new Point(0, 0);
                            lstNtroll = Controls[0];
                            lstNtroll.Size = Szz;
                            lstNtroll.Invalidate();
                            if (Controls[i].Location == lstNtroll.Location&&i>0)
                            {
                                Controls[i].Left = lstNtroll.Right * i;
                                Controls[i].Top = lstNtroll.Top;
                                lstNtroll = Controls[i];
                                lstNtroll.Size = Szz;
                                lstNtroll.Invalidate();
                            }
                            else
                            {
                                Controls[i].Left = lstNtroll.Right * i;
                                Controls[i].Top = lstNtroll.Top;
                                lstNtroll = Controls[i];
                                lstNtroll.Size = Szz;
                                lstNtroll.Invalidate();
                            }
                            //Controls[i].Size = Szz;
                            //Controls[i].Invalidate();

                        }

                        //sttstcs.Left = fl.Right;
                        //sttstcs.Top = fl.Top;
                        //sttstcs.Invalidate();
                    };

                    


                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }//Design added on StartUp - HeadrPanel
            }
            foreach (Control c in Controls)
            {
                c.ForeColor = Color.FromArgb(60,ClrdFrnt);
                if (c.Controls.Count > 0)
                {
                    foreach (Control Cc in Controls)
                    {
                        Cc.ForeColor = Color.FromArgb(60, ClrdFrnt);
                        if (Cc.Controls.Count > 0)
                        {
                            foreach (Control Ccc in Controls)
                            {
                                Ccc.ForeColor = Color.FromArgb(60, ClrdFrnt);

                            }
                        }
                    }

                }
            }
            Invalidate();
        }
        public void FrClrChange()
        {
            ColorDialog clrChoose = new ColorDialog();
            if (clrChoose.ShowDialog() == DialogResult.OK)
            {
                Cnst.VluesIso.ForeColor = clrChoose.Color;
            }
        }
        public void Mv3D()
        {
            //if (S.Cnvs.PrsmDrw == true)
            //{
            //    if (Cnst.MPrisms.Count == 0)
            //    {
            //        MessageBox.Show("Nemám nic, čím mohu pohnout. (There is nothing to move.)");

            //    }
            //    else
            //    {
            //        if (PrsmSlct == null)
            //        {
            //            MessageBox.Show("Prosím, označte jeden kvádrPrsm. (Please, select one rectangle)");

            //        }
            //        else
            //        {


            //            int[] rcrtM = { PrsmSlct.Input[0]+(int)UpDownMoveX.Value, PrsmSlct.Input[1] + (int)UpDownMoveY.Value, PrsmSlct.Input[2] + (int)UpDownMoveZ.Value,PrsmSlct.Input[3], PrsmSlct.Input[4], PrsmSlct.Input[5] };
            //            {//Prsm InstantMOVE
            //                //{//Clear all result Lists
            //                //    Cnst.Intrsc3D.Clear();
            //                //    Cnst.CmbnPrsms3D.Clear();
            //                //    Cnst.DifrPrsms3D.Clear();
            //                //    Cnst.Intrsc3DOfIntrsct.Clear();
            //                //}//Clear all result Lists
            //                //{//Recreate Prsm.Slctd=true
            //                //    Prism Prsm = new Prism(rcrtM);
            //                //    Prsm.PrntMe(PrsmSlct.MyParent);
            //                //    Prsm.LinkBtn(PrsmSlct.LnkMy);
            //                //    PrsmSlct.LnkMy.LinkPrsm(Prsm);
            //                //    Prsm.PrsmClr = PrsmSlct.PrsmClr;
            //                //    Prsm.CreateMe();
            //                //    Cnst.MPrisms.Remove(PrsmSlct);
            //                //    Cnst.PrismsToDraw.Remove(PrsmSlct);
            //                //    PrsmSlct.Dispose();
            //                //    Cnst.MPrisms.Add(Prsm);
            //                //    Cnst.PrismsToDraw.Add(Prsm);
            //                //    PrsmSlct = Prsm;
            //                //    PrsmSlct.Slctd = true;
            //                //    Cnst.VluesIso.Text = PrsmSlct.PrsmTxt0.Text;
            //                //    Cnst.VluesIso.Invalidate();
            //                //}//Recreate Prism=) Prsm.Slctd=true

            //            }//Prsm InstantMOVE



            //            {//Move3d over Time
            //                {//Create new Move3d for later execution
            //                    //Move3d prsmSlct = new Move3d((int)UpDownMoveX.Value, (int)UpDownMoveY.Value, (int)UpDownMoveZ.Value);
            //                    Move3d prsmSlctUsrVal = new Move3d(UsrMoveX.UsrVal, UsrMoveY.UsrVal, UsrMoveZ.UsrVal);
            //                    PrsmSlct.ReceiveMove(prsmSlctUsrVal, 43);
            //                }//Create new Move3d for later execution

            //                {//Execute && DRAW Move3d
            //                    S.Ticker.Interval = 33;
            //                    S.Ticker.Tick += (senderf, f) =>
            //                    {
            //                        foreach (Prism q in S.Cnvs.Movement)
            //                        {
            //                            q.Ticker_Tick2();
            //                            //q.Ticker_Tick();

            //                        }
            //                        S.Cnvs.Movement.RemoveAll(q => q.isMoving == false);
            //                        if (S.Cnvs.Movement.Count == 0) S.Ticker.Stop();

            //                        S.Cnvs.Refresh();

            //                    };
            //                }//Execute && DRAW Move3d

            //                {//Dialog
            //                    //DialogResult dialogResult = MessageBox.Show("Pohnout?", "Opravdu?", MessageBoxButtons.YesNo);
            //                    //if (dialogResult == DialogResult.Yes)
            //                    //{
            //                    //    PrsmSlct.PdateMe();
            //                    //}
            //                    //else if (dialogResult == DialogResult.No)
            //                    //{
            //                    //    Move3d prsmSlctReset = new Move3d(0, 0, 0);
            //                    //    PrsmSlct.ReceiveMove(prsmSlctReset, 13);
            //                    //    S.Ticker.Interval = 33;
            //                    //    S.Ticker.Tick += (senderf, f) =>
            //                    //    {
            //                    //        foreach (Prism q in S.Cnvs.Movement)
            //                    //        {
            //                    //            q.Ticker_Tick2();
            //                    //            //q.Ticker_Tick();

            //                    //        }
            //                    //        S.Cnvs.Movement.RemoveAll(q => q.isMoving == false);
            //                    //        if (S.Cnvs.Movement.Count == 0) S.Ticker.Stop();

            //                    //        S.Cnvs.Refresh();

            //                    //    };
            //                    //}
            //                }//Dialog
            //            }//Move3d over Time

            //            S.Cnvs.Refresh();
            //        }

            //    }
            //}
            //if (S.Cnvs.KvdrDrw==true)
            //{
            //    if (S.Cnvs.Kvadry.Count == 0)
            //    {
            //        MessageBox.Show("Nemám nic, čím mohu pohnout. (There is nothing to move.)");

            //    }
            //    else
            //    {
            //        if (KvdrSlct == null)
            //        {
            //            MessageBox.Show("Prosím, označte jeden kvádr. (Please, select one rectangle)");

            //        }
            //        else
            //        {

            //            Move3dEventArgs kvdrSlct = new Move3dEventArgs(UsrMoveX.UsrVal, UsrMoveY.UsrVal, UsrMoveZ.UsrVal);
            //            KvdrSlct.ReceiveMove(kvdrSlct);
            //            //Asi sem dopsat INSTANT MOVE...
            //            //int[] rcreateMe = { KvdrSlct.Input[0] + (int)UpDownMoveX.Value, KvdrSlct.Input[1] + (int)UpDownMoveY.Value, KvdrSlct.Input[2] + (int)UpDownMoveZ.Value, KvdrSlct.Input[3], KvdrSlct.Input[4], KvdrSlct.Input[5] };

            //            //Asi sem dopsat INSTANT MOVE...

            //            //S.Cnvs.IntersectBlocks();
            //        }

            //    }
            //}
        }
        public void HldrRfrsh()
        {
            Hldr.Controls.Clear();
            Font myFont = new Font("Cambria", 11, FontStyle.Bold);
            BtnMy lstCntrl = null;
            //Select LblButtons
            SpwnLck = new Point(1, 1);
            //SpwnLck = new Point(lstCntrl.Right + 0, lstCntrl.Top - lstCntrl.Height);
            Szz = new Size(Hldr.Width - 22, Hldr.Height / 3);//for purpouse!
                     
            RposCntrols();
        }
        public void MyKvadrCreator()
        {
            //if (Pn0rgn.UsrVal < 1 && Pn1rgn.UsrVal < 1 && Pn2.UsrVal < 1 && Pn3.UsrVal < 1 && Pn4.UsrVal < 1 && Pn5.UsrVal < 1)
            //{
            //    int[] input = { 0, 0, 0, 66, 66, 66 };
            //    if (S.Cnvs.Kvadry.Count > 0)
            //    {
            //        for (int i = 0; i < S.Cnvs.Kvadry.Count; i++)
            //        {
            //            input[0] = (i + 1) * 30 + input[0];
            //            input[1] = (i + 1) * 30 + input[1];
            //            input[2] = (i + 1) * 30 + input[2];
            //            input[3] = (i + 1) * 30 + input[3];
            //            input[4] = (i + 1) * 30 + input[4];
            //            input[5] = (i + 1) * 30 + input[5];
            //        }

            //    }
            //    Inpt = input;
            //}
            //else
            //{
            //    int[] input = { Pn0rgn.UsrVal, Pn1rgn.UsrVal, Pn2.UsrVal, Pn3.UsrVal, Pn4.UsrVal, Pn5.UsrVal };
            //    Inpt = input;
            //}
            //Kvadr kvadr = new Kvadr(Inpt[0], Inpt[1], Inpt[2], Inpt[3], Inpt[4], Inpt[5]);
            //kvadr.RndClr();
            //S.Cnvs.Kvadry.Add(kvadr);
            //S.Cnvs.IntersectBlocks();
            //S.Cnvs.PrIntrsctBlocks();//S.Canvas.Refresh();


        }
        public void PrsmCreator()
        {
            //S.Cnvs.Rndr = false;
            //S.Cnvs.ShwTm = false;
            //try//Prism Creation
            //{

            //    {//Clear Lists
            //        S.Cnvs.ShwTm = false;
            //        S.Cnvs.Rndr = false;

            //        S.Cnvs.ShwTm = false;
            //        S.Cnvs.Rndr = false;
            //    }//Clear Lists

            //    //Check for box values

            //    if (Pn0rgn.UsrVal<1&& Pn1rgn.UsrVal<1&&Pn2.UsrVal<1&&Pn3.UsrVal<1&& Pn4.UsrVal<1&& Pn5.UsrVal<1)
            //    {
            //        int[] input = { 0, 0, 0, 66, 66, 66 };
            //        if (Cnst.MPrisms.Count>0)
            //        {
            //            for (int i = 0; i < Cnst.MPrisms.Count; i++)
            //            {
            //                input[0] = (i+1) * 30 + input[0];
            //                input[1] = (i+1) * 30 + input[1];
            //                input[2] = (i+1) * 30 + input[2];
            //                input[3] = (i+1) * 30 + input[3];
            //                input[4] = (i+1) * 30 + input[4];
            //                input[5] = (i+1) * 30 + input[5];
            //            }

            //        }
            //        Inpt = input;
            //    }
            //    else
            //    {
            //        int[] input = { Pn0rgn.UsrVal, Pn1rgn.UsrVal, Pn2.UsrVal, Pn3.UsrVal, Pn4.UsrVal, Pn5.UsrVal };
            //        Inpt = input;
            //    }



            //    //3D points convert To 2D
            //    {//Clear Lists
            //        Cnst.LftPolygonP.Clear();
            //        Cnst.RghtPolygonP.Clear();
            //        Cnst.TopPolygonP.Clear();
            //        Cnst.BttmPolygonP.Clear();
            //        Cnst.BckPolygonP.Clear();
            //        Cnst.FrntPolygonP.Clear();
            //    }//Clear Lists

            //    {//Results

            //        Prism Prsm = new Prism(Inpt);
            //        Prsm.PrntMe(S.Cnvs);
            //        Prsm.PrsmClr = Cnst.VluesIso.BackColor;
            //        Prsm.RndClr();
            //        Cnst.VluesIso.BackColor = Prsm.PrsmClr;
            //        MyClrInvrt(Cnst.VluesIso.BackColor);
            //        Cnst.VluesIso.ForeColor = ForeColor;

            //        Prsm.CreateMe();
            //        Cnst.VluesIso.Text = Prsm.PrsmTxt0.Text;
            //        Cnst.VluesIso.Invalidate();
            //        Cnst.MPrisms.Add(Prsm);
            //        Cnst.PrismsToDraw.Add(Prsm);
            //        S.Cnvs.Axe = "Rslt3D";

            //        S.Cnvs.Refresh();


            //        //Invalidate();
            //    }//Results


            //}
            //catch (Exception) { }//Prism Creation
        }
        public void MyClrInvrt(Color cl)
        {
            ClrInver = Color.FromArgb(cl.ToArgb() ^ 0xffffff);
            ForeColor = ClrInver;
        }


    }
}

