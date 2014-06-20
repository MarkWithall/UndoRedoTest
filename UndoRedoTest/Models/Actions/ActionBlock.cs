using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UndoRedoTest.Models.UndoRedo;

namespace UndoRedoTest.Models.Actions
{
    public class ActionBlock : UndoableAction
    {
        private readonly UndoableAction[] _actionSequence;

        public ActionBlock(params UndoableAction[] actionSequence)
        {
            _actionSequence = actionSequence;
        }

        public void Do()
        {
            foreach (var action in _actionSequence)
                action.Do();
        }

        public void Undo()
        {
            foreach (var action in _actionSequence.Reverse())
                action.Undo();
        }

        public override string ToString()
        {
            return String.Join(",", _actionSequence.Select(a => a.ToString()));
        }
    }
}
