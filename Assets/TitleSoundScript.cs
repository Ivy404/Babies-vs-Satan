using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundScript : MonoBehaviour
{
    public void PlayMenuSound()
    {
        // PLAY SOUND menu
        AudioManager.audioManagerRef.PlaySound("impact_menu");
    }
}
