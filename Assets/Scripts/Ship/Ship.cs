using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Ship : MonoBehaviour
{
    [SerializeField] private ShipCollisionHandler _handler;
    
    private Mover _mover;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }
}