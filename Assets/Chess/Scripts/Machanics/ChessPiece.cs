using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece:MonoBehaviour
{
    protected GameEvent selectedPieceEvent;
   public int currentX { get; set; }
   public int currentY { get; set; }
   public int team{get;set;} //0=My team | if(!0) other team

    //col=x amd row=y

    public  void Init(int Y,int X,int team)
    {
        currentX=X;
        currentY=Y;
        this.team=team;
        ChessBoardManager.instance.board[currentX,currentY]=this;
        selectedPieceEvent=ChessBoardManager.instance.GetSelectedEvent();
    }
    //when piece will change position in the board
    public void SetPositionOfPiece(int Y,int X)
    {
        currentX=X;
        currentY=Y;
    }
    //Just a virtual fun which will be override by all other children class
   public virtual List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board,int tileCountX,int tileCountY)
   {
        List<Vector2Int> moves=new List<Vector2Int>();
        return moves;
   }

    public void OnMouseDown()
    {
        //Clear all privious HighLights
        ChessBoardPlacementHandler.Instance.ClearHighlights();

        List<Vector2Int> Moves=GetAvailableMoves(ref ChessBoardManager.instance.board,ChessBoardManager.instance.tileCountX,ChessBoardManager.instance.tileCountY);
        //Loop through all possible moves and Color them Accordingly
        foreach(Vector2Int item in Moves)
        {
            if(ChessBoardManager.instance.board[item.x,item.y]!=null && ChessBoardManager.instance.board[item.x,item.y].team!=team)
                ChessBoardPlacementHandler.Instance.Highlight(item.y,item.x,Color.red); 
            else
                ChessBoardPlacementHandler.Instance.Highlight(item.y,item.x);
        }
        //Raise event to let other know which piece is currently selected
        selectedPieceEvent.Raise(this,null);
    }

   

}
