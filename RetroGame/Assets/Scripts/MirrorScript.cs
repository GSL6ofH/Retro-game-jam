using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    private Camera _mirrorCam;
    void Start()
    {
        _mirrorCam = GetComponent<Camera>();
    }
    void Update()
    {
        if (Time.frameCount % 4 == 0)
        {
            _mirrorCam.Render();
        }
    }
}