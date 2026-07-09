using UnityEngine;

public class TreeDestroyScript: MonoBehaviour
{
    public float Health = 100f;
    public GameObject standingTreeObject;
    public GameObject fallenTreeObject;
    public GameObject woodLogObject;
    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            FallDown();
        }
    }
    private void FallDown()
    {
        standingTreeObject.SetActive(false);
        fallenTreeObject.SetActive(true);
        if (woodLogObject != null)
        {
            woodLogObject.SetActive(true);
        }
        Collider standingCol = standingTreeObject.GetComponent<Collider>();
        if (standingCol != null) standingCol.enabled = false;
        Debug.Log("tree is chopped");
    }
}