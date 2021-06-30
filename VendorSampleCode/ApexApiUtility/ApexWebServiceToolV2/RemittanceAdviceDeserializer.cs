using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ApexWebServiceToolV2.ApexSandbox;
//using ApexWebServiceToolV2.ApexProd;
//using ApexWebServiceToolV2.ApexLocal;

namespace ApexWebServiceToolV2
{
    public class EraDeserializer
    {
        public void DoIt()
        {
            var serializer = new XmlSerializer(typeof (WsRemittanceAdvice));
            var path = @"835Output-SerializedWith5010MappingComments.xml";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var xmlReader = XmlReader.Create(fs))
                {
                    var era = serializer.Deserialize(xmlReader) as WsRemittanceAdvice;
                }
            }
        }
    }
}
