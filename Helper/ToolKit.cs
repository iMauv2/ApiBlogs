using Blogs.Dto;
using Blogs.Repository;
using Blogs.Models;

namespace Blogs.Helper
{
    public static class ToolKit
    {
        public static List<EntradasPendientesDto> GetEntradaDto(EntradaRepository entradaRepository, UsuarioRepository usuarioRepository)
        {
            return (from entradas in entradaRepository.GetEntradasByEstado("P")
                join usuarios in usuarioRepository.GetAllUsuarios() on entradas.id_Usuario equals usuarios.id
                select new EntradasPendientesDto
                {
                    id_Entrada = entradas.id,
                    nombreUsuario = usuarios.nombre,
                    texto = entradas.texto,
                    fechaIngreso = entradas.fechaIngreso,
                }).ToList();
        }
    }
}
