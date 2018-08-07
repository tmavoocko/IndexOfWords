using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Drawing.Graphics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NdexOfWords
{
    public class BtnCntxtMenu : MenuesContext
    {
        //Button own cntxMenu:-)

        public BtnCntxtMenu(Point p, Form1 parent)
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
            catch (Exception){}//Menu properties = Labels below

            //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------
            //try//RcCalc  Labelbutonek
            //{
            //    Label rcCalc = new Label();
            //    rcCalc.Text = "Průnik obdélníků";
            //    rcCalc.TextAlign = ContentAlignment.MiddleCenter;
            //    rcCalc.BorderStyle = BorderStyle.Fixed3D;
            //    rcCalc.MouseHover += (sendere, z) =>
            //    {
            //        rcCalc.BackColor = Color.FromArgb(95, 55, 95);//fialova                
            //        rcCalc.ForeColor = parent.ForeColor;

            //    };
            //    rcCalc.MouseLeave += (sendere, z) =>
            //    {
            //        rcCalc.BackColor = parent.ForeColor;
            //        rcCalc.ForeColor = parent.BackColor;
            //    };
            //    rcCalc.Click += (sendere, z) =>
            //    { parent.RcCalc(); Dispose(); };
            //    if (LastLbl.Text == "Frst")
            //    {
            //        rcCalc.Location = new Point(LastLbl.Left, LastLbl.Top);
            //    }
            //    else { rcCalc.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
            //    rcCalc.Size = LastLbl.Size;
            //    LastLbl = rcCalc;//automated grafics for menu!!
            //    Controls.Add(LastLbl);//automated
                
            //}
            //catch (Exception)   { }//RcCalc  Labelbutonek
            //try//RcCmbn Labelbutonek
            //{
            //    //RcCmbn
            //    Label rcCmbn = new Label();
            //    rcCmbn.Text = "Sloučení obdélníků";
            //    rcCmbn.TextAlign = ContentAlignment.MiddleCenter;
            //    rcCmbn.BorderStyle = BorderStyle.Fixed3D;
            //    rcCmbn.MouseHover += (sendere, z) =>
            //    {
            //        rcCmbn.BackColor = Color.FromArgb(95, 55, 95);//fialova
            //        rcCmbn.ForeColor = parent.ForeColor;
            //    };
            //    rcCmbn.MouseLeave += (sendere, z) =>
            //    { //rcCmbn.BackColor = Color.FromArgb(95, 95, 95);
            //        rcCmbn.BackColor = parent.ForeColor;
            //        rcCmbn.ForeColor = parent.BackColor;
            //    };
            //    rcCmbn.Click += (sendere, z) =>
            //    {
            //        parent.RcCmbn(); Dispose();

            //    };
            //    if (LastLbl.Text == "Frst")
            //    {
            //        rcCmbn.Location = new Point(LastLbl.Left, LastLbl.Top);
            //    }
            //    else { rcCmbn.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
            //    rcCmbn.Size = LastLbl.Size;
            //    LastLbl = rcCmbn;//automated grafics for menu!!
            //    Controls.Add(LastLbl);//automated
            //}
            //catch (Exception)
            //{

            //    throw;
            //}//RcCmbn Labelbutonek
            //try//RcDffr Labelbutonek
            //{
            //    Label RcDffr = new Label();
            //    RcDffr.Text = "Rozdíl obdélníků";
            //    RcDffr.TextAlign = ContentAlignment.MiddleCenter;
            //    RcDffr.BorderStyle = BorderStyle.Fixed3D;
            //    RcDffr.MouseHover += (sendere, z) =>
            //    {
            //        RcDffr.BackColor = Color.FromArgb(95, 55, 95);//fialova
            //        RcDffr.ForeColor = parent.ForeColor;
            //    };
            //    RcDffr.MouseLeave += (sendere, z) =>
            //    { //RcDffr.BackColor = Color.FromArgb(95, 95, 95);
            //        RcDffr.BackColor = parent.ForeColor;
            //        RcDffr.ForeColor = parent.BackColor;
            //    };
            //    RcDffr.Click += (sendere, z) =>
            //    {
            //        parent.RcDiffr();
            //        //parent.RcDiffr();
            //        Dispose();

            //    };
            //    if (LastLbl.Text == "Frst")
            //    {
            //        RcDffr.Location = new Point(LastLbl.Left, LastLbl.Top);
            //    }
            //    else { RcDffr.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
            //    RcDffr.Size = LastLbl.Size;
            //    LastLbl = RcDffr;//automated grafics for menu!!
            //    Controls.Add(LastLbl);//automated
            //}
            //catch (Exception)  { }//RcDffr Labelbutonek
            
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
                    //parent.Dispose();
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
        }//Auto positioned Menu!!
        //public BtnCntxtMenu(Point p, DsgnCnv parent)
        //{
        //    if (Cnst.To2D = true)
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

        //        //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------
        //        try//RcCalc  Labelbutonek
        //        {
        //            Label rcCalc = new Label();
        //            rcCalc.Text = "Průnik obdélníků";
        //            rcCalc.TextAlign = ContentAlignment.MiddleCenter;
        //            rcCalc.BorderStyle = BorderStyle.Fixed3D;
        //            rcCalc.MouseHover += (sendere, z) =>
        //            {
        //                rcCalc.BackColor = Color.FromArgb(95, 55, 95);//fialova                
        //                rcCalc.ForeColor = parent.ForeColor;

        //            };
        //            rcCalc.MouseLeave += (sendere, z) =>
        //            {
        //                rcCalc.BackColor = parent.ForeColor;
        //                rcCalc.ForeColor = parent.BackColor;
        //            };
        //            rcCalc.Click += (sendere, z) =>
        //            {
        //                parent.RcIntrsctPure();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                rcCalc.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { rcCalc.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            rcCalc.Size = LastLbl.Size;
        //            LastLbl = rcCalc;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated

        //        }
        //        catch (Exception) { }//RcCalc  Labelbutonek
        //        try//RcCmbn Labelbutonek
        //        {
        //            //RcCmbn
        //            Label rcCmbn = new Label();
        //            rcCmbn.Text = "Sloučení obdélníků";
        //            rcCmbn.TextAlign = ContentAlignment.MiddleCenter;
        //            rcCmbn.BorderStyle = BorderStyle.Fixed3D;
        //            rcCmbn.MouseHover += (sendere, z) =>
        //            {
        //                rcCmbn.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                rcCmbn.ForeColor = parent.ForeColor;
        //            };
        //            rcCmbn.MouseLeave += (sendere, z) =>
        //            { //rcCmbn.BackColor = Color.FromArgb(95, 95, 95);
        //                rcCmbn.BackColor = parent.ForeColor;
        //                rcCmbn.ForeColor = parent.BackColor;
        //            };
        //            rcCmbn.Click += (sendere, z) =>
        //            {
        //                parent.RcCmbn();
        //                Dispose();

        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                rcCmbn.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { rcCmbn.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            rcCmbn.Size = LastLbl.Size;
        //            LastLbl = rcCmbn;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }//RcCmbn Labelbutonek
        //        try//RcDffr Labelbutonek
        //        {
        //            Label RcDffr = new Label();
        //            RcDffr.Text = "Rozdíl obdélníků";
        //            RcDffr.TextAlign = ContentAlignment.MiddleCenter;
        //            RcDffr.BorderStyle = BorderStyle.Fixed3D;
        //            RcDffr.MouseHover += (sendere, z) =>
        //            {
        //                RcDffr.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                RcDffr.ForeColor = parent.ForeColor;
        //            };
        //            RcDffr.MouseLeave += (sendere, z) =>
        //            { //RcDffr.BackColor = Color.FromArgb(95, 95, 95);
        //                RcDffr.BackColor = parent.ForeColor;
        //                RcDffr.ForeColor = parent.BackColor;
        //            };
        //            RcDffr.Click += (sendere, z) =>
        //            {
        //                parent.RcDiffr();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                RcDffr.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { RcDffr.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            RcDffr.Size = LastLbl.Size;
        //            LastLbl = RcDffr;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated
        //        }
        //        catch (Exception) { }//RcDffr Labelbutonek

        //        try//Close - Labelbutton
        //        {
        //            Label clsLbl = new Label();//Auto positioned!!
        //            clsLbl.Text = "Close";
        //            clsLbl.TextAlign = ContentAlignment.MiddleCenter;
        //            clsLbl.BorderStyle = BorderStyle.Fixed3D;
        //            clsLbl.MouseHover += (sendere, z) =>
        //            {
        //                clsLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                clsLbl.ForeColor = parent.ForeColor;
        //                //clsLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            clsLbl.MouseLeave += (sendere, z) =>
        //            { //clsLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                clsLbl.BackColor = parent.ForeColor;
        //                clsLbl.ForeColor = parent.BackColor;
        //            };
        //            clsLbl.Click += (sender, f) =>
        //            {
        //                Dispose();
        //                //parent.Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                clsLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { clsLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            clsLbl.Size = LastLbl.Size;
        //            LastLbl = clsLbl;
        //            Controls.Add(LastLbl);//Auto positioned!!
        //        }
        //        catch (Exception) { }//Close - Labelbutton
        //                             //TOTALY AUTO GRAFICS BUTTONS!!=Labels ---------------above--------

        //        Left = p.X;//Menu Positioning
        //        Top = p.Y;//Menu Positioning
        //        try// reposition acording to screen
        //        {
        //            //Rectangle wArea = Screen.FromControl(this).WorkingArea;
        //            //if (Left < 0) Left = 0;
        //            //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
        //            //if (Top < 0) Top = 0;
        //            //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
        //        }
        //        catch (Exception) { }// reposition acording to screen /COMENTED

        //        parent.Controls.Add(this);
        //    }
        //    if(Cnst.To3D = true)
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

        //        //TOTALY AUTO GRAFICS BUTTONS!!=Labels ------------BELOW--------
        //        try//RcIntrsc  Labelbutonek
        //        {
        //            Label rcCalc = new Label();
        //            rcCalc.Text = "Průnik kvádrů";
        //            rcCalc.TextAlign = ContentAlignment.MiddleCenter;
        //            rcCalc.BorderStyle = BorderStyle.Fixed3D;
        //            rcCalc.MouseHover += (sendere, z) =>
        //            {
        //                rcCalc.BackColor = Color.FromArgb(95, 55, 95);//fialova                
        //                rcCalc.ForeColor = parent.ForeColor;

        //            };
        //            rcCalc.MouseLeave += (sendere, z) =>
        //            {
        //                rcCalc.BackColor = parent.ForeColor;
        //                rcCalc.ForeColor = parent.BackColor;
        //            };
        //            rcCalc.Click += (sendere, z) =>
        //            {
        //                //S.Cnvs.FncCmbn = true;
        //                S.Cnvs.IntrsctPrsms();
        //                S.Cnvs.Axe = "Rslt3D";
        //                S.Cnvs.Refresh();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                rcCalc.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { rcCalc.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            rcCalc.Size = LastLbl.Size;
        //            LastLbl = rcCalc;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated

        //        }
        //        catch (Exception) { }//PrsmIntrsc  Labelbutonek
        //        try//RcCmbn Labelbutonek
        //        {
        //            //RcCmbn
        //            Label rcCmbn = new Label();
        //            rcCmbn.Text = "Sloučení kvádrů";
        //            rcCmbn.TextAlign = ContentAlignment.MiddleCenter;
        //            rcCmbn.BorderStyle = BorderStyle.Fixed3D;
        //            rcCmbn.MouseHover += (sendere, z) =>
        //            {
        //                rcCmbn.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                rcCmbn.ForeColor = parent.ForeColor;
        //            };
        //            rcCmbn.MouseLeave += (sendere, z) =>
        //            { //rcCmbn.BackColor = Color.FromArgb(95, 95, 95);
        //                rcCmbn.BackColor = parent.ForeColor;
        //                rcCmbn.ForeColor = parent.BackColor;
        //            };
        //            rcCmbn.Click += (sendere, z) =>
        //            {
        //                S.Cnvs.CmbnPrsms();
        //                S.Cnvs.Axe = "Rslt3D";
        //                S.Cnvs.Refresh();
        //                Dispose();

        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                rcCmbn.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { rcCmbn.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            rcCmbn.Size = LastLbl.Size;
        //            LastLbl = rcCmbn;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }//PrsmCmbn Labelbutonek
        //        try//PrsmDffr Labelbutonek
        //        {
        //            MessageBox.Show("PrsmDffrClick zavolano ze SubMenu");
        //            Label PrsmDffr = new Label();
        //            PrsmDffr.Text = "Rozdíl kvádrů";
        //            PrsmDffr.TextAlign = ContentAlignment.MiddleCenter;
        //            PrsmDffr.BorderStyle = BorderStyle.Fixed3D;
        //            PrsmDffr.MouseHover += (sendere, z) =>
        //            {
        //                PrsmDffr.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                PrsmDffr.ForeColor = parent.ForeColor;
        //            };
        //            PrsmDffr.MouseLeave += (sendere, z) =>
        //            { //PrsmDffr.BackColor = Color.FromArgb(95, 95, 95);
        //                PrsmDffr.BackColor = parent.ForeColor;
        //                PrsmDffr.ForeColor = parent.BackColor;
        //            };
        //            PrsmDffr.Click += (sendere, z) =>
        //            {
        //                if (S.Cnvs.PrsmDrw == true)
        //                {

        //                    foreach (Prism pr in Cnst.MPrisms)
        //                    {
        //                        Kvadr kv = new Kvadr(pr.Input[0], pr.Input[1], pr.Input[2], pr.Input[3], pr.Input[4], pr.Input[5]);
        //                        kv.KvdrClr = pr.PrsmClr;
        //                        S.Cnvs.Kvadry.Add(kv);
        //                        //p.Dispose();
        //                    }
        //                    //MessageBox.Show(S.Cnvs.Kvadry.Count.ToString());
                            
        //                    S.Cnvs.IntersectBlocks();
        //                    Cnst.MPrisms.Clear();
        //                    //Cnst.PrismsToDraw.Clear();
        //                    foreach (Kvadr k in S.Cnvs.Kvadry)
        //                    {
        //                        foreach (Kvadr ksub in k.SubKvadry)
        //                        {
        //                            Prism pr = new Prism(ksub.Input);
        //                            pr.PrntMe(S.Cnvs);
        //                            pr.CreateMe();
        //                            pr.PrsmClr = k.KvdrClr;
        //                            Cnst.MPrisms.Add(pr);
        //                            Cnst.PrismsToDraw.Add(pr);
        //                        }
        //                    }
        //                    S.Cnvs.Axe = "Rslt3D";
        //                    S.Hdr.HldrRfrsh();
        //                    S.Cnvs.Refresh();
        //                    //S.Cnvs.Kvadry.Clear();
        //                }
        //                //parent.PrIntrsctBlocks();
        //                Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                PrsmDffr.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { PrsmDffr.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            PrsmDffr.Size = LastLbl.Size;
        //            LastLbl = PrsmDffr;//automated grafics for menu!!
        //            Controls.Add(LastLbl);//automated
        //        }
        //        catch (Exception) { }//PrsmDffr Labelbutonek

        //        try//Close - Labelbutton
        //        {
        //            Label clsLbl = new Label();//Auto positioned!!
        //            clsLbl.Text = "Close";
        //            clsLbl.TextAlign = ContentAlignment.MiddleCenter;
        //            clsLbl.BorderStyle = BorderStyle.Fixed3D;
        //            clsLbl.MouseHover += (sendere, z) =>
        //            {
        //                clsLbl.BackColor = Color.FromArgb(95, 55, 95);//fialova
        //                clsLbl.ForeColor = parent.ForeColor;
        //                //clsLbl.ForeColor = Color.FromArgb(255,255, 255);//bila
        //            };
        //            clsLbl.MouseLeave += (sendere, z) =>
        //            { //clsLbl.BackColor = Color.FromArgb(95, 95, 95);
        //                clsLbl.BackColor = parent.ForeColor;
        //                clsLbl.ForeColor = parent.BackColor;
        //            };
        //            clsLbl.Click += (sender, f) =>
        //            {
        //                Dispose();
        //                //parent.Dispose();
        //            };
        //            if (LastLbl.Text == "Frst")
        //            {
        //                clsLbl.Location = new Point(LastLbl.Left, LastLbl.Top);
        //            }
        //            else { clsLbl.Location = new Point(LastLbl.Left, LastLbl.Bottom); }
        //            clsLbl.Size = LastLbl.Size;
        //            LastLbl = clsLbl;
        //            Controls.Add(LastLbl);//Auto positioned!!
        //        }
        //        catch (Exception) { }//Close - Labelbutton
        //                             //TOTALY AUTO GRAFICS BUTTONS!!=Labels ---------------above--------

        //        Left = p.X;//Menu Positioning
        //        Top = p.Y;//Menu Positioning
        //        try// reposition acording to screen
        //        {
        //            //Rectangle wArea = Screen.FromControl(this).WorkingArea;
        //            //if (Left < 0) Left = 0;
        //            //if (Left + Width > wArea.Width) Left = wArea.Width - Width;
        //            //if (Top < 0) Top = 0;
        //            //if (Top + Height > wArea.Height) Top = wArea.Height - Height;
        //        }
        //        catch (Exception) { }// reposition acording to screen /COMENTED

        //        parent.Controls.Add(this);
        //    }
        //}
        
    }
}
