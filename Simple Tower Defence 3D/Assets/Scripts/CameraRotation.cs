using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float _horizontalInput;
    
    private void Update()
    {
        Input();
        Rotate();
    }

    private void Input()
    {
        _horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
    }
    
    private void Rotate()
    {
        float rotation = -_horizontalInput * Time.deltaTime * 150;
        transform.Rotate(0, rotation, 0);
    }
}
