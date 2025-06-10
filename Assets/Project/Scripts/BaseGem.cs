using System;
using UnityEngine;
using UnityEngine.UIElements;

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
        gemButton.clicked += OnGemClicked;
    }

    private void OnDisable()
    {
        gemButton.clicked += OnGemClicked;
    }

    private void OnGemClicked()
    {
        onClicked?.Invoke();
    }

    public abstract void OnMatch();
    public abstract bool IsMatching(BaseGem gem);
    public abstract void OnCreated();
    public abstract void Destroy(Action onComplete);
}
