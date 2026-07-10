using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPosition;
    public GameObject currentActiveAxe;
    private GameObject heldObject;
    public AudioSource audioSource;
    public AudioClip pickupSound;
    public AudioClip dropSound;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null) TryPickup();
            else TryPlace();
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

                if (currentActiveAxe != null) currentActiveAxe.SetActive(false);
            }
        }
    }
    void TryPlace()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            Placewood snap = hit.collider.GetComponent<Placewood>();
            if (snap != null)
            {
                if (snap.TryPlace(heldObject))
                {
                    Destroy(heldObject);
                    heldObject = null;
                    if (currentActiveAxe != null)
                    {
                        currentActiveAxe.SetActive(true);
                    }
                }
                else
                {
                    DropObject();
                }
            }
            else
            {
                DropObject();
            }
        }
        else
        {
            DropObject();
        }
    }
    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.parent = null;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            if (currentActiveAxe != null) currentActiveAxe.SetActive(true);
            if (dropSound != null) audioSource.PlayOneShot(dropSound);

            heldObject = null;
            if (currentActiveAxe != null) currentActiveAxe.SetActive(true);
        }
    }
}
