using Commander.Src.Core.Generic.LocalData;

namespace Commander.Src.Core.AuthCore.JWTModels
{
    public class RefreshToken: IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool Revoked { get; set; }
    }
}