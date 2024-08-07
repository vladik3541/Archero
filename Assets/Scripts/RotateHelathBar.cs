using UnityEngine;


public class RotateHelathBar : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
