namespace IQSoft.eCommerce.Entities.Core
{
    public sealed class AppSettings
    {
        public DataSection Data { get; set; }
        public ConfigSettingsSection ConfigSettings { get; set; }        
        public StorageSettingsSection FileSettings { get; set; }
        public SmtpEmailSettings SmtpSettings { get; set; }
        public JwtKeysSettings JwtKeysSettings { get; set; }
    }

    public class DataSection
    {
        public string CommonConnectionString { get; set; }
        public int CommandTimeout { get; set; }
    }

    public class ConfigSettingsSection
    {        
        public bool IsDevelopment { get; set; }
    }

    public class StorageSettingsSection
    {
        public string DocumentsFolder { get; set; }        
        public string GoogleFirebaseFile { get; set; }        
    }

    public class SmtpEmailSettings
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int PortNo { get; set; }
    }

    public class JwtKeysSettings
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string IssuerSigningKey { get; set; }
    }

    public sealed class ConfigSettings
    {
        public static AppSettings Instance { get; set; }
    }
}
