using System.Windows.Forms;

namespace Destiny2LoneWolf.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            Topmost = true;
            Left = Screen.PrimaryScreen.Bounds.Width - Width;
            Top = 0;
        }
    }
}
