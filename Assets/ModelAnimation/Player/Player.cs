using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCamera m_camera;
    CharacterController m_characterController;
    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        this.m_animator = this.GetComponent<Animator>();
        this.m_characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) vector.z -= 1;
        if (Input.GetKey(KeyCode.S)) vector.z += 1;
        if (Input.GetKey(KeyCode.D)) vector.x -= 1;
        if (Input.GetKey(KeyCode.A)) vector.x += 1;

        if (vector.magnitude != 0)
        {
            this.m_animator.SetBool("isWalking", true);
            vector.Normalize();
            vector = Quaternion.AngleAxis(this.m_camera.yaw, Vector3.up) * vector;

            Quaternion targetRotation = Quaternion.LookRotation(vector, Vector3.up);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            vector *= 20f;
            this.m_characterController.SimpleMove(vector);
        } else
        {
            this.m_animator.SetBool("isWalking", false);
        }
        // gravity
        this.m_characterController.Move(new Vector3(0, -9.8f, 0));
    }
}
