using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseGem : MonoBehaviour
{
    [SerializeField]
    private Button gemButton;

    [SerializeField]
    private int score = 1;

    public int Score => score;

    public event Action onClicked;
    private void OnEnable()
    {
        gemButton.onClick.AddListener(OnGemClicked);
    }

    private void OnDisable()
    {
        gemButton.onClick.RemoveListener(OnGemClicked);
    }

    public void OnGemClicked()
    {
        Debug.Log("Clicked");
        onClicked?.Invoke();
    }

    public abstract void OnMatch();
    public abstract bool IsMatching(BaseGem gem);
    public abstract void OnCreated();
    public abstract void Destroy(Action onComplete);
}
