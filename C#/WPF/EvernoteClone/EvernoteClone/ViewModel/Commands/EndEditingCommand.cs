using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class EndEditingCommand : ICommand
    {
        public EndEditingCommand(NotesViewModel notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public NotesViewModel NotesViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            if (notebook != null)
            {
                NotesViewModel.StopEditing(notebook);
            }
        }
    }
}
