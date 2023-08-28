using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    static class ToDoLogic
    {

        public static void Saving(ObservableCollection<Case> tasks)
        {
            using (FileStream fileStream = new FileStream("data.json", FileMode.Create))
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };
                JsonSerializer.SerializeAsync(fileStream, tasks, options);
            }
        }

        public static void Loading(ObservableCollection<Case> tasks)
        {
            if (File.Exists("data.json"))
            {
                using (FileStream fileStream = new FileStream("data.json", FileMode.Open))
                {
                    ObservableCollection<Case> deserializedTasks = JsonSerializer.Deserialize<ObservableCollection<Case>>(fileStream);

                    tasks.Clear();
                    foreach (var task in deserializedTasks)
                    {
                        tasks.Add(task);
                    }

                }

            }
        }

        public static void Sort(ObservableCollection<Case> tasks)
        {
            var sortedTasks = from task in tasks
                              orderby task.IsDone
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
