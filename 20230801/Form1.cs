namespace TokuraBooks
{
    public partial class Form1 : Form
    {
        TextBox textbox1, textbox2, textbox3;

        public Form1()
        {
            InitializeComponent();

            //ラベルやテキストボックスなどを配置します
            MakeItems();
        }
        //10進のテキストボックスの値を2進に変換します
        private void D2B_Click(object sender, EventArgs e)
        {
            int D;
            string S = textbox1.Text;
            string B = "";

            Mes($"Input :{S}");
            if (S == "") { Mes("10 進数が必要"); return; }
            if (int.TryParse(S, out D) == false) { Mes("Illegal decimal number"); return; }

            Mes($"D={D}");
            while (D > 0)
            {
                B = (D % 2 == 0) ? "0" + B : "1" + B;
                D = D / 2;
                Mes($"B={B}, D={D}");
            }
            if (B == "") B = "0";
            Rep1($"{B}");
        }
        //2進のテキストボックスの値を10進に変換します
        private void B2D_Click(object sender, EventArgs e)
        {
            int D = 0;
            string S = textbox2.Text;
            string B = S;

            Mes($"Input :{S}");
            if (S == "") { Mes("2 進数が必要"); return; }

            foreach (char c in B)
            {
                D = 2 * D + (c - '0');
                Mes($"c={c}, D={D}");
            }
            Rep2($"{D}");
        }

        void Rep1(string s) => textbox1.Text = s;
        void Rep2(string s) => textbox2.Text = s;
        void Mes(string s) => textbox3.AppendText($"{s}\r\n");

        void Clear(object sender, EventArgs e) => textbox3.Clear();

        void MakeItems()
        {
            Panel panel;
            Label label1, label2;
            Button button1, button2, button3;

            panel = new Panel
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 200),
                BackColor = Color.White,
            };
            label1 = new Label()
            {
                Location = new Point(15, 20),
                Text = "10進",
                BackColor = Color.Transparent,
            };
            label2 = new Label()
            {
                Location = new Point(200, 20),
                Text = "2進",
                BackColor = Color.Transparent,
            };
            textbox1 = new TextBox()
            {
                Location = new Point(15, 60),
                Size = new Size(120, 30),
                BorderStyle = BorderStyle.FixedSingle,
            };
            textbox2 = new TextBox()
            {
                Location = new Point(200, 60),
                Size = new Size(200, 30),
                BorderStyle = BorderStyle.FixedSingle,
            };
            textbox3 = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
            };
            button1 = new Button()
            {
                Location = new Point(15, 100),
                Size = new Size(100, 50),
                Text = "10進2進",
            };
            button2 = new Button()
            {
                Location = new Point(200, 100),
                Size = new Size(100, 50),
                Text = "2進10進",
            };
            button3 = new Button()
            {
                Location = new Point(310, 100),
                Size = new Size(100, 50),
                Text = "クリア",
                ForeColor = Color.Black,
            };
            button1.Click += D2B_Click;
            button2.Click += B2D_Click;
            button3.Click += Clear;
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(textbox1);
            panel.Controls.Add(textbox2);
            panel.Controls.Add(button1);
            panel.Controls.Add(button2);
            panel.Controls.Add(button3);
            Controls.Add(textbox3);
            Controls.Add(panel);
        }
    }
}
