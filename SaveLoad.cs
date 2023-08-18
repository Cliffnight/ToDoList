using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    static class SaveLoad
    {
        public static void Saving(ObservableCollection<Case> tasks)
        {
            using (FileStream fileStream = new FileStream("data.json", FileMode.Create))
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };
                JsonSerializer.SerializeAsync(fileStream, tasks, options);
            }
        }

    }
}
