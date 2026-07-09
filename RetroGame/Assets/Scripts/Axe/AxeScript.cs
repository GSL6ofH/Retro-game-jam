using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public Animator anim;
    public float axeDamage = 35f;
    public float maxDistance = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Swing");
        }
    }
    public void PerformRaycastAttack()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            TreeDestroyScript tree = hit.collider.GetComponentInParent<TreeDestroyScript>();
            if (tree != null)
            {
                tree.TakeDamage(axeDamage);
                Debug.Log("Tree hit");
            }
        }
    }
}