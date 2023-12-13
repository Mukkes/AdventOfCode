﻿using System.Data.Common;

namespace AdventOfCodeLibrary.Models;
public class Map2D<T>
{
    private List<List<T>> _map = new List<List<T>>();

    public void AddRow(T[] items)
    {
        var row = new List<T>();
        foreach (var item in items)
        {
            row.Add(item);
        }
        _map.Add(row);
    }

    public List<T> GetRow(int row)
    {
        return _map[row];
    }

    public List<List<T>> GetRows()
    {
        return _map;
    }

    public List<T> GetColumn(int column)
    {
        return _map.Select(row => row[column]).ToList();
    }

    public List<List<T>> GetColumns()
    {
        var columns = new List<List<T>>();
        for (var i = 0; i < GetColumnCount(); i++)
        {
            columns.Add(_map.Select(row => row[i]).ToList());
        }
        return columns;
    }

    public T GetCoord(Point2D point)
    {
        return GetCoord((int)point.X, (int)point.Y);
    }

    public T GetCoord(int x, int y)
    {
        return _map[x][y];
    }

    public int GetRowCount()
    {
        return _map.Count;
    }

    public int GetColumnCount()
    {
        return _map[0].Count;
    }
}
