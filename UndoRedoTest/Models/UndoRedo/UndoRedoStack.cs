using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UndoRedoTest.Models.UndoRedo
{
    public class UndoRedoStack
    {
        private readonly Stack<UndoableAction> _undoStack = new Stack<UndoableAction>();
        private readonly Stack<UndoableAction> _redoStack = new Stack<UndoableAction>();

        public void Do(UndoableAction action)
        {
            action.Do();
            _undoStack.Push(action);
            _redoStack.Clear();
        }

        public void Undo()
        {
            RunAction(_undoStack, _redoStack, a => a.Undo());
        }

        public void Redo()
        {
            RunAction(_redoStack, _undoStack, a => a.Do());
        }

        private static void RunAction(Stack<UndoableAction> source, Stack<UndoableAction> target, Action<UndoableAction> undoRedo)
        {
            if (source.Count == 0)
                return;
            var action = source.Pop();
            undoRedo(action);
            target.Push(action);
        }
    }
}
