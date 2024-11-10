using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PassTroughtLevels : MonoBehaviour
{
    public List<Locations> levelsDestiny;
    private Transform pjRef;
    private void Awake()
    {
        levelsDestiny = new List<Locations>();
    }
    private void Start()
    {
        levelsDestiny = new List<Locations>(GameObject.FindObjectsOfType<Locations>());
        levelsDestiny = levelsDestiny.OrderBy(x => x.ID).ToList();
        pjRef = GameManager.instance.player.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter1"))
        {
            print(levelsDestiny[0].gameObject.transform.position);
            pjRef.position = levelsDestiny[0].gameObject.transform.position;
        }
        if (collision.CompareTag("Teleporter2"))
        {
            print(levelsDestiny[1].gameObject.transform.position);
            pjRef.position = levelsDestiny[1].gameObject.transform.position;
        }
    }
    private IEnumerator FadeToLevel()
    {
        yield return null;
    }
}
