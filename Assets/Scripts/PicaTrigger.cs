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
        if(other.gameObject.tag != "isCristal"){
            babyInside = true;
            Debug.Log(
                other.gameObject.name
            );
            topPica.SetActive(false);

            // PLAY SOUND water splash
            AudioManager.audioManagerRef.PlaySound("water_splash");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag != "isCristal"){
            babyInside = false;
            Debug.Log(
                other.gameObject.name
            );
            topPica.SetActive(true);

            // PLAY SOUND awww
            AudioManager.audioManagerRef.PlaySound("awww");
        }
    }

    public bool isBabyIn(){
        return babyInside;
    }
}
