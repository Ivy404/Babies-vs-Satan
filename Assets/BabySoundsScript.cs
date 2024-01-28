using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySoundsScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // PLAY SOUND thud
        AudioManager.audioManagerRef.PlaySound("thud2");
    }
}
