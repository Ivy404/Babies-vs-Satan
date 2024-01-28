using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    private Animator _animator;
    public float bumpforce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // This function should be called once the baby collides with the Bumper
    private void HitBumper()
    {
        _animator.SetTrigger("BumperHit");
        Debug.Log("Bumper hit!");
    }

    // This function is called when the animation of the bumper finishes
    private void PushBaby()
    {
        // TO DO: apply the force to the baby here
        Debug.Log("Baby Pushed!");
    }
}
