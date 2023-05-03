namespace Zoho.Domain
{
    public class Currency : Entity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }

        public IEnumerable<Client> Clients{ get; set; }
    }
}