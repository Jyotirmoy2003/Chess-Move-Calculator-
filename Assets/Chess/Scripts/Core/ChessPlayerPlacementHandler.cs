using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;

        [Tooltip("Put '0' if Player or Put '1' for other team")]
        [SerializeField] int team=0;
        [SerializeField] PicesType picesType=PicesType.Pawn;
        private enum PicesType{
            King,
            Queen,
            Bishop,
            Knight,
            Rook,
            Pawn,
        }

        private void Start() {
            AddComp();
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;

        }

        void AddComp()
        {
            switch (picesType)
            {
                case PicesType.King:
                    gameObject.AddComponent<King>().Init(row,column,team);
                    break;
                case PicesType.Queen:
                    gameObject.AddComponent<Queen>().Init(row,column,team);
                    break;
                case PicesType.Bishop:
                    gameObject.AddComponent<Bishop>().Init(row,column,team);
                    break;
                case PicesType.Knight:
                    gameObject.AddComponent<Knight>().Init(row,column,team);
                    break;
                case PicesType.Rook:
                    gameObject.AddComponent<Rook>().Init(row,column,team);
                    break;
                case PicesType.Pawn:
                    gameObject.AddComponent<Pawn>().Init(row,column,team);
                    break;
                default:
                    print("Not a valid Type");
                    break;
            }
        }
    }
}