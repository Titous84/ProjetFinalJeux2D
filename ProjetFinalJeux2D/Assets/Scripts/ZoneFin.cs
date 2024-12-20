using UnityEngine;

/// <summary>
/// Cette classe gère la fin du niveau lorsqu'un joueur entre dans la zone de fin.
/// </summary>
public class ZoneFin : MonoBehaviour
{
    /// <summary>
    /// Méthode appelée lorsqu'un autre Collider2D entre en collision avec ce trigger.
    /// </summary>
    /// <param name="other">Le Collider2D entrant en collision avec ce trigger.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le collider appartient à l'objet avec le tag "Joueur"
        if (other.CompareTag("Joueur"))
        {
            // Trouve l'objet GestionCanvasInGame dans la scène
            GestionCanvasInGame gestionCanvas = FindObjectOfType<GestionCanvasInGame>();
            
            // Si l'objet GestionCanvasInGame est trouvé, appelle la méthode pour terminer le niveau
            if (gestionCanvas != null)
            {
                gestionCanvas.FinNiveau(); // Appelle la méthode pour terminer le niveau
            }
        }
    }
}
