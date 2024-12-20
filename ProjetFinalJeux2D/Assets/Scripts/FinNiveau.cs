using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Ce script gère la fin du niveau 1.
/// Lorsque le joueur atteint la zone de fin, un Canvas de fin est affiché, 
/// et le niveau 2 est chargé après un délai.
/// </summary>
public class FinNiveau1 : MonoBehaviour
{
    /// <summary>
    /// Référence au Canvas affichant la fin du niveau.
    /// </summary>
    public GameObject canvasFinDeNiveau;
    
    /// <summary>
    /// Temps avant de passer au niveau 2.
    /// </summary>
    public float delaiAvantChangement = 3f;

    /// <summary>
    /// Désactive le Canvas de fin de niveau au démarrage.
    /// </summary>
    void Start()
    {
        if (canvasFinDeNiveau != null)
        {
            canvasFinDeNiveau.SetActive(false); // Le Canvas n'est pas visible au début
        }
    }

    /// <summary>
    /// Déclenché lorsqu'un autre objet entre dans la zone de fin.
    /// </summary>
    /// <param name="other">L'objet entrant dans la zone de fin.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le collider appartient à l'objet avec le tag "Joueur"
        if (other.CompareTag("Joueur"))
        {
            // Affiche le Canvas de fin de niveau
            if (canvasFinDeNiveau != null)
            {
                canvasFinDeNiveau.SetActive(true);
            }

            Debug.Log("Chargement du prochain niveau après un délai...");
            // Démarre la coroutine pour charger le niveau suivant après un délai
            StartCoroutine(AttendreEtChargerNiveauSuivant());
        }
    }

    /// <summary>
    /// Coroutine qui attend un délai spécifié avant de charger le niveau suivant.
    /// </summary>
    IEnumerator AttendreEtChargerNiveauSuivant()
    {
        yield return new WaitForSeconds(delaiAvantChangement);
        // Charge la scène du niveau 2
        SceneManager.LoadScene("Niveau2");
    }
}
