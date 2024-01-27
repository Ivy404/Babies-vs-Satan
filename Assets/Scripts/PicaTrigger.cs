using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicaTrigger : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D trig;
    [SerializeField]
    private GameObject topPica;
    private bool babyInside = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D other) {
        babyInside = true;
        Debug.Log(
            other.gameObject.name
        );
        topPica.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other) {
        babyInside = false;
        Debug.Log(
            other.gameObject.name
        );
        topPica.SetActive(true);
    }

    public bool isBabyIn(){
        return babyInside;
    }
}
