using System.ComponentModel.DataAnnotations;


namespace NET_QR.Models
{
    public class UserQrRelation
    {
        [Key]
        public int ID { get; set; }
        public string name{ get; set; }
        public int userid { get; set; }
        public string imagepath { get; set; }   

    }
}
