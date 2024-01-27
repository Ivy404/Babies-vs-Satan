using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBaby : MonoBehaviour
{
    public Rigidbody2D baby;
    public Camera cam;
    public GameObject lineObj;
    LineRenderer lineR;

    [SerializeField] private float minForce = 50.0f;
    [SerializeField] private float maxForce = 150.0f;
    [SerializeField] private float minDistance = 0.5f;
    [SerializeField] private float maxDistance = 15.0f;


    private bool dragging = false;
    private Vector3 startPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        baby = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baby != null)
        {
            float force;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                dragging = true;
                // createLine();
                // Vector2 wp = cam.ScreenToWorldPoint(Input.mousePosition);
                //baby.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * force);
            } else if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector3 direction = startPos - cam.ScreenToWorldPoint(Input.mousePosition);
                float mgt = direction.sqrMagnitude;
                if (mgt >= minDistance)
                {

                }

            } else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Vector3 direction = startPos - cam.ScreenToWorldPoint(Input.mousePosition);
                float mgt = direction.sqrMagnitude;
                if (mgt >= minDistance && mgt <= maxDistance)
                {
                    force = (mgt - minDistance) / (maxDistance - minDistance);
                } else if (mgt > maxDistance)
                {
                    force = 1.0f;
                } else
                {
                    // throw cancel
                    return;
                }
                force = minForce + (maxForce - minForce) * force;
                Debug.Log(force);
                baby.simulated = true;
                baby.velocity = direction.normalized * force;
                dragging = false;
                lineR = null;

            }
        }
    }

    void createLine()
    {
        GameObject lineObject = Instantiate(lineObj);
        lineR = lineObject.GetComponent<LineRenderer>();
    }

    void drawLine(int points, Vector3 position)
    {
        for (int i = 0; i < points; i++) {

            lineR.SetPosition(i, position);

        }
    }
}
