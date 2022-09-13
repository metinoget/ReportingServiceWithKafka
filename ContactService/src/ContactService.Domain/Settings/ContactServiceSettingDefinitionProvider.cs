using Volo.Abp.Settings;

namespace ContactService.Settings;

public class ContactServiceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ContactServiceSettings.MySetting1));
    }
}
