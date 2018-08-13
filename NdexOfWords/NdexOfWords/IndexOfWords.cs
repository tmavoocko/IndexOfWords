using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.Linq;

namespace NdexOfWords
{
    public partial class IndexOfWords : Form
    {
        public Font LddTxtFnt = new Font("Litograph", 9, FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
        public int Fgh = 0;
        public int FghEnd = 0;
        public int ClctIntrval = 0;
        public DateTime TmerStart = new DateTime();
        public DateTime TmerEnd = new DateTime();
        public DateTime TmOfClick = new DateTime();
        List<string> IntroStrngs = new List<string>();
        private Point mouseDownLoc;
        public Panel DrwCore = new Panel();
        public Point SpwLc = new Point();
        public Timer Tckr = new Timer();
        public Font MFnt = new Font("Litograph", 15, FontStyle.Bold);
        public Font mFntCh = new Font("Litograph", 10, FontStyle.Regular);
        public Rectangle DsgRct = new Rectangle();
        public Panel VrtLft, HrzLftTop, HrzLftDwn, VrtRght, HrzRghtTop, HrzRghtDwn;
        public Panel Hrzntl = new Panel();
        public Panel Prgrm = new Panel();
        public Color ClrBasePenelHolder = Color.FromArgb(255, Color.WhiteSmoke);
        
        public Color ClrdBck = Color.FromArgb(200, Color.Black);
        public Color ClrdFrnt = Color.FromArgb(200, Color.Tomato);
        public Color ClrInver;
        public Control LstCntrl = new Control();

        public int SiModifier = 1;
        
        private ToolStrip menuStrip;
        private StatusStrip statusStrip;
        private ContextMenuStrip fileMenuStrip;
        private ContextMenuStrip optionsMenuStrip;
        //private ContextMenuStrip SttstcsMnStrp;
        //TlStrip
        private bool inProgres = false;
        private static Timer ticker = new Timer();
        ToolStripProgressBar progress;
        ToolStripLabel label;
        //TlStrip
        public IndexOfWords()
        {

            
            DoubleBuffered = true;
            Text = "Index Of Words - D.Konicek - zadani ctvrte";
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
            MouseHover += (sender, e) =>
            {
                ToolTip hint = new ToolTip();
                hint.SetToolTip(this, Text);
                foreach (Control c in Controls)
                {
                    c.MouseHover += (senderf, f) =>
                    {
                        ToolTip hint2 = new ToolTip();
                        hint2.SetToolTip(c, c.ToString());
                    };
                    if (c.Controls.Count > 0)
                    {
                        foreach (Control Cc in Controls)
                        {

                            Cc.MouseHover += (senderf, f) =>
                            {
                                ToolTip hint2 = new ToolTip();
                                hint2.SetToolTip(Cc, Cc.ToString());
                            };
                            if (Cc.Controls.Count > 0)
                            {
                                foreach (Control Ccc in Controls)
                                {
                                    Ccc.MouseHover += (senderf, f) =>
                                    {
                                        ToolTip hint2 = new ToolTip();
                                        hint2.SetToolTip(Ccc, Ccc.ToString());
                                    };
                                }
                            }
                        }

                    }
                }
               
            };
            MouseLeave += (sender, e) =>
            {

                {
                    ////No mdFrameLoc - because it is on Form1                        
                    //Point parentLoc = new Point(0, 0);
                    //try { Cnst.jstTry.Dispose(); } catch (Exception) { }
                    //try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                    //try { Cnst.justOne.Dispose(); } catch (Exception) { }
                    //BackColor = ClrdBck;
                    //Enabled = true;
                    ////Cnst.jstTry = new MTltip(this, this, "Pokus!!!!", 70);
                    ////Cnst.jstTry.BringToFront();
                }
            };
            KeyUp += (sender, e) =>
            {
                //if (e.KeyData == Keys.Enter)
                //{
                //    //No mdFrameLoc - because it is on Form1                        
                //    Point parentLoc = new Point(0, 0);
                //    try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                //    try { Cnst.justOne.Dispose(); } catch (Exception) { }
                //    Cnst.jstTry = new MTltip(parentLoc, this);
                //    Cnst.jstTry.BringToFront();
                //}
            };
            FormClosing += (sender, e) =>
            {
                {//Xml create & save
                    XmlDocument docxml = new XmlDocument();
                    //xmlDoc.CreateNode(XmlNodeType.Element, "Records", null);
                    //XElement n = new XElement("Customer", "Adventure Works");
                    XmlDocument doc = new XmlDocument();
                    //doc.AppendChild(n);
                    //doc.CreateElement("Customer", "Adventure Works");
                    //StartingNode
                    XmlElement prgr = (XmlElement)doc.AppendChild(doc.CreateElement("prgrm"));
                    //el.SetAttribute("Bar", "some & value");
                    prgr.SetAttribute("IndexofWords", this.Text);
                    {//aBlok-InnerNode 
                        XmlElement aBlock = (XmlElement)prgr.AppendChild(doc.CreateElement("ABlock"));
                        aBlock.InnerText = "ABlock-InnerNode";
                        aBlock.SetAttribute("aBlock", Cnst.C.UsVl.Text);
                    }//aBlok-InnerNode
                    {//cBlok-InnerNode 
                        XmlElement cBlock = (XmlElement)prgr.AppendChild(doc.CreateElement("CBlok"));
                        cBlock.InnerText = "CBlock-InnerNode";
                        cBlock.SetAttribute("cBlock", Cnst.C.UsVl.Text);
                    }//cBlok-InnerNode
                    //MessageBox.Show(doc.OuterXml);
                    
                    // Save the document to a file. White space is
                    // preserved (no white space).
                    doc.PreserveWhitespace = true;
                    doc.Save("IndexOfWords.xml");
                }//Xml create & save
            };
            {//XmlDocument load
                XmlDocument dcLoad = new XmlDocument();
                dcLoad.Load("IndexOfWords.xml");

                XmlNode node = dcLoad.SelectSingleNode("ABlock");
                
                
            }//XmlDocument load
            ScSize();
            IntrScr();
        }
        //FUNCTION - TlStrip-------------------
        void onOpenFileClick(object sender, EventArgs e)
        {
            
            {//OpenFile
                {//OpenFile
                    //if (Cnst.B.UsVl.Text == "")
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
                                Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                Invalidate();
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
                                //tsdd.Dispose();
                                Text = ofd.SafeFileName + " - Frequencies Table -D.Konicek - zadani treti";
                                Invalidate();

                            }
                        }
                    }
                    
                   
                }//OpenFile
            }//OpenFile
        }
        void onSaveFileClick(object sender, EventArgs e)
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
                                    string output0 = Cnst.A.UsVl.Text + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + Cnst.C.UsVl.Text;//+ "-------------------------------------------" + Environment.NewLine + Cnst.D.UsVl.Text;

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
                                string output0 = Cnst.A.UsVl.Text + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + Cnst.C.UsVl.Text + "-------------------------------------------" + Environment.NewLine + Cnst.D.UsVl.Text;

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
        }
        void onNewFileClick(object sender, EventArgs e)
        {
            {//New
                {//New

                    Cnst.LddFileName = "New";
                    Cnst.A.UsVl.Text = "";
                    //Cnst.A.UsVl.BackColor = Color.Chocolate;
                    Cnst.A.WrtnTxt = true;
                    Cnst.A.UsVl.SelectAll();
                    Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Left;
                    Cnst.A.UsVl.SelectionFont = Cnst.A.Font;
                    Cnst.A.UsVl.Focus();
                    Cnst.A.Invalidate();
                    Cnst.A.UsVl.Invalidate();
                    
                    Text = "New";
                    Invalidate();
                }//New
            }//New
        }
        void sttstcsClick(object sender, EventArgs e)
        {
            {//Dialog
                DialogResult dialogResult = MessageBox.Show("Filtrujeme: slova delsi nez 3 znaky "+Environment.NewLine+ "a zaroven slova neobsahujici cislo " + Environment.NewLine + "a zaroven slova ktera nejsou napsana velkymi pismeny.", "Filter Info", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                   
                }
                
            }//Dialog
            {//Functionality here

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
                    
                    string output = "Provedené úpravy ve slovech:" + Environment.NewLine;
                    string mTputCnstC = "";
                    //mTputCnstC += "Dictionary: " + Environment.NewLine + prsTxt + Environment.NewLine + "-------------";

                    {//Show statistics//changes to text from original file
                        if (Cnst.A.UsVl.Text != "")//&& Cnst.A.UsVl.Text != Cnst.B.UsVl.Text)
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

                                



                            }//Letters used
                            Cnst.C.UsVl.Text += Environment.NewLine + mTputCnstC;
                            

                        }
                        else
                        {
                            MessageBox.Show("Nemám co bych mohl porovnávat.");
                        }
                    }//Show statistics
                }//Statistics - First try
            }//Functionality here


        }
        void wrtnTxtClick(object sender, EventArgs e)
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
                //Cnst.B.UsVl.Focus();
                //Cnst.B.UsVl.SelectionStart = Cnst.B.UsVl.Text.Length;

            }

            //Cnst.D.UsVl.Text = "";

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
        void onAnimateOptionClick(object sender, EventArgs e)
        {
            if (inProgres)
            {
                ticker.Stop();
                inProgres = false;
            }
            else
            {
                ticker.Start();
                inProgres = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Cnst.S.remApp(this);
            base.OnClosed(e);
        }//FUNCTION - TlStrip-------------------
        
        //FUNCTION - private-------------------
        private void ScSize()
        {
            //SetBounds((Screen.GetBounds(this).Width / 2) - (Width / 2), (Screen.GetBounds(this).Height / 2) - (Height / 2), Width, Height, BoundsSpecified.Location);
            //Set Form1(Window) fit on any Monitor             
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            //thiCnst.S.Size = new Size(w, h);
            Size = new Size(w - ((1 / 2) / 2), h - ((1 / 2) / 2));
            //-----------------Set Form1(Window) fit on any Monitor 





        }
        private void IndexOfWordsDsgn()
        {
            //ScSize();
            {//Prgrm
                Prgrm.Width = ClientSize.Width;
                Prgrm.Height = ClientSize.Height;
                Prgrm.Location = new Point(0, 0);
                Prgrm.Dock = DockStyle.Fill;
                Prgrm.Visible = false;
                Controls.Add(Prgrm);
            }//Prgrm
            ClientSizeChanged += (sender, e) =>
            {
                Prgrm.Invalidate();
            };
            {//Hdr2
                Cnst.WnOrigArea = new Size(ClientRectangle.Width, ClientRectangle.Height);

                MyClrInvrt(ClrdBck);
                //DsgnFrColor = ForeColor;
                //Point spwnLoc = new Point(ClientSize.Width / 80, ClientSize.Height / 80);
                //Size szz = new Size(75, 45); int fnt = 21;
                //Font myFont = new Font("Cambria", fnt, FontStyle.Bold);

                //Cnst.S.Hdr2 = new Hdr2(Prgrm); Cnst.S.Hdr2.Location = new Point(0, 0);
                //Cnst.ScreeLftOver = new Rectangle(Cnst.S.Hdr2.Left, Cnst.S.Hdr2.Bottom, Prgrm.ClientRectangle.Width, Prgrm.ClientRectangle.Height - Cnst.S.Hdr2.Height);
                //LstCntrl = Cnst.S.Hdr2;
            }//Hdr2
            {//newDSG

                Prgrm.ClientSizeChanged += (sender, e) =>
                {

                    //Visible = false;
                    Hrzntl.Width = ClientSize.Width;
                    Hrzntl.Height = ClientSize.Height;// - Cnst.S.Hdr2.Height;

                    VrtLft.Width = Hrzntl.Width / 5 * 4;//Left side
                    VrtLft.Height = Hrzntl.Height;//Left side

                    HrzLftTop.Location = new Point(0, 0);//A1
                    HrzLftTop.Width = VrtLft.Width;
                    HrzLftTop.Height = VrtLft.Height / 2;//A1

                    //HrzLftDwn.Width = VrtLft.Width;//B1
                    //HrzLftDwn.Height = VrtLft.Height / 2;
                    //HrzLftDwn.Left = HrzLftTop.Left;
                    //HrzLftDwn.Top = HrzLftTop.Bottom;//B1

                    VrtRght.Width = Hrzntl.Width - VrtLft.Right; //Right side
                    VrtRght.Height = Hrzntl.Height;

                    HrzRghtTop.Location = new Point(0, 0);//C1
                    HrzRghtTop.Width = VrtRght.Width;
                    HrzRghtTop.Height = VrtRght.Height / 2;//C1

                    //HrzRghtDwn.Width = VrtRght.Width;//D1
                    //HrzRghtDwn.Height = VrtRght.Height / 2;
                    //HrzRghtDwn.Left = HrzRghtTop.Left;
                    //HrzRghtDwn.Top = HrzRghtTop.Bottom;//D1

                    foreach (Control c in Hrzntl.Controls)
                    {


                        c.Invalidate();
                        if (c.Controls.Count > 0)
                        {
                            foreach (Control Cc in Controls)
                            {

                                Cc.Invalidate();
                                if (Cc.Controls.Count > 0)
                                {
                                    foreach (Control Ccc in Controls)
                                    {

                                        Ccc.Invalidate();
                                        if (Ccc.Controls.Count > 0)
                                        {
                                            foreach (Control Cccc in Controls)
                                            {

                                                Cccc.Invalidate();
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                    Visible = true;
                };

                {//Hrzntl
                    Hrzntl.Width = ClientSize.Width;
                    Hrzntl.Height = ClientSize.Height - LstCntrl.Height;
                    Hrzntl.Left = LstCntrl.Left;
                    Hrzntl.Top = LstCntrl.Bottom;
                    Hrzntl.BackColor = ClrdBck;
                    Hrzntl.Dock = DockStyle.Fill;
                    Hrzntl.BringToFront();
                    //Hrzntl.Width = Cnst.ScreeLftOver.Width;
                    //Hrzntl.Height = Cnst.ScreeLftOver.Height;
                    Hrzntl.Controls.Clear();

                    //Rectangle pnlScreen = Cnst.ScreeLftOver;//new Rectangle(Location.X, Location.Y, Cnst.ScreeLftOver.Width, Cnst.ScreeLftOver.Height);
                    //int w = Width >= pnlScreen.Width ? pnlScreen.Width : (pnlScreen.Width + Hrzntl.Width) / 2;
                    //int h = Height >= pnlScreen.Height ? pnlScreen.Height : (pnlScreen.Height + Hrzntl.Height) / 2;
                    //Size = new Size(w, h);
                    //
                    //Hrzntl.Size = new Size(w / 10 * 9, h / 10 * 9);
                    //Hrzntl.Location = new Point((Width - Hrzntl.Width) / 2, (Height - Hrzntl.Height) / 2);
                    Hrzntl.BringToFront();

                    {//VrtLft
                        VrtLft = new Panel();

                        VrtLft.Width = Hrzntl.Width / 5 * 4;
                        VrtLft.Height = Hrzntl.Height;
                        //VrtLft.Dock = DockStyle.Left;
                        VrtLft.BackColor = ClrBasePenelHolder;


                        {//Panel A1
                            HrzLftTop = new Panel();
                            HrzLftTop.Location = new Point(0, 0);
                            HrzLftTop.Width = VrtLft.Width;
                            HrzLftTop.Height = VrtLft.Height;
                            HrzLftTop.Dock = DockStyle.Fill;
                            HrzLftTop.BackColor = ClrBasePenelHolder;



                            //RichTextBox usrText = new RichTextBox(); usrText.Font = MFnt; 
                            //usrText.Font = MFnt;

                            PnTxt A = new PnTxt(HrzLftTop, new Point(2, 2), new Size(HrzLftTop.Width, HrzLftTop.Height), ClrdBck, Color.Tomato, ClrdBck, MFnt, true);//, "PnTxt")
                            A.BorderStyle = BorderStyle.FixedSingle;
                            //A.BorderStyle = BorderStyle.None;


                            A.ForeColor = ClrdBck;
                            //usrText.Dock = DockStyle.Fill;
                            A.Size = new Size(HrzLftTop.Width, HrzLftTop.Height);
                            A.Dock = DockStyle.Fill;
                            A.Location = new Point(2, 2);
                            Cnst.A = A;
                            //Cnst.A.Enabled = false;
                            Cnst.A.BackColor = ClrdFrnt;
                            Cnst.A.ForeColor = ClrdBck;

                            if (Cnst.A.WrtnTxt == true)
                            {
                                //Cnst.A.UsVl.BackColor = Color.DarkOrange;
                                //Cnst.A.UsVl.SelectionProtected = false;
                            }
                            else
                            {
                                //Cnst.A.UsVl.SelectionProtected = true;
                                Cnst.A.UsVl.BackColor = ClrdBck;
                            }
                            //HrzLftTop.Controls.Add(Cnst.A);

                            //Cnst.A
                            //HrzLftTop.Controls.Add(dntTouchMe);
                        }//Panel A1
                        {//Panel B1
                            HrzLftDwn = new Panel();
                            HrzLftDwn.Width = VrtLft.Width;
                            HrzLftDwn.Height = VrtLft.Height / 2;
                            HrzLftDwn.Left = HrzLftTop.Left;
                            HrzLftDwn.Top = HrzLftTop.Bottom;
                            //HrzLftDwn.Dock = DockStyle.Bottom;
                            HrzLftDwn.BackColor = ClrBasePenelHolder;
                            //HrzLftDwn.AutoScroll = true;


                            //RichTextBox usrText = new RichTextBox(); usrText.Font = MFnt;


                            //PnTxt B = new PnTxt(HrzLftDwn, new Point(0, 0), new Size(HrzLftDwn.Width, HrzLftDwn.Height), ClrdBck, MFnt, false);//, "PnTxt")
                            //B.BorderStyle = BorderStyle.FixedSingle;
                            ////B.BackColor = ClrdBck;
                            ////B.ForeColor = ClrdFrnt;
                            ////B.BorderStyle = BorderStyle.None;
                            ////usrText.BackColor = ClrdBck;
                            ////usrText.ForeColor = ClrdFrnt;
                            ////usrText.Size = new Size(HrzLftDwn.Width, HrzLftDwn.Height / 3);
                            //B.Dock = DockStyle.Fill;
                            ////usrText.Location = new Point(2, 2);
                            //Cnst.B = B;
                            //HrzLftDwn.Controls.Add(Cnst.B);
                        }//Panel B1

                        //VrtLft.Controls.Add(HrzLftDwn);
                        //VrtLft.Controls.Add(HrzLftTop);
                    }//VrtLft
                    LstCntrl = VrtLft;

                    {//VrtRght
                        VrtRght = new Panel();

                        VrtRght.Width = Hrzntl.Width - VrtLft.Right;
                        VrtRght.Height = Hrzntl.Height;
                        VrtRght.Dock = DockStyle.Right;
                        VrtRght.BackColor = ClrBasePenelHolder;


                        {//Panel C1
                            HrzRghtTop = new Panel();
                            HrzRghtTop.Location = new Point(0, 0);
                            HrzRghtTop.Width = VrtRght.Width;
                            HrzRghtTop.Height = VrtRght.Height;
                            HrzRghtTop.Dock = DockStyle.Fill;
                            HrzRghtTop.BackColor = ClrBasePenelHolder;



                            //RichTextBox usrText = new RichTextBox(); usrText.Font = MFnt;
                            //usrText.BorderStyle = BorderStyle.None;
                            //usrText.BackColor = ClrdBck;
                            //usrText.ForeColor = ClrdFrnt;
                            PnTxt C = new PnTxt(HrzRghtTop, new Point(2, 2), new Size(HrzRghtTop.Width, HrzRghtTop.Height), ClrdBck, Color.Black, ClrdFrnt, mFntCh, false);//, "PnTxt")
                            C.BorderStyle = BorderStyle.FixedSingle;
                            //usrText.BackColor = ClrdBck;
                            //usrText.ForeColor = ClrdFrnt;
                            //usrText.Size = new Size(HrzLftDwn.Width, HrzLftDwn.Height / 3);
                            //C.Dock = DockStyle.Fill;
                            C.Size = new Size(HrzRghtTop.Width, HrzRghtTop.Height / 2);
                            C.Dock = DockStyle.Right;
                            C.Location = new Point(2, 2);
                            Cnst.C = C;
                            HrzRghtTop.Controls.Add(Cnst.C);
                        }//Panel C1
                        {//Panel D1
                            HrzRghtDwn = new Panel();
                            HrzRghtDwn.Width = VrtRght.Width;
                            HrzRghtDwn.Height = VrtRght.Height / 2;
                            HrzRghtDwn.Left = HrzRghtTop.Left;
                            HrzRghtDwn.Top = HrzRghtTop.Bottom;
                            //HrzRghtDwn.Dock = DockStyle.Bottom;
                            HrzRghtDwn.BackColor = ClrBasePenelHolder;
                            //HrzRghtDwn.AutoScroll = true;

                            //RichTextBox usrText = new RichTextBox(); usrText.Font = MFnt;
                            //
                            //usrText.BorderStyle = BorderStyle.None;
                            //usrText.BackColor = ClrdBck;
                            //usrText.ForeColor = ClrdFrnt;
                            //PnTxt D = new PnTxt(HrzRghtDwn, new Point(2, 2), new Size(HrzRghtDwn.Width, HrzRghtDwn.Height), ClrdBck, mFntCh, false);//, "PnTxt")
                            //D.BorderStyle = BorderStyle.FixedSingle;
                            ////usrText.BackColor = ClrdBck;
                            ////usrText.ForeColor = ClrdFrnt;
                            ////usrText.Size = new Size(HrzLftDwn.Width, HrzLftDwn.Height / 3);
                            //D.Dock = DockStyle.Fill;
                            ////usrText.Location = new Point(2, 2);
                            //Cnst.D = D;
                            //HrzRghtDwn.Controls.Add(Cnst.D);
                        }//Panel D1

                        //VrtRght.Controls.Add(HrzRghtDwn);
                        VrtRght.Controls.Add(HrzRghtTop);
                    }//VrtRght
                    Prgrm.Controls.Add(Cnst.A);
                    Prgrm.Controls.Add(Cnst.C);

                    foreach (Control c in Prgrm.Controls)
                    {


                        //foreach (Control c in Controls)
                        {
                            //c.MouseHover += (senderf, f) =>
                            //{
                            //    ToolTip hint2 = new ToolTip();
                            //    hint2.SetToolTip(c, c.ToString());
                            //};
                            //if (c.Controls.Count > 0)
                            //{
                            //    foreach (Control Cc in Controls)
                            //    {

                            //        Cc.MouseHover += (senderf, f) =>
                            //        {
                            //            ToolTip hint2 = new ToolTip();
                            //            hint2.SetToolTip(Cc, Cc.ToString());
                            //        };
                            //        if (Cc.Controls.Count > 0)
                            //        {
                            //            foreach (Control Ccc in Controls)
                            //            {
                            //                Ccc.MouseHover += (senderf, f) =>
                            //                {
                            //                    ToolTip hint2 = new ToolTip();
                            //                    hint2.SetToolTip(Ccc, Ccc.ToString());
                            //                };
                            //            }
                            //        }
                            //    }

                            //}
                        }
                        c.MouseLeave += (sender, e) =>
                        {

                            {

                            }
                        };





                        c.ForeColor = Color.FromArgb(32, 78, 70);
                        c.Invalidate();
                        if (c.Controls.Count > 0)
                        {
                            foreach (Control Cc in Controls)
                            {
                                Cc.MouseHover += (sender, e) =>
                                {
                                    ToolTip hint = new ToolTip();
                                    hint.SetToolTip(c, "Pokus");

                                };
                                Cc.ForeColor = Color.FromArgb(32, 78, 70);
                                Cc.Invalidate();
                                if (Cc.Controls.Count > 0)
                                {
                                    foreach (Control Ccc in Controls)
                                    {
                                        Ccc.MouseHover += (sender, e) =>
                                        {
                                            ToolTip hint = new ToolTip();
                                            hint.SetToolTip(c, "Pokus");

                                        };
                                        Ccc.ForeColor = Color.FromArgb(32, 78, 70);
                                        Ccc.Invalidate();
                                    }
                                }
                            }

                        }
                    }

                }//Hrzntl
                //Hrzntl.Visible = false;
                Prgrm.Controls.Add(Hrzntl);

            }//newDSG
            {//internal MainForm   

                // Form Location and Position
                Screen activeScreen = Screen.FromPoint(MousePosition);
                Cnst.S.addApp(this);
                StartPosition = FormStartPosition.Manual;
                Location = activeScreen.WorkingArea.Location;
                Size = activeScreen.WorkingArea.Size;





                //Show(); // form
            }//internal MainForm
        }//FUNCTION - private----
        private void IntrScr()
        {
            IndexOfWordsDsgn();
            Prgrm.Visible = true;
            Prgrm.BringToFront();
            
            try
            {
                //Intro Screen

                Cnst.S.scIntrBackground.Location = new Point(0, 0);
                Cnst.S.scIntrBackground.BackColor = Color.Black;
                Cnst.S.scIntrBackground.Size = new Size(ClientSize.Width, ClientSize.Height);
                Cnst.S.scIntrBackground.Dock = DockStyle.Fill;
                //Cnst.S.scIntrBackground.BringToFront();
                DrwCore.Location = new Point(19, 16);
                DrwCore.Height = ClientSize.Height - 17 - 20;
                DrwCore.Width = ClientSize.Width - 17 - 20;
                DrwCore.BackColor = ClrdBck;
                DrwCore.Dock = DockStyle.Fill;
                DrwCore.MouseUp += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Right && Tckr.Enabled == true)
                    {
                        TmOfClick = DateTime.Now;
                        if (FghEnd>(int)TmOfClick.Ticks)
                        {
                            //DrwCore.Dispose();
                            //Prgrm.Visible = true;
                            Prgrm.BringToFront();
                            //Cnst.S.scIntrBackground.SendToBack();
                            //Prgrm.BringToFront();
                            Cnst.S.scIntrBackground.Hide();
                        }
                        //MessageBox.Show(TmerStart.ToString());
                        //MessageBox.Show(TmerEnd.ToString());
                        //MessageBox.Show(FghEnd.ToString());
                    }


                };
                Cnst.S.scIntrBackground.Controls.Add(DrwCore);

                Controls.Add(Cnst.S.scIntrBackground);
                Cnst.S.scIntrBackground.BringToFront();
                Prgrm.SendToBack();
                
                //Draw some Controls

                {//Draw some Controls


                    Random mManager = new Random();
                    int fnt = 17;
                    Font fntMine = new Font("Litograph", fnt, FontStyle.Bold);
                    //Pro zadaný text vytvořit index, tj. slovník s označením všech výskytů v textu v podobě číslo řádku lomítko číslo pozice. Ignorovat slova kratší než 4 znaky, slova obsahující číslo, slova samými velkými písmeny.  Zvládat i diakritiku a cizí znakové sady.

                    string[] fill = { "Pro", "zadaný", "text", "vytvořit", "index,", "tj.", " slovník", " s", "označením", " všech", " výskytů", "v", "textu", "v", "podobě", " číslo", " řádku", "lomítko", " číslo", "pozice", " .", "Ignorovat slova kratší než 4 znaky, slova obsahující číslo, slova samými velkými písmeny.", "Zvládat i diakritiku a cizí znakové sady."};
                    //string tXt0 = "", tXt1, tXt2, tXt3, tXt4, tXt5, tXt6, tXt7, tXt8;
                    
                    int rndCreate = mManager.Next(0, (fill.Length - 1));
                    for (int i = 0; i < rndCreate; i++)
                    {
                        string tXtI=fill[mManager.Next(rndCreate)];
                        IntroStrngs.Add(tXtI);
                    }
                    

                    for (int i = 0; i < IntroStrngs.Count; i++)
                    {
                        Random rndm = new Random();
                        LblAnmtd sssAnmtd = new LblAnmtd(new Point(i*30, i*30), DrwCore, IntroStrngs[i]);
                        
                        sssAnmtd.Font = fntMine;
                        DrwCore.Controls.Add(sssAnmtd);
                        
                        {//Create new Move2D for later execution
                            //MessageBox.Show("Tckr.tick=Tckr is in middle");

                            { //Create new Move2D for later execution

                                LblAnmtd.Move2D animationON = new LblAnmtd.Move2D(rndm.Next(55, 95), rndm.Next(58, 95));
                                sssAnmtd.ReceiveMove(animationON,33);
                                //e.Graphics.DrawString(sssAnmtd.Text, mgnr.Font, new SolidBrush(Color.FromArgb(rndm.Next(50, 255), rndm.Next(0, 255), rndm.Next(25, 255))), sssAnmtd.Location.X + (txtSz2.Width / 2) + i * 10, sssAnmtd.Location.Y + (txtSz2.Height / 2) + i * 10);

                            }//Create new Move2D for later execution
                            {//Execute && Update Move2D
                             //Cnst.S.Ticker.Interval = 33;
                             //Cnst.S.Ticker.Tick += (senderr, r) =>
                             //{
                             //    foreach (LblAnmtd lbl in Cnst.S.Movement2D)
                             //    {
                             //        lbl.Ticker_Tick2();
                             //    }
                             //    Cnst.S.Movement2D.RemoveAll(lbl => lbl.isMoving == false);
                             //    if (Cnst.S.Movement2D.Count == 0) Cnst.S.Ticker.Stop();
                             //    //IntersectBlocks();
                             //    //Cnst.S.scIntrBackground.Refresh();
                             //    DrwCore.Refresh();
                             //};
                            }//Execute && Update Move2D



                        }//Create new Move2D for later execution
                    }
                }//Draw some Controls
                Cnst.S.scIntrBackground.Paint += (sender, e) =>
                {
                    //{////ClientResultsDraw
                    //    GraphicsContainer Brdr = e.Graphics.BeginContainer();//BaseLines Container
                    //    int w = ClientSize.Width-28, h = ClientSize.Height - 28;
                    //    Pen pncl = new Pen(Color.DarkOrange, 7f);
                    //    Pen pnclDash = new Pen(ForeColor, 3f);
                        
                    //    pnclDash.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    //    SpwLc = new Point(0, 0);
                    //    e.Graphics.ScaleTransform(1.0f, -1.0f);
                    //    e.Graphics.TranslateTransform(14, 56 - Height);
                    //    Rectangle rmck = new Rectangle();
                    //    rmck.Height = h;
                    //    rmck.Width = w;//funguje 
                    //    e.Graphics.DrawRectangle(pncl, rmck);
                        
                        
                    //    e.Graphics.EndContainer(Brdr);//ContainerEnd////BaseLines Container
                        

                    //}//ClientResultsDraw
                    


                };//Draw some Controls

                {//Print
                    // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
                    Bitmap smaBmp = new Bitmap(DrwCore.Width, DrwCore.Height);
                    DrwCore.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

                    string myPath = Application.StartupPath;
                    myPath += "\\Intro Screen.jpg";
                    //MessageBox.Show(myPath);
                    try//Save print
                    { smaBmp.Save(myPath, ImageFormat.Jpeg); }
                    catch (Exception) { }//Save print
                }//Print+Save
                
                {//PictureBox
                    PictureBox scIntr = new PictureBox();
                    scIntr.Location = new Point(0, 0);
                    if (ClientSize.Width > ClientSize.Height)
                    {
                        scIntr.Size = new Size(ClientSize.Height, ClientSize.Height);
                        scIntr.Location = new Point((ClientSize.Width - scIntr.Width) / 2, 0);
                    }
                    else
                    {
                        scIntr.Size = new Size(ClientSize.Width, ClientSize.Width);
                    }
                    scIntr.BackColor = Color.BlueViolet;
                    scIntr.SizeMode = PictureBoxSizeMode.StretchImage;
                    string autoPathScr = Application.StartupPath;
                    //---Some Changes---------
                    autoPathScr += "\\Intro Screen.jpg";//New Load
                                                        //autoPathScr += "\\IntrScr\\IntrScrZeuCnst.S.jpg";//Old Load
                                                        //MessageBox.Show(autoPathScr);
                    try
                    {
                        scIntr.Image = Image.FromFile(autoPathScr);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }//Load the picture
                    scIntr.BringToFront();
                    //Controls.Add(scIntr);

                }//PictureBox
                
                Tckr.Interval = 5500;
                Tckr.Start();
                TmerStart = DateTime.Now;
                Fgh = (int)TmerStart.Ticks;
                TmerEnd = TmerStart.AddSeconds(5).AddMilliseconds(500);
                FghEnd= (int)TmerEnd.Ticks;
                ClctIntrval = ((int)TmerEnd.Ticks - (int)TmerStart.Ticks) / 10000;
                {//Execute && Update Move2D
                    Cnst.S.Ticker.Interval = 833;
                    Cnst.S.Ticker.Tick += (senderr, r) =>
                    {
                        

                        foreach (LblAnmtd lbl in Cnst.S.Movement2D)
                        {
                            lbl.Ticker_Tick2();
                        }
                        Cnst.S.Movement2D.RemoveAll(lbl => lbl.isMoving == false);
                        if (Cnst.S.Movement2D.Count == 0) Cnst.S.Ticker.Stop();
                        //IntersectBlocks();
                        //Cnst.S.scIntrBackground.Refresh();
                        DrwCore.Refresh();
                    };
                }//Execute && Update Move2D
                
                Tckr.Tick += (sender, e) =>
                {
                    
                    Prgrm.BringToFront();
                    {//Dsgn last touch

                        {//ToolsStrip - Top line
                            menuStrip = new ToolStrip();//The top level control:ToolStrip - base menu line
                            menuStrip.Dock = DockStyle.Top;//Docking

                            {//"File"

                                //"File" Button context for the menu
                                fileMenuStrip = new ContextMenuStrip();
                                fileMenuStrip.Opening += (senderr, r) =>
                                {
                                    //FILL FILE MENU each time it is opened
                                    //clear old items
                                    fileMenuStrip.Items.Clear();
                                    //decide what to show

                                    {//Show set of buttons - Base Set
                                     //show it                                      Title, Icon,   click handler, name of control                
                                        fileMenuStrip.Items.Add(new ToolStripMenuItem("New", null, onNewFileClick, "newFileButton"));
                                        fileMenuStrip.Items.Add(new ToolStripMenuItem("Open", null, onOpenFileClick, "openFileButton"));
                                        fileMenuStrip.Items.Add(new ToolStripMenuItem("Save", null, onSaveFileClick, "saveFileButton"));
                                    }//Show set of buttons - Base Set

                                    // EventArgs.Cancel default is true (i have no idea what it does :)
                                    r.Cancel = false;
                                };//"File" Button context for the menu


                                // "File" -the drop down button in menu
                                ToolStripDropDownButton file = new ToolStripDropDownButton("File", null, null, "File");
                                menuStrip.Items.Add(file);//asign the button to exact menu-"menuStrip"
                                file.DropDown = fileMenuStrip;//asign DropDown context
                                                              // "File" -the drop down button in menu
                            }//"File"
                            {//"Statistics"-Filter                     
                             // "Statistics"-the clasic button in menu- Top line

                                menuStrip.Items.Add(new ToolStripMenuItem("Filter", null, sttstcsClick, "sttstcsButton"));//asign the button to exact menu-"menuStrip"

                            }//"Statistics"
                            {//"WritenText"                     
                                //"WritenText" - the clasic button in menu - Top line

                                //menuStrip.Items.Add(new ToolStripMenuItem("WritenText", null, wrtnTxtClick, "wrtnTxtButton"));//asign the button to exact menu-"menuStrip"

                            }//"WritenText"
                            {//"Options"
                             //"Options"- Button context for the menu
                                optionsMenuStrip = new ContextMenuStrip();
                                optionsMenuStrip.Opening += (senderr, r) =>
                                {
                                    /*FILL OPTIONS MENU*/
                                    optionsMenuStrip.Items.Clear();
                                    optionsMenuStrip.Items.Add(new ToolStripMenuItem("Animate", null, onAnimateOptionClick, "animateButton"));
                                    r.Cancel = false;
                                };//"Options"- Button context for the menu


                                // "Options"-the drop down button in menu
                                ToolStripDropDownButton options = new ToolStripDropDownButton("Options", null, null, "Options");
                                //menuStrip.Items.Add(options);//asign the button to exact menu-"menuStrip"
                                options.DropDown = optionsMenuStrip;//asign DropDown context
                                                                    // "Options"-the drop down button in menu
                            }//"Options"

                            Controls.Add(menuStrip);
                        }//ToolStrip - Top line

                        {//Status bar - botom line
                            statusStrip = new StatusStrip();
                            statusStrip.Dock = DockStyle.Bottom;
                            //ticker instancing
                            ticker.Tick += (senderr, r) =>
                            {
                                progress.PerformStep();
                                label.Text = progress.Value.ToString() + "% Complete";
                                if (progress.Value == 100)
                                {
                                    progress.Value = 0;
                                }
                            };
                            //progress bar in status strip
                            progress = new ToolStripProgressBar();
                            progress.Minimum = 0;
                            progress.Maximum = 100;
                            progress.Step = 1;
                            progress.Width = 500;
                            progress.Value = 45;
                            //statusStrip.Items.Add(progress);

                            // label in status
                            label = new ToolStripLabel();
                            
                            Cnst.A.UsVl.TextChanged += (senderr, r) => 
                            {
                                int ndx = Cnst.A.UsVl.Text.LastIndexOfAny(Cnst.A.UsVl.Text.ToArray());
                                List<string> Lines = Cnst.A.UsVl.Text.Split('\n').ToList();
                                label.Text = "Lines: "+Lines.Count.ToString()+" / "+ndx.ToString();
                                Lines.Clear();
                            };
                            label.Text = "Lines: 0";
                            statusStrip.Items.Add(label);

                            Controls.Add(statusStrip);
                        }//Status bar - botom line
                    }//Dsgn last touch
                    
                    Cnst.S.scIntrBackground.Hide();

                    Tckr.Stop();
                    
                    foreach (Control t in Controls)
                    {
                        //Font = new Font("Cambria", FntSize, FontStyle.Bold);
                        //BackColor = Color.Black;
                        ForeColor = ClrdFrnt;
                    }
                    //TxtSpltrDsgn();
                    
                    {//DirectoryCreation
                     // Specify the directory you want to manipulate.
                        string myPath = Application.StartupPath;
                        myPath += "\\User save";
                        try
                        {
                            // Determine whether the directory existCnst.S.
                            if (Directory.Exists(myPath))
                            {
                                //MessageBox.Show("That path exists already.");
                                return;
                            }

                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(myPath);
                            //MessageBox.Show("The directory was created successfully at {0}.", Directory.GetCreationTime(myPath).ToLongDateString());

                            // Delete the directory.
                            //di.Delete();
                            //Console.WriteLine("The directory was deleted successfully.");
                        }
                        catch (Exception z)
                        {
                            MessageBox.Show("The process failed: {0}", z.ToString());
                        }
                        finally { }

                    }//DirectoryCreation
                    
                    //MessageBox.Show((fndout.Count).ToString());
                };//Intro Screen
            }
            catch (Exception) { }//IntroScr
        }//Startup seting for window
        //FUNCTION PUBLIC----------------------------------------------    
        
        public void MyClrInvrt(Color cl)
        {
            ClrInver = Color.FromArgb(cl.ToArgb() ^ 0xffffff);
            ForeColor = ClrInver;
        }
        public void DbgTltps()
        {//Position of added controls

            {//Draw over Time
                {//Create new Draw over Time for later execution
                    MTltip.DrwOverTime drwot = new MTltip.DrwOverTime(50);
                    
                    //PrsmSlct.ReceiveMove(prsmSlctUsrVal, 43);
                }//Create new Draw over Time for later execution
                {//asign whoo will be drawed
                }//asign whoo will be drawed
                {//Execute && DRAW Move3d
                    Cnst.S.Ticker.Interval = 33;

                    Cnst.S.Ticker.Tick += (senderf, f) =>
                    {
                        foreach (MTltip q in Cnst.S.TPaint)
                        {
                            q.Ticker_Tick2();
                            //q.Ticker_Tick();

                        }
                        Cnst.S.TPaint.RemoveAll(q => q.isDrwing == false);
                        if (Cnst.S.TPaint.Count == 0) Cnst.S.Ticker.Stop();

                        //S.Cnvs.Refresh();

                    };
                }//Execute && DRAW Move3d
            }



                Invalidate();
            //MessageBox.Show(Cnst.Source.ClientRectangle.Size.ToString());

            foreach (Control c in Controls)
            {

                c.ForeColor = Color.FromArgb(32, 78, 70);
                c.Invalidate();
                {//Draw over Time
                    {//Create new Draw over Time for later execution
                        MTltip.DrwOverTime drwot = new MTltip.DrwOverTime(10);
                        if (c is MTltip)
                        {
                            
                            
                        }
                        //PrsmSlct.ReceiveMove(prsmSlctUsrVal, 43);
                    }//Create new Draw over Time for later execution

                    {//Execute && DRAW Move3d
                        Cnst.S.Ticker.Interval = 33;

                        Cnst.S.Ticker.Tick += (senderf, f) =>
                        {
                            foreach (MTltip q in Cnst.S.TPaint)
                            {
                                q.Ticker_Tick2();
                                //q.Ticker_Tick();

                            }
                            Cnst.S.TPaint.RemoveAll(q => q.isDrwing == false);
                            if (Cnst.S.TPaint.Count == 0) Cnst.S.Ticker.Stop();

                            //S.Cnvs.Refresh();

                        };
                    }//Execute && DRAW Move3d
                }
                if (c.Controls.Count > 0)
                {
                    foreach (Control Cc in Controls)
                    {
                        Cc.ForeColor = Color.FromArgb(32, 78, 70);
                        Cc.Invalidate();
                        if (Cc.Controls.Count > 0)
                        {
                            foreach (Control Ccc in Controls)
                            {
                                Ccc.ForeColor = Color.FromArgb(32, 78, 70);
                                Ccc.Invalidate();
                            }
                        }
                    }

                }
            }
            //Controls.Clear();
            //HdrDsgn();
        }
        public void RposCntrols()
        {//Position of added controls
            Invalidate();
            //MessageBox.Show(Cnst.Source.ClientRectangle.Size.ToString());

            foreach (Control c in Controls)
            {
                //c.ForeColor = Color.FromArgb(32, 78, 70);
                c.Invalidate();
                if (c.Controls.Count > 0)
                {
                    foreach (Control Cc in Controls)
                    {
                        //Cc.ForeColor = Color.FromArgb(32, 78, 70);
                        Cc.Invalidate();
                        if (Cc.Controls.Count > 0)
                        {
                            foreach (Control Ccc in Controls)
                            {
                                //Ccc.ForeColor = Color.FromArgb(32, 78, 70);
                                Ccc.Invalidate();
                            }
                        }
                    }

                }
            }
            //Controls.Clear();
            //HdrDsgn();
            {//Hldr
                //Hldr.Size = Cnst.ScreeLftOver.Size;
                //Hldr.Location = Cnst.ScreeLftOver.Location;
                //Hldr.BackColor = Color.Transparent;
                //Hldr.BackColor = Color.FromArgb(70, Color.Violet);
                //Hldr.BringToFront();
                //Hldr.Invalidate();
                //Controls.Add(Hldr);
            }//Hldr
             //Hrzntl.Location = Cnst.ScreeLftOver.Location;
            {//Hrzntl
             //Hrzntl.Location = Cnst.ScreeLftOver.Location;
             //Hrzntl.BackColor = Color.Blue;
             ////Hrzntl.Dock = DockStyle.Bottom;
             //Hrzntl.BringToFront();
             ////Hrzntl.Width = Cnst.ScreeLftOver.Width;
             ////Hrzntl.Height = Cnst.ScreeLftOver.Height;
             //Hrzntl.Controls.Clear();

                //Rectangle pnlScreen = Cnst.ScreeLftOver;//new Rectangle(Location.X, Location.Y, Cnst.ScreeLftOver.Width, Cnst.ScreeLftOver.Height);
                //int w = Width >= pnlScreen.Width ? pnlScreen.Width : (pnlScreen.Width + Hrzntl.Width) / 2;
                //int h = Height >= pnlScreen.Height ? pnlScreen.Height : (pnlScreen.Height + Hrzntl.Height) / 2;
                //Size = new Size(w, h);

                //Hrzntl.Size = new Size(w / 10 * 9, h / 10 * 9);
                //Hrzntl.Location = new Point((Width - Hrzntl.Width) / 2, (Height - Hrzntl.Height) / 2);
                //Hrzntl.BringToFront();

                //{//VrtLft
                //    VrtLft = new Panel();

                //    VrtLft.Width = Hrzntl.Width / 2;
                //    VrtLft.Height = Hrzntl.Height;
                //    VrtLft.Dock = DockStyle.Left;
                //    VrtLft.BackColor = Color.FromArgb(90, Color.WhiteSmoke);


                //    {//Panel A1
                //        HrzLftTop = new Panel();
                //        HrzLftTop.Width = VrtLft.Width;
                //        HrzLftTop.Height = VrtLft.Height / 2;
                //        HrzLftTop.Dock = DockStyle.Top;
                //        HrzLftTop.BackColor = Color.FromArgb(90, Color.Yellow);



                //        RichTextBox usrText = new RichTextBox(); usrText.Font = MFnt;

                //        usrText.BorderStyle = BorderStyle.None;
                //        usrText.BackColor = ClrdBck;
                //        usrText.ForeColor = ClrdFrnt;
                //        usrText.Size = new Size(HrzLftTop.Width, HrzLftTop.Height / 3);
                //        usrText.Dock = DockStyle.Fill;
                //        usrText.Location = new Point(2, 2);
                //        HrzLftTop.Controls.Add(usrText);
                //    }//Panel A1
                //    {//Panel B1
                //        HrzLftDwn = new Panel();
                //        HrzLftDwn.Width = VrtLft.Width;
                //        HrzLftDwn.Height = VrtLft.Height / 2;
                //        HrzLftDwn.Dock = DockStyle.Bottom;
                //        HrzLftDwn.BackColor = Color.FromArgb(90, Color.LimeGreen);
                //        //HrzLftDwn.AutoScroll = true;

                //        PnTxt usrText = new PnTxt(this,new Point(2, 2), new Size(HrzLftDwn.Width, HrzLftDwn.Height), ClrdFrnt, MFnt);
                //        usrText.BorderStyle = BorderStyle.None;
                //        //usrText.BackColor = ClrdBck;
                //        //usrText.ForeColor = ClrdFrnt;
                //        //usrText.Size = new Size(HrzLftDwn.Width, HrzLftDwn.Height / 3);
                //        usrText.Dock = DockStyle.Fill;
                //        //usrText.Location = new Point(2, 2);

                //        HrzLftDwn.Controls.Add(usrText);
                //    }//Panel B1

                //    VrtLft.Controls.Add(HrzLftDwn);
                //    VrtLft.Controls.Add(HrzLftTop);
                //}//VrtLft



                //Hrzntl.Controls.Add(VrtLft);


            }//Hrzntl
             //Controls.Add(Hrzntl);
        }
        public void PrintScreen()
        {
            //!!SAVE PICTURE FILE ON DISC!!---------------------------------
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            string myPath = Application.StartupPath;//Setting HomeFolder for saving future PrtScr.jpg
            myPath += "\\SpliterScreen.jpg"; //Adding Name for PrtScr.jpg
            try
            {
                bmp.Save(myPath, ImageFormat.Jpeg);//SAVE!!
            }
            catch (Exception) { }
            //!!SAVE PICTURE FILE ON DISC!!---------------------------------
        }
        
    }

    //Classes


    //context menu for Textures

    //context menu for Panels




}
