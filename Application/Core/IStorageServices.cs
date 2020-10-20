using System.IO;
using System.Threading.Tasks;

namespace applestore.Application.Core {
    public interface IStorageServices {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}