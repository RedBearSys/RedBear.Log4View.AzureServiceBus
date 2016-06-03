using System;
using System.Windows.Forms;
using Prosa.Log4View.Configuration;
using Prosa.Log4View.Properties;
using Prosa.Log4View.Receiver;

namespace RedBear.Log4View.AzureServiceBus {
    internal partial class AzureConfigControl : UserControl, IReceiverControl
    {
        private readonly AzureReceiverConfig _receiverConfig;
        private readonly IReceiverForm _receiverForm;
        private bool _resized;

        public AzureConfigControl(AzureReceiverConfig config, IReceiverForm receiverForm)
        {
            InitializeComponent();

            _receiverConfig = config;
            _receiverForm = receiverForm;
        }

        public ReceiverConfig ReceiverConfig => _receiverConfig;

        private void AzureConfigControlLoad(object sender, EventArgs e) {
            txtTopic.Text = _receiverConfig.Topic;
            txtPrefix.Text = _receiverConfig.Prefix;
            txtConnString.Text = _receiverConfig.ConnectionString;

            helpProvider.HelpNamespace = Resources.HelpPath;
            IsModified = false;
        }

        public void WriteConfiguration() {
            _receiverConfig.Topic = txtTopic.Text;
            _receiverConfig.Prefix = txtPrefix.Text;
            _receiverConfig.ConnectionString = txtConnString.Text;

            if (!string.IsNullOrEmpty(_receiverConfig.Prefix) && !_receiverConfig.Prefix.EndsWith("."))
            {
                _receiverConfig.Prefix += ".";
            }
        }

        public bool ReadFilterEnabled => false;

        public bool IsModified { get; private set; }

        public bool IsValid
        {
            get
            {
                var result = true;
                var value = txtTopic.Text.Replace("\\", "/");

                if (value.Length == 0)
                {
                    result = false;
                }
                else if (value.Length > 260)
                {
                    result = false;
                }
                else if (value.StartsWith("/") || value.EndsWith("/"))
                {
                    result = false;
                }
                else if (value.Contains("?") || value.Contains("#") || value.Contains("@"))
                {
                    result = false;
                }

                if (txtConnString.Text.Length == 0)
                {
                    result = false;
                }

                return result;
            }
        }

        public void UpdateControls(bool calledFromReceiverForm = false)
        {
           if (!calledFromReceiverForm)
              _receiverForm.UpdateControls();
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            IsModified = true;
            UpdateControls();
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e)
        {
            IsModified = true;
            UpdateControls();
        }

        private void txtConnString_TextChanged(object sender, EventArgs e)
        {
            IsModified = true;
            UpdateControls();
        }

        private void AzureConfigControl_Paint(object sender, PaintEventArgs e)
        {
            if (!_resized && Form.ActiveForm != null)
            {
                _resized = true;
                Form.ActiveForm.Height += 110;
            }
        }
    }
}
