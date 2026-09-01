using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPosition;
    public GameObject currentActiveAxe;
    protected GameObject heldObject;
    public AudioSource audioSource;
    public AudioClip pickupSound;
    public AudioClip dropSound;
    public float throwForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickup();
            }
            else
            {
                TryThrowOrPlace();
            }
        }
    }

    void TryPickup()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = holdPosition;

                if (currentActiveAxe != null) currentActiveAxe.SetActive(false);
                if (pickupSound != null) audioSource.PlayOneShot(pickupSound);
            }
        }
    }

    void TryThrowOrPlace()
    {
        ThrowableObject throwable = heldObject.GetComponent<ThrowableObject>();

        if (throwable != null)
        {
            throwable.Throw(Camera.main.transform.forward, throwForce);
            ResetAfterDropOrThrow();
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                Placewood snap = hit.collider.GetComponent<Placewood>();
                if (snap != null && snap.TryPlace(heldObject))
                {
                    Destroy(heldObject);
                    heldObject = null;
                    if (currentActiveAxe != null) currentActiveAxe.SetActive(true);
                    return;
                }
            }
            DropObject();
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.parent = null;
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            ResetAfterDropOrThrow();
        }
    }

    void ResetAfterDropOrThrow()
    {
        heldObject = null;
        if (currentActiveAxe != null) currentActiveAxe.SetActive(true);
        if (dropSound != null) audioSource.PlayOneShot(dropSound);
    }
}