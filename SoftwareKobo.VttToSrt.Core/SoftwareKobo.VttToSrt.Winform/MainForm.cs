using System;
using System.IO;
using System.Windows.Forms;

namespace SoftwareKobo.VttToSrt.Winform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var vtt = File.ReadAllText(ofd.FileName);
                    var srt = Core.VttToSrt.Convert(vtt);
                    using (var sfd = new SaveFileDialog())
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(sfd.FileName, srt);
                            MessageBox.Show("finish");
                        }
                    }
                }
            }
        }
    }
}