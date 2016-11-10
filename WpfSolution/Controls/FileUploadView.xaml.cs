using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSolution.Controls
{
    /// <summary>
    /// Interaction logic for FileUploadView.xaml
    /// </summary>
    public partial class FileUploadView : UserControl
    {
        public FileUploadView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Excel | *.xlsx";
            if(dlg.ShowDialog().Value)
            {
                tbFilePath.Text = dlg.FileName;

                var binding = tbFilePath.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }
    }
}
