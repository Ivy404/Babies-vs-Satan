using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] windtrig;
    [SerializeField]
    private GameObject[] shards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
        //other.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude < 60
        if(other.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 50){
            foreach(GameObject shard in shards){
                shard.SetActive(true);
                shard.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0.30f, 3.0f), Random.Range(-1.0f, 1.0f));
            }
            /*
        
            for(int i = 0; i < windtrig.Length; i++){
                Debug.Log(windtrig[i].name);
                windtrig[i].SetActive(false);
            }*/
            foreach(GameObject go in windtrig){
                go.SetActive(false);
            }

            // PLAY SOUND glass breaking
            AudioManager.audioManagerRef.PlaySoundWithRandomPitch("glass_break");
        }
    }
}
