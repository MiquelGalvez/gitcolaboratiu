using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPickup : MonoBehaviour
{
    [SerializeField]
    float turnSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
    }
}
