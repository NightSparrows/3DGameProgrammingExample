using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform m_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPosition = this.m_player.position;
        newPosition.y += 100;
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
