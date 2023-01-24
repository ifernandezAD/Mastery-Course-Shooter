using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;


    private Animator animator;
    private CharacterController characterController;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * rotationSpeed);

        characterController.SimpleMove(transform.forward * Time.deltaTime * moveSpeed * vertical);
    }
}