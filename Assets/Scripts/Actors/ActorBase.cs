using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorBase : MonoBehaviour
{
    [Header("Actor settings")]
    [SerializeField] private int movementSpeed;
    [SerializeField] private NavMeshAgent agent;

    private enum states
    {
        Idle,
        Working
    }
    private states currentState;

    private void Start()
    {

        currentState = states.Idle;
        //agent.SetPath = GetPosition();

    }

    private void Update()
    {

        switch (currentState)
        {

            case states.Idle:
                Stroll();
                break;
        }

    }

    private void Stroll()
    {

        agent.Move(GetPosition());

    }

    private Vector3 GetPosition()
    {

        int xPos = Random.Range(-10, 10);
        int zPos = Random.Range(-10, 10);
        Vector3 newPosition = new Vector3(xPos, 0, zPos);

        return newPosition;

    }
}
