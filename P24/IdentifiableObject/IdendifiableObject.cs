
namespace IdentifiableObject
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {    
            foreach(string id in idents)
            {
                AddIdentifier(id);
            }       
        }
        public bool AreYou(string id)       
        {
            return _identifiers.Contains(id.ToLower());
        }
        public string FirstID
        {
            get
            {
                if ( _identifiers.Count == 0) return "";
                return _identifiers.First();
            }
        }
        public void AddIdentifier(string id)    
        {
            _identifiers.Add(id.ToLower());
        }
        public void PrivilegeEscalation(string pin)
        {
            if (pin == "2912")
            {
                _identifiers[0] = "105292912";
            }
        }
    }
}