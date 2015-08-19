using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace Every {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private GitManager gitManager;
        private EventManager eventManager;

        public MainWindow() {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PathText.Text = dialog.FileName;
            }
        }

        private void PathText_TextChanged(object sender, TextChangedEventArgs e) {
            StartButton.IsEnabled = File.Exists(PathText.Text);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) {
            string filename = PathText.Text;
            if (filename == string.Empty) {
                MessageBox.Show("No file selected", "No file selected", MessageBoxButton.OK, MessageBoxImage.Stop);
            } else {
                gitManager = new GitManager(filename);
                eventManager = new EventManager(filename);
            }
        }
    }
}
