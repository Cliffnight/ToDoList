using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    static class ToDoLogic
    {
        public static void Sort(ObservableCollection<Case> tasks)
        {
            var sortedTasks = tasks.OrderByDescending(task => task.IsDone).ToList();
            tasks.Clear();
            sortedTasks.ForEach(task => tasks.Add(task));
        }
    }
}
