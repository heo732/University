using System.ComponentModel;

namespace MainTool.Enums
{
    public enum TaskType
    {
        [Description("Найкоротший шлях на мережі")]
        ShortestWay,
        [Description("Максимальний потік на мережі")]
        MaxFlow
    }
}