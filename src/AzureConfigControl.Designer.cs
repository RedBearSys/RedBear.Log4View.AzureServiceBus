namespace RedBear.Log4View.AzureServiceBus {
    internal partial class AzureConfigControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AzureConfigControl));
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.lblTopic = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTopic
            // 
            this.helpProvider.SetHelpString(this.txtTopic, resources.GetString("txtTopic.HelpString"));
            resources.ApplyResources(this.txtTopic, "txtTopic");
            this.txtTopic.Name = "txtTopic";
            this.helpProvider.SetShowHelp(this.txtTopic, ((bool)(resources.GetObject("txtTopic.ShowHelp"))));
            this.txtTopic.TextChanged += new System.EventHandler(this.txtTopic_TextChanged);
            // 
            // txtPrefix
            // 
            this.helpProvider.SetHelpString(this.txtPrefix, resources.GetString("txtPrefix.HelpString"));
            resources.ApplyResources(this.txtPrefix, "txtPrefix");
            this.txtPrefix.Name = "txtPrefix";
            this.helpProvider.SetShowHelp(this.txtPrefix, ((bool)(resources.GetObject("txtPrefix.ShowHelp"))));
            this.txtPrefix.TextChanged += new System.EventHandler(this.txtPrefix_TextChanged);
            // 
            // txtConnString
            // 
            this.helpProvider.SetHelpString(this.txtConnString, resources.GetString("txtConnString.HelpString"));
            resources.ApplyResources(this.txtConnString, "txtConnString");
            this.txtConnString.Name = "txtConnString";
            this.helpProvider.SetShowHelp(this.txtConnString, ((bool)(resources.GetObject("txtConnString.ShowHelp"))));
            this.txtConnString.TextChanged += new System.EventHandler(this.txtConnString_TextChanged);
            // 
            // lblTopic
            // 
            resources.ApplyResources(this.lblTopic, "lblTopic");
            this.lblTopic.Name = "lblTopic";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // AzureConfigControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.txtTopic);
            this.Name = "AzureConfigControl";
            this.helpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.AzureConfigControlLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AzureConfigControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label5;
    }
}
