namespace PushPull.Models
{
    public class CustomerLife
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
        public bool IsAlive {get; set; }

        public virtual ApplicationUser User { get; set; }
    }

}