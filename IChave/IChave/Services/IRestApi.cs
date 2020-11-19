using System.Collections.Generic;
using System.Threading.Tasks;
using IChave.DTO;
using IChave.Models;
using Refit;

namespace IChave.Services
{
    public interface IRestApi
    {
        //CEP
        [Get("/{cep}/json")]
        Task<CepDTO> Cep(string cep);

        //TOKEN
        [Post("/login")]
        Task<TokenDTO> Login([Body(BodySerializationMethod.Serialized)] User user);

        [Post("/refresh-token")]
        [Headers("Authorization: Bearer")]
        Task<TokenDTO> RefreshToken();

        //USER
        [Get("/get-user")]
        [Headers("Authorization: Bearer")]
        Task<User> GetUser();

        [Post("/update-user")]
        [Headers("Authorization: Bearer")]
        Task<MsgDTO> UpdateUser([Body(BodySerializationMethod.Serialized)] User user);

        [Post("/change-user-password")]
        [Headers("Authorization: Bearer")]
        Task<MsgDTO> ChangePassword([Body(BodySerializationMethod.Serialized)] ChangePasswordDTO changePasswordDTO);

        [Post("/create-user")]
        Task<MsgDTO> Create([Body(BodySerializationMethod.Serialized)] User user);

        //ADDRESS
        [Get("/get-address-list")]
        [Headers("Authorization: Bearer")]
        Task<List<Address>> GetAddressList();

        [Post("/add-address")]
        [Headers("Authorization: Bearer")]
        Task<MsgDTO> AddAddress([Body(BodySerializationMethod.Serialized)] Address address);

        [Post("/update-address")]
        [Headers("Authorization: Bearer")]
        Task<MsgDTO> UpdateAddress([Body(BodySerializationMethod.Serialized)] Address address);

        [Post("/delete-address")]
        [Headers("Authorization: Bearer")]
        Task<MsgDTO> DeleteAddress([Body(BodySerializationMethod.Serialized)] Address address);

        //LOCKSMITH_LIST
        [Get("/get-locksmith-list")]
        [Headers("Authorization: Bearer")]
        Task<List<LocksmithDTO>> GetLocksmithList();

        [Get("/get-locksmith-services")]
        [Headers("Authorization: Bearer")]
        Task<List<Service>> GetLocksmithServices([Body(BodySerializationMethod.Serialized)] int locksmith_id);

        //WHATSAPP
        [Get("/get-whatsapp-url")]
        [Headers("Authorization: Bearer")]
        Task<MsgDTO> GetWhatsapp([Body(BodySerializationMethod.Serialized)] int service_id);
    }
}