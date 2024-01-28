using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCristalDoofSelfDestroy : MonoBehaviour
{
    [SerializeField]
    private float minLifespan=4;
    
    [SerializeField]
    private float maxLifespan=7;
    private float timelife = 0;
    private float lifespan=7;
    
    // Start is called before the first frame update
    void Start()
    {
        lifespan = Random.Range(minLifespan, maxLifespan);
    }

    // Update is called once per frame
    void Update()
    {
        timelife += Time.deltaTime;
        if(lifespan < timelife){
            Destroy(this.gameObject);
        }
    }
}
