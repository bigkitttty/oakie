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
    public partial class aike_bookmrks : Form
    {
        String favXml = "bookmarks.xml";
           
        public aike_bookmrks()
        {
            InitializeComponent();
        }

        private void aike_bookmrks_Load(object sender, EventArgs e)
        {
            XmlDocument myXml = new XmlDocument();
            //treeView1.ImageList = TreeView.ImageList;

            //treeView1.Nodes[0].ImageIndex = 0;
            
            XmlDocument myXml2 = new XmlDocument();
            
               if (File.Exists(favXml))
                {
                    myXml.Load(favXml);
                
                    foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
                    {
                        Uri url = new Uri(el.GetAttribute("url"));
                        TreeNode node = new TreeNode(el.InnerText);
                        node.ToolTipText = el.GetAttribute("url");
                        node.Name = el.GetAttribute("url");
                        //node.ContextMenuStrip = organizeContextMenu;
                        treeView1.Nodes.Add(node);
                    }
                
               }
        }
    }
}
