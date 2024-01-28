using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundScript : MonoBehaviour
{
    public void PlayTitleName()
    {
        // PLAY SOUND menu
        AudioManager.audioManagerRef.PlaySound("title3");
    }

    public void PlayMenuSound()
    {
        // PLAY SOUND menu
        AudioManager.audioManagerRef.PlaySoundWithRandomPitch("impact_menu");
    }
}
