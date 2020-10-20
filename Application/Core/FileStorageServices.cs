using System.IO;
using System.Threading.Tasks;

namespace applestore.Application.Core {
    public class FileStorageServices : IStorageServices {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStorageServices(IWebHostEnviroment webHostEnviroment) {
            _userContentFolder = Path.Combine(webHostEnviroment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public async Task DeleteFileAsync(string fileName) {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath)) 
                await Task.Run(() => File.Delete(filePath));
        }

        public string GetFileUrl(string fileName) {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName) {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}