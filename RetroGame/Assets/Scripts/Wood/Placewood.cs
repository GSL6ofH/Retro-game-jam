using UnityEngine;

public class Placewood : MonoBehaviour
{
    public string Wood;
    public GameObject[] woodStages;
    private int currentStage = 0;
    public AudioClip placeSound;
    public bool TryPlace(GameObject heldObject)
    {
        PickUpItem item = heldObject.GetComponent<PickUpItem>();
        if (item != null && item.itemName == Wood && currentStage < woodStages.Length)
        {
            woodStages[currentStage].SetActive(true);
            currentStage++;
            if (placeSound != null)
            {
                AudioSource.PlayClipAtPoint(placeSound, transform.position);
            }
            return true;
        }
        return false;
    }
}