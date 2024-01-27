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
        _ready = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
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
        }
        else
        {
            if(aimForce > 0)
                ThrowBaby();
            aimForce = 0;
        }
        _animator.SetFloat("AimForce", aimForce);
    }

    private void ReloadBaby()
    {
        _ready = true;
        Debug.Log("Reloaded!");
    }

    private void ThrowBaby()
    {
        _animator.SetBool("Throw", true);
        Debug.Log("Throw!");

        _animator.SetBool("Throw", false);
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
