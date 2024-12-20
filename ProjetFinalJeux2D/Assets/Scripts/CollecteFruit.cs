using UnityEngine;

/// <summary>
/// Ce script gère la collecte des fruits.
/// Il joue un son associé au fruit et ajoute des points lorsque le joueur collecte un fruit.
/// </summary>
public class CollecteFruit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Joueur"))
        {
            // Joue le son de collecte si un AudioSource est disponible sur ce GameObject
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play(); // Joue le son associé au fruit
            }

            // Augmente les points du joueur
            GestionCanvasInGame gestionCanvas = FindObjectOfType<GestionCanvasInGame>();
            if (gestionCanvas != null)
            {
                gestionCanvas.AjouterPoints(1); // Ajoute 1 point par fruit collecté
            }

            // Détruit l'objet fruit après la collecte
            Destroy(gameObject, 0.1f); // Laisse un court délai avant la destruction pour jouer le son
        }
    }
}
