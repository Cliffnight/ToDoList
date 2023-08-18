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

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Case> tasks = new ObservableCollection<Case>();
        public MainWindow()
        {
            InitializeComponent();

            Case newCase = new Case("Новая запись...", "Введите текст...");

            tasks.Add(newCase);

            todoListBox.ItemsSource = tasks;
            todoListBox.DisplayMemberPath = "Name";


        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Case newCase = new Case(taskTextBox.Text, contentBox.Text);

            if (!string.IsNullOrWhiteSpace(newCase.Name))
            {
                tasks.Add(newCase);
                taskTextBox.Clear();
            }
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
            taskTextBox.Text = tasks[todoListBox.SelectedIndex].Name;

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


    }
}
