using ContactService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ContactService.Permissions;

public class ContactServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ContactServicePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ContactServicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ContactServiceResource>(name);
    }
}
