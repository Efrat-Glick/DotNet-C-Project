namespace DalFacade;


using DO;

public interface IQuestion
{
    void Add(Question question);
    Question? Read(int id);
    IEnumerable<Question> ReadAll();
    void Update(Question question);
    void Delete(int id);
}