using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;

public class Head : MonoBehaviour
{
    public GameObject Heads;

    private GameOverScript gos;

    private void Awake()
    {
        gos = GetComponent<GameOverScript>();
    }

    public void DeleteHead()
    {
        for (var i = 0; i < Heads.transform.childCount; i++)
        {
            var anim = Heads.transform.GetChild(i).gameObject.GetComponent<Animator>();
            anim.SetBool("isHit", true);
            Observable.Timer(new TimeSpan(0, 0, 1))
            .ObserveOnMainThread()
            .Subscribe(_ =>
            {
                //Èäè íà õóé
                anim.SetBool("isHit", false);
            });
        }
        Destroy(Heads.transform.GetChild(Heads.transform.childCount - 1).gameObject);
    }

    private void Start()
    {
        var daeth = Observable.EveryUpdate()
            .Where(x => Heads.transform.childCount == 0)
            .Subscribe(x => gos.GameOver());
    }

}
