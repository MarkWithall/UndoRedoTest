using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UndoRedoTest.Models.UndoRedo;

namespace UndoRedoTest.Models.Actions
{
    public class ClearListAction<T> : UndoableAction
    {
        private readonly IList<T> _list;
        private readonly IList<T> _backup;

        public ClearListAction(IList<T> list)
        {
            _list = list;
            _backup = new List<T>(list);
        }

        public void Do()
        {
            _list.Clear();
        }

        public void Undo()
        {
            foreach (var item in _backup)
                _list.Add(item);
        }
    }
}
