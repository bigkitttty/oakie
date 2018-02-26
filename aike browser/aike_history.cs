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
    public partial class aike_history : Form
    {
        String historyXml = "history.xml";
        public aike_history()
        {
            InitializeComponent();
        }

        public static implicit operator Button(aike_history v)
        {
            throw new NotImplementedException();
         }

        private void aike_history_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            //open the xml file
            XmlDocument myXml = new XmlDocument();

            if (File.Exists(historyXml))
            {
                myXml.Load(historyXml);
                DateTime now = DateTime.Now;

                //....

                treeView1.ShowRootLines = true;
                foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
                {
                    Uri site = new Uri(el.GetAttribute("url"));

                    if (!treeView1.Nodes.ContainsKey(site.Host.ToString()))
                        treeView1.Nodes.Add(site.Host.ToString(),
                                                      site.Host.ToString(), 0, 0);
                    //create a new tree node
                    TreeNode node = new TreeNode(el.GetAttribute("url"), 3, 3);
                    //set some properties of the new tree node you created    
                    node.ToolTipText = el.GetAttribute("url") +
                                     "\nLast Visited: " +
                                     el.GetAttribute("lastVisited") +
                                     "\nTimes Visited: " +
                                     el.GetAttribute("times");
                    node.Name = el.GetAttribute("url");
                    //add a context menu to this node
                    //node.ContextMenuStrip = histContextMenu;
                    //add this node to the treeview control    
                    treeView1.Nodes[site.Host.ToString()].Nodes.Add(node);
                }
                //...
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
