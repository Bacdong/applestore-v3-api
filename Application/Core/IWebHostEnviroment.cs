#region Assembly Microsoft.AspNetCore.Hosting.Abstractions, Version=3.1.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// Microsoft.AspNetCore.Hosting.Abstractions.dll
#endregion

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace applestore.Application.Core {
    public interface IWebHostEnviroment : Microsoft.Extensions.Hosting.IHostEnvironment {
        //
        // Summary:
        //     Gets or sets an Microsoft.Extensions.FileProviders.IFileProvider pointing at
        //     Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath.
        IFileProvider WebRootFileProvider { get; set; }
        //
        // Summary:
        //     Gets or sets the absolute path to the directory that contains the web-servable
        //     application content files.
        string WebRootPath { get; set; }
    }
}