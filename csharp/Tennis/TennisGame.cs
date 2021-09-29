namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int _score1 = 0;
        private int _score2 = 0;

        private string _player1Name;
        private string _player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this._player1Name)
                this._score1 += 1;
            else
                this._score2 += 1;
        }

        public string GetScore()
        {
            string score = "";

            if (this._score1 == this._score2)
            {
                score = GetScoreDescription(this._score2, true);
            }
            else if (this._score1 >= 4 || this._score2 >= 4)
            {
                int minusResult = this._score1 - this._score2;
                if (minusResult == 1) 
                    score = string.Format("Advantage {0}", this._player1Name);
                else if (minusResult == -1) 
                    score = string.Format("Advantage {0}", this._player2Name);
                else if (minusResult >= 2) 
                    score = string.Format("Win for {0}", this._player1Name);
                else 
                    score = string.Format("Win for {0}", this._player2Name);
            }
            else
            {
                score = GetScoreDescription(this._score1) + "-" + GetScoreDescription(this._score2);                
            }

            return score;
        }

        private string GetScoreDescription(int score, bool isTieScore = false)
        {
            string description = string.Empty;

            switch (score)
            {
                case 0:
                    description  = "Love" + (isTieScore ? "-All" : "");
                    break;
                case 1:
                    description = "Fifteen" + (isTieScore ? "-All" : "");
                    break;
                case 2:
                    description = "Thirty" + (isTieScore ? "-All" : "");
                    break;
                default:
                    description = (!isTieScore ? "Forty" : "Deuce");
                    break;
            }

            return description;
        }
    }
}

