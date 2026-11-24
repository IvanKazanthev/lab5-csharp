namespace LAB5.Models
{
    public class Achievement
    {
        private int _clubId;
        private int _gold;
        private int _silver;
        private int _bronze;
        private int _cup;
        private int _lostCup;
        private int _championsLeague;
        private int _lostChampionsLeague;
        private int _europaLeague;
        private int _lostEuropaLeague;
        private int _cupWinnersCup;
        private int _lostCupWinnersCup;
        private int _conferenceLeague;
        private int _lostConferenceLeague;

        public int ClubId
        {
            get { return _clubId; }
            set { _clubId = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public int Silver
        {
            get { return _silver; }
            set { _silver = value; }
        }

        public int Bronze
        {
            get { return _bronze; }
            set { _bronze = value; }
        }

        public int Cup
        {
            get { return _cup; }
            set { _cup = value; }
        }

        public int LostCup
        {
            get { return _lostCup; }
            set { _lostCup = value; }
        }

        public int ChampionsLeague
        {
            get { return _championsLeague; }
            set { _championsLeague = value; }
        }

        public int LostChampionsLeague
        {
            get { return _lostChampionsLeague; }
            set { _lostChampionsLeague = value; }
        }

        public int EuropaLeague
        {
            get { return _europaLeague; }
            set { _europaLeague = value; }
        }

        public int LostEuropaLeague
        {
            get { return _lostEuropaLeague; }
            set { _lostEuropaLeague = value; }
        }

        public int CupWinnersCup
        {
            get { return _cupWinnersCup; }
            set { _cupWinnersCup = value; }
        }

        public int LostCupWinnersCup
        {
            get { return _lostCupWinnersCup; }
            set { _lostCupWinnersCup = value; }
        }

        public int ConferenceLeague
        {
            get { return _conferenceLeague; }
            set { _conferenceLeague = value; }
        }

        public int LostConferenceLeague
        {
            get { return _lostConferenceLeague; }
            set { _lostConferenceLeague = value; }
        }

        public Achievement()
        {
        }

        public override string ToString()
        {
            return "Клуб: " + ClubId
                + " | Золото: " + Gold
                + " | Кубки: " + Cup;
        }
    }
}