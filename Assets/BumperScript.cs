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
        baby.AddTorque(torquef);
        //baby.velocity = Mathf.Sin(Vector3.Angle(this.transform.up,baby.velocity))*baby.velocity.magnitude*this.transform.up.normalized+this.transform.up * bumpforce;
        baby.velocity = Mathf.Cos(Mathf.Deg2Rad * Vector3.Angle(this.transform.right, baby.velocity)) * baby.velocity.magnitude * this.transform.right.normalized + this.transform.up * bumpforce;
    }

    // This function is called when the animation of the bumper finishes
    private void PushBaby()
    {
        // PLAY SOUND bumper
        AudioManager.audioManagerRef.PlaySound("bumper");
    }
}
