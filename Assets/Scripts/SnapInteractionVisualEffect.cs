using UnityEngine;
using Oculus.Interaction;

public class SnapInteractionVisualEffect : MonoBehaviour
{
    [SerializeField] private GameObject ghostA;
    [SerializeField] private GameObject ghostB;

    private SnapInteractable snap;

    private void Awake()
    {
        snap = GetComponent<SnapInteractable>();
    }

    private void OnEnable()
    {
        snap.WhenInteractorViewAdded += OnHover;
        snap.WhenInteractorViewRemoved += OnUnhover;
        snap.WhenSelectingInteractorViewAdded += OnSelect;
    }

    private void OnDisable()
    {
        snap.WhenInteractorViewAdded -= OnHover;
        snap.WhenInteractorViewRemoved -= OnUnhover;
        snap.WhenSelectingInteractorViewAdded -= OnSelect;
    }

    private void OnHover(IInteractorView interactor)
    {
        SnapInteractor snapInteractor = interactor as SnapInteractor;

        if (snapInteractor == null)
            return;

        if (snapInteractor.gameObject.CompareTag("Tape"))
        {
            ghostA.transform.position = snap.transform.position;
            ghostA.transform.rotation = snap.transform.rotation;

            ghostA.SetActive(true);
            ghostB.SetActive(false);
        }
        else if (snapInteractor.gameObject.CompareTag("Screwdriver"))
        {
            ghostB.transform.position = snap.transform.position;
            ghostB.transform.rotation = snap.transform.rotation;

            ghostA.SetActive(false);
            ghostB.SetActive(true);
        }
    }

    private void OnUnhover(IInteractorView interactor)
    {
        ghostA.SetActive(false);
        ghostB.SetActive(false);
    }

    private void OnSelect(IInteractorView interactor)
    {
        ghostA.SetActive(false);
        ghostB.SetActive(false);
    }
}