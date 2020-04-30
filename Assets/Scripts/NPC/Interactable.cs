using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    bool hasInterectd = false;

     void Update()
    {
        if (isFocus && !hasInterectd)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Debug.Log("Interact");
                hasInterectd = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInterectd = false;

    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInterectd = false;
    }

    void OnDrawGizsmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
