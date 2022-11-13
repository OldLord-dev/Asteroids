using UnityEngine;

public class ScreenWraping : MonoBehaviour
{
    private Vector3 boxColliderSize;
    private BoxCollider2D boxCollider;
    void Start()
    {
        boxColliderSize = -Camera.main.ScreenToWorldPoint(Vector3.zero)*2;
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2 (boxColliderSize.x, boxColliderSize.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ScreenWrap(collision.gameObject);
    }
    private void ScreenWrap(GameObject go)
    {
        Camera cam = Camera.main;
        Vector3 viewportPosition = cam.WorldToViewportPoint(go.transform.position);
        Vector3 newPosition = go.transform.position;
        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x;
        }

        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
        }
        go.transform.position = newPosition;
    }
}
   