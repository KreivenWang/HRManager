using System.Resources;

namespace Steelsa.Localization
{
    public class LocalizationManager
    {
        public static ResourceManager ResManagerSource { get; private set; }
        public static void InitializeResource(ResourceManager rm)
        {
            ResManagerSource = rm;
        }
    }
}
