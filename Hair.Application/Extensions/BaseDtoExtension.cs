﻿using Hair.Application.Common;

namespace Hair.Application.Extensions
{
    /// <summary>
    /// Classe para extensão de retorno de <see cref="BaseDto"/> contendo dados padrões e criação de um novo
    /// </summary>
    public class BaseDtoExtension
    {
        /// <summary>
        /// Cria uma <see cref="BaseDto"/> genérica para itens inválidos
        /// </summary>
        /// <param name="itemMissing"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com StatusCode 406 e mensagem sendo <paramref name="message"/></returns>
        public static BaseDto Invalid(string message = "Valor inválido") => new BaseDto(406, message);

        /// <summary>
        /// Cria uma <see cref="BaseDto"/>
        /// </summary>
        /// <param name="itemMissing"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com os dados fornecidos no parâmetro, e <paramref name="data"/> 
        /// se não inserido valor recebe <see langword="null"/></returns>
        public static BaseDto Create(int statusCode, string message, object? data = null) => new BaseDto(statusCode, message, data);

        /// <summary>
        /// Cria uma <see cref="BaseDto"/> genérica para itens não encontrados
        /// </summary>
        /// <param name="itemMissing"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com StatusCode 404 e mensagem sendo "<paramref name="itemMissing"/> não encontrado"</returns>
        public static BaseDto NotFound(string itemMissing = "Usuário") => new BaseDto(404, $"{itemMissing} não encontrado");

        /// <summary>
        /// Cria uma <see cref="BaseDto"/> genérica para situações de sucesso
        /// </summary>
        /// <param name="itemMissing"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com StatusCode 200 e mensagem sendo <paramref name="message"/> caso não alterado</returns>
        public static BaseDto Sucess(string message = "Operação conclúida") => new BaseDto(200, message);

        /// <summary>
        /// Cria uma <see cref="BaseDto"/> genérica para itens nulos
        /// </summary>
        /// <param name="itemMissing"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com StatusCode 406 e mensagem sendo "<paramref name="message"/> não pode ser nulo"</returns>
        public static BaseDto NotNull(string message = "Valor") => new(406, $"{message} não pode ser nulo");

        /// <summary>
        /// Efetua a criação de <see cref="BaseDto"/> em caso de solicitação cancelada
        /// </summary>
        /// <returns>Retorna <see cref="BaseDto"/> com status code 200 e mensagem "Solicitação cancelada"</returns>
        public static BaseDto RequestCanceled() => new(200, "Solicitação cancelada");
    }
}