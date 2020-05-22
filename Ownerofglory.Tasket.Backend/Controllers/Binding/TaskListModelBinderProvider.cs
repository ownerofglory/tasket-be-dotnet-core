using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Controllers.Binding
{
    public class TaskListModelBinderProvider: IModelBinderProvider
    {
        public TaskListModelBinderProvider()
        {
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(TaskList))
                return new TaskListModelBinder();

            return null;
        }
    }
}
