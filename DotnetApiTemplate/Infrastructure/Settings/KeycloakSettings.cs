namespace Infrastructure.Settings;

public class KeycloakSettings
{
    public string Host {  get; set; }

    public int Port { get; set; }

    public string RealmUrl { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret {  get; set; }
}
