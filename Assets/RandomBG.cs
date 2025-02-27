using UnityEngine;

public class RandomBG : MonoBehaviour
{
    public float speed;

    public Color color;
    public int priorityColor;
    public float priorityTime;
    public float priorityTimeMax;
    public float priorityAmount;
    public float priorityDirection;

    public float min, max;
    private Camera camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        color = new Color(Random.Range(min/255f, max/255f), Random.Range(min/255f, max/255f), Random.Range(min/255f, max/255f));
        camera = Camera.main;
        priorityColor = Random.Range(0, 3);
        priorityDirection = Random.value > 0.5f ? -1f : 1f;
    }

    // Update is called once per frame
    void Update()
    {
        RandomColorSmooth();

        if (priorityTime > priorityTimeMax)
        {
            priorityTime = 0f;
            priorityColor = Random.Range(0, 3);
            priorityDirection = Random.value > 0.5f ? -1f : 1f;
        }
        priorityTime += Time.deltaTime;
    }

    void RandomColorSmooth()
    {
        float r = color.r, g = color.g, b = color.b;
        
        float randomBias = r+b+g / (max+min) / 3f; // //range between 0.4 and 0.6
        
        randomBias = Mathf.Clamp(randomBias, 0.48f, 0.52f);
        print("random Bias: " + randomBias);
        
        r += Random.value < randomBias ? -speed * Time.deltaTime : speed * Time.deltaTime;
        g += Random.value < randomBias ? -speed * Time.deltaTime : speed * Time.deltaTime;
        b += Random.value < randomBias ? -speed * Time.deltaTime : speed * Time.deltaTime;



        color = new Color(Mathf.Clamp(r, min/255f, max/255f), Mathf.Clamp(g, min/255f, max/255f), Mathf.Clamp(b, min/255f, max/255f));
        
        //priority color
        color[priorityColor] += Random.Range(0, speed) 
                                * priorityAmount * priorityDirection * Time.deltaTime;
        
        camera.backgroundColor = color;
    }
}
