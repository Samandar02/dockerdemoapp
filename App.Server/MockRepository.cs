using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App.Server
{
    public class MockRepository : IRepository
    {
        List<TodoModel> context = new List<TodoModel>();
        public IEnumerable<TodoModel> GetToDos()
        {
            return context.ToList();
        }
        public string PostToDo(TodoModel newToDo)
        {
            context.Add(newToDo);
            return newToDo.Todo??"as";
        }
    }
    public class TodoModel
    {
        public string? Todo { get; set; }
    }
}