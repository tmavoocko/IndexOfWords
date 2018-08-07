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
    public class CntxtMenu : MenuesContext
    {

        public CntxtMenu(Label p, CntxtMenu parent)
        {
            Label LastLbl = new Label();//FIRST Lbl!
            LastLbl.Location = new Point(2, 0);
            LastLbl.Text = "Frst";
            LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

            try//Menu properties 
            {
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                BackColor = parent.ForeColor;
                ForeColor = parent.BackColor;
                //BackColor = Color.FromArgb(95, 95, 95);
                Font = parent.myFont;
                BringToFront();
            }
            catch (Exception) { }//Menu properties = Labels below

            //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------
            

            try//Close - Labelbutton
            {
                Label clsLbl = new Label();//Auto positioned!!
                clsLbl.Text = "Close";
                clsLbl.TextAlign = ContentAlignment.MiddleCenter;
                clsLbl.BorderStyle = BorderStyle.Fixed3D;
                clsLbl.MouseHover += (sendere, z) =>
                {
                    clsLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    clsLbl.ForeColor = parent.ForeColor;
                    //clsLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                clsLbl.MouseLeave += (sendere, z) =>
                { //clsLbl.BackColor = Color.FromArgb(95, 95, 95);
                    clsLbl.BackColor = parent.ForeColor;
                    clsLbl.ForeColor = parent.BackColor;
                };
                clsLbl.Click += (sender, f) =>
                {
                    Dispose();
                    parent.Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    clsLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { clsLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                clsLbl.Size = LastLbl.Size;
                LastLbl = clsLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Close - Labelbutton
                                 //TOTALY AUTO GRAFICS BUTTONS!!=Labels ---------------above--------

            Left = p.Left;//Menu Positioning
            Top = p.Top;//Menu Positioning

            parent.Controls.Add(this);
            parent.Invalidate();
        }
        public CntxtMenu(Point p,Form1 parent)
        {
            Label LastLbl = new Label();//FIRST Lbl!
            LastLbl.Location = new Point(2, 0);
            LastLbl.Text = "Frst";
            LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

            try//Menu properties 
            {
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                BackColor = parent.ForeColor;
                ForeColor = parent.BackColor;
                //BackColor = Color.FromArgb(95, 95, 95);
                Font = parent.myFont;
                BringToFront();
            }
            catch (Exception) { }//Menu properties = Labels below
            //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------

            //TOTALY AUTO GRAFICS BUTTONS!!=Buttons below------------------------
            try//New Rcetangle
            {
                Label someB = new Label();
                someB.Text = "New Rectangle";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    //p = new Point(p.X, parent.Height - p.Y);
                    //PcBResizable pc = new PcBResizable(p, parent);
                    //pc.Size = new Size(20, 20); pc.Invalidate();
                    //parent.Header.Vlues.Text = pc.myValue.Text;
                    //parent.Header.Vlues.BackColor = pc.BackColor;
                    //parent.Header.MyClrInvrt(parent.Header.Vlues.BackColor);
                    //parent.Header.Vlues.ForeColor = ForeColor;
                    //parent.Header.Vlues.Invalidate();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//New Rcetangle
            try//SolveIt
            {
                Label someB = new Label();
                someB.Text = "Solve";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                    try { Cnst.justOne.Dispose(); } catch (Exception) { }

                    Cnst.justTwo = new BtnCntxtMenu(p, parent);
                    Cnst.justTwo.BringToFront();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//SolveIt
            try//Print
            {
                Label someB = new Label();
                someB.Text = "Print";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
                    Bitmap smaBmp = new Bitmap(parent.Width, parent.Height);
                    Dispose();//Dispose THE menu BEFORE PRINT!!
                    parent.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

                    string myPath = Application.StartupPath;
                    myPath += "\\User save\\Print Screen.jpg";
                    MessageBox.Show(myPath);
                    try//Save print
                    { smaBmp.Save(myPath, ImageFormat.Jpeg); }
                    catch (Exception) { }//Save print
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Print
            try//Clear
            {
                Label someB = new Label();
                someB.Text = "Clear";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    //Cnst.RcIntersect.Clear(); Cnst.MyRecs.Clear();
                    //foreach (PcBResizable pc in Cnst.PcBR)
                    //{ pc.Dispose(); }
                    //Cnst.PcBR.Clear();
                    //foreach (DrRslPan dr in Cnst.DrRsl)
                    //{ dr.Dispose(); }
                    //Cnst.DrRsl.Clear();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Clear
            try//SelectionDELETE
            {
                Label someB = new Label();
                someB.Text = "Delete Selected items";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    //if (!(Messlist.Contains(val)))
                    //foreach (PcBResizable pc in Controls)
                    //{
                    //    if (Cnst.PcBR.Intersect(Cnst.Slctd).Any())
                    //    {
                    //        Cnst.PcBR.Remove(pc);
                    //        parent.Controls.Remove(pc);
                    //        pc.Dispose();
                    //    }

                    //}
                    //foreach (DrRslPan drr in Controls)
                    //{
                    //    parent.Controls.Remove(drr);
                    //    drr.Dispose();
                    //}


                    //Cnst.RcDiffI.Clear();
                    //Cnst.RcDiffJ.Clear();
                    //Cnst.RcIntersect.Clear();
                    //Cnst.MyRecs.Clear();
                    //Cnst.PcBR.Clear();
                    //parent.Controls.Clear();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//SelectionDELETE
            try//Cancel
            {
                Label someB = new Label();
                someB.Text = "Cancel";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) => { Dispose(); };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Cancel
            try//Close
            {
                Label someB = new Label();
                someB.Text = "Close";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    parent.Close();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Close
            //TOTALY AUTO GRAFICS BUTTONS!!=Buttons ---------------above--------

            Left = p.X;//Positioning
            Top = p.Y;//Positioning
            // reposition acording to screen
            //Rectangle wArea = Screen.FromControl(this).WorkingArea;
            //if (Left < 0) Left = 0;
            //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
            //if (Top < 0) Top = 0;
            //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
            // reposition acording to screen

            parent.Controls.Add(this);
        }
        public CntxtMenu(Point p, DsgnInsVrtc parent)
        {
            Label LastLbl = new Label();//FIRST Lbl!
            LastLbl.Location = new Point(2, 0);
            LastLbl.Text = "Frst";
            LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

            try//Menu properties 
            {
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                BackColor = parent.ForeColor;
                ForeColor = parent.BackColor;
                //BackColor = Color.FromArgb(95, 95, 95);
                Font = parent.myFont;
                BringToFront();
            }
            catch (Exception) { }//Menu properties = Labels below
            //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------

            //TOTALY AUTO GRAFICS BUTTONS!!=Buttons below------------------------
            try//New Rcetangle
            {
                Label someB = new Label();
                someB.Text = "New Rectangle";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                 {
                     someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                     someB.ForeColor = parent.ForeColor;
                     //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                 };
                someB.MouseLeave += (sendere, z) =>
                 { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                     someB.BackColor = parent.ForeColor;
                     someB.ForeColor = parent.BackColor;
                 };
                someB.Click += (sender, f) =>
                {
                    //p = new Point(p.X, parent.Height - p.Y);
                    //PcBResizable pc = new PcBResizable(p, parent);
                    //pc.Size = new Size(20, 20);pc.Invalidate();
                    //parent.Header.Vlues.Text = pc.myValue.Text;
                    //parent.Header.Vlues.BackColor = pc.BackColor;
                    //parent.Header.MyClrInvrt(parent.Header.Vlues.BackColor);
                    //parent.Header.Vlues.ForeColor = ForeColor;
                    //parent.Header.Vlues.Invalidate();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }catch (Exception){ }//New Rcetangle
            try//SolveIt
            {
                Label someB = new Label();
                someB.Text = "Solve";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    

                    //Cnst.justTwo = new BtnCntxtMenu(p, parent);

                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//SolveIt
            try//Print
            {
                Label someB = new Label();
                someB.Text = "Print";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
                    Bitmap smaBmp = new Bitmap(parent.Width, parent.Height);
                    Dispose();//Dispose THE menu BEFORE PRINT!!
                    parent.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

                    string myPath = Application.StartupPath;
                    myPath += "\\User save\\Print Screen.jpg";
                    MessageBox.Show(myPath);
                    try//Save print
                    {smaBmp.Save(myPath, ImageFormat.Jpeg);}
                    catch (Exception) { }//Save print
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Print
            try//Clear
            {
                Label someB = new Label();
                someB.Text = "Clear";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    //Cnst.RcIntersect.Clear(); Cnst.MyRecs.Clear();
                    //foreach (PcBResizable pc in Cnst.PcBR)
                    //{ pc.Dispose(); }
                    //Cnst.PcBR.Clear();
                    //foreach (DrRslPan dr in Cnst.DrRsl)
                    //{ dr.Dispose(); }
                    //Cnst.DrRsl.Clear();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Clear
            try//SelectionDELETE
            {
                Label someB = new Label();
                someB.Text = "Delete Selected items";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    //if (!(Messlist.Contains(val)))
                    //foreach (PcBResizable pc in Controls)
                    //{
                    //    if (Cnst.PcBR.Intersect(Cnst.Slctd).Any())
                    //    {
                    //        Cnst.PcBR.Remove(pc);
                    //        parent.Controls.Remove(pc);
                    //        pc.Dispose();
                    //    }

                    //}
                    //foreach (DrRslPan drr in Controls)
                    //{
                    //    parent.Controls.Remove(drr);
                    //    drr.Dispose();
                    //}


                    //Cnst.RcDiffI.Clear();
                    //Cnst.RcDiffJ.Clear();
                    //Cnst.RcIntersect.Clear();
                    //Cnst.MyRecs.Clear();
                    //Cnst.PcBR.Clear();
                    //parent.Controls.Clear();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//SelectionDELETE
            try//Cancel
            {
                Label someB = new Label();
                someB.Text = "Cancel";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) => { Dispose(); };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Cancel
            try//Close
            {
                Label someB = new Label();
                someB.Text = "Close";
                someB.TextAlign = ContentAlignment.MiddleCenter;
                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
                someB.MouseHover += (sendere, z) =>
                {
                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    someB.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                someB.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    someB.BackColor = parent.ForeColor;
                    someB.ForeColor = parent.BackColor;
                };
                someB.Click += (sender, f) =>
                {
                    //parent.Close();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                someB.Size = LastLbl.Size;
                LastLbl = someB;//automated grafics for menu!!
                Controls.Add(LastLbl);//automated grafics for menu!!
            }
            catch (Exception) { }//Close
            //TOTALY AUTO GRAFICS BUTTONS!!=Buttons ---------------above--------

            Left = p.X;//Positioning
            Top = p.Y;//Positioning
            // reposition acording to screen
            //Rectangle wArea = Screen.FromControl(this).WorkingArea;
            //if (Left < 0) Left = 0;
            //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
            //if (Top < 0) Top = 0;
            //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
            // reposition acording to screen

            parent.Controls.Add(this);
        }
        //public CntxtMenu(Point p, DsgnCnv parent)
        //{
        //    if (S.Cnvs.PrsmDrw==true&&Cnst.To3D==true)
        //    {

        //        {
        //            Label LastLbl = new Label();//FIRST Lbl!
        //            LastLbl.Location = new Point(2, 0);
        //            LastLbl.Text = "Frst";
        //            LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

        //            try//Menu properties 
        //            {
        //                AutoSize = true;
        //                AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //                BackColor = parent.ForeColor;
        //                ForeColor = parent.BackColor;
        //                //BackColor = Color.FromArgb(95, 95, 95);
        //                Font = parent.myFont;
        //                BringToFront();
        //            }
        //            catch (Exception) { }//Menu properties = Labels below

        //            //TOTALY AUTO GRAFICS BUTTONS!!=Buttons below------------------------
        //            try//Render
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Nový kvádr";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    S.Hdr.PrsmCreator();
        //                    S.Hdr.HldrRfrsh();

        //                    parent.Axe = "Rslt3D";
        //                    parent.Refresh();

        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//NewPrsm
        //            try//Render
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Render";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    parent.Rndr = true;
        //                    parent.Axe = "Tst3D";
        //                    parent.Invalidate();
        //                    //p = new Point(p.X, parent.Height - p.Y);
        //                    //PcBResizable pc = new PcBResizable(p, parent);
        //                    //pc.Size = new Size(20, 20);pc.Invalidate();
        //                    //parent.Header.Vlues.Text = pc.myValue.Text;
        //                    //parent.Header.Vlues.BackColor = pc.BackColor;
        //                    //parent.Header.MyClrInvrt(parent.Header.Vlues.BackColor);
        //                    //parent.Header.Vlues.ForeColor = ForeColor;
        //                    //parent.Header.Vlues.Invalidate();
        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Render
        //            try//Show Time
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Show Time";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    parent.ShwTm = true;

        //                    //parent.Axe = "Tst3D";
        //                    parent.Invalidate();

        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Show Time
        //            try//ReDraw
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Reset - Redraw";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (senderm, m) =>
        //                {
        //                    parent.Paint += (senderf, f) =>
        //                    {
        //                        //MessageBox.Show("MCnvs Paint += (sender, e) =>  =Active ");
        //                        switch (parent.Axe)
        //                        {
        //                            case "Y": parent.YDraw(f.Graphics); break;
        //                            case "X": parent.XDraw(f.Graphics); break;
        //                            case "Crss": parent.CrssDraw(f.Graphics); break;
        //                            case "Rslt2D": parent.RsltDraw2D(f.Graphics); break;
        //                            case "Rslt3D":


        //                                parent.RsltDrawIso(f.Graphics);
        //                                break;
        //                            case "Tst3D":
        //                                //3d
        //                                if (Cnst.Intrsc3D.Count > 0)
        //                                {


        //                                }
        //                                if (parent.Rndr == true)//&& Cnst.Intrsc3D.Count == 0)
        //                                {
        //                                    S.Ticker.Interval = 33;
        //                                    S.Ticker.Tick += (senders, s) =>
        //                                    {
        //                                        foreach (Prism q in parent.Movement)
        //                                        {
        //                                            q.Ticker_Tick();
        //                                        }
        //                                        parent.Movement.RemoveAll(q => q.isMoving == false);
        //                                        if (parent.Movement.Count == 0) S.Ticker.Stop();
        //                                        //PrIntrsctBlocks();
        //                                        Refresh();
        //                                    };

        //                                    {////ClientResultsDraw
        //                                        GraphicsContainer BsLns = f.Graphics.BeginContainer();//BaseLines Container
        //                                        int w = Width, h = Cnst.ScreeLftOver.Height;
        //                                        Pen pncl = new Pen(Color.Red, 2f);
        //                                        Pen pnclDash = new Pen(ForeColor, 3f);
        //                                        pnclDash.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
        //                                        //SpwLc = new Point(0, 0);
        //                                        f.Graphics.ScaleTransform(1.0f, -1.0f);
        //                                        f.Graphics.TranslateTransform(0, 0 - Height);
        //                                        foreach (Prism prsm in Cnst.MPrisms)
        //                                        {
        //                                            Rectangle[] m3DRcs = Cnst.My3DRcsColl.ToArray();
        //                                            foreach (Point[] pnts in prsm.VsblSides)
        //                                            {
        //                                                f.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(60, prsm.PrsmClr)), pnts);
        //                                                SizeF txtSz = f.Graphics.MeasureString("+", myFont);
        //                                                //e.Graphics.FillPolygon(new SolidBrush(Color.White), pnts);
        //                                                //e.Graphics.DrawString("+", myFont, new SolidBrush(Color.Violet), p.X - (txtSz.Width / 2), p.Y - (txtSz.Height/2));
        //                                            }
        //                                            pncl.Color = prsm.PrsmClr;
        //                                            pnclDash.Color = System.Drawing.Color.FromArgb(70, prsm.PrsmClr);
        //                                            foreach (Point[] pnts in prsm.InvsblSides)
        //                                            {
        //                                                f.Graphics.DrawPolygon(pnclDash, pnts);
        //                                            }
        //                                            foreach (Point[] pnts in prsm.VsblSides)
        //                                            {
        //                                                f.Graphics.DrawPolygon(pncl, pnts);
        //                                            }
        //                                        }



        //                                        f.Graphics.EndContainer(BsLns);//ContainerEnd////BaseLines Container


        //                                    }//ClientResultsDraw

        //                                    //TstDraw3D(e.Graphics);

        //                                }
        //                                if (parent.ShwTm == true)
        //                                {
        //                                    //3d
        //                                    parent.DashedForePen.DashStyle = DashStyle.DashDot;
        //                                    //ZMENA//
        //                                    parent.DashedForePen.DashStyle = DashStyle.DashDot;
        //                                    parent.DashedPrunikPen.DashStyle = DashStyle.DashDot;

        //                                    parent.DashedForePen.DashStyle = DashStyle.DashDot;
        //                                    parent.DashedPrunikPen.DashStyle = DashStyle.DashDot;
        //                                    S.Ticker.Interval = 33;
        //                                    S.Ticker.Tick += (senders, s) =>
        //                                    {
        //                                        foreach (Kvadr q in parent.Pohyby)
        //                                        {
        //                                            q.Ticker_Tick();
        //                                        }
        //                                        parent.Pohyby.RemoveAll(q => q.isMoving == false);
        //                                        if (parent.Pohyby.Count == 0) S.Ticker.Stop();
        //                                        parent.PrIntrsctBlocks();
        //                                        Refresh();
        //                                    };
        //                                    //3d
        //                                    //TstDraw3D(e.Graphics);

        //                                    foreach (Kvadr kv in parent.Kvadry)
        //                                    {
        //                                        if (parent.ConjuctionSwitch)
        //                                        {
        //                                            parent.ConjunctionPen.Color = Color.FromArgb(100, kv.KvdrClr);
        //                                            parent.DashedConjunctionPen.Color = Color.FromArgb(80, kv.KvdrClr);
        //                                            foreach (Kvadr obal in kv.Konjukce)
        //                                            {
        //                                                foreach (Cara line in obal.BackLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.DashedConjunctionPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.ConjunctionPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                                foreach (Cara line in obal.MiddleLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.DashedConjunctionPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.ConjunctionPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                                foreach (Cara line in obal.FrontLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.DashedConjunctionPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.ConjunctionPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                        // ZMENA // nakreslim vnitrky
        //                                        if (parent.SubBlockSwitch)
        //                                        {
        //                                            //MyClrInvrt(kv.KvdrClr);
        //                                            parent.SubKvadrPen.Color = Color.FromArgb(90, kv.KvdrClr);
        //                                            foreach (Kvadr subKvadr in kv.SubKvadry)
        //                                            {
        //                                                foreach (Cara line in subKvadr.BackLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        if (kv.Selected) f.Graphics.DrawLine(parent.DashedSelectedPen, line.Start.To2d, line.End.To2d);
        //                                                        else f.Graphics.DrawLine(parent.DashedSubKvadrPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (kv.Selected) f.Graphics.DrawLine(parent.SelectedPen, line.Start.To2d, line.End.To2d);
        //                                                        else f.Graphics.DrawLine(parent.SubKvadrPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                                foreach (Cara line in subKvadr.MiddleLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        if (kv.Selected) f.Graphics.DrawLine(parent.DashedSelectedPen, line.Start.To2d, line.End.To2d);
        //                                                        else f.Graphics.DrawLine(parent.DashedSubKvadrPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (kv.Selected) f.Graphics.DrawLine(parent.SelectedPen, line.Start.To2d, line.End.To2d);
        //                                                        else f.Graphics.DrawLine(parent.SubKvadrPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                                foreach (Cara line in subKvadr.FrontLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        if (kv.Selected) f.Graphics.DrawLine(parent.DashedSelectedPen, line.Start.To2d, line.End.To2d);
        //                                                        else f.Graphics.DrawLine(parent.DashedSubKvadrPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (kv.Selected) f.Graphics.DrawLine(parent.SelectedPen, line.Start.To2d, line.End.To2d);
        //                                                        else f.Graphics.DrawLine(parent.SubKvadrPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }




        //                                        if (parent.MainBlockSwitch)
        //                                        {

        //                                            parent.ForePen.Color = Color.FromArgb(100, kv.KvdrClr);
        //                                            //MyClrInvrt(kv.KvdrClr);
        //                                            parent.DashedForePen.Color = Color.FromArgb(85, kv.KvdrClr);

        //                                            foreach (Cara line in kv.BackLines)
        //                                            {
        //                                                if (line.Invisible)
        //                                                {
        //                                                    if (kv.Selected) f.Graphics.DrawLine(parent.DashedSelectedPen, line.Start.To2d, line.End.To2d);
        //                                                    else f.Graphics.DrawLine(parent.DashedForePen, line.Start.To2d, line.End.To2d);

        //                                                }
        //                                                else
        //                                                {
        //                                                    if (kv.Selected) f.Graphics.DrawLine(parent.SelectedPen, line.Start.To2d, line.End.To2d);
        //                                                    else f.Graphics.DrawLine(parent.ForePen, line.Start.To2d, line.End.To2d);
        //                                                }
        //                                            }
        //                                            foreach (Cara line in kv.MiddleLines)
        //                                            {
        //                                                if (line.Invisible)
        //                                                {
        //                                                    if (kv.Selected) f.Graphics.DrawLine(parent.DashedSelectedPen, line.Start.To2d, line.End.To2d);
        //                                                    else f.Graphics.DrawLine(parent.DashedForePen, line.Start.To2d, line.End.To2d);

        //                                                }
        //                                                else
        //                                                {
        //                                                    if (kv.Selected) f.Graphics.DrawLine(parent.SelectedPen, line.Start.To2d, line.End.To2d);
        //                                                    else f.Graphics.DrawLine(parent.ForePen, line.Start.To2d, line.End.To2d);
        //                                                }
        //                                            }
        //                                            foreach (Cara line in kv.FrontLines)
        //                                            {
        //                                                if (line.Invisible)
        //                                                {
        //                                                    if (kv.Selected) f.Graphics.DrawLine(parent.DashedSelectedPen, line.Start.To2d, line.End.To2d);
        //                                                    else f.Graphics.DrawLine(parent.DashedForePen, line.Start.To2d, line.End.To2d);

        //                                                }
        //                                                else
        //                                                {
        //                                                    if (kv.Selected) f.Graphics.DrawLine(parent.SelectedPen, line.Start.To2d, line.End.To2d);
        //                                                    else f.Graphics.DrawLine(parent.ForePen, line.Start.To2d, line.End.To2d);
        //                                                }
        //                                            }
        //                                        }
        //                                        if (parent.IntersectSwitch)
        //                                        {
        //                                            parent.PrunikPen.Color = Color.FromArgb(90, parent.ClrdBck);
        //                                            parent.DashedPrunikPen.Color = Color.FromArgb(90, parent.ClrdBck);
        //                                            foreach (Kvadr prunik in kv.Pruniky)
        //                                            {
        //                                                foreach (Cara line in prunik.BackLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.DashedPrunikPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.PrunikPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                                foreach (Cara line in prunik.MiddleLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.DashedPrunikPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.PrunikPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                                foreach (Cara line in prunik.FrontLines)
        //                                                {
        //                                                    if (line.Invisible)
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.DashedPrunikPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        f.Graphics.DrawLine(parent.PrunikPen, line.Start.To2d, line.End.To2d);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                    //Invalidate();
        //                                    //ShwTm = false;

        //                                }



        //                                break;
        //                            //case "Tst3D": AddPolygonExample(e.Graphics); break;
        //                            case "Clnt": parent.ClntDraw(f.Graphics); break;
        //                            case "D2": parent.D2Draw(f.Graphics); break;
        //                            case "D3": parent.D3Draw(f.Graphics); break;
        //                            default:
        //                                break;
        //                        }

        //                    };

        //                    S.Cnvs.Refresh();

        //                    //p = new Point(p.X, parent.Height - p.Y);
        //                    //PcBResizable pc = new PcBResizable(p, parent);
        //                    //pc.Size = new Size(20, 20);pc.Invalidate();


        //                    ////parent.Header.Vlues.Text = pc.myValue.Text;
        //                    ////parent.Header.Vlues.BackColor = pc.BackColor;
        //                    ////parent.Header.MyClrInvrt(parent.Header.Vlues.BackColor);
        //                    ////parent.Header.Vlues.ForeColor = ForeColor;
        //                    ////parent.Header.Vlues.Invalidate();
        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//ReDraw
        //            try//Original
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Original";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (senderm, m) =>
        //                {
        //                    if (S.Cnvs.PrsmDrw == true)
        //                    {
        //                        {//Clear all result Lists
        //                            Cnst.Intrsc3D.Clear();
        //                            Cnst.CmbnPrsms3D.Clear();
        //                            Cnst.DifrPrsms3D.Clear();
        //                            Cnst.Intrsc3DOfIntrsct.Clear();
        //                        }//Clear all result Lists

        //                        foreach (Prism pr in Cnst.MPrisms)
        //                        {
        //                            //pr.RstMe();
        //                        }

        //                    }
        //                    if (S.Cnvs.KvdrDrw == true)
        //                    {
        //                        S.Cnvs.MainBlockSwitch = true;//baseDraw
        //                        S.Cnvs.SubBlockSwitch = false;//diffr
        //                        S.Cnvs.IntersectSwitch = false;//Intrsct
        //                        S.Cnvs.ConjuctionSwitch = false;//cmbn
        //                        foreach (Kvadr kv in S.Cnvs.Kvadry)
        //                        {
        //                            //kv.RstMe();
        //                        }

        //                    }

        //                    S.Cnvs.Refresh();

        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Original
        //            try//SolveIt
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Solve";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {

        //                    try
        //                    {
        //                        Cnst.justTwo.Dispose();
        //                    }
        //                    catch (Exception) { }
        //                    try
        //                    {
        //                        Cnst.jstTry.Dispose();
        //                    }
        //                    catch (Exception) { }
        //                    //Cnst.justTwo = new BtnCntxtMenu(p, parent);
        //                    Cnst.jstTry = new CntxtMenu(someB, this);
        //                    //Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                //LastLbl = someB;//automated grafics for menu!!
        //                //Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//SolveIt
        //            try//Print
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Print";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
        //                    Bitmap smaBmp = new Bitmap(parent.Width, parent.Height);
        //                    Dispose();//Dispose THE menu BEFORE PRINT!!
        //                    parent.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

        //                    string myPath = Application.StartupPath;
        //                    myPath += "\\User save\\Print Screen.jpg";
        //                    MessageBox.Show(myPath);
        //                    try//Save print
        //                    { smaBmp.Save(myPath, ImageFormat.Jpeg); }
        //                    catch (Exception) { }//Save print
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Print
        //            try//Clear
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Clear";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    Cnst.RcIntersect.Clear(); Cnst.MyRecs.Clear();
        //                    foreach (PcBResizable pc in Cnst.PcBR)
        //                    { pc.Dispose(); }
        //                    Cnst.PcBR.Clear();
        //                    foreach (DrRslPan dr in Cnst.DrRsl)
        //                    { dr.Dispose(); }
        //                    Cnst.DrRsl.Clear();
        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Clear
        //            try//SelectionDELETE
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Delete Selected items";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    //if (!(Messlist.Contains(val)))
        //                    //foreach (PcBResizable pc in Controls)
        //                    //{
        //                    //    if (Cnst.PcBR.Intersect(Cnst.Slctd).Any())
        //                    //    {
        //                    //        Cnst.PcBR.Remove(pc);
        //                    //        parent.Controls.Remove(pc);
        //                    //        pc.Dispose();
        //                    //    }

        //                    //}
        //                    //foreach (DrRslPan drr in Controls)
        //                    //{
        //                    //    parent.Controls.Remove(drr);
        //                    //    drr.Dispose();
        //                    //}


        //                    //Cnst.RcDiffI.Clear();
        //                    //Cnst.RcDiffJ.Clear();
        //                    //Cnst.RcIntersect.Clear();
        //                    //Cnst.MyRecs.Clear();
        //                    //Cnst.PcBR.Clear();
        //                    //parent.Controls.Clear();
        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//SelectionDELETE
        //            try//Cancel
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Cancel";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) => { Dispose(); };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Cancel
        //            try//Close
        //            {
        //                Label someB = new Label();
        //                someB.Text = "Close";
        //                someB.TextAlign = ContentAlignment.MiddleCenter;
        //                someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //                someB.MouseHover += (sendere, z) =>
        //                {
        //                    someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                    someB.ForeColor = parent.ForeColor;
        //                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //                };
        //                someB.MouseLeave += (sendere, z) =>
        //                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                    someB.BackColor = parent.ForeColor;
        //                    someB.ForeColor = parent.BackColor;
        //                };
        //                someB.Click += (sender, f) =>
        //                {
        //                    //parent.Close();
        //                    Application.Exit();
        //                    Dispose();
        //                };
        //                if (LastLbl.Text == "Frst")
        //                {
        //                    someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //                }
        //                else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //                someB.Size = LastLbl.Size;
        //                LastLbl = someB;//automated grafics for menu!!
        //                Controls.Add(LastLbl);//automated grafics for menu!!
        //            }
        //            catch (Exception) { }//Close
        //                                 //TOTALY AUTO GRAFICS BUTTONS!!=Buttons ---------------above--------

        //            Left = p.X;//Positioning
        //            Top = p.Y;//Positioning
        //                      // reposition acording to screen
        //                      //Rectangle wArea = Screen.FromControl(this).WorkingArea;
        //                      //if (Left < 0) Left = 0;
        //                      //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
        //                      //if (Top < 0) Top = 0;
        //                      //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
        //                      // reposition acording to screen

        //            parent.Controls.Add(this);
        //            //MessageBox.Show(Location.ToString());
        //            Location = new Point(p.X, p.Y);
        //            Invalidate();
        //        }
        //    }
        //    if (S.Cnvs.PrsmDrw ==false&&Cnst.To2D==true)
        //    {
        //        Label LastLbl = new Label();//FIRST Lbl!
        //        LastLbl.Location = new Point(2, 0);
        //        LastLbl.Text = "Frst";
        //        LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

        //        try//Menu properties 
        //        {
        //            AutoSize = true;
        //            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //            BackColor = parent.ForeColor;
        //            ForeColor = parent.BackColor;
        //            //BackColor = Color.FromArgb(95, 95, 95);
        //            Font = parent.myFont;
        //            BringToFront();
        //        }
        //        catch (Exception) { }//Menu properties = Labels below
        //                             //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------

        //        //TOTALY AUTO GRAFICS BUTTONS!!=Buttons below------------------------
        //        try//New Rcetangle
        //        {
        //            Label someB = new Label();
        //            someB.Text = "New Rectangle";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) =>
        //            {
        //                //p = new Point(p.X, parent.Height - p.Y);
        //                PcBResizable pc = new PcBResizable(p, Cnst.Source);
        //                pc.Size = new Size(20, 20); pc.Invalidate();
        //                //parent.Header.Vlues.Text = pc.myValue.Text;
        //                //parent.Header.Vlues.BackColor = pc.BackColor;
        //                //parent.Header.MyClrInvrt(parent.Header.Vlues.BackColor);
        //                //parent.Header.Vlues.ForeColor = ForeColor;
        //                //parent.Header.Vlues.Invalidate();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//New Rcetangle
        //        try//SolveIt
        //        {
        //            Label someB = new Label();
        //            someB.Text = "Solve";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) =>
        //            {
        //                try { Cnst.justTwo.Dispose(); } catch (Exception) { }
        //                try { Cnst.justOne.Dispose(); } catch (Exception) { }

        //                Cnst.justTwo = new BtnCntxtMenu(p, parent);
        //                Cnst.justTwo.BringToFront();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//SolveIt
        //        try//Print
        //        {
        //            Label someB = new Label();
        //            someB.Text = "Print";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) =>
        //            {
        //                // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
        //                Bitmap smaBmp = new Bitmap(parent.Width, parent.Height);
        //                Dispose();//Dispose THE menu BEFORE PRINT!!
        //                parent.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

        //                string myPath = Application.StartupPath;
        //                myPath += "\\User save\\Print Screen.jpg";
        //                MessageBox.Show(myPath);
        //                try//Save print
        //                { smaBmp.Save(myPath, ImageFormat.Jpeg); }
        //                catch (Exception) { }//Save print
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//Print
        //        try//Clear
        //        {
        //            Label someB = new Label();
        //            someB.Text = "Clear";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) =>
        //            {
        //                Cnst.RcIntersect.Clear(); Cnst.MyRecs.Clear();
        //                foreach (PcBResizable pc in Cnst.PcBR)
        //                { pc.Dispose(); }
        //                Cnst.PcBR.Clear();
        //                foreach (DrRslPan dr in Cnst.DrRsl)
        //                { dr.Dispose(); }
        //                Cnst.DrRsl.Clear();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//Clear
        //        try//SelectionDELETE
        //        {
        //            Label someB = new Label();
        //            someB.Text = "Delete Selected items";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) =>
        //            {
        //                //if (!(Messlist.Contains(val)))
        //                //foreach (PcBResizable pc in Controls)
        //                //{
        //                //    if (Cnst.PcBR.Intersect(Cnst.Slctd).Any())
        //                //    {
        //                //        Cnst.PcBR.Remove(pc);
        //                //        parent.Controls.Remove(pc);
        //                //        pc.Dispose();
        //                //    }

        //                //}
        //                //foreach (DrRslPan drr in Controls)
        //                //{
        //                //    parent.Controls.Remove(drr);
        //                //    drr.Dispose();
        //                //}


        //                //Cnst.RcDiffI.Clear();
        //                //Cnst.RcDiffJ.Clear();
        //                //Cnst.RcIntersect.Clear();
        //                //Cnst.MyRecs.Clear();
        //                //Cnst.PcBR.Clear();
        //                //parent.Controls.Clear();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//SelectionDELETE
        //        try//Cancel
        //        {
        //            Label someB = new Label();
        //            someB.Text = "Cancel";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) => { Dispose(); };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//Cancel
        //        try//Close
        //        {
        //            Label someB = new Label();
        //            someB.Text = "Close";
        //            someB.TextAlign = ContentAlignment.MiddleCenter;
        //            someB.Font = new Font("Cambria", 14, FontStyle.Bold);
        //            someB.MouseHover += (sendere, z) =>
        //            {
        //                someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                someB.ForeColor = parent.ForeColor;
        //                //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            someB.MouseLeave += (sendere, z) =>
        //            { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                someB.BackColor = parent.ForeColor;
        //                someB.ForeColor = parent.BackColor;
        //            };
        //            someB.Click += (sender, f) =>
        //            {
        //                Cnst.Source.Close();
        //                //parent.Close();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                someB.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            someB.Size = LastLbl.Size;
        //            LastLbl = someB;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated grafics for menu!!
        //        }
        //        catch (Exception) { }//Close
        //                             //TOTALY AUTO GRAFICS BUTTONS!!=Buttons ---------------above--------

        //        Left = p.X;//Positioning
        //        Top = p.Y;//Positioning
        //                  // reposition acording to screen
        //                  //Rectangle wArea = Screen.FromControl(this).WorkingArea;
        //                  //if (Left < 0) Left = 0;
        //                  //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
        //                  //if (Top < 0) Top = 0;
        //                  //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
        //                  // reposition acording to screen

        //        parent.Controls.Add(this);
        //    }
        //}
        
        
        public CntxtMenu(Point p, LblMove parent)//Totaly Autopositioned Menu
        {
            Label LastLbl = new Label();//FIRST Lbl!
            LastLbl.Location = new Point(2, 0);
            LastLbl.Text = "Frst";
            LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

            try//Menu properties 
            {
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                BackColor = parent.ForeColor;
                ForeColor = parent.BackColor;
                //BackColor = Color.FromArgb(95, 95, 95);
                Font = parent.Font;
                BringToFront();
            }
            catch (Exception) { }//Menu properties = Labels below

            
            try//Lock- Labelbutton
            {
                Label lckLbl = new Label();//Auto positioned!!
                lckLbl.Text = "Lock";
                lckLbl.TextAlign = ContentAlignment.MiddleCenter;
                lckLbl.BorderStyle = BorderStyle.Fixed3D;
                lckLbl.MouseHover += (sendere, z) =>
                {
                    lckLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    lckLbl.ForeColor = parent.ForeColor;
                    //lckLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                lckLbl.MouseLeave += (sendere, z) =>
                { //lckLbl.BackColor = Color.FromArgb(95, 95, 95);
                    lckLbl.BackColor = parent.ForeColor;
                    lckLbl.ForeColor = parent.BackColor;
                };
                lckLbl.Click += (sender, f) =>
                {
                    parent.FrLocked = true;
                    if (parent.FrLocked)
                    {
                        ToolTip hint = new ToolTip();
                        hint.SetToolTip(parent, "Locked");
                        hint.BackColor = Color.Gray;
                        hint.ForeColor = Color.OrangeRed;
                    }
                    else
                    {
                        ToolTip hint = new ToolTip();
                        hint.SetToolTip(parent, "Movable");
                        hint.BackColor = Color.Gray;
                        hint.ForeColor = Color.OrangeRed;
                    }
                    parent.Size = parent.OriginSize; parent.BringToFront();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    lckLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { lckLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                lckLbl.Size = LastLbl.Size;
                LastLbl = lckLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Lock - Labelbutton
            try//Unlock- Labelbutton
            {
                Label unlckLbl = new Label();//Auto positioned!!
                unlckLbl.Text = "Unlock";
                unlckLbl.TextAlign = ContentAlignment.MiddleCenter;
                unlckLbl.BorderStyle = BorderStyle.Fixed3D;
                unlckLbl.MouseHover += (sendere, z) =>
                {
                    unlckLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    unlckLbl.ForeColor = parent.ForeColor;
                    //unlckLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                unlckLbl.MouseLeave += (sendere, z) =>
                { //unlckLbl.BackColor = Color.FromArgb(95, 95, 95);
                    unlckLbl.BackColor = parent.ForeColor;
                    unlckLbl.ForeColor = parent.BackColor;
                };
                unlckLbl.Click += (sender, f) =>
                {
                    parent.FrLocked = false;
                    if (parent.FrLocked)
                    {
                        ToolTip hint = new ToolTip();
                        hint.SetToolTip(parent, "Locked");
                        hint.BackColor = Color.Gray;
                        hint.ForeColor = Color.OrangeRed;
                    }
                    else
                    {
                        ToolTip hint = new ToolTip();
                        hint.SetToolTip(parent, "Movable");
                        hint.BackColor = Color.Gray;
                        hint.ForeColor = Color.OrangeRed;
                    }
                    parent.Size = parent.OriginSize; parent.BringToFront();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    unlckLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { unlckLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                unlckLbl.Size = LastLbl.Size;
                LastLbl = unlckLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Unlock - Labelbutton
            try//Print - Labelbutton
            {
                Label prntLbl = new Label();//Auto positioned!!
                prntLbl.Text = "Autoprint";
                prntLbl.TextAlign = ContentAlignment.MiddleCenter;
                prntLbl.BorderStyle = BorderStyle.Fixed3D;
                prntLbl.MouseHover += (sendere, z) =>
                {
                    prntLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    prntLbl.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                prntLbl.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    prntLbl.BackColor = parent.ForeColor;
                    prntLbl.ForeColor = parent.BackColor;
                };
                prntLbl.Click += (sender, f) =>
                {
                    // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
                    parent.Size = parent.OriginSize; parent.BringToFront();
                    Bitmap smaBmp = new Bitmap(parent.Width, parent.Height);
                    Dispose();//Dispose THE menu BEFORE PRINT!!

                    parent.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

                    string myPath = Application.StartupPath;
                    myPath += "\\User save\\Print Screen.jpg";
                    MessageBox.Show(myPath);
                    try { smaBmp.Save(myPath, ImageFormat.Jpeg); }
                    catch (Exception) { }
                };
                if (LastLbl.Text == "Frst")
                {
                    prntLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { prntLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                prntLbl.Size = LastLbl.Size;
                LastLbl = prntLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Print - Labelbutton
            try//Close - Labelbutton
            {
                Label clsLbl = new Label();//Auto positioned!!
                clsLbl.Text = "Cancel";
                clsLbl.TextAlign = ContentAlignment.MiddleCenter;
                clsLbl.BorderStyle = BorderStyle.Fixed3D;
                clsLbl.MouseHover += (sendere, z) =>
                {
                    clsLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    clsLbl.ForeColor = parent.ForeColor;
                    //clsLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                clsLbl.MouseLeave += (sendere, z) =>
                { //clsLbl.BackColor = Color.FromArgb(95, 95, 95);
                    clsLbl.BackColor = parent.ForeColor;
                    clsLbl.ForeColor = parent.BackColor;
                };
                clsLbl.Click += (sender, f) =>
                {
                    parent.Size = parent.OriginSize; parent.BringToFront();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    clsLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { clsLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                clsLbl.Size = LastLbl.Size;
                LastLbl = clsLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Close - Labelbutton
            //TOTALY AUTO GRAFICS buttons!!=LABELS ---------------above--------

            Left = p.X;//Menu Positioning
            Top = p.Y;//Menu Positioning
            try// reposition acording to screen
            {
                //Rectangle wArea = Screen.FromControl(this).WorkingArea;
                //if (Left < 0) Left = 0;
                //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
                //if (Top < 0) Top = 0;
                //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
            }
            catch (Exception) { }// reposition acording to screen /COMENTED


            parent.Controls.Add(this);
            Disposed += (sender, f) =>
            {
                parent.Rst();
            };
        }//Totaly Autopositioned Menu
        public CntxtMenu(Point p, PnTxt parent)//Totaly Autopositioned Menu
        {
            Label LastLbl = new Label();//FIRST Lbl!
            LastLbl.Location = new Point(2, 0);
            LastLbl.Text = "Frst";
            LastLbl.Size = new Size(W, H);//Setting:auto grafics for menu Buttons!!

            try//Menu properties 
            {
                AutoSize = true;
                AutoSizeMode = AutoSizeMode.GrowAndShrink;
                BackColor = parent.ForeColor;
                ForeColor = parent.BackColor;
                //BackColor = Color.FromArgb(95, 95, 95);
                Font = parent.Font;
                BringToFront();
            }
            catch (Exception) { }//Menu properties = Labels below

            if (Cnst.B == parent)
            {
                try//File Load - Labelbutton
                {
                    Label someB = new Label();//Auto positioned!!
                    someB.Text = "Import text";
                    someB.TextAlign = ContentAlignment.MiddleCenter;
                    someB.BorderStyle = BorderStyle.Fixed3D;
                    someB.MouseHover += (sendere, z) =>
                    {
                        someB.BackColor = Color.FromArgb(95, 55, 95);//fialova
                        someB.ForeColor = parent.ForeColor;
                        //lckLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                    };
                    someB.MouseLeave += (sendere, z) =>
                    { //lckLbl.BackColor = Color.FromArgb(95, 95, 95);
                        someB.BackColor = parent.ForeColor;
                        someB.ForeColor = parent.BackColor;
                    };
                    someB.Click += (sender, f) =>
                    {
                        parent.FrLocked = true;
                        if (parent.FrLocked)
                        {

                            try { Cnst.justTwo.Dispose(); } catch (Exception) { }
                            try { Cnst.justOne.Dispose(); } catch (Exception) { }
                            {//OpenFile
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
                                    Cnst.B.UsVl.Text = pks;
                                    Cnst.B.UsVl.Invalidate();
                                    //Cnst.A.Enabled = false;

                                }
                            }//OpenFile


                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Locked");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Movable");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }

                        parent.Size = parent.OriginSize; parent.BringToFront();

                        Dispose();
                    };
                    if (LastLbl.Text == "Frst")
                    {
                        someB.Location = new Point(LastLbl.Left, LastLbl.Top);
                    }
                    else { someB.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                    someB.Size = LastLbl.Size;
                    LastLbl = someB;
                    Controls.Add(LastLbl);//Auto positioned!!
                }
                catch (Exception) { }//File Load - Labelbutton
                try//Export my text- Labelbutton
                {
                    Label xportLbl = new Label();//Auto positioned!!
                    xportLbl.Text = "Export text";
                    xportLbl.TextAlign = ContentAlignment.MiddleCenter;
                    xportLbl.BorderStyle = BorderStyle.Fixed3D;
                    xportLbl.MouseHover += (sendere, z) =>
                    {
                        xportLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                        xportLbl.ForeColor = parent.ForeColor;
                        //lckLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                    };
                    xportLbl.MouseLeave += (sendere, z) =>
                    { //lckLbl.BackColor = Color.FromArgb(95, 95, 95);
                        xportLbl.BackColor = parent.ForeColor;
                        xportLbl.ForeColor = parent.BackColor;
                    };
                    xportLbl.Click += (sender, f) =>
                    {
                        parent.FrLocked = true;
                        if (parent.FrLocked)
                        {


                            string autoPath = Application.StartupPath;
                            autoPath += "\\User save";
                            SaveFileDialog xprt = new SaveFileDialog();
                            xprt.InitialDirectory = autoPath;
                            xprt.FileName = "Untitled1"; //default file name
                            xprt.DefaultExt = ".txt"; //default file extension
                            xprt.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                            string flname = "//Untitled1.txt";
                            if (xprt.ShowDialog() == DialogResult.OK)
                            {

                                //autoPath += "//";
                                //autoPath += xprt.FileName;
                                //MessageBox.Show(xprt.FileName );
                                try
                                {
                                    // Determine whether the directory existCnst.S.
                                    if (File.Exists(xprt.FileName))
                                    {
                                        //MessageBox.Show("That path exists already.");
                                        return;
                                    }
                                    string output = parent.UsVl.Text + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + Cnst.C.UsVl.Text + "-------------------------------------------" + Environment.NewLine + Cnst.D.UsVl.Text;
                                    File.WriteAllText(xprt.FileName, output);
                                }
                                catch (Exception z)
                                {
                                    MessageBox.Show("The process failed: {0}", z.ToString());
                                }
                                finally { }



                            }

                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Locked");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Movable");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }

                        parent.Size = parent.OriginSize; parent.BringToFront();

                        Dispose();
                    };
                    if (LastLbl.Text == "Frst")
                    {
                        xportLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                    }
                    else { xportLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                    xportLbl.Size = LastLbl.Size;
                    LastLbl = xportLbl;
                    Controls.Add(LastLbl);//Auto positioned!!
                }
                catch (Exception) { }//Export my text- Labelbutton

            }
            if (parent.Mvble==true)
            {

                try//Lock- Labelbutton
                {
                    Label lckLbl = new Label();//Auto positioned!!
                    lckLbl.Text = "Lock";
                    lckLbl.TextAlign = ContentAlignment.MiddleCenter;
                    lckLbl.BorderStyle = BorderStyle.Fixed3D;
                    lckLbl.MouseHover += (sendere, z) =>
                    {
                        lckLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                        lckLbl.ForeColor = parent.ForeColor;
                        //lckLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                    };
                    lckLbl.MouseLeave += (sendere, z) =>
                    { //lckLbl.BackColor = Color.FromArgb(95, 95, 95);
                        lckLbl.BackColor = parent.ForeColor;
                        lckLbl.ForeColor = parent.BackColor;
                    };
                    lckLbl.Click += (sender, f) =>
                    {
                        parent.FrLocked = true;
                        if (parent.FrLocked)
                        {


                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Locked");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Movable");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }

                        parent.Size = parent.OriginSize; parent.BringToFront();

                        Dispose();
                    };
                    if (LastLbl.Text == "Frst")
                    {
                        lckLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                    }
                    else { lckLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                    lckLbl.Size = LastLbl.Size;
                    LastLbl = lckLbl;
                    Controls.Add(LastLbl);//Auto positioned!!
                }
                catch (Exception) { }//Lock - Labelbutton
                try//Unlock- Labelbutton
                {
                    Label unlckLbl = new Label();//Auto positioned!!
                    unlckLbl.Text = "Unlock";
                    unlckLbl.TextAlign = ContentAlignment.MiddleCenter;
                    unlckLbl.BorderStyle = BorderStyle.Fixed3D;
                    unlckLbl.MouseHover += (sendere, z) =>
                    {
                        unlckLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                        unlckLbl.ForeColor = parent.ForeColor;
                        //unlckLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                    };
                    unlckLbl.MouseLeave += (sendere, z) =>
                    { //unlckLbl.BackColor = Color.FromArgb(95, 95, 95);
                        unlckLbl.BackColor = parent.ForeColor;
                        unlckLbl.ForeColor = parent.BackColor;
                    };
                    unlckLbl.Click += (sender, f) =>
                    {
                        parent.FrLocked = false;
                        if (parent.FrLocked)
                        {
                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Locked");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            ToolTip hint = new ToolTip();
                            hint.SetToolTip(parent, "Movable");
                            hint.BackColor = Color.Gray;
                            hint.ForeColor = Color.OrangeRed;
                        }
                        parent.Size = parent.OriginSize; parent.BringToFront();
                        Dispose();
                    };
                    if (LastLbl.Text == "Frst")
                    {
                        unlckLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                    }
                    else { unlckLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                    unlckLbl.Size = LastLbl.Size;
                    LastLbl = unlckLbl;
                    Controls.Add(LastLbl);//Auto positioned!!
                }
                catch (Exception) { }//Unlock - Labelbutton
            }
            try//Print - Labelbutton
            {
                Label prntLbl = new Label();//Auto positioned!!
                prntLbl.Text = "Autoprint";
                prntLbl.TextAlign = ContentAlignment.MiddleCenter;
                prntLbl.BorderStyle = BorderStyle.Fixed3D;
                prntLbl.MouseHover += (sendere, z) =>
                {
                    prntLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    prntLbl.ForeColor = parent.ForeColor;
                    //prntLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                prntLbl.MouseLeave += (sendere, z) =>
                { //prntLbl.BackColor = Color.FromArgb(95, 95, 95);
                    prntLbl.BackColor = parent.ForeColor;
                    prntLbl.ForeColor = parent.BackColor;
                };
                prntLbl.Click += (sender, f) =>
                {
                    // FINALLY PRINTSCR All spawned Items DONE!!!!!!!! BECOUSE I AM PRINTING A JUST PANEL NOT FORM1 (remeber this!) $$
                    parent.Size = parent.OriginSize; parent.BringToFront();
                    Bitmap smaBmp = new Bitmap(parent.Width, parent.Height);
                    Dispose();//Dispose THE menu BEFORE PRINT!!

                    parent.DrawToBitmap(smaBmp, new Rectangle(Point.Empty, smaBmp.Size));

                    string myPath = Application.StartupPath;
                    myPath += "\\User save\\Print Screen.jpg";
                    MessageBox.Show(myPath);
                    try { smaBmp.Save(myPath, ImageFormat.Jpeg); }
                    catch (Exception) { }
                };
                if (LastLbl.Text == "Frst")
                {
                    prntLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { prntLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                prntLbl.Size = LastLbl.Size;
                LastLbl = prntLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Print - Labelbutton
            try//Close - Labelbutton
            {
                Label clsLbl = new Label();//Auto positioned!!
                clsLbl.Text = "Cancel";
                clsLbl.TextAlign = ContentAlignment.MiddleCenter;
                clsLbl.BorderStyle = BorderStyle.Fixed3D;
                clsLbl.MouseHover += (sendere, z) =>
                {
                    clsLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
                    clsLbl.ForeColor = parent.ForeColor;
                    //clsLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
                };
                clsLbl.MouseLeave += (sendere, z) =>
                { //clsLbl.BackColor = Color.FromArgb(95, 95, 95);
                    clsLbl.BackColor = parent.ForeColor;
                    clsLbl.ForeColor = parent.BackColor;
                };
                clsLbl.Click += (sender, f) =>
                {
                    parent.Size = parent.OriginSize; parent.BringToFront();
                    Dispose();
                };
                if (LastLbl.Text == "Frst")
                {
                    clsLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
                }
                else { clsLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
                clsLbl.Size = LastLbl.Size;
                LastLbl = clsLbl;
                Controls.Add(LastLbl);//Auto positioned!!
            }
            catch (Exception) { }//Close - Labelbutton
            //TOTALY AUTO GRAFICS buttons!!=LABELS ---------------above--------

            Left = p.X;//Menu Positioning
            Top = p.Y;//Menu Positioning
            try// reposition acording to screen
            {
                //Rectangle wArea = Screen.FromControl(this).WorkingArea;
                //if (Left < 0) Left = 0;
                //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
                //if (Top < 0) Top = 0;
                //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
            }
            catch (Exception) { }// reposition acording to screen /COMENTED


            parent.Controls.Add(this);
        }//Totaly Autopositioned Menu
        
    }

}
