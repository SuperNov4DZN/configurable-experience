using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using configurable_experience.Patches;

namespace configurable_experience
{
    [BepInPlugin("com.Super.configurable-experience","Configurable Experience", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;

        // Configs
        public static ConfigEntry<bool> enablePlugin;
        public static ConfigEntry<bool> disableFatigue;
        public static ConfigEntry<bool> changeMetabolism;
        public static ConfigEntry<float> multiplier;

        public void Awake()
        {
            enablePlugin = Config.Bind(
                "General",
                "Enabled",
                true,
                "Enables/Disables the mod."
            );

            disableFatigue = Config.Bind(
                "Skill Fatigue",
                "Disable Skill Fatigue",
                true,
                "Enables/Disables the skill fatigue."
            );

            multiplier = Config.Bind(
                "Skill Multiplier",
                "Skill Points Multiplier",
                1.0f,
                "Changes the default multiplier used for skill points. (1 == default)"
            );

            changeMetabolism = Config.Bind(
                "Skill Multiplier",
                "Modify Metabolism Multiplier",
                false,
                "Enables/Disables changes to the metabolism multiplier.\n(Note: can be a bit OP because default XP rewards for Metabolism are very high)"
            );

            LogSource = Logger;
            LogSource.LogInfo("configurable-experience 1.0.0 loaded!.");

            new SkillsMultiplierPatch().Enable();
            new DisableFatiguePatch().Enable();
        }
    }
}
