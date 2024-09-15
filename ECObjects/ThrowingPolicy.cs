
namespace ECObjects
{
    internal class ThrowingPolicy
    {
        internal static Exception Apply(Exception exception)
        {
            throw exception;
        }
    }
}