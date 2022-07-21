using P03.Telephony.Models.Interfaces;

namespace P03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
