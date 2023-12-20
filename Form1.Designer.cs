namespace Dtat_protection_forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            listBox1 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            buttonRegister = new Button();
            buttonLogin = new Button();
            listBoxUsernameHashAlgorithms = new ListBox();
            listBoxPasswordHashAlghoritms = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(248, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(248, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(262, 23);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(350, 20);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(58, 201);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(670, 194);
            dataGridView1.TabIndex = 3;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "admin", "user" });
            listBox1.Location = new Point(248, 152);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(262, 19);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 76);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 5;
            label2.Text = "Пароль";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(350, 134);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 6;
            label3.Text = "Права";
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(89, 152);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(96, 23);
            buttonRegister.TabIndex = 7;
            buttonRegister.Text = "Регистрация";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(565, 152);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "Вход";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // listBoxUsernameHashAlgorithms
            // 
            listBoxUsernameHashAlgorithms.FormattingEnabled = true;
            listBoxUsernameHashAlgorithms.ItemHeight = 15;
            listBoxUsernameHashAlgorithms.Items.AddRange(new object[] { "MD5", "SHA-256" });
            listBoxUsernameHashAlgorithms.Location = new Point(545, 38);
            listBoxUsernameHashAlgorithms.Name = "listBoxUsernameHashAlgorithms";
            listBoxUsernameHashAlgorithms.Size = new Size(120, 19);
            listBoxUsernameHashAlgorithms.TabIndex = 9;
            // 
            // listBoxPasswordHashAlghoritms
            // 
            listBoxPasswordHashAlghoritms.FormattingEnabled = true;
            listBoxPasswordHashAlghoritms.ItemHeight = 15;
            listBoxPasswordHashAlghoritms.Items.AddRange(new object[] { "MD5", "SHA-256" });
            listBoxPasswordHashAlghoritms.Location = new Point(545, 94);
            listBoxPasswordHashAlghoritms.Name = "listBoxPasswordHashAlghoritms";
            listBoxPasswordHashAlghoritms.Size = new Size(120, 19);
            listBoxPasswordHashAlghoritms.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxPasswordHashAlghoritms);
            Controls.Add(listBoxUsernameHashAlgorithms);
            Controls.Add(buttonLogin);
            Controls.Add(buttonRegister);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Защита Информации   Практическая работа №5";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private DataGridView dataGridView1;
        private ListBox listBox1;
        private Label label2;
        private Label label3;
        private Button buttonRegister;
        private Button buttonLogin;
        private ListBox listBoxUsernameHashAlgorithms;
        private ListBox listBoxPasswordHashAlghoritms;
    }
}