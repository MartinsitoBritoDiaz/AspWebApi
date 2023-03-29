namespace Web_API.Helpers
{


    public class Helpers
    {
        private enum Roles: short
        {
            Admin = 1,
            User = 2,
            Guest = 3,
        }

        public static string GetRoleName(short roleId)
        {
            return Enum.GetName(typeof(Roles), roleId);
        }
    }


}
