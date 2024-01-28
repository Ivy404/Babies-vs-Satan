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
    private PicaTrigger pila;
    [SerializeField]
    private float winCon = 3.0f;
    [SerializeField]
    private BossBabyMainMenu menu;
    [SerializeField]
    private PanCamVictory camManager;

    private float winTimer;
    private bool victoryMenu = false;

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
        //  debug restart
        if (Input.GetKeyDown(KeyCode.K)) { babybehaviour.KillBabies(); }
        // Evaluation of win con
        if (pila.isBabyIn() && state != States.Win)
        {
            winTimer += Time.deltaTime;
        }
        else
        {
            winTimer = 0;
        }

        if (winTimer >= winCon && state != States.Win)
        {
            state = States.Win;
            Debug.Log("You win!!");
            camManager.victory();

            // PLAY SOUNDS victory
            AudioManager.audioManagerRef.PlaySound("victory_fanfare");
            AudioManager.audioManagerRef.PlaySound("victory_cheers");
        }
        // State Machine
        switch (state)
        {
            case States.Idle:
                if (babybehaviour.dragging) // player is dragging
                    state = States.Playing; 
                break;
            case States.Playing:
                // set priest variable to priest force: aimForce with forceM
                priest.aimForce = babybehaviour.forceM;
                if (!babybehaviour.dragging && babybehaviour.forceM >= 0) // player released the click at enough distance
                {
                    priest.throwBaby = true;
                    state = States.Throw;
                    priest.aimForce = 0;
                    babybehaviour.enabledInput = false;
                }
                else if (!babybehaviour.dragging && babybehaviour.forceM < 0)
                {
                    state = States.Idle;
                }
                break;
            case States.Throw:
                if (priest.BabyReleased()) // change for babyReleased
                {
                    babybehaviour.CreateBaby(priest.skincolor, priest.clothcolor);
                    babybehaviour.ThrowBaby();
                    state = States.Waiting;
                }
                break;
            case States.Waiting:
                if (priest.PriestReady()) // priest ready
                {
                    babybehaviour.enabledInput = true;
                    state = States.Idle;
                }
                break;
            case States.Win:
                if (!camManager.isPanning && !victoryMenu)
                {
                    menu.bautizadoOle();
                    victoryMenu = true;

                    // PLAY SOUND Baptized
                    AudioManager.audioManagerRef.PlaySound("victory_voices");
                }
                break;
            case States.Lose:
                state = States.Idle;
                break;
        }
    }
}
