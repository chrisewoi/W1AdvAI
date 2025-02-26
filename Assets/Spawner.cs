using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float rate;
    public GameObject ball;
    private GameObject _ballSpawnGraphic;
    public AnimationCurve spawnGraphicCurve;
    private float _ballVisualScale;
    

    private float _cooldown;
    void Start()
    {
        _cooldown = 0f;
        _ballSpawnGraphic = Instantiate(ball, transform);
        Destroy(_ballSpawnGraphic.GetComponent<Rigidbody>());
        //_ballSpawnGraphic.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (_cooldown >= rate)
        {
            Spawn();
            
        }

        _cooldown += Time.deltaTime;
    }

    public void Spawn()
    {
        _cooldown = 0f;
        Instantiate(ball, transform);
    }
}
