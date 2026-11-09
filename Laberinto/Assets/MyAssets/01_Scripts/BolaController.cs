using UnityEngine;
using UnityEngine.InputSystem;
public class BolaController : MonoBehaviour
{

    [SerializeField] float fuerzaEmpuje = 10f;
    [SerializeField] float fuerzaTorsion = 3f;

    [SerializeField] InputActionAsset inputActions;

    Rigidbody rb;
    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = inputActions.FindAction("Player/Move");
    }

    void OnEnable()
    {
        if (moveAction != null)
            moveAction.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null)
            moveAction.Disable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movimiento = moveAction.ReadValue<Vector2>();

        // Empujes hacia delante y atrás
        Vector3 empuje = new Vector3(
            0f,
            0f,
            movimiento.y * fuerzaEmpuje
        );

        rb.AddForce(empuje, ForceMode.Force);

        // Torsiones hacia los lados
        Vector3 torsion = new Vector3(
            0f,
            0f,
            -movimiento.x * fuerzaTorsion
        );

        rb.AddTorque(torsion, ForceMode.Force);
    }
}
