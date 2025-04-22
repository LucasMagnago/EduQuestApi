namespace EduQuest.Communication.Requests
{
    public class RequestRemoveProfessorFromTurmaJson
    {
        public int ProfessorId { get; set; }
        public int TurmaId { get; set; }
        public int DisciplinaId { get; set; }
    }
}
