using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

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
        
        public string Name 
        { 
            get { return name; } 
            set 
            { 
                if(value != null)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
                
                else
                {
                    name = "Новая запись";
                    OnPropertyChanged(nameof(Name));
                }
            } 
        }
        public string Content 
        { 
            get { return content; }

            set
            {
                if (value != null)
                {
                    content = value;
                }
                else
                {
                    name = "Введите текст...";
                }
            }
        }

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
