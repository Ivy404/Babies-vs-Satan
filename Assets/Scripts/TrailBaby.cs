using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBaby : MonoBehaviour
{

    private TrailRenderer trail;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        trail = this.transform.GetChild(1).GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (trail != null)
        {
            // width is the width of the line
            timer += Time.deltaTime;
            float width = trail.startWidth;
            trail.material.mainTextureScale = new Vector2(1f / width, 1.0f);
            // 1/width is the repetition of the texture per unit (thus you can also do double
            // lines)
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (trail != null) { trail.emitting = false;}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trail != null) { trail.emitting = false; }
    }
}
