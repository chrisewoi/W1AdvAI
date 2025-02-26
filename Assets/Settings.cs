using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool vsyncOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 24;
        vsyncOn = false;
    }

    // Update is called once per frame
    public void ToggleVSync()
    {
        vsyncOn = !vsyncOn;

        if (vsyncOn)
        {
            QualitySettings.vSyncCount = 5;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
