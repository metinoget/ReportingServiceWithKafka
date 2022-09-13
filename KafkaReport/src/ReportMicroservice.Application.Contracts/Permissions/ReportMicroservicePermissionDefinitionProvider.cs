using ReportMicroservice.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ReportMicroservice.Permissions;

public class ReportMicroservicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ReportMicroservicePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ReportMicroservicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ReportMicroserviceResource>(name);
    }
}
