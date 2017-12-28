namespace Survey.DBTool
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
            this.cmdUpdateSchema = new System.Windows.Forms.Button();
            this.cmdCreateDefaultData = new System.Windows.Forms.Button();
            this.cmdSampleData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdUpdateSchema
            // 
            this.cmdUpdateSchema.Location = new System.Drawing.Point(23, 21);
            this.cmdUpdateSchema.Name = "cmdUpdateSchema";
            this.cmdUpdateSchema.Size = new System.Drawing.Size(135, 46);
            this.cmdUpdateSchema.TabIndex = 0;
            this.cmdUpdateSchema.Text = "Update Schema";
            this.cmdUpdateSchema.UseVisualStyleBackColor = true;
            this.cmdUpdateSchema.Click += new System.EventHandler(this.cmdUpdateSchema_Click);
            // 
            // cmdCreateDefaultData
            // 
            this.cmdCreateDefaultData.Location = new System.Drawing.Point(23, 101);
            this.cmdCreateDefaultData.Name = "cmdCreateDefaultData";
            this.cmdCreateDefaultData.Size = new System.Drawing.Size(135, 46);
            this.cmdCreateDefaultData.TabIndex = 1;
            this.cmdCreateDefaultData.Text = "Create Default Data";
            this.cmdCreateDefaultData.UseVisualStyleBackColor = true;
            this.cmdCreateDefaultData.Click += new System.EventHandler(this.cmdCreateDefaultData_Click);
            // 
            // cmdSampleData
            // 
            this.cmdSampleData.Location = new System.Drawing.Point(23, 176);
            this.cmdSampleData.Name = "cmdSampleData";
            this.cmdSampleData.Size = new System.Drawing.Size(135, 46);
            this.cmdSampleData.TabIndex = 2;
            this.cmdSampleData.Text = "Sample Data";
            this.cmdSampleData.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmdSampleData);
            this.Controls.Add(this.cmdCreateDefaultData);
            this.Controls.Add(this.cmdUpdateSchema);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdUpdateSchema;
        private System.Windows.Forms.Button cmdCreateDefaultData;
        private System.Windows.Forms.Button cmdSampleData;
    }
}

