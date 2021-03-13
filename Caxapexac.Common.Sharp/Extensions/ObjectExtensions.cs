// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class ObjectExtensions
    {
        public static bool HasMethod(this object self, string methodName)
        {
            return self.GetType().GetMethod(methodName) != null;
        }

        public static bool HasField(this object self, string fieldName)
        {
            return self.GetType().GetField(fieldName) != null;
        }

        public static bool HasProperty(this object self, string propertyName)
        {
            return self.GetType().GetProperty(propertyName) != null;
        }
    }
}