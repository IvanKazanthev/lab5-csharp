namespace LAB5.Models
{
    public class Club
    {
        private int _id;
        private string _name;
        private int _countryId;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int CountryId
        {
            get
            {
                return _countryId;
            }
            set
            {
                _countryId = value;
            }
        }

        public Club()
        {
            _id = 0;
            _name = "";
            _countryId = 0;
        }

        public Club(int id, string name, int countryId)
        {
            _id = id;
            _name = name;
            _countryId = countryId;
        }

        public override string ToString()
        {
            return Id + " | " + Name
                + " | Страна: " + CountryId;
        }
    }
}