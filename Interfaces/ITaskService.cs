using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.Interfaces{
    public interface ITaskService{
         List<Task> GetAll();
        Task GetTask(int id);
        void Post(Task t);
        void Delete(int id);
        bool Put(int id,Task t);
      //  int Count { get; }
    }
}