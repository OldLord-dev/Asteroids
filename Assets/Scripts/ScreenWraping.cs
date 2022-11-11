//using System.Collections;
//using Unity.VisualScripting;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class ScreenWraping : MonoBehaviour
{
    SpriteRenderer[] renderers;
    private bool isWrappingX = false;
    private bool isWrappingY = false;

    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }
    void Update()
    {
        ScreenWrap();
    }

    private bool CheckRenderers()
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }
    private void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY)
        {
            return;
        }

        Camera cam = Camera.main;
        Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
        Vector3 newPosition = transform.position;

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;

            isWrappingX = true;
        }

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }

        transform.position = newPosition;
    }
}
   