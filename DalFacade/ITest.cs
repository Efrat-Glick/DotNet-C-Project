namespace DalFacade;

using DO;
using global::DO;

public interface ITest
{
    void Add(Test test);
    Test? Read(int id);
    IEnumerable<Test> ReadAll();
    void Update(Test test);
    void Delete(int id);
}