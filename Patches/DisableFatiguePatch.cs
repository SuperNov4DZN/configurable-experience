using EFT;
using System.Reflection;
using SPT.Reflection.Patching;

namespace configurable_experience.Patches
{
    internal class DisableFatiguePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(SkillManager).GetMethod(nameof(SkillManager.GetEffectiveness), BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
        }

        [PatchPostfix]
        private static void Postfix(ref float __result)
        {
            // Disable skill fatigue if enabled
            if(Plugin.disableFatigue.Value)
            {
                __result = 1.0f;
            }

        }
    }
}
