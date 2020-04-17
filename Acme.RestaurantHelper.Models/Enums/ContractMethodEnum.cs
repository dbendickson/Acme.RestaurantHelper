using System.ComponentModel;

namespace Acme.RestaurantHelper.Models.Enums
{
    public enum ContactMethodEnum
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Text Message")]
        TextMessage = 1,
        [Description("Email")]
        Email = 2,
        [Description("Phone Call")]
        PhoneCall = 3
    }
}
