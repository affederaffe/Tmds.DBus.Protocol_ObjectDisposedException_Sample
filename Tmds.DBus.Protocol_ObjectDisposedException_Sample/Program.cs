using Tmds.DBus.Protocol;
using Tmds.DBus.SourceGenerator;


await Connection.Session.ConnectAsync();
OrgFreedesktopDBus dbus = new(Connection.Session, "org.freedesktop.DBus", "/org/freedesktop/DBus");
IDisposable disposable = await dbus.WatchNameOwnerChangedAsync(OnNameChange);
disposable.Dispose(); // Emits ObjectDisposedException

return;

static void OnNameChange(Exception? e, (string ServiceName, string? OldOwner, string? NewOwner) args)
{
    if (e is not null)
        throw e; // Throws the Exception emitted above
}
