using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByAtividadesConcluidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByAtividadesConcluidasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasParticipadasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasParticipadasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasVencidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasVencidasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingEscolasByAtividadesConcluidas;
using EduQuest.Application.UseCases.Rankings.GetRankingEscolasByBatalhasParticipadas;
using EduQuest.Application.UseCases.Rankings.GetRankingEscolasByBatalhasVencidas;
using EduQuest.Application.UseCases.Rankings.GetRankingEscolasByMediaNotas;
using EduQuest.Application.UseCases.Rankings.GetRankingTurmasByAtividadesConcluidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingTurmasByBatalhasParticipadasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingTurmasByBatalhasVencidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaNotasInEscola;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        #region Atividades Concluídas

        [HttpGet("escola/{escolaId}/alunos/atividades-concluidas")]
        public async Task<IActionResult> GetRankingAlunosByAtividadesConcluidasInEscola(
            [FromServices] IGetRankingAlunosByAtividadesConcluidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("turma/{turmaId}/alunos/atividades-concluidas")]
        public async Task<IActionResult> GetRankingAlunosByAtividadesConcluidasInTurma(
            [FromServices] IGetRankingAlunosByAtividadesConcluidasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/turmas/atividades-concluidas")]
        public async Task<IActionResult> GetRankingTurmasByAtividadesConcluidasInEscola(
            [FromServices] IGetRankingTurmasByAtividadesConcluidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escolas/atividades-concluidas")]
        public async Task<IActionResult> GetRankingEscolasByAtividadesConcluidas(
            [FromServices] IGetRankingEscolasByAtividadesConcluidasUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        #endregion

        #region Média Nota Atividades

        [HttpGet("turma/{turmaId}/alunos/media-nota-atividades")]
        public async Task<IActionResult> GetRankingAlunosMediaNotaTurma(
            [FromServices] IGetRankingAlunosByMediaNotasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/alunos/media-nota-atividades")]
        public async Task<IActionResult> GetRankingAlunosMediaNotaEscola(
            [FromServices] IGetRankingAlunosByMediaNotasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/turmas/media-nota-atividades")]
        public async Task<IActionResult> GetRankingTurmasMediaNotaEscola(
            [FromServices] IGetRankingTurmasByMediaNotasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escolas/media-nota-atividades")]
        public async Task<IActionResult> GetRankingEscolasMediaNota(
            [FromServices] IGetRankingEscolasByMediaNotasUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        #endregion

        #region Batalhas Participadas

        [HttpGet("turma/{turmaId}/alunos/batalhas-participadas")]
        public async Task<IActionResult> GetRankingAlunosBatalhasParticipadasTurma(
            [FromServices] IGetRankingAlunosByBatalhasParticipadasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/alunos/batalhas-participadas")]
        public async Task<IActionResult> GetRankingAlunosBatalhasParticipadasEscola(
            [FromServices] IGetRankingAlunosByBatalhasParticipadasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/turmas/batalhas-participadas")]
        public async Task<IActionResult> GetRankingTurmasBatalhasParticipadasEscola(
            [FromServices] IGetRankingTurmasByBatalhasParticipadasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escolas/batalhas-participadas")]
        public async Task<IActionResult> GetRankingEscolasBatalhasParticipadas(
            [FromServices] IGetRankingEscolasByBatalhasParticipadasUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        #endregion

        #region Batalhas Vencidas

        [HttpGet("turma/{turmaId}/alunos/batalhas-vencidas")]
        public async Task<IActionResult> GetRankingAlunosBatalhasVencidasTurma(
            [FromServices] IGetRankingAlunosByBatalhasVencidasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/alunos/batalhas-vencidas")]
        public async Task<IActionResult> GetRankingAlunosBatalhasVencidasEscola(
            [FromServices] IGetRankingAlunosByBatalhasVencidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escola/{escolaId}/turmas/batalhas-vencidas")]
        public async Task<IActionResult> GetRankingTurmasBatalhasVencidasEscola(
            [FromServices] IGetRankingTurmasByBatalhasVencidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        [HttpGet("escolas/batalhas-vencidas")]
        public async Task<IActionResult> GetRankingEscolasBatalhasVencidas(
            [FromServices] IGetRankingEscolasByBatalhasVencidasUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        #endregion
    }
}
