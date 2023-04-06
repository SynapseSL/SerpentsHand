using Neuron.Core.Meta;
using Neuron.Modules.Configs.Localization;

namespace SerpentsHand;

[Automatic]
public class Translation : Translations<Translation>
{
    public string SpawnMessageCadet { get; set; } =
        "<i>You are a <color=green>SerpentsHand Cadet</color></i>\\n<i>Your Goal is it to kill all Humans and help the SCP's</i>\\n<b>Press N to close</b>";
    
    public string SpawnMessagePrivate { get; set; } =
        "<i>You are a <color=green>SerpentsHand Private</color></i>\\n<i>Your Goal is it to kill all Humans and help the SCP's</i>\\n<b>Press N to close</b>";
    
    public string SpawnMessageSergeant { get; set; } =
        "<i>You are a <color=green>SerpentsHand Sergeant</color></i>\\n<i>Your Goal is it to kill all Humans and help the SCP's</i>\\n<b>Press N to close</b>";
}
