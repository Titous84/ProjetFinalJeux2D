using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; // Nécessaire pour utiliser IEnumerator et les coroutines

/// <summary>
/// Gère l'affichage du niveau en cours, les points du joueur, et la fin du niveau.
/// Adapté pour le niveau 1.
/// </summary>
public class GestionCanvasInGameNiv1 : MonoBehaviour
{
    public TextMeshProUGUI texteNiveau; // Texte pour afficher le niveau en cours
    public GameObject canvasFinNiveau; // Canvas pour afficher la fin du niveau
    public TextMeshProUGUI texteFinPoints; // Texte pour afficher le nombre de points dans le canvas de fin de niveau
    public float delaiAvantChangement = 3f; // Délai avant de passer au niveau suivant

    private int points = 0; // Points du joueur

    void Start()
    {
        // Affiche le nom de la scène actuelle comme niveau
        if (texteNiveau != null)
        {
            texteNiveau.text = "Niveau 1"; // Indique explicitement que c'est le niveau 1
        }

        // Désactive le canvas de fin de niveau au début
        if (canvasFinNiveau != null)
        {
            canvasFinNiveau.SetActive(false);
        }

        // Initialise l'affichage des points
        if (texteFinPoints != null)
        {
            texteFinPoints.text = "Points : " + points;
        }
    }

    /// <summary>
    /// Ajoute des points au joueur.
    /// </summary>
    /// <param name="pointsAjoutes">Le nombre de points à ajouter.</param>
    public void AjouterPoints(int pointsAjoutes)
    {
        points += pointsAjoutes;
        if (texteFinPoints != null)
        {
            texteFinPoints.text = "Points : " + points;
        }
    }

    /// <summary>
    /// Fonction appelée pour terminer le niveau.
    /// </summary>
    public void FinNiveau()
    {
        Debug.Log("Vous avez terminé le niveau 1 avec " + points + " points !");
        
        // Affiche le canvas de fin de niveau
        if (canvasFinNiveau != null)
        {
            canvasFinNiveau.SetActive(true);
        }

        // Affiche un message de fin personnalisé
        if (texteFinPoints != null)
        {
            texteFinPoints.text = "Félicitations ! Vous avez terminé le niveau 1 avec " + points + " points.";
        }

        // Transition automatique vers le niveau suivant après un délai
        StartCoroutine(ChargerNiveauSuivant(delaiAvantChangement));
    }

    /// <summary>
    /// Coroutine pour charger le niveau suivant après un délai.
    /// </summary>
    /// <param name="delai">Temps à attendre avant de changer de niveau.</param>
    private IEnumerator ChargerNiveauSuivant(float delai)
    {
        yield return new WaitForSecondsRealtime(delai); // Attend même si le temps est en pause
        Time.timeScale = 1; // Remet le temps à la normale
        SceneManager.LoadScene("Niveau2"); // Charge la scène "Niveau 2" (remplacez par le nom exact)
    }
}
