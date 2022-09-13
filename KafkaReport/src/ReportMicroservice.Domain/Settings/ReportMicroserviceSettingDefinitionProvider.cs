using Volo.Abp.Settings;

namespace ReportMicroservice.Settings;

public class ReportMicroserviceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ReportMicroserviceSettings.MySetting1));
    }
}
