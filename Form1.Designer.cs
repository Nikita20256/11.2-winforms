namespace _11._2_winforms
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
            labelPlaneModel = new Label();
            listBoxPlanes = new ListBox();
            buttonSearch = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            labelDisplay = new Label();
            labelFound = new Label();
            SuspendLayout();
            // 
            // labelPlaneModel
            // 
            labelPlaneModel.AutoSize = true;
            labelPlaneModel.Location = new Point(41, 45);
            labelPlaneModel.Name = "labelPlaneModel";
            labelPlaneModel.Size = new Size(132, 20);
            labelPlaneModel.TabIndex = 0;
            labelPlaneModel.Text = "Модель самолета";
            // 
            // listBoxPlanes
            // 
            listBoxPlanes.FormattingEnabled = true;
            listBoxPlanes.Location = new Point(41, 68);
            listBoxPlanes.Name = "listBoxPlanes";
            listBoxPlanes.Size = new Size(150, 104);
            listBoxPlanes.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(41, 178);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(257, 68);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(531, 104);
            listBox1.TabIndex = 3;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(257, 235);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(531, 104);
            listBox2.TabIndex = 4;
            // 
            // labelDisplay
            // 
            labelDisplay.AutoSize = true;
            labelDisplay.Location = new Point(257, 212);
            labelDisplay.Name = "labelDisplay";
            labelDisplay.Size = new Size(54, 20);
            labelDisplay.TabIndex = 5;
            labelDisplay.Text = "Табло:";
            // 
            // labelFound
            // 
            labelFound.AutoSize = true;
            labelFound.Location = new Point(257, 45);
            labelFound.Name = "labelFound";
            labelFound.Size = new Size(141, 20);
            labelFound.TabIndex = 6;
            labelFound.Text = "Найденные рейсы:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelFound);
            Controls.Add(labelDisplay);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(buttonSearch);
            Controls.Add(listBoxPlanes);
            Controls.Add(labelPlaneModel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPlaneModel;
        private ListBox listBoxPlanes;
        private Button buttonSearch;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label labelDisplay;
        private Label labelFound;
    }
}
