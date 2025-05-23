﻿using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.UsuarioEscolaPerfis.Assign
{
    internal class AssignUserToSchoolWithRoleUseCase : IAssingUserToSchoolWithRoleUseCase
    {
        private readonly IEscolaRepository _escolaRepository;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignUserToSchoolWithRoleUseCase(IEscolaRepository escolaRepository,
            IPerfilRepository perfilRepository,
            IUsuarioRepository usuarioRepository,
            IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IUnitOfWork unitOfWork)
        {
            _escolaRepository = escolaRepository;
            _perfilRepository = perfilRepository;
            _usuarioRepository = usuarioRepository;
            _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAssignedUsuarioJson> Execute(RequestAssignUsuarioJson request)
        {
            bool existsUsuario = await _usuarioRepository.ExistsWithIdAsync(request.UsuarioId);
            if (!existsUsuario)
                throw new NotFoundException("O usuário não foi encontrado"); // Alterar exception

            bool existsEscola = await _escolaRepository.ExistsWithIdAsync(request.EscolaId);
            if (!existsEscola)
                throw new NotFoundException("A escola não foi encontrada"); // Alterar exception

            bool existPerfil = await _perfilRepository.ExistsWithIdAsync(request.PerfilId);
            if (!existPerfil)
                throw new NotFoundException("O perfil não foi encontrado"); // Alterar exception

            bool existVinculo = await _usuarioEscolaPerfilRepository.DoesUsuarioHavePerfilInEscolaAsync(request.UsuarioId, request.EscolaId, request.PerfilId);
            if (existVinculo)
                throw new ConflictException("O usuário já está vínculado a esta disciplina nesta turma"); // Alterar exception

            var usuarioEscolaPerfil = new UsuarioEscolaPerfil
            {
                UsuarioId = request.UsuarioId,
                EscolaId = request.EscolaId,
                PerfilId = request.PerfilId,
                Ativo = false
            };

            await _usuarioEscolaPerfilRepository.SaveAsync(usuarioEscolaPerfil);
            await _unitOfWork.Commit();

            return new ResponseAssignedUsuarioJson
            {
                UsuarioId = usuarioEscolaPerfil.UsuarioId,
                EscolaId = usuarioEscolaPerfil.EscolaId,
                PerfilId = usuarioEscolaPerfil.PerfilId,
                Ativo = usuarioEscolaPerfil.Ativo,
                CreatedAt = DateTime.Now
            };
        }
    }
}
