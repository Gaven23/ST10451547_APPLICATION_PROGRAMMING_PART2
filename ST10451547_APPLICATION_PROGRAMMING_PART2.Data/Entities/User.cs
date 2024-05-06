namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Data.Entities
{
    public class User
    {
        public int UsersId { get; set; }
        public Guid UsersToken { get; set; }
        public int RoleId { get; set; }
        public int ProductId { get; set; }
        public string Loginname { get; set; }
        public string LoginPassword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int GenderId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Role Role { get; set; }
    }
}
