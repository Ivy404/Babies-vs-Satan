using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanImpulse : MonoBehaviour
{
    [SerializeField]
    private float strength = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        // PLAY SOUND fan 'horn'
        AudioManager.audioManagerRef.PlaySound("pipes");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(transform.up.x, transform.up.y) * strength;
    }
}
