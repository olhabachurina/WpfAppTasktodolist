using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfAppTasktodolist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private List<Task> tasks;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTasks();
            tasksListBox.ItemsSource = tasks;
        }

        private void InitializeTasks()
        {
            tasks = new List<Task>
            {
                new Task { Title = "Задача 1.Сделать все домашние задания до 26.11.2023", IsCompleted = false },
                new Task { Title = "Задача 2.Ознакомится с конспектом", IsCompleted = true },
                new Task { Title = "Задача 3.Подготовить проект до 30.11.2023", IsCompleted = false }
            };
        }

        private void TasksListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tasksListBox.SelectedItem is Task selectedTask)
            {
                taskCompletedIcon.Visibility = selectedTask.IsCompleted ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new AddTaskWindow();
            if (addTaskWindow.ShowDialog() == true)
            {
                tasks.Add(new Task { Title = addTaskWindow.TaskTitle, IsCompleted = addTaskWindow.IsTaskCompleted });
                tasksListBox.ItemsSource = null;
                tasksListBox.ItemsSource = tasks;
            }
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (tasksListBox.SelectedItem is Task selectedTask)
            {
                selectedTask.IsCompleted = !selectedTask.IsCompleted;
                taskCompletedIcon.Visibility = selectedTask.IsCompleted ? Visibility.Visible : Visibility.Collapsed;

            }
        }
        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (tasksListBox.SelectedItem is Task selectedTask)
            {
                tasks.Remove(selectedTask);
                tasksListBox.ItemsSource = null;
                tasksListBox.ItemsSource = tasks;

            }
        }
    }
}

