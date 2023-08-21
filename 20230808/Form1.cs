using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            Button button1, button2;
            SplitContainer Splitcontainer1;
            string s1 = "10 進";
            string s2 = "2 進";
            int x1 = 15; int x2 = 200;
            int y1 = 20; int y2 = 60; int y3 = 100;
            Splitcontainer1 = new SplitContainer
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Orientation = Orientation.Vertical,
                SplitterWidth = 4,
                BorderStyle = BorderStyle.FixedSingle,
                SplitterDistance = 80,
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
            button1 = new Button
            {
                Location = new Point(x1, y3),
                Size = new Size(100, 30),
                Text = "10 進2進",
                Visible = false,
            };
            button2 = new Button
            {
                Location = new Point(x2, y3),
                Size = new Size(100, 30),
                Text = "test",
            };
            button2.Click += Test2_Click;
            Splitcontainer1.Panel1.Controls.Add(label1);
            Splitcontainer1.Panel1.Controls.Add(label2);
            Splitcontainer1.Panel1.Controls.Add(textbox1);
            Splitcontainer1.Panel1.Controls.Add(textbox2);
            Splitcontainer1.Panel2.Controls.Add(textbox3);
            Splitcontainer1.Panel1.Controls.Add(button1);
            Splitcontainer1.Panel1.Controls.Add(button2);
            Controls.Add(Splitcontainer1);
        }
 
        private void Test2_Click(object? sender, EventArgs e)

        {
            string s1 = textbox1.Text;
            int b = int.Parse(s1);
            string y = "";
            int c = b;
            while (c > 0) { y = (c & 0x1) + y; c = c >> 1; }
            textbox2.Text = y;
            textbox3.AppendText($"B={s1}, {y}, 1.1={b % 4}，1.2={b & 0x3} 2.1={b / 4 % 16}, 2.2={(b >> 2) & 0xF}, 3.1 ={(128 <= b) && (b < 192)}, 3.2 ={b >> 6 == 2}\r\n");
        }
    }
}