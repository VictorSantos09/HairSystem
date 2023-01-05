using Hair.Domain.Entities;

namespace Hair.Tests
{
    public class GlobalUser
    {
        private static AdressEntity Adress;
        private static HaircutePriceEntity HaircutePrice;
        private static UserEntity User;

        public GlobalUser()
        {
            Adress = new AdressEntity("Av Brasil", "240", "Blumenau", "SC", null);
            HaircutePrice = new HaircutePriceEntity(20, 15, 12);
            User = new UserEntity("Victor's", "Victor", "13991256286", "victor@gmail.com", "victors123", Adress, "123456789", HaircutePrice);
        }

        public UserEntity GetGlobalUser()
        {
            return User;
        }
    }
}
