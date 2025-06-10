using System;
using UnityEngine;

[System.Serializable]
public class Cell
{
    private BaseGem existingGem;

    public event Action<BaseGem> OnCellClickedEvent;

    public bool IsFull => existingGem != null;

    public void Set(BaseGem gemPrefab, Vector2 position)
    {
        if (existingGem != null)
        {
            existingGem.Destroy(() => CreateNewGem(gemPrefab, position));
            existingGem.onClicked -= OnGemClicked;
            UnityEngine.Object.Destroy(existingGem);
            return;
        }

        CreateNewGem(gemPrefab, position);
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

    private void CreateNewGem(BaseGem gemPrefab, Vector2 position)
    {
        existingGem = UnityEngine.Object.Instantiate(gemPrefab, position, Quaternion.identity);
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
            UnityEngine.Object.Destroy(existingGem);
        }
    }
}
