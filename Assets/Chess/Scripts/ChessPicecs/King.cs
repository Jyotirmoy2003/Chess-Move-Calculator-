using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King :ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board,int tileCountX,int tileCountY)
    {
        List<Vector2Int> moves=new List<Vector2Int>();
        for (int x = currentX - 1; x < currentX + 2; x++)
                for (int y = currentY - 1; y < currentY + 2; y++)
                    if (y >= 0 && x >= 0 && x < tileCountX && y < tileCountY)
                        if (board[x, y] == null || board[x, y].team != team)
                            moves.Add(new Vector2Int(x, y));
        return moves;
    }
}
