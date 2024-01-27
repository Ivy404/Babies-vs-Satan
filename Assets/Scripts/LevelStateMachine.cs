using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateMachine : MonoBehaviour
{

    [SerializeField]
    private LaunchBaby babybehaviour;
    [SerializeField]
    private PriestTestScript priest;
    [SerializeField]
    private Transform anchor;

    public enum States
    {
        Idle,
        Playing,
        Throw,
        Waiting,
        Win,
        Lose
    }

    [SerializeField] private States state;
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        babybehaviour.enabledInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Evaluation of win con

        // State Machine
        switch (state)
        {
            case States.Idle:
                if (babybehaviour.dragging) // player is dragging
                    state = States.Playing; 
                break;
            case States.Playing:
                // set priest variable to priest force: aimForce with forceM
                if (!babybehaviour.dragging && babybehaviour.forceM > 0) // player released the click at enough distance
                {
                    // set priest throwBaby
                    state = States.Throw;
                }
                else if (!babybehaviour.dragging && babybehaviour.forceM <= 0)
                {
                    state = States.Idle;
                }
                break;
            case States.Throw:
                if (priest != null) // change for babyReleased
                {
                    babybehaviour.ThrowBaby(Vector3.zero); // get anchor
                    state = States.Waiting;
                }
                break;
            case States.Waiting:
                if (true) // priest ready
                {
                    state = States.Idle;
                }
                break;
            case States.Win:
                break;
            case States.Lose:
                state = States.Idle;
                break;
        }
    }
}
