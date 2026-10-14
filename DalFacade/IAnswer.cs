namespace DalFacade;

using DO;
using global::DO;

public interface IAnswer
{
    void Add(Answer answer);
    Answer? Read(int id);
    IEnumerable<Answer> ReadAll();
    void Update(Answer answer);
    void Delete(int id);
}