namespace DirectSelling
{
    partial class OrderForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.printOrder = new System.Drawing.Printing.PrintDocument();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblOrdId = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tbOrdInfo = new System.Windows.Forms.TextBox();
            this.gbNewOrdInfo = new System.Windows.Forms.GroupBox();
            this.btnCashBack = new System.Windows.Forms.Button();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbOrdQty = new System.Windows.Forms.TextBox();
            this.tbOrdSize = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnClr = new System.Windows.Forms.Button();
            this.btnAddOrd = new System.Windows.Forms.Button();
            this.tbOrdBrand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbOrdSrp = new System.Windows.Forms.TextBox();
            this.cbOrdCat = new System.Windows.Forms.ComboBox();
            this.tbOrdName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbOrdPage = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOrdComp = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cbOrdMonth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblOrdDate = new System.Windows.Forms.Label();
            this.tbOrdTot = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbOrdId = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.paneReceipt = new System.Windows.Forms.Panel();
            this.btnOrdDel = new System.Windows.Forms.Button();
            this.lblOrdItem = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.lblOrdCusID = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.btnOrdCon = new System.Windows.Forms.Button();
            this.gVOrdRec = new System.Windows.Forms.DataGridView();
            this.colOrdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrdTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOrdTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbNewOrdInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.paneReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVOrdRec)).BeginInit();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            // 
            // lblOrdId
            // 
            this.lblOrdId.AutoSize = true;
            this.lblOrdId.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblOrdId.Location = new System.Drawing.Point(87, 48);
            this.lblOrdId.Name = "lblOrdId";
            this.lblOrdId.Size = new System.Drawing.Size(81, 16);
            this.lblOrdId.TabIndex = 88;
            this.lblOrdId.Text = "00-0000-000";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.Gray;
            this.label59.Location = new System.Drawing.Point(21, 48);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(60, 16);
            this.label59.TabIndex = 87;
            this.label59.Text = "Order ID:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Red;
            this.label56.Location = new System.Drawing.Point(286, 322);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(18, 16);
            this.label56.TabIndex = 86;
            this.label56.Text = "%";
            // 
            // tbOrdInfo
            // 
            this.tbOrdInfo.BackColor = System.Drawing.Color.Black;
            this.tbOrdInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdInfo.ForeColor = System.Drawing.Color.White;
            this.tbOrdInfo.Location = new System.Drawing.Point(111, 248);
            this.tbOrdInfo.Name = "tbOrdInfo";
            this.tbOrdInfo.Size = new System.Drawing.Size(193, 27);
            this.tbOrdInfo.TabIndex = 6;
            this.tbOrdInfo.Leave += new System.EventHandler(this.tbOrdBrand_Leave);
            // 
            // gbNewOrdInfo
            // 
            this.gbNewOrdInfo.BackColor = System.Drawing.Color.Black;
            this.gbNewOrdInfo.Controls.Add(this.btnCashBack);
            this.gbNewOrdInfo.Controls.Add(this.lblOrdId);
            this.gbNewOrdInfo.Controls.Add(this.label59);
            this.gbNewOrdInfo.Controls.Add(this.label56);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdInfo);
            this.gbNewOrdInfo.Controls.Add(this.numRate);
            this.gbNewOrdInfo.Controls.Add(this.label35);
            this.gbNewOrdInfo.Controls.Add(this.label57);
            this.gbNewOrdInfo.Controls.Add(this.label14);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdQty);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdSize);
            this.gbNewOrdInfo.Controls.Add(this.label15);
            this.gbNewOrdInfo.Controls.Add(this.btnClr);
            this.gbNewOrdInfo.Controls.Add(this.btnAddOrd);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdBrand);
            this.gbNewOrdInfo.Controls.Add(this.label7);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdSrp);
            this.gbNewOrdInfo.Controls.Add(this.cbOrdCat);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdName);
            this.gbNewOrdInfo.Controls.Add(this.label27);
            this.gbNewOrdInfo.Controls.Add(this.label13);
            this.gbNewOrdInfo.Controls.Add(this.tbOrdPage);
            this.gbNewOrdInfo.Controls.Add(this.label25);
            this.gbNewOrdInfo.Controls.Add(this.label6);
            this.gbNewOrdInfo.Controls.Add(this.cbOrdComp);
            this.gbNewOrdInfo.Controls.Add(this.label28);
            this.gbNewOrdInfo.Controls.Add(this.cbOrdMonth);
            this.gbNewOrdInfo.Controls.Add(this.label5);
            this.gbNewOrdInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNewOrdInfo.ForeColor = System.Drawing.Color.Red;
            this.gbNewOrdInfo.Location = new System.Drawing.Point(12, 12);
            this.gbNewOrdInfo.Name = "gbNewOrdInfo";
            this.gbNewOrdInfo.Size = new System.Drawing.Size(334, 416);
            this.gbNewOrdInfo.TabIndex = 77;
            this.gbNewOrdInfo.TabStop = false;
            this.gbNewOrdInfo.Text = "Order Information:";
            // 
            // btnCashBack
            // 
            this.btnCashBack.FlatAppearance.BorderSize = 0;
            this.btnCashBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCashBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnCashBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashBack.Image = global::DirectSelling.Properties.Resources.Go_back_icon__1_;
            this.btnCashBack.Location = new System.Drawing.Point(3, 374);
            this.btnCashBack.Name = "btnCashBack";
            this.btnCashBack.Size = new System.Drawing.Size(39, 38);
            this.btnCashBack.TabIndex = 75;
            this.btnCashBack.UseVisualStyleBackColor = true;
            this.btnCashBack.Click += new System.EventHandler(this.btnCashBack_Click);
            // 
            // numRate
            // 
            this.numRate.BackColor = System.Drawing.Color.Black;
            this.numRate.ForeColor = System.Drawing.Color.White;
            this.numRate.Location = new System.Drawing.Point(244, 314);
            this.numRate.Name = "numRate";
            this.numRate.Size = new System.Drawing.Size(40, 27);
            this.numRate.TabIndex = 10;
            this.numRate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label35.Location = new System.Drawing.Point(10, 252);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(95, 18);
            this.label35.TabIndex = 77;
            this.label35.Text = "Color / Info:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label57.Location = new System.Drawing.Point(161, 317);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(84, 18);
            this.label57.TabIndex = 84;
            this.label57.Text = "Profit Rate:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(65, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 18);
            this.label14.TabIndex = 63;
            this.label14.Text = "QTY:";
            // 
            // tbOrdQty
            // 
            this.tbOrdQty.BackColor = System.Drawing.Color.Black;
            this.tbOrdQty.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdQty.ForeColor = System.Drawing.Color.White;
            this.tbOrdQty.Location = new System.Drawing.Point(111, 281);
            this.tbOrdQty.Name = "tbOrdQty";
            this.tbOrdQty.Size = new System.Drawing.Size(36, 27);
            this.tbOrdQty.TabIndex = 7;
            // 
            // tbOrdSize
            // 
            this.tbOrdSize.BackColor = System.Drawing.Color.Black;
            this.tbOrdSize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdSize.ForeColor = System.Drawing.Color.White;
            this.tbOrdSize.Location = new System.Drawing.Point(202, 281);
            this.tbOrdSize.Name = "tbOrdSize";
            this.tbOrdSize.Size = new System.Drawing.Size(102, 27);
            this.tbOrdSize.TabIndex = 8;
            this.tbOrdSize.Leave += new System.EventHandler(this.tbOrdBrand_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label15.Location = new System.Drawing.Point(48, 219);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 18);
            this.label15.TabIndex = 75;
            this.label15.Text = "Name:";
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.Black;
            this.btnClr.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnClr.FlatAppearance.BorderSize = 0;
            this.btnClr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClr.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClr.ForeColor = System.Drawing.Color.White;
            this.btnClr.Image = global::DirectSelling.Properties.Resources.Button_Refresh_icon1;
            this.btnClr.Location = new System.Drawing.Point(303, 12);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(27, 22);
            this.btnClr.TabIndex = 12;
            this.btnClr.UseVisualStyleBackColor = false;
            // 
            // btnAddOrd
            // 
            this.btnAddOrd.BackColor = System.Drawing.Color.Black;
            this.btnAddOrd.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnAddOrd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddOrd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddOrd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrd.ForeColor = System.Drawing.Color.White;
            this.btnAddOrd.Location = new System.Drawing.Point(111, 363);
            this.btnAddOrd.Name = "btnAddOrd";
            this.btnAddOrd.Size = new System.Drawing.Size(193, 29);
            this.btnAddOrd.TabIndex = 11;
            this.btnAddOrd.Text = "ADD";
            this.btnAddOrd.UseVisualStyleBackColor = false;
            this.btnAddOrd.Click += new System.EventHandler(this.btnAddOrd_Click);
            // 
            // tbOrdBrand
            // 
            this.tbOrdBrand.BackColor = System.Drawing.Color.Black;
            this.tbOrdBrand.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdBrand.ForeColor = System.Drawing.Color.White;
            this.tbOrdBrand.Location = new System.Drawing.Point(111, 182);
            this.tbOrdBrand.Name = "tbOrdBrand";
            this.tbOrdBrand.Size = new System.Drawing.Size(193, 27);
            this.tbOrdBrand.TabIndex = 4;
            this.tbOrdBrand.Leave += new System.EventHandler(this.tbOrdBrand_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(68, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 18);
            this.label7.TabIndex = 52;
            this.label7.Text = "SRP:";
            // 
            // tbOrdSrp
            // 
            this.tbOrdSrp.BackColor = System.Drawing.Color.Black;
            this.tbOrdSrp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdSrp.ForeColor = System.Drawing.Color.White;
            this.tbOrdSrp.Location = new System.Drawing.Point(111, 314);
            this.tbOrdSrp.Name = "tbOrdSrp";
            this.tbOrdSrp.Size = new System.Drawing.Size(47, 27);
            this.tbOrdSrp.TabIndex = 9;
            // 
            // cbOrdCat
            // 
            this.cbOrdCat.BackColor = System.Drawing.Color.Black;
            this.cbOrdCat.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrdCat.ForeColor = System.Drawing.Color.White;
            this.cbOrdCat.FormattingEnabled = true;
            this.cbOrdCat.Items.AddRange(new object[] {
            "Perfumes",
            "Footwares",
            "Underwares",
            "Bags & Wallets",
            "Skin & Body Care",
            "Facial Care / Makeup",
            "Shirts & Jackets",
            "Shorts & Pants / Belts",
            "Accessories & Cellphones",
            "Home & Kitchen ware",
            "Food Supplements / Medicines",
            "Others"});
            this.cbOrdCat.Location = new System.Drawing.Point(111, 119);
            this.cbOrdCat.Name = "cbOrdCat";
            this.cbOrdCat.Size = new System.Drawing.Size(193, 24);
            this.cbOrdCat.TabIndex = 1;
            this.cbOrdCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbOrdComp_KeyPress);
            // 
            // tbOrdName
            // 
            this.tbOrdName.BackColor = System.Drawing.Color.Black;
            this.tbOrdName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdName.ForeColor = System.Drawing.Color.White;
            this.tbOrdName.Location = new System.Drawing.Point(111, 215);
            this.tbOrdName.Name = "tbOrdName";
            this.tbOrdName.Size = new System.Drawing.Size(193, 27);
            this.tbOrdName.TabIndex = 5;
            this.tbOrdName.Leave += new System.EventHandler(this.tbOrdBrand_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label27.Location = new System.Drawing.Point(23, 120);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(82, 18);
            this.label27.TabIndex = 44;
            this.label27.Text = "Category:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label13.Location = new System.Drawing.Point(50, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 18);
            this.label13.TabIndex = 59;
            this.label13.Text = "Brand:";
            // 
            // tbOrdPage
            // 
            this.tbOrdPage.BackColor = System.Drawing.Color.Black;
            this.tbOrdPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdPage.ForeColor = System.Drawing.Color.White;
            this.tbOrdPage.Location = new System.Drawing.Point(262, 149);
            this.tbOrdPage.Name = "tbOrdPage";
            this.tbOrdPage.Size = new System.Drawing.Size(42, 27);
            this.tbOrdPage.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label25.Location = new System.Drawing.Point(21, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 18);
            this.label25.TabIndex = 42;
            this.label25.Text = "Distributor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(155, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 18);
            this.label6.TabIndex = 50;
            this.label6.Text = "Size:";
            // 
            // cbOrdComp
            // 
            this.cbOrdComp.BackColor = System.Drawing.Color.Black;
            this.cbOrdComp.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrdComp.ForeColor = System.Drawing.Color.White;
            this.cbOrdComp.FormattingEnabled = true;
            this.cbOrdComp.Items.AddRange(new object[] {
            "Avon",
            "Natasha",
            "MSE",
            "Personal Collections"});
            this.cbOrdComp.Location = new System.Drawing.Point(111, 89);
            this.cbOrdComp.Name = "cbOrdComp";
            this.cbOrdComp.Size = new System.Drawing.Size(193, 24);
            this.cbOrdComp.TabIndex = 0;
            this.cbOrdComp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbOrdComp_KeyPress);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label28.Location = new System.Drawing.Point(47, 150);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 18);
            this.label28.TabIndex = 46;
            this.label28.Text = "Month:";
            // 
            // cbOrdMonth
            // 
            this.cbOrdMonth.BackColor = System.Drawing.Color.Black;
            this.cbOrdMonth.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrdMonth.ForeColor = System.Drawing.Color.White;
            this.cbOrdMonth.FormattingEnabled = true;
            this.cbOrdMonth.Items.AddRange(new object[] {
            "January",
            "Febuary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbOrdMonth.Location = new System.Drawing.Point(111, 149);
            this.cbOrdMonth.Name = "cbOrdMonth";
            this.cbOrdMonth.Size = new System.Drawing.Size(98, 24);
            this.cbOrdMonth.TabIndex = 2;
            this.cbOrdMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbOrdComp_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(215, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "Page:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label24.Location = new System.Drawing.Point(36, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 18);
            this.label24.TabIndex = 63;
            this.label24.Text = "Time:";
            // 
            // lblOrdDate
            // 
            this.lblOrdDate.AutoSize = true;
            this.lblOrdDate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdDate.ForeColor = System.Drawing.Color.SlateGray;
            this.lblOrdDate.Location = new System.Drawing.Point(85, 15);
            this.lblOrdDate.Name = "lblOrdDate";
            this.lblOrdDate.Size = new System.Drawing.Size(47, 18);
            this.lblOrdDate.TabIndex = 64;
            this.lblOrdDate.Text = "Date:";
            // 
            // tbOrdTot
            // 
            this.tbOrdTot.BackColor = System.Drawing.Color.Black;
            this.tbOrdTot.Enabled = false;
            this.tbOrdTot.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdTot.ForeColor = System.Drawing.Color.White;
            this.tbOrdTot.Location = new System.Drawing.Point(440, 340);
            this.tbOrdTot.Name = "tbOrdTot";
            this.tbOrdTot.Size = new System.Drawing.Size(129, 27);
            this.tbOrdTot.TabIndex = 70;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label23.Location = new System.Drawing.Point(36, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 18);
            this.label23.TabIndex = 62;
            this.label23.Text = "Date:";
            // 
            // tbOrdId
            // 
            this.tbOrdId.BackColor = System.Drawing.Color.Black;
            this.tbOrdId.Enabled = false;
            this.tbOrdId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrdId.ForeColor = System.Drawing.Color.White;
            this.tbOrdId.Location = new System.Drawing.Point(440, 7);
            this.tbOrdId.Name = "tbOrdId";
            this.tbOrdId.Size = new System.Drawing.Size(129, 23);
            this.tbOrdId.TabIndex = 61;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.SlateGray;
            this.label22.Location = new System.Drawing.Point(335, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 16);
            this.label22.TabIndex = 60;
            this.label22.Text = "Transaction #:";
            // 
            // paneReceipt
            // 
            this.paneReceipt.BackColor = System.Drawing.Color.Black;
            this.paneReceipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneReceipt.Controls.Add(this.btnOrdDel);
            this.paneReceipt.Controls.Add(this.lblOrdItem);
            this.paneReceipt.Controls.Add(this.label58);
            this.paneReceipt.Controls.Add(this.lblOrdCusID);
            this.paneReceipt.Controls.Add(this.label37);
            this.paneReceipt.Controls.Add(this.btnOrdCon);
            this.paneReceipt.Controls.Add(this.gVOrdRec);
            this.paneReceipt.Controls.Add(this.lblOrdTime);
            this.paneReceipt.Controls.Add(this.label8);
            this.paneReceipt.Controls.Add(this.label24);
            this.paneReceipt.Controls.Add(this.lblOrdDate);
            this.paneReceipt.Controls.Add(this.tbOrdTot);
            this.paneReceipt.Controls.Add(this.label23);
            this.paneReceipt.Controls.Add(this.tbOrdId);
            this.paneReceipt.Controls.Add(this.label22);
            this.paneReceipt.Location = new System.Drawing.Point(352, 12);
            this.paneReceipt.Name = "paneReceipt";
            this.paneReceipt.Size = new System.Drawing.Size(585, 416);
            this.paneReceipt.TabIndex = 76;
            // 
            // btnOrdDel
            // 
            this.btnOrdDel.BackColor = System.Drawing.Color.Transparent;
            this.btnOrdDel.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnOrdDel.FlatAppearance.BorderSize = 0;
            this.btnOrdDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOrdDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOrdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdDel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdDel.ForeColor = System.Drawing.Color.Black;
            this.btnOrdDel.Image = global::DirectSelling.Properties.Resources.Actions_trash_empty_icon;
            this.btnOrdDel.Location = new System.Drawing.Point(3, 301);
            this.btnOrdDel.Name = "btnOrdDel";
            this.btnOrdDel.Size = new System.Drawing.Size(34, 33);
            this.btnOrdDel.TabIndex = 13;
            this.btnOrdDel.UseVisualStyleBackColor = false;
            this.btnOrdDel.Click += new System.EventHandler(this.btnOrdDel_Click);
            // 
            // lblOrdItem
            // 
            this.lblOrdItem.AutoSize = true;
            this.lblOrdItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdItem.ForeColor = System.Drawing.Color.SlateGray;
            this.lblOrdItem.Location = new System.Drawing.Point(85, 344);
            this.lblOrdItem.Name = "lblOrdItem";
            this.lblOrdItem.Size = new System.Drawing.Size(16, 18);
            this.lblOrdItem.TabIndex = 80;
            this.lblOrdItem.Text = "0";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label58.Location = new System.Drawing.Point(36, 344);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(50, 18);
            this.label58.TabIndex = 79;
            this.label58.Text = "Items:";
            // 
            // lblOrdCusID
            // 
            this.lblOrdCusID.AutoSize = true;
            this.lblOrdCusID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdCusID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblOrdCusID.Location = new System.Drawing.Point(437, 50);
            this.lblOrdCusID.Name = "lblOrdCusID";
            this.lblOrdCusID.Size = new System.Drawing.Size(64, 16);
            this.lblOrdCusID.TabIndex = 76;
            this.lblOrdCusID.Text = "00000000";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.SlateGray;
            this.label37.Location = new System.Drawing.Point(344, 50);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(90, 16);
            this.label37.TabIndex = 75;
            this.label37.Text = "Customer ID:";
            // 
            // btnOrdCon
            // 
            this.btnOrdCon.BackColor = System.Drawing.Color.Black;
            this.btnOrdCon.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnOrdCon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOrdCon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnOrdCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdCon.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdCon.ForeColor = System.Drawing.Color.White;
            this.btnOrdCon.Location = new System.Drawing.Point(39, 373);
            this.btnOrdCon.Name = "btnOrdCon";
            this.btnOrdCon.Size = new System.Drawing.Size(530, 28);
            this.btnOrdCon.TabIndex = 14;
            this.btnOrdCon.Text = "CONFIRM";
            this.btnOrdCon.UseVisualStyleBackColor = false;
            this.btnOrdCon.Click += new System.EventHandler(this.btnOrdCon_Click);
            // 
            // gVOrdRec
            // 
            this.gVOrdRec.AllowUserToAddRows = false;
            this.gVOrdRec.AllowUserToDeleteRows = false;
            this.gVOrdRec.AllowUserToResizeRows = false;
            this.gVOrdRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gVOrdRec.BackgroundColor = System.Drawing.Color.Black;
            this.gVOrdRec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVOrdRec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gVOrdRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gVOrdRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrdId,
            this.colQty,
            this.colBrand,
            this.colDes,
            this.colPrice,
            this.colOrdTot});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gVOrdRec.DefaultCellStyle = dataGridViewCellStyle2;
            this.gVOrdRec.GridColor = System.Drawing.Color.DodgerBlue;
            this.gVOrdRec.Location = new System.Drawing.Point(39, 87);
            this.gVOrdRec.Name = "gVOrdRec";
            this.gVOrdRec.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gVOrdRec.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gVOrdRec.RowHeadersVisible = false;
            this.gVOrdRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gVOrdRec.Size = new System.Drawing.Size(530, 247);
            this.gVOrdRec.TabIndex = 68;
            // 
            // colOrdId
            // 
            this.colOrdId.FillWeight = 80F;
            this.colOrdId.HeaderText = "OrdID";
            this.colOrdId.Name = "colOrdId";
            this.colOrdId.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.FillWeight = 50F;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colBrand
            // 
            this.colBrand.FillWeight = 80F;
            this.colBrand.HeaderText = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            // 
            // colDes
            // 
            this.colDes.HeaderText = "Name";
            this.colDes.Name = "colDes";
            this.colDes.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.FillWeight = 60F;
            this.colPrice.HeaderText = "SRP";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colOrdTot
            // 
            this.colOrdTot.FillWeight = 80F;
            this.colOrdTot.HeaderText = "SubTotal";
            this.colOrdTot.Name = "colOrdTot";
            this.colOrdTot.ReadOnly = true;
            // 
            // lblOrdTime
            // 
            this.lblOrdTime.AutoSize = true;
            this.lblOrdTime.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdTime.ForeColor = System.Drawing.Color.SlateGray;
            this.lblOrdTime.Location = new System.Drawing.Point(85, 48);
            this.lblOrdTime.Name = "lblOrdTime";
            this.lblOrdTime.Size = new System.Drawing.Size(46, 18);
            this.lblOrdTime.TabIndex = 65;
            this.lblOrdTime.Text = "Time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(388, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 66;
            this.label8.Text = "Total:";
            // 
            // OrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(948, 443);
            this.Controls.Add(this.gbNewOrdInfo);
            this.Controls.Add(this.paneReceipt);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.gbNewOrdInfo.ResumeLayout(false);
            this.gbNewOrdInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            this.paneReceipt.ResumeLayout(false);
            this.paneReceipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVOrdRec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrdDel;
        private System.Drawing.Printing.PrintDocument printOrder;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnCashBack;
        private System.Windows.Forms.Label lblOrdId;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox tbOrdInfo;
        public System.Windows.Forms.GroupBox gbNewOrdInfo;
        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbOrdQty;
        private System.Windows.Forms.TextBox tbOrdSize;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnAddOrd;
        private System.Windows.Forms.TextBox tbOrdBrand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbOrdSrp;
        private System.Windows.Forms.ComboBox cbOrdCat;
        private System.Windows.Forms.TextBox tbOrdName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbOrdPage;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOrdComp;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cbOrdMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblOrdDate;
        private System.Windows.Forms.TextBox tbOrdTot;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbOrdId;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Panel paneReceipt;
        private System.Windows.Forms.Label lblOrdItem;
        private System.Windows.Forms.Label label58;
        public System.Windows.Forms.Label lblOrdCusID;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnOrdCon;
        private System.Windows.Forms.DataGridView gVOrdRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdTot;
        private System.Windows.Forms.Label lblOrdTime;
        private System.Windows.Forms.Label label8;
    }
}