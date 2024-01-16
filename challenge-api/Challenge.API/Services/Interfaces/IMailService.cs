using Challenge.API.Services.Dto;

namespace Challenge.API.Services.Interfaces
{
    public interface IMailService
    {
        void SendEmail(MailDto request);
    }
}
