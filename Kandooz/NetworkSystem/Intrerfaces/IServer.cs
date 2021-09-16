
public interface IServer 
{
    void Send(Message message,uint reciverID);
    void Broadcast(Message message);
    void Join(string id);
    void Create(string id);
    void Update();
}
