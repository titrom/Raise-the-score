using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using static ProjectDataTask;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

public class SpriteEnemy : MonoBehaviour
{
    public string NameEnemy;
    public TMP_Text textName;
    public Enemy enemy;
    public GameObject HitBox;
    public TMP_Text prefabDamageText;

    public Texture2D Texture;
    public Slider slider;
    private void Awake()
    {
        enemy = Enemys.First(x => x.Name == NameEnemy);
        textName.text = enemy.Name;
        slider.maxValue = enemy.HP;
        enemy.ObservableHP.Subscribe(x => slider.value = enemy.HP);
        enemy.ObservableHP
            .Where(x => x <= 0)
            .ObserveOnMainThread()
            .Subscribe(x =>
            {
                SceneManager.LoadScene("ComplitGameScene");
            });

    }

    public void FallHP(int damage, EGETask.TaskType atackType)
    {
        var realDamage = (int)(damage * (atackType == enemy.Weaknesses ? 1.5 : 1));
        enemy.HP -= realDamage;

        var damageText = Instantiate(prefabDamageText, HitBox.transform);
        damageText.rectTransform.localPosition = new Vector2(Rnd.Next(150) - 100, Rnd.Next(150) - 100);
        damageText.text = $"-{realDamage}";

        Observable.Timer(new TimeSpan(0, 0, 1))
            .ObserveOnMainThread()
            .Subscribe(_ =>
            {
                //Иди на хуй
                Destroy(damageText);
            });
    }
}
