namespace Lab3_OOP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox listBoxVehicles;
        private System.Windows.Forms.PropertyGrid propertyGridVehicle;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ComboBox comboBoxVehicleTypes;
        private System.Windows.Forms.Label labelVehicleTypes;

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
            this.listBoxVehicles = new System.Windows.Forms.ListBox();
            this.propertyGridVehicle = new System.Windows.Forms.PropertyGrid();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.comboBoxVehicleTypes = new System.Windows.Forms.ComboBox();
            this.labelVehicleTypes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxVehicles
            // 
            this.listBoxVehicles.FormattingEnabled = true;
            this.listBoxVehicles.ItemHeight = 15;
            this.listBoxVehicles.Location = new System.Drawing.Point(12, 12);
            this.listBoxVehicles.Name = "listBoxVehicles";
            this.listBoxVehicles.Size = new System.Drawing.Size(260, 424);
            this.listBoxVehicles.TabIndex = 0;
            this.listBoxVehicles.SelectedIndexChanged += new System.EventHandler(this.listBoxVehicles_SelectedIndexChanged);
            // 
            // propertyGridVehicle
            // 
            this.propertyGridVehicle.Location = new System.Drawing.Point(278, 12);
            this.propertyGridVehicle.Name = "propertyGridVehicle";
            this.propertyGridVehicle.Size = new System.Drawing.Size(310, 424);
            this.propertyGridVehicle.TabIndex = 1;
            // 
            // comboBoxVehicleTypes
            // 
            this.comboBoxVehicleTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVehicleTypes.FormattingEnabled = true;
            this.comboBoxVehicleTypes.Location = new System.Drawing.Point(594, 32);
            this.comboBoxVehicleTypes.Name = "comboBoxVehicleTypes";
            this.comboBoxVehicleTypes.Size = new System.Drawing.Size(194, 23);
            this.comboBoxVehicleTypes.TabIndex = 2;
            // 
            // labelVehicleTypes
            // 
            this.labelVehicleTypes.AutoSize = true;
            this.labelVehicleTypes.Location = new System.Drawing.Point(594, 12);
            this.labelVehicleTypes.Name = "labelVehicleTypes";
            this.labelVehicleTypes.Size = new System.Drawing.Size(130, 15);
            this.labelVehicleTypes.TabIndex = 3;
            this.labelVehicleTypes.Text = "Vehicle type to create:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(594, 70);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(194, 30);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add vehicle";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(594, 106);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(194, 30);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "Remove selected";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(594, 176);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(194, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Serialize to file";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(594, 212);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(194, 30);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Text = "Deserialize from file";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelVehicleTypes);
            this.Controls.Add(this.comboBoxVehicleTypes);
            this.Controls.Add(this.propertyGridVehicle);
            this.Controls.Add(this.listBoxVehicles);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle binary serialization demo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
