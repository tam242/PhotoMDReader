namespace PhotoOrganizer
{
    partial class Dashboard
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
            this.foundPhotosLb = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.photosListView = new System.Windows.Forms.ListView();
            this.photoView = new System.Windows.Forms.PictureBox();
            this.peopleTextBox = new System.Windows.Forms.TextBox();
            this.addPeopleBtn = new System.Windows.Forms.Button();
            this.sortListView = new System.Windows.Forms.Button();
            this.LFPeopleTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LFLocTB = new System.Windows.Forms.TextBox();
            this.LFDateBTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LFDateATB = new System.Windows.Forms.TextBox();
            this.exportDbAsXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photoView)).BeginInit();
            this.SuspendLayout();
            // 
            // foundPhotosLb
            // 
            this.foundPhotosLb.FormattingEnabled = true;
            this.foundPhotosLb.ItemHeight = 15;
            this.foundPhotosLb.Location = new System.Drawing.Point(649, 502);
            this.foundPhotosLb.Name = "foundPhotosLb";
            this.foundPhotosLb.Size = new System.Drawing.Size(374, 64);
            this.foundPhotosLb.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(1029, 498);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(95, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Upload images";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // photosListView
            // 
            this.photosListView.HideSelection = false;
            this.photosListView.Location = new System.Drawing.Point(12, 12);
            this.photosListView.Name = "photosListView";
            this.photosListView.Size = new System.Drawing.Size(230, 579);
            this.photosListView.TabIndex = 3;
            this.photosListView.UseCompatibleStateImageBehavior = false;
            this.photosListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.photosListView_ItemSelectionChanged);
            // 
            // photoView
            // 
            this.photoView.Location = new System.Drawing.Point(258, 12);
            this.photoView.Name = "photoView";
            this.photoView.Size = new System.Drawing.Size(848, 480);
            this.photoView.TabIndex = 4;
            this.photoView.TabStop = false;
            // 
            // peopleTextBox
            // 
            this.peopleTextBox.Location = new System.Drawing.Point(649, 574);
            this.peopleTextBox.Name = "peopleTextBox";
            this.peopleTextBox.Size = new System.Drawing.Size(374, 23);
            this.peopleTextBox.TabIndex = 5;
            // 
            // addPeopleBtn
            // 
            this.addPeopleBtn.Location = new System.Drawing.Point(1029, 574);
            this.addPeopleBtn.Name = "addPeopleBtn";
            this.addPeopleBtn.Size = new System.Drawing.Size(95, 23);
            this.addPeopleBtn.TabIndex = 6;
            this.addPeopleBtn.Text = "Add People";
            this.addPeopleBtn.UseVisualStyleBackColor = true;
            this.addPeopleBtn.Click += new System.EventHandler(this.addPeopleBtn_Click);
            // 
            // sortListView
            // 
            this.sortListView.Location = new System.Drawing.Point(548, 573);
            this.sortListView.Name = "sortListView";
            this.sortListView.Size = new System.Drawing.Size(95, 23);
            this.sortListView.TabIndex = 7;
            this.sortListView.Text = "Search";
            this.sortListView.UseVisualStyleBackColor = true;
            this.sortListView.Click += new System.EventHandler(this.sortListView_Click);
            // 
            // LFPeopleTB
            // 
            this.LFPeopleTB.Location = new System.Drawing.Point(307, 573);
            this.LFPeopleTB.Name = "LFPeopleTB";
            this.LFPeopleTB.Size = new System.Drawing.Size(232, 23);
            this.LFPeopleTB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date";
            // 
            // LFLocTB
            // 
            this.LFLocTB.Location = new System.Drawing.Point(317, 538);
            this.LFLocTB.Name = "LFLocTB";
            this.LFLocTB.Size = new System.Drawing.Size(222, 23);
            this.LFLocTB.TabIndex = 12;
            // 
            // LFDateBTB
            // 
            this.LFDateBTB.Location = new System.Drawing.Point(307, 502);
            this.LFDateBTB.Name = "LFDateBTB";
            this.LFDateBTB.Size = new System.Drawing.Size(105, 23);
            this.LFDateBTB.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 506);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "-";
            // 
            // LFDateATB
            // 
            this.LFDateATB.Location = new System.Drawing.Point(436, 502);
            this.LFDateATB.Name = "LFDateATB";
            this.LFDateATB.Size = new System.Drawing.Size(103, 23);
            this.LFDateATB.TabIndex = 15;
            // 
            // exportDbAsXml
            // 
            this.exportDbAsXml.Location = new System.Drawing.Point(548, 502);
            this.exportDbAsXml.Name = "exportDbAsXml";
            this.exportDbAsXml.Size = new System.Drawing.Size(95, 23);
            this.exportDbAsXml.TabIndex = 16;
            this.exportDbAsXml.Text = "Export Xml";
            this.exportDbAsXml.UseVisualStyleBackColor = true;
            this.exportDbAsXml.Click += new System.EventHandler(this.exportDbAsXml_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 609);
            this.Controls.Add(this.exportDbAsXml);
            this.Controls.Add(this.LFDateATB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LFDateBTB);
            this.Controls.Add(this.LFLocTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LFPeopleTB);
            this.Controls.Add(this.sortListView);
            this.Controls.Add(this.addPeopleBtn);
            this.Controls.Add(this.peopleTextBox);
            this.Controls.Add(this.photoView);
            this.Controls.Add(this.photosListView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.foundPhotosLb);
            this.MinimumSize = new System.Drawing.Size(1152, 648);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.photoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox foundPhotosLb;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListView photosListView;
        private System.Windows.Forms.PictureBox photoView;
        private System.Windows.Forms.TextBox peopleTextBox;
        private System.Windows.Forms.Button addPeopleBtn;
        private System.Windows.Forms.Button sortListView;
        private System.Windows.Forms.TextBox LFPeopleTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LFLocTB;
        private System.Windows.Forms.TextBox LFDateBTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LFDateATB;
        private System.Windows.Forms.Button exportDbAsXml;
    }
}
