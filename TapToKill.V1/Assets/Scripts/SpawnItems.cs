using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    private GameObject item;
    private GameObject[] itemPrefabs = new GameObject[2];
    Vector2 camMin, camMax, itemHalfSize;

    private void Start() 
    {  
        itemPrefabs[0] = Resources.Load<GameObject>("GoodItem");
        itemPrefabs[1] = Resources.Load<GameObject>("BadItem");
        itemHalfSize = itemPrefabs[0].GetComponent<BoxCollider2D>().size/2;
        camMin = Camera.main.ViewportToWorldPoint (new Vector2 (0,0) + itemHalfSize);
        camMax = Camera.main.ViewportToWorldPoint (new Vector2 (1,1) - itemHalfSize);
    }

    private void Update() 
    {
        if(item==null)
        {
            Vector3 itemPos = new Vector3(Random.Range(camMin.x, camMax.x), Random.Range(camMin.y, camMax.y), 0);
            item = Instantiate(itemPrefabs[Random.Range(0,2)], itemPos, Quaternion.identity);   
        }
    }
}