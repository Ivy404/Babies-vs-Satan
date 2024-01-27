using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PriestTestScript : MonoBehaviour
{
    [SerializeField] private float _aimForce;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _aimForce = 0.3f;
            Debug.Log("Force Strong");
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            _aimForce = 0.7f;
            Debug.Log("Force Mid");
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            _aimForce = 1.0f;
            Debug.Log("Force Low");
        }
        else
        {
            if(_aimForce > 0)
                ThrowBaby();
            _aimForce = 0;
        }
        _animator.SetFloat("AimForce", _aimForce);
    }

    void ThrowBaby()
    {
        _animator.SetBool("Throw", true);
        Debug.Log("Throw!");

        _animator.SetBool("Throw", false);
    }
}
