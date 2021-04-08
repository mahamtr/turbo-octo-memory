using BANKEST2.Core.Entities;

namespace BANKEST2.Core.Services
{
    public interface IPersonVerifier
    {
        bool IsPersonValid(Person person);
    }
}