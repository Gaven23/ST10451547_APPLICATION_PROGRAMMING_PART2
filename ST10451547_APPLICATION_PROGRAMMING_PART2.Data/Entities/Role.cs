namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
