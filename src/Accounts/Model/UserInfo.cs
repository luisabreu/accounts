namespace Accounts.Model {
    public class UserInfo {
        public int IdUserInfo { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public bool Generated { get; set; }
        public byte[] Version { get; set; }

        public UserInfoRecord ToScreen() {
            return new UserInfoRecord {
                IdUserInfo = this.IdUserInfo,
                GivenName = this.GivenName,
                Surname = this.Surname,
                Description = this.Description,
                Department = this.Department,
                GenerateScript = this.Generated,
                Version = this.Version,
            };
        }
    }
}