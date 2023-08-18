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
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Case> tasks = new ObservableCollection<Case>();
        public MainWindow()
        {
            InitializeComponent();

            SaveLoad.Loading(tasks);

            todoListBox.ItemsSource = tasks;
            todoListBox.DisplayMemberPath = "Name";

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Case newCase = new Case("Новая запись", "Введите текст...");

            tasks.Add(newCase);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (todoListBox.SelectedIndex != -1)
            {
                tasks.RemoveAt(todoListBox.SelectedIndex);
            }
        }


        private void todoListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            contentBox.Text = tasks[todoListBox.SelectedIndex].Content;
            taskNameTextBox.Text = tasks[todoListBox.SelectedIndex].Name;

            if (tasks[todoListBox.SelectedIndex].IsDone)
            {
                isDoneCheckBox.IsChecked = true;
            }
            else
            {
                isDoneCheckBox.IsChecked = false;
            }
  
        }

        private void isDoneCheckBox_Checked(object sender, RoutedEventArgs e)
        {
           tasks[todoListBox.SelectedIndex].IsDone = true;
        }

        private void isDoneCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
           tasks[todoListBox.SelectedIndex].IsDone = false;
        }

        private void taskNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tasks[todoListBox.SelectedIndex].Name = taskNameTextBox.Text;
        }

        private void contentBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tasks[todoListBox.SelectedIndex].Content = contentBox.Text;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveLoad.Saving(tasks);
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoLogic.Sort(tasks);
        }

    }
}
