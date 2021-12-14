using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCScript : MonoBehaviour
{
    [Header("Player Variables")]
    CharacterController controller;
    [Space]
    [Header("Movement Physics")]
    [SerializeField] float playerSpeed = 50.0f;
    [SerializeField] float jumpHeight = 10.0f;
    [SerializeField] float gravityValue = -9.81f;
    Vector3 playerVelocity;

    [SerializeField] bool groundedPlayer;

    Transform camera;
    float rotSpeed = 4f;

    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        camera = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    private void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;

       
    }
    void Update()
    {
        float HoriInput = Input.GetAxisRaw("Horizontal");
        float VertiInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(HoriInput, 0f, VertiInput);
        Vector3 move = new Vector3(movement.x, 0f, movement.z).normalized;

        move = camera.forward * move.z + camera.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player...
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            float target = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0f, target, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
        }

        
    }
    
}
// Testing

//RaycastHit hit;

/*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
{
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    Debug.Log("Did Hit");
}
else
{
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
    Debug.Log("Did not Hit");
}*/
