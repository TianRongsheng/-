namespace ListSamples
{
    public class FindCountry
    {
        public FindCountry(string country)
        {
            _country = country;//国家
        }

        private readonly string _country;//只读

        public bool FindCountryPredicate(Racer racer) 
        {
            return racer?.Country == _country;
        } 
    }
}
