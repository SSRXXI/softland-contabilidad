using System;

namespace api_contabilidad_softland
{
    public class Response
    {
        public int Id { get; set; }
        public string StatusCode { get; set; }
        public string[] Error { get; set; }
        public string[] Comprobante { get; set; }
    }
}
