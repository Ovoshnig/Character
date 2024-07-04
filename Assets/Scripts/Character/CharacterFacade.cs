using UnityEngine;

[RequireComponent(typeof(CharacterMover),
                  typeof(Interactions))]
public class CharacterFacade : MonoBehaviour
{
    private CharacterMover _characterMover;
    private Interactions _interactions;

    private void Awake()
    {
        _characterMover = GetComponent<CharacterMover>();
        _interactions = GetComponent<Interactions>();
    }

    private void Update() => _characterMover.HandleMovement();
    private void OnTriggerEnter(Collider other) => _interactions.OnTriggerEnter(other);
    private void OnTriggerExit(Collider other) => _interactions.OnTriggerExit(other);
}
