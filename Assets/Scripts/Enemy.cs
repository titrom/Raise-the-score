using System;
using UniRx;
using static ProjectDataTask;

public class Enemy
{
    public string Name { get; set; }
    public string TexturName { get; set; }


    private readonly BehaviorSubject<int> _subjectHP = new BehaviorSubject<int>(0);
    public int HP
    {
        get => _subjectHP.Value;
        set => _subjectHP.OnNext(value);    
    }

    public IObservable<int> ObservableHP => _subjectHP;
    public EGETask.TaskType Weaknesses { get; set; }

    public Enemy(string name, string texturName, int hp, EGETask.TaskType weaknesses)
    {
        Name = name;
        TexturName = texturName;
        HP = hp;
        Weaknesses = weaknesses;
    }
}