using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    [SerializeField] GameEvent selectedPieceEvent;
    private int row,column;
    private SpriteRenderer spriteRenderer;
    private Color prevColor;
    private ChessPiece selectedPiece=null;
    
    public void Init(int Y,int X)
    {
        row=Y;
        column=X;
        spriteRenderer=GetComponent<SpriteRenderer>();
        prevColor=spriteRenderer.color;
        //if event ref is not set then get it from manager
        if(selectedPieceEvent==null)
            selectedPieceEvent=ChessBoardManager.instance.GetSelectedEvent();
    }

    void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        selectedPiece=ChessBoardManager.instance.GetSelectedPiece();
        //if piece is selected
        if(selectedPiece!=null)
        {
            //Update the Main Board
            ChessBoardManager.instance.board[selectedPiece.currentX,selectedPiece.currentY]=null;
            
            //set piece position and raise the event
            selectedPiece.transform.position=ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            selectedPiece.SetPositionOfPiece(row,column);



            //Attack 
            if(ChessBoardManager.instance.board[selectedPiece.currentX,selectedPiece.currentY]!=null) //if its not null then it had to be an Enemy piece
            {
                var data=ChessBoardManager.instance.board[selectedPiece.currentX,selectedPiece.currentY];
                Destroy(data.gameObject);
                
            }
            //Update new values in board
            ChessBoardManager.instance.board[selectedPiece.currentX,selectedPiece.currentY]=selectedPiece;

            selectedPieceEvent.Raise(this,null);
        }
    }
    void OnMouseOver()=>spriteRenderer.color=new Color(prevColor.r,prevColor.g,prevColor.b,prevColor.a-40f);
    
    void OnMouseExit()=>spriteRenderer.color=prevColor;
    
}
