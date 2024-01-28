using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    private Animator _animator;
    public float bumpforce = 20.0f;
    public float torquef = 5.0f;
    private Rigidbody2D baby;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // This function should be called once the baby collides with the Bumper
    public void HitBumper(Rigidbody2D b)
    {
        baby = b;
        _animator.SetTrigger("BumperHit");
        Debug.Log("Bumper hit!");
    }

    // This function is called when the animation of the bumper finishes
    private void PushBaby()
    {
        Vector2 vector = Quaternion.Euler(0, 0, this.transform.eulerAngles.z) * Vector2.up;
        baby.velocity = baby.velocity + vector * bumpforce;
        baby.AddTorque(torquef);
        // TO DO: apply the force to the baby here
        Debug.Log("Baby Pushed!");
    }
}
