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
using System.Text.RegularExpressions;

namespace NdexOfWords
{
    public class PnTxt: Panel
    {
        public List<String> Hstry = new List<string>();
        public Panel DntTouchMe = new Panel();
        public Font MFnt = new Font("Litograph", 9, FontStyle.Regular);
        public RichTextBox UsVl = new RichTextBox();
        public int UsrVal=0;
        private Point mdFrameLoc;
        private Point mouseDownLoc;
        private bool frameMoving;
        public bool FrLocked = true;
        public Size OriginSize;
        public Point OriLoca;
        public bool WrtnTxt = false;
        public bool ShdOver = false;
        public bool Mvble = false;
        public bool ClckdBefore = false;
        public Color ClrInver;
        public Color ClrdFrnt = Color.FromArgb(255,32, 45, 37);
        public Color ClrdBck = Color.Chocolate;
        public Color BClrPanel;
        public Color MsOver = Color.FromArgb(166,Color.LightGray);
        public void MyClrInvrt(Color cl)
        {
            ClrInver = Color.FromArgb(cl.ToArgb() ^ 0xffffff);
            ForeColor = ClrInver;
        }
        public Control MPrnt;
        public Control MLnk;


        public Font LddTxtFnt = new Font("Litograph", 9, FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
        public PnTxt(Control parent, Point p, Size sz, Color bclr,  Font fnt,bool wrtnTxt)
        {
            
            {//This
                MPrnt = parent;
                //ShdOver = shdO;
                WrtnTxt = wrtnTxt;
                DoubleBuffered = true; OriginSize = sz;
                Location = p; OriLoca = p; Size = sz;
                BorderStyle = BorderStyle.FixedSingle;
                BackColor = BClrPanel = bclr;
                //BackColor = Color.FromArgb(100, bclr);
                MyClrInvrt(BackColor); Font = fnt;
                MouseDown += (sender, e) =>
                {

                    if (FrLocked)
                    {

                    }
                    else
                    {
                        mdFrameLoc = this.Location;
                        mouseDownLoc = e.Location;
                        if (e.Button == MouseButtons.Left) frameMoving = true;



                        //BringToFront();
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
                        //OriLoca = new Point(left * 100 / Cnst.Source.ZoomPerc, top * 100 / Cnst.Source.ZoomPerc);
                        //Invalidate();

                    }
                };
                MouseUp += (sender, e) =>
                {
                    frameMoving = false;
                    switch (e.Button)
                    {
                        case MouseButtons.Left:

                            if (this.Location == mdFrameLoc)
                            {
                                break;
                            }

                            break;
                        case MouseButtons.Middle:
                            if (this.Location == mdFrameLoc) { break; }
                            break;
                        case MouseButtons.Right:

                            if (this.Location == mdFrameLoc)
                            {
                                Point parentLoc = new Point(0, 0);
                                try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                                try { Cnst.justOne.Dispose(); } catch (Exception) { }
                                //Point myP = Cursor.Position;
                                //CntxtMenu myCP = new CntxtMenu(myP, this);
                                Cnst.justOne = new CntxtMenu(parentLoc, this);
                                UsVl.SendToBack();
                                Cnst.justOne.BringToFront();
                                if (Cnst.justOne.Width > Width | Cnst.justOne.Height > Height)
                                {
                                    Size = Cnst.justOne.Size;
                                }

                            }
                            break;
                        default:
                            break;
                    }

                };

                MouseHover += (sender, e) =>
                {
                    BackColor = MsOver;
                };
                MouseLeave += (sender, e) =>
                {
                    BackColor = bclr;
                };

                SizeChanged += (sender, e) =>
                {
                    Rectangle pnlScreen = new Rectangle(Location.X, Location.Y, Width, Height);
                    int w = Width >= pnlScreen.Width ? pnlScreen.Width : (pnlScreen.Width + Width) / 2;
                    int h = Height >= pnlScreen.Height ? pnlScreen.Height : (pnlScreen.Height + Height) / 2;
                    Size = new Size(w, h);

                    UsVl.Size = new Size(w / 10 * 9, h / 10 * 9);
                    UsVl.Location = new Point((Width - UsVl.Width) / 2, (Height - UsVl.Height) / 2);
                    UsVl.BringToFront();
                };
                BringToFront();
            }//This
            {//Textbox

                UsVl.BackColor = ClrdBck; UsVl.ForeColor = ClrdFrnt;
                UsVl.Font = fnt;

                Rectangle pnlScreen = new Rectangle(Location.X, Location.Y, Width, Height);
                int w = Width >= pnlScreen.Width ? pnlScreen.Width : (pnlScreen.Width + Width) / 2;
                int h = Height >= pnlScreen.Height ? pnlScreen.Height : (pnlScreen.Height + Height) / 2;
                Size = new Size(w, h);

                UsVl.Size = new Size(w / 10 * 9, h / 10 * 9);
                UsVl.Location = new Point((Width - UsVl.Width) / 2, (Height - UsVl.Height) / 2);
                //UsVl.BringToFront();

                UsVl.BorderStyle = BorderStyle.None;
                UsVl.MouseDown += (sender, e) =>
                {
                    
                    if (FrLocked)
                    {
                        //UsVl.SelectAll();
                        //UsVl.Focus();
                        

                    }
                    else
                    {
                        mdFrameLoc = this.Location;
                        mouseDownLoc = e.Location;
                        if (e.Button == System.Windows.Forms.MouseButtons.Left) frameMoving = true;



                        //BringToFront();
                    }

                };
                UsVl.MouseMove += (sender, e) =>
                {
                    if (frameMoving)
                    {
                        int left = Left + (e.X - mouseDownLoc.X);
                        int top = Top + (e.Y - mouseDownLoc.Y);
                        if (top < 0) top = 0;
                        if (left < 0) left = 0;
                        Top = top;
                        Left = left;
                        //OriLoca = new Point(left * 100 / Cnst.Source.ZoomPerc, top * 100 / Cnst.Source.ZoomPerc);
                        //Invalidate();

                    }
                };
                UsVl.MouseUp += (sender, e) =>
                {
                    frameMoving = false;
                    switch (e.Button)
                    {
                        case MouseButtons.Left:

                            if (Cnst.A.WrtnTxt == false&& Cnst.A.UsVl.Text == UsVl.Text)
                            {
                                Cnst.B.UsVl.Focus();
                                Cnst.B.UsVl.SelectionStart = Cnst.B.UsVl.Text.Length;
                            }
                            if (this.Location == mdFrameLoc)
                            {
                                //UsVl.SelectAll();
                                //UsVl.SelectionBackColor = UsVl.BackColor;
                                //UsVl.AutoWordSelection = true;
                                //UsVl.DeselectAll();
                                break;
                            }

                            break;
                        case MouseButtons.Middle:
                            if (this.Location == mdFrameLoc) { break; }
                            break;
                        case MouseButtons.Right:

                            if (this.Location == mdFrameLoc)
                            {
                                Point parentLoc = new Point(0, 0);
                                try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                                try { Cnst.justOne.Dispose(); } catch (Exception) { }
                                //Point myP = Cursor.Position;
                                //CntxtMenu myCP = new CntxtMenu(myP, this);
                                Cnst.justOne = new CntxtMenu(parentLoc, this);
                                Cnst.justOne.BringToFront();
                                if (Cnst.justOne.Width>Width| Cnst.justOne.Height > Height)
                                {
                                    Size = Cnst.justOne.Size;
                                }
                                
                            }
                            break;
                        default:
                            break;
                    }

                };
                UsVl.KeyDown += (sender, e) =>
                {
                    if (UsVl.Text!="")
                    {
                        if (Hstry.Count<1)
                        {
                            Hstry.Add(UsVl.Text);
                        }
                        else
                        {
                            if (Hstry[Hstry.Count-1]!= UsVl.Text)
                            {
                                Hstry.Add(UsVl.Text);
                            }
                        }
                        
                    }
                };
                
                UsVl.KeyUp += (sender, e) =>
                {
                    if (e.KeyData == Keys.Enter)
                    {

                    }
                    else
                    {
                        if (Cnst.A.UsVl.Text == UsVl.Text&& WrtnTxt==false)
                        {
                            //get index=position of cursor in string==UsVl.SelectionStart
                            //UsVl.Text.Remove(UsVl.SelectionStart - 1);
                            //UsVl.SelectAll();
                            
                            //UsVl.SelectionProtected = true;
                            //Cnst.A.UsVl.Text = Cnst.LddFile;
                            //UsVl.Invalidate();
                            //UsVl.SelectAll();
                            //UsVl.SelectionProtected = true;
                            Cnst.B.UsVl.Focus ();
                            //then compair chars - itireteration

                            //then delete the changes

                            //UsVl.Text = UsVl.Text.Remove(UsVl.Text.Length - 1);

                            //if (System.Text.RegularExpressions.Regex.IsMatch(UsVl.Text, ""))
                            //{
                            //    //if (UsVl.SelectionStart - 1<0)
                            //    //{
                            //    //    UsVl.SelectionStart = 1;
                            //    //}
                            //    try
                            //    {
                            //        //UsVl.Text = UsVl.Text.Remove(UsVl.SelectionStart - 1);
                            //    }
                            //    catch (Exception){}



                            //}
                        }
                        else
                        {
                            if (Cnst.A.UsVl.Text == UsVl.Text && WrtnTxt == true)
                            {
                                //get index=position of cursor in string==UsVl.SelectionStart
                                //UsVl.Text.Remove(UsVl.SelectionStart - 1);
                                //UsVl.SelectAll();

                                //UsVl.SelectionProtected = false;
                                //Cnst.A.UsVl.Text = Cnst.LddFile;
                                //UsVl.Invalidate();
                                //UsVl.SelectAll();
                                //UsVl.SelectionProtected = false;
                               
                            }

                        }
                    }
                };
                UsVl.TextChanged += (sender, e) =>
                {
                    //MessageBox.Show("txt changed");

                    if (Cnst.A.UsVl.Text== UsVl.Text)
                    {


                        ParseText();
                        string prsTxt = "";
                        //Cnst.C.UsVl.Text = "";
                        foreach (KeyValuePair<string, List<Tuple<int, int>>> kvp in validWords)
                        {
                            if (prsTxt != "") prsTxt += "\r\n";
                            prsTxt += kvp.Key + " @(";
                            string output = "";
                            foreach (Tuple<int, int> t in kvp.Value)
                            {
                                if (output != "") output += ", ";
                                output += t.Item1.ToString() + "/" + t.Item2.ToString();
                            }
                            prsTxt += output + ")";
                            {//Two-Colored WORKING!!
                                string cction2 = "";
                                {//Two-Colored WORKING!!
                                    String sentence1 = Cnst.A.UsVl.Text;
                                    String sentence2 = kvp.Key;
                                    String sentence3 = kvp.Key;
                                    cction2 = sentence1 + sentence2+sentence3;
                                    int start1 = cction2.IndexOf(sentence1);//correction of IndexOf()  -for every newLine neded!                                    
                                    String subString1 = cction2.Substring(start1, sentence1.Length);
                                    bool match1 = (sentence1 == subString1); // true
                                    //Cnst.A.UsVl.SelectionStart = start1;
                                    //Cnst.A.UsVl.SelectionLength = sentence1.Length;
                                    //Cnst.A.UsVl.SelectionColor = Color.Red;


                                    int start2 = cction2.IndexOf(sentence2);
                                    String subString2 = cction2.Substring(start2, sentence2.Length);
                                    bool match2 = (sentence2 == subString2); // true
                                    Cnst.A.UsVl.SelectionStart = start2;
                                    Cnst.A.UsVl.SelectionLength = sentence2.Length;
                                    Cnst.A.UsVl.SelectionColor = Color.Blue;

                                    int whl = kvp.Value.Count - 1;
                                    if (kvp.Value.Count>0)
                                    {
                                        while (whl>(-100))
                                        {

                                            int start3 = kvp.Value[whl].Item2;
                                            String subString3 = cction2.Substring(start3, sentence3.Length);
                                            bool match3 = (sentence3 == subString3);
                                            Cnst.A.UsVl.SelectionStart = start3;
                                            Cnst.A.UsVl.SelectionLength = sentence3.Length;
                                            Cnst.A.UsVl.SelectionColor = Color.AliceBlue;
                                            whl--;

                                        }

                                    }
                                    //int start3 = kvp.Value[0].Item2;//(sentence3);
                                    //String subString3 = cction2.Substring(start3, sentence3.Length);
                                    
                                    //bool match3 = (sentence3 == subString3); // true
                                    

                                    
                                    //Cnst.A.UsVl.SelectionStart = start3;
                                    //Cnst.A.UsVl.SelectionLength = sentence3.Length;
                                    //Cnst.A.UsVl.SelectionColor = Color.AliceBlue;
                                }//Two-Colored WORKING!!
                            }//Two-Colored WORKING!!
                        }

                        if (Cnst.A.WrtnTxt == true)
                        {
                            //Cnst.B.UsVl.Text = Cnst.A.UsVl.Text;
                            Cnst.A.UsVl.Font = Cnst.A.Font;
                            //Cnst.A.UsVl.SelectAll();
                            Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Left;

                            Cnst.A.UsVl.Invalidate();
                            //Cnst.A.UsVl.Focus();
                            //Cnst.A.UsVl.Select(Cnst.A.UsVl.Text.Length , 0);
                            //Cnst.A.UsVl.SelectionStart = Cnst.A.UsVl.Text.Length;
                        }
                        if (Cnst.A.WrtnTxt == false)
                        {
                            //Cnst.B.UsVl.Text = Cnst.A.UsVl.Text;
                            Cnst.A.UsVl.Font = LddTxtFnt;
                            Cnst.A.UsVl.SelectAll();
                            Cnst.A.UsVl.SelectionAlignment = HorizontalAlignment.Center;
                            Cnst.A.UsVl.DeselectAll();
                            //Cnst.A.UsVl.Invalidate();
                            Cnst.B.UsVl.Focus();
                            //Cnst.B.UsVl.Select(Cnst.B.UsVl.Text.Length , 0);
                            Cnst.B.UsVl.SelectionStart = Cnst.B.UsVl.Text.Length;
                        }
                        if (Cnst.LddFile != ""&& Cnst.A.WrtnTxt == false)
                        {
                            //Cnst.B.UsVl.Text = Cnst.A.UsVl.Text;
                        }

                        {//Base data minig

                            Cnst.C.UsVl.Text = "";

                            //Words Count algoritm
                            var text = UsVl.Text.Trim();
                            int wordCount = 0, index = 0;

                            while (index < text.Length)
                            {
                                // check if current char is part of a word
                                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                                    index++;

                                wordCount++;

                                // skip whitespace until next word
                                while (index < text.Length && char.IsWhiteSpace(text[index]))
                                    index++;
                            }//Words Count algoritm

                            string output = "";
                            {//Letters frequency
                             // 1.
                             // Array to store frequencies.
                                int[] c = new int[(int)char.MaxValue];

                                // 2.
                                // Read entire text file.
                                string s = UsVl.Text;

                                // 3.
                                // Iterate over each character.
                                foreach (char t in s)
                                {
                                    // Increment table.
                                    c[(int)t]++;
                                }

                                // 4.
                                // Write all letters found.
                                int sprtrCorr = 0;
                                for (int i = 0; i < (int)char.MaxValue; i++)
                                {
                                    if (c[i] > 0 && char.IsLetter((char)i))
                                    {
                                        output += ("Letter: " + (char)i + "=) " + c[i] + " *" + Environment.NewLine);
                                        //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                        //    (char)i,
                                        //    c[i]);
                                    }
                                    if (c[i] > 0 && char.IsDigit((char)i))
                                    {
                                        output += ("Digit: " + (char)i + "=) " + c[i] + " *" + Environment.NewLine);
                                        //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                        //    (char)i,

                                    }
                                    if (c[i] > 0 && char.IsWhiteSpace((char)i))
                                    {
                                        sprtrCorr = c[i];
                                        output += ("WhiteSpace: " + (char)i + "=) " + c[i] + " *" + Environment.NewLine);
                                        //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                        //    (char)i,

                                    }
                                    if (c[i] > 0 && char.IsSeparator((char)i))
                                    {
                                        output += ("Separator: " + (char)i + "=) " + (c[i] - sprtrCorr) + " *" + Environment.NewLine);
                                        //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                        //    (char)i,

                                    }

                                }

                            }//Letters frequency

                            //MessageBox.Show(output);
                            Cnst.C.UsVl.Text = "Filtered words:" + Environment.NewLine + prsTxt + Environment.NewLine + Environment.NewLine + "Your text contains:" + Environment.NewLine + (wordCount).ToString() + " words. " + Environment.NewLine + "Letters Count: " + Environment.NewLine + (index).ToString() + Environment.NewLine + "Frequency of occurrence: " + Environment.NewLine + output;
                            Cnst.C.UsVl.Invalidate();
                        }//Base data minig
                        //Cnst.B.UsVl.Invalidate();
                    }
                    if (Cnst.B.UsVl.Text == UsVl.Text)
                    {
                        Cnst.D.UsVl.Text = "";

                        int wordCount = 0, index = 0;
                        {//Words Count algoritm
                            var text = UsVl.Text.Trim();
                            

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
                            string s = UsVl.Text;

                            // 3.
                            // Iterate over each character.
                            foreach (char t in s)
                            {
                                // Increment table.
                                c[(int)t]++;
                            }

                            // 4.
                            // Write all letters found.
                            int sprtrCorr = 0;
                            for (int i = 0; i < (int)char.MaxValue; i++)
                            {
                                if (c[i] > 0 &&char.IsLetter((char)i))
                                {
                                    output += ("Písmeno: " + (char)i + "=) " + c[i] + " x" + Environment.NewLine);
                                    //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                    //    (char)i,
                                    //    c[i]);
                                }
                                if (c[i] > 0 && char.IsDigit((char)i))
                                {
                                    output += ("Číslice: " + (char)i + "=) " + c[i] + " x" + Environment.NewLine);
                                    //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                    //    (char)i,

                                }
                                if (c[i] > 0 && char.IsWhiteSpace((char)i))
                                {
                                    sprtrCorr = c[i];
                                    output += ("Mezera: " + (char)i + "=) " + c[i] + " x" + Environment.NewLine);
                                    //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                    //    (char)i,

                                }
                                if (c[i] > 0 && char.IsSeparator((char)i))
                                {
                                    output += ("Oddělovač: " + (char)i + "=) " + (c[i] -sprtrCorr)+ " x" + Environment.NewLine);
                                    //Console.WriteLine("Letter: {0}  Frequency: {1}",
                                    //    (char)i,

                                }
                                
                            }

                        }//Letters frequency

                        //MessageBox.Show(output);
                        Cnst.D.UsVl.Text = "Your text contains:" + Environment.NewLine  + (wordCount).ToString() + " slov, "+Environment.NewLine+ "Celkem použito písmen: " + Environment.NewLine + (index).ToString() + Environment.NewLine+"Frekvence výskytu: "+Environment.NewLine+output;
                        Cnst.D.UsVl.Invalidate();
                    }
                    if (Cnst.D.UsVl.Text == UsVl.Text)
                    {
                        List<string> output = new List<string>();
                        try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                        try { Cnst.justOne.Dispose(); } catch (Exception) { }
                        {//Show statistics//changest to text from original file
                            var first = Cnst.B.UsVl.Text.Split(' ');
                            var second = Cnst.D.UsVl.Text.Split(' ');
                            var primary = first.Length > second.Length ? first : second;
                            var secondary = primary == second ? first : second;
                            var difference = primary.Except(secondary).ToArray();
                            output = difference.ToList();
                            
                            //MessageBox.Show(output);
                            //Cnst.B.UsVl.Text = output;
                            Cnst.B.UsVl.Invalidate();
                        }//Show statistics
                    }

                    //if (System.Text.RegularExpressions.Regex.IsMatch(UsVl.Text, "[^0-9]"))
                    //{
                    //    //
                    //    //

                        //    //


                        //}


                        //int trpars = 0;
                        //if (int.TryParse(UsVl.Text, out trpars))
                        //{ UsrVal = trpars; }
                        //else
                        //{

                        //    if (UsVl.Text=="-"| UsVl.Text == "+"){}
                        //    else
                        //    {


                        //        if (UsVl.Text!="")
                        //        {
                        //            MTltip hint = new MTltip();
                        //            hint.SetToolTip(UsVl, "Please enter only numbers.");
                        //            UsVl.Text = UsVl.Text.Remove(UsVl.Text.Length - 1);
                        //        }

                        //    }
                        //    //
                        //    UsrVal = 0;
                        //}


                };
                UsVl.MouseHover += (sender, e) =>
                {
                    BackColor = BClrPanel;
                    if (Cnst.A.UsVl.Text == UsVl.Text && Cnst.A.WrtnTxt == true && Cnst.B.UsVl.Text != "" && Cnst.A.UsVl.Text != Cnst.B.UsVl.Text)
                    {
                        //ToolTip hint = new ToolTip();
                        //hint.SetToolTip(Cnst.A.UsVl, "Writing in this window will" + Environment.NewLine + " discard changes from the window" + Environment.NewLine + " below right now. To avoid loosing" + Environment.NewLine + " your work press Commit first.");
                        //MTltip hnt = new MTltip(Cnst.A.UsVl, Cnst.A.UsVl, "Writing in this window will" + Environment.NewLine + " discard changes from the window" + Environment.NewLine + " below right now. To avoid loosing" + Environment.NewLine + " your work press Commit first.", 80);

                    }
                    BackColor = MsOver;
                    
                    
                };
                UsVl.MouseLeave += (sender, e) =>
                {
                    BackColor = BClrPanel;
                };
                UsVl.GotFocus += (sender, e) =>
                {
                    if (Cnst.A.UsVl.Text == UsVl.Text && Cnst.A.UsVl.Text != "")
                    {        
                        Cnst.A.UsVl.SelectAll();
                        Cnst.A.UsVl.SelectionColor = Color.Black;
                        Cnst.A.UsVl.DeselectAll();
                    }
                    if (Cnst.B.UsVl.Text == UsVl.Text && Cnst.B.UsVl.Text != "" )
                    {
                        Cnst.B.UsVl.SelectAll();
                        Cnst.B.UsVl.SelectionColor = Color.Black;
                        Cnst.B.UsVl.DeselectAll();
                    }
                    BackColor = Color.FromArgb(90, BClrPanel);
                };
                UsVl.LostFocus += (sender, e) =>
                {
                    
                    BackColor = BClrPanel;
                };

                Controls.Add(UsVl);
            }//Textbox
            {//Buttons
                //{//Undo
                //    Button Ndo = new Button();
                //    Ndo.Anchor = AnchorStyles.Left+5 | AnchorStyles.Top+2;
                //    Ndo.Text = "<";
                //    Ndo.Size = new Size((Width - UsVl.Width) / 2-1, Height/10);// - UsVl.Height) / 2);
                //    Ndo.Font = new Font("Litograph", 9, FontStyle.Regular);
                //    Ndo.Visible = false;
                //    Controls.Add(Ndo);
                //    UsVl.Click += (sender, e) =>
                //    {
                //        Ndo.Visible = true;
                //    };
                //}//Undo
                //{//Redo
                //    Button Rdo = new Button();
                //    Rdo.Anchor = AnchorStyles.Left+5 | AnchorStyles.Top+2+ (Height / 10);
                //    Rdo.Text = ">";
                //    Rdo.Font= new Font("Litograph", 9, FontStyle.Regular);
                //    Rdo.Size = new Size((Width - UsVl.Width) / 2, (Height - UsVl.Height) );
                //    Rdo.Visible = false;
                //    Controls.Add(Rdo);
                //    UsVl.Click += (sender, e) =>
                //    {
                //        Rdo.Visible = true;
                //    };
                //}//Redo

            }//Buttons
            if (ShdOver==true)
            {
                {//ShadeOver
                    
                    DntTouchMe.Dock = DockStyle.Fill;
                    DntTouchMe.BackColor = Color.FromArgb(10, Cnst.S.Hdr2.BackColor);
                    DntTouchMe.MouseDown += (sender, e) =>
                    {

                    };


                    DntTouchMe.MouseMove += (sender, e) =>
                    {
                        if (frameMoving)
                        {
                            int left = Left + (e.X - mouseDownLoc.X);
                            int top = Top + (e.Y - mouseDownLoc.Y);
                            if (top < 0) top = 0;
                            if (left < 0) left = 0;
                            Top = top;
                            Left = left;
                            //OriLoca = new Point(left * 100 / Cnst.Source.ZoomPerc, top * 100 / Cnst.Source.ZoomPerc);
                            //Invalidate();

                        }
                    };
                    DntTouchMe.MouseUp += (sender, e) =>
                    {
                        frameMoving = false;
                        switch (e.Button)
                        {
                            case MouseButtons.Left:

                                if (this.Location == mdFrameLoc) { break; }

                                break;
                            case MouseButtons.Middle:
                                if (this.Location == mdFrameLoc) { break; }
                                break;
                            case MouseButtons.Right:

                                if (this.Location == mdFrameLoc)
                                {
                                    //Point parentLoc = new Point(0, 0);
                                    //try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                                    //try { Cnst.justOne.Dispose(); } catch (Exception) { }
                                    ////Point myP = Cursor.Position;
                                    ////CntxtMenu myCP = new CntxtMenu(myP, this);
                                    //Cnst.justOne = new CntxtMenu(parentLoc, this);
                                    //Cnst.justOne.BringToFront();
                                    //if (Cnst.justOne.Width > Width | Cnst.justOne.Height > Height)
                                    //{
                                    //    Size = Cnst.justOne.Size;
                                    //}

                                }
                                break;
                            default:
                                break;
                        }

                    };
                    DntTouchMe.KeyUp += (sender, e) =>
                    {
                        if (e.KeyData == Keys.Enter)
                        {

                        }
                    };

                    DntTouchMe.MouseHover += (sender, e) =>
                    {
                        BackColor = Color.FromArgb(20, 32, 78, 70);
                        //BackColor = fclr;

                    };
                    DntTouchMe.MouseLeave += (sender, e) => { BackColor = Color.FromArgb(20, bclr); };







                    DntTouchMe.BringToFront();
                    //Controls.Add(DntTouchMe);
                    UsVl.SendToBack();
                    UsVl.Controls.Add(DntTouchMe);
                }//ShadeOver
            }
            
            
            MPrnt.Controls.Add(this);
        }
        public Dictionary<string, List<Tuple<int, int>>> validWords = new Dictionary<string, List<Tuple<int, int>>>();
        protected bool inOp = false;
        public void ParseText()
        {
            if (!inOp)
            {
                inOp = true;
                validWords.Clear();
                string[] Lines = UsVl.Text.Split('\n');
                for (int i = 0; i < Lines.Length; i++)
                {
                    string line = Regex.Replace(Lines[i], @"\t|\n|\r", " ");
                    while (line.Contains("  ")) line = line.Replace("  ", " ");
                    string[] splitLine = line.Split(' ');
                    for (int j = 0; j < splitLine.Length; j++)
                    {
                        string word = splitLine[j].Trim(S.Separators);
                        if (word.Length > 3 && !word.Any(char.IsNumber) && word != word.ToUpper())
                        {
                            if (validWords.Keys.Contains(word))
                            {
                                Tuple<int, int> t = new Tuple<int, int>(i, j);
                                validWords[word].Add(t);
                            }
                            else
                            {
                                List<Tuple<int, int>> list = new List<Tuple<int, int>>();
                                Tuple<int, int> t = new Tuple<int, int>(i, j);
                                list.Add(t);
                                validWords.Add(word, list);
                            }
                        }
                    }
                }
                inOp = false;
            }
        }

        private void PnTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow 10 decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -10))
            {
                e.Handled = true;
            }
        }

        public void dsgFnt()
        {
            //UsVl.SelectAll();
            //UsVl.HorizontalAlignment= HorizontalAlignment.Center
            //UsVl.SelectionBackColor = Color.BlueViolet;
            //UsVl.SelectionFont = LddTxtFnt;
        }
    }
}
