namespace IChave.DTO
{
    public class LocksmithDTO
    {
        public int locksmith_id { get; set; }
        public string company_name { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cell_phone { get; set; }

        public LocksmithDTO()
        {
        }
    }
}