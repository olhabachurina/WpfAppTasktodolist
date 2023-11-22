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
using System.Windows.Shapes;

namespace WpfAppTasktodolist
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public string TaskTitle { get; private set; }
        public bool IsTaskCompleted { get; private set; }
        public AddTaskWindow()
        {
            InitializeComponent();
            
        }

        private void CompletedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            IsTaskCompleted = false;
        }

        private void CompletedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            IsTaskCompleted = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TaskTitle = taskTitleTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
    

