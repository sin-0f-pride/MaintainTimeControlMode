using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;

using HarmonyLib;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;

namespace MaintainTimeControlMode.Patches
{
    [HarmonyPatch]
    public static class HandleMouseTranspilerPatch
    {

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MapScreen), "HandleMouse")]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            MethodInfo methodInfo = AccessTools.PropertySetter(typeof(Campaign), "TimeControlMode");
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Calls(methodInfo))
                {
                    list[i].opcode = OpCodes.Nop;
                    list[i - 1].opcode = OpCodes.Nop;
                    list[i - 2].opcode = OpCodes.Nop;
                }
            }
            return list.AsEnumerable();
        }
    }
}
