using UnityEngine;

/// <summary>
/// Fait osciller un objet parent, autour de son propre pivot (point d'attache).
/// </summary>
public class BalancierPivotFixe : MonoBehaviour
{
    public float amplitude = 45f; // Amplitude en degrés
    public float vitesse = 2f; // Vitesse de l'oscillation

    void Update()
    {
        // Calcule l'angle d'oscillation en fonction du temps
        float angleOscillant = Mathf.Sin(Time.time * vitesse) * amplitude;

        // Applique une rotation autour du point pivot
        transform.rotation = Quaternion.Euler(0, 0, angleOscillant);
    }
}
