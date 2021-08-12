using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace XMLReader2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNodeList dataNodes = xmlDoc.SelectNodes("//Data/Component/Characteristic");
                foreach (XmlNode node in dataNodes)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        richTextBox1.AppendText(Environment.NewLine + childNode.Name +"="+ childNode.InnerText);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Text Files (*.txt)|*.txt" + "|" +
                                "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                "All Files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string file = saveDialog.FileName;
                richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
