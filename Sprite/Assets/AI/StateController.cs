using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{

    public State currentState;
    public State remainState;

    [HideInInspector] public AIPath aiPath;
    [HideInInspector] public AIDestinationSetter destination;
    [HideInInspector] public Patrol patrol;
    [HideInInspector] public Seeker seeker;
    [HideInInspector] public Entity entity;
    [HideInInspector] public float stateTimeElapsed;
    public bool aiActive;


    void Awake()
    {
        aiPath = GetComponent<AIPath>();
        destination = GetComponent<AIDestinationSetter>();
        patrol = GetComponent<Patrol>();
        seeker = GetComponent<Seeker>();
        entity = GetComponent<Entity>();
    }

    private void Start()
    {
        destination.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}