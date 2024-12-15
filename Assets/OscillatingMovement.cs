using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
public class OscillatingMovement : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float amplitude = 1f;
    public float frequency = 1f;

    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position;
        direction = direction.normalized;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + direction * offset;
    }
}
