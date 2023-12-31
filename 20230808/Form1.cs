//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;


namespace _20230821
{
    public partial class Form1 : Form
    {
        TextBox textbox1, textbox2, textbox3;
        public Form1()
        {
            InitializeComponent();
            StageSetting1();
        }
        void StageSetting1()
        {
            Label label1, label2;
            Button /* button1,*/ button2;
            SplitContainer Splitcontainer1;
            string s1 = "10 �i";
            string s2 = "2 �i";
            int x1 = 15, x2 = 250;
            int y1 = 20, y2 = 60;
            this.Width = 1200;

            Splitcontainer1 = new SplitContainer
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Orientation = Orientation.Vertical,
                SplitterWidth = 4,
                BorderStyle = BorderStyle.FixedSingle,
                SplitterDistance = 60,
            };
            label1 = new Label()
            {
                Location = new Point(x1, y1),
                Text = s1,
                BackColor = Color.Transparent,
            };
            label2 = new Label()
            {
                Location = new Point(x2, y1),
                Text = s2,
                BackColor = Color.Transparent,
            };
            textbox1 = new TextBox()
            {
                Location = new Point(x1, y2),
                Size = new Size(120, 30),
                BorderStyle = BorderStyle.FixedSingle,
            };
            textbox2 = new TextBox()
            {
                Location = new Point(x2, y2),
                Size = new Size(200, 30),
                BorderStyle = BorderStyle.FixedSingle,
            };
            textbox3 = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
            };
            button2 = new Button
            {
                Location = new Point(x1 + 130, y2),
                Size = new Size(90, 30),
                Text = "�ϊ�",
            };
            button2.Click += Test2_Click;
            Splitcontainer1.Panel1.Controls.Add(label1);
            Splitcontainer1.Panel1.Controls.Add(label2);
            Splitcontainer1.Panel1.Controls.Add(textbox1);
            Splitcontainer1.Panel1.Controls.Add(button2);
            Splitcontainer1.Panel1.Controls.Add(textbox2);
            Splitcontainer1.Panel2.Controls.Add(textbox3);
            //Splitcontainer1.Panel1.Controls.Add(button1);
            Controls.Add(Splitcontainer1);
        }
 
        private void Test2_Click(object? sender, EventArgs e)

        {
            string s1 = textbox1.Text;
            int b = int.Parse(s1);
            string y = "";
            int c = b;
            while (c > 0) { y = (c & 0x1) + y; c = c >> 1; }
            for(c = y.Length; c < 8; c++) { y = "0" + y; }
            textbox2.Text =  y;
            textbox3.AppendText(
                $"B={s1},\t{y}\t"+
                $"1.1={b % 4}, "                   + $"1.2={b & 0x3}\t"+
                $"2.1={b / 4 % 16}, "              + $"2.2={(b >> 2) & 0xF},\t"+
                $"3.1={(128 <= b) && (b < 192)}, " + $"3.2={b >> 6 == 2}\r\n");
        }
    }
}