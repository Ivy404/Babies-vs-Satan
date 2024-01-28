using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehaviour : MonoBehaviour
{
    protected Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            Vector2 vector = Quaternion.Euler(0, 0, collision.gameObject.transform.eulerAngles.z) * Vector2.up;
            body.velocity = body.velocity + vector*collision.gameObject.GetComponent<BumperScript>().bumpforce ; 
        }
    }
}
