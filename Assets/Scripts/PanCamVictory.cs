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
    private float duration = 3.0f;
    [SerializeField] 
    private float offset = 1.0f;
    [SerializeField] 
    private float zoomIn = 1f;

    private float zoomOut;
    public bool isPanning = false;
    private Vector3 orgPan;
    private float panTimer = 0f;
    private Vector3 npos;
    // Start is called before the first frame update
    void Start()
    {
        zoomOut = mCamera.orthographicSize;
        orgPan = mCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPanning){
            SmoothMove(orgPan, npos, duration);
            //if((target.transform.position - mCamera.transform.position).sqrMagnitude < sensibility) isPanning = false;
        }
    }

    public void victory()
    {
        npos = target.transform.position + Vector3.up * offset;
        npos.z = orgPan.z;
        isPanning = true;
    }

    public void setTarget(GameObject go){
        target = go;
    }

    void SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        if ( panTimer < 1.0 && isPanning)
        {
            panTimer += Time.deltaTime / seconds;
            mCamera.transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0.0f, 1.0f, panTimer));
            mCamera.orthographicSize = Mathf.Lerp(zoomOut, zoomIn, Mathf.SmoothStep(0.0f, 1.0f, panTimer));
        } else
        {
            isPanning=false;
            panTimer=0;
        }
    }
}
