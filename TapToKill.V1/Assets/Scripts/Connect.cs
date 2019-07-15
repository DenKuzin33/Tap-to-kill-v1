using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    private UnityEvent onConnect;
    [SerializeField]
    InputField ipField;
    [SerializeField]
    Text failed;

    private void Awake() 
    {
        Screen.autorotateToPortrait = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    private void Start()
    { 
        failed.gameObject.SetActive(false);
        onConnect = new UnityEvent();
        onConnect.AddListener(StartGame);
    }

    private bool Connection(string addres)
    {
        if(addres != "")
        return true;
        return false;
    }

    public void ConnectButton()
    {
        if(Connection(ipField.text))
        onConnect.Invoke();
        else failed.gameObject.SetActive(true);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
