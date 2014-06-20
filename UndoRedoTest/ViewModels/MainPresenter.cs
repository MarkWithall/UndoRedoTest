using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UndoRedoTest.Models.Actions;
using UndoRedoTest.Models.UndoRedo;
using UndoRedoTest.ViewModels.Framework;

namespace UndoRedoTest.ViewModels
{
    public class MainPresenter : ObservableObject
    {
        private readonly UndoRedoStack _undoRedoStack = new UndoRedoStack();
        private readonly ObservableCollection<string> _strings = new ObservableCollection<string>();
        private string _aString;

        public string AString
        {
            get { return _aString; }
            set
            {
                _aString = value;
                RaisePropertyChanged("AString");
            }
        }

        public IEnumerable<string> Strings
        {
            get { return _strings; }
        }

        public ICommand AddStringCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _undoRedoStack.Do(new AddToListAction<string>(AString, _strings));
                    AString = String.Empty;
                });
            }
        }

        public ICommand DoManyThingsCommand
        {
            get
            {
                return new DelegateCommand(() => _undoRedoStack.Do(
                    new ActionBlock(
                        new AddToListAction<string>("ONE", _strings),
                        new AddToListAction<string>("TWO", _strings),
                        new AddToListAction<string>("THREE", _strings))));
            }
        }

        public ICommand NewCommand
        {
            get { return new DelegateCommand(() => _undoRedoStack.Do(new ClearListAction<string>(_strings))); }
        }

        public static ICommand ExitCommand
        {
            get { return new DelegateCommand(Application.Current.Shutdown); }
        }

        public ICommand UndoCommand
        {
            get { return new DelegateCommand(_undoRedoStack.Undo); }
        }

        public ICommand RedoCommand
        {
            get { return new DelegateCommand(_undoRedoStack.Redo); }
        }
    }
}
