using System;
using System.Threading.Tasks;

namespace Infrastructure.Utils.Interfaces
{
    public interface IHttpClientCustom
    {
        Task<T> GetAsync<T>(Uri requestUrl);
    }
}
