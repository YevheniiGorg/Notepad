using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace Notepad_V1._1
{
    public partial class Form1 : Form
    {
       
        Form3 F3;
        int count = 0;
      

        public Form1()
        {
            //перекл. культуру приложения на русский язык
           
           
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Lenguage))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Lenguage);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Lenguage);
            }
          
            

            InitializeComponent();

            NewRTextBox();
            
        }

        private void NewRTextBox()
        {
            count++;
            TabPage New = new TabPage("New" + count);

            RichTextBox Rt = new RichTextBox();
            Rt.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(New);
            New.Controls.Add(Rt);
            tabControl1.SelectedTab = New;
           
        }

       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRTextBox();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.Title = "File to open";
            OpenFile.FileName = "";
            OpenFile.Filter = "Rich Text Filter (*.rtf) | *.rtf";
            RichTextBox rtb = null;
            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;

                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    rtb.LoadFile(OpenFile.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();

        }

        private void SaveFile()
        {
            SaveFileDialog SaveFile = new SaveFileDialog();

            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                int index = tabControl1.SelectedIndex + 1;
                SaveFile.FileName = "new docyment" + index + ".rtf";
                rtb.SaveFile(SaveFile.FileName, RichTextBoxStreamType.RichText);
            }
            MessageBox.Show("The file is saved!");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();

        }

        private void SaveAs()
        {
            SaveFileDialog SaveFile = new SaveFileDialog();

            SaveFile.Title = "File to save";
            SaveFile.FileName = "";
            SaveFile.Filter = "Rich Text Filter (*.rtf) | *.rtf";

            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;

                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    rtb.SaveFile(SaveFile.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void Undo()
        {
            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                if (rtb.CanUndo == true)
                {
                    rtb.Undo();
                }

            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();

        }

        private void Redo()
        {
            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                if (rtb.CanRedo == true)
                {
                    rtb.Redo();
                }

            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void Cut()
        {
            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                rtb.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void Copy()
        {
            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                rtb.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Paste()
        {
            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                rtb.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                rtb.SelectAll();
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            RichTextBox rtb = null;

            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                colorDialog1.Color = rtb.BackColor;
                if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   colorDialog1.Color != rtb.BackColor)
                {
                    rtb.BackColor = colorDialog1.Color;
                }

            }
           
        }

        //FontColor
        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            RichTextBox rtb = null;
            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                colorDialog1.Color = rtb.SelectionColor;
                if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                  colorDialog1.Color != rtb.SelectionColor)
                {
                       rtb.SelectionColor = colorDialog1.Color;
                }
            }
          
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help();
        }

        private static void Help()
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog FontDial = new FontDialog();
            RichTextBox rtb = null;
            if (tabControl1.TabCount != 0)
            {
                rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                if (FontDial.ShowDialog() == DialogResult.OK)
                {
                    rtb.Font = FontDial.Font;
                }
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewRTextBox();
        }

       
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help();
        }

        private void SaveAsToolStripButton1_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void UndoToolStripButton1_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripButton2_Click(object sender, EventArgs e)
        {
            Redo();
        }      

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[]
                       {
                System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                 System.Globalization.CultureInfo.GetCultureInfo("ru-RU")
                       };

            comboBox1.DisplayMember = "NetIveName";
            comboBox1.ValueMember = "Name";

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Lenguage))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Lenguage;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Lenguage = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {           
            if (MessageBox.Show(WinFormStrings.EditRequest,WinFormStrings.EditTitle,MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Close();
            }
                       
        }

        private void ColorToolStripButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    menuStrip1.Items[i].ForeColor = colorDialog1.Color;
                }

            }
        }
    }
}
