using UnityEngine;

public class RandomBG : MonoBehaviour
{
    public float speed;

    public Color color;

    public float min, max;
    private Camera camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        color = new Color(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RandomColorSmooth();
    }

    void RandomColorSmooth()
    {
        float r = color.r, g = color.g, b = color.b;
        
        float randomBias = r+b+g / max / 2f;
        
        r += Random.value < randomBias ? -speed * Time.deltaTime : speed * Time.deltaTime;
        g += Random.value < randomBias ? -speed * Time.deltaTime : speed * Time.deltaTime;
        b += Random.value < randomBias ? -speed * Time.deltaTime : speed * Time.deltaTime;

        

        color = new Color(Mathf.Clamp(r, min/255f, max/255f), Mathf.Clamp(g, min/255f, max/255f), Mathf.Clamp(b, min/255f, max/255f));

        camera.backgroundColor = color;
    }
}
