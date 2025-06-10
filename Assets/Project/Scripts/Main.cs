using System;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private string[] contentNameLinkedArray;

    [SerializeField]
    private BaseGem[] contentPrefabLinkedArray;

    [SerializeField]
    private Vector2 boardSize;

    [SerializeField]
    private string initialCellContent;

    private Board board;

    private void Awake()
    {
        var contentDictionary = new Dictionary<string, BaseGem>();
        for (var i = 0; i < contentPrefabLinkedArray.Length; i++)
        {
            var key = contentNameLinkedArray[i];
            var value = contentPrefabLinkedArray[i];
            contentDictionary.Add(key, value);
        }

        board = new Board((int)boardSize.x, (int)boardSize.y, contentDictionary, OnCellClicked);

        if (string.IsNullOrEmpty(initialCellContent))
        {
            return;
        }

        for (var i = 0; i < boardSize.x; i++)
        {
            for (var j = 0; j < boardSize.y; j++) {
                board.SetCell(i, j, initialCellContent);
            }
        }
    }

    private void OnCellClicked(BaseGem clickedGem)
    {
        var score = 0;
        for (var i = 0; i < boardSize.x; i++)
        {
            for (var j = 0; j < boardSize.y; j++)
            {
                var cell = board.GetCell(i, j);
                if (cell.IsMatching(clickedGem))
                {
                    score += cell.OnMatch();
                }
            }
        }

        Debug.Log(score);
        RefreshBoard();
    }

    private void RefreshBoard()
    {
        var score = 0;
        for (var i = 0; i < boardSize.x; i++)
        {
            for (var j = 0; j < boardSize.y; j++)
            {
                var randomContentIndex = UnityEngine.Random.Range(0, contentNameLinkedArray.Length);
                board.SetCell(i, j, contentNameLinkedArray[randomContentIndex]);
            }
        }
    }
}
