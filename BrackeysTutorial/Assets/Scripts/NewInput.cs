using UnityEngine;

public class NewInput : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 2000f;
    public float rotationSpeed = 2000f;
    public float yatayharekethızı = 10f; 
    public float solDuvarPozisyon;
    public float sagDuvarPozisyon;

    [Range(0,2)]
    public float max_accel;
    [SerializeField] private float current_accel;
    public float max_accel_reach_time;

    void Start()
    {
        // Initialize Rigidbody
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        rb.AddForce(forwardForce * Time.deltaTime, 0, 0);

        Vector3 mevcut_pozisyon = transform.position;

        if (Input.GetKey("d"))
        {
            current_accel += max_accel * Time.deltaTime / max_accel_reach_time; 
            mevcut_pozisyon.z -= Mathf.Min(current_accel, yatayharekethızı) * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            current_accel += max_accel * Time.deltaTime / max_accel_reach_time; 
            mevcut_pozisyon.z += Mathf.Min(current_accel, yatayharekethızı) * Time.deltaTime;
        }
        else
        {
            current_accel = 0;
        }

        // Clamp the position
        mevcut_pozisyon.z = Mathf.Clamp(mevcut_pozisyon.z, sagDuvarPozisyon, solDuvarPozisyon - transform.localScale.z / 2);
        transform.position = mevcut_pozisyon;
    }
}

