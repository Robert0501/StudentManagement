using System.Text.Json.Serialization;

namespace StudentManagement.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PersonType
    {
        Student = 1,
        Teacher = 2,
        Secretary = 3

    }
}