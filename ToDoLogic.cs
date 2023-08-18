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
            var sortedTasks = from task in tasks
                              orderby task.IsDone descending
                              select task;

            List<Case> sortedList = sortedTasks.ToList();

            tasks.Clear();

            foreach (var task in sortedList)
            {
                tasks.Add(task);
            }
        }
    }
}
