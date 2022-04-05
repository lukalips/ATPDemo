namespace ATP.Business
{
    public interface IUtilities
    {
        public void AddToPlayerFavorites(string playerId);
        public void ClearFavorites(int userId);

        public void RemovePlayerFromVavorites(int user, string playerId);
    }
}
