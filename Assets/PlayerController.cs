using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    /**
    public float moveSpeed = 6f;    // Velocidad de movimiento del jugador
    public float jumpForce = 5f;    // Fuerza de salto del jugador
    
    // Referencia al componente Rigidbody del jugador
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Obtener el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();
        
        // Inicializar el jugador como estando en el suelo
        isGrounded = true;

        // Asegúrate de que el Rigidbody use gravedad
        rb.useGravity = true;
    }

    void Update()
    {
        // Obtener la entrada horizontal del jugador (entre -1 y 1)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcular el movimiento horizontal basado en la entrada del jugador y la velocidad de movimiento
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Mover la posición del jugador sumando el movimiento a la posición actual
        rb.MovePosition(transform.position + movement);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Añade fuerza para saltar usando un impulso
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            // El jugador ya no está en el suelo después de saltar
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    **/
   public float speed = 5f;       // Velocidad de movimiento horizontal del jugador
    public float jumpSpeed = 5f;   // Fuerza de salto del jugador
    public float gravity = -9.81f;

    private float ySpeed = 0f;
    private bool isGrounded = false;
    private bool canDoubleJump = false;

    private CharacterController controller;

    void Start()
    {
        // Obtener el componente CharacterController del jugador
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtener la entrada horizontal del jugador (entre -1 y 1)
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f) * speed;

        // Aplicar la gravedad a la velocidad vertical
        ySpeed += gravity * Time.deltaTime;

        // Manejo del salto
        if (Input.GetButtonDown("Jump"))
        {
            // Si el jugador está en el suelo, permite saltar
            if (isGrounded)
            {
                ySpeed = jumpSpeed;
                isGrounded = false;
                canDoubleJump = true; // Permite el doble salto
            }
            // Permite el segundo salto si `canDoubleJump` es verdadero
            else if (canDoubleJump)
            {
                // Multiplica el jumpSpeed por 1.2 para el doble salto
                ySpeed = jumpSpeed * 1.2f;
                canDoubleJump = false; // Deshabilita el doble salto después de usarlo
            }
        }

        // Combina el movimiento horizontal con la velocidad vertical en un vector 3D
        Vector3 movement = horizontalMovement + new Vector3(0, ySpeed, 0);

        // Mueve el jugador usando CharacterController.Move
        controller.Move(movement * Time.deltaTime);

        // Verifica si el jugador está en el suelo
        if (controller.isGrounded)
        {
            // El jugador está en el suelo, por lo que restablecemos `ySpeed` y `canDoubleJump`
            isGrounded = true;
            ySpeed = 0f; // Restablece `ySpeed` a cero cuando está en el suelo
            canDoubleJump = false; // Restablece `canDoubleJump` a `false` cuando está en el suelo
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.CompareTag("Comida")){
            Destroy(hit.gameObject);
        }
    }
}




