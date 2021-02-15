using ChessboardControl;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChessOpeningRepertoire
{
    public class OpeningMove
    {
        public OpeningMove(OpeningHalfMove halfMove, ChessColor turn, int moveIndex, string FEN)
        {
            this.Move = halfMove;
            this.MoveColor = turn;
            this.MoveIndex = moveIndex;
            this.FenPosition = FEN;
        }

        #region Properties

        [JsonProperty(Order = 8)]
        public List<OpeningMove> Children { get; } = new List<OpeningMove>();

        [JsonProperty(Order = 3)]
        public string Comment { get; set; } = string.Empty;

        [JsonProperty(Order = 0)]
        public string ECO { get; set; } = string.Empty;

        [JsonProperty(Order = 4)]
        public string FenPosition { get; set; }

        [JsonProperty(Order = 5)]
        public OpeningHalfMove Move { get; set; }

        [JsonProperty(Order = 2, DefaultValueHandling = DefaultValueHandling.Include)]
        public ChessColor MoveColor { get; set; }

        [JsonProperty(Order = 6)]
        public int MoveIndex { get; set; }

        [JsonProperty(Order = 7)]
        public MoveStatistics MoveStat { get; set; } = new MoveStatistics(0, 33,34);

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets if the move can be include in quizzes.
        /// </summary>
        [JsonProperty(Order = 9)]        
        public bool Selected { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"{MoveIndex}.{(MoveColor == ChessColor.Black ? ".." : "")}{Move}{(!string.IsNullOrWhiteSpace(ECO) && !string.IsNullOrWhiteSpace(Name)?$" [{ECO}-{Name}]":"")}";
        }

        #endregion Methods
    }
}
