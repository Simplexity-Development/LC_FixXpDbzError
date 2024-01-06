using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LC_FixXpDbzError
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [HarmonyPatch]
    public class Main : BaseUnityPlugin
    {
        private const string modGUID = "SimplexityDev.LC_FixXpDbzError";
        private const string modName = "Fix XP DivideByZero Error";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static ManualLogSource logger;

        void Awake()
        {
            logger = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(HUDManager), nameof(HUDManager.SetPlayerLevel))]
        static void Prefix(HUDManager __instance)
        {
            logger.LogInfo("Testing for XPMax == 0");
            if (__instance.playerLevels[__instance.localPlayerLevel].XPMax != 0) return;
            __instance.playerLevels[__instance.localPlayerLevel].XPMax = 1;
            logger.LogWarning($"Detected localPlayerLevel ({__instance.localPlayerLevel}) XPMax as 0, setting to 1.");
        }
    }
}