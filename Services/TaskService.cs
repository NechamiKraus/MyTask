using Tasks.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Services
{

 using Tasks.Models;

    public class TaskService:ITaskService
     {      
        List<Task> myTasks {get;}
        private IWebHostEnvironment  webHost;
        private string filePath;

        public TaskService(IWebHostEnvironment webHost)
        {
          
            this.webHost = webHost;

            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "Task.json");
            using (var jsonFile = File.OpenText(filePath))
            {
                myTasks = JsonSerializer.Deserialize<List<Task>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
       }
       
        private void saveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(myTasks));
        }

      public List<Task> GetAll() => myTasks;
       

       public Task GetTask(int id) => myTasks.FirstOrDefault (t => t.id == id);
   

      public bool Put(int id, Task newTask)
    {
        var oldTask = myTasks.FirstOrDefault(t => t.id == id);
        var index = myTasks.IndexOf(oldTask);
        if (index == -1)
            return false;
        myTasks[index] = newTask;
        return true;
        saveToFile();

    } 

    public void Post(Task newTask)
    {
        newTask.id =myTasks.Count();//myTasks.Count()+1;
        myTasks.Add(newTask);
        saveToFile();
    }

    public void Delete(int id)
    {
        var temptask = GetTask(id);
        if (temptask is null)
            return;
        var oldTask = myTasks.FirstOrDefault(t => t.id == id);
        var index = myTasks.IndexOf(oldTask);
        myTasks.RemoveAt(index);
        myTasks.Remove(temptask);
        saveToFile();
    } 


    
}
}