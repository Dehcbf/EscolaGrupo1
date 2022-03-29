namespace EscolaGrupo1.Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);

        void ToList();
    }
}