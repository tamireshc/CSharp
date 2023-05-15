using System.Runtime.Serialization;

namespace LoggingIn.Core;

public enum Species
{
    [EnumMember(Value = "Dog")]
    Dog,
    [EnumMember(Value = "Cat")]
    Cat,
    [EnumMember(Value = "Bird")]
    Bird,
    [EnumMember(Value = "Fish")]
    Fish
}