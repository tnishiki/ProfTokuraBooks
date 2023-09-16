namespace Multiplier1
{
    public partial class Form1 : Form
    {
        TextBox textbox1, textbox2, textbox3, repbox;
        Label label1, label2, label3;
        string Ls1 = "A", Ls2 = "B", Ls3 = "P";
        int va = 0, vb = 0, vp = 0;
        string sba = "", sbb = "", sbp = "", srep = "";
        public Form1()
        {

            InitializeComponent();
            StageSetting1();
        }
        void StageSetting1()
        {
            Button button1, button2, button3, button4, button5, button6;
            SplitContainer Splitcontainer1;
            int x1 = 60; int x2 = 160, x3 = 260;
            int y1 = 60; int y2 = 140; int y3 = 200, y4 = 250;
            int w1 = 120, w2 = 240, w3 = 80;
            int h1 = 60;
            int xoff = -30, yoff = -25;
            this.Width = 800;
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
                Location = new Point(x1 + xoff, y1 + yoff),
                Size = new Size(w1, 25),
                Text = Ls1,
                BackColor = Color.Transparent,
            };
            label2 = new Label()
            {
                Location = new Point(x3 + xoff, y1 + yoff),
                Size = new Size(w1, 25),
                Text = Ls2,
                BackColor = Color.Transparent,
            };
            label3 = new Label()
            {
                Location = new Point(x1 + xoff, y2 + yoff),
                Size = new Size(w1, 25),
                Text = Ls3,
                BackColor = Color.Transparent,
            };
            textbox1 = new TextBox()
            {
                Location = new Point(x1, y1),
                Size = new Size(w1, h1),
                BorderStyle = BorderStyle.FixedSingle,
            };
            textbox2 = new TextBox()
            {
                Location = new Point(x3, y1),
                Size = new Size(w1, h1),
                BorderStyle = BorderStyle.FixedSingle,
            };
            textbox3 = new TextBox()
            {
                Location = new Point(x1, y2),
                Size = new Size(w2, h1),
                BorderStyle = BorderStyle.FixedSingle,
            };
            repbox = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
            };
            button1 = new Button
            {
                Location = new Point(x1, y3),
                Size = new Size(w3, 30),
                Text = "Setup",
                Visible = true,
            };
            button2 = new Button
            {
                Location = new Point(x2, y3),
                Size = new Size(w3, 30),
                Text = "Clear",
            };
            button3 = new Button
            {
                Location = new Point(x3, y3),
                Size = new Size(w3, 30),
                Text = "Step",
            };
            button4 = new Button
            {
                Location = new Point(x1, y4),
                Size = new Size(w3, 30),
                Text = "Guide",
            };
            button5 = new Button
            {
                Location = new Point(x2, y4),
                Size = new Size(w3, 30),
                Text = "Quit",
            };
            button6 = new Button
            {
                Location = new Point(x3, y4),
                Size = new Size(w3, 30),
                Text = "Test",
            };
            button1.Click += Set_Click;
            button2.Click += Clear_Click;
            button3.Click += Step_Click;
            button4.Click += guide_Click;
            button5.Click += quit_Click;
            button6.Click += Test_Click;
            Splitcontainer1.Panel1.Controls.Add(label1);
            Splitcontainer1.Panel1.Controls.Add(label2);
            Splitcontainer1.Panel1.Controls.Add(label3);
            Splitcontainer1.Panel1.Controls.Add(textbox1);
            Splitcontainer1.Panel1.Controls.Add(textbox2);
            Splitcontainer1.Panel1.Controls.Add(textbox3);
            Splitcontainer1.Panel2.Controls.Add(repbox);
            Splitcontainer1.Panel1.Controls.Add(button1);
            Splitcontainer1.Panel1.Controls.Add(button2);
            Splitcontainer1.Panel1.Controls.Add(button3);
            Splitcontainer1.Panel1.Controls.Add(button4);
            Splitcontainer1.Panel1.Controls.Add(button5);
            Splitcontainer1.Panel1.Controls.Add(button6);
            Controls.Add(Splitcontainer1);
        }
        void mes(string s) => repbox.AppendText($"{s}\r\n");
        void rep(string s, int h)
        {
            int z = 0;
            for (int j = 0; j < s.Length; j++) { z = 2 * z + s[j] - '0'; }
            if (h == 1) { label1.Text = $"A {z}"; va = z; textbox1.Text = s; }
            else if (h == 2)
            {
                label2.Text = $"B {z}"; vb = z; textbox2.Text =
            s;
            }
            else if (h == 3)
            {
                label3.Text = $"P {z}"; vp = z; textbox3.Text =
            s;
            }
        }
        string val2Binary(int d, int k)
        {
            string bs = "01";
            string y = "";
            int c = d;
            while (c > 0) { y = bs[c % 2] + y; c = c / 2; }
            if (y.Length >= 9) return y;
            for (c = y.Length; c < k; c++) { y = "0" + y; }
            return y;
        }
        string sadd(string s1, string s2)
        {
            if (s1.Length != s2.Length) return "";
            string ss = "";
            int c = 0;
            for (int j = s1.Length; j > 0; j--)
            {
                int r = (s1[j - 1] - '0') + (s2[j - 1] - '0') + c;
                ss = (char)(r % 2 + '0') + ss;
                c = (r >= 2) ? 1 : 0;
            }
            ss = (char)(c + '0') + ss;
            return ss;
        }
        private void Set_Click(object sender, EventArgs e)
        {
            string ds1 = textbox1.Text;
            label1.Text = "A " + ds1;
            va = int.Parse(ds1);
            sba = val2Binary(va, 8);
            textbox1.Text = sba;
            string ds2 = textbox2.Text;
            label2.Text = "B " + ds2;
            vb = int.Parse(ds2);
            sbb = val2Binary(vb, 8);
            textbox2.Text = sbb;
            label3.Text = "P 0";
            sbp = "00000000";
            vp = 0;
            textbox3.Text = sbp;
            srep = $"A:{va} × B:{vb}";
            mes(srep);
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            label1.Text = "A "; va = 0; sba = ""; textbox1.Clear();
            label2.Text = "B "; vb = 0; sbb = ""; textbox2.Clear();
            label3.Text = "P "; vp = 0; sbp = ""; textbox3.Clear();
            repbox.Clear();
        }
        private void Step_Click(object sender, EventArgs e)
        {
            if (sbb == "")
            {
                mes("Finish");
                srep = srep + $" = {vp}";
                mes(srep);
                return;
            }
            string sbp = textbox3.Text;
            if (sbb.EndsWith("0"))
            {
                //mes($"B.LSB=0 Adder.through");
                sbp = '0' + sbp;
                rep(sbp, 3);
            }
            else
            {
                //mes($"B.LSB=1 Adder.Add");
                if (sbp.Length == sba.Length)
                {
                    sbp = sadd(sba, sbp);
                }
                else
                {
                    string sbpl = sbp.Remove(0, sba.Length);
                    string sbph = sadd(sba, sbp.Substring(0, sba.Length));
                    sbp = sbph + sbpl;
                }
                rep(sbp, 3);
            }
            sbb = sbb.Substring(0, sbb.Length - 1);
            rep(sbb, 2);
            mes($"{sba} {sbb.Length}: sbb={sbb} \t{sbp.Length}: sbp={sbp} ");
            rep(sbp, 3);
        }
        void guide_Click(object sender, EventArgs e)
        {
            mes("Aに被乗数を10進で，Bに乗数を10進で入力する");
            mes("Setupボタンをクリック");
            mes("以後，stepボタンを繰り返しクリック\r\n");
        }
        void quit_Click(object sender, EventArgs e) => Application.Exit();
        private void Test_Click(object sender, EventArgs e) => mes("off-service");
    }
}