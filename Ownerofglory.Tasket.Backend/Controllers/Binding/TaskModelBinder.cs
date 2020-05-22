using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ownerofglory.Tasket.Backend.Controllers.Binding.Dto
{
    public class TaskModelBinder : IModelBinder
    {
        public TaskModelBinder()
        {
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext.ModelName));
            }

            var httpMethod = bindingContext.HttpContext.Request.Method;
            var request = bindingContext.HttpContext.Request;

            if (httpMethod == HttpMethod.Post.Method)
            {
                var copy = new MemoryStream();

                request.Body.CopyToAsync(copy).GetAwaiter().GetResult();
                request.Body = copy;
                request.Body.Position = 0;

                using (var reader = new StreamReader(
                    stream: request.Body,
                    encoding: Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: true,
                    bufferSize: 128,
                    leaveOpen: true))
                {
                    var content = reader.ReadToEnd();
                    var taskListDto = JsonSerializer.Deserialize<TaskDto>(content);

                    bindingContext.Result = ModelBindingResult.Success(taskListDto.ToTask());
                }

            }

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
