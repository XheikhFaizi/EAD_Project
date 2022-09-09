
namespace NET_QR.Models.Interface
{

    public interface InterfaceUser
    {
        public bool Ifuserexist(User s);
        public bool UserExistByEmail(string s);

        public Task<bool> createuser(User s);

        public Task<bool> UploadFile(IFormFile file);
    }
}
