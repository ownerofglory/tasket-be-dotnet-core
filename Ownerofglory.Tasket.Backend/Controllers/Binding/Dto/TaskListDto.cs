using System;
using Newtonsoft.Json;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Controllers.Binding.Dto
{
    public class TaskListDto
    {
        public long? Id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        public string spaceId { get; set; }


        public TaskListDto()
        {
        }

        public TaskList ToTaskList()
        {
            return new TaskList
            {
                Name = name,
                SpaceId = long.Parse(spaceId)
            };
        }
    }
}
