using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DeadzoneCamera : MonoBehaviour 
{
    public Renderer target;

    public void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}