using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectDataTask
{
    public static System.Random Rnd { get; set; } = new System.Random();

    public static List<EGETask> Tasks = new List<EGETask> { 
     new EGETask(0, 35, EGETask.TaskType.LineUr),
     new EGETask(1, 75, EGETask.TaskType.LineUr),
     new EGETask(2, -12, EGETask.TaskType.LogUr),
     new EGETask(3, -7, EGETask.TaskType.LogUr),
     new EGETask(4, 3, EGETask.TaskType.LogUr),
     new EGETask(5, 10, EGETask.TaskType.LineUr),
     new EGETask(6, 34, EGETask.TaskType.LineUr),
     new EGETask(7, 34, EGETask.TaskType.MinUr), // 8
     new EGETask(8, -3, EGETask.TaskType.MinUr), // 10
     new EGETask(9, 1, EGETask.TaskType.LogUr) // 11
    };


    public static List<Enemy> Enemys = new List<Enemy>
    {
        new Enemy("Тимошенко","Timoshenko",100, EGETask.TaskType.LogUr)
    };





    public class EGETask
    {
        public int Number { get; set; }
        public double Correct { get; set; }

        public TaskType Type { get; set; }

        public EGETask(int number, double correct, TaskType type)
        {
            Number = number;
            Correct = correct;
            Type = type;
        }


        public enum TaskType
        {
            MinUr, LineUr, LogUr
        }
    }

}
