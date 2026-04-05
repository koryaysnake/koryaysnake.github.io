namespace Game
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиРезультатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветБочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.gameBoard = new System.Windows.Forms.TableLayoutPanel();
            this.btn16 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn14 = new System.Windows.Forms.Button();
            this.btn13 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.micePanel = new System.Windows.Forms.Panel();
            this.btnMouse4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMouse3 = new System.Windows.Forms.Button();
            this.btnMouse1 = new System.Windows.Forms.Button();
            this.btnMouse2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheckGuess = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gameBoard.SuspendLayout();
            this.micePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1419, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.моиРезультатыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // моиРезультатыToolStripMenuItem
            // 
            this.моиРезультатыToolStripMenuItem.Name = "моиРезультатыToolStripMenuItem";
            this.моиРезультатыToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.моиРезультатыToolStripMenuItem.Text = "Мои результаты";
            this.моиРезультатыToolStripMenuItem.Click += new System.EventHandler(this.показатьРезультатыToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветБочекToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // цветБочекToolStripMenuItem
            // 
            this.цветБочекToolStripMenuItem.Name = "цветБочекToolStripMenuItem";
            this.цветБочекToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.цветБочекToolStripMenuItem.Text = "Цвет бочек";
            this.цветБочекToolStripMenuItem.Click += new System.EventHandler(this.цветБочекToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правилаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // правилаToolStripMenuItem
            // 
            this.правилаToolStripMenuItem.Name = "правилаToolStripMenuItem";
            this.правилаToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.правилаToolStripMenuItem.Text = "Правила";
            this.правилаToolStripMenuItem.Click += new System.EventHandler(this.правилаToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(51, 63);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(49, 19);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "Игрок:";
            // 
            // gameBoard
            // 
            this.gameBoard.ColumnCount = 4;
            this.gameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.69128F));
            this.gameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.30872F));
            this.gameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.gameBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.gameBoard.Controls.Add(this.btn16, 3, 3);
            this.gameBoard.Controls.Add(this.btn15, 2, 3);
            this.gameBoard.Controls.Add(this.btn14, 1, 3);
            this.gameBoard.Controls.Add(this.btn13, 0, 3);
            this.gameBoard.Controls.Add(this.btn12, 3, 2);
            this.gameBoard.Controls.Add(this.btn11, 2, 2);
            this.gameBoard.Controls.Add(this.btn10, 1, 2);
            this.gameBoard.Controls.Add(this.btn9, 0, 2);
            this.gameBoard.Controls.Add(this.btn8, 3, 1);
            this.gameBoard.Controls.Add(this.btn7, 2, 1);
            this.gameBoard.Controls.Add(this.btn6, 1, 1);
            this.gameBoard.Controls.Add(this.btn5, 0, 1);
            this.gameBoard.Controls.Add(this.btn4, 3, 0);
            this.gameBoard.Controls.Add(this.btn3, 2, 0);
            this.gameBoard.Controls.Add(this.btn2, 1, 0);
            this.gameBoard.Controls.Add(this.btn1, 0, 0);
            this.gameBoard.Location = new System.Drawing.Point(864, 96);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.RowCount = 4;
            this.gameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.71795F));
            this.gameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.28205F));
            this.gameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.gameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.gameBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gameBoard.Size = new System.Drawing.Size(383, 425);
            this.gameBoard.TabIndex = 2;
            // 
            // btn16
            // 
            this.btn16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn16.Location = new System.Drawing.Point(284, 317);
            this.btn16.Name = "btn16";
            this.btn16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn16.Size = new System.Drawing.Size(96, 105);
            this.btn16.TabIndex = 15;
            this.btn16.Text = "15";
            this.btn16.UseVisualStyleBackColor = false;
            this.btn16.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn15
            // 
            this.btn15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn15.Location = new System.Drawing.Point(194, 317);
            this.btn15.Name = "btn15";
            this.btn15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn15.Size = new System.Drawing.Size(84, 105);
            this.btn15.TabIndex = 14;
            this.btn15.Text = "14";
            this.btn15.UseVisualStyleBackColor = false;
            this.btn15.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn14
            // 
            this.btn14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn14.Location = new System.Drawing.Point(106, 317);
            this.btn14.Name = "btn14";
            this.btn14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn14.Size = new System.Drawing.Size(82, 105);
            this.btn14.TabIndex = 13;
            this.btn14.Text = "13";
            this.btn14.UseVisualStyleBackColor = false;
            this.btn14.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn13
            // 
            this.btn13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn13.Location = new System.Drawing.Point(3, 317);
            this.btn13.Name = "btn13";
            this.btn13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn13.Size = new System.Drawing.Size(97, 105);
            this.btn13.TabIndex = 12;
            this.btn13.Text = "12";
            this.btn13.UseVisualStyleBackColor = false;
            this.btn13.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn12
            // 
            this.btn12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn12.Location = new System.Drawing.Point(284, 208);
            this.btn12.Name = "btn12";
            this.btn12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn12.Size = new System.Drawing.Size(96, 103);
            this.btn12.TabIndex = 11;
            this.btn12.Text = "11";
            this.btn12.UseVisualStyleBackColor = false;
            this.btn12.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn11
            // 
            this.btn11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn11.Location = new System.Drawing.Point(194, 208);
            this.btn11.Name = "btn11";
            this.btn11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn11.Size = new System.Drawing.Size(84, 103);
            this.btn11.TabIndex = 10;
            this.btn11.Text = "10";
            this.btn11.UseVisualStyleBackColor = false;
            this.btn11.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn10
            // 
            this.btn10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn10.Location = new System.Drawing.Point(106, 208);
            this.btn10.Name = "btn10";
            this.btn10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn10.Size = new System.Drawing.Size(82, 103);
            this.btn10.TabIndex = 9;
            this.btn10.Text = "9";
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn9.Location = new System.Drawing.Point(3, 208);
            this.btn9.Name = "btn9";
            this.btn9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn9.Size = new System.Drawing.Size(97, 103);
            this.btn9.TabIndex = 8;
            this.btn9.Text = "8";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn8.Location = new System.Drawing.Point(284, 103);
            this.btn8.Name = "btn8";
            this.btn8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn8.Size = new System.Drawing.Size(96, 99);
            this.btn8.TabIndex = 7;
            this.btn8.Text = "7";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn7.Location = new System.Drawing.Point(194, 103);
            this.btn7.Name = "btn7";
            this.btn7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn7.Size = new System.Drawing.Size(84, 99);
            this.btn7.TabIndex = 6;
            this.btn7.Text = "6";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn6.Location = new System.Drawing.Point(106, 103);
            this.btn6.Name = "btn6";
            this.btn6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn6.Size = new System.Drawing.Size(82, 99);
            this.btn6.TabIndex = 5;
            this.btn6.Text = "5";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn5.Location = new System.Drawing.Point(3, 103);
            this.btn5.Name = "btn5";
            this.btn5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn5.Size = new System.Drawing.Size(97, 99);
            this.btn5.TabIndex = 4;
            this.btn5.Text = "4";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn4.Location = new System.Drawing.Point(284, 3);
            this.btn4.Name = "btn4";
            this.btn4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn4.Size = new System.Drawing.Size(96, 94);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "3";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn3.Location = new System.Drawing.Point(194, 3);
            this.btn3.Name = "btn3";
            this.btn3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn3.Size = new System.Drawing.Size(84, 94);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "2";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn2.Location = new System.Drawing.Point(106, 3);
            this.btn2.Name = "btn2";
            this.btn2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn2.Size = new System.Drawing.Size(82, 94);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "1";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.BarrelClick);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1.Location = new System.Drawing.Point(3, 3);
            this.btn1.Name = "btn1";
            this.btn1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn1.Size = new System.Drawing.Size(97, 94);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "0";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.BarrelClick);
            // 
            // micePanel
            // 
            this.micePanel.Controls.Add(this.btnMouse4);
            this.micePanel.Controls.Add(this.label1);
            this.micePanel.Controls.Add(this.btnMouse3);
            this.micePanel.Controls.Add(this.btnMouse1);
            this.micePanel.Controls.Add(this.btnMouse2);
            this.micePanel.Controls.Add(this.label4);
            this.micePanel.Controls.Add(this.label2);
            this.micePanel.Controls.Add(this.label3);
            this.micePanel.Location = new System.Drawing.Point(46, 109);
            this.micePanel.Name = "micePanel";
            this.micePanel.Size = new System.Drawing.Size(560, 263);
            this.micePanel.TabIndex = 3;
            // 
            // btnMouse4
            // 
            this.btnMouse4.BackColor = System.Drawing.Color.Silver;
            this.btnMouse4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMouse4.ForeColor = System.Drawing.Color.Green;
            this.btnMouse4.Location = new System.Drawing.Point(19, 208);
            this.btnMouse4.Name = "btnMouse4";
            this.btnMouse4.Size = new System.Drawing.Size(48, 37);
            this.btnMouse4.TabIndex = 18;
            this.btnMouse4.Text = "🐭";
            this.btnMouse4.UseVisualStyleBackColor = false;
            this.btnMouse4.Click += new System.EventHandler(this.MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "мышь 1";
            // 
            // btnMouse3
            // 
            this.btnMouse3.BackColor = System.Drawing.Color.Silver;
            this.btnMouse3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMouse3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMouse3.Location = new System.Drawing.Point(19, 152);
            this.btnMouse3.Name = "btnMouse3";
            this.btnMouse3.Size = new System.Drawing.Size(48, 37);
            this.btnMouse3.TabIndex = 17;
            this.btnMouse3.Text = "🐭";
            this.btnMouse3.UseVisualStyleBackColor = false;
            this.btnMouse3.Click += new System.EventHandler(this.MouseClick);
            // 
            // btnMouse1
            // 
            this.btnMouse1.BackColor = System.Drawing.Color.Silver;
            this.btnMouse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMouse1.ForeColor = System.Drawing.Color.Black;
            this.btnMouse1.Location = new System.Drawing.Point(19, 31);
            this.btnMouse1.Name = "btnMouse1";
            this.btnMouse1.Size = new System.Drawing.Size(48, 37);
            this.btnMouse1.TabIndex = 15;
            this.btnMouse1.Text = "🐭";
            this.btnMouse1.UseVisualStyleBackColor = false;
            this.btnMouse1.Click += new System.EventHandler(this.MouseClick);
            // 
            // btnMouse2
            // 
            this.btnMouse2.BackColor = System.Drawing.Color.Silver;
            this.btnMouse2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMouse2.ForeColor = System.Drawing.Color.Red;
            this.btnMouse2.Location = new System.Drawing.Point(19, 92);
            this.btnMouse2.Name = "btnMouse2";
            this.btnMouse2.Size = new System.Drawing.Size(48, 37);
            this.btnMouse2.TabIndex = 16;
            this.btnMouse2.Text = "🐭";
            this.btnMouse2.UseVisualStyleBackColor = false;
            this.btnMouse2.Click += new System.EventHandler(this.MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "мышь 4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "мышь 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "мышь 3";
            // 
            // btnCheckGuess
            // 
            this.btnCheckGuess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCheckGuess.Location = new System.Drawing.Point(205, 378);
            this.btnCheckGuess.Name = "btnCheckGuess";
            this.btnCheckGuess.Size = new System.Drawing.Size(148, 54);
            this.btnCheckGuess.TabIndex = 12;
            this.btnCheckGuess.Text = "Угадать бочку";
            this.btnCheckGuess.UseVisualStyleBackColor = false;
            this.btnCheckGuess.Click += new System.EventHandler(this.btnCheckGuess_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNewGame.Location = new System.Drawing.Point(205, 467);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(148, 54);
            this.btnNewGame.TabIndex = 13;
            this.btnNewGame.Text = "Новая игра";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(870, 569);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 19);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Статус:";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1419, 750);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnCheckGuess);
            this.Controls.Add(this.micePanel);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "мышь 1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gameBoard.ResumeLayout(false);
            this.micePanel.ResumeLayout(false);
            this.micePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиРезультатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветБочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.TableLayoutPanel gameBoard;
        private System.Windows.Forms.Panel micePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCheckGuess;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn16;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn14;
        private System.Windows.Forms.Button btn13;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btnMouse1;
        private System.Windows.Forms.Button btnMouse2;
        private System.Windows.Forms.Button btnMouse3;
        private System.Windows.Forms.Button btnMouse4;
    }
}