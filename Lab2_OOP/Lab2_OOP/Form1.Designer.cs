namespace Lab2_OOP
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ComboBox figureTypeComboBox;
        private Button addFigureButton;

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
            figureTypeComboBox = new ComboBox();
            addFigureButton = new Button();
            SuspendLayout();
            // 
            // figureTypeComboBox
            // 
            figureTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            figureTypeComboBox.FormattingEnabled = true;
            figureTypeComboBox.Location = new Point(12, 12);
            figureTypeComboBox.Name = "figureTypeComboBox";
            figureTypeComboBox.Size = new Size(200, 33);
            figureTypeComboBox.TabIndex = 0;
            // 
            // addFigureButton
            // 
            addFigureButton.Location = new Point(230, 12);
            addFigureButton.Name = "addFigureButton";
            addFigureButton.Size = new Size(150, 33);
            addFigureButton.TabIndex = 1;
            addFigureButton.Text = "Add figure";
            addFigureButton.UseVisualStyleBackColor = true;
            addFigureButton.Click += addFigureButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addFigureButton);
            Controls.Add(figureTypeComboBox);
            DoubleBuffered = true;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Lab2_OOP - Graphic editor";
            ResumeLayout(false);
        }

        #endregion
    }
}

