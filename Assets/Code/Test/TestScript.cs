using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Com.Yosi.Linkar.Code.Models.GameItems;
using Com.Yosi.Linkar.Code.Util;

public class TestScript : MonoBehaviour
{
    private Board _board;

    void Start ()
    {
        _board = new Board();
        _board.TargetPosition = new Point(5, 4);

        LogAggregator.AddItem("GAME STARTS");
        LogAggregator.AddItem("");
        LogAggregator.AddItem(CardType.Red.ToString() + " starts");
        LogAggregator.AddItem("");
        addCard(7, 8, CardType.Red);
        addCard(8, 8, CardType.Green);
        addCard(6, 7, CardType.Blue);
        addCard(6, 6, CardType.Yellow);
        addCard(-1, -1, CardType.Red);
        addCard(6, 5, CardType.Green);
        addCard(6, 4, CardType.Blue);
        addCard(5, 6, CardType.Yellow);
        addCard(5, 5, CardType.Red);
        addCard(-1, -1, CardType.Green);
        addCard(5, 4, CardType.Blue);
        LogAggregator.AddItem("");
        LogAggregator.AddItem("GAME ENDS");
        LogAggregator.AddItem("");

        LogAggregator.AddItem("Printing Path:");
        var a = _board.GetClosestPathsToTarget();
        a[0].Cards.Reverse();
        LogAggregator.AddItem(a[0].ToString());
        LogAggregator.AddItem("");

        var points = a[0].GetPoints();
        LogAggregator.AddItem("Printing Points:");
        LogAggregator.AddItem("Blue  : " + points[CardType.Blue]);
        LogAggregator.AddItem("Red   : " + points[CardType.Red]);
        LogAggregator.AddItem("Green : " + points[CardType.Green]);
        LogAggregator.AddItem("Yellow: " + points[CardType.Yellow]);

        LogAggregator.Print();
    }

    private void addCard(int x, int y, CardType type)
    {
        if (x > -1 && y > -1)
        {
            _board.AddCard(new Card(type, new Point(x, y)));
            LogAggregator.AddItem(type.ToString() + " played to " + x + "-" + y);
        }
        else
        {
            LogAggregator.AddItem(type.ToString() + " passed");
        }
    }
}
