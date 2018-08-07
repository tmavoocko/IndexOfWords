using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NdexOfWords
{
    public static partial class S
    {
        public static char[] Separators = { ' ', '.', ',', '!', '?', '\n', '\r', '\t' };
    }
    class MainForm : Form
    {
        //[STAThread]
        //static void Main(string[] args)
        //{
        //    Application.Run(new MainForm());
        //}

        public Panel PANEL = new Panel() { BackColor = Color.LightSeaGreen, Dock = DockStyle.Fill };
        public MenuStrip MENU = new MenuStrip() { Dock = DockStyle.Top };
        public StatusStrip STATUS = new StatusStrip() { Dock = DockStyle.Bottom };

        private TextBoxPanel textBoxPanel = new TextBoxPanel() { Dock = DockStyle.Fill };
        private OutputPanel outputPanel = new OutputPanel() { Dock = DockStyle.Right, Width = 300 };

        private MultiButton FileMenu = new MultiButton("File") { IsMainMenu = true };//create menu
        private MultiButton OptionsMenu = new MultiButton("Options") { IsMainMenu = true };//create menu 

        private MultiButton NewFile = new MultiButton("New");//create menu item
        private MultiButton RunOption = new MultiButton("Run");

        public MainForm()
        {
            Screen aScreen = Screen.FromPoint(MousePosition);
            StartPosition = FormStartPosition.Manual;
            Size = aScreen.WorkingArea.Size;
            Location = aScreen.WorkingArea.Location;

            Controls.Add(PANEL);// dock fill first
            Controls.Add(MENU); // dock top wil squeeze in
            Controls.Add(STATUS);// as well as dock bottom == no resize events

            MENU.Items.Add(FileMenu.MenuButton);//add menu button
            MENU.Items.Add(OptionsMenu.MenuButton);//add menu button

            NewFile.ClickOnly += ClickOnlyEvent;//do stuff when item is clicked
            FileMenu.AddMultiButton(NewFile);//add sub buton to menu

            RunOption.ClickOnly += ClickOnlyEvent;
            OptionsMenu.AddMultiButton(RunOption);

            ToolStripProgressBar progress = new ToolStripProgressBar
            {
                Style = ProgressBarStyle.Continuous,
                Minimum = 0,
                Maximum = 100,
                Step = 1,
                Value = 0
            };
            STATUS.Items.Add(progress);

            PANEL.Controls.Add(textBoxPanel);
            PANEL.Controls.Add(outputPanel);
            textBoxPanel.TextChanged += (sender, e) =>
            {
                textBoxPanel.ParseText();
                outputPanel.Text = "";
                foreach (KeyValuePair<string, List<Tuple<int, int>>> kvp in textBoxPanel.validWords)
                {
                    if (outputPanel.Text != "") outputPanel.Text += "\r\n";
                    outputPanel.Text += kvp.Key + " @(";
                    string output = "";
                    foreach (Tuple<int, int> t in kvp.Value)
                    {
                        if (output != "") output += ", ";
                        output += t.Item1.ToString() + "/" + t.Item2.ToString();
                    }
                    outputPanel.Text += output + ")";
                }
            };


        }

        private void SizePlusClick(MultiButton sender, ClickOnlyEvArgs e)
        {

        }






        private void ClickOnlyEvent(MultiButton sender, ClickOnlyEvArgs e)
        {

        }
        private void BoolValChanged(MultiButton sender, BoolChangeEvArgs e)
        {

        }
        private void IntValChanged(MultiButton sender, IntChangeEvArgs e)
        {

        }
        private void StrValChanged(MultiButton sender, StrChangeEvArgs e)
        {

        }
    }
}