using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Interactor Settings")]
    public float interactDistance;
    public LayerMask interactLayerMask = ~0; // Iteracts with all layers by default
    public Vector3 playerInteractHeight = new Vector3(0,1f,0);

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = new Ray(transform.position + playerInteractHeight, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayerMask))
            {
                Debug.Log($"Interacted with: {hit.collider.name}");

                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<DoorOpen>().doorOpen = true;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + playerInteractHeight, transform.position + playerInteractHeight + transform.forward * interactDistance);
    }
}
