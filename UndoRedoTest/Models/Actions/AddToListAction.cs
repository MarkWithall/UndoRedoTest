using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UndoRedoTest.Models.UndoRedo;

namespace UndoRedoTest.Models.Actions
{
    public class AddToListAction<T> : UndoableAction
    {
        private readonly T _itemToAdd;
        private readonly IList<T> _list;

        public AddToListAction(T itemToAdd, IList<T> list)
        {
            _itemToAdd = itemToAdd;
            _list = list;
        }

        public void Do()
        {
            _list.Add(_itemToAdd);
        }

        public void Undo()
        {
            _list.RemoveAt(_list.Count - 1);
        }

        public override string ToString()
        {
            return _itemToAdd.ToString();
        }
    }
}