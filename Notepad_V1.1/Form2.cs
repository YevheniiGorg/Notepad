using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_V1._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            ReadFile();
        }

        private void ReadFile()
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.FileName = "About the program.txt";

            richTextBox1.LoadFile(OpenFile.FileName,RichTextBoxStreamType.PlainText);        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
