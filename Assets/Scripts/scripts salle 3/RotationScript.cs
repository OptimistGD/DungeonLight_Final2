using UnityEngine;
using UnityEngine.UI; // si tu utilises Text
// using TMPro; // si tu utilises TextMeshPro

public class RotatingObject : MonoBehaviour
{
    public float rotationStep = 90f;
    public Vector3 correctRotation;
    public float rotationTolerance = 1f;

    private bool playerInside = false;
    public bool isCorrect = false;

    [Header("UI d'interaction")]
    public GameObject interactionUI; // un panel ou texte à activer/désactiver

    private void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (playerInside && Input.GetMouseButtonDown(0)) // clic gauche
        {
            RotateObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (interactionUI != null)
                interactionUI.SetActive(true); // afficher le message
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (interactionUI != null)
                interactionUI.SetActive(false); // cacher le message
        }
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.up, rotationStep);

        Vector3 currentRot = transform.eulerAngles;
        bool xOk = Mathf.Abs(Mathf.DeltaAngle(currentRot.x, correctRotation.x)) < rotationTolerance;

        isCorrect = xOk;

        PuzzleManager.Instance?.CheckAllObjects();
    }
}