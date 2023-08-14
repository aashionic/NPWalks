using NPWalks.API.Models.Domain;

namespace NPWalks.API.Repositories
{
    public interface IImageRepository
    {

        Task<Image>Upload(Image image);
    }
}
