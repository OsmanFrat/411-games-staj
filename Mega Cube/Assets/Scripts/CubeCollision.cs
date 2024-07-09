using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    Cube cube;

    private void Awake()
    {
        cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Cube otherCube = collision.gameObject.GetComponent<Cube>();

        // check if contacted with other cube
        if (otherCube != null && cube.CubeID > otherCube.CubeID)
        {
            // check if both cubes have same number
            if (cube.cubeNumber == otherCube.cubeNumber)
            {
                Debug.Log("Hit: " + cube.cubeNumber);

                Vector3 contactPoint = collision.contacts[0].point;

                // check if cubes number less than max number in CubeSpawn
                if (otherCube.cubeNumber < CubeSpawn.Instance.maxCubeNumber)
                {
                    // spawn a new cube as a result
                    Cube newCube = CubeSpawn.Instance.Spawn(cube.cubeNumber * 2, contactPoint + Vector3.up * 1.6f);
                    // push the new cube up and forward:
                    float pushForce = 2.5f;
                    newCube.cubeRigidbody.AddForce(new Vector3(0, .3f, 1f) * pushForce, ForceMode.Impulse);

                    // add some torque:
                    float randomValue = UnityEngine.Random.Range(-20, 20f);
                    Vector3 randomDirection = Vector3.one * randomValue;
                    newCube.cubeRigidbody.AddTorque(randomDirection);
                }

                // the explosion should affect surrounded cubes too:
                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach (Collider coll in surroundedCubes)
                {
                    if (coll.attachedRigidbody != null)
                    {
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                    }

                    Fx.Instance.PlayCubeExplosionFx(contactPoint, cube.cubeColor);

                    // Destroy the two cubes
                    CubeSpawn.Instance.DestroyCube(cube);
                    CubeSpawn.Instance.DestroyCube(otherCube);
                }
            }


        }
    }

}
