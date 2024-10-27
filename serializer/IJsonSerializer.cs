using QuizTopEx.models;
using System.Collections.Generic;

namespace QuizTopEx.serializer
{
    public interface IJsonSerializer<TValue>
    {
        string FileName { get; }

        List<TValue> Load();
        void Save(List<TValue> items);
        void Save(User currentUser);
    }
}