using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace aike_browser
{
    public partial class Form1 : Form
    {
        String historyXml = "history.xml";
        String favXml = "bookmarks.xml";
            
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // GO to the wed sit
            foreach (Control ctrl1 in tabControl1.SelectedTab.Controls)
            {
                if (ctrl1 is WebBrowser)
                {
                    ((WebBrowser)ctrl1).Url = new Uri(textBox1.Text);
                }
            }
            //webBrowser1.Url = new Uri(textBox1.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //go back
            foreach (Control ctrl1 in tabControl1.SelectedTab.Controls)
            {
                if (ctrl1 is WebBrowser)
                {
                    ((WebBrowser)ctrl1).GoBack();
                }
            }
            //webBrowser1.GoBack();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // make the wedbrowser bigr
            tabControl1.Width = this.Width - 10;
            tabControl1.Height = this.Height - 100;

            webBrowser1.Width = this.Width-50;
            webBrowser1.Height = this.Height-150;

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //change text
            foreach (Control ctrl1 in tabControl1.SelectedTab.Controls)
            {
                if (ctrl1 is WebBrowser)
                {
                    tabControl1.SelectedTab.Text = ((WebBrowser)ctrl1).DocumentTitle;
                    textBox1.Text = Convert.ToString(((WebBrowser)ctrl1).Url);
                }
            }
            
        }

        private void exatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void aboutAikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // make the about box
            MessageBox.Show("aike browser version 5.0","ABOUT aikie");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //ADD THE SETTINDS
            aike_ettings frm2 = new aike_ettings();
            frm2.ShowDialog();
         }

        private void button3_Click(object sender, EventArgs e)
        {
            //make the reload buttim
            //tabControl1.SelectedTab.

            foreach (Control ctrl1 in tabControl1.SelectedTab.Controls)
            {
                if (ctrl1 is WebBrowser)
                {
                    ((WebBrowser)ctrl1).Refresh();
                }
            }


            //webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // make tabs
            TabPage tb = new TabPage();
            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.Navigate("www.google.com");

            tabControl1.TabPages.Add(tb);
            tb.Controls.Add(wb);
            tb.Text = "google";
            tabControl1.SelectedTab = tb;

            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            button6.Enabled = true;

            //AddHandler WB.DocumentCompleted, AddressOf MyDocCompletedSub;
        }

        private void history_Click(object sender, EventArgs e)
        {
            aike_history frm2 = new aike_history();
           frm2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl1 in tabControl1.SelectedTab.Controls)
            {
                if (ctrl1 is WebBrowser)
                {
                    ((WebBrowser)ctrl1).GoHome();

                    tabControl1.SelectedTab.Text = ((WebBrowser)ctrl1).DocumentTitle;
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabCount > 1)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);

                if (tabControl1.TabCount == 1)
                    button6.Enabled = false;
            }
            
        }

        private void bookmrks_Click(object sender, EventArgs e)
        {
            aike_bookmrks frm2 = new aike_bookmrks();
            frm2.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            XmlDocument myXml = new XmlDocument();
            XmlElement el = myXml.CreateElement("favorit");
            string url1 = "test";
            string name1 = "test";

            foreach (Control ctrl1 in tabControl1.SelectedTab.Controls)
            {
                if (ctrl1 is WebBrowser)
                {
                    url1 = ((WebBrowser)ctrl1).Url.ToString();
                    name1 = ((WebBrowser)ctrl1).DocumentTitle.ToString();
                }
            }

            el.SetAttribute("url", url1);
            el.InnerText = name1;
            if (!File.Exists(favXml))
            {
                XmlElement root = myXml.CreateElement("favorites");
                myXml.AppendChild(root);
                root.AppendChild(el);
            }
            else
            {
                myXml.Load(favXml);
                myXml.DocumentElement.AppendChild(el);
            }
            
         myXml.Save(favXml);
        }
    }
}
// make the Links open in a now tad

// maake the history
// make it go home on all of the tads
//add bookmarks