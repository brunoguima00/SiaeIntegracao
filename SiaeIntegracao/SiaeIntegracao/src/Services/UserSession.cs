namespace SiaeIntegracao.src.Services
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public event Action? OnChange;

        public void SetUser(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
