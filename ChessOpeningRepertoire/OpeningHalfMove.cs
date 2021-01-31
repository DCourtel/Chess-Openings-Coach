using ChessboardControl;
using System;
using Newtonsoft.Json;

namespace ChessOpeningRepertoire
{
    public class OpeningHalfMove : IEquatable<OpeningHalfMove>
    {
        public OpeningHalfMove() { }

        public OpeningHalfMove(ChessMove move)
        {
            this.CapturedPiece = move.CapturedPiece;
            this.From = move.From.Clone();
            this.PromotedTo = move.PromotedTo;
            this.ToSAN = move.ToSAN;
            this.To = move.To.Clone();
        }

        #region Properties

        [JsonProperty(Order =3)]
        /// <summary>
        /// Gets or sets the captuded piece if any.
        /// </summary>
        public ChessPieceKind CapturedPiece { get; set; } = ChessPieceKind.None;

        [JsonProperty(Order =1)]
        /// <summary>
        /// Gets or sets the square where the piece move from.
        /// </summary>
        public ChessSquare From { get; set; }

        [JsonProperty(Order =4)]
        /// <summary>
        /// Gets or sets the type of the piece created during a pawn promotion.
        /// </summary>
        public ChessPieceKind PromotedTo { get; set; } = ChessPieceKind.None;

        [JsonProperty(Order =0)]
        /// <summary>
        /// Gets or sets the move expressed in the Standard Algebraic Notation (SAN).
        /// </summary>
        public string ToSAN { get; set; } = string.Empty;

        [JsonProperty(Order =2)]
        /// <summary>
        /// Gets or sets the square where the piece move to.
        /// </summary>
        public ChessSquare To { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates a clone of this instance.
        /// </summary>
        /// <returns>A deep clone of this instance.</returns>
        public OpeningHalfMove Clone()
        {
            OpeningHalfMove clone = (OpeningHalfMove)this.MemberwiseClone();

            clone.From = this.From.Clone();
            clone.To = this.To.Clone();
            //clone.MovingPiece = this.MovingPiece.Clone();

            return clone;
        }

        public static bool operator ==(OpeningHalfMove first, OpeningHalfMove second)
        {
            if (ReferenceEquals(first, second)) { return true; }
            if (first is null && second is null) { return true; }
            if (first is null || second is null) { return false; }

            return first.From == second.From &&
                    first.To == second.To &&
                    first.CapturedPiece == second.CapturedPiece &&
                    first.PromotedTo == second.PromotedTo;
        }

        public static bool operator !=(OpeningHalfMove first, OpeningHalfMove second)
        {
            return !(first == second);
        }

        public bool Equals(OpeningHalfMove other)
        {
            return Equals((object)other);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) { return false; }
            if (!(obj is OpeningHalfMove)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }

            return this == (OpeningHalfMove)obj;
        }

        public override int GetHashCode()
        {
            return $"{From}{To}{CapturedPiece}{PromotedTo}".GetHashCode();
        }

        public override string ToString()
        {
            return ToSAN;
        }

        #endregion Methods
    }
}
