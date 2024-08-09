﻿using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Implements
{
    public interface IUsuarioController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioDto>> Getall();
        Task<ActionResult<UsuarioDto>> Save([FromBody] UsuarioDto entity);
        Task<UsuarioDto> GetById(int id);
        Task<ActionResult> UpdateById(int id, [FromBody] UsuarioDto entity);

    }
}
