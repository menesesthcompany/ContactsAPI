namespace ContactsAPI.Entities
{
    public class Contato
    {
        public Contato()
        {
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public DateTime StarDate { get; set; }
        public bool IsDeleted { get; set; }
        public void Update(string nome, string email, int celular, DateTime startDate)
        {
            Nome = nome;
            Email = email;
            Celular = celular;
            StarDate = startDate;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}