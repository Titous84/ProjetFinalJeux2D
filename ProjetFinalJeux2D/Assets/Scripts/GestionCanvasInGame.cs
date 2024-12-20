using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Ce script gère l'affichage du niveau en cours, les points du joueur, et la fin de partie.
/// </summary>
public class GestionCanvasInGame : MonoBehaviour
{
    public TextMeshProUGUI texteNiveau; // Référence au texte affichant le niveau en cours
    public GameObject canvasConfirmation; // Canvas pour confirmer si le joueur souhaite quitter ou recommencer
    public TextMeshProUGUI texteQuestionJoueur; // Référence au texte de la question dans le canvas de confirmation
    public TextMeshProUGUI textePoints; // Référence au texte affichant les points du joueur
    public GameObject canvasFinNiveau; // Canvas pour afficher la fin du niveau et les points
    public TextMeshProUGUI texteFinPoints; // Texte pour afficher le nombre de points dans le canvas de fin de niveau

    private int points = 0; // Points du joueur

    void Start()
    {
        // Affiche le nom de la scène actuelle comme niveau
        if (texteNiveau != null)
        {
            texteNiveau.text = "" + SceneManager.GetActiveScene().name;
        }

        // Désactive le canvas de confirmation et le canvas de fin de niveau au début
        if (canvasConfirmation != null)
        {
            canvasConfirmation.SetActive(false);
        }

        if (canvasFinNiveau != null)
        {
            canvasFinNiveau.SetActive(false);
        }

        // Initialise l'affichage des points
        if (textePoints != null)
        {
            textePoints.text = "Points : " + points;
        }
    }

    /// <summary>
    /// Ajoute des points au joueur.
    /// </summary>
    /// <param name="pointsAjoutes">Le nombre de points à ajouter.</param>
    public void AjouterPoints(int pointsAjoutes)
    {
        points += pointsAjoutes;
        if (textePoints != null)
        {
            textePoints.text = "Points : " + points;
        }
    }

    /// <summary>
    /// Fonction appelée pour terminer le niveau.
    /// </summary>
    public void FinNiveau()
    {
        Debug.Log("Niveau terminé avec " + points + " points !");
        
        // Affiche le canvas de fin de niveau avec le nombre de points gagnés
        if (canvasFinNiveau != null)
        {
            canvasFinNiveau.SetActive(true);
        }

        if (texteFinPoints != null)
        {
            texteFinPoints.text = "Vous avez terminé le niveau avec " + points + " points !";
        }

        Time.timeScale = 0; // Met le jeu en pause pour marquer la fin
    }

    /// <summary>
    /// Appelé lorsque le joueur clique sur le bouton "Quitter InGame".
    /// Affiche une boîte de dialogue de confirmation.
    /// </summary>
    public void BoutonQuitterInGame()
    {
        if (canvasConfirmation != null)
        {
            canvasConfirmation.SetActive(true);
            if (texteQuestionJoueur != null)
            {
                texteQuestionJoueur.text = "Souhaitez-vous quitter le jeu ou recommencer ?";
            }
            Time.timeScale = 0; // Met le jeu en pause
        }
    }

    /// <summary>
    /// Fonction appelée lorsque le joueur confirme de quitter le jeu.
    /// </summary>
    public void QuitterJeu()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit(); // Quitte l'application (ne fonctionne que dans un build, pas dans l'éditeur)
    }

    /// <summary>
    /// Fonction appelée lorsque le joueur choisit de recommencer le niveau.
    /// </summary>
    public void RecommencerNiveau()
    {
        Time.timeScale = 1; // Remet le temps à la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }

    /// <summary>
    /// Fonction appelée pour annuler la demande de quitter ou recommencer.
    /// </summary>
    public void AnnulerQuitter()
    {
        if (canvasConfirmation != null)
        {
            canvasConfirmation.SetActive(false);
            Time.timeScale = 1; // Remet le temps à la normale
        }
    }
}
