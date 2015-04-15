using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace GiffgaffHelperV1
{
    public partial class frmNameDialog : Form
    {
        public frmNameDialog()
        {
            InitializeComponent();
        }

        public string setnumber
        {
            get { return this.lblissueno.Text; }
            set { this.lblissueno.Text = value; }
        }

        private void frmNameDialog_Load(object sender, EventArgs e)
        {

        }

        private void lblissueno_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            //Set up the XML reader so it can write the new values!
            FileStream XmlReader = new FileStream("urlstore.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            // Set up the XmlDocument and assign it a variable name
            System.Xml.XmlDocument XMLDatabase = new System.Xml.XmlDocument();
            //Get the XML truck to dump the stuff off, but this time it'll be leaving with new values!
            XMLDatabase.Load(XmlReader);
            // Create a list of the nodes in the xml file //
            System.Xml.XmlNodeList NodeList = XMLDatabase.GetElementsByTagName("urldatabase");
            if (lblissueno.Text == "1")
            {
                //Time to start loading up the truck!
                NodeList[0].FirstChild.ChildNodes[24].InnerText = txtURL.Text; 
            }
            else if (lblissueno.Text == "2")
            {
                //Time to start loading up the truck!
                NodeList[0].FirstChild.ChildNodes[25].InnerText = txtURL.Text;
            }
            else if (lblissueno.Text == "3")
            {
                //Time to start loading up the truck!
                NodeList[0].FirstChild.ChildNodes[26].InnerText = txtURL.Text;
            }

             //The truck is loaded, now we gotta send it back to the XML Depo
             //THANKS FOR MAKING ME, A WRITERRRRR! 
             FileStream XmlWriter = new FileStream("urlstore.xml", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
             //Now we're streaming the data, let's write it in the stream
             XMLDatabase.Save(XmlWriter);
            //Done, now let's go to sleep, I'm knackered and Dave wants to party tomorrow...
             this.Close();
        }

    }
}
