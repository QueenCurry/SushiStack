﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSettingButtonManager : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject settingPanel;

    public void BackButtonClicked()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        settingPanel.SetActive(false);
    }
    public void dataReset()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        warningPanel.SetActive(true);
    }
}
