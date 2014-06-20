using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UndoRedoTest.Models.UndoRedo
{
    public interface UndoableAction
    {
        void Do();
        void Undo();
    }
}