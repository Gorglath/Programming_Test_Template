using System;
using UnityEngine;

[System.Serializable]
public class Cell
{
    private BaseGem existingGem;

    public event Action<BaseGem> OnCellClickedEvent;

    public bool IsFull => existingGem != null;

    public void Set(BaseGem gemPrefab, Vector2 position, RectTransform gemsContainer)
    {
        if (existingGem != null)
        {
            existingGem.Destroy(() => CreateNewGem(gemPrefab, position, gemsContainer));
            existingGem.onClicked -= OnGemClicked;
            UnityEngine.Object.Destroy(existingGem.gameObject);
            return;
        }

        CreateNewGem(gemPrefab, position, gemsContainer);
    }

    private void OnGemClicked()
    {
        OnCellClickedEvent?.Invoke(existingGem);
    }

    public int OnMatch()
    {
        var score = existingGem.Score;
        Dispose();
        return score;
    }

    private void CreateNewGem(BaseGem gemPrefab, Vector2 position, RectTransform gemsContainer)
    {
        existingGem = UnityEngine.Object.Instantiate(gemPrefab, position, Quaternion.identity, gemsContainer);
        existingGem.OnCreated();
        existingGem.onClicked += OnGemClicked;
    }

    public bool IsMatching(BaseGem gem)
    {
        if(existingGem ==  null)
        {
            return false;
        }

        return existingGem.IsMatching(gem);
    }

    public void Dispose()
    {
        if (existingGem != null)
        {
            existingGem.onClicked -= OnGemClicked;
            UnityEngine.Object.Destroy(existingGem.gameObject);
            existingGem = null;
        }
    }
}
