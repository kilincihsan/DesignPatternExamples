using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.StepBuilderPattern_ChessMoveBuilder
{

    /*Steps
     * 1. Choose player
     * 2. Choose piece
     * 3. PlayFrom X,Y
     * 4. PlayTo X,Y
     * 5. Build
     */

    public interface IChoosePlayer
    {
        IChoosePiece ChoosePlayer(Player player);
    }

    public interface IChoosePiece
    {
        IPlayFrom ChoosePiece(Piece piece);
    }

    public interface IPlayFrom
    {
        IPlayTo PlayFrom(char x, int y);
    }

    public interface IPlayTo
    {
        IBuild PlayTo(char x, int y);
    }

    public interface IBuild
    {
        Move Build();
    }

    #region classes

    public enum Player { White, Black }
    public enum Piece { Pawn, Rook, Knight, Bishop, Queen, King }

    public class Move
    {
        public Player Player { get; set; }
        public Piece Piece { get; set; }
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Player)}={Player.ToString()}, {nameof(Piece)}={Piece.ToString()}, {nameof(FromX)}={FromX.ToString()}, {nameof(FromY)}={FromY.ToString()}, {nameof(ToX)}={ToX.ToString()}, {nameof(ToY)}={ToY.ToString()}}}";
        }
    }
    #endregion

    /* step builder */
    public class MoveBuilder
    {
        /* starts here */
        public static IChoosePlayer Init()
        {
            return new Implementation();
        }

        public class Implementation : IChoosePlayer, IChoosePiece, IPlayFrom, IPlayTo, IBuild
        {
            /* define the object to build */
            private Move Move { get; set; } = new Move();

            /* step 1 choose player */
            public IChoosePiece ChoosePlayer(Player player)
            {
                Move.Player = player;
                return this;
            }

            /* step 2 choose piece */
            public IPlayFrom ChoosePiece(Piece piece)
            {
                Move.Piece = piece;
                return this;
            }

            /* step 3 play from */
            public IPlayTo PlayFrom(char x,int y)
            {
                Move.FromX = x;
                Move.FromY = y; 
                return this;
            }

            /* step 4 play to */
            public IBuild PlayTo(char x, int y)
            {
                /* maybe some validation here about where pieces can move etc.*/
                Move.ToX = x;
                Move.ToY = y;
                return this;
            }

            /* step 5 build */
            public Move Build()
            {
                  return Move;
            }
        }

    }

    public class StepBuilderPattern_ChessMoveBuilder
    {
        public static void Execute()
        {
            /* brilliant king sacrifice - https://youtu.be/bTS9XaoQ6mg */
            Console.WriteLine("\n##################### stepwise builder pattern - ChessMoveBuilder #####################");
            var blackMoves = MoveBuilder.Init().ChoosePlayer(Player.Black).ChoosePiece(Piece.King).PlayFrom('d', 5).PlayTo('d', 4).Build();
            var whiteMoves = MoveBuilder.Init().ChoosePlayer(Player.White).ChoosePiece(Piece.King).PlayFrom('f', 2).PlayTo('e', 3).Build();

            Console.WriteLine(blackMoves);
            Console.WriteLine(whiteMoves);
            Console.WriteLine("checkmate!");

        }
    }
}
