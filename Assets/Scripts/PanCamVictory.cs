using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamVictory : MonoBehaviour
{
    
    [SerializeField]
    private Camera mCamera;
    [SerializeField] 
    private GameObject target;
    [SerializeField] 
    [Range(0.0f, 1.0f)]
    private float weight = 0.5f;
    [SerializeField] 
    private float sensibility = 0.2f;
    [SerializeField] 
    private float zoomIn = 1f;
    [SerializeField] 
    private float zoomOut = 0.2f;
    private bool isPanning = false;
    private Vector3 orgPan;
    // Start is called before the first frame update
    void Start()
    {
        zoomOut = mCamera.orthographicSize;
        orgPan = mCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPanning){
            pan();
            if((target.transform.position - mCamera.transform.position).sqrMagnitude < sensibility){
                isPanning = false;
            }
        }
    }

    public void victory(){
        isPanning = true;
    }

    void pan(){
        //float nscl = ((zoomIn - mCamera.orthographicSize) / 2f) + weight*0.01f;
        float d = (mCamera.transform.position - orgPan).sqrMagnitude;
        d = d/(target.transform.position - orgPan).sqrMagnitude;
        Vector3 npos = (target.transform.position - mCamera.transform.position) * weight;
        npos.z = 0 ;
        mCamera.transform.position = mCamera.transform.position + npos;
        mCamera.orthographicSize = ((1-d) * zoomIn) + ((0+d) * zoomOut);
    }

    public void setTarget(GameObject go){
        target = go;
    }
}
