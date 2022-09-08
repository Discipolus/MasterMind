namespace MasterMind
{
    partial class form_MasterMind
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
            this.gB_Spiel = new System.Windows.Forms.GroupBox();
            this.gB_hints = new System.Windows.Forms.GroupBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gB_Spiel
            // 
            this.gB_Spiel.Location = new System.Drawing.Point(10, 10);
            this.gB_Spiel.Name = "gB_Spiel";
            this.gB_Spiel.Size = new System.Drawing.Size(135, 380);
            this.gB_Spiel.TabIndex = 4;
            this.gB_Spiel.TabStop = false;
            this.gB_Spiel.Text = "Spiel";
            // 
            // gB_hints
            // 
            this.gB_hints.Location = new System.Drawing.Point(151, 10);
            this.gB_hints.Name = "gB_hints";
            this.gB_hints.Size = new System.Drawing.Size(60, 380);
            this.gB_hints.TabIndex = 7;
            this.gB_hints.TabStop = false;
            this.gB_hints.Text = "Hints";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(136, 396);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 23);
            this.btn_check.TabIndex = 8;
            this.btn_check.Text = "check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // form_MasterMind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 428);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.gB_hints);
            this.Controls.Add(this.gB_Spiel);
            this.Name = "form_MasterMind";
            this.Text = "MasterMind v1.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_Spiel;
        private System.Windows.Forms.GroupBox gB_hints;
        private System.Windows.Forms.Button btn_check;
    }
}

