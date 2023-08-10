using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfTodoList.Models;

namespace WpfTodoList.ViewModels {
  public class TodoViewModel : INotifyPropertyChanged {
    public ObservableCollection<TodoItem> TodoItems { get; } = new ObservableCollection<TodoItem>();

    private string newTask;
    public string NewTask {
      get { return newTask; }
      set
      {
        newTask = value;
        OnPropertyChanged(nameof(NewTask));
      }
    }

    public ICommand AddTaskCommand { get; }
    public ICommand CompleteTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }

    public TodoViewModel() {
      AddTaskCommand = new RelayCommand(AddTask);
      CompleteTaskCommand = new RelayCommand<object?>(CompleteTask);
      DeleteTaskCommand = new RelayCommand<object?>(DeleteTask);
    }
    
    private void AddTask() {
      if (!string.IsNullOrWhiteSpace(NewTask))
      {
        TodoItems.Add(new TodoItem { Title = NewTask });
        NewTask = string.Empty;
      }
    }

    private void CompleteTask(object? taskObj) {
      if (taskObj is TodoItem task)
      {
        task.IsCompleted = true;
      }
    }

    private void DeleteTask(object? taskObj) {
      if (taskObj is TodoItem task)
      {
        TodoItems.Remove(task);
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
