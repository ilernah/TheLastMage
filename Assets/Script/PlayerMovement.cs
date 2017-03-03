using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool isCanMove = true;

    private Vector2 destinationVector;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        int inputX = (int)Input.GetAxisRaw("Horizontal");
        int inputY = (int)Input.GetAxisRaw("Vertical");

        if (inputX != 0)
        {
            inputY = 0;
        }

        if ((inputX != 0 || inputY != 0) && isCanMove)
        {
            isCanMove = false;
            Vector2 startPositionVector = transform.position;
            destinationVector = startPositionVector + new Vector2(inputX, inputY);

            animator.SetBool("isWalking", true);
            animator.SetFloat("inputX", inputX);
            animator.SetFloat("inputY", inputY);
            StartCoroutine(SmoothMovement(destinationVector));
        }
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rigidBody.position, end, 5f * Time.deltaTime);
            rigidBody.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        animator.SetBool("isWalking", false);
        isCanMove = true;
    }
}
