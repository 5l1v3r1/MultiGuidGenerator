using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace MultiGuidGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NumberOfGuidsTextBoxValidating(object sender, CancelEventArgs e)
        {
            int number;
            bool result = int.TryParse(NumberOfGuidsTextBox.Text, out number);

            if (!result)
            {
                e.Cancel = true;
            }
        }

        private void GenerateButtonClick(object sender, EventArgs e)
        {
            int number;
            bool result = int.TryParse(NumberOfGuidsTextBox.Text, out number);

            if (!result)
            {
                MessageBox.Show("Invalid number specified");
                return;
            }

            OutputTextBox.Clear();

            var sb = new StringBuilder();
            for (int i=0;i<number;i++)
            {
                var x = Guid.NewGuid();
                var guid = IncludeDashesCheckBox.Checked ? x.ToString() : x.ToString().Replace("-", "");

                sb.Append(guid);
                sb.Append("\r\n");
            }

            OutputTextBox.Text = sb.ToString();
        }
    }
}
