using UnityEngine;

public class MenuRoomButton : MonoBehaviour
{
    [SerializeField] private string _roomSceneName;

    public string SceneName { get => _roomSceneName; }
}
