using EscolaGrupo1.Entities;
using System.Collections.Generic;

namespace EscolaGrupo1.Observer
{
    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        List<object> GetProcess();

        void Notify();

        void NotifyWithSave(object toSave);
    }
}