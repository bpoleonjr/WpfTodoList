using System.ComponentModel;

namespace WpfTodoList.Models {
  public class TodoItem : INotifyPropertyChanged {
    public required string Title { get; set; }
    private bool isCompleted;
    public bool IsCompleted {
      get { return isCompleted; }
      set {
        isCompleted = value;
        OnPropertyChanged(nameof(IsCompleted));
      }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
