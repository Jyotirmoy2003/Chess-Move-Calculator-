using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Pawn : ChessPiece
{


   
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board,int tileCountX,int tileCountY)
    {
        List<Vector2Int> moves=new List<Vector2Int>();

        int direction=(team==0)?1:-1;
        //One in Front
        if(board[currentX,currentY+direction]==null)
            moves.Add(new Vector2Int(currentX,currentY+direction));

        //Two in first Move
        if(board[currentX,currentY+direction]==null)
        {
            //White team
            if(team==0 && currentY==1 && board[currentX,currentY+(direction*2)]==null)
                moves.Add(new Vector2Int(currentX,currentY+(direction*2)));
            //Black Team
            if(team!=0 && currentY==6 && board[currentX,currentY+(direction*2)]==null)
                moves.Add(new Vector2Int(currentX,currentY+(direction*2)));

        }

        //kill Move
        if(currentX!=tileCountX-1)
            if(board[currentX+1,currentY+direction] &&board[currentX+1,currentY+direction].team!=team )
                moves.Add(new Vector2Int(currentX+1,currentY+direction));
        
        if(currentX!=0)
            if(board[currentX-1,currentY+direction] &&board[currentX-1,currentY+direction].team!=team )
                moves.Add(new Vector2Int(currentX-1,currentY+direction));
    

        return moves;
    }
}
