using UnityEngine;

public class NewInput : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 2000f;
    public float rotationSpeed = 2000f;
    public float yatayharekethızı = 10f; // Increased this for noticeable movement
    public float sağduvarpozisyon;
    public float ivme;
    public float ivmeArtışHızı; // Increased this for noticeable acceleration

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
            ivme += ivmeArtışHızı * Time.deltaTime; // Increase acceleration
            mevcut_pozisyon.z -= Mathf.Min(ivme, yatayharekethızı) * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            ivme += ivmeArtışHızı * Time.deltaTime; // Increase acceleration
            mevcut_pozisyon.z += Mathf.Min(ivme, yatayharekethızı) * Time.deltaTime;
        }
        else
        {
            ivme = 0; // Reset acceleration if no keys are pressed
        }

        // Clamp the position
        mevcut_pozisyon.z = Mathf.Clamp(mevcut_pozisyon.z, -71.3f, sağduvarpozisyon - transform.localScale.x / 2);
        transform.position = mevcut_pozisyon;
    }
}

