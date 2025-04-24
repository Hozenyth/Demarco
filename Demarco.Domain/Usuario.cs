namespace Demarco.Domain
{
    public class Usuario: BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
       

        public Usuario( string nome, string email, string password)
        {
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
        }

        public Usuario() { }
        
    }
}
