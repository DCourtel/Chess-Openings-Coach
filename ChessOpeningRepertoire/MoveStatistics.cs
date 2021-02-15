namespace ChessOpeningRepertoire
{
    public class MoveStatistics
    {
        public MoveStatistics(int gameCount, int whiteStat, int nullStat)
        {
            if(whiteStat + NullStat > 100) { throw new System.ArgumentException("The sum of the two parameters cannot be greater than 100."); }
            this.GameCount = gameCount;
            this.WhiteStat = whiteStat;
            this.NullStat = nullStat;
        }

        #region Properties

        public int GameCount { get; set; }

        public int WhiteStat { get; set; }

        public int BlackStat { get { return 100 - (WhiteStat + NullStat); }  }

        public int NullStat { get; set; }

        #endregion Properties
    }
}
