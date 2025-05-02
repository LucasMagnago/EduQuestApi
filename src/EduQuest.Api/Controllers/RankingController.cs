using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByAtividadeConcluidaInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByAtividadeConcluidaInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasParticipadasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasParticipadasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasVencidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByBatalhasVencidasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotaInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByMediaNotaInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesAcertadasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesAcertadasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesRespondidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingAlunosByQuestoesRespondidasInTurma;
using EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaAtividadesConcluidasInEscola;
using EduQuest.Application.UseCases.Rankings.GetRankingTurmasByMediaGeralNotaInEscola;
using EduQuest.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EduQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        #region Atividades Concluídas

        /// <summary>
        /// Obtém o ranking de alunos por número de atividades concluídas dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de alunos da escola com sua contagem de atividades concluídas.</returns>
        [HttpGet("escola/{escolaId}/alunos/atividades-concluidas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosAtividadeConcluidaEscola(
            [FromServices] IGetRankingAlunosByAtividadeConcluidaInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de alunos por número de atividades concluídas dentro de uma turma específica.
        /// </summary>
        /// <param name="turmaId">ID da Turma</param>
        /// <returns>Lista ordenada de alunos com sua contagem de atividades concluídas.</returns>
        [HttpGet("turma/{turmaId}/alunos/atividades-concluidas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosAtividadeConcluidaTurma(
            [FromServices] IGetRankingAlunosByAtividadeConcluidaInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de turmas por média de atividades concluídas por aluno dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de turmas da escola com a média de atividades concluídas por aluno.</returns>
        [HttpGet("escola/{escolaId}/turmas/atividades-concluidas-media")]
        [ProducesResponseType(typeof(List<ResponseRankingTurmaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingTurmasMediaAtividadeConcluidaEscola(
            [FromServices] IGetRankingTurmasByMediaAtividadesConcluidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }
        #endregion

        #region Média Nota Atividades

        /// <summary>
        /// Obtém o ranking de alunos pela média de notas nas atividades concluídas dentro de uma turma específica.
        /// </summary>
        /// <param name="turmaId">ID da Turma</param>
        /// <returns>Lista ordenada de alunos com sua média de notas.</returns>
        [HttpGet("turma/{turmaId}/alunos/media-nota-atividades")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosMediaNotaTurma(
            [FromServices] IGetRankingAlunosByMediaNotaInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de alunos pela média de notas nas atividades concluídas dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de alunos da escola com sua média de notas.</returns>
        [HttpGet("escola/{escolaId}/alunos/media-nota-atividades")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosMediaNotaEscola(
            [FromServices] IGetRankingAlunosByMediaNotaInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de turmas pela média geral de notas (média das médias dos alunos) dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de turmas da escola com a média geral de notas.</returns>
        [HttpGet("escola/{escolaId}/turmas/media-geral-nota-atividades")]
        [ProducesResponseType(typeof(List<ResponseRankingTurmaJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingTurmasMediaGeralNotaEscola(
            [FromServices] IGetRankingTurmasByMediaGeralNotaInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        #endregion

        #region Batalhas Participadas

        /// <summary>
        /// Obtém o ranking de alunos por número de batalhas participadas dentro de uma turma específica.
        /// </summary>
        /// <param name="turmaId">ID da Turma</param>
        /// <returns>Lista ordenada de alunos com sua contagem de batalhas participadas.</returns>
        [HttpGet("turma/{turmaId}/alunos/batalhas-participadas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosBatalhasParticipadasTurma(
            [FromServices] IGetRankingAlunosByBatalhasParticipadasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de alunos por número de batalhas participadas dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de alunos da escola com sua contagem de batalhas participadas.</returns>
        [HttpGet("escola/{escolaId}/alunos/batalhas-participadas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosBatalhasParticipadasEscola(
            [FromServices] IGetRankingAlunosByBatalhasParticipadasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        #endregion

        #region Batalhas Vencidas

        /// <summary>
        /// Obtém o ranking de alunos por número de batalhas vencidas dentro de uma turma específica.
        /// </summary>
        /// <param name="turmaId">ID da Turma</param>
        /// <returns>Lista ordenada de alunos com sua contagem de batalhas vencidas.</returns>
        [HttpGet("turma/{turmaId}/alunos/batalhas-vencidas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosBatalhasVencidasTurma(
            [FromServices] IGetRankingAlunosByBatalhasVencidasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de alunos por número de batalhas vencidas dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de alunos da escola com sua contagem de batalhas vencidas.</returns>
        [HttpGet("escola/{escolaId}/alunos/batalhas-vencidas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosBatalhasVencidasEscola(
            [FromServices] IGetRankingAlunosByBatalhasVencidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        #endregion

        #region Questões Respondidas

        /// <summary>
        /// Obtém o ranking de alunos por número total de questões respondidas (atividades + batalhas) dentro de uma turma específica.
        /// </summary>
        /// <param name="turmaId">ID da Turma</param>
        /// <returns>Lista ordenada de alunos com sua contagem total de questões respondidas.</returns>
        [HttpGet("turma/{turmaId}/alunos/questoes-respondidas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosQuestoesRespondidasTurma(
            [FromServices] IGetRankingAlunosByQuestoesRespondidasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de alunos por número total de questões respondidas (atividades + batalhas) dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de alunos da escola com sua contagem total de questões respondidas.</returns>
        [HttpGet("escola/{escolaId}/alunos/questoes-respondidas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosQuestoesRespondidasEscola(
            [FromServices] IGetRankingAlunosByQuestoesRespondidasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        #endregion

        #region Questões Acertadas

        /// <summary>
        /// Obtém o ranking de alunos por número total de questões acertadas (atividades + batalhas) dentro de uma turma específica.
        /// </summary>
        /// <param name="turmaId">ID da Turma</param>
        /// <returns>Lista ordenada de alunos com sua contagem total de questões acertadas.</returns>
        [HttpGet("turma/{turmaId}/alunos/questoes-acertadas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosQuestoesAcertadasTurma(
            [FromServices] IGetRankingAlunosByQuestoesAcertadasInTurmaUseCase useCase,
            [FromRoute] int turmaId)
        {
            var response = await useCase.Execute(turmaId);
            return Ok(response);
        }

        /// <summary>
        /// Obtém o ranking de alunos por número total de questões acertadas (atividades + batalhas) dentro de uma escola específica.
        /// </summary>
        /// <param name="escolaId">ID da Escola</param>
        /// <returns>Lista ordenada de alunos da escola com sua contagem total de questões acertadas.</returns>
        [HttpGet("escola/{escolaId}/alunos/questoes-acertadas")]
        [ProducesResponseType(typeof(List<ResponseRankingAlunoJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRankingAlunosQuestoesAcertadasEscola(
            [FromServices] IGetRankingAlunosByQuestoesAcertadasInEscolaUseCase useCase,
            [FromRoute] int escolaId)
        {
            var response = await useCase.Execute(escolaId);
            return Ok(response);
        }

        #endregion
    }
}
