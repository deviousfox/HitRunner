using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHolder : MonoBehaviour
{
   public EnemyAttack EnemyAttack => _enemyAttack;
   public Animator Animator => _animator;
   public AnimationVisualiser AnimationVisualiser => _animationVisualiser;
   [SerializeField] private EnemyAttack _enemyAttack;
   [SerializeField] private Animator _animator;
   [SerializeField] private AnimationVisualiser _animationVisualiser;
}
