using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Enemy
{
    [SerializeField] private PlayerDataHolder _dataHolder;
    public override void Die()
    {
        _dataHolder.PlayerShooter.CanShoot = false;     
        Destroy(_dataHolder.Animator);
        Destroy(_dataHolder.AnimationVisualiser);
        Destroy(_dataHolder.PlayerAgent);
        Destroy(_dataHolder.PlayerAgent);
        Rigidbody[] rigidbodies  = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
        FindObjectOfType<UiController>().LoseGame();
    }
}
