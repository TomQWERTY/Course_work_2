namespace CourseWork2
{
    partial class Form1
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
            this.mainTableIn = new System.Windows.Forms.DataGridView();
            this.numOfStatesTextBox = new System.Windows.Forms.TextBox();
            this.numOfSymbolsTextBox = new System.Windows.Forms.TextBox();
            this.acceptAllBut = new System.Windows.Forms.Button();
            this.startState = new System.Windows.Forms.TextBox();
            this.symbolsCountLabel = new System.Windows.Forms.Label();
            this.statesCountLabel = new System.Windows.Forms.Label();
            this.startStateLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.mainTableOut = new System.Windows.Forms.DataGridView();
            this.cleanT1Button = new System.Windows.Forms.Button();
            this.tRecogRadioButton = new System.Windows.Forms.RadioButton();
            this.MooreRadioButton = new System.Windows.Forms.RadioButton();
            this.MealyRadioButton = new System.Windows.Forms.RadioButton();
            this.createAutoButton = new System.Windows.Forms.Button();
            this.accept3 = new System.Windows.Forms.Button();
            this.accept2 = new System.Windows.Forms.Button();
            this.accept1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recogRadioButton = new System.Windows.Forms.RadioButton();
            this.loadButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.startS22 = new System.Windows.Forms.Label();
            this.addTableIn = new System.Windows.Forms.DataGridView();
            this.startS2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.deleteResult = new System.Windows.Forms.Button();
            this.addTableOut = new System.Windows.Forms.DataGridView();
            this.finalSSLabel2 = new System.Windows.Forms.Label();
            this.finalSSLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainTableIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTableOut)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTableIn)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTableOut)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableIn
            // 
            this.mainTableIn.AllowUserToAddRows = false;
            this.mainTableIn.AllowUserToDeleteRows = false;
            this.mainTableIn.AllowUserToResizeColumns = false;
            this.mainTableIn.AllowUserToResizeRows = false;
            this.mainTableIn.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mainTableIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTableIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTableIn.ColumnHeadersVisible = false;
            this.mainTableIn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.mainTableIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainTableIn.Location = new System.Drawing.Point(6, 48);
            this.mainTableIn.MultiSelect = false;
            this.mainTableIn.Name = "mainTableIn";
            this.mainTableIn.RowHeadersVisible = false;
            this.mainTableIn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mainTableIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mainTableIn.Size = new System.Drawing.Size(54, 18);
            this.mainTableIn.TabIndex = 14;
            // 
            // numOfStatesTextBox
            // 
            this.numOfStatesTextBox.Location = new System.Drawing.Point(114, 44);
            this.numOfStatesTextBox.Name = "numOfStatesTextBox";
            this.numOfStatesTextBox.Size = new System.Drawing.Size(39, 20);
            this.numOfStatesTextBox.TabIndex = 9;
            this.numOfStatesTextBox.Text = "2";
            // 
            // numOfSymbolsTextBox
            // 
            this.numOfSymbolsTextBox.Location = new System.Drawing.Point(114, 18);
            this.numOfSymbolsTextBox.Name = "numOfSymbolsTextBox";
            this.numOfSymbolsTextBox.Size = new System.Drawing.Size(39, 20);
            this.numOfSymbolsTextBox.TabIndex = 7;
            this.numOfSymbolsTextBox.Text = "2";
            // 
            // acceptAllBut
            // 
            this.acceptAllBut.Location = new System.Drawing.Point(135, 97);
            this.acceptAllBut.Name = "acceptAllBut";
            this.acceptAllBut.Size = new System.Drawing.Size(107, 23);
            this.acceptAllBut.TabIndex = 13;
            this.acceptAllBut.Text = "Застосувати все";
            this.acceptAllBut.UseVisualStyleBackColor = true;
            // 
            // startState
            // 
            this.startState.Location = new System.Drawing.Point(114, 70);
            this.startState.Name = "startState";
            this.startState.Size = new System.Drawing.Size(39, 20);
            this.startState.TabIndex = 11;
            this.startState.Text = "0";
            // 
            // symbolsCountLabel
            // 
            this.symbolsCountLabel.AutoSize = true;
            this.symbolsCountLabel.Location = new System.Drawing.Point(6, 21);
            this.symbolsCountLabel.Name = "symbolsCountLabel";
            this.symbolsCountLabel.Size = new System.Drawing.Size(102, 13);
            this.symbolsCountLabel.TabIndex = 6;
            this.symbolsCountLabel.Text = "Кількість символів";
            // 
            // statesCountLabel
            // 
            this.statesCountLabel.AutoSize = true;
            this.statesCountLabel.Location = new System.Drawing.Point(6, 47);
            this.statesCountLabel.Name = "statesCountLabel";
            this.statesCountLabel.Size = new System.Drawing.Size(87, 13);
            this.statesCountLabel.TabIndex = 7;
            this.statesCountLabel.Text = "Кількість станів";
            // 
            // startStateLabel
            // 
            this.startStateLabel.AutoSize = true;
            this.startStateLabel.Location = new System.Drawing.Point(6, 73);
            this.startStateLabel.Name = "startStateLabel";
            this.startStateLabel.Size = new System.Drawing.Size(93, 13);
            this.startStateLabel.TabIndex = 8;
            this.startStateLabel.Text = "Початковий стан";
            // 
            // minimizeButton
            // 
            this.minimizeButton.Location = new System.Drawing.Point(6, 19);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(102, 23);
            this.minimizeButton.TabIndex = 18;
            this.minimizeButton.Text = "Мінімізувати";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // mainTableOut
            // 
            this.mainTableOut.AllowUserToAddRows = false;
            this.mainTableOut.AllowUserToDeleteRows = false;
            this.mainTableOut.AllowUserToResizeColumns = false;
            this.mainTableOut.AllowUserToResizeRows = false;
            this.mainTableOut.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mainTableOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTableOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTableOut.ColumnHeadersVisible = false;
            this.mainTableOut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.mainTableOut.Location = new System.Drawing.Point(6, 48);
            this.mainTableOut.MultiSelect = false;
            this.mainTableOut.Name = "mainTableOut";
            this.mainTableOut.ReadOnly = true;
            this.mainTableOut.RowHeadersVisible = false;
            this.mainTableOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mainTableOut.Size = new System.Drawing.Size(37, 16);
            this.mainTableOut.TabIndex = 10;
            this.mainTableOut.TabStop = false;
            // 
            // cleanT1Button
            // 
            this.cleanT1Button.Location = new System.Drawing.Point(130, 19);
            this.cleanT1Button.Name = "cleanT1Button";
            this.cleanT1Button.Size = new System.Drawing.Size(80, 23);
            this.cleanT1Button.TabIndex = 16;
            this.cleanT1Button.Text = "Очистити";
            this.cleanT1Button.UseVisualStyleBackColor = true;
            this.cleanT1Button.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // tRecogRadioButton
            // 
            this.tRecogRadioButton.AutoSize = true;
            this.tRecogRadioButton.Checked = true;
            this.tRecogRadioButton.Location = new System.Drawing.Point(6, 19);
            this.tRecogRadioButton.Name = "tRecogRadioButton";
            this.tRecogRadioButton.Size = new System.Drawing.Size(127, 17);
            this.tRecogRadioButton.TabIndex = 1;
            this.tRecogRadioButton.TabStop = true;
            this.tRecogRadioButton.Text = "Повний розпізнавач";
            this.tRecogRadioButton.UseVisualStyleBackColor = true;
            // 
            // MooreRadioButton
            // 
            this.MooreRadioButton.AutoSize = true;
            this.MooreRadioButton.Location = new System.Drawing.Point(6, 65);
            this.MooreRadioButton.Name = "MooreRadioButton";
            this.MooreRadioButton.Size = new System.Drawing.Size(97, 17);
            this.MooreRadioButton.TabIndex = 3;
            this.MooreRadioButton.TabStop = true;
            this.MooreRadioButton.Text = "Автомат Мура";
            this.MooreRadioButton.UseVisualStyleBackColor = true;
            // 
            // MealyRadioButton
            // 
            this.MealyRadioButton.AutoSize = true;
            this.MealyRadioButton.Location = new System.Drawing.Point(6, 88);
            this.MealyRadioButton.Name = "MealyRadioButton";
            this.MealyRadioButton.Size = new System.Drawing.Size(90, 17);
            this.MealyRadioButton.TabIndex = 4;
            this.MealyRadioButton.TabStop = true;
            this.MealyRadioButton.Text = "Автомат Мілі";
            this.MealyRadioButton.UseVisualStyleBackColor = true;
            // 
            // createAutoButton
            // 
            this.createAutoButton.Location = new System.Drawing.Point(6, 111);
            this.createAutoButton.Name = "createAutoButton";
            this.createAutoButton.Size = new System.Drawing.Size(102, 23);
            this.createAutoButton.TabIndex = 5;
            this.createAutoButton.Text = "Створити";
            this.createAutoButton.UseVisualStyleBackColor = true;
            // 
            // accept3
            // 
            this.accept3.Location = new System.Drawing.Point(159, 68);
            this.accept3.Name = "accept3";
            this.accept3.Size = new System.Drawing.Size(83, 23);
            this.accept3.TabIndex = 12;
            this.accept3.Text = "Застосувати";
            this.accept3.UseVisualStyleBackColor = true;
            this.accept3.Click += new System.EventHandler(this.accept3_Click);
            // 
            // accept2
            // 
            this.accept2.Location = new System.Drawing.Point(159, 42);
            this.accept2.Name = "accept2";
            this.accept2.Size = new System.Drawing.Size(83, 23);
            this.accept2.TabIndex = 10;
            this.accept2.Text = "Застосувати";
            this.accept2.UseVisualStyleBackColor = true;
            this.accept2.Click += new System.EventHandler(this.accept2_Click);
            // 
            // accept1
            // 
            this.accept1.Location = new System.Drawing.Point(159, 16);
            this.accept1.Name = "accept1";
            this.accept1.Size = new System.Drawing.Size(83, 23);
            this.accept1.TabIndex = 8;
            this.accept1.Text = "Застосувати";
            this.accept1.UseVisualStyleBackColor = true;
            this.accept1.Click += new System.EventHandler(this.accept1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recogRadioButton);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Controls.Add(this.tRecogRadioButton);
            this.groupBox1.Controls.Add(this.MooreRadioButton);
            this.groupBox1.Controls.Add(this.MealyRadioButton);
            this.groupBox1.Controls.Add(this.createAutoButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 186);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип автомата";
            // 
            // recogRadioButton
            // 
            this.recogRadioButton.AutoSize = true;
            this.recogRadioButton.Location = new System.Drawing.Point(6, 42);
            this.recogRadioButton.Name = "recogRadioButton";
            this.recogRadioButton.Size = new System.Drawing.Size(139, 17);
            this.recogRadioButton.TabIndex = 2;
            this.recogRadioButton.TabStop = true;
            this.recogRadioButton.Text = "Неповний розпізнавач";
            this.recogRadioButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(6, 140);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(102, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Завантажити";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.symbolsCountLabel);
            this.groupBox2.Controls.Add(this.numOfStatesTextBox);
            this.groupBox2.Controls.Add(this.accept1);
            this.groupBox2.Controls.Add(this.numOfSymbolsTextBox);
            this.groupBox2.Controls.Add(this.accept2);
            this.groupBox2.Controls.Add(this.acceptAllBut);
            this.groupBox2.Controls.Add(this.accept3);
            this.groupBox2.Controls.Add(this.startState);
            this.groupBox2.Controls.Add(this.statesCountLabel);
            this.groupBox2.Controls.Add(this.startStateLabel);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 125);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметри автомата";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.startS22);
            this.groupBox3.Controls.Add(this.addTableIn);
            this.groupBox3.Controls.Add(this.mainTableIn);
            this.groupBox3.Controls.Add(this.cleanT1Button);
            this.groupBox3.Controls.Add(this.startS2);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.groupBox3.Size = new System.Drawing.Size(217, 190);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Табличне подання";
            // 
            // startS22
            // 
            this.startS22.AutoSize = true;
            this.startS22.Location = new System.Drawing.Point(108, 21);
            this.startS22.Name = "startS22";
            this.startS22.Size = new System.Drawing.Size(13, 13);
            this.startS22.TabIndex = 14;
            this.startS22.Text = "0";
            // 
            // addTableIn
            // 
            this.addTableIn.AllowUserToAddRows = false;
            this.addTableIn.AllowUserToDeleteRows = false;
            this.addTableIn.AllowUserToResizeColumns = false;
            this.addTableIn.AllowUserToResizeRows = false;
            this.addTableIn.BackgroundColor = System.Drawing.SystemColors.Control;
            this.addTableIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addTableIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addTableIn.ColumnHeadersVisible = false;
            this.addTableIn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.addTableIn.Location = new System.Drawing.Point(6, 150);
            this.addTableIn.MultiSelect = false;
            this.addTableIn.Name = "addTableIn";
            this.addTableIn.RowHeadersVisible = false;
            this.addTableIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.addTableIn.Size = new System.Drawing.Size(54, 24);
            this.addTableIn.TabIndex = 15;
            // 
            // startS2
            // 
            this.startS2.AutoSize = true;
            this.startS2.Location = new System.Drawing.Point(3, 21);
            this.startS2.Name = "startS2";
            this.startS2.Size = new System.Drawing.Size(99, 13);
            this.startS2.TabIndex = 13;
            this.startS2.Text = "Початковий стан: ";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.deleteResult);
            this.groupBox4.Controls.Add(this.addTableOut);
            this.groupBox4.Controls.Add(this.finalSSLabel2);
            this.groupBox4.Controls.Add(this.finalSSLabel);
            this.groupBox4.Controls.Add(this.mainTableOut);
            this.groupBox4.Location = new System.Drawing.Point(12, 464);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.groupBox4.Size = new System.Drawing.Size(217, 135);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Мінімізований автомат";
            this.groupBox4.Visible = false;
            // 
            // deleteResult
            // 
            this.deleteResult.Location = new System.Drawing.Point(135, 19);
            this.deleteResult.Name = "deleteResult";
            this.deleteResult.Size = new System.Drawing.Size(75, 23);
            this.deleteResult.TabIndex = 17;
            this.deleteResult.Text = "Видалити";
            this.deleteResult.UseVisualStyleBackColor = true;
            this.deleteResult.Click += new System.EventHandler(this.deleteResult_Click);
            // 
            // addTableOut
            // 
            this.addTableOut.AllowUserToAddRows = false;
            this.addTableOut.AllowUserToDeleteRows = false;
            this.addTableOut.AllowUserToResizeColumns = false;
            this.addTableOut.AllowUserToResizeRows = false;
            this.addTableOut.BackgroundColor = System.Drawing.SystemColors.Control;
            this.addTableOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addTableOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addTableOut.ColumnHeadersVisible = false;
            this.addTableOut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.addTableOut.Location = new System.Drawing.Point(6, 108);
            this.addTableOut.MultiSelect = false;
            this.addTableOut.Name = "addTableOut";
            this.addTableOut.ReadOnly = true;
            this.addTableOut.RowHeadersVisible = false;
            this.addTableOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.addTableOut.Size = new System.Drawing.Size(69, 11);
            this.addTableOut.TabIndex = 15;
            this.addTableOut.TabStop = false;
            // 
            // finalSSLabel2
            // 
            this.finalSSLabel2.AutoSize = true;
            this.finalSSLabel2.Location = new System.Drawing.Point(108, 21);
            this.finalSSLabel2.Name = "finalSSLabel2";
            this.finalSSLabel2.Size = new System.Drawing.Size(0, 13);
            this.finalSSLabel2.TabIndex = 12;
            // 
            // finalSSLabel
            // 
            this.finalSSLabel.AutoSize = true;
            this.finalSSLabel.Location = new System.Drawing.Point(3, 21);
            this.finalSSLabel.Name = "finalSSLabel";
            this.finalSSLabel.Size = new System.Drawing.Size(99, 13);
            this.finalSSLabel.TabIndex = 11;
            this.finalSSLabel.Text = "Початковий стан: ";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "saved.txt";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.saveButton);
            this.groupBox5.Controls.Add(this.minimizeButton);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(218, 143);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(261, 55);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Автомат";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(114, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(102, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Зберегти";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(491, 447);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainTableIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTableOut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTableIn)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addTableOut)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainTableIn;
        private System.Windows.Forms.TextBox numOfStatesTextBox;
        private System.Windows.Forms.TextBox numOfSymbolsTextBox;
        private System.Windows.Forms.Button acceptAllBut;
        private System.Windows.Forms.TextBox startState;
        private System.Windows.Forms.Label symbolsCountLabel;
        private System.Windows.Forms.Label statesCountLabel;
        private System.Windows.Forms.Label startStateLabel;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.DataGridView mainTableOut;
        private System.Windows.Forms.Button cleanT1Button;
        private System.Windows.Forms.RadioButton tRecogRadioButton;
        private System.Windows.Forms.RadioButton MooreRadioButton;
        private System.Windows.Forms.RadioButton MealyRadioButton;
        private System.Windows.Forms.Button createAutoButton;
        private System.Windows.Forms.Button accept3;
        private System.Windows.Forms.Button accept2;
        private System.Windows.Forms.Button accept1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton recogRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label finalSSLabel2;
        private System.Windows.Forms.Label finalSSLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label startS22;
        private System.Windows.Forms.Label startS2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.DataGridView addTableOut;
        private System.Windows.Forms.DataGridView addTableIn;
        private System.Windows.Forms.Button deleteResult;
    }
}

