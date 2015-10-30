using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Every {
    public partial class MainWindow : Window {
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
            eventManager = new EventManager(PathText.Text);
            StartButton.IsEnabled = false;
            StartButton.Content = "Watching...";
        }
    }
}
