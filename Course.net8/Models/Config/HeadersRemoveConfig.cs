namespace Course.net8.Models.Config;

public class HeadersRemoveConfig
{
   
        public bool Enabled { get; set; }
        public string[] HeadersKeys { get; set; } = new string[0];

}