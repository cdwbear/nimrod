using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexWebServiceToolV2
{
    [Serializable]
    public class ClientSettings
    {
        public Dictionary<string, string> SettingDict { get; set; }
    }

    [Serializable]
    public class Setting
    {
        public string Key_1_5 {get; set;}
        public string Password_1_5 {get; set;}
        public string VendorSiteId { get; set; }

        // default value should be false
        public string WriteSerializedXML { get; set; }
        // default value should be false
        public string WriteANSI5010 { get; set; }
        // default value should be false
        public string WriteStatus { get; set; }
        public string LastBinding { get; set; }
        public string EligFirstName { get; set; }
        public string EligCommonName { get; set; }
        public string EligPayeeNpi { get; set; }
        public string EligTaxId { get; set; }
        public string EligPayerId { get; set; }
        public string EligSubscriberFirstName { get; set; }
        public string EligSubscriberLastName { get; set; }
        public string EligSubscriberDob { get; set; }
        public string EligSubscriberGender { get; set; }
        public string EligSubscriberId { get; set; }
        public string ApiVersion { get; set; }
    }
}
