using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicaTrigger : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D trig;
    [SerializeField]
    private GameObject topPica;
    [SerializeField]
    private PanCamVictory camListener;
    [SerializeField]
    private BossBabyMainMenu cm2;
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
        cm2.bautizadoOle();
        camListener.victory();
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
