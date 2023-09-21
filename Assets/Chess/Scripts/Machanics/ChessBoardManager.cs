using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardManager : MonoBehaviour
{
   public static ChessBoardManager instance;
    [SerializeField] GameEvent selectedPieceEvent;
    public ChessPiece[,] board=new ChessPiece[8,8];
    public int tileCountX=8,tileCountY=8;
    private ChessPiece selectedPiece=null;
    

    void Awake()
    {
        instance=this;
    }
    

    public ChessPiece GetSelectedPiece()
    {
        return selectedPiece;
    }

    public ref GameEvent GetSelectedEvent()
    {
        return ref selectedPieceEvent;
    }

    #region  EVENT'S
    //Listen to Piece Selected Event
    public void ListenSeletedEvent(Component sender,object data)
    {
        if(sender is ChessPiece) //selected a new Piece
            selectedPiece=(ChessPiece)sender;
        else if(sender is MovePiece) //Piece is already placed in board
            selectedPiece=null;
    }

    #endregion
    
}
