using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PriestTestScript : MonoBehaviour
{
    [SerializeField] public bool throwBaby;
    [SerializeField] public  float aimForce;

    [SerializeField] private bool _ready;
    [SerializeField] private bool _releaseBaby;
    [SerializeField] private GameObject _babySlot;
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
        _animator.SetFloat("AimForce", aimForce);

        if (throwBaby) // Set by the level manager
            ThrowBaby();
    }

    // method to initiate the baby throw animations
    private void ThrowBaby()
    {
        throwBaby = false;
        _ready = false; // This will be false until I reload
        _animator.SetTrigger("Throw");
        if(_babySlot != null) _babySlot.SetActive(false);
        Debug.Log("Throw!");
    }

    // method to do the actual baby release. Called when the throw animation is finished
    private void ReleaseBaby()
    {
        _releaseBaby = true;
        _animator.SetTrigger("Reload");
        Debug.Log("Release!");
    }

    // method to do the baby reload. Called when the reload animation is finished
    private void ReloadBaby()
    {
        if (_babySlot != null) _babySlot.SetActive(true);
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
