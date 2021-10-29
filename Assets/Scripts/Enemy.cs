using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ValueBar valueBar;
    [SerializeField] private AiMover mover;
    [SerializeField] private float maxHealth;
    [SerializeField] private Arena thisArena;
    [SerializeField] private UnityEvent DieEvent;

    private float curentHealth;
    private GameObject valueObject;

    private void Awake()
    {
        curentHealth = maxHealth;
        if (valueBar == null)
        {
            LoadValueBar();
            valueBar.SetTargetFollow(transform);
        }
    }

    public void ApplyDamage(float damage)
    {
        curentHealth -= damage;
        valueBar.UpdateValue(curentHealth / maxHealth);
        if (curentHealth <= 0)
            Deth();
    }

    public void Deth()
    {
        valueObject.SetActive(false);
        DieEvent?.Invoke();
        thisArena.RemoveEnemy(this);
    }
    // жуткий костыль, не придумал ничего лучше чем одновременно подгружать и скрывать объект
    // чтобы он не висел и не занимал пол экрана если находиться далеко от камеры игрока
    private void LoadValueBar()
    {
        GameObject go = Resources.Load("SliderValue") as GameObject;
        valueObject = Instantiate(go);
        go.SetActive(false);
        valueBar = valueObject.GetComponentInChildren<ValueBar>(); 
    }
    public void EnableEnemy()
    {
        valueObject.SetActive(true);
        mover.EnableMover();
    }
}
