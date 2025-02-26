using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SpinCounter : MonoBehaviour
{
    public int spinCount;
    public GameObject trigger;
    public GameObject reset;
    public GameObject display;

    private bool spinChecked;
    public TMP_Text displayText;

    void Start()
    {
        transform.parent = null;
        display.transform.parent = null;
        spinChecked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger") && spinChecked)
        {
            spinCount++;
            spinChecked = false;

            displayText.text = spinCount.ToString();
        }

        if (other.CompareTag("Reset") && !spinChecked)
        {
            spinCount++;
            spinChecked = true;
            
            displayText.text = spinCount.ToString();
        }
    }
}
