using System;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private Cell[,] cells;
    private Dictionary<string, BaseGem> contentDictionary;
    private Action<BaseGem> onCellClicked;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Board(int rows, int columns, Dictionary<string, BaseGem> contentDictionary, Action<BaseGem> onCellClicked)
    {
        this.contentDictionary = contentDictionary;
        this.onCellClicked = onCellClicked;
        Rows = rows;
        Columns = columns;
        cells = new Cell[rows, columns];

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                cells[r, c] = new Cell();
                cells[r, c].OnCellClickedEvent += OnCellClicked;
            }
        }
    }

    private void OnCellClicked(BaseGem clickedGem)
    {
        onCellClicked?.Invoke(clickedGem);
    }

    public Cell GetCell(int row, int column)
    {
        if (!IsInBounds(row, column))
            return null;
        return cells[row, column];
    }

    public void SetCell(int row, int column, string content)
    {
        if (!IsInBounds(row, column))
            return;

        cells[row, column].Set(contentDictionary[content], new Vector2(row, column));
    }

    public bool IsInBounds(int row, int column)
    {
        return row >= 0 && row < Rows && column >= 0 && column < Columns;
    }

    public void Clear()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                cells[r, c].Dispose();
                cells[r, c].OnCellClickedEvent -= OnCellClicked;
            }
        }
    }
}
