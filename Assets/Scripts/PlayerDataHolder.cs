using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDataHolder : MonoBehaviour
{
    public PlayerShooter PlayerShooter => _playerShooter;
    public NavMeshAgent PlayerAgent => _agent;
    public Animator Animator => _animator;
    public AnimationVisualiser AnimationVisualiser => _animationVisualiser;
    
    [SerializeField] private PlayerShooter _playerShooter;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationVisualiser _animationVisualiser;
}
