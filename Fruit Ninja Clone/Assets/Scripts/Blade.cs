using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrail;
    public float minCuttingVelocity = .001f;

    [SerializeField] private bool isCutting = false;

    [SerializeField] private Vector2 previousPosition;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D bladeCollider;
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject currentBladeTrail;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bladeCollider = GetComponent<CircleCollider2D>();

        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        
        if (velocity > minCuttingVelocity)
        {
            bladeCollider.enabled = true;
        }
        else
        {
            bladeCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rb.position;
       
        currentBladeTrail = Instantiate(bladeTrail, transform);
        bladeCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        bladeCollider.enabled = false;
        Destroy(currentBladeTrail, 2f);
    }
}
