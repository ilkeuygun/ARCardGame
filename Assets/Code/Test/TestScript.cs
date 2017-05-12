﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Yosi.Linkar.Code.Models.GameItems;

public class TestScript : MonoBehaviour
{
    private Board _board;

    void Start ()
    {
        _board = new Board();
        _board.TargetPosition = new Point(5, 4);

        addCard(7, 8, CardType.Red);
        addCard(8, 8, CardType.Red);
        addCard(6, 6, CardType.Red);
        addCard(6, 7, CardType.Red);
        addCard(6, 5, CardType.Red);
        addCard(6, 4, CardType.Red);
        addCard(5, 4, CardType.Red);
        addCard(5, 6, CardType.Red);
        addCard(5, 5, CardType.Red);

        var a = _board.GetClosestPathsToTarget();
        Debug.Log(a[0].ToString());
    }

    private void addCard(int x, int y, CardType type)
    {
        _board.AddCard(new Card(type, new Point(x, y)));
    }
}