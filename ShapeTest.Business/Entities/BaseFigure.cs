using System;
using System.Collections.Generic;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Entities
{
    public abstract class BaseFigure : IFigure
    {
        protected string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetAndRaiseIfChanged(ref _Name, value); }
        }

        public event EntityChangedEventHandler EntityChanged;
        public void OnEntityChanged()
        {
            EntityChangedEventHandler handler = EntityChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public void SetAndRaiseIfChanged<T>(ref T backingField, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(backingField, newValue))
            {
                backingField = newValue;
                OnEntityChanged();
            }
        }
        public abstract double GetArea();
    }
}