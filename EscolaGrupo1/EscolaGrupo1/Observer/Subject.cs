using System;
using System.Collections.Generic;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Observer
{
    public class Subject : ISubject
    {
        private readonly List<IObserver> _observers;
        private readonly List<object> _toProcess;

        public Subject()
        {
            _observers = new List<IObserver>();
            _toProcess = new List<object>();
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        // Trigger an update in each subscriber.
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public List<object> GetProcess()
        {
            var cloneProcess = new List<object>(_toProcess);
            _toProcess.Clear();
            return cloneProcess;
        }

        public void NotifyWithSave(object toSave)
        {
            _toProcess.Add(toSave);
            Notify();
        }
    }
}
