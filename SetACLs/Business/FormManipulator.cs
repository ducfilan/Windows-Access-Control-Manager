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

        public void StartMarqueeProgressBar(ProgressBar progressBar)
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
        }

        public void StartMarqueeProgressBarAsync(ProgressBar progressBar)
        {
            progressBar.BeginInvoke((MethodInvoker)delegate
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 30;
            });
        }

        public void StopMarqueeProgressBar(ProgressBar progressBar)
        {
            progressBar.Style = ProgressBarStyle.Blocks;
        }

        public void StopMarqueeProgressBarAsync(ProgressBar progressBar)
        {
            progressBar.BeginInvoke((MethodInvoker)delegate
            {
                progressBar.Style = ProgressBarStyle.Blocks;
            });
        }
    }
}
