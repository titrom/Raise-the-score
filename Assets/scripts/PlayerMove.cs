using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    public float Spead = 1.0f;
    public InputAction Controle;


    private Vector2 move = Vector2.zero;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        Controle.Enable();
    }
    private void OnDisable()
    {
        Controle.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = Controle.ReadValue<Vector2>();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * Spead, move.y * Spead);
    }

}
