namespace ChessOpeningRepertoire
{
    public class MoveStatistics
    {
        public MoveStatistics(int whiteStat, int blackStat, int nullStat)
        {
            this.WhiteStat = whiteStat;
            this.BlackStat = blackStat;
            this.NullStat = nullStat;
        }

        #region Properties

        public int WhiteStat { get; set; }

        public int BlackStat { get; set; }

        public int NullStat { get; set; }

        #endregion Properties
    }
}
