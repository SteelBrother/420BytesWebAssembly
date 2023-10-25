﻿using _420BytesWebAssembly.DT.DTOs;

namespace _420BytesProyectAssembly.PWA.Client.Model.Interfaces
{
    public interface IConexionRest
    {
        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T enviar);
    }
}
