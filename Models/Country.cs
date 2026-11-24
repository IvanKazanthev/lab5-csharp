namespace LAB5.Models
{
    public class Country
    {
        private int _id;
        private string _name;

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

        public Country()
        {
            _id = 0;
            _name = "";
        }

        public Country(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public override string ToString()
        {
            return Id + " | " + Name;
        }
    }
}