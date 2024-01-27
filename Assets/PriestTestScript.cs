using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PriestTestScript : MonoBehaviour
{
    [SerializeField] public bool throwBaby;
    [SerializeField] public  float aimForce;

    [SerializeField] private bool _ready;
    [SerializeField] private bool _releaseBaby;
    [SerializeField] private Transform _babySlot;
    private Animator _animator;

    private

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        throwBaby = false;
        aimForce = 0;
        _releaseBaby = false;
        _ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            aimForce = 0.3f;
            Debug.Log("Force Strong");
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            aimForce = 0.7f;
            Debug.Log("Force Mid");
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            aimForce = 1.0f;
            Debug.Log("Force Low");
        }*/

        _animator.SetFloat("AimForce", aimForce);

        if (throwBaby) // Set by the level manager
            ThrowBaby();
    }

    // method to initiate the baby throw animations
    private void ThrowBaby()
    {
        throwBaby = false;
        _ready = false; //
        _animator.SetTrigger("Throw");
        Debug.Log("Throw!");
    }

    // method to do the actual baby release. Called when the throw animation is finished
    private void ReleaseBaby()
    {
        _releaseBaby = true;
        _animator.SetTrigger("Relaod");
        Debug.Log("Release!");
    }

    // method to do the baby reload. Called when the reload animation is finished
    private void ReloadBaby()
    {
        _ready = true;
        Debug.Log("Reloaded!");
    }

    public bool BabyReleased()
    {
        return _releaseBaby;
    }
    public bool PriestReady()
    {
        return _ready;
    }
}
