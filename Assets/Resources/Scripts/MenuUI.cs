using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public void OnRoomButtonPointed(BaseEventData e)
    {
        e.selectedObject.GetComponent<Outline>().effectColor = Color.blue;
    }

    public void OnRoomButtonUnpointed(BaseEventData e)
    {
        e.selectedObject.GetComponent<Outline>().effectColor = Color.black;
    }

    public void OnRoomButtonClick(BaseEventData e)
    {
        string sceneName = e.selectedObject.GetComponent<MenuRoomButton>().SceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
