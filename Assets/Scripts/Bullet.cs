using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed=20;
    // Update is called once per frame
    private void OnEnable()
    {
        StartCoroutine("Wait2Seconds");
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 4 * speed * Time.deltaTime, 0));
    }
    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}

