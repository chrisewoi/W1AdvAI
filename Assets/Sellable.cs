using System;
using UnityEngine;

public class Sellable : MonoBehaviour
{
    public GameObject sellSign;

    public Material deselected, selected;

    public MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        sellSign.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        print("mouseover");
        sellSign.gameObject.SetActive(true);
        meshRenderer.material = selected;
    }

    private void OnMouseExit()
    {
        print("mouseexit");
        sellSign.gameObject.SetActive(false);
        meshRenderer.material = deselected;
    }

    private void OnMouseEnter()
    {
        print("mouseenter");
        sellSign.gameObject.SetActive(true);
        meshRenderer.material = deselected;
    }
}
