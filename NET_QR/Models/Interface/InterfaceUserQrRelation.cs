
namespace NET_QR.Models.Interface
{

    public interface InterfaceUserQrRelation
    {
        public List<UserQrRelation> getuserrelation(int userid);

        public bool addrelation(UserQrRelation s);

    }
}
