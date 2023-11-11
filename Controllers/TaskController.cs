using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Tasks.Interfaces;
using Tasks.Models;

namespace Tasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        // private static readonly string[] tasks = new[]
        // {
        //    "go for a walk" ,"wash floor","bake a cake","listen to music","go to school","sleep"

        // };
        private ITaskService TaskService;
        public TaskController(ITaskService taskService){
            this.TaskService=taskService;
        }

       [HttpGet]
      public IEnumerable<Task> Get()
        {
        return this.TaskService.GetAll();
        }

       [HttpGet ("{id}")]
       public Task Get(int id) 
       {   
           return this.TaskService.GetTask(id);
    
       }   

       [HttpPut ("{id}")]
      public bool Put(int id, Task newTask)
    {
        return this.TaskService.Put(id,newTask);
      
    } 
    [HttpPost]
    public void Post(Task newTask)
    {
        this.TaskService.Post(newTask);
        
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        this.TaskService.Delete(id);
    
    }       
     }

}
