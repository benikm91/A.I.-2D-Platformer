using UnityEngine;

[RequireComponent(typeof(InteractableWatcher))]
public class PlayerInputController : MonoBehaviour, IJetpackInput, IHorizontalMovementInput
{

    public bool BoostRequest { get; private set; }
    public float HorizontalMovementRequest { get; private set; }

    private InteractableWatcher _interactableWatcher;

    private void Awake()
    {
        _interactableWatcher = GetComponent<InteractableWatcher>();
    }

    void Update()
    {
        BoostRequest = Input.GetButton("Action") && _interactableWatcher.Interactable == null;
        if (Input.GetButtonDown("Action") && _interactableWatcher.Interactable != null)
        {
            _interactableWatcher.Interactable.Interact(gameObject);
        }
        HorizontalMovementRequest = Input.GetAxisRaw("Horizontal");

    }

}
