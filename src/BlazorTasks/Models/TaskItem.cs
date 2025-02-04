using Microsoft.AspNetCore.Components;

namespace BlazorTasks.Models
{
    public class TaskItem
    {
        public string? Name { get; set; } = string.Empty;
        public bool IsEditMode { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public string ElementClass { get; set; } = string.Empty;
        public ElementReference Reference { get; set; } = new ElementReference();
    }
}
