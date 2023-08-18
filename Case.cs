using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ToDoList
{
    internal class Case : INotifyPropertyChanged
    {
        string name {  get; set; }

        string content { get; set; }

        bool isDone { get; set; }

        public Case(string name, string content)
        {
            this.name = name;
            this.content = content;
            this.isDone = false;
        }
        
        public string Name { get { return name; } }
        public string Content { get { return content; } }

        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (value != isDone)
                {
                    isDone = value;
                    OnPropertyChanged(nameof(IsDone));
                }
            }
        }

        // Обновление 
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
