using UnityEngine;
using UnityEditor;

public class TurnGear : MonoBehaviour
{
    private Transform transform;

    public float TurnSpeed = 100;
    
    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime, Space.World);
    }
}