using EFT;
using System.Reflection;
using SPT.Reflection.Patching;

namespace configurable_experience.Patches
{
    internal class SkillsMultiplierPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(SkillClass).GetMethod(nameof(SkillClass.UseEffectiveness), BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
        }

        [PatchPostfix]
        private static void Postfix(ref SkillClass __instance, ref float __result, ref float ___float_2)
        {
            // Keep the multiplier unchanged if the plugin is disabled
            if (!Plugin.enablePlugin.Value)
            {
                return;
            }

            // Keep the multiplier unchanged for metabolism if the option is disabled
            if (!Plugin.changeMetabolism.Value && __instance.Id == ESkillId.Metabolism)
            {
                return;
            }

            float multiplier = Plugin.multiplier.Value;

            __result *= multiplier;
            ___float_2 = __result;
        }
    }
}
