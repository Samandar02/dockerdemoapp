using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Server
{
    public interface IRepository
    {
        IEnumerable<TodoModel> GetToDos();
        string PostToDo(TodoModel newToDo);
    }
}