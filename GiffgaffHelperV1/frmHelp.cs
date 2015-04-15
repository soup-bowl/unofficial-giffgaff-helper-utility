using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiffgaffHelperV1
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void lblusage_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "This tool was initially designed as a simple tool that provided useful links and shortcuts that the user could copy and subsequently paste, providing an easy solution to hunting down links. As the tool evolved it eventually had an Internet Explorer functionality in that it could open up the links within the tool, therefore making it more available to consumers. Nowadays it will simply open them in the favourite browser, however the in-built browser will return (with a vengence).\r\n\r\nFor normal everyday users this provides the ease of navigation by providing an easy control panel interface with clickable buttons that take you to where you need to go. For advanced users this will provide the option of 'Helper mode', which lets you copy links from the internal database and paste them for others, allowing you to focus more on writing good quality help rather than scouring the knowledge base for links and solutions elsewhere.\r\n\r\nPlease note that this does not provide an excuse for users to simply use this tool alone as a method of problem solving for others. This will be considered spamming if just the link is pasted without any decent help. Please take the approved helpers quizzes to learn more.";
        }

        private void lbloffical_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "This is not an official giffgaff tool, which is explained on both the home page and the control panel screen (small print). This program was voluntarily made and while giffgaff are open to the usage of their logo and other resources for related projects the UNOFFICIAL Giffgaff Helper is... Well, unofficial.";
        }

        private void lblhowtononhelp_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "The usage is very simple, all you do is point your cursor (the little arrow) over the button you wish to use, and click it. It should automatically after a couple of seconds open up your desired web page in the browser set as default. If you web browser does not pop up, click on the tools menu and ensure that helper mode is turned off.\r\n\r\nThe in-built web browser will return shortly.";
        }

        private void lblhowuseexpr_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "Instead of using it the standard way, helpers can toggle the 'Helper Mode' which can be found in either the tools menu or on the first menu in tray mode. In this mode any button that is clicked will send the usual output to your clipboard instead so you can paste it into any assistance you are providing. This usually goes hand-in-hand with tray mode as it enables you to provide quick and speedy support with it sitting in your tray.";
        }

        private void lblupdatenchange_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "Unfortunately it is currently not possible to be able to edit the links (excluding the service board manual settings). This is a planned feature and as soon as I learn how to use such a feature it will be incorperated. Also there is no automatic updater, however since it is a simple single executable it is advisable to check every six months for an update, or when certain links begin to malfunction. These along with saving customised link databases are all planned features.";
        }

        private void lblSupportdev_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "Your downloading, trialing and usage of the program is enough support for me. However I do appreciate some nice words or constructive critisim over my work on the home page. Also if you wish to donate money to the development there is a link on the control panel, however money does not affect the development in any way since it is developed with entirely free tools and hosted on free services.";
        }

        private void lblsourcecode_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "Absolutely! Contact me and I will be more than willing to give out the source code. This program is released under no licence (aka 'Public Domain') so you are free to use, break, reverse engineer and whtever you generally want as long as you do not do it under my name. Despite my usage of non-free tools such as Microsoft Visual Studio, please support the Free Software Foundation in the fight to make the internet a better, freer place!";
        }

        private void lblcontact_Click(object sender, EventArgs e)
        {
            txtHelpDialog.Text = "You are more than welcome to contact me. If you wish to reach me please drop me an IM ('spiritshadowx') or comment on the home page of the UGGH and I will get back to you as soon as possible. Alternatively, you can always contact my junk email cl-overflow@outlook.com (not saying your mail is junk, I do not wish to distribute my work email and I still check my junk email regularly) and I will reply as soon as I can.";
        }
    }
}
