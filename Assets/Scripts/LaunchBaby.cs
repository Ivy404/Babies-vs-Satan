using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaunchBaby : MonoBehaviour
{
    public GameObject babyprefab;
    public Camera cam;
    public GameObject lineObj;
    public GameObject anchor;
    public float force;
    public float forceM;
    public bool enabledInput;
    public bool dragging = false;
    LineRenderer lineR;

    [SerializeField] private float minForce = 50.0f;
    [SerializeField] private float maxForce = 150.0f;
    [SerializeField] private float minDistance = 0.5f;
    [SerializeField] private float maxDistance = 15.0f;
    [SerializeField] private List<GameObject> babies = new List<GameObject>();

    private GameObject babyObj;
    private GameObject cLineObj;
    private Rigidbody2D baby;
    private Vector3 startPos = Vector3.zero;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void CreateBaby()
    {
        babyObj = Instantiate(babyprefab);
        baby = babyObj.GetComponent<Rigidbody2D>();
        if (baby != null)
        {
            babies.Add(babyObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enabledInput)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                dragging = true;
                createLine();
                // Vector2 wp = cam.ScreenToWorldPoint(Input.mousePosition);
                //baby.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * force);
            } else if (Input.GetKey(KeyCode.Mouse0) && dragging)
            {
                Vector3 direction = startPos - cam.ScreenToWorldPoint(Input.mousePosition);
                float mgt = direction.sqrMagnitude;
                lineR.SetPosition(0, anchor.transform.position);
                if (mgt >= minDistance)
                {
                    lineR.enabled = true;
                    forceM = (mgt - minDistance) / (maxDistance - minDistance);
                    forceM = Mathf.Clamp(forceM, 0, 1);
                    force = minForce + (maxForce - minForce) * forceM;
                    float angle = Vector3.Angle(Vector3.right, direction);
                    if (angle > 180)
                    {
                        angle = angle - 180;
                    }
                    drawLine(10, direction.normalized * force, angle, anchor.transform.position);
                } else
                {
                    lineR.enabled = false;
                    forceM = 0;
                    force = 0;
                }

            } else if (Input.GetKeyUp(KeyCode.Mouse0) && dragging)
            {
                Vector3 direction = startPos - cam.ScreenToWorldPoint(Input.mousePosition);
                float mgt = direction.sqrMagnitude;
                if (mgt >= minDistance && mgt <= maxDistance)
                {
                    forceM = (mgt - minDistance) / (maxDistance - minDistance);
                } else if (mgt > maxDistance)
                {
                    forceM = 1.0f;
                } else
                {
                    forceM = -1.0f;
                    return;
                }
                force = minForce + (maxForce - minForce) * forceM;
                dir = direction;
                dragging = false;
                Destroy(cLineObj);

            }
        }
    }

    public void ThrowBaby()
    {
        babyObj.transform.position = anchor.transform.position;
        baby.simulated = true;
        baby.velocity = dir.normalized * force;

        // PLAY SOUND THROW
        AudioManager.audioManagerRef.PlaySoundWithRandomPitch("baby_blah");

    }
    void createLine()
    {
        cLineObj = Instantiate(lineObj);
        lineR = cLineObj.GetComponent<LineRenderer>();
    }

    void drawLine(int points, Vector3 velocity, float angle, Vector3 position)
    {
        float tdelta = 0.1f;
        lineR.positionCount = points;
        for (int i = 1; i < points; i++) {
            lineR.SetPosition(i, new Vector3(
                position.x + velocity.x * i * tdelta,
                position.y + velocity.y * i * tdelta - (1f / 2f) * (9.81f) * Mathf.Pow(tdelta * i, 2),
                0
                ));

        }
    }

    public void KillBabies()
    {
        for (int i = babies.Count - 1; i >= 0 ; i--)
        {
            Destroy(babies[i]);
        }
    }
}
