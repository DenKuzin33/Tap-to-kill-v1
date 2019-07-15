using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    int point = 1;
    private PointsManager manager;

    private void Start() 
    {
        manager = FindObjectOfType<PointsManager>();
    }

    private void Update() 
    {
        if(Input.touchCount > 0 && !ButtonsHandle.isPaused) 
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject()) 
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(!Physics.Raycast(ray, out hit)) Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown() 
    {
        if(!ButtonsHandle.isPaused)
        {
            if(gameObject.tag == "BadItem") point *=-1;
            manager.RefreshPoints(point);
            Destroy(gameObject);
        }
    }
}