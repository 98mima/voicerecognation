namespace Voice_Recognition
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Enable = new System.Windows.Forms.Button();
            this.Disable = new System.Windows.Forms.Button();
            this.textConsole = new System.Windows.Forms.TextBox();
            this.timerSpeech = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Enable
            // 
            this.Enable.BackColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.Enable, "Enable");
            this.Enable.Name = "Enable";
            this.Enable.UseVisualStyleBackColor = false;
            this.Enable.Click += new System.EventHandler(this.Enable_Click);
            // 
            // Disable
            // 
            this.Disable.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.Disable, "Disable");
            this.Disable.ForeColor = System.Drawing.Color.Black;
            this.Disable.Name = "Disable";
            this.Disable.UseVisualStyleBackColor = false;
            this.Disable.Click += new System.EventHandler(this.Disable_Click);
            // 
            // textConsole
            // 
            resources.ApplyResources(this.textConsole, "textConsole");
            this.textConsole.Name = "textConsole";
            this.textConsole.TextChanged += new System.EventHandler(this.textConsole_TextChanged);
            // 
            // timerSpeech
            // 
            this.timerSpeech.Tick += new System.EventHandler(this.timerSpeech_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textConsole);
            this.Controls.Add(this.Disable);
            this.Controls.Add(this.Enable);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Enable;
        private System.Windows.Forms.Button Disable;
        private System.Windows.Forms.TextBox textConsole;
        private System.Windows.Forms.Timer timerSpeech;
        private System.Windows.Forms.Label label1;
    }
}

