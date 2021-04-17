namespace PIDMicrosoft
{
    partial class MyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchKeysTextbox = new System.Windows.Forms.TextBox();
            this.showDeadKeysCheckbox = new System.Windows.Forms.CheckBox();
            this.keyDataGridView = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.threadNumComboBox = new System.Windows.Forms.ComboBox();
            this.pidCheckLabel = new System.Windows.Forms.Label();
            this.pidOutputTextbox = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.pidInputTextbox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cidDashOutputTextBox = new System.Windows.Forms.TextBox();
            this.cidDashCopyButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cidCommandOutputTextbox = new System.Windows.Forms.TextBox();
            this.cidCommandType = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.copyRawCIDButton = new System.Windows.Forms.Button();
            this.cidOutputTextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cidTimeLabel = new System.Windows.Forms.Label();
            this.getCIDButton = new System.Windows.Forms.Button();
            this.iidInputTextBox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rememberAccountCheckbox = new System.Windows.Forms.CheckBox();
            this.loginStatusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.accountTypeLabel = new System.Windows.Forms.Label();
            this.userEmailLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.expiredDateLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 537);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnAccountTabShown);
            this.tabControl1.Enter += new System.EventHandler(this.OnAccountFocused);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.searchKeysTextbox);
            this.tabPage1.Controls.Add(this.showDeadKeysCheckbox);
            this.tabPage1.Controls.Add(this.keyDataGridView);
            this.tabPage1.Controls.Add(this.keyTypeComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(893, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Keys";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Select Keys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search Keys";
            // 
            // searchKeysTextbox
            // 
            this.searchKeysTextbox.Location = new System.Drawing.Point(577, 6);
            this.searchKeysTextbox.Name = "searchKeysTextbox";
            this.searchKeysTextbox.Size = new System.Drawing.Size(186, 20);
            this.searchKeysTextbox.TabIndex = 3;
            this.searchKeysTextbox.Click += new System.EventHandler(this.searchTextbox_clicked);
            this.searchKeysTextbox.TextChanged += new System.EventHandler(this.searchKeys_textChanged);
            this.searchKeysTextbox.DoubleClick += new System.EventHandler(this.searchTextbox_doubleClicked);
            // 
            // showDeadKeysCheckbox
            // 
            this.showDeadKeysCheckbox.AutoSize = true;
            this.showDeadKeysCheckbox.Location = new System.Drawing.Point(782, 8);
            this.showDeadKeysCheckbox.Name = "showDeadKeysCheckbox";
            this.showDeadKeysCheckbox.Size = new System.Drawing.Size(108, 17);
            this.showDeadKeysCheckbox.TabIndex = 2;
            this.showDeadKeysCheckbox.Text = "Show Dead Keys";
            this.showDeadKeysCheckbox.UseVisualStyleBackColor = true;
            this.showDeadKeysCheckbox.CheckedChanged += new System.EventHandler(this.showDeadKeys_checkedChanged);
            // 
            // keyDataGridView
            // 
            this.keyDataGridView.AllowUserToAddRows = false;
            this.keyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.keyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.keyDataGridView.Location = new System.Drawing.Point(6, 33);
            this.keyDataGridView.Name = "keyDataGridView";
            this.keyDataGridView.ReadOnly = true;
            this.keyDataGridView.RowHeadersVisible = false;
            this.keyDataGridView.Size = new System.Drawing.Size(881, 475);
            this.keyDataGridView.TabIndex = 1;
            this.keyDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.keyDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.keyTableMouseClick);
            // 
            // Column7
            // 
            this.Column7.FillWeight = 26.14404F;
            this.Column7.HeaderText = "ID";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 182.7411F;
            this.Column1.HeaderText = "Product Key";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 97.77871F;
            this.Column3.HeaderText = "Sub Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 97.77871F;
            this.Column4.HeaderText = "Activation Count";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 97.77871F;
            this.Column5.HeaderText = "Error Code";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 97.77871F;
            this.Column6.HeaderText = "Time";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // keyTypeComboBox
            // 
            this.keyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyTypeComboBox.FormattingEnabled = true;
            this.keyTypeComboBox.Location = new System.Drawing.Point(75, 6);
            this.keyTypeComboBox.Name = "keyTypeComboBox";
            this.keyTypeComboBox.Size = new System.Drawing.Size(411, 21);
            this.keyTypeComboBox.TabIndex = 0;
            this.keyTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyTypeSelectedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.threadNumComboBox);
            this.tabPage2.Controls.Add(this.pidCheckLabel);
            this.tabPage2.Controls.Add(this.pidOutputTextbox);
            this.tabPage2.Controls.Add(this.checkButton);
            this.tabPage2.Controls.Add(this.pidInputTextbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Check Key";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // threadNumComboBox
            // 
            this.threadNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.threadNumComboBox.FormattingEnabled = true;
            this.threadNumComboBox.Location = new System.Drawing.Point(0, 203);
            this.threadNumComboBox.Name = "threadNumComboBox";
            this.threadNumComboBox.Size = new System.Drawing.Size(97, 21);
            this.threadNumComboBox.TabIndex = 4;
            // 
            // pidCheckLabel
            // 
            this.pidCheckLabel.AutoSize = true;
            this.pidCheckLabel.Location = new System.Drawing.Point(3, 495);
            this.pidCheckLabel.Name = "pidCheckLabel";
            this.pidCheckLabel.Size = new System.Drawing.Size(125, 13);
            this.pidCheckLabel.TabIndex = 3;
            this.pidCheckLabel.Text = "Check key status at here";
            // 
            // pidOutputTextbox
            // 
            this.pidOutputTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.pidOutputTextbox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pidOutputTextbox.Location = new System.Drawing.Point(0, 233);
            this.pidOutputTextbox.Multiline = true;
            this.pidOutputTextbox.Name = "pidOutputTextbox";
            this.pidOutputTextbox.ReadOnly = true;
            this.pidOutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pidOutputTextbox.Size = new System.Drawing.Size(890, 259);
            this.pidOutputTextbox.TabIndex = 2;
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(374, 198);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(125, 29);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Check Online";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.OnCheckButtonClick);
            // 
            // pidInputTextbox
            // 
            this.pidInputTextbox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pidInputTextbox.Location = new System.Drawing.Point(0, 3);
            this.pidInputTextbox.Multiline = true;
            this.pidInputTextbox.Name = "pidInputTextbox";
            this.pidInputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pidInputTextbox.Size = new System.Drawing.Size(890, 189);
            this.pidInputTextbox.TabIndex = 0;
            this.pidInputTextbox.Click += new System.EventHandler(this.pidCheckTextboxInput_Clicked);
            this.pidInputTextbox.DoubleClick += new System.EventHandler(this.pidCheckTextboxInput_DoubleClicked);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cidDashOutputTextBox);
            this.tabPage3.Controls.Add(this.cidDashCopyButton);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.cidCommandOutputTextbox);
            this.tabPage3.Controls.Add(this.cidCommandType);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.copyRawCIDButton);
            this.tabPage3.Controls.Add(this.cidOutputTextBox);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.cidTimeLabel);
            this.tabPage3.Controls.Add(this.getCIDButton);
            this.tabPage3.Controls.Add(this.iidInputTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(893, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Get CID";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cidDashOutputTextBox
            // 
            this.cidDashOutputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.cidDashOutputTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cidDashOutputTextBox.Location = new System.Drawing.Point(64, 204);
            this.cidDashOutputTextBox.Name = "cidDashOutputTextBox";
            this.cidDashOutputTextBox.ReadOnly = true;
            this.cidDashOutputTextBox.Size = new System.Drawing.Size(644, 22);
            this.cidDashOutputTextBox.TabIndex = 13;
            this.cidDashOutputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cidDashCopyButton
            // 
            this.cidDashCopyButton.Location = new System.Drawing.Point(731, 203);
            this.cidDashCopyButton.Name = "cidDashCopyButton";
            this.cidDashCopyButton.Size = new System.Drawing.Size(85, 23);
            this.cidDashCopyButton.TabIndex = 12;
            this.cidDashCopyButton.Text = "Copy";
            this.cidDashCopyButton.UseVisualStyleBackColor = true;
            this.cidDashCopyButton.Click += new System.EventHandler(this.cidDashOutputCopyButtonClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(754, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(64, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Confirmation ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Installation ID";
            // 
            // cidCommandOutputTextbox
            // 
            this.cidCommandOutputTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.cidCommandOutputTextbox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cidCommandOutputTextbox.Location = new System.Drawing.Point(65, 270);
            this.cidCommandOutputTextbox.Multiline = true;
            this.cidCommandOutputTextbox.Name = "cidCommandOutputTextbox";
            this.cidCommandOutputTextbox.ReadOnly = true;
            this.cidCommandOutputTextbox.Size = new System.Drawing.Size(751, 222);
            this.cidCommandOutputTextbox.TabIndex = 8;
            // 
            // cidCommandType
            // 
            this.cidCommandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cidCommandType.FormattingEnabled = true;
            this.cidCommandType.Location = new System.Drawing.Point(64, 243);
            this.cidCommandType.Name = "cidCommandType";
            this.cidCommandType.Size = new System.Drawing.Size(644, 21);
            this.cidCommandType.TabIndex = 7;
            this.cidCommandType.SelectedIndexChanged += new System.EventHandler(this.UpdateCIDComandOutput);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(731, 241);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Copy";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.CopyCIDCommand);
            // 
            // copyRawCIDButton
            // 
            this.copyRawCIDButton.Location = new System.Drawing.Point(731, 159);
            this.copyRawCIDButton.Name = "copyRawCIDButton";
            this.copyRawCIDButton.Size = new System.Drawing.Size(85, 23);
            this.copyRawCIDButton.TabIndex = 5;
            this.copyRawCIDButton.Text = "Copy";
            this.copyRawCIDButton.UseVisualStyleBackColor = true;
            this.copyRawCIDButton.Click += new System.EventHandler(this.copyRawCIDButton_Click);
            // 
            // cidOutputTextBox
            // 
            this.cidOutputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.cidOutputTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cidOutputTextBox.Location = new System.Drawing.Point(64, 160);
            this.cidOutputTextBox.Name = "cidOutputTextBox";
            this.cidOutputTextBox.ReadOnly = true;
            this.cidOutputTextBox.Size = new System.Drawing.Size(644, 22);
            this.cidOutputTextBox.TabIndex = 4;
            this.cidOutputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(64, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Live Get";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cidTimeLabel
            // 
            this.cidTimeLabel.AutoSize = true;
            this.cidTimeLabel.Location = new System.Drawing.Point(61, 94);
            this.cidTimeLabel.Name = "cidTimeLabel";
            this.cidTimeLabel.Size = new System.Drawing.Size(97, 13);
            this.cidTimeLabel.TabIndex = 2;
            this.cidTimeLabel.Text = "Time status at here";
            this.cidTimeLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // getCIDButton
            // 
            this.getCIDButton.Location = new System.Drawing.Point(731, 36);
            this.getCIDButton.Name = "getCIDButton";
            this.getCIDButton.Size = new System.Drawing.Size(85, 23);
            this.getCIDButton.TabIndex = 1;
            this.getCIDButton.Text = "Get CID";
            this.getCIDButton.UseVisualStyleBackColor = true;
            this.getCIDButton.Click += new System.EventHandler(this.GetCID_Click);
            // 
            // iidInputTextBox
            // 
            this.iidInputTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iidInputTextBox.Location = new System.Drawing.Point(64, 37);
            this.iidInputTextBox.Multiline = true;
            this.iidInputTextBox.Name = "iidInputTextBox";
            this.iidInputTextBox.Size = new System.Drawing.Size(644, 20);
            this.iidInputTextBox.TabIndex = 0;
            this.iidInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.iidInputTextBox.Click += new System.EventHandler(this.cidInputTextbox_Clicked);
            this.iidInputTextBox.TextChanged += new System.EventHandler(this.iidInputTextChanged);
            this.iidInputTextBox.DoubleClick += new System.EventHandler(this.cidInputTextbox_DoubleClicked);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(893, 511);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Account";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Enter += new System.EventHandler(this.OnAccountTabSelected);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rememberAccountCheckbox);
            this.splitContainer1.Panel1.Controls.Add(this.loginStatusLabel);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.passwordTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.emailTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button8);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Size = new System.Drawing.Size(887, 495);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 17;
            // 
            // rememberAccountCheckbox
            // 
            this.rememberAccountCheckbox.AutoSize = true;
            this.rememberAccountCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberAccountCheckbox.Location = new System.Drawing.Point(115, 132);
            this.rememberAccountCheckbox.Name = "rememberAccountCheckbox";
            this.rememberAccountCheckbox.Size = new System.Drawing.Size(137, 17);
            this.rememberAccountCheckbox.TabIndex = 12;
            this.rememberAccountCheckbox.Text = "Remember My Account";
            this.rememberAccountCheckbox.UseVisualStyleBackColor = true;
            // 
            // loginStatusLabel
            // 
            this.loginStatusLabel.AutoSize = true;
            this.loginStatusLabel.Location = new System.Drawing.Point(112, 227);
            this.loginStatusLabel.Name = "loginStatusLabel";
            this.loginStatusLabel.Size = new System.Drawing.Size(100, 13);
            this.loginStatusLabel.TabIndex = 13;
            this.loginStatusLabel.Text = "Login status at here";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Register";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RegisterButtonClick);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(115, 92);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(160, 20);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(115, 42);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(160, 20);
            this.emailTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Email";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(297, 45);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 23);
            this.button8.TabIndex = 19;
            this.button8.Text = "Upgrade/Donate";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.DonateButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.93916F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.06084F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.accountTypeLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.userEmailLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.expiredDateLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 216);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Email:";
            // 
            // accountTypeLabel
            // 
            this.accountTypeLabel.AutoSize = true;
            this.accountTypeLabel.Location = new System.Drawing.Point(86, 44);
            this.accountTypeLabel.Name = "accountTypeLabel";
            this.accountTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.accountTypeLabel.TabIndex = 13;
            this.accountTypeLabel.Text = "Standard";
            // 
            // userEmailLabel
            // 
            this.userEmailLabel.AutoSize = true;
            this.userEmailLabel.Location = new System.Drawing.Point(86, 0);
            this.userEmailLabel.Name = "userEmailLabel";
            this.userEmailLabel.Size = new System.Drawing.Size(82, 13);
            this.userEmailLabel.TabIndex = 11;
            this.userEmailLabel.Text = "test@email.com";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Account Type:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Expired Date:";
            // 
            // expiredDateLabel
            // 
            this.expiredDateLabel.AutoSize = true;
            this.expiredDateLabel.Location = new System.Drawing.Point(86, 174);
            this.expiredDateLabel.Name = "expiredDateLabel";
            this.expiredDateLabel.Size = new System.Drawing.Size(65, 13);
            this.expiredDateLabel.TabIndex = 15;
            this.expiredDateLabel.Text = "08/03/2008";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "PID Counter:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "0/0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "CID Counter:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(86, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "0/0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LogoutButtonClick);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(925, 551);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MyForm";
            this.Text = "PID Microsoft";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyForm_Closed);
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.Shown += new System.EventHandler(this.MyForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView keyDataGridView;
        private System.Windows.Forms.ComboBox keyTypeComboBox;
        private System.Windows.Forms.TextBox pidOutputTextbox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox pidInputTextbox;
        private System.Windows.Forms.Label pidCheckLabel;
        private System.Windows.Forms.Button getCIDButton;
        private System.Windows.Forms.TextBox iidInputTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label cidTimeLabel;
        private System.Windows.Forms.Button copyRawCIDButton;
        private System.Windows.Forms.TextBox cidOutputTextBox;
        private System.Windows.Forms.TextBox cidCommandOutputTextbox;
        private System.Windows.Forms.ComboBox cidCommandType;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label loginStatusLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label expiredDateLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label accountTypeLabel;
        private System.Windows.Forms.Label userEmailLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox cidDashOutputTextBox;
        private System.Windows.Forms.Button cidDashCopyButton;
        private System.Windows.Forms.ComboBox threadNumComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchKeysTextbox;
        private System.Windows.Forms.CheckBox showDeadKeysCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox rememberAccountCheckbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
    }
}

