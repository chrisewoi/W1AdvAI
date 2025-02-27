using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float rate;
    public GameObject ball;
    private GameObject _ballSpawnGraphic;
    public AnimationCurve spawnGraphicCurve;
    private float _ballVisualScaleDefault;
    private float _ballVisualScale => spawnGraphicCurve.Evaluate(Mathf.InverseLerp(0, rate, _cooldown)) * _ballVisualScaleDefault;
    

    private float _cooldown;
    void Start()
    {
        _cooldown = 0f;
        _ballSpawnGraphic = Instantiate(ball, transform);
        _ballVisualScaleDefault = _ballSpawnGraphic.transform.localScale.x;
        Destroy(_ballSpawnGraphic.GetComponent<Rigidbody>());
        Destroy(_ballSpawnGraphic.GetComponent<SphereCollider>());
        //_ballSpawnGraphic.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (_cooldown >= rate)
        {
            Spawn();
            
        }

        //print(_ballVisualScale);
        Vector3 scale = new Vector3(_ballVisualScale, _ballVisualScale, _ballVisualScale);
        _ballSpawnGraphic.transform.localScale = scale;

        _cooldown += Time.deltaTime;
    }

    public void Spawn()
    {
        _cooldown = 0f;
        Instantiate(ball, transform);
    }
}
