using System.Windows.Forms;

namespace SetACLs.Business
{
    public class FormManipulator
    {
        public DialogResult ShowWarning(string message)
        {
            return MessageBox.Show(message,
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        public void ShowInformation(string message)
        {
            MessageBox.Show(message, @"Done", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, @"Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, @"Done", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
