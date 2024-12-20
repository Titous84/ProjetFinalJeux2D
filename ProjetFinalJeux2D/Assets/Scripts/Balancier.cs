using UnityEngine;

/// <summary>
/// Fait osciller un objet comme un balancier, même si le pivot est en bas.
/// </summary>
public class Balancier : MonoBehaviour
{
    public float amplitude = 45f; // Amplitude du balancier en degrés
    public float vitesse = 2f; // Vitesse de l'oscillation

    private Vector3 positionFixe; // Position simulée du point d'attache (le haut de la chaîne)

    void Start()
    {
        // Stocke la position initiale du point d'attache simulé (haut de la chaîne)
        positionFixe = transform.position + Vector3.up * (transform.localScale.y / 2f); // Ajustez si nécessaire
    }

    void Update()
    {
        // Calcule l'angle d'oscillation en fonction du temps
        float angleOscillant = Mathf.Sin(Time.time * vitesse) * amplitude;

        // Effectue une rotation autour du point d'attache simulé
        transform.position = positionFixe + Quaternion.Euler(0, 0, angleOscillant) * Vector3.down * (transform.localScale.y / 2f);
        transform.rotation = Quaternion.Euler(0, 0, angleOscillant);
    }
}
