using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.instance.PlaySound("BackGround_001");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.instance.PlaySound("Cannon");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SoundManager.instance.PlaySound("Laser");
        }
    }
}
