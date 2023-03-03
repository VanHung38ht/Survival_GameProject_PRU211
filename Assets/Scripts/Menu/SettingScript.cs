using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    public GameObject settingScreen;
    // Start is called before the first frame update
    public void OpenSetting()
    {
        settingScreen.SetActive(true);
    }

    // Update is called once per frame
    public void CloseSetting()
    {
        settingScreen.SetActive(false);
    }
}
