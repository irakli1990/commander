using Commander.Src.Core.Generic.LocalData;

namespace Commander.Src.Feature.Auth.Domain.Entity
{
    public class User: IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public string RepeatPassword { get; set; }
    }
}