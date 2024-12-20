using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger une nouvelle scène ou quitter l'application

/// <summary>
/// Ce script vérifie si tous les fruits ont été collectés pour terminer le niveau.
/// </summary>
public class FinNiveauFinal : MonoBehaviour
{
    private GameObject[] fruits; // Tableau qui contient tous les fruits du niveau
    public GameObject canvasFinDePartie; // Référence au Canvas contenant les boutons "Recommencer" et "Quitter"

    /// <summary>
    /// Initialise la liste des fruits au début du niveau.
    /// </summary>
    void Start()
    {
        // Récupère tous les objets avec le tag "Fruit"
        fruits = GameObject.FindGameObjectsWithTag("Fruit");

        // Désactive le canvas de fin de partie au début
        if (canvasFinDePartie != null)
        {
            canvasFinDePartie.SetActive(false);
        }
    }

    /// <summary>
    /// Déclenché lorsqu'un autre objet entre en collision avec la zone de fin.
    /// </summary>
    /// <param name="other">L'objet entrant en collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet entrant est le joueur et si tous les fruits ont été collectés
        if (other.CompareTag("Joueur") && TousFruitsCollectes())
        {
            // Affiche le canvas de fin de partie
            if (canvasFinDePartie != null)
            {
                canvasFinDePartie.SetActive(true); // Affiche le message de fin et les boutons
            }

            Debug.Log("Félicitations, vous avez terminé le jeu !");
            Time.timeScale = 0; // Met le jeu en pause pour la fin de partie
        }
    }

    /// <summary>
    /// Vérifie si tous les fruits ont été collectés.
    /// </summary>
    /// <returns>Retourne vrai si aucun fruit n'est présent sur la carte, sinon faux.</returns>
    bool TousFruitsCollectes()
    {
        return GameObject.FindGameObjectsWithTag("Fruit").Length == 0;
    }

    /// <summary>
    /// Fonction appelée pour recommencer le niveau.
    /// </summary>
    public void Recommencer()
    {
        Time.timeScale = 1; // Remet le temps à la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }

    /// <summary>
    /// Fonction appelée pour quitter le jeu.
    /// </summary>
    public void Quitter()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit(); // Quitte l'application (ne fonctionne que dans un build, pas dans l'éditeur)
    }
}
