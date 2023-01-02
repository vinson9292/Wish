using Wish.Debugging;

namespace Wish
{
    public class WishConsts
    {
        public const string LocalizationSourceName = "Wish";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d898a1e55dfb4692b7491588b067f8d0";
    }
}
