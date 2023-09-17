using System.Text;

namespace Multiplier1._1
{
    public partial class Form1 : Form
    {
        int Count = 0;

        private TextBox InputA;
        private TextBox InputB;
        private TextBox RegisterA;
        private TextBox RegisterB;
        private TextBox RegisterPHight;
        private TextBox RegisterPLow;
        private Panel ControlPanel;
        private TextBox RegisterB_LSB;
        private TextBox ValueToAdd;
        private Label RegisterPDecimal;
        private Label CounterLabel;

        public Form1()
        {
            InitializeComponent();
            StageSetting1();
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            Pen pen2 = new Pen(Color.Black);

            int w1, w2, h1, h2;
            w1 = ControlPanel.Left + ControlPanel.Width + 5;
            w2 = RegisterA.Left - 5;
            h1 = RegisterA.Top + RegisterA.Height / 2;
            e.Graphics.DrawLine(pen2, w1, h1, w2, h1);
            w1 = RegisterA.Left + RegisterA.Width + 5;
            w2 = RegisterB.Left - 5;
            e.Graphics.DrawLine(pen2, w1, h1, w2, h1);
            w1 = RegisterA.Left + RegisterA.Width / 2;
            h1 = RegisterA.Top + RegisterA.Height + 5;
            h2 = ValueToAdd.Top - 5;
            e.Graphics.DrawLine(pen2, w1, h1, w1, h2);
            w1 = RegisterB.Left + RegisterB.Width - 5;
            h1 = RegisterB.Top + RegisterB.Height + 5;
            h2 = RegisterB_LSB.Top - 5;
            e.Graphics.DrawLine(pen2, w1, h1, w1, h2);
            w1 = ValueToAdd.Left + ValueToAdd.Width / 2;
            h1 = ValueToAdd.Top + ValueToAdd.Height + 5;
            h2 = RegisterPHight.Top - 5;
            e.Graphics.DrawLine(pen2, w1, h1, w1, h2);
        }
        private void button1_Click(object? sender, EventArgs e)
        {
            int i = 0;
            Count = 8;
            CounterLabel.Text = $"あと {Count} 回";

            if (int.TryParse(InputA.Text, out i))
            {
                i = (255 < i) ? 255 : i;
                InputA.Text = i.ToString();
                RegisterA.Text = Convert.ToString(i, 2).PadLeft(8, '0');
            }
            if (int.TryParse(InputB.Text, out i))
            {
                i = (255 < i) ? 255 : i;
                InputB.Text = i.ToString();
                RegisterB.Text = Convert.ToString(i, 2).PadLeft(8, '0');
            }
            this.Refresh();
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            RegisterB_LSB.Text = "0";
            ValueToAdd.Text = "00000000";
            this.Refresh();
            Application.DoEvents();
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            RegisterPHight.Text = "00000000";
            RegisterPLow.Text = "00000000";
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            if (Count == 0) return;

            RegisterB_LSB.Text = RegisterB.Text.Substring(RegisterB.Text.Length - 1, 1);
            RegisterB.Text = RegisterB.Text.Substring(0, RegisterB.Text.Length - 1);

            if (RegisterB_LSB.Text == "0")
            {
                ValueToAdd.Text = "00000000";
            }
            else
            {
                ValueToAdd.Text = RegisterA.Text;
            }
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            (string a, string shift) = Add2bitand2bit(ValueToAdd.Text, RegisterPHight.Text);

            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            RegisterPLow.Text = a.Substring(a.Length - 1, 1) + RegisterPLow.Text.Substring(0, RegisterPLow.Text.Length - 1);
            RegisterPHight.Text = shift + a.Substring(0, a.Length - 1);

            RegisterPDecimal.Text = BinToDec(RegisterPHight.Text, RegisterPLow.Text).ToString();

            Count--;
            CounterLabel.Text = $"あと {Count} 回";
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            RegisterA.Text = RegisterB.Text = RegisterPHight.Text = RegisterPLow.Text = RegisterB_LSB.Text = "0";
            Count = 0;
        }

        private (string, string) Add2bitand2bit(string a, string b)
        {
            string shift = "0", r = "";
            for (int i = b.Length - 1; -1 < i; i--)
            {
                int x = ((a[i] == '1') ? 1 : 0) + ((b[i] == '1' ? 1 : 0)) + ((shift == "1") ? 1 : 0);
                r = (((x % 2) == 0) ? "0" : "1") + r;
                shift = ((x / 2) == 1) ? "1" : "0";
            }
            return (r, shift);
        }
        private int BinToDec(string h, string l)
        {
            int a = 0, b = 0, c = 1;
            for (int i = 7; -1 < i; i--)
            {
                a += c * ((h[i] == '0') ? 0 : 1);
                b += c * ((l[i] == '0') ? 0 : 1);
                c *= 2;
            }
            return a * 256 + b;
        }
        private void StageSetting1()
        {
            Button button1;
            Button button2;
            Button button3;

            SuspendLayout();

            ControlPanel = new Panel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(12, 12),
                Size = new Size(359, 415),
            };
            ControlPanel.SuspendLayout();

            ControlPanel.Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(12, 41),
                Size = new Size(134, 20),
                Text = "A(10進数で0～255)",
            });
            InputA = new TextBox()
            {
                Location = new Point(12, 64),
                Size = new Size(125, 27),
                TextAlign = HorizontalAlignment.Right,
            };
            ControlPanel.Controls.Add(InputA);
            ControlPanel.Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(212, 41),
                Size = new Size(133, 20),
                TabIndex = 3,
                Text = "B(10進数で0～255)",
            });
            InputB = new TextBox()
            {
                Location = new Point(212, 64),
                Size = new Size(125, 27),
                TabIndex = 2,
                TextAlign = HorizontalAlignment.Right,
            };
            ControlPanel.Controls.Add(InputB);
            CounterLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(96, 198),
                Size = new Size(63, 20),
                Text = "あと 0 回",
                TextAlign = ContentAlignment.MiddleRight,
            };
            ControlPanel.Controls.Add(CounterLabel);
            button1 = new Button()
            {
                Location = new Point(180, 124),
                Size = new Size(157, 53),
                TabIndex = 4,
                Text = "Setup",
                UseVisualStyleBackColor = true,
            };
            button1.Click += button1_Click;
            button2 = new Button()
            {
                Location = new Point(180, 183),
                Size = new Size(157, 53),
                TabIndex = 5,
                Text = "Step",
                UseVisualStyleBackColor = true,
            };
            button2.Click += button2_Click;
            button3 = new Button()
            {
                Location = new Point(180, 267),
                Size = new Size(157, 53),
                Text = "Clear",
                UseVisualStyleBackColor = true,
            };
            button3.Click += button3_Click;

            ControlPanel.Controls.Add(button1);
            ControlPanel.Controls.Add(button2);
            ControlPanel.Controls.Add(button3);

            ControlPanel.ResumeLayout(false);
            Controls.Add(ControlPanel);

            Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(471, 54),
                Size = new Size(112, 20),
                Text = "Aレジスタ(2進数)",
            });
            RegisterA = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(470, 77),
                ReadOnly = true,
                Size = new Size(120, 27),
                TextAlign = HorizontalAlignment.Right,
            };
            Controls.Add(RegisterA);
            RegisterB = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(687, 78),
                Name = "textBox4",
                ReadOnly = true,
                Size = new Size(120, 27),
                TabIndex = 10,
                TextAlign = HorizontalAlignment.Right,
            };
            Controls.Add(RegisterB);
            Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(687, 55),
                Size = new Size(111, 20),
                Text = "Bレジスタ(2進数)",
            });
            RegisterPHight = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(471, 291),
                ReadOnly = true,
                Size = new Size(125, 27),
                TextAlign = HorizontalAlignment.Right,
            };
            Controls.Add(RegisterPHight);
            RegisterPLow = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(595, 291),
                ReadOnly = true,
                Size = new Size(125, 27),
                TextAlign = HorizontalAlignment.Right,
            };
            Controls.Add(RegisterPLow);
            Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(471, 264),
                Size = new Size(102, 20),
                Text = "Pレジスタ(上位)",
            });
            Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(595, 264),
                Size = new Size(102, 20),
                Text = "Pレジスタ(下位)",
            });

            Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(622, 155),
                Size = new Size(185, 20),
                Text = "BレジスタのLSB(最下位ビット)",
            });
            RegisterB_LSB = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(767, 186),
                ReadOnly = true,
                Size = new Size(40, 27),
                TextAlign = HorizontalAlignment.Right,
            };
            Controls.Add(RegisterB_LSB);
            ValueToAdd = new TextBox()
            {
                BackColor = SystemColors.Control,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(471, 185),
                ReadOnly = true,
                Size = new Size(125, 27),
                TextAlign = HorizontalAlignment.Right,
            };
            Controls.Add(ValueToAdd);
            Controls.Add(new Label()
            {
                AutoSize = true,
                Location = new Point(470, 155),
                Size = new Size(54, 20),
                Text = "加算値",
            });
            RegisterPDecimal = new Label()
            {
                Location = new Point(726, 289),
                Size = new Size(81, 29),
                Text = "0",
                TextAlign = ContentAlignment.MiddleRight,
            };
            Controls.Add(RegisterPDecimal);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 466);
            Text = "乗算器";
            Paint += Form1_Paint;
            ControlPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}