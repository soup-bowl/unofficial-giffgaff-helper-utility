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
    public partial class FrmMain : Form
    {
        string url;
        string xmlversion;
        int countxmlentriessloaded;
        string buttonname; //for the 'WritetoOutput' void

        public FrmMain()
        {
            InitializeComponent();
            ReadXML();
            
        }

        //Background Modifiers

        private void ReadXML()
        {
            bool FileExists;
            WritetoXML("Initialising XML Reader...");
            string curFile = @"urlstore.xml";
            Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            FileExists = File.Exists(curFile) ? true : false;
            if (FileExists == false)
            {
                WritetoXML("The XML file is missing. Please replace the file or visit the homepage to download an XML file.");
                MessageBox.Show("The XML file is missing. Please click the 'Unofficial giffgaff Helper' button on the" + Environment.NewLine + "dashboard to see the official page and see the section 'Missing XML Error?'. Alternatively, reinstall giffgaff helper.", "Missing XML");
            }
            else
            {
                //Set up the XML reader, and point it to the file it needs to open (found here http://bit.ly/12aFnmP for future reference)
                FileStream XmlReader = new FileStream("urlstore.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                // Set up the XmlDocument and assign it a variable name
                System.Xml.XmlDocument XMLDatabase = new System.Xml.XmlDocument();
                //Get the XML truck to dump the stuff off
                XMLDatabase.Load(XmlReader);
                // Create a list of the nodes in the xml file //
                System.Xml.XmlNodeList NodeList = XMLDatabase.GetElementsByTagName("urldatabase"); 
                //Time to use this new data! First up, load the version numbers!
                xmlversion = NodeList[0].FirstChild.ChildNodes[0].InnerText; 
                //Now it's in, let's let the user know what version database they are now using.
                WritetoXML("You are running XML database version " + xmlversion);
                WritetoOutput("Using database version " + xmlversion); 
                //And it works! That's right me, a year of googling and you finally googled correctly!
                string temporarystore;
                //My Giffgaff
                temporarystore = NodeList[0].FirstChild.ChildNodes[3].InnerText;
                WritetoXML("Fetching My giffgaff URL");
                txtMygaff.Text = temporarystore;
                //Setting up Newbies
                temporarystore = NodeList[0].FirstChild.ChildNodes[4].InnerText;
                WritetoXML("Fetching setting up URL");
                txtSettingup.Text = temporarystore;
                //Purchase Goodybag
                temporarystore = NodeList[0].FirstChild.ChildNodes[5].InnerText;
                WritetoXML("Fetching purchase a goodybag URL");
                txtPurchasebag.Text = temporarystore;
                //Redeem Voucher
                temporarystore = NodeList[0].FirstChild.ChildNodes[6].InnerText;
                WritetoXML("Fetching redeem voucher URL");
                txtReddemvouch.Text = temporarystore;
                //Top other
                temporarystore = NodeList[0].FirstChild.ChildNodes[7].InnerText;
                WritetoXML("Fetching top up another number URL");
                txtTopother.Text = temporarystore;
                //Unlockapedia
                temporarystore = NodeList[0].FirstChild.ChildNodes[8].InnerText;
                WritetoXML("Fetching unlockapedia URL");
                txtUnlockapedia.Text = temporarystore;
                //Signal
                temporarystore = NodeList[0].FirstChild.ChildNodes[9].InnerText;
                WritetoXML("Fetching signal checker URL");
                txtSignal.Text = temporarystore;
                //Number Porting
                temporarystore = NodeList[0].FirstChild.ChildNodes[10].InnerText;
                WritetoXML("Fetching number porting URL");
                txtNumberport.Text = temporarystore;
                //Agenter
                temporarystore = NodeList[0].FirstChild.ChildNodes[11].InnerText;
                WritetoXML("Fetching ask an agent URL");
                txtAskAgent.Text = temporarystore;
                //Educatorer
                temporarystore = NodeList[0].FirstChild.ChildNodes[12].InnerText;
                WritetoXML("Fetching ask an educator URL");
                txtAskEd.Text = temporarystore;
                //Lost Password
                temporarystore = NodeList[0].FirstChild.ChildNodes[13].InnerText;
                WritetoXML("Fetching lost password URL");
                txtLostPasswd.Text = temporarystore;
                //APPLE DEVICES
                //iPhone 3G
                temporarystore = NodeList[0].FirstChild.ChildNodes[14].InnerText;
                WritetoXML("Fetching Apple device guide URLs");
                txtIP3G.Text = temporarystore;
                //iPhone 4G
                temporarystore = NodeList[0].FirstChild.ChildNodes[15].InnerText;
                txtIP4G.Text = temporarystore;
                //iPad
                temporarystore = NodeList[0].FirstChild.ChildNodes[16].InnerText;
                txtIPad.Text = temporarystore;
                //ANDROID DEVICES
                //Standard Android
                temporarystore = NodeList[0].FirstChild.ChildNodes[17].InnerText;
                WritetoXML("Fetching Android device guide URLs");
                txtAndroid.Text = temporarystore;
                //Standard Android 4.0+
                temporarystore = NodeList[0].FirstChild.ChildNodes[18].InnerText;
                txtAndrICS.Text = temporarystore;
                //WINDOWS DEVICES
                //Windows Phone 6
                temporarystore = NodeList[0].FirstChild.ChildNodes[19].InnerText;
                WritetoXML("Fetching Windows device guide URLs");
                txtWP6.Text = temporarystore;
                //Windows Phone 7
                temporarystore = NodeList[0].FirstChild.ChildNodes[20].InnerText;
                txtWP7.Text = temporarystore;
                //Windows Phone 8
                temporarystore = NodeList[0].FirstChild.ChildNodes[21].InnerText;
                txtWP8.Text = temporarystore;
                //BLACKBERRY DEVICES
                //General BlackBerry
                temporarystore = NodeList[0].FirstChild.ChildNodes[22].InnerText;
                WritetoXML("Fetching BlackBerry device guide URLs");
                txtBlackBerry.Text = temporarystore;
                //APN DEVICES
                temporarystore = NodeList[0].FirstChild.ChildNodes[23].InnerText;
                WritetoXML("Fetching APN URL");
                txtAPN.Text = temporarystore;
                //Custom Issues
                temporarystore = NodeList[0].FirstChild.ChildNodes[24].InnerText;
                WritetoXML("Fetching custom issue URLs");
                txtIssue1.Text = temporarystore;
                temporarystore = NodeList[0].FirstChild.ChildNodes[25].InnerText;
                txtIssue2.Text = temporarystore;
                temporarystore = NodeList[0].FirstChild.ChildNodes[26].InnerText;
                txtIssue3.Text = temporarystore;
                //Service Update Board
                temporarystore = NodeList[0].FirstChild.ChildNodes[27].InnerText;
                WritetoXML("Fetching service board URL");
                txtServiceupd.Text = temporarystore;
                //Check Credit Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[28].InnerText;
                WritetoXML("Fetching shortcodes");
                txtNoChkCrd.Text = temporarystore;
                //Check Goody Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[29].InnerText;
                txtNoChkGoody.Text = temporarystore;
                //Top up Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[30].InnerText;
                txtNoTopup.Text = temporarystore;
                //Voicemail Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[31].InnerText;
                txtNoVoicemail.Text = temporarystore;
                //Voicemail on Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[32].InnerText;
                txtNoVoiceOn.Text = temporarystore;
                //Voicemail off Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[33].InnerText;
                txtNoVoiceOff.Text = temporarystore;
                //Settings Number
                temporarystore = NodeList[0].FirstChild.ChildNodes[34].InnerText;
                txtNoSettings.Text = temporarystore;
                //Disable Adult Filter
                temporarystore = NodeList[0].FirstChild.ChildNodes[35].InnerText;
                WritetoXML("Fetching adult filter URL");
                txtDisableAdult.Text = temporarystore;
                //Lost device
                temporarystore = NodeList[0].FirstChild.ChildNodes[36].InnerText;
                WritetoXML("Fetching lost SIM/phone URL");
                txtLostSIM.Text = temporarystore;
                //PAC Code
                temporarystore = NodeList[0].FirstChild.ChildNodes[37].InnerText;
                WritetoXML("Fetching PAC retrieval URL");
                txtPACstore.Text = temporarystore;
                //PUK Code
                temporarystore = NodeList[0].FirstChild.ChildNodes[38].InnerText;
                WritetoXML("Fetching PUK retrieval URL");
                txtPUKstore.Text = temporarystore;
                //Tarrif
                temporarystore = NodeList[0].FirstChild.ChildNodes[39].InnerText;
                WritetoXML("Fetching tarrif URL");
                txtTarrif.Text = temporarystore;
                //SIM Swap
                temporarystore = NodeList[0].FirstChild.ChildNodes[40].InnerText;
                WritetoXML("Fetching SIM swap URL");
                txtSIMswap.Text = temporarystore;
                //Myth buster
                temporarystore = NodeList[0].FirstChild.ChildNodes[40].InnerText;
                WritetoXML("Fetching myth buster URL");
                txtMythbust.Text = temporarystore;
                //Count total loaded
                if (txtMygaff.Text.Equals("")) { } else { btnDashboard1.Enabled = true; countxmlentriessloaded++; }
                if (txtSettingup.Text.Equals("")) { } else { btnNewbies1.Enabled = true; countxmlentriessloaded++; }
                if (txtPurchasebag.Text.Equals("")) { } else { btnGrabbag1.Enabled = true; countxmlentriessloaded++; }
                if (txtReddemvouch.Text.Equals("")) { } else { btnVoucher1.Enabled = true; countxmlentriessloaded++; }
                if (txtTopother.Text.Equals("")) { } else { btnSharedaloov1.Enabled = true; countxmlentriessloaded++; }
                if (txtUnlockapedia.Text.Equals("")) { } else { BtnUnlock1.Enabled = true; countxmlentriessloaded++; }
                if (txtSignal.Text.Equals("")) { } else { btnsignal1.Enabled = true; countxmlentriessloaded++; }
                if (txtNumberport.Text.Equals("")) { } else { BtnNumberport1.Enabled = true; countxmlentriessloaded++; }
                if (txtAskAgent.Text.Equals("")) { } else { btnagent1.Enabled = true; countxmlentriessloaded++; }
                if (txtAskEd.Text.Equals("")) { } else { btneducator1.Enabled = true; countxmlentriessloaded++; }
                if (txtLostPasswd.Text.Equals("")) { } else { btnpswd1.Enabled = true; countxmlentriessloaded++; }

                if (txtIP3G.Text.Equals("")) { } else { BtniPhone3.Enabled = true; countxmlentriessloaded++; }
                if (txtIP4G.Text.Equals("")) { } else { Btniphone4.Enabled = true; countxmlentriessloaded++; }
                if (txtIPad.Text.Equals("")) { } else { Btnipad.Enabled = true; countxmlentriessloaded++; }

                if (txtAndroid.Text.Equals("")) { } else { BtnAndroid.Enabled = true; countxmlentriessloaded++; }
                if (txtAndrICS.Text.Equals("")) { } else { BtnICS.Enabled = true; countxmlentriessloaded++; }

                if (txtWP6.Text.Equals("")) { } else { BtnWindowphone6.Enabled = true; countxmlentriessloaded++; }
                if (txtWP7.Text.Equals("")) { } else { BtnWindows7.Enabled = true; countxmlentriessloaded++; }
                if (txtWP8.Text.Equals("")) { } else { BtnWindows8.Enabled = true; countxmlentriessloaded++; }

                if (txtBlackBerry.Text.Equals("")) { } else { BtnBlackBerry.Enabled = true; countxmlentriessloaded++; }

                if (txtAPN.Text.Equals("")) { } else { BtnAPN.Enabled = true; countxmlentriessloaded++; }

                if (txtIssue1.Text.Equals("")) { } else { BtnIssue1.Enabled = true; BtnSet1.Enabled = true; countxmlentriessloaded++; }
                if (txtIssue2.Text.Equals("")) { } else { BtnIssue2.Enabled = true; BtnSet2.Enabled = true; countxmlentriessloaded++; }
                if (txtIssue3.Text.Equals("")) { } else { BtnIssue3.Enabled = true; BtnSet3.Enabled = true; countxmlentriessloaded++; }
                if (txtServiceupd.Text.Equals("")) { } else { BtnServiceUpd.Enabled = true; countxmlentriessloaded++; }

                if (txtNoChkCrd.Text.Equals("")) { } else { Btnnocheckbal.Enabled = true; countxmlentriessloaded++; }
                if (txtNoChkGoody.Text.Equals("")) { } else { BtnnoCheckGood.Enabled = true; countxmlentriessloaded++; }
                if (txtNoTopup.Text.Equals("")) { } else { Btnnotopup.Enabled = true; countxmlentriessloaded++; }
                if (txtNoVoicemail.Text.Equals("")) { } else { BtnnoVoicemail.Enabled = true; countxmlentriessloaded++; }
                if (txtNoVoiceOn.Text.Equals("")) { } else { Btnnovoiceon.Enabled = true; countxmlentriessloaded++; }
                if (txtNoVoiceOff.Text.Equals("")) { } else { Btnnovoiceoff.Enabled = true; countxmlentriessloaded++; }
                if (txtNoSettings.Text.Equals("")) { } else { Btnnosettings.Enabled = true; countxmlentriessloaded++; }

                if (txtDisableAdult.Text.Equals("")) { } else { BtnFilter.Enabled = true; countxmlentriessloaded++; }
                if (txtLostSIM.Text.Equals("")) { } else { btnLostsim.Enabled = true; countxmlentriessloaded++; }
                if (txtPACstore.Text.Equals("")) { } else { BtnPAC.Enabled = true; countxmlentriessloaded++; }
                if (txtPUKstore.Text.Equals("")) { } else { btnPUK.Enabled = true; countxmlentriessloaded++; }
                if (txtTarrif.Text.Equals("")) { } else { BtnTarrif.Enabled = true; countxmlentriessloaded++; }
                if (txtSIMswap.Text.Equals("")) { } else { btnSWAP.Enabled = true; countxmlentriessloaded++; }
                if (txtMythbust.Text.Equals("")) { } else { btnMyths.Enabled = true; countxmlentriessloaded++; }

                WritetoXML(countxmlentriessloaded + " scripts have loaded.");
                countxmlentriessloaded = 0;
            }
            
            


        }

        private void WritetoXML(object outputxml)
        {
            txtXMLOutput.Text += Environment.NewLine + outputxml;
        }
        
        private void WritetoOutput(object outputwrite)
        {
            txtOutput.Text += Environment.NewLine + outputwrite;
        }
        
        private void SetClipboard(object text)
        {
            System.Windows.Forms.Clipboard.SetDataObject(text);
        }

        private void clippermode()
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(url);
            }
            else
            {
                System.Diagnostics.Process.Start(url);
            }
        }

        private void TrayMode2()
        {
            if (chkTrayMode.Checked == true)
            {
                chkTrayMode.Checked = false;
                mnuTrayMode.Checked = false;
                TrayMode.Visible = false;
                this.Show();
            }
            else
            {
                chkTrayMode.Checked = true;
                mnuTrayMode.Checked = true;
                TrayMode.Visible = true;
                this.Hide();
            }
        }

        private void HelperMode()
        {
            if (ChkBrowserOpen.Checked == true)
            {
                mnuHelperMode.Checked = false;
                ChkBrowserOpen.Checked = false;
                cxtlblHelpermde.Checked = false;
            }
            else
            {
                mnuHelperMode.Checked = true;
                ChkBrowserOpen.Checked = true;
                cxtlblHelpermde.Checked = true;
            }
        }

        //Button Events

        private void dashboard()
        {
            url = txtMygaff.Text;
            clippermode();
        }

        private void newbies()
        {
            url = txtSettingup.Text;
            clippermode();
        }

        private void grabgoody()
        {
            url = txtPurchasebag.Text;
            clippermode();
        }

        private void voucher()
        {
            url = txtReddemvouch.Text;
            clippermode();
        }

        private void casttopotherspell()
        {
            url = txtTopother.Text;
            clippermode(); 
        }

        private void unlockapedia()
        {
            url = txtUnlockapedia.Text;
            clippermode();
        }

        private void signalstatus()
        {
            url = txtSignal.Text;
            clippermode();
        }

        private void numberporting()
        {
            url = txtNumberport.Text;
            clippermode();
        }

        private void askagent()
        {
            url = txtAskAgent.Text;
            clippermode();
        }

        private void askeducator()
        {
            url = txtAskEd.Text;
            clippermode();
        }

        private void lostpassword()
        {
            url = txtLostPasswd.Text;
            clippermode();
        }

        private void guideiPhone3G()
        {
            url = txtIP3G.Text;
            clippermode();
        }

        private void guideiPhone4G()
        {
            url = txtIP4G.Text;
            clippermode();
        }

        private void guideiPad()
        {
            url = txtIPad.Text;
            clippermode();
        }

        private void guideandroid()
        {
            url = txtAndroid.Text;
            clippermode();
        }

        private void guideandroidICS()
        {
            url = txtAndrICS.Text;
            clippermode();
        }

        private void guideWP6()
        {
            url = txtWP6.Text;
            clippermode();
        }

        private void guideWP7()
        {
            url = txtWP7.Text;
            clippermode();
        }

        private void guideWP8()
        {
            url = txtWP8.Text;
            clippermode();
        }

        private void guideblackberry()
        {
            url = txtBlackBerry.Text;
            clippermode();
        }

        private void guideAPN()
        {
            url = txtAPN.Text;
            clippermode();
        }

        private void issue1()
        {
            url = txtIssue1.Text;
            clippermode();
        }

        private void issue2()
        {
            url = txtIssue2.Text;
            clippermode();
        }
        
        private void issue3()
        {
            url = txtIssue3.Text;
            clippermode();
        }

        private void serviceboard()
        {
            url = txtServiceupd.Text;
            clippermode();
        }

        private void adult()
        {
            url = txtDisableAdult.Text;
            clippermode();
        }

        private void lostSIM()
        {
            url = txtLostSIM.Text;
            clippermode();
        }

        private void PAC()
        {
            url = txtPACstore.Text;
            clippermode();
        }

        private void PUK()
        {
            url = txtPUKstore.Text;
            clippermode();
        }

        private void tarrif()
        {
            url = txtTarrif.Text;
            clippermode();
        }

        private void donation()
        {
            url = "http://bit.ly/ggh-donatetomypocket";
            clippermode();
        }

        private void simswap()
        {
            url = txtSIMswap.Text;
            clippermode();
        }

        private void mythbust()
        {
            url = txtMythbust.Text;
            clippermode();
        }

        private void spread()
        {
            url = "http://bit.ly/ggh-creator";
            clippermode();
        }

        private void homepage()
        {
            url = "http://bit.ly/ggh-ggh";
            clippermode();
        }

        //Menu Callers

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void mnuDebug_Click(object sender, EventArgs e)
        {
            if (mnuDebug.Checked == true)
            {
                mnuDebug.Checked = false;
                pnlDebug.Visible = false;
                btnExpand.Visible = false;
            }
            else
            {
                mnuDebug.Checked = true;
                pnlDebug.Visible = true;
                btnExpand.Visible = true;
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout theAboutForm = new frmAbout();
            theAboutForm.ShowDialog();
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            frmHelp theHelpForm = new frmHelp();
            theHelpForm.ShowDialog();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ReadXML();
        }

        private void mnuEditXML_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("urlstore.xml");
        }
        
        private void mnuTrayMode_Click(object sender, EventArgs e)
        {
            TrayMode2();            
        }

        private void mnuHelperMode_Click(object sender, EventArgs e)
        {
            HelperMode();
        }

        //Dashboard Callers

        private void btnDashboard1_Click(object sender, EventArgs e)
        {
            dashboard();
        }

        private void btnNewbies1_Click(object sender, EventArgs e)
        {
            newbies();
        }

        private void btnGrabbag1_Click(object sender, EventArgs e)
        {
            grabgoody();
        }

        private void btnVoucher1_Click(object sender, EventArgs e)
        {
            voucher();
        }

        private void btnSharedaloov1_Click(object sender, EventArgs e)
        {
            casttopotherspell();
        }

        private void BtnUnlock1_Click(object sender, EventArgs e)
        {
            unlockapedia();
        }

        private void btnsignal1_Click(object sender, EventArgs e)
        {
            signalstatus();
        }

        private void BtnNumberport1_Click(object sender, EventArgs e)
        {
            numberporting();
        }

        private void btnagent1_Click(object sender, EventArgs e)
        {
            askagent();
        }

        private void btneducator1_Click(object sender, EventArgs e)
        {
            askeducator();
        }

        private void btnpswd1_Click(object sender, EventArgs e)
        {
            lostpassword();
        }

        private void BtniPhone3_Click(object sender, EventArgs e)
        {
            guideiPhone3G();
        }

        private void Btniphone4_Click(object sender, EventArgs e)
        {
            guideiPhone4G();
        }

        private void Btnipad_Click(object sender, EventArgs e)
        {
            guideiPad();
        }

        private void BtnAndroid_Click(object sender, EventArgs e)
        {
            guideandroid();
        }

        private void BtnICS_Click(object sender, EventArgs e)
        {
            guideandroidICS();
        }

        private void BtnWindowphone6_Click(object sender, EventArgs e)
        {
            guideWP6();
        }

        private void BtnWindows7_Click(object sender, EventArgs e)
        {
            guideWP7();
        }

        private void BtnWindows8_Click(object sender, EventArgs e)
        {
            guideWP8();
        }

        private void BtnBlackBerry_Click(object sender, EventArgs e)
        {
            guideblackberry();
        }

        private void BtnAPN_Click(object sender, EventArgs e)
        {
            guideAPN();
        }

        private void BtnServiceUpd_Click(object sender, EventArgs e)
        {
            serviceboard();
        }

        private void BtnIssue1_Click(object sender, EventArgs e)
        {
            issue1();
        }

        private void BtnIssue2_Click(object sender, EventArgs e)
        {
            issue2();
        }

        private void BtnIssue3_Click(object sender, EventArgs e)
        {
            issue3();
        }

        public void BtnSet1_Click(object sender, EventArgs e)
        {
            frmNameDialog theNameForm = new frmNameDialog();
            theNameForm.setnumber = "1";
            theNameForm.ShowDialog();
        }

        private void BtnSet2_Click(object sender, EventArgs e)
        {
            frmNameDialog theNameForm = new frmNameDialog();
            theNameForm.setnumber = "2";
            theNameForm.ShowDialog();
        }

        private void BtnSet3_Click(object sender, EventArgs e)
        {
            frmNameDialog theNameForm = new frmNameDialog();
            theNameForm.setnumber = "3";
            theNameForm.ShowDialog();
        } 

        private void Btnnocheckbal_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoChkCrd);
            }
            else
            {
                MessageBox.Show("The number is - *100#" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. A message will say wait for network action, shortly after a pop-up will appear with your balance and your free Giffgaff calls/text status.");
            }
        }

        private void BtnnoCheckGood_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoChkGoody);
            }
            else
            {
                MessageBox.Show("The number is - *100*7#, This is used for checking remaining Goodbag minutes." + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. A message will say wait for network action, shortly after a pop-up will appear with your remaining Goodybag calls");
            }
        }

        private void Btnnotopup_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoTopup);
            }
            else
            {
                MessageBox.Show("The number is - 43430" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. This will allow you to top up via voucher in the traditional mobile way. Alternatively, visit your My Giffgaff section on the website to top up through the internet interface.");
            }
        }

        private void BtnnoVoicemail_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoVoicemail);
            }
            else
            {
                MessageBox.Show("The number is - 443" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. You will be given a landline-style voice mail check. All calls to the voice mail cost the standard charge, or will count as part of your goodybag minutes.");
            }
        }

        private void Btnnovoiceon_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoVoiceOn);
            }
            else
            {
                MessageBox.Show("The number is - 1616" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. You will enable your voice mail doing this. Please note, this will only work if you have previously disabled your voice mail. If you are here because you can't call voice mail, please check the service updates board (downtime issues > Service Updates).");
            }
        }

        private void Btnnovoiceoff_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoVoiceOff);
            }
            else
            {
                MessageBox.Show("The number is - 1626" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. Callers will be greeted with a message that you cannot be reached instead of voice mail.");
            }
        }

        private void Btnnosettings_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoSettings);
            }
            else
            {
                MessageBox.Show("The number is - 2020" + Environment.NewLine + Environment.NewLine + "DO NOT CALL - Enter the number into the text contact entry, and send them a message with the word 'Settings'. You will receive a message enabling you to install a settings profile. This will automatically set up internet and multimedia Messaging. To install, simply open the message and either click the link or for older phones press 'install' when it appears on screen. Some phones will automatically install these upon opening.");
            }
        }
        
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            adult();
        }

        private void BtnLostsim_Click(object sender, EventArgs e)
        {
            lostSIM();
        }

        private void BtnPAC_Click(object sender, EventArgs e)
        {
            PAC();
        }

        private void btnPUK_Click(object sender, EventArgs e)
        {
            PUK();
        }

        private void BtnTarrif_Click(object sender, EventArgs e)
        {
            tarrif();
        }

        private void btnSWAP_Click(object sender, EventArgs e)
        {
            simswap();
        }

        private void btnMyths_Click(object sender, EventArgs e)
        {
            mythbust();
        }

        private void BtnDonate_Click(object sender, EventArgs e)
        {
            donation();
        }

        private void BtnSIMOrdering_Click(object sender, EventArgs e)
        {
            spread();
        }

        private void btnworduphome_Click(object sender, EventArgs e)
        {
            homepage();
        }

        //Tray Callers

        private void CxtLblQuitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CxtLblReturn_Click(object sender, EventArgs e)
        {
            TrayMode2();
        }

        private void cxtlblHelpermde_Click(object sender, EventArgs e)
        {
            HelperMode();
        }

        private void cxtlblnewbguide_Click(object sender, EventArgs e)
        {
            newbies();
        }

        private void cxtlblDashboard_Click(object sender, EventArgs e)
        {
            dashboard();
        }

        private void cxtlbltopup_Click(object sender, EventArgs e)
        {
            grabgoody();
        }

        private void cxtlblvouchrebeem_Click(object sender, EventArgs e)
        {
            voucher();
        }

        private void cxtlbllovesharing_Click(object sender, EventArgs e)
        {
            casttopotherspell();
        }

        private void cxtlblunlocky_Click(object sender, EventArgs e)
        {
            unlockapedia();
        }

        private void CxtLbl02signal_Click(object sender, EventArgs e)
        {
            signalstatus();
        }

        private void CxtLblNumberPort_Click(object sender, EventArgs e)
        {
            numberporting();
        }

        private void CxtLblAgent_Click(object sender, EventArgs e)
        {
            askagent();
        }

        private void CxtLblEducator_Click(object sender, EventArgs e)
        {
            askeducator();
        }

        private void CxtLblPswd_Click(object sender, EventArgs e)
        {
            lostpassword();
        }

        private void CxtLblAPN_Click(object sender, EventArgs e)
        {
            guideAPN();
        }

        private void CxtLblBB_Click(object sender, EventArgs e)
        {
            guideblackberry();
        }

        private void CxtLblWin6_Click(object sender, EventArgs e)
        {
            guideWP6();
        }

        private void CxtLblWin7_Click(object sender, EventArgs e)
        {
            guideWP7();
        }

        private void CxtLblWin8_Click(object sender, EventArgs e)
        {
            guideWP8();
        }

        private void CxtLblAndroid_Click(object sender, EventArgs e)
        {
            guideandroid();
        }

        private void CxtLblA40_Click(object sender, EventArgs e)
        {
            guideandroidICS();
        }

        private void CxtLblIP3_Click(object sender, EventArgs e)
        {
            guideiPhone3G();
        }

        private void CxtLblIP4_Click(object sender, EventArgs e)
        {
            guideiPhone4G();
        }

        private void CxtLblipad_Click(object sender, EventArgs e)
        {
            guideiPad();
        }

        private void CxtLblLI1_Click(object sender, EventArgs e)
        {
            issue1();
        }

        private void CxtLblLI2_Click(object sender, EventArgs e)
        {
            issue2();
        }

        private void CxtLblLI3_Click(object sender, EventArgs e)
        {
            issue3();
        }

        private void CxtLblService_Click(object sender, EventArgs e)
        {
            serviceboard();
        }

        private void CheckCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoChkCrd);
            }
            else
            {
                MessageBox.Show("The number is - *100#" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. A message will say wait for network action, shortly after a pop-up will appear with your balance and your free Giffgaff calls/text status.");
            }
        }

        private void CheckGoodybagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoChkGoody);
            }
            else
            {
                MessageBox.Show("The number is - *100*7#, This is used for checking remaining Goodbag minutes." + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. A message will say wait for network action, shortly after a pop-up will appear with your remaining Goodybag calls");
            }
        }

        private void TopUpViaPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoTopup);
            }
            else
            {
                MessageBox.Show("The number is - 43430" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. This will allow you to top up via voucher in the traditional mobile way. Alternatively, visit your My Giffgaff section on the website to top up through the internet interface.");
            }
        }

        private void CheckVoiceMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoVoicemail);
            }
            else
            {
                MessageBox.Show("The number is - 443" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. You will be given a landline-style voice mail check. All calls to the voice mail cost the standard charge, or will count as part of your goodybag minutes.");
            }
        }

        private void TurnVoiceMailOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoVoiceOn);
            }
            else
            {
                MessageBox.Show("The number is - 1616" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. You will enable your voice mail doing this. Please note, this will only work if you have previously disabled your voice mail. If you are here because you can't call voice mail, please check the service updates board (downtime issues > Service Updates).");
            }
        }

        private void TurnVoiceMailOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoVoiceOff);
            }
            else
            {
                MessageBox.Show("The number is - 1626" + Environment.NewLine + Environment.NewLine + "Dial this in your phone and call. Callers will be greeted with a message that you cannot be reached instead of voice mail.");
            }
        }

        private void SettingsMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkBrowserOpen.Checked == true)
            {
                SetClipboard(txtNoSettings);
            }
            else
            {
                MessageBox.Show("The number is - 2020" + Environment.NewLine + Environment.NewLine + "DO NOT CALL - Enter the number into the text contact entry, and send them a message with the word 'Settings'. You will receive a message enabling you to install a settings profile. This will automatically set up internet and multimedia Messaging. To install, simply open the message and either click the link or for older phones press 'install' when it appears on screen. Some phones will automatically install these upon opening.");
            }
        }

        private void CxtLblAdult_Click(object sender, EventArgs e)
        {
            adult();
        }

        private void CxtLblLostSIM_Click(object sender, EventArgs e)
        {
            lostSIM();
        }

        private void CxtLblPAC_Click(object sender, EventArgs e)
        {
            PAC();
        }

        private void CxtLblPUK_Click(object sender, EventArgs e)
        {
            PUK();
        }

        private void CxtLblTarrif_Click(object sender, EventArgs e)
        {
            tarrif();
        }

        private void CxtLblSwapp_Click(object sender, EventArgs e)
        {
            simswap();
        }

        private void cxtlblMyth_Click(object sender, EventArgs e)
        {
            mythbust();
        }

        private void CxtLblDonate_Click(object sender, EventArgs e)
        {
            donation();
        }

        private void CxtLblJoin_Click(object sender, EventArgs e)
        {
            spread();
        }

        private void CXTLBLspreadyspread_Click(object sender, EventArgs e)
        {
            homepage();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (pnlDebug.Height == 400)
            {
                pnlDebug.Height = 100;
                btnExpand.Text = "+";
            }
            else
            {
                pnlDebug.Height = 400;
                btnExpand.Text = "-";
            }
        }
               

    }
}
