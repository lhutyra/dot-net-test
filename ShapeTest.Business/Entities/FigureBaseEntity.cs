using System;
using System.Collections.Generic;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Entities
{
    public abstract class FigureBaseEntity : IFigure
    {
        public event EntityChangedEventHandler EntityChanged;
        public virtual void OnEntityChanged()
        {
            EntityChangedEventHandler handler = EntityChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public virtual void SetAndRaiseIfChanged<T>(ref T backingField, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(backingField, newValue))
            {
                backingField = newValue;
                OnEntityChanged();
            }
        }

        public abstract string Name { get; set; }
        public abstract double GetArea();

    }
}