using ChessboardControl;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChessOpeningRepertoire
{
    public class OpeningRepertoire
    {
        public OpeningRepertoire(ChessColor color)
        {
            this.Color = color;
        }

        #region Properties

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        /// <summary>
        /// Gets or sets the color of the repertoire.
        /// </summary>
        public ChessColor Color { get; private set; }

        /// <summary>
        /// Gets the list of all openings in this repertoire.
        /// </summary>
        public List<OpeningMove> Moves { get; } = new List<OpeningMove>();

        /// <summary>
        /// Gets or sets if the repertoire can be include in quizzes.
        /// </summary>
        public bool Selected { get; set; }

        #endregion Properties
    }
}
