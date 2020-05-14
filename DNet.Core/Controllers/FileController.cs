using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DNet.Core.Common.Helper;
using DNet.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace DNet.Core.Controllers
{
    /// <summary>
    /// 文件管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly string fileFolderBaseName = "upload";
        #region 文件下载
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("down")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
        public IActionResult DownImg([FromQuery]string filePath, [FromServices] IWebHostEnvironment environment)
        {
            if (string.IsNullOrWhiteSpace(filePath) || filePath.Length < 4)
            {
                return BadRequest("参数错误");
            }
            if (filePath.StartsWith("/")) filePath = filePath.TrimStart('/');//去除开头的路径的/
            string folderName = "";
            string fileFullPath = Path.Combine(environment.WebRootPath, folderName, filePath);
            try
            {
                var stream = System.IO.File.OpenRead(fileFullPath);

                string fileExt = FileHelper.GetPostfixStr(filePath);
                //获取文件得ContentType
                var provider = new FileExtensionContentTypeProvider();
                var memi = provider.Mappings[fileExt];
                var fileName = Path.GetFileName(fileFullPath);

                return File(stream, memi, fileName);
            }
            catch (Exception)
            {
                return BadRequest("未找到该文件路径");
            }
        }
        #endregion

        #region 多文件上传
        /// <summary>
        /// 多文件上传
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload/multi")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadImages([FromServices]IWebHostEnvironment environment)
        {
            IFormFileCollection files = Request.Form.Files;
            if (files == null || !files.Any()) return BadRequest("请选择上传文件");
            //一次上传数量限制
            var maxFiles = 9;
            if (files.Count > maxFiles) return BadRequest($"一次上传数量不能超过{maxFiles}个");
            //格式限制
            var allowTypes = new string[] { "image/jpg", "image/png", "image/jpeg" };
            if (!files.Any(c => allowTypes.Contains(c.ContentType))) return BadRequest($"文件格式不正确,只允许上传[{string.Join(",", allowTypes)}]");
            //限制上传文件大小 
            var maxFileLarge = 1024 * 1024 * 4;
            if (files.Any(c => c.Length > maxFileLarge)) return BadRequest("文件过大");
            var today = DateTime.Today.ToString("yyyyMMdd");
            var baseFolder = fileFolderBaseName + @"/" + today;
            string folderPath = Path.Combine(environment.WebRootPath, baseFolder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePathList = new List<string>();
            foreach (var file in files)
            {
                //var fileName = Path.GetRandomFileName().Replace(".", "") + "_" + file.FileName;
                var name = file.FileName.Trim();
                var fileName = name.Substring(0, name.LastIndexOf("."));
                var fileExt = FileHelper.GetPostfixStr(name);
                fileName = fileName + "_" + Path.GetRandomFileName().Replace(".", "") + fileExt;
                filePathList.Add(baseFolder + @"/" + fileName);
                string filePath = Path.Combine(folderPath, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                    await stream.FlushAsync();
                }
            }
            return Ok(filePathList);
        }
        #endregion


        #region 使用封装的FormFile上传
        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <param name="file">UserFile</param>
        /// <param name="environment">environment</param>
        /// <returns></returns>
        [HttpPost("file")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> UseFormAttributeUpload([FromForm] UserFile file, [FromServices]IWebHostEnvironment environment)
        {
            if (file == null || !file.IsValid)
                return BadRequest("不允许上传的文件类型");
            if (file == null) return BadRequest("请选择上传文件");
            var today = DateTime.Today.ToString("yyyyMMdd");
            var baseFolder = fileFolderBaseName + @"/" + today;
            string folderPath = Path.Combine(environment.WebRootPath, baseFolder);
            string fileName = await file.SaveAs(folderPath);
            return Ok(baseFolder + "/" + fileName);
        }
        #endregion

        #region 文件上传的两种方式 1.流 2.缓存
        /// <summary>
        /// 流式文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost("stream")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadingStream()
        {
            //获取boundary
            var boundary = HeaderUtilities.RemoveQuotes(MediaTypeHeaderValue.Parse(Request.ContentType).Boundary).Value;
            //得到reader
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            //{BodyLengthLimit=2000};
            var section = await reader.ReadNextSectionAsync();
            var today = DateTime.Today.ToString("yyyyMMdd");
            var baseFolder = fileFolderBaseName + @"\\" + today;
            //读取section
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);
                if (hasContentDispositionHeader)
                {
                    var trustedFileNameForFileStorage = Path.GetRandomFileName();
                    await WriteFileAsync(section.Body, Path.Combine(baseFolder, trustedFileNameForFileStorage));
                }
                section = await reader.ReadNextSectionAsync();
            }
            return Created(nameof(FileController), null);
        }


        /// <summary>
        /// 缓存式文件上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("form")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadingFormFile(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var today = DateTime.Today.ToString("yyyyMMdd");
                var baseFolder = fileFolderBaseName + @"\" + today;
                var trustedFileNameForFileStorage = Path.GetRandomFileName().Replace(",", "") + "_" + file.FileName;
                await WriteFileAsync(stream, Path.Combine(baseFolder, trustedFileNameForFileStorage));
                return Created(nameof(FileController), null);
            }

        }

        /// <summary>
        /// 缓存式文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost("form/multi")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadingFormFile()
        {
            try
            {
                var files = Request.Form.Files;
                if (files == null || files.Count == 0)
                {
                    return BadRequest("file 不能为空");
                }
                var today = DateTime.Today.ToString("yyyyMMdd");
                var baseFolder = fileFolderBaseName + @"\\" + today;
                foreach (var file in files)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var trustedFileNameForFileStorage = Path.GetRandomFileName().Replace(",", "") + "_" + file.FileName;
                        await WriteFileAsync(stream, Path.Combine(baseFolder, trustedFileNameForFileStorage));
                    }
                }
                return Created(nameof(FileController), null);
            }
            catch (Exception e)
            {
                return BadRequest("上传文件出错," + e.Message);
            }

        }


        /// <summary>
        /// 写文件到磁盘
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="path">文件保存路径</param>
        /// <returns></returns>
        public static async Task<int> WriteFileAsync(System.IO.Stream stream, string path)
        {
            const int FILE_WRITE_SIZE = 84975;//写入缓存区大小
            int writeCount = 0;
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write, FILE_WRITE_SIZE, true))
            {
                byte[] byteArr = new byte[FILE_WRITE_SIZE];
                int readCount = 0;
                while ((readCount = await stream.ReadAsync(byteArr, 0, byteArr.Length)) > 0)
                {
                    await fileStream.WriteAsync(byteArr, 0, readCount);
                    writeCount += readCount;
                }
            }
            return writeCount;
        }
        #endregion
    }
}