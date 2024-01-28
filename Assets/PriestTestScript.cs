using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PriestTestScript : MonoBehaviour
{
    [SerializeField] public bool throwBaby;
    [SerializeField] public  float aimForce;

    [SerializeField] private bool _ready;
    [SerializeField] private bool _releaseBaby;
    [SerializeField] private GameObject _babySlot;

    [SerializeField] private Color[] skinColors;
    private Animator _animator;

    public Color skincolor;
    public Color clothcolor;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        throwBaby = false;
        aimForce = 0;
        _releaseBaby = false;
        _ready = true;

        Transform bb = _babySlot.transform.GetChild(0).GetChild(0);
        int choiceColor = Random.Range(0, skinColors.Length);
        skincolor = skinColors[choiceColor];
        bb.GetChild(2).GetComponent<SpriteRenderer>().color = skinColors[choiceColor]; // face
        clothcolor = new Color(
        Random.Range(0.2f, 0.8f),
        Random.Range(0.2f, 0.8f),
        Random.Range(0.2f, 0.8f),
        1.0f
        );
        bb.GetChild(3).GetComponent<SpriteRenderer>().color = clothcolor; // cloth
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("AimForce", aimForce);

        if (throwBaby) // Set by the level manager
            ThrowBaby();
    }

    // method to initiate the baby throw animations
    private void ThrowBaby()
    {
        throwBaby = false;
        _ready = false; // This will be false until I reload
        _animator.SetTrigger("Throw");
        if(_babySlot != null) _babySlot.SetActive(false);
        //Debug.Log("Throw!");

        // PLAY SOUND effort
        AudioManager.audioManagerRef.PlaySound("effort");
    }

    // method to do the actual baby release. Called when the throw animation is finished
    private void ReleaseBaby()
    {
        _releaseBaby = true;
        _animator.SetTrigger("Reload");

        //Debug.Log("Release!");
    }

    // method to do the baby reload. Called when the reload animation is finished
    private void ReloadBaby()
    {
        Transform bb = _babySlot.transform.GetChild(0).GetChild(0);
        int choiceColor = Random.Range(0, skinColors.Length);
        skincolor = skinColors[choiceColor];
        bb.GetChild(2).GetComponent<SpriteRenderer>().color = skinColors[choiceColor]; // face
        clothcolor = new Color(
        Random.Range(0.2f, 0.8f),
        Random.Range(0.2f, 0.8f),
        Random.Range(0.2f, 0.8f),
        1.0f
        );
        bb.GetChild(3).GetComponent<SpriteRenderer>().color = clothcolor; // cloth
        if (_babySlot != null) _babySlot.SetActive(true);
        _ready = true;
        //Debug.Log("Reloaded!");
    }

    public bool BabyReleased()
    {
        return _releaseBaby;
    }
    public bool PriestReady()
    {
        return _ready;
    }
}
