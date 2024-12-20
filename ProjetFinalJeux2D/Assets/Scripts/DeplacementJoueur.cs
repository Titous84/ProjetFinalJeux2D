using UnityEngine;

/// <summary>
/// Ce script gère les déplacements du joueur : marcher à gauche/droite et sauter.
/// </summary>
public class DeplacementJoueur : MonoBehaviour
{
    public float vitesse = 5f; // Vitesse de déplacement du joueur
    public float forceDeSaut = 10f; // Force de saut du joueur
    private Rigidbody2D rb;

    /// <summary>
    /// Initialisation des composants nécessaires.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Récupère le composant Rigidbody2D pour gérer la physique du joueur
    }

    /// <summary>
    /// Gère les entrées du joueur à chaque image.
    /// </summary>
    void Update()
    {
        // Récupère l'entrée horizontale (gauche/droite)
        float mouvement = Input.GetAxis("Horizontal");
        
        // Applique la vitesse de déplacement au Rigidbody2D
        rb.velocity = new Vector2(mouvement * vitesse, rb.velocity.y);

        // Vérifie si le joueur appuie sur "Jump" et s'il est au sol pour sauter
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, forceDeSaut), ForceMode2D.Impulse);
        }
    }
}
