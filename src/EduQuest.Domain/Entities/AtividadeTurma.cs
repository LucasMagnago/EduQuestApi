﻿using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AtividadeTurma
    {
        [Key]
        public int Id { get; set; }

        // 1. Atividade ---> AtividadeTurma <--- Turma
        public int AtividadeId { get; set; }
        public Atividade Atividade { get; set; } = null!;
        public int TurmaId { get; set; }
        public Turma Turma { get; set; } = null!;
    }
}
