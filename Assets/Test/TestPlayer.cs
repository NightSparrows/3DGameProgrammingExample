using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public TestPlayerCamera mCamera;
    public CharacterController characterController;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
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
            this.animator.SetBool("isWalking", true);
            vector.Normalize();
            vector = Quaternion.AngleAxis(this.mCamera.yaw, Vector3.up) * vector;

            Quaternion targetRotation = Quaternion.LookRotation(vector, Vector3.up);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            vector *= 20f;
            this.characterController.SimpleMove(vector);
        } else
        {
            this.animator.SetBool("isWalking", false);
        }
        // gravity
        this.characterController.Move(new Vector3(0, -9.8f, 0));
    }
}
