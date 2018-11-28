using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiaArquivosKTM
{


    namespace CSharp_Json
    {
        public class TiposDocumentos
        {
            public Documento[] Documentos { get; set; }
        }

        public class Documento
        {
            public int COD_TIPO_DOCUMENTO_KOFAX { get; set; }
            public int COD_TIPO_DOCUMENTO { get; set; }
            public string CLASSEKTM { get; set; }
            public string CLASSEKOFAX { get; set; }
            public string FORMTYPEKOFAX { get; set; }
        }

    }

    class TiposDocumentos
    {



        using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace CSharp_Json
    {
        class Program
        {
            static void Main(string[] args)
            {
                LerArquivoJson(@"c:\json.json");
            }

            static void LerStringJson()
            {
                JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                string json = @"{ ""nome"" : ""Jose Carlos"", ""sobrenome"" : ""Macoratti"", ""email"": ""macoratti@yahoo.com"" }";

                dynamic resultado = serializer.DeserializeObject(json);

                Console.WriteLine("  ==  Resultado da leitura do arquivo JSON  == ");
                Console.WriteLine("");

                foreach (KeyValuePair<string, object> entry in resultado)
                {
                    var key = entry.Key;
                    var value = entry.Value as string;
                    Console.WriteLine(String.Format("{0} : {1}", key, value));
                }

            }

            static void LerArquivoJson(string arquivo)
            {



                JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                using (StreamReader r = new StreamReader(arquivo))
                {

                    var x = JsonConvert.DeserializeObject<TiposDocumentos>(r.ReadToEnd());

                    string json = r.ReadToEnd();
                    dynamic array = serializer.DeserializeObject(json);

                    Console.WriteLine("");
                    Console.WriteLine(serializer.Serialize(array));
                    Console.WriteLine("");
                    Console.ReadKey();
                }
            }

        }

    }


}
}
