using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Xml;

namespace TesterApp
{
	public class Form1 : System.Windows.Forms.Form
	{
		TcpClient socket = new TcpClient();
		NetworkStream ns = null;
		string crlf = "\r\n";

		private System.Windows.Forms.TextBox CommandBox;
		private System.Windows.Forms.ListBox CommandList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button PreMadeCommandBtn;
		private System.Windows.Forms.TextBox ResponseBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox Server;
		private System.Windows.Forms.TextBox Port;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Connect;
		private System.Windows.Forms.Button ClearResponses;
		private System.ComponentModel.Container components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CommandBox = new System.Windows.Forms.TextBox();
			this.CommandList = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PreMadeCommandBtn = new System.Windows.Forms.Button();
			this.ResponseBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ClearResponses = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.Connect = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Port = new System.Windows.Forms.TextBox();
			this.Server = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// CommandBox
			// 
			this.CommandBox.Location = new System.Drawing.Point(8, 16);
			this.CommandBox.Multiline = true;
			this.CommandBox.Name = "CommandBox";
			this.CommandBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.CommandBox.Size = new System.Drawing.Size(440, 264);
			this.CommandBox.TabIndex = 0;
			this.CommandBox.Text = "";
			this.CommandBox.WordWrap = false;
			// 
			// CommandList
			// 
			this.CommandList.Location = new System.Drawing.Point(8, 16);
			this.CommandList.Name = "CommandList";
			this.CommandList.Size = new System.Drawing.Size(352, 69);
			this.CommandList.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PreMadeCommandBtn);
			this.groupBox1.Controls.Add(this.CommandList);
			this.groupBox1.Location = new System.Drawing.Point(472, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 120);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sample Commands";
			// 
			// PreMadeCommandBtn
			// 
			this.PreMadeCommandBtn.Location = new System.Drawing.Point(8, 88);
			this.PreMadeCommandBtn.Name = "PreMadeCommandBtn";
			this.PreMadeCommandBtn.Size = new System.Drawing.Size(352, 23);
			this.PreMadeCommandBtn.TabIndex = 2;
			this.PreMadeCommandBtn.Text = "<-- Send to command window";
			this.PreMadeCommandBtn.Click += new System.EventHandler(this.PreMadeCommandBtn_Click);
			// 
			// ResponseBox
			// 
			this.ResponseBox.Location = new System.Drawing.Point(8, 16);
			this.ResponseBox.Multiline = true;
			this.ResponseBox.Name = "ResponseBox";
			this.ResponseBox.ReadOnly = true;
			this.ResponseBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.ResponseBox.Size = new System.Drawing.Size(352, 192);
			this.ResponseBox.TabIndex = 3;
			this.ResponseBox.Text = "";
			this.ResponseBox.WordWrap = false;
			this.ResponseBox.TextChanged += new System.EventHandler(this.ResponseBox_TextChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.CommandBox);
			this.groupBox2.Location = new System.Drawing.Point(8, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 320);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Send Commands";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(336, 288);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Send Command";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ClearResponses);
			this.groupBox3.Controls.Add(this.ResponseBox);
			this.groupBox3.Location = new System.Drawing.Point(472, 136);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(368, 248);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Response List";
			// 
			// ClearResponses
			// 
			this.ClearResponses.Location = new System.Drawing.Point(248, 216);
			this.ClearResponses.Name = "ClearResponses";
			this.ClearResponses.Size = new System.Drawing.Size(112, 23);
			this.ClearResponses.TabIndex = 5;
			this.ClearResponses.Text = "Clear Responses";
			this.ClearResponses.Click += new System.EventHandler(this.ClearResponses_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.Connect);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.Port);
			this.groupBox4.Controls.Add(this.Server);
			this.groupBox4.Location = new System.Drawing.Point(8, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(456, 48);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Connect";
			// 
			// Connect
			// 
			this.Connect.Location = new System.Drawing.Point(344, 16);
			this.Connect.Name = "Connect";
			this.Connect.Size = new System.Drawing.Size(104, 23);
			this.Connect.TabIndex = 4;
			this.Connect.Text = "Connect";
			this.Connect.Click += new System.EventHandler(this.Connect_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(168, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Server:";
			// 
			// Port
			// 
			this.Port.Location = new System.Drawing.Point(200, 16);
			this.Port.Name = "Port";
			this.Port.Size = new System.Drawing.Size(40, 20);
			this.Port.TabIndex = 1;
			this.Port.Text = "56906";
			// 
			// Server
			// 
			this.Server.Location = new System.Drawing.Point(56, 16);
			this.Server.Name = "Server";
			this.Server.TabIndex = 0;
			this.Server.Text = "demo.trms.com";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 389);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			CommandList.Items.Add("CreatePage1");
			CommandList.Items.Add("CreatePage2");
			CommandList.Items.Add("CreatePage3");
			CommandList.Items.Add("UpdatePage");
			CommandList.Items.Add("CreateAlertPage");
			CommandList.Items.Add("CreateCrawl");
			CommandList.Items.Add("CreateCrawlInvalidUser");
			CommandList.Items.Add("CreateCrawl1Zone");
			CommandList.Items.Add("CreateCrawlInvalidZone");
			CommandList.Items.Add("ChangePageStatus");
			CommandList.Items.Add("DeletePage");
			CommandList.Items.Add("DeleteAllUserPages");
			CommandList.Items.Add("DeactivateAllAlertPages");
			CommandList.Items.Add("IllFormedCmd1");
			CommandList.Items.Add("IllFormedCmd2");
			CommandList.Items.Add("IllFormedCmd3");
			CommandList.Items.Add("IllFormedCmd4");
		}

		private void Connect_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Connect.Text == "Connect")
				{
					socket = new TcpClient();
					socket.Connect(Server.Text, Int32.Parse(Port.Text));
					ns = socket.GetStream();
					ResponseBox.Text += "Connected." + crlf + crlf;
					Connect.Text = "Disconnect";
					return;
				}

			
				if (Connect.Text == "Disconnect")
				{
					ns.Close();
					socket.Close();
					Connect.Text = "Connect";
					ResponseBox.Text += "Disconnected." + crlf + crlf;
					return;
				}

			}
			catch (Exception exc)
			{
				ResponseBox.Text += exc.Message + crlf + crlf;
			}
			

		}

		private void ResponseBox_TextChanged(object sender, System.EventArgs e)
		{
			//scroll to bottom
			ResponseBox.SelectionStart = ResponseBox.Text.Length;
			ResponseBox.ScrollToCaret();
		}

		private void PreMadeCommandBtn_Click(object sender, System.EventArgs e)
		{
			switch (CommandList.SelectedItem.ToString())
			{
				case "CreatePage1":
					CommandBox.Text = SampleCommand.CreatePage1();
					break;
				case "CreatePage2":
					CommandBox.Text = SampleCommand.CreatePage2();
					break;
				case "CreatePage3":
					CommandBox.Text = SampleCommand.CreatePage3();
					break;
				case "UpdatePage":
					CommandBox.Text = SampleCommand.UpdatePage();
					break;
				case "CreateAlertPage":
					CommandBox.Text = SampleCommand.CreateAlertPage();
					break;
				case "CreateCrawl":
					CommandBox.Text = SampleCommand.CreateCrawl();
					break;
				case "CreateCrawlInvalidUser":
					CommandBox.Text = SampleCommand.CreateCrawlInvalidUser();
					break;
				case "CreateCrawl1Zone":
					CommandBox.Text = SampleCommand.CreateCrawl1Zone();
					break;
				case "CreateCrawlInvalidZone":
					CommandBox.Text = SampleCommand.CreateCrawlInvalidZone();
					break;
				case "ChangePageStatus":
					CommandBox.Text = SampleCommand.ChangePageStatus();
					break;
				case "DeletePage":
					CommandBox.Text = SampleCommand.DeletePage();
					break;
				case "DeleteAllUserPages":
					CommandBox.Text = SampleCommand.DeleteAllUserPages();
					break;
				case "DeactivateAllAlertPages":
					CommandBox.Text = SampleCommand.DeactivateAllAlertPages();
					break;
				case "IllFormedCmd1":
					CommandBox.Text = SampleCommand.IllFormedCmd1();
					break;
				case "IllFormedCmd2":
					CommandBox.Text = SampleCommand.IllFormedCmd2();
					break;
				case "IllFormedCmd3":
					CommandBox.Text = SampleCommand.IllFormedCmd3();
					break;
				case "IllFormedCmd4":
					CommandBox.Text = SampleCommand.IllFormedCmd4();
					break;
			}

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (ns != null && ns.CanWrite && ns.CanRead)
			{
				try
				{
					byte[] cmd;
					byte[] response;

					button1.Enabled = false;
					ResponseBox.Text += "Sending Command..." + crlf;
					cmd = Encoding.ASCII.GetBytes(CommandBox.Text.ToCharArray());
					ns.Write(cmd, 0, cmd.Length);


					response = new byte[socket.ReceiveBufferSize];
					ns.Read(response, 0, socket.ReceiveBufferSize);
					string XML = Encoding.ASCII.GetString(response).Trim().Replace("\0",""); //get rid of whitespace

					//parse the return xml
					StringReader sr = new StringReader(XML);
					XmlDocument xdoc = new XmlDocument();
					xdoc.Load(sr);

					XmlNodeList result = xdoc.GetElementsByTagName("Result");
					XmlNodeList description = xdoc.GetElementsByTagName("Description");
					XmlNodeList guids = xdoc.GetElementsByTagName("GUID");


					ResponseBox.Text += "Result: " + result[0].InnerText + crlf;
					ResponseBox.Text += "Description: " + description[0].InnerText + crlf;

					for (int i = 0; i<guids.Count; i++)
						ResponseBox.Text += "GUID: " + guids[i].InnerText + crlf;


					ResponseBox.Text += crlf;

				}
				catch(Exception exc)
				{
					ResponseBox.Text += exc.Message + crlf + crlf;
				}

			}
			else
			{
				ResponseBox.Text += "Not Connected. " + crlf + crlf;
			}

			
			button1.Enabled = true;
		}

		private void ClearResponses_Click(object sender, System.EventArgs e)
		{
			ResponseBox.Text = "";
		}
	}
	
	/// <summary>
	/// A storage class for commands
	/// </summary>
	public class SampleCommand
	{

		public SampleCommand(string CommandName)
		{
		}
		public static string CreatePage1()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<Zone>1</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-29T00:00:00</DateTimeOn>
		<DateTimeOff>2005-12-29T23:59:59</DateTimeOff>
		<CycleTimeOn>08:00:00</CycleTimeOn>
		<CycleTimeOff>17:00:00</CycleTimeOff>
		<DisplayDuration>5</DisplayDuration>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
		<Description>This is a sample page that we created via the remote command system.</Description>
		<PageType>Standard</PageType>
		<PageTemplate>
			<TemplateName>a title and body</TemplateName>
			<Block Name=""Title"" Value=""Hello"" />
			<Block Name=""bOdY"" Value=""World!"" />
			<Block Name=""test"" Value=""World!"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		public static string CreatePage2()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<Zone>1</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-29T00:00:00</DateTimeOn>
		<DateTimeOff>2005-12-29T23:59:59</DateTimeOff>
		<CycleTimeOn>08:00:00</CycleTimeOn>
		<CycleTimeOff>17:00:00</CycleTimeOff>
		<DisplayDuration>5</DisplayDuration>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
		<Description>This is a sample page that we created via the remote command system.</Description>
		<PageType>Standard</PageType>
		<PageTemplate>
			<TemplateName>Picture Right</TemplateName>
			<Block Name=""Title"" Value=""Sample"" />
			<Block Name=""Description"" Value=""Carousel Page"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		public static string CreatePage3()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<Zone>1</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-29T00:00:00</DateTimeOn>
		<DateTimeOff>2005-12-29T23:59:59</DateTimeOff>
		<CycleTimeOn>08:00:00</CycleTimeOn>
		<CycleTimeOff>17:00:00</CycleTimeOff>
		<DisplayDuration>5</DisplayDuration>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
		<Description>This is a sample page that we created via the remote command system.</Description>
		<PageType>Standard</PageType>
		<PageTemplate>
			<TemplateName>blue lines</TemplateName>
			<Block Name=""Text"" Value=""TRMS!"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		public static string UpdatePage()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<UpdateGUID>3dc0f1cd-eb4c-4bad-8733-15a5a13eea08</UpdateGUID>
		<Zone>1</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-09-29T00:00:00</DateTimeOn>
		<DateTimeOff>2005-12-05T23:59:59</DateTimeOff>
		<CycleTimeOn>09:00:00</CycleTimeOn>
		<CycleTimeOff>18:00:00</CycleTimeOff>
		<Weekdays>32</Weekdays>
		<WebEnabled>true</WebEnabled>
		<PageType>Standard</PageType>
		<PageTemplate>
			<TemplateName>two column</TemplateName>
			<Block Name=""left text area"" Value=""Left!"" />
			<Block Name=""right text area"" Value=""Right!"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		
		public static string CreateAlertPage()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<Zone>1</Zone>
		<AlwaysOn>true</AlwaysOn>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
		<PageType>alert</PageType>
		<PageTemplate>
			<TemplateName>Simple Message</TemplateName>
			<Block Name=""Simple Message"" Value=""ALERT PAGE"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		
		public static string CreateCrawl()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreateCrawl>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<CrawlText>This is the text I'd like to see at the bottom of the screen.</CrawlText>
		<Zone>all</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-26T00:00:00</DateTimeOn>
		<DateTimeOff>2005-12-29T23:59:59</DateTimeOff>
		<CycleTimeOn>08:00:00</CycleTimeOn>
		<CycleTimeOff>17:00:00</CycleTimeOff>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
	</CreateCrawl>
</CarouselCommand>";
		}
		public static string CreateCrawlInvalidUser()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreateCrawl>
		<UserName>fakeName</UserName>
		<Password>fakePassword</Password>
		<CrawlText>This is the text I'd like to see at the bottom of the screen.</CrawlText>
		<Zone>all</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-26T00:00:00-06:00</DateTimeOn>
		<DateTimeOff>2005-10-29T23:59:59-06:00</DateTimeOff>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
	</CreateCrawl>
</CarouselCommand>";
		}
		public static string CreateCrawl1Zone()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreateCrawl>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<CrawlText>Always on, MWF</CrawlText>
		<Zone>1</Zone>
		<AlwaysOn>true</AlwaysOn>
		<Weekdays>42</Weekdays>
		<WebEnabled>true</WebEnabled>
	</CreateCrawl>
</CarouselCommand>";
		}
		public static string CreateCrawlInvalidZone()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreateCrawl>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<CrawlText>This is the text I'd like to see at the bottom of the screen.</CrawlText>
		<Zone>9999</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-26T00:00:00-06:00</DateTimeOn>
		<DateTimeOff>2005-10-29T23:59:59-06:00</DateTimeOff>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
	</CreateCrawl>
</CarouselCommand>";
		}
		public static string ChangePageStatus()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<!-- This command will set the status of the specified page to on. -->
	<ChangePageStatus>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<GUID>77c0592c-e13e-46de-b2dc-5617e119452a</GUID>
		<Status>on</Status>
	</ChangePageStatus>
</CarouselCommand>";
		}
		
		public static string DeletePage()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<!-- This command will delete the specified page, assuming that the user John has permission to do so. -->
	<DeletePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<GUID>4f83e8f2-2b17-41de-8e7b-5e799280d388</GUID>
	</DeletePage>
</CarouselCommand>";
		}
		
		public static string DeleteAllUserPages()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<!-- Sending this command will permanently delete ALL pages created by John -->
	<DeleteAllUserPages>
		<UserName>xml</UserName>
		<Password>trms</Password>
	</DeleteAllUserPages>
</CarouselCommand>";
		}
		
		public static string DeactivateAllAlertPages()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<!-- Sending this command will turn off all alert pages. -->
	<DeactivateAllAlertPages>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<Zone>all</Zone>
	</DeactivateAllAlertPages>
</CarouselCommand>";
		}
		
		public static string IllFormedCmd1()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<!-- no username/password -->
		<Zone>1</Zone>
		<AlwaysOn>false</AlwaysOn>
		<DateTimeOn>2005-10-29T00:00:00-06:00</DateTimeOn>
		<DateTimeOff>2005-10-29T23:59:59-06:00</DateTimeOff>
		<CycleTimeOn>08:00:00-06:00</CycleTimeOn>
		<CycleTimeOff>17:00:00-06:00</CycleTimeOff>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
		<PageType>Standard</PageType>
		<PageTemplate>
			<TemplateName>Title Body</TemplateName>
			<Block Name=""Title"" Value=""Hello"" />
			<Block Name=""Body"" Value=""World!"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		public static string IllFormedCmd2()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<CreatePage>
		<UserName>xml</UserName>
		<Password>trms</Password>
		<Zone>1</Zone>
		<AlwaysOn>hello</AlwaysOn> <!-- error here -->
		<DateTimeOn>2005-10-29T00:00:00-06:00</DateTimeOn>
		<DateTimeOff>2005-10-29T23:59:59-06:00</DateTimeOff>
		<CycleTimeOn>08:00:00-06:00</CycleTimeOn>
		<CycleTimeOff>17:00:00-06:00</CycleTimeOff>
		<Weekdays>127</Weekdays>
		<WebEnabled>true</WebEnabled>
		<PageType>Standard</PageType>
		<PageTemplate>
			<TemplateName>Title Body</TemplateName>
			<Block Name=""Title"" Value=""Hello"" />
			<Block Name=""Body"" Value=""World!"" />
		</PageTemplate>
	</CreatePage>
</CarouselCommand>";
		}
		
		public static string IllFormedCmd3()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
</CarouselCommand>";
		}
		public static string IllFormedCmd4()
		{
			return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<CarouselCommand xmlns=""http://www.trms.com/CarouselRemoteCommand"">
	<SomeStrangeCommand>
		<Entity attribute1=""1"" />
	</SomeStrangeCommand>
</CarouselCommand>";
		}
		
	}
}
