using ContactsAPI.Entities;

namespace ContactsAPI.Persistence
{
    public class ContatoDbContext
    {
        public List<Contato> Contatos { get; set; }
        public ContatoDbContext()
        {
            Contatos = new List<Contato>();
        }
    }
}