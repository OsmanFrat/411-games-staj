using UnityEngine;

public class Fx : MonoBehaviour
{
    [SerializeField] private ParticleSystem cubeExplosionFx;

    ParticleSystem.MainModule cubeExplosionFxMainModule;

    // singleton class
    public static Fx Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cubeExplosionFxMainModule = cubeExplosionFx.main;
    }

    public void PlayCubeExplosionFx(Vector3 position, Color color)
    {
        cubeExplosionFxMainModule.startColor = new ParticleSystem.MinMaxGradient(color);
        cubeExplosionFx.transform.position = position;
        cubeExplosionFx.Play();
    }
}
